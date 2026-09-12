using System;
using System.Data;
using System.Windows.Forms;

using Npgsql;

namespace MoneyMap.AdminPanel.Transactions
{
    public partial class TransactionsControl : UserControl
    {
        #region Constructor

        public TransactionsControl()
        {
            InitializeComponent();

            LoadUsers();
            LoadCategories();
            LoadTransactions();
        }

        #endregion

        #region Events

        private void DgvTransactions_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row =
                dgvTransactions.Rows[e.RowIndex];

            txtTransactionId.Text =
                row.Cells["c_transaction_id"].Value.ToString();

            cmbUser.SelectedValue =
                row.Cells["c_user_id"].Value;

            cmbCategory.SelectedValue =
                row.Cells["c_category_id"].Value;

            DateOnly transactionDate =
                (DateOnly)row.Cells["c_transaction_date"].Value;

            dtpTransactionDate.Value =
                transactionDate.ToDateTime(TimeOnly.MinValue);

            txtDescription.Text =
                row.Cells["c_description"].Value.ToString();

            txtAmount.Text =
                row.Cells["c_amount"].Value.ToString();
        }

        private void TxtSearch_TextChanged(
            object sender,
            EventArgs e)
        {
            LoadTransactions();
        }

        private void BtnClearSearch_Click(
            object sender,
            EventArgs e)
        {
            txtSearch.Clear();
        }

        private void BtnAdd_Click(
            object sender,
            EventArgs e)
        {
            if (!ValidateFields())
            {
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to add this transaction?",
                "Confirm Add",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                return;
            }

            using (NpgsqlConnection connection =
                GP_1.Database.CreateConnection())
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
                    )";

                using (NpgsqlCommand command =
                    new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue(
                        "@userId",
                        Convert.ToInt32(cmbUser.SelectedValue));

                    command.Parameters.AddWithValue(
                        "@categoryId",
                        Convert.ToInt32(cmbCategory.SelectedValue));

                    command.Parameters.AddWithValue(
                        "@transactionDate",
                        dtpTransactionDate.Value.Date);

                    command.Parameters.AddWithValue(
                        "@description",
                        txtDescription.Text.Trim());

                    command.Parameters.AddWithValue(
                        "@amount",
                        Convert.ToDecimal(txtAmount.Text));

                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show(
                "Transaction added successfully.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            LoadTransactions();
            ClearFields();
        }

        private void BtnEdit_Click(
            object sender,
            EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTransactionId.Text))
            {
                MessageBox.Show(
                    "Please select a transaction first.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (!ValidateFields())
            {
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to update this transaction?",
                "Confirm Update",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                return;
            }

            using (NpgsqlConnection connection =
                GP_1.Database.CreateConnection())
            {
                connection.Open();

                string query = @"
                    UPDATE t_transaction
                    SET
                        c_user_id = @userId,
                        c_category_id = @categoryId,
                        c_transaction_date = @transactionDate,
                        c_description = @description,
                        c_amount = @amount
                    WHERE c_transaction_id = @transactionId";

                using (NpgsqlCommand command =
                    new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue(
                        "@userId",
                        Convert.ToInt32(cmbUser.SelectedValue));

                    command.Parameters.AddWithValue(
                        "@categoryId",
                        Convert.ToInt32(cmbCategory.SelectedValue));

                    command.Parameters.AddWithValue(
                        "@transactionDate",
                        dtpTransactionDate.Value.Date);

                    command.Parameters.AddWithValue(
                        "@description",
                        txtDescription.Text.Trim());

                    command.Parameters.AddWithValue(
                        "@amount",
                        Convert.ToDecimal(txtAmount.Text));

                    command.Parameters.AddWithValue(
                        "@transactionId",
                        Convert.ToInt64(txtTransactionId.Text));

                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show(
                "Transaction updated successfully.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            LoadTransactions();
            ClearFields();
        }

        private void BtnDelete_Click(
            object sender,
            EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTransactionId.Text))
            {
                MessageBox.Show(
                    "Please select a transaction first.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this transaction?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
            {
                return;
            }

            using (NpgsqlConnection connection =
                GP_1.Database.CreateConnection())
            {
                connection.Open();

                string query = @"
                    DELETE FROM t_transaction
                    WHERE c_transaction_id = @transactionId";

                using (NpgsqlCommand command =
                    new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue(
                        "@transactionId",
                        Convert.ToInt64(txtTransactionId.Text));

                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show(
                "Transaction deleted successfully.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            LoadTransactions();
            ClearFields();
        }

        private void BtnClear_Click(
            object sender,
            EventArgs e)
        {
            ClearFields();
        }

        #endregion

        #region Methods

        private void LoadUsers()
        {
            using (NpgsqlConnection connection =
                GP_1.Database.CreateConnection())
            {
                connection.Open();

                string query = @"
                    SELECT
                        c_user_id,
                        c_username
                    FROM t_user
                    ORDER BY c_username";

                using (NpgsqlCommand command =
                    new NpgsqlCommand(query, connection))
                {
                    using (NpgsqlDataAdapter adapter =
                        new NpgsqlDataAdapter(command))
                    {
                        DataTable dataTable =
                            new DataTable();

                        adapter.Fill(dataTable);

                        cmbUser.DataSource =
                            dataTable;

                        cmbUser.DisplayMember =
                            "c_username";

                        cmbUser.ValueMember =
                            "c_user_id";
                    }
                }
            }
        }

        private void LoadCategories()
        {
            using (NpgsqlConnection connection =
                GP_1.Database.CreateConnection())
            {
                connection.Open();

                string query = @"
                    SELECT
                        c_category_id,
                        c_category_name
                    FROM t_category
                    ORDER BY c_category_name";

                using (NpgsqlCommand command =
                    new NpgsqlCommand(query, connection))
                {
                    using (NpgsqlDataAdapter adapter =
                        new NpgsqlDataAdapter(command))
                    {
                        DataTable dataTable =
                            new DataTable();

                        adapter.Fill(dataTable);

                        cmbCategory.DataSource =
                            dataTable;

                        cmbCategory.DisplayMember =
                            "c_category_name";

                        cmbCategory.ValueMember =
                            "c_category_id";
                    }
                }
            }
        }

        private void LoadTransactions()
        {
            using (NpgsqlConnection connection =
                GP_1.Database.CreateConnection())
            {
                connection.Open();

                string query = @"
                    SELECT
                        tr.c_transaction_id,
                        tr.c_user_id,
                        u.c_username,
                        tr.c_category_id,
                        c.c_category_name,
                        tr.c_transaction_date,
                        tr.c_description,
                        tr.c_amount,
                        tr.c_created_at
                    FROM t_transaction tr
                    INNER JOIN t_user u
                        ON tr.c_user_id = u.c_user_id
                    INNER JOIN t_category c
                        ON tr.c_category_id = c.c_category_id";

                string searchText =
                    txtSearch.Text.Trim();

                if (!string.IsNullOrWhiteSpace(searchText))
                {
                    query += @"
                        WHERE
                        (
                            CAST(tr.c_transaction_id AS TEXT) ILIKE @search
                            OR u.c_username ILIKE @search
                            OR c.c_category_name ILIKE @search
                            OR tr.c_description ILIKE @search
                            OR CAST(tr.c_amount AS TEXT) ILIKE @search
                            OR CAST(tr.c_transaction_date AS TEXT) ILIKE @search
                        )";
                }

                query += @"
                    ORDER BY
                        tr.c_transaction_id";

                using (NpgsqlCommand command =
                    new NpgsqlCommand(query, connection))
                {
                    if (!string.IsNullOrWhiteSpace(searchText))
                    {
                        command.Parameters.AddWithValue(
                            "@search",
                            "%" + searchText + "%");
                    }

                    using (NpgsqlDataAdapter adapter =
                        new NpgsqlDataAdapter(command))
                    {
                        DataTable dataTable =
                            new DataTable();

                        adapter.Fill(dataTable);

                        dgvTransactions.DataSource =
                            dataTable;
                    }
                }
            }

            SetColumnHeaders();
        }

        private void SetColumnHeaders()
        {
            if (dgvTransactions.Columns.Count == 0)
            {
                return;
            }

            dgvTransactions.Columns["c_transaction_id"]
                .HeaderText = "Transaction ID";

            dgvTransactions.Columns["c_username"]
                .HeaderText = "User Name";

            dgvTransactions.Columns["c_category_name"]
                .HeaderText = "Category Name";

            dgvTransactions.Columns["c_transaction_date"]
                .HeaderText = "Transaction Date";

            dgvTransactions.Columns["c_description"]
                .HeaderText = "Description";

            dgvTransactions.Columns["c_amount"]
                .HeaderText = "Amount";

            dgvTransactions.Columns["c_created_at"]
                .HeaderText = "Created At";

            dgvTransactions.Columns["c_user_id"]
                .Visible = false;

            dgvTransactions.Columns["c_category_id"]
                .Visible = false;
        }

        private bool ValidateFields()
        {
            if (cmbUser.SelectedValue == null)
            {
                MessageBox.Show(
                    "Please select a user.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            if (cmbCategory.SelectedValue == null)
            {
                MessageBox.Show(
                    "Please select a category.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show(
                    "Please enter a description.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAmount.Text))
            {
                MessageBox.Show(
                    "Please enter an amount.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            if (!decimal.TryParse(
                txtAmount.Text,
                out decimal amount))
            {
                MessageBox.Show(
                    "Please enter a valid amount.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            if (amount <= 0)
            {
                MessageBox.Show(
                    "Amount must be greater than zero.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            return true;
        }

        private void ClearFields()
        {
            txtTransactionId.Clear();

            if (cmbUser.Items.Count > 0)
            {
                cmbUser.SelectedIndex = 0;
            }

            if (cmbCategory.Items.Count > 0)
            {
                cmbCategory.SelectedIndex = 0;
            }

            dtpTransactionDate.Value =
                DateTime.Today;

            txtDescription.Clear();
            txtAmount.Clear();

            dgvTransactions.ClearSelection();
        }

        #endregion
    }
}