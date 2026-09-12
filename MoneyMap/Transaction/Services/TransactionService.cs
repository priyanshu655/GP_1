using System;
using System.Collections.Generic;
using Npgsql;
using GP_1.Models;

namespace GP_1.Services
{
    public class TransactionService
    {
        private readonly string connectionString = Database.ConnectionString;

        // Load categories by transaction type name ('Income' or 'Expense')
        public List<Transaction> GetCategoriesByTypeName(string typeName)
        {
            List<Transaction> categories = new List<Transaction>();

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
                    SELECT
                        c.c_category_id,
                        c.c_category_name
                    FROM t_category c
                    INNER JOIN t_transaction_type tt
                        ON c.c_type_id = tt.c_type_id
                    WHERE
                        LOWER(tt.c_type_name) = LOWER(@typeName)
                    ORDER BY
                        c.c_category_name;";

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@typeName", typeName);

                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Transaction category = new Transaction();
                            category.CategoryId = Convert.ToInt32(reader["c_category_id"]);
                            category.CategoryName = reader["c_category_name"]?.ToString() ?? string.Empty;
                            categories.Add(category);
                        }
                    }
                }
            }

            return categories;
        }

        // Insert a new transaction
        public void AddTransaction(Transaction transaction)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
                    INSERT INTO t_transaction
                    (
                        c_user_id,
                        c_category_id,
                        c_transaction_date,
                        c_description,
                        c_amount
                    )
                    VALUES
                    (
                        @userId,
                        @categoryId,
                        @transactionDate,
                        @description,
                        @amount
                    );";

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", transaction.UserId);
                    command.Parameters.AddWithValue("@categoryId", transaction.CategoryId);
                    command.Parameters.AddWithValue("@transactionDate", DateOnly.FromDateTime(transaction.TransactionDate));
                    command.Parameters.AddWithValue("@description", transaction.Description ?? string.Empty);
                    command.Parameters.AddWithValue("@amount", transaction.Amount);

                    command.ExecuteNonQuery();
                }
            }
        }

        // Update an existing transaction
        public void UpdateTransaction(Transaction transaction)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
                    UPDATE t_transaction
                    SET
                        c_category_id = @categoryId,
                        c_transaction_date = @transactionDate,
                        c_description = @description,
                        c_amount = @amount
                    WHERE
                        c_transaction_id = @transactionId
                        AND c_user_id = @userId;";

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@categoryId", transaction.CategoryId);
                    command.Parameters.AddWithValue("@transactionDate", DateOnly.FromDateTime(transaction.TransactionDate));
                    command.Parameters.AddWithValue("@description", transaction.Description ?? string.Empty);
                    command.Parameters.AddWithValue("@amount", transaction.Amount);
                    command.Parameters.AddWithValue("@transactionId", transaction.TransactionId);
                    command.Parameters.AddWithValue("@userId", transaction.UserId);

                    command.ExecuteNonQuery();
                }
            }
        }

        // Delete a transaction
        public void DeleteTransaction(long transactionId, int userId)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
                    DELETE FROM t_transaction
                    WHERE
                        c_transaction_id = @transactionId
                        AND c_user_id = @userId;";

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@transactionId", transactionId);
                    command.Parameters.AddWithValue("@userId", userId);

                    command.ExecuteNonQuery();
                }
            }
        }

        // Load transactions for a specific user
        public List<Transaction> GetTransactionsByUserId(int userId)
        {
            List<Transaction> transactions = new List<Transaction>();

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
                    SELECT
                        tr.c_transaction_id,
                        tr.c_transaction_date,
                        tr.c_description,
                        tt.c_type_name,
                        c.c_category_name,
                        tr.c_amount,
                        tr.c_category_id
                    FROM t_transaction tr
                    INNER JOIN t_category c
                        ON tr.c_category_id = c.c_category_id
                    INNER JOIN t_transaction_type tt
                        ON c.c_type_id = tt.c_type_id
                    WHERE
                        tr.c_user_id = @userId
                    ORDER BY
                        tr.c_transaction_date DESC,
                        tr.c_transaction_id DESC;";

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);

                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Transaction transaction = new Transaction();
                            transaction.TransactionId = Convert.ToInt64(reader["c_transaction_id"]);
                            
                            if (reader["c_transaction_date"] is DateOnly dateOnly)
                            {
                                transaction.TransactionDate = dateOnly.ToDateTime(TimeOnly.MinValue);
                            }
                            else if (reader["c_transaction_date"] is DateTime dt)
                            {
                                transaction.TransactionDate = dt;
                            }

                            transaction.Description = reader["c_description"]?.ToString() ?? string.Empty;
                            transaction.TransactionType = reader["c_type_name"]?.ToString() ?? string.Empty;
                            transaction.CategoryName = reader["c_category_name"]?.ToString() ?? string.Empty;
                            transaction.Amount = Convert.ToDecimal(reader["c_amount"]);
                            transaction.CategoryId = Convert.ToInt32(reader["c_category_id"]);
                            transaction.UserId = userId;
                            transactions.Add(transaction);
                        }
                    }
                }
            }

            return transactions;
        }

        // Fetch username by user ID
        public string GetUsernameById(int userId)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT c_username FROM t_user WHERE c_user_id = @userId;";
                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@userId", userId);
                        object? result = command.ExecuteScalar();
                        return result != null ? result.ToString() ?? "" : "";
                    }
                }
            }
            catch
            {
                return "";
            }
        }
    }
}
