using System;
using System.Data;
using System.Windows.Forms;

using Npgsql;

namespace MoneyMap.AdminPanel.Budgets
{
    public partial class BudgetsControl : UserControl
    {
        #region Constructor

        public BudgetsControl()
        {
            InitializeComponent();

            LoadUsers();
            LoadBudgets();
        }

        #endregion

        #region Events

        private void DgvBudgets_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row =
                dgvBudgets.Rows[e.RowIndex];

            txtBudgetId.Text =
                row.Cells["c_budget_id"].Value.ToString();

            cmbUser.SelectedValue =
                row.Cells["c_user_id"].Value;

            txtBudgetPercentage.Text =
                row.Cells["c_budget_percentage"].Value.ToString();

            DateOnly budgetMonth =
                (DateOnly)row.Cells["c_budget_month"].Value;

            dtpBudgetMonth.Value =
                budgetMonth.ToDateTime(TimeOnly.MinValue);
        }

        private void TxtSearch_TextChanged(
            object sender,
            EventArgs e)
        {
            LoadBudgets();
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
                "Are you sure you want to add this budget?",
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
                    INSERT INTO t_budget
                    (
                        c_user_id,
                        c_budget_percentage,
                        c_budget_month
                    )
                    VALUES
                    (
                        @userId,
                        @budgetPercentage,
                        @budgetMonth
                    )";

                using (NpgsqlCommand command =
                    new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue(
                        "@userId",
                        Convert.ToInt32(cmbUser.SelectedValue));

                    command.Parameters.AddWithValue(
                        "@budgetPercentage",
                        Convert.ToDecimal(
                            txtBudgetPercentage.Text));

                    command.Parameters.AddWithValue(
                        "@budgetMonth",
                        dtpBudgetMonth.Value.Date);

                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show(
                "Budget added successfully.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            LoadBudgets();
            ClearFields();
        }

        private void BtnEdit_Click(
            object sender,
            EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBudgetId.Text))
            {
                MessageBox.Show(
                    "Please select a budget first.",
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
                "Are you sure you want to update this budget?",
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
                    UPDATE t_budget
                    SET
                        c_user_id = @userId,
                        c_budget_percentage = @budgetPercentage,
                        c_budget_month = @budgetMonth,
                        c_updated_at = CURRENT_TIMESTAMP
                    WHERE c_budget_id = @budgetId";

                using (NpgsqlCommand command =
                    new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue(
                        "@userId",
                        Convert.ToInt32(cmbUser.SelectedValue));

                    command.Parameters.AddWithValue(
                        "@budgetPercentage",
                        Convert.ToDecimal(
                            txtBudgetPercentage.Text));

                    command.Parameters.AddWithValue(
                        "@budgetMonth",
                        dtpBudgetMonth.Value.Date);

                    command.Parameters.AddWithValue(
                        "@budgetId",
                        Convert.ToInt64(txtBudgetId.Text));

                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show(
                "Budget updated successfully.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            LoadBudgets();
            ClearFields();
        }

        private void BtnDelete_Click(
            object sender,
            EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBudgetId.Text))
            {
                MessageBox.Show(
                    "Please select a budget first.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this budget?",
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
                    DELETE FROM t_budget
                    WHERE c_budget_id = @budgetId";

                using (NpgsqlCommand command =
                    new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue(
                        "@budgetId",
                        Convert.ToInt64(txtBudgetId.Text));

                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show(
                "Budget deleted successfully.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            LoadBudgets();
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

        private void LoadBudgets()
        {
            using (NpgsqlConnection connection =
                GP_1.Database.CreateConnection())
            {
                connection.Open();

                string query = @"
                    SELECT
                        b.c_budget_id,
                        b.c_user_id,
                        u.c_username,
                        b.c_budget_percentage,
                        b.c_budget_month,
                        b.c_created_at,
                        b.c_updated_at
                    FROM t_budget b
                    INNER JOIN t_user u
                        ON b.c_user_id = u.c_user_id";

                string searchText =
                    txtSearch.Text.Trim();

                if (!string.IsNullOrWhiteSpace(searchText))
                {
                    query += @"
                        WHERE
                        (
                            CAST(b.c_budget_id AS TEXT) ILIKE @search
                            OR u.c_username ILIKE @search
                            OR CAST(b.c_budget_percentage AS TEXT)
                                ILIKE @search
                            OR CAST(b.c_budget_month AS TEXT)
                                ILIKE @search
                            OR CAST(b.c_created_at AS TEXT)
                                ILIKE @search
                            OR CAST(b.c_updated_at AS TEXT)
                                ILIKE @search
                        )";
                }

                query += @"
                    ORDER BY
                        b.c_budget_id";

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

                        dgvBudgets.DataSource =
                            dataTable;
                    }
                }
            }

            SetColumnHeaders();
        }

        private void SetColumnHeaders()
        {
            if (dgvBudgets.Columns.Count == 0)
            {
                return;
            }

            dgvBudgets.Columns["c_budget_id"]
                .HeaderText = "Budget ID";

            dgvBudgets.Columns["c_username"]
                .HeaderText = "User Name";

            dgvBudgets.Columns["c_budget_percentage"]
                .HeaderText = "Budget Percentage";

            dgvBudgets.Columns["c_budget_month"]
                .HeaderText = "Budget Month";

            dgvBudgets.Columns["c_created_at"]
                .HeaderText = "Created At";

            dgvBudgets.Columns["c_updated_at"]
                .HeaderText = "Updated At";

            dgvBudgets.Columns["c_user_id"]
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

            if (string.IsNullOrWhiteSpace(
                txtBudgetPercentage.Text))
            {
                MessageBox.Show(
                    "Please enter a budget percentage.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            if (!decimal.TryParse(
                txtBudgetPercentage.Text,
                out decimal budgetPercentage))
            {
                MessageBox.Show(
                    "Please enter a valid budget percentage.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            if (budgetPercentage <= 0 ||
                budgetPercentage > 100)
            {
                MessageBox.Show(
                    "Budget percentage must be between 0 and 100.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            return true;
        }

        private void ClearFields()
        {
            txtBudgetId.Clear();

            if (cmbUser.Items.Count > 0)
            {
                cmbUser.SelectedIndex = 0;
            }

            txtBudgetPercentage.Clear();

            dtpBudgetMonth.Value =
                DateTime.Today;

            dgvBudgets.ClearSelection();
        }

        #endregion
    }
}