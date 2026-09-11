using System;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;

namespace GP_1
{
    public static class SettingsManager
    {
        private static string connectionString =
            "Host=localhost;Port=5432;Database=MoneyTracker;Username=postgres;Password=root;Include Error Detail=true";

        public static int ResolveValidUserId(int preferredUserId = 1)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    // Find which parent table and column the foreign key 'fk_setting_user' references
                    string fkQuery = @"
                        SELECT
                            c.confrelid::regclass::text AS parent_table,
                            af.attname AS parent_column
                        FROM pg_constraint c
                        JOIN pg_attribute af ON af.attnum = ANY(c.confkey) AND af.attrelid = c.confrelid
                        WHERE c.conname = 'fk_setting_user'
                        LIMIT 1;
                    ";

                    string parentTable = "t_user";
                    string parentColumn = "c_user_id";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(fkQuery, connection))
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            parentTable = reader["parent_table"]?.ToString() ?? "t_user";
                            parentColumn = reader["parent_column"]?.ToString() ?? "c_user_id";
                        }
                    }

                    // Check if preferredUserId exists
                    string checkQuery = $"SELECT {parentColumn} FROM {parentTable} WHERE {parentColumn} = @id LIMIT 1;";
                    using (NpgsqlCommand checkCmd = new NpgsqlCommand(checkQuery, connection))
                    {
                        checkCmd.Parameters.AddWithValue("@id", preferredUserId);
                        object? exists = checkCmd.ExecuteScalar();
                        if (exists != null && exists != DBNull.Value)
                        {
                            return Convert.ToInt32(exists);
                        }
                    }

                    // If preferredId is not present, find the first available user ID
                    string anyUserQuery = $"SELECT {parentColumn} FROM {parentTable} ORDER BY {parentColumn} ASC LIMIT 1;";
                    using (NpgsqlCommand anyCmd = new NpgsqlCommand(anyUserQuery, connection))
                    {
                        object? firstUser = anyCmd.ExecuteScalar();
                        if (firstUser != null && firstUser != DBNull.Value)
                        {
                            return Convert.ToInt32(firstUser);
                        }
                    }
                }
            }
            catch
            {
                // Fall back to preferredUserId if resolution fails
            }

            return preferredUserId;
        }

        public static void SaveSettings(
            int userId,
            Font font,
            Color textColor,
            Color backgroundColor)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    // Parameterized PostgreSQL UPSERT query
                    string query = @"
                        INSERT INTO t_setting
                        (
                            c_user_id,
                            c_font_name,
                            c_font_size,
                            c_text_color,
                            c_background_color,
                            c_updated_at
                        )
                        VALUES
                        (
                            @userId,
                            @fontName,
                            @fontSize,
                            @textColor,
                            @backgroundColor,
                            CURRENT_TIMESTAMP
                        )
                        ON CONFLICT (c_user_id)
                        DO UPDATE SET
                            c_font_name = EXCLUDED.c_font_name,
                            c_font_size = EXCLUDED.c_font_size,
                            c_text_color = EXCLUDED.c_text_color,
                            c_background_color = EXCLUDED.c_background_color,
                            c_updated_at = CURRENT_TIMESTAMP;
                    ";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        // Use parameterized values to prevent SQL injection
                        command.Parameters.AddWithValue("@userId", userId);
                        command.Parameters.AddWithValue("@fontName", font.Name);
                        command.Parameters.AddWithValue("@fontSize", font.Size);
                        command.Parameters.AddWithValue("@textColor", ColorTranslator.ToHtml(textColor));
                        command.Parameters.AddWithValue("@backgroundColor", ColorTranslator.ToHtml(backgroundColor));

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                if (ex.SqlState == "23503")
                {
                    MessageBox.Show(
                        $"Foreign key violation on 't_setting' (fk_setting_user):\n" +
                        $"The user ID '{userId}' does not exist in the database user table.\n\n" +
                        "Please ensure a user exists in your database table, or pass a valid user ID to SettingForm(userId).\n\n" +
                        "Details: " + ex.Message,
                        "Database Error - Missing User",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(
                        "Database error while saving settings:\n" + ex.Message,
                        "Database Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                throw; // Rethrow to allow caller to know save was unsuccessful
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An unexpected error occurred while saving settings:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                throw;
            }
        }

        public static bool LoadSettings(
            int userId,
            out Font font,
            out Color textColor,
            out Color backgroundColor)
        {
            // Set sensible default values first
            font = SystemFonts.DefaultFont;
            textColor = Color.Black;
            backgroundColor = SystemColors.Control;

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                        SELECT
                            c_font_name,
                            c_font_size,
                            c_text_color,
                            c_background_color
                        FROM t_setting
                        WHERE c_user_id = @userId;
                    ";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@userId", userId);

                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string fontName = reader["c_font_name"] != DBNull.Value
                                    ? reader["c_font_name"].ToString() ?? SystemFonts.DefaultFont.Name
                                    : SystemFonts.DefaultFont.Name;

                                float fontSize = reader["c_font_size"] != DBNull.Value
                                    ? Convert.ToSingle(reader["c_font_size"])
                                    : SystemFonts.DefaultFont.Size;

                                string textColorString = reader["c_text_color"] != DBNull.Value
                                    ? reader["c_text_color"].ToString() ?? "#000000"
                                    : "#000000";

                                string backgroundColorString = reader["c_background_color"] != DBNull.Value
                                    ? reader["c_background_color"].ToString() ?? "#FFFFFF"
                                    : "#FFFFFF";

                                // Safe Font reconstruction with fallback
                                try
                                {
                                    font = new Font(fontName, fontSize);
                                }
                                catch
                                {
                                    font = SystemFonts.DefaultFont;
                                }

                                // Safe Color reconstruction with fallback
                                try
                                {
                                    textColor = ColorTranslator.FromHtml(textColorString);
                                }
                                catch
                                {
                                    textColor = Color.Black;
                                }

                                try
                                {
                                    backgroundColor = ColorTranslator.FromHtml(backgroundColorString);
                                }
                                catch
                                {
                                    backgroundColor = SystemColors.Control;
                                }

                                return true;
                            }
                        }
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(
                    "Could not load settings from PostgreSQL database.\nUsing default appearance.\n\nDetails: " + ex.Message,
                    "Database Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading settings.\nUsing default appearance.\n\nDetails: " + ex.Message,
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

            return false;
        }
        public static void ApplySettings(Form form, int userId)
        {
            if (form == null || form.IsDisposed)
            {
                return;
            }

            Font font;
            Color textColor;
            Color backgroundColor;

            LoadSettings(userId, out font, out textColor, out backgroundColor);

            ApplyToControls(form, font, textColor, backgroundColor);
        }

        private static void ApplyToControls(
            Control control,
            Font font,
            Color textColor,
            Color backgroundColor)
        {
            if (control == null)
            {
                return;
            }

            // Apply font to form and child controls (except MenuStrip to keep clean menu styling)
            if (!(control is MenuStrip))
            {
                control.Font = font;
            }

            // Apply background color to Form, Panels, and GroupBoxes
            // We intentionally do NOT overwrite Button, TextBox, DataGridView, or MenuStrip backcolors
            // to keep the existing UI readable and usable.
            if (control is Form || control is Panel || control is GroupBox)
            {
                control.BackColor = backgroundColor;
            }

            // Apply text color to Labels and GroupBoxes
            if (control is Label || control is GroupBox)
            {
                control.ForeColor = textColor;
            }

            // Recursively process child controls
            foreach (Control child in control.Controls)
            {
                ApplyToControls(child, font, textColor, backgroundColor);
            }
        }
    }
}