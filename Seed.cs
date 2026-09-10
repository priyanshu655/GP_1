using Npgsql;

public static class Seed
{
    private static readonly string connectionString = "Server=localhost;Port=5432;Database=MoneyMap;User Id=postgres;Password=root;";
    public static void Initialize()
    {
        using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
        {
            con.Open();

            try
            {
                CreateTables(con);
                InsertTransactionTypes(con);
                InsertUsers(con);
                InsertCategories(con);
                InsertTransactions(con);
                InsertBudgets(con);
                InsertSettings(con);
            }
            finally
            {
                con.Close();
            }
        }

    }

    // ============================================================
    // CREATE TABLES
    // ============================================================

    private static void CreateTables(NpgsqlConnection con)
    {
        using (NpgsqlCommand cmd = new NpgsqlCommand(@"
                
                CREATE TABLE IF NOT EXISTS t_user
                (
                    c_user_id INTEGER GENERATED ALWAYS AS IDENTITY,
                    c_username VARCHAR(50) NOT NULL,
                    c_password_hash VARCHAR(255) NOT NULL,
                    c_is_active BOOLEAN NOT NULL DEFAULT TRUE,
                    c_created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,

                    CONSTRAINT pk_user
                        PRIMARY KEY (c_user_id),

                    CONSTRAINT uq_user_username
                        UNIQUE (c_username)
                );

                CREATE TABLE IF NOT EXISTS t_transaction_type
                (
                    c_type_id INTEGER GENERATED ALWAYS AS IDENTITY,
                    c_type_name VARCHAR(20) NOT NULL,

                    CONSTRAINT pk_transaction_type
                        PRIMARY KEY (c_type_id),

                    CONSTRAINT uq_transaction_type_name
                        UNIQUE (c_type_name)
                );

                CREATE TABLE IF NOT EXISTS t_category
                (
                    c_category_id INTEGER GENERATED ALWAYS AS IDENTITY,
                    c_type_id INTEGER NOT NULL,
                    c_category_name VARCHAR(50) NOT NULL,
                    c_created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,

                    CONSTRAINT pk_category
                        PRIMARY KEY (c_category_id),

                    CONSTRAINT fk_category_transaction_type
                        FOREIGN KEY (c_type_id)
                        REFERENCES t_transaction_type(c_type_id)
                );

                CREATE TABLE IF NOT EXISTS t_transaction
                (
                    c_transaction_id BIGINT GENERATED ALWAYS AS IDENTITY,
                    c_user_id INTEGER NOT NULL,
                    c_category_id INTEGER NOT NULL,
                    c_transaction_date DATE NOT NULL DEFAULT CURRENT_DATE,
                    c_description VARCHAR(255) NULL,
                    c_amount NUMERIC(12,2) NOT NULL,
                    c_created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,

                    CONSTRAINT pk_transaction
                        PRIMARY KEY (c_transaction_id),

                    CONSTRAINT fk_transaction_user
                        FOREIGN KEY (c_user_id)
                        REFERENCES t_user(c_user_id),

                    CONSTRAINT fk_transaction_category
                        FOREIGN KEY (c_category_id)
                        REFERENCES t_category(c_category_id),

                    CONSTRAINT chk_transaction_amount
                        CHECK (c_amount > 0)
                );

                CREATE TABLE IF NOT EXISTS t_budget
                (
                    c_budget_id BIGINT GENERATED ALWAYS AS IDENTITY,
                    c_user_id INTEGER NOT NULL,
                    c_budget_percentage NUMERIC(5,2) NOT NULL,
                    c_budget_month DATE NOT NULL,
                    c_created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
                    c_updated_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,

                    CONSTRAINT pk_budget
                        PRIMARY KEY (c_budget_id),

                    CONSTRAINT fk_budget_user
                        FOREIGN KEY (c_user_id)
                        REFERENCES t_user(c_user_id),

                    CONSTRAINT chk_budget_percentage
                        CHECK
                        (
                            c_budget_percentage > 0
                            AND c_budget_percentage <= 100
                        )
                );

                CREATE TABLE IF NOT EXISTS t_setting
                (
                    c_setting_id INTEGER GENERATED ALWAYS AS IDENTITY,
                    c_user_id INTEGER NOT NULL,
                    c_font_name VARCHAR(100),
                    c_font_size NUMERIC(5,2),
                    c_text_color VARCHAR(20),
                    c_background_color VARCHAR(20),
                    c_updated_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,

                    CONSTRAINT pk_setting
                        PRIMARY KEY (c_setting_id),

                    CONSTRAINT uq_setting_user
                        UNIQUE (c_user_id),

                    CONSTRAINT fk_setting_user
                        FOREIGN KEY (c_user_id)
                        REFERENCES t_user(c_user_id),

                    CONSTRAINT chk_setting_font_size
                        CHECK
                        (
                            c_font_size IS NULL
                            OR c_font_size > 0
                        )
                );

            ", con))
        {
            cmd.ExecuteNonQuery();
        }
    }

    // ============================================================
    // INSERT TRANSACTION TYPES
    // ============================================================

    private static void InsertTransactionTypes(NpgsqlConnection con)
    {
        using (NpgsqlCommand cmd = new NpgsqlCommand(@"

                INSERT INTO t_transaction_type
                (
                    c_type_name
                )
                VALUES
                (
                    'Income'
                ),
                (
                    'Expense'
                )
                ON CONFLICT (c_type_name) DO NOTHING;

            ", con))
        {
            cmd.ExecuteNonQuery();
        }
    }

    // ============================================================
    // INSERT USERS
    // ============================================================

    private static void InsertUsers(NpgsqlConnection con)
    {
        using (NpgsqlCommand cmd = new NpgsqlCommand(@"

                INSERT INTO t_user
                (
                    c_username,
                    c_password_hash,
                    c_is_active
                )
                VALUES
                (
                    'vishw',
                    '123456',
                    TRUE
                ),
                (
                    'rahul',
                    'rahul123',
                    TRUE
                ),
                (
                    'neha',
                    'neha123',
                    TRUE
                ),
                (
                    'amit',
                    'amit123',
                    TRUE
                )
                ON CONFLICT (c_username) DO NOTHING;

            ", con))
        {
            cmd.ExecuteNonQuery();
        }
    }

    // ============================================================
    // INSERT CATEGORIES
    // ============================================================

    private static void InsertCategories(NpgsqlConnection con)
    {
        using (NpgsqlCommand cmd = new NpgsqlCommand(@"

                INSERT INTO t_category
                (
                    c_type_id,
                    c_category_name
                )
                VALUES

                -- Income Categories
                (
                    1,
                    'Salary'
                ),
                (
                    1,
                    'Business'
                ),
                (
                    1,
                    'Freelance'
                ),
                (
                    1,
                    'Interest'
                ),

                -- Expense Categories
                (
                    2,
                    'Food'
                ),
                (
                    2,
                    'Travel'
                ),
                (
                    2,
                    'Shopping'
                ),
                (
                    2,
                    'Rent'
                ),
                (
                    2,
                    'Bills'
                ),
                (
                    2,
                    'Entertainment'
                ),
                (
                    2,
                    'Medical'
                );

            ", con))
        {
            cmd.ExecuteNonQuery();
        }
    }

    // ============================================================
    // INSERT TRANSACTIONS
    // ============================================================

    private static void InsertTransactions(NpgsqlConnection con)
    {
        using (NpgsqlCommand cmd = new NpgsqlCommand(@"

                INSERT INTO t_transaction
                (
                    c_user_id,
                    c_category_id,
                    c_transaction_date,
                    c_description,
                    c_amount
                )
                VALUES

                -- ====================================================
                -- Vishw - Income
                -- ====================================================

                (
                    1,
                    1,
                    '2026-09-01',
                    'September Salary',
                    30000.00
                ),

                -- Vishw - Expenses

                (
                    1,
                    5,
                    '2026-09-02',
                    'Lunch',
                    500.00
                ),
                (
                    1,
                    6,
                    '2026-09-03',
                    'Travel Expense',
                    300.00
                ),
                (
                    1,
                    7,
                    '2026-09-04',
                    'Clothes Shopping',
                    2000.00
                ),
                (
                    1,
                    9,
                    '2026-09-05',
                    'Electricity Bill',
                    1500.00
                ),

                -- ====================================================
                -- Rahul - Income
                -- ====================================================

                (
                    2,
                    1,
                    '2026-09-01',
                    'September Salary',
                    40000.00
                ),

                -- Rahul - Expenses

                (
                    2,
                    5,
                    '2026-09-02',
                    'Food Expense',
                    1000.00
                ),
                (
                    2,
                    8,
                    '2026-09-03',
                    'House Rent',
                    10000.00
                ),
                (
                    2,
                    9,
                    '2026-09-05',
                    'Electricity Bill',
                    2000.00
                ),

                -- ====================================================
                -- Neha - Income
                -- ====================================================

                (
                    3,
                    1,
                    '2026-09-01',
                    'September Salary',
                    35000.00
                ),

                -- Neha - Expenses

                (
                    3,
                    5,
                    '2026-09-02',
                    'Food Expense',
                    800.00
                ),
                (
                    3,
                    7,
                    '2026-09-04',
                    'Shopping',
                    2500.00
                ),

                -- ====================================================
                -- Amit - Income
                -- ====================================================

                (
                    4,
                    3,
                    '2026-09-01',
                    'Freelance Project',
                    25000.00
                ),

                -- Amit - Expenses

                (
                    4,
                    6,
                    '2026-09-02',
                    'Travel Expense',
                    1200.00
                ),
                (
                    4,
                    5,
                    '2026-09-03',
                    'Food Expense',
                    700.00
                );

            ", con))
        {
            cmd.ExecuteNonQuery();
        }
    }

    // ============================================================
    // INSERT BUDGET
    // ============================================================

    private static void InsertBudgets(NpgsqlConnection con)
    {
        using (NpgsqlCommand cmd = new NpgsqlCommand(@"

                INSERT INTO t_budget
                (
                    c_user_id,
                    c_budget_percentage,
                    c_budget_month
                )
                VALUES

                (
                    1,
                    60.00,
                    '2026-09-01'
                ),
                (
                    2,
                    60.00,
                    '2026-09-01'
                ),
                (
                    3,
                    60.00,
                    '2026-09-01'
                ),
                (
                    4,
                    60.00,
                    '2026-09-01'
                );

            ", con))
        {
            cmd.ExecuteNonQuery();
        }
    }

    // ============================================================
    // INSERT USER SETTINGS
    // ============================================================

    private static void InsertSettings(NpgsqlConnection con)
    {
        using (NpgsqlCommand cmd = new NpgsqlCommand(@"

                INSERT INTO t_setting
                (
                    c_user_id,
                    c_font_name,
                    c_font_size,
                    c_text_color,
                    c_background_color
                )
                VALUES

                (
                    1,
                    'Arial',
                    12.00,
                    'Black',
                    'White'
                ),
                (
                    2,
                    'Calibri',
                    11.00,
                    'Black',
                    'White'
                ),
                (
                    3,
                    'Arial',
                    12.00,
                    'Blue',
                    'White'
                ),
                (
                    4,
                    'Times New Roman',
                    12.00,
                    'Black',
                    'LightGray'
                );

            ", con))
        {
            cmd.ExecuteNonQuery();
        }
    }
}
