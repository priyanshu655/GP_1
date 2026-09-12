using System;
using System.Data;
using System.Windows.Forms;

using Npgsql;

namespace MoneyMap.AdminPanel.Categories
{
    public partial class CategoriesControl : UserControl
    {
        #region Constructor

        public CategoriesControl()
        {
            InitializeComponent();

            LoadTransactionTypes();
            LoadCategories();
        }

        #endregion

        #region Events

        private void DgvCategories_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row =
                dgvCategories.Rows[e.RowIndex];

            txtCategoryId.Text =
                row.Cells["c_category_id"].Value.ToString();

            cmbType.SelectedValue =
                row.Cells["c_type_id"].Value;

            txtCategoryName.Text =
                row.Cells["c_category_name"].Value.ToString();
        }

        private void TxtSearch_TextChanged(
            object sender,
            EventArgs e)
        {
            LoadCategories();
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
                "Are you sure you want to add this category?",
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
                    INSERT INTO t_category
                    (
                        c_type_id,
                        c_category_name
                    )
                    VALUES
                    (
                        @typeId,
                        @categoryName
                    )";

                using (NpgsqlCommand command =
                    new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue(
                        "@typeId",
                        Convert.ToInt32(cmbType.SelectedValue));

                    command.Parameters.AddWithValue(
                        "@categoryName",
                        txtCategoryName.Text.Trim());

                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show(
                "Category added successfully.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            LoadCategories();
            ClearFields();
        }

        private void BtnEdit_Click(
            object sender,
            EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoryId.Text))
            {
                MessageBox.Show(
                    "Please select a category first.",
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
                "Are you sure you want to update this category?",
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
                    UPDATE t_category
                    SET
                        c_type_id = @typeId,
                        c_category_name = @categoryName
                    WHERE c_category_id = @categoryId";

                using (NpgsqlCommand command =
                    new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue(
                        "@typeId",
                        Convert.ToInt32(cmbType.SelectedValue));

                    command.Parameters.AddWithValue(
                        "@categoryName",
                        txtCategoryName.Text.Trim());

                    command.Parameters.AddWithValue(
                        "@categoryId",
                        Convert.ToInt32(txtCategoryId.Text));

                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show(
                "Category updated successfully.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            LoadCategories();
            ClearFields();
        }

        private void BtnDelete_Click(
            object sender,
            EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoryId.Text))
            {
                MessageBox.Show(
                    "Please select a category first.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this category?",
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
                    DELETE FROM t_category
                    WHERE c_category_id = @categoryId";

                using (NpgsqlCommand command =
                    new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue(
                        "@categoryId",
                        Convert.ToInt32(txtCategoryId.Text));

                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show(
                "Category deleted successfully.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            LoadCategories();
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
                    FROM t_transaction_type
                    ORDER BY c_type_name";

                using (NpgsqlCommand command =
                    new NpgsqlCommand(query, connection))
                {
                    using (NpgsqlDataAdapter adapter =
                        new NpgsqlDataAdapter(command))
                    {
                        DataTable dataTable =
                            new DataTable();

                        adapter.Fill(dataTable);

                        cmbType.DataSource =
                            dataTable;

                        cmbType.DisplayMember =
                            "c_type_name";

                        cmbType.ValueMember =
                            "c_type_id";
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
                        c.c_category_id,
                        c.c_type_id,
                        t.c_type_name,
                        c.c_category_name,
                        c.c_created_at
                    FROM t_category c
                    INNER JOIN t_transaction_type t
                        ON c.c_type_id = t.c_type_id";

                string searchText =
                    txtSearch.Text.Trim();

                if (!string.IsNullOrWhiteSpace(searchText))
                {
                    query += @"
                        WHERE
                        (
                            CAST(c.c_category_id AS TEXT) ILIKE @search
                            OR t.c_type_name ILIKE @search
                            OR c.c_category_name ILIKE @search
                            OR CAST(c.c_created_at AS TEXT) ILIKE @search
                        )";
                }

                query += @"
                    ORDER BY
                        c.c_category_id";

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

                        dgvCategories.DataSource =
                            dataTable;
                    }
                }
            }

            SetColumnHeaders();
        }

        private void SetColumnHeaders()
        {
            if (dgvCategories.Columns.Count == 0)
            {
                return;
            }

            dgvCategories.Columns["c_category_id"]
                .HeaderText = "Category ID";

            dgvCategories.Columns["c_type_name"]
                .HeaderText = "Type Name";

            dgvCategories.Columns["c_category_name"]
                .HeaderText = "Category Name";

            dgvCategories.Columns["c_created_at"]
                .HeaderText = "Created At";

            dgvCategories.Columns["c_type_id"]
                .Visible = false;
        }

        private bool ValidateFields()
        {
            if (cmbType.SelectedValue == null)
            {
                MessageBox.Show(
                    "Please select a transaction type.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show(
                    "Please enter a category name.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            return true;
        }

        private void ClearFields()
        {
            txtCategoryId.Clear();

            if (cmbType.Items.Count > 0)
            {
                cmbType.SelectedIndex = 0;
            }

            txtCategoryName.Clear();

            dgvCategories.ClearSelection();
        }

        #endregion
    }
}