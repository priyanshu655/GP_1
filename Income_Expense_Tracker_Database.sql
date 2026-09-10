-- ============================================================
-- Income and Expense Tracker
-- PostgreSQL Database Script
-- Coding Standard:
-- Table Name   : t_table_name
-- Column Name  : c_column_name
-- Primary Key  : pk_keyname
-- Foreign Key  : fk_keyname
-- Unique Key   : uq_keyname
-- Check        : chk_keyname
-- SQL Keywords : UPPER CASE
-- ============================================================


-- ============================================================
-- START: Create Tables
-- ============================================================

CREATE TABLE t_user
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


CREATE TABLE t_transaction_type
(
    c_type_id INTEGER GENERATED ALWAYS AS IDENTITY,
    c_type_name VARCHAR(20) NOT NULL,

    CONSTRAINT pk_transaction_type
        PRIMARY KEY (c_type_id),

    CONSTRAINT uq_transaction_type_name
        UNIQUE (c_type_name)
);


CREATE TABLE t_category
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


CREATE TABLE t_transaction
(
    c_transaction_id BIGINT GENERATED ALWAYS AS IDENTITY,
    c_user_id INTEGER NOT NULL,
    c_category_id INTEGER NOT NULL,
    c_transaction_date DATE NOT NULL DEFAULT CURRENT_DATE,
    c_description VARCHAR(255) NOT NULL,
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


CREATE TABLE t_budget
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


CREATE TABLE t_setting
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

-- ============================================================
-- END: Create Tables
-- ============================================================


-- ============================================================
-- START: Insert Transaction Types
-- ============================================================

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
);

-- ============================================================
-- END: Insert Transaction Types
-- ============================================================


-- ============================================================
-- START: Insert Users
-- ============================================================

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
);

-- ============================================================
-- END: Insert Users
-- ============================================================


-- ============================================================
-- START: Insert Categories
-- ============================================================

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

-- ============================================================
-- END: Insert Categories
-- ============================================================


-- ============================================================
-- START: Insert Transactions
-- ============================================================

INSERT INTO t_transaction
(
    c_user_id,
    c_category_id,
    c_transaction_date,
    c_description,
    c_amount
)
VALUES

-- Vishw - Income
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

-- Rahul - Income
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

-- Neha - Income
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

-- Amit - Income
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

-- ============================================================
-- END: Insert Transactions
-- ============================================================


-- ============================================================
-- START: Insert Budget
-- 60% of income is allocated for expenses.
-- Remaining 40% is available for savings.
-- ============================================================

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

-- ============================================================
-- END: Insert Budget
-- ============================================================


-- ============================================================
-- START: Insert User Settings
-- ============================================================

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

-- ============================================================
-- END: Insert User Settings
-- ============================================================


-- ============================================================
-- START: Test Queries
-- ============================================================

-- Users
SELECT
    c_user_id,
    c_username,
    c_password_hash,
    c_is_active,
    c_created_at
FROM t_user;


-- Transaction Types
SELECT
    c_type_id,
    c_type_name
FROM t_transaction_type;


-- Categories with Transaction Type
SELECT
    c.category_id AS c_category_id,
    c.c_category_name,
    tt.c_type_name
FROM t_category c
INNER JOIN t_transaction_type tt
    ON c.c_type_id = tt.c_type_id
ORDER BY
    c.c_category_id;


-- All Transactions
SELECT
    tr.c_transaction_id,
    u.c_username,
    tt.c_type_name,
    c.c_category_name,
    tr.c_transaction_date,
    tr.c_description,
    tr.c_amount,
    tr.c_created_at
FROM t_transaction tr
INNER JOIN t_user u
    ON tr.c_user_id = u.c_user_id
INNER JOIN t_category c
    ON tr.c_category_id = c.c_category_id
INNER JOIN t_transaction_type tt
    ON c.c_type_id = tt.c_type_id
ORDER BY
    tr.c_transaction_date;


-- Budget
SELECT
    b.c_budget_id,
    u.c_username,
    b.c_budget_percentage,
    b.c_budget_month,
    b.c_created_at,
    b.c_updated_at
FROM t_budget b
INNER JOIN t_user u
    ON b.c_user_id = u.c_user_id
ORDER BY
    b.c_budget_month,
    u.c_username;


-- Settings
SELECT
    s.c_setting_id,
    u.c_username,
    s.c_font_name,
    s.c_font_size,
    s.c_text_color,
    s.c_background_color,
    s.c_updated_at
FROM t_setting s
INNER JOIN t_user u
    ON s.c_user_id = u.c_user_id
ORDER BY
    s.c_setting_id;


-- Total Income and Expense by User
SELECT
    u.c_user_id,
    u.c_username,
    COALESCE
    (
        SUM
        (
            CASE
                WHEN tt.c_type_name = 'Income'
                THEN tr.c_amount
                ELSE 0
            END
        ),
        0
    ) AS c_total_income,
    COALESCE
    (
        SUM
        (
            CASE
                WHEN tt.c_type_name = 'Expense'
                THEN tr.c_amount
                ELSE 0
            END
        ),
        0
    ) AS c_total_expense
FROM t_user u
LEFT JOIN t_transaction tr
    ON u.c_user_id = tr.c_user_id
LEFT JOIN t_category c
    ON tr.c_category_id = c.c_category_id
LEFT JOIN t_transaction_type tt
    ON c.c_type_id = tt.c_type_id
GROUP BY
    u.c_user_id,
    u.c_username
ORDER BY
    u.c_user_id;

-- ============================================================
-- END: Test Queries
-- ============================================================
