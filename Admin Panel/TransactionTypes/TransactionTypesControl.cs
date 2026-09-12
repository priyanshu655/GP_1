using System;
using System.Data;
using System.Windows.Forms;

using Npgsql;

namespace MoneyMap.AdminPanel.TransactionTypes
{
    public partial class TransactionTypesControl : UserControl
    {
        #region Constructor

        public TransactionTypesControl()
        {
            InitializeComponent();
            LoadTransactionTypes();
        }

        #endregion

        #region Events

        private void DgvTransactionTypes_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row =
                dgvTransactionTypes.Rows[e.RowIndex];

            txtTypeId.Text =
                row.Cells["c_type_id"].Value.ToString();

            txtTypeName.Text =
                row.Cells["c_type_name"].Value.ToString();
        }

        private void TxtSearch_TextChanged(
            object sender,
            EventArgs e)
        {
            LoadTransactionTypes();
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
            if (string.IsNullOrWhiteSpace(txtTypeName.Text))
            {
                MessageBox.Show(
                    "Please enter a transaction type name.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to add this transaction type?",
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
                    INSERT INTO t_transaction_type
                    (
                        c_type_name
                    )
                    VALUES
                    (
                        @typeName
                    )";

                using (NpgsqlCommand command =
                    new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue(
                        "@typeName",
                        txtTypeName.Text.Trim());

                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show(
                "Transaction type added successfully.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            LoadTransactionTypes();
            ClearFields();
        }

        private void BtnEdit_Click(
            object sender,
            EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTypeId.Text))
            {
                MessageBox.Show(
                    "Please select a transaction type first.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (string.IsNullOrWhiteSpace(txtTypeName.Text))
            {
                MessageBox.Show(
                    "Please enter a transaction type name.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to update this transaction type?",
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
                    UPDATE t_transaction_type
                    SET
                        c_type_name = @typeName
                    WHERE c_type_id = @typeId";

                using (NpgsqlCommand command =
                    new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue(
                        "@typeName",
                        txtTypeName.Text.Trim());

                    command.Parameters.AddWithValue(
                        "@typeId",
                        Convert.ToInt32(txtTypeId.Text));

                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show(
                "Transaction type updated successfully.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            LoadTransactionTypes();
            ClearFields();
        }

        private void BtnDelete_Click(
            object sender,
            EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTypeId.Text))
            {
                MessageBox.Show(
                    "Please select a transaction type first.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this transaction type?",
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
                    DELETE FROM t_transaction_type
                    WHERE c_type_id = @typeId";

                using (NpgsqlCommand command =
                    new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue(
                        "@typeId",
                        Convert.ToInt32(txtTypeId.Text));

                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show(
                "Transaction type deleted successfully.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            LoadTransactionTypes();
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

        private void LoadTransactionTypes()
        {
            using (NpgsqlConnection connection =
                GP_1.Database.CreateConnection())
            {
                connection.Open();

                string query = @"
                    SELECT
                        c_type_id,
                        c_type_name
                    FROM t_transaction_type";

                string searchText =
                    txtSearch.Text.Trim();

                if (!string.IsNullOrWhiteSpace(searchText))
                {
                    query += @"
                        WHERE
                        (
                            CAST(c_type_id AS TEXT) ILIKE @search
                            OR c_type_name ILIKE @search
                        )";
                }

                query += @"
                    ORDER BY
                        c_type_id";

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

                        dgvTransactionTypes.DataSource =
                            dataTable;
                    }
                }
            }

            SetColumnHeaders();
        }

        private void SetColumnHeaders()
        {
            if (dgvTransactionTypes.Columns.Count == 0)
            {
                return;
            }

            dgvTransactionTypes.Columns["c_type_id"]
                .HeaderText = "Type ID";

            dgvTransactionTypes.Columns["c_type_name"]
                .HeaderText = "Transaction Type";
        }

        private void ClearFields()
        {
            txtTypeId.Clear();
            txtTypeName.Clear();

            dgvTransactionTypes.ClearSelection();
        }

        #endregion
    }
}