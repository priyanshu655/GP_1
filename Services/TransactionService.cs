using Npgsql;
using GP_1.Models;

namespace GP_1.Services
{
    public class TransactionService
    {
        private readonly string connectionString = "Server=localhost;Port=5432;Database=MoneyMap;User Id=postgres;Password=root;";

        //START: Added By: Vishw Date: 10-sep-2026 Desc: Load categories by transaction type name
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
                        tt.c_type_name = @typeName
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
                            category.CategoryName = reader["c_category_name"].ToString()!;
                            categories.Add(category);
                        }
                    }
                }
            }

            return categories;
        }
        //END: Added By: Vishw Date: 10-sep-2026 Desc: Load categories by transaction type name

        //START: Added By: Vishw Date: 10-sep-2026 Desc: Insert a new transaction
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
                    command.Parameters.AddWithValue("@transactionDate", transaction.TransactionDate);
                    command.Parameters.AddWithValue("@description", transaction.Description);
                    command.Parameters.AddWithValue("@amount", transaction.Amount);

                    command.ExecuteNonQuery();
                }
            }
        }
        //END: Added By: Vishw Date: 10-sep-2026 Desc: Insert a new transaction

        //START: Added By: Vishw Date: 10-sep-2026 Desc: Update an existing transaction
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
                    command.Parameters.AddWithValue("@transactionDate", transaction.TransactionDate);
                    command.Parameters.AddWithValue("@description", transaction.Description);
                    command.Parameters.AddWithValue("@amount", transaction.Amount);
                    command.Parameters.AddWithValue("@transactionId", transaction.TransactionId);
                    command.Parameters.AddWithValue("@userId", transaction.UserId);

                    command.ExecuteNonQuery();
                }
            }
        }
        //END: Added By: Vishw Date: 10-sep-2026 Desc: Update an existing transaction

        //START: Added By: Vishw Date: 10-sep-2026 Desc: Delete a transaction
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
        //END: Added By: Vishw Date: 10-sep-2026 Desc: Delete a transaction

        //START: Added By: Vishw Date: 10-sep-2026 Desc: Load transactions for a specific user
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
                            DateOnly dateOnly = reader.GetFieldValue<DateOnly>(reader.GetOrdinal("c_transaction_date"));
                            transaction.TransactionDate = dateOnly.ToDateTime(TimeOnly.MinValue);
                            transaction.Description = reader["c_description"].ToString()!;
                            transaction.TransactionType = reader["c_type_name"].ToString()!;
                            transaction.CategoryName = reader["c_category_name"].ToString()!;
                            transaction.Amount = Convert.ToDecimal(reader["c_amount"]);
                            transaction.CategoryId = Convert.ToInt32(reader["c_category_id"]);
                            transactions.Add(transaction);
                        }
                    }
                }
            }

            return transactions;
        }
        //END: Added By: Vishw Date: 10-sep-2026 Desc: Load transactions for a specific user
    }
}
