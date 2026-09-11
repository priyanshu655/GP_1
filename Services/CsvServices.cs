using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using Npgsql;

namespace GP_1.Services
{
    /// <summary>
    /// Result summary returned after an import operation, so the UI
    /// can show the user exactly what happened.
    /// </summary>
    public class CsvImportResult
    {
        #region Variable Declaration

        public int TotalRows { get; set; }
        public int SuccessCount { get; set; }
        public int FailedCount { get; set; }
        public List<string> Errors { get; set; } = new List<string>();

        #endregion
    }

    /// <summary>
    /// Handles CSV Import/Export for transaction records (File > Import Records / Export Records).
    /// CSV format matches t_transaction columns directly:
    /// c_user_id,c_category_id,c_transaction_date,c_description,c_amount
    /// </summary>
    public class CsvService
    {
        #region Variable Declaration

        private readonly string _connectionString;

        #endregion

        #region Common

        public CsvService(string connectionString)
        {
            _connectionString = connectionString;
        }

        #endregion

        #region Functions

        //START: Added By: Trupti Date: 11-Sep-2026 Desc: Export all transactions to a CSV file
        /// <summary>
        /// Exports transactions to a CSV file.
        /// If userId is null, exports all users' transactions.
        /// If userId is given, exports only that user's transactions.
        /// </summary>
        public void ExportTransactions(string filePath, int? userId = null)
        {
            string strQuery = @"
                SELECT c_user_id,
                       c_category_id,
                       c_transaction_date,
                       c_description,
                       c_amount
                FROM t_transaction";

            if (userId.HasValue)
            {
                strQuery += " WHERE c_user_id = @userId";
            }

            strQuery += " ORDER BY c_transaction_date;";

            using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                writer.WriteLine("c_user_id,c_category_id,c_transaction_date,c_description,c_amount");

                using (NpgsqlConnection conn = new NpgsqlConnection(_connectionString))
                using (NpgsqlCommand cmd = new NpgsqlCommand(strQuery, conn))
                {
                    if (userId.HasValue)
                    {
                        cmd.Parameters.AddWithValue("userId", userId.Value);
                    }

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string uid = reader["c_user_id"].ToString();
                            string catId = reader["c_category_id"].ToString();
                            string date = ((DateOnly)reader["c_transaction_date"]).ToString("yyyy-MM-dd");
                            string description = EscapeCsvField(reader["c_description"].ToString());
                            string amount = ((decimal)reader["c_amount"]).ToString(CultureInfo.InvariantCulture);

                            writer.WriteLine($"{uid},{catId},{date},{description},{amount}");
                        }
                    }
                }
            }
        }
        //END: Added By: Trupti Date: 11-Sep-2026 Desc: Export all transactions to a CSV file

        //START: Added By: Trupti Date: 11-Sep-2026 Desc: Import transactions from a CSV file
        /// <summary>
        /// Imports transactions from a CSV file. Each row provides its own
        /// c_user_id and c_category_id directly (no lookups needed).
        /// Invalid rows are skipped and reported instead of stopping the whole import.
        /// </summary>
        public CsvImportResult ImportTransactions(string filePath)
        {
            CsvImportResult result = new CsvImportResult();

            if (!File.Exists(filePath))
            {
                result.Errors.Add("Please select a valid CSV file. The selected file could not be found.");
                return result;
            }

            string[] lines = File.ReadAllLines(filePath);

            if (lines.Length <= 1)
            {
                result.Errors.Add("The selected CSV file has no records to import. Please select a file that contains at least one data row.");
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
                            throw new FormatException($"Please check row {rowNumber}. Each row must have 5 columns (c_user_id, c_category_id, c_transaction_date, c_description, c_amount).");
                        }

                        if (!int.TryParse(fields[0].Trim(), out int userId))
                        {
                            throw new FormatException($"Please enter a valid user ID in row {rowNumber}. Only whole numbers are allowed.");
                        }

                        if (!int.TryParse(fields[1].Trim(), out int categoryId))
                        {
                            throw new FormatException($"Please enter a valid category ID in row {rowNumber}. Only whole numbers are allowed.");
                        }

                        DateOnly transactionDate;
                        if (!DateOnly.TryParseExact(fields[2].Trim(), "yyyy-MM-dd",
                                CultureInfo.InvariantCulture, DateTimeStyles.None, out transactionDate))
                        {
                            throw new FormatException($"Please enter a valid transaction date in row {rowNumber} (expected format: yyyy-MM-dd).");
                        }

                        string description = fields[3].Trim();

                        if (string.IsNullOrWhiteSpace(description))
                        {
                            throw new FormatException($"Please enter a description in row {rowNumber}. This field cannot be empty.");
                        }

                        if (description.Length > 255)
                        {
                            throw new FormatException($"Please shorten the description in row {rowNumber}. The description cannot be longer than 255 characters.");
                        }

                        if (!decimal.TryParse(fields[4].Trim(), NumberStyles.Number,
                                CultureInfo.InvariantCulture, out decimal amount))
                        {
                            throw new FormatException($"Please enter a valid amount in row {rowNumber} (numeric characters only).");
                        }

                        if (amount <= 0)
                        {
                            throw new FormatException($"Please enter an amount greater than zero in row {rowNumber}.");
                        }

                        if (!RecordExists(conn, "t_user", "c_user_id", userId))
                        {
                            throw new FormatException($"Row {rowNumber} refers to user ID {userId}, which does not exist. Please add this user first or correct the ID.");
                        }

                        if (!RecordExists(conn, "t_category", "c_category_id", categoryId))
                        {
                            throw new FormatException($"Row {rowNumber} refers to category ID {categoryId}, which does not exist. Please add this category first or correct the ID.");
                        }

                        InsertTransaction(conn, userId, categoryId, transactionDate, description, amount);

                        result.SuccessCount++;
                    }
                    catch (FormatException ex)
                    {
                        result.FailedCount++;
                        result.Errors.Add(ex.Message);
                    }
                    catch (Exception)
                    {
                        result.FailedCount++;
                        result.Errors.Add($"Row {rowNumber} could not be saved. Please check the row values and try again.");
                    }
                }
            }

            return result;
        }
        //END: Added By: Trupti Date: 11-Sep-2026 Desc: Import transactions from a CSV file

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

        /// <summary>
        /// Wraps a field in quotes if it contains a comma or quote, and escapes inner quotes.
        /// </summary>
        private static string EscapeCsvField(string field)
        {
            if (field == null)
            {
                return string.Empty;
            }

            if (field.Contains(",") || field.Contains("\"") || field.Contains("\n"))
            {
                return "\"" + field.Replace("\"", "\"\"") + "\"";
            }

            return field;
        }

        /// <summary>
        /// Splits one CSV line into fields, correctly handling quoted values
        /// that may contain commas.
        /// </summary>
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

        #endregion
    }
}