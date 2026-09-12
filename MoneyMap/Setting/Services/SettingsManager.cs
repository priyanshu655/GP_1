using System;
using System.Drawing;
using System.Windows.Forms;
using GP_1;
using Npgsql;

namespace MoneyMap.Setting.Services
{
    public class UserSettings
    {
        public string FontName { get; set; } = "Segoe UI";
        public float FontSize { get; set; } = 9.5f;
        public Color TextColor { get; set; } = ColorTranslator.FromHtml("#181F2A");
        public Color BackgroundColor { get; set; } = ColorTranslator.FromHtml("#F8F9FB");

        public Font CreateFont()
        {
            try
            {
                return new Font(FontName, FontSize, FontStyle.Regular);
            }
            catch
            {
                return new Font("Segoe UI", FontSize > 0 ? FontSize : 9.5f, FontStyle.Regular);
            }
        }
    }

    public static class SettingsManager
    {
        public static event Action<int>? SettingsChanged;

        private static bool tableChecked = false;

        public static void EnsureTableExists()
        {
            if (tableChecked) return;
            try
            {
                using var conn = Database.CreateConnection();
                conn.Open();
                string sql = @"
                    CREATE TABLE IF NOT EXISTS t_setting (
                        c_setting_id SERIAL PRIMARY KEY,
                        c_user_id INT NOT NULL REFERENCES t_user(c_user_id) ON DELETE CASCADE,
                        c_font_name VARCHAR(100) DEFAULT 'Segoe UI',
                        c_font_size REAL DEFAULT 9.5,
                        c_text_color VARCHAR(30) DEFAULT '#181F2A',
                        c_background_color VARCHAR(30) DEFAULT '#F8F9FB',
                        CONSTRAINT uq_setting_user UNIQUE (c_user_id)
                    );";
                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                tableChecked = true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("EnsureTableExists error: " + ex.Message);
            }
        }

        public static UserSettings LoadSettings(int userId)
        {
            EnsureTableExists();
            var settings = new UserSettings();

            try
            {
                using var conn = Database.CreateConnection();
                conn.Open();
                string sql = "SELECT c_font_name, c_font_size, c_text_color, c_background_color FROM t_setting WHERE c_user_id = @userId LIMIT 1;";
                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@userId", userId);

                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    settings.FontName = reader.IsDBNull(0) ? "Segoe UI" : reader.GetString(0);
                    settings.FontSize = reader.IsDBNull(1) ? 9.5f : Convert.ToSingle(reader.GetValue(1));
                    string textHex = reader.IsDBNull(2) ? "#181F2A" : reader.GetString(2);
                    string bgHex = reader.IsDBNull(3) ? "#F8F9FB" : reader.GetString(3);

                    try { settings.TextColor = ColorTranslator.FromHtml(textHex); } catch { }
                    try { settings.BackgroundColor = ColorTranslator.FromHtml(bgHex); } catch { }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("LoadSettings error: " + ex.Message);
            }

            return settings;
        }

        public static bool SaveSettings(int userId, string fontName, float fontSize, Color textColor, Color bgColor)
        {
            EnsureTableExists();
            try
            {
                using var conn = Database.CreateConnection();
                conn.Open();
                string sql = @"
                    INSERT INTO t_setting (c_user_id, c_font_name, c_font_size, c_text_color, c_background_color)
                    VALUES (@userId, @fontName, @fontSize, @textColor, @bgColor)
                    ON CONFLICT (c_user_id) DO UPDATE SET
                        c_font_name = EXCLUDED.c_font_name,
                        c_font_size = EXCLUDED.c_font_size,
                        c_text_color = EXCLUDED.c_text_color,
                        c_background_color = EXCLUDED.c_background_color;";

                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@fontName", fontName ?? "Segoe UI");
                cmd.Parameters.AddWithValue("@fontSize", fontSize);
                cmd.Parameters.AddWithValue("@textColor", ColorTranslator.ToHtml(textColor));
                cmd.Parameters.AddWithValue("@bgColor", ColorTranslator.ToHtml(bgColor));

                cmd.ExecuteNonQuery();

                SettingsChanged?.Invoke(userId);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save settings: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static bool ResetSettings(int userId)
        {
            EnsureTableExists();
            try
            {
                using var conn = Database.CreateConnection();
                conn.Open();
                string sql = "DELETE FROM t_setting WHERE c_user_id = @userId;";
                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.ExecuteNonQuery();

                SettingsChanged?.Invoke(userId);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to reset settings: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static void ApplySettings(Form form, int userId)
        {
            var settings = LoadSettings(userId);
            ApplySettings(form, settings);
        }

        public static void ApplySettings(Control root, UserSettings settings)
        {
            if (root == null || settings == null) return;

            Font customFont = settings.CreateFont();

            // Set root background if Form
            if (root is Form frm)
            {
                frm.BackColor = settings.BackgroundColor;
            }

            ApplyToControlHierarchy(root, customFont, settings.TextColor, settings.BackgroundColor);
        }

        private static void ApplyToControlHierarchy(Control control, Font font, Color textColor, Color bgColor)
        {
            if (control == null) return;

            // Do not alter menu bars or status strips as they have distinct UI theme navigation rules
            if (control is MenuStrip || control is ToolStrip || control is StatusStrip)
            {
                return;
            }

            // Apply font if control isn't a specialized icon/close button with fixed symbols
            if (control.Name != "btnClose" && control.Name != "lblIcon")
            {
                control.Font = new Font(font.FontFamily, Math.Max(7f, font.Size), control.Font?.Style ?? FontStyle.Regular);
            }

            // Apply text color to appropriate content controls
            if (control is Label || control is GroupBox || control is CheckBox || control is RadioButton)
            {
                // If it's a card/banner title or dark card subtitle, don't overwrite white text
                if (control.ForeColor != Color.White && control.ForeColor != Color.FromArgb(255, 255, 255))
                {
                    control.ForeColor = textColor;
                }
            }
            else if (control is TextBox || control is ComboBox || control is DateTimePicker || control is NumericUpDown)
            {
                control.ForeColor = textColor;
            }
            else if (control is ListView lv)
            {
                lv.ForeColor = textColor;
                lv.Font = font;
            }
            else if (control is DataGridView dgv)
            {
                dgv.ForeColor = textColor;
                dgv.DefaultCellStyle.Font = font;
                dgv.DefaultCellStyle.ForeColor = textColor;
            }

            // Recursively apply to child controls
            foreach (Control child in control.Controls)
            {
                ApplyToControlHierarchy(child, font, textColor, bgColor);
            }
        }
    }
}
