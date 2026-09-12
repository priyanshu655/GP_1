using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using Npgsql;

namespace GP_1.Services
{
    /// <summary>
    /// Summary returned after an import operation.
    /// </summary>
    public class CsvImportResult
    {
        public int TotalRows { get; set; }
        public int SuccessCount { get; set; }
        public int FailedCount { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
    }

    /// <summary>
    /// Handles CSV Import/Export for transaction records.
    /// CSV format: c_user_id,c_category_id,c_transaction_date,c_description,c_amount
    /// </summary>
    public class CsvService
    {
        private readonly string _connectionString;

        public CsvService(string? connectionString = null)
        {
            _connectionString = string.IsNullOrWhiteSpace(connectionString)
                ? Database.ConnectionString
                : connectionString;
        }

        /// <summary>
        /// Exports transactions to a CSV file.
        /// If userId is specified, exports only that user's records.
        /// </summary>
        public int ExportTransactions(string filePath, int? userId = null)
        {
            string strQuery = @"
                SELECT c_user_id,
                       c_category_id,
                       c_transaction_date,
                       c_description,
                       c_amount
                FROM t_transaction";

            if (userId.HasValue && userId.Value > 0)
            {
                strQuery += " WHERE c_user_id = @userId";
            }

            strQuery += " ORDER BY c_transaction_date DESC, c_transaction_id DESC;";

            int rowCount = 0;

            using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                writer.WriteLine("c_user_id,c_category_id,c_transaction_date,c_description,c_amount");

                using (NpgsqlConnection conn = new NpgsqlConnection(_connectionString))
                using (NpgsqlCommand cmd = new NpgsqlCommand(strQuery, conn))
                {
                    if (userId.HasValue && userId.Value > 0)
                    {
                        cmd.Parameters.AddWithValue("userId", userId.Value);
                    }

                    conn.Open();

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string uid = reader["c_user_id"].ToString() ?? "";
                            string cid = reader["c_category_id"].ToString() ?? "";
                            
                            string dateStr;
                            if (reader["c_transaction_date"] is DateOnly dOnly)
                            {
                                dateStr = dOnly.ToString("yyyy-MM-dd");
                            }
                            else if (reader["c_transaction_date"] is DateTime dt)
                            {
                                dateStr = dt.ToString("yyyy-MM-dd");
                            }
                            else
                            {
                                dateStr = reader["c_transaction_date"]?.ToString() ?? "";
                            }

                            string desc = EscapeCsvField(reader["c_description"]?.ToString() ?? "");
                            string amount = Convert.ToDecimal(reader["c_amount"]).ToString("0.00", CultureInfo.InvariantCulture);

                            writer.WriteLine($"{uid},{cid},{dateStr},{desc},{amount}");
                            rowCount++;
                        }
                    }
                }
            }

            return rowCount;
        }

        /// <summary>
        /// Imports transactions from a CSV file into PostgreSQL database.
        /// </summary>
        public CsvImportResult ImportTransactions(string filePath, int? fallbackUserId = null)
        {
            CsvImportResult result = new CsvImportResult();

            if (!File.Exists(filePath))
            {
                result.Errors.Add("The selected file does not exist.");
                return result;
            }

            string[] lines = File.ReadAllLines(filePath, Encoding.UTF8);

            if (lines.Length <= 1)
            {
                return result;
            }

            using (NpgsqlConnection conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();

                // Skip header row (index 0)
                for (int i = 1; i < lines.Length; i++)
                {
                    string line = lines[i];

                    if (string.IsNullOrWhiteSpace(line))
                    {
                        continue;
                    }

                    result.TotalRows++;
                    int rowNumber = i + 1;

                    try
                    {
                        string[] fields = ParseCsvLine(line);

                        if (fields.Length < 5)
                        {
                            throw new FormatException($"Row {rowNumber}: Must have 5 columns (c_user_id, c_category_id, c_transaction_date, c_description, c_amount).");
                        }

                        int userId;
                        if (!int.TryParse(fields[0].Trim(), out userId))
                        {
                            if (fallbackUserId.HasValue && fallbackUserId.Value > 0)
                            {
                                userId = fallbackUserId.Value;
                            }
                            else
                            {
                                throw new FormatException($"Row {rowNumber}: Invalid User ID '{fields[0]}'. Only integer numbers are allowed.");
                            }
                        }

                        if (!int.TryParse(fields[1].Trim(), out int categoryId))
                        {
                            throw new FormatException($"Row {rowNumber}: Invalid Category ID '{fields[1]}'. Only integer numbers are allowed.");
                        }

                        DateOnly transactionDate;
                        string rawDate = fields[2].Trim();
                        string[] dateFormats = { "yyyy-MM-dd", "dd-MM-yyyy", "MM/dd/yyyy", "yyyy/MM/dd", "dd/MM/yyyy" };

                        if (!DateOnly.TryParseExact(rawDate, dateFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out transactionDate))
                        {
                            if (!DateOnly.TryParse(rawDate, out transactionDate))
                            {
                                throw new FormatException($"Row {rowNumber}: Invalid transaction date '{rawDate}' (supported: yyyy-MM-dd or dd-MM-yyyy).");
                            }
                        }

                        string description = fields[3].Trim();

                        if (string.IsNullOrWhiteSpace(description))
                        {
                            throw new FormatException($"Row {rowNumber}: Description cannot be empty.");
                        }

                        if (description.Length > 255)
                        {
                            throw new FormatException($"Row {rowNumber}: Description is longer than 255 characters.");
                        }

                        if (!decimal.TryParse(fields[4].Trim(), NumberStyles.Number, CultureInfo.InvariantCulture, out decimal amount))
                        {
                            throw new FormatException($"Row {rowNumber}: Invalid amount '{fields[4]}'.");
                        }

                        if (amount <= 0)
                        {
                            throw new FormatException($"Row {rowNumber}: Amount must be greater than zero.");
                        }

                        if (!RecordExists(conn, "t_user", "c_user_id", userId))
                        {
                            throw new FormatException($"Row {rowNumber}: User ID {userId} does not exist in the database.");
                        }

                        if (!RecordExists(conn, "t_category", "c_category_id", categoryId))
                        {
                            throw new FormatException($"Row {rowNumber}: Category ID {categoryId} does not exist in the database.");
                        }

                        InsertTransaction(conn, userId, categoryId, transactionDate, description, amount);

                        result.SuccessCount++;
                    }
                    catch (FormatException ex)
                    {
                        result.FailedCount++;
                        result.Errors.Add(ex.Message);
                    }
                    catch (Exception ex)
                    {
                        result.FailedCount++;
                        result.Errors.Add($"Row {rowNumber}: Failed to save ({ex.Message}).");
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Generates a sample CSV template for the user to fill out.
        /// </summary>
        public void GenerateSampleTemplate(string filePath, int sampleUserId = 1)
        {
            using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                writer.WriteLine("c_user_id,c_category_id,c_transaction_date,c_description,c_amount");
                writer.WriteLine($"{sampleUserId},1,{DateTime.Today:yyyy-MM-dd},Monthly Salary,50000.00");
                writer.WriteLine($"{sampleUserId},2,{DateTime.Today:yyyy-MM-dd},Grocery Shopping,2500.50");
                writer.WriteLine($"{sampleUserId},3,{DateTime.Today:yyyy-MM-dd},Internet Bill,999.00");
            }
        }

        private bool RecordExists(NpgsqlConnection conn, string tableName, string idColumn, int id)
        {
            string strQuery = $"SELECT {idColumn} FROM {tableName} WHERE {idColumn} = @id LIMIT 1;";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strQuery, conn))
            {
                cmd.Parameters.AddWithValue("id", id);
                return cmd.ExecuteScalar() != null;
            }
        }

        private void InsertTransaction(NpgsqlConnection conn, int userId, int categoryId,
            DateOnly transactionDate, string description, decimal amount)
        {
            string strQuery = @"
                INSERT INTO t_transaction
                    (c_user_id, c_category_id, c_transaction_date, c_description, c_amount, c_created_at)
                VALUES
                    (@userId, @categoryId, @transactionDate, @description, @amount, NOW());";

            using (NpgsqlCommand cmd = new NpgsqlCommand(strQuery, conn))
            {
                cmd.Parameters.AddWithValue("userId", userId);
                cmd.Parameters.AddWithValue("categoryId", categoryId);
                cmd.Parameters.AddWithValue("transactionDate", transactionDate);
                cmd.Parameters.AddWithValue("description", description);
                cmd.Parameters.AddWithValue("amount", amount);
                cmd.ExecuteNonQuery();
            }
        }

        private static string EscapeCsvField(string field)
        {
            if (string.IsNullOrEmpty(field))
            {
                return string.Empty;
            }

            if (field.Contains(",") || field.Contains("\"") || field.Contains("\n") || field.Contains("\r"))
            {
                return "\"" + field.Replace("\"", "\"\"") + "\"";
            }

            return field;
        }

        private static string[] ParseCsvLine(string line)
        {
            List<string> fields = new List<string>();
            StringBuilder current = new StringBuilder();
            bool inQuotes = false;

            for (int i = 0; i < line.Length; i++)
            {
                char c = line[i];

                if (inQuotes)
                {
                    if (c == '"')
                    {
                        if (i + 1 < line.Length && line[i + 1] == '"')
                        {
                            current.Append('"');
                            i++;
                        }
                        else
                        {
                            inQuotes = false;
                        }
                    }
                    else
                    {
                        current.Append(c);
                    }
                }
                else
                {
                    if (c == '"')
                    {
                        inQuotes = true;
                    }
                    else if (c == ',')
                    {
                        fields.Add(current.ToString());
                        current.Clear();
                    }
                    else
                    {
                        current.Append(c);
                    }
                }
            }

            fields.Add(current.ToString());

            return fields.ToArray();
        }
    }
}
