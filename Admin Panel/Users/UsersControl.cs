using System;
using System.Data;
using System.Windows.Forms;

using Npgsql;

namespace MoneyMap.AdminPanel.Users
{
    public partial class UsersControl : UserControl
    {
        #region Constructor

        public UsersControl()
        {
            InitializeComponent();
            LoadUsers();
        }

        #endregion

        #region Events

        private void DgvUsers_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row =
                dgvUsers.Rows[e.RowIndex];

            txtUserId.Text =
                row.Cells["c_user_id"].Value.ToString();

            txtUsername.Text =
                row.Cells["c_username"].Value.ToString();

            txtPassword.Text =
                row.Cells["c_password_hash"].Value.ToString();

            chkIsActive.Checked =
                Convert.ToBoolean(
                    row.Cells["c_is_active"].Value);
        }

        private void TxtSearch_TextChanged(
            object sender,
            EventArgs e)
        {
            LoadUsers();
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
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show(
                    "Please enter a username.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show(
                    "Please enter a password hash.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to add this user?",
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
                    INSERT INTO t_user
                    (
                        c_username,
                        c_password_hash,
                        c_is_active
                    )
                    VALUES
                    (
                        @username,
                        @passwordHash,
                        @isActive
                    )";

                using (NpgsqlCommand command =
                    new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue(
                        "@username",
                        txtUsername.Text.Trim());

                    command.Parameters.AddWithValue(
                        "@passwordHash",
                        txtPassword.Text.Trim());

                    command.Parameters.AddWithValue(
                        "@isActive",
                        chkIsActive.Checked);

                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show(
                "User added successfully.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            LoadUsers();
            ClearFields();
        }

        private void BtnEdit_Click(
            object sender,
            EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserId.Text))
            {
                MessageBox.Show(
                    "Please select a user first.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show(
                    "Please enter a username.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show(
                    "Please enter a password hash.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to update this user?",
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
                    UPDATE t_user
                    SET
                        c_username = @username,
                        c_password_hash = @passwordHash,
                        c_is_active = @isActive
                    WHERE c_user_id = @userId";

                using (NpgsqlCommand command =
                    new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue(
                        "@username",
                        txtUsername.Text.Trim());

                    command.Parameters.AddWithValue(
                        "@passwordHash",
                        txtPassword.Text.Trim());

                    command.Parameters.AddWithValue(
                        "@isActive",
                        chkIsActive.Checked);

                    command.Parameters.AddWithValue(
                        "@userId",
                        Convert.ToInt32(txtUserId.Text));

                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show(
                "User updated successfully.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            LoadUsers();
            ClearFields();
        }

        private void BtnDelete_Click(
            object sender,
            EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserId.Text))
            {
                MessageBox.Show(
                    "Please select a user first.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this user?",
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
                    DELETE FROM t_user
                    WHERE c_user_id = @userId";

                using (NpgsqlCommand command =
                    new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue(
                        "@userId",
                        Convert.ToInt32(txtUserId.Text));

                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show(
                "User deleted successfully.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            LoadUsers();
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
                        c_username,
                        c_password_hash,
                        c_is_active,
                        c_created_at
                    FROM t_user";

                string searchText =
                    txtSearch.Text.Trim();

                if (!string.IsNullOrWhiteSpace(searchText))
                {
                    query += @"
                        WHERE
                        (
                            CAST(c_user_id AS TEXT) ILIKE @search
                            OR c_username ILIKE @search
                            OR c_password_hash ILIKE @search
                            OR CAST(c_is_active AS TEXT) ILIKE @search
                            OR CAST(c_created_at AS TEXT) ILIKE @search
                        )";
                }

                query += @"
                    ORDER BY
                        c_user_id";

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

                        dgvUsers.DataSource =
                            dataTable;
                    }
                }
            }

            SetColumnHeaders();
        }

        private void SetColumnHeaders()
        {
            if (dgvUsers.Columns.Count == 0)
            {
                return;
            }

            dgvUsers.Columns["c_user_id"]
                .HeaderText = "User ID";

            dgvUsers.Columns["c_username"]
                .HeaderText = "Username";

            dgvUsers.Columns["c_password_hash"]
                .HeaderText = "Password Hash";

            dgvUsers.Columns["c_is_active"]
                .HeaderText = "Active";

            dgvUsers.Columns["c_created_at"]
                .HeaderText = "Created At";
        }

        private void ClearFields()
        {
            txtUserId.Clear();
            txtUsername.Clear();
            txtPassword.Clear();

            chkIsActive.Checked = true;

            dgvUsers.ClearSelection();
        }

        #endregion
    }
}