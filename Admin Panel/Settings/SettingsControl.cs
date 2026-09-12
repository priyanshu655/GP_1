using System;
using System.Data;
using System.Windows.Forms;

using Npgsql;

namespace MoneyMap.AdminPanel.Settings
{
    public partial class SettingsControl : UserControl
    {
        #region Constructor

        public SettingsControl()
        {
            InitializeComponent();

            LoadUsers();
            LoadSettings();
        }

        #endregion

        #region Events

        private void DgvSettings_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row =
                dgvSettings.Rows[e.RowIndex];

            txtSettingId.Text =
                row.Cells["c_setting_id"].Value.ToString();

            cmbUser.SelectedValue =
                row.Cells["c_user_id"].Value;

            txtFontName.Text =
                row.Cells["c_font_name"].Value?.ToString();

            txtFontSize.Text =
                row.Cells["c_font_size"].Value?.ToString();

            txtTextColor.Text =
                row.Cells["c_text_color"].Value?.ToString();

            txtBackgroundColor.Text =
                row.Cells["c_background_color"].Value?.ToString();
        }

        private void TxtSearch_TextChanged(
            object sender,
            EventArgs e)
        {
            LoadSettings();
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
                "Are you sure you want to add this setting?",
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
                        @userId,
                        @fontName,
                        @fontSize,
                        @textColor,
                        @backgroundColor
                    )";

                using (NpgsqlCommand command =
                    new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue(
                        "@userId",
                        Convert.ToInt32(cmbUser.SelectedValue));

                    command.Parameters.AddWithValue(
                        "@fontName",
                        GetValue(txtFontName.Text));

                    command.Parameters.AddWithValue(
                        "@fontSize",
                        GetFontSize());

                    command.Parameters.AddWithValue(
                        "@textColor",
                        GetValue(txtTextColor.Text));

                    command.Parameters.AddWithValue(
                        "@backgroundColor",
                        GetValue(txtBackgroundColor.Text));

                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show(
                "Setting added successfully.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            LoadSettings();
            ClearFields();
        }

        private void BtnEdit_Click(
            object sender,
            EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSettingId.Text))
            {
                MessageBox.Show(
                    "Please select a setting first.",
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
                "Are you sure you want to update this setting?",
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
                    UPDATE t_setting
                    SET
                        c_user_id = @userId,
                        c_font_name = @fontName,
                        c_font_size = @fontSize,
                        c_text_color = @textColor,
                        c_background_color = @backgroundColor,
                        c_updated_at = CURRENT_TIMESTAMP
                    WHERE c_setting_id = @settingId";

                using (NpgsqlCommand command =
                    new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue(
                        "@userId",
                        Convert.ToInt32(cmbUser.SelectedValue));

                    command.Parameters.AddWithValue(
                        "@fontName",
                        GetValue(txtFontName.Text));

                    command.Parameters.AddWithValue(
                        "@fontSize",
                        GetFontSize());

                    command.Parameters.AddWithValue(
                        "@textColor",
                        GetValue(txtTextColor.Text));

                    command.Parameters.AddWithValue(
                        "@backgroundColor",
                        GetValue(txtBackgroundColor.Text));

                    command.Parameters.AddWithValue(
                        "@settingId",
                        Convert.ToInt32(txtSettingId.Text));

                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show(
                "Setting updated successfully.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            LoadSettings();
            ClearFields();
        }

        private void BtnDelete_Click(
            object sender,
            EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSettingId.Text))
            {
                MessageBox.Show(
                    "Please select a setting first.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this setting?",
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
                    DELETE FROM t_setting
                    WHERE c_setting_id = @settingId";

                using (NpgsqlCommand command =
                    new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue(
                        "@settingId",
                        Convert.ToInt32(txtSettingId.Text));

                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show(
                "Setting deleted successfully.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            LoadSettings();
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

        private void LoadSettings()
        {
            using (NpgsqlConnection connection =
                GP_1.Database.CreateConnection())
            {
                connection.Open();

                string query = @"
                    SELECT
                        s.c_setting_id,
                        s.c_user_id,
                        u.c_username,
                        s.c_font_name,
                        s.c_font_size,
                        s.c_text_color,
                        s.c_background_color,
                        s.c_updated_at
                    FROM t_setting s
                    INNER JOIN t_user u
                        ON s.c_user_id = u.c_user_id";

                string searchText =
                    txtSearch.Text.Trim();

                if (!string.IsNullOrWhiteSpace(searchText))
                {
                    query += @"
                        WHERE
                        (
                            CAST(s.c_setting_id AS TEXT)
                                ILIKE @search
                            OR u.c_username
                                ILIKE @search
                            OR s.c_font_name
                                ILIKE @search
                            OR CAST(s.c_font_size AS TEXT)
                                ILIKE @search
                            OR s.c_text_color
                                ILIKE @search
                            OR s.c_background_color
                                ILIKE @search
                            OR CAST(s.c_updated_at AS TEXT)
                                ILIKE @search
                        )";
                }

                query += @"
                    ORDER BY
                        s.c_setting_id";

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

                        dgvSettings.DataSource =
                            dataTable;
                    }
                }
            }

            SetColumnHeaders();
        }

        private void SetColumnHeaders()
        {
            if (dgvSettings.Columns.Count == 0)
            {
                return;
            }

            dgvSettings.Columns["c_setting_id"]
                .HeaderText = "Setting ID";

            dgvSettings.Columns["c_username"]
                .HeaderText = "User Name";

            dgvSettings.Columns["c_font_name"]
                .HeaderText = "Font Name";

            dgvSettings.Columns["c_font_size"]
                .HeaderText = "Font Size";

            dgvSettings.Columns["c_text_color"]
                .HeaderText = "Text Color";

            dgvSettings.Columns["c_background_color"]
                .HeaderText = "Background Color";

            dgvSettings.Columns["c_updated_at"]
                .HeaderText = "Updated At";

            dgvSettings.Columns["c_user_id"]
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

            if (!string.IsNullOrWhiteSpace(txtFontSize.Text))
            {
                if (!decimal.TryParse(
                    txtFontSize.Text,
                    out decimal fontSize))
                {
                    MessageBox.Show(
                        "Please enter a valid font size.",
                        "Validation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return false;
                }

                if (fontSize <= 0)
                {
                    MessageBox.Show(
                        "Font size must be greater than zero.",
                        "Validation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return false;
                }
            }

            return true;
        }

        private object GetValue(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return DBNull.Value;
            }

            return value.Trim();
        }

        private object GetFontSize()
        {
            if (string.IsNullOrWhiteSpace(txtFontSize.Text))
            {
                return DBNull.Value;
            }

            return Convert.ToDecimal(txtFontSize.Text);
        }

        private void ClearFields()
        {
            txtSettingId.Clear();

            if (cmbUser.Items.Count > 0)
            {
                cmbUser.SelectedIndex = 0;
            }

            txtFontName.Clear();
            txtFontSize.Clear();
            txtTextColor.Clear();
            txtBackgroundColor.Clear();

            dgvSettings.ClearSelection();
        }

        #endregion
    }
}