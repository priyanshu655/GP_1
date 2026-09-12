using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using LoginPage;
using Npgsql;

namespace SignupPage
{
    public partial class Form1 : Form
    {
        private readonly string connectionString =
            "Server=localhost;Port=5432;Database=MoneyMap;Username=postgres;Password=password";

        private readonly string passwordPattern =
            @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";

        public Form1()
        {
            InitializeComponent();
            SetupCardStyling();
        }

        private void SetupCardStyling()
        {
            cardPanel.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using var borderPen = new Pen(Color.FromArgb(226, 232, 240), 1.5f);
                Rectangle rect = cardPanel.ClientRectangle;
                rect.Width -= 1;
                rect.Height -= 1;
                e.Graphics.DrawRectangle(borderPen, rect);
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CenterCard();
            textBox1.Focus();
        }

        private void RightPanel_Resize(object sender, EventArgs e)
        {
            CenterCard();
        }

        private void CenterCard()
        {
            if (rightPanel == null || cardPanel == null) return;

            int targetX = Math.Max(20, (rightPanel.ClientSize.Width - cardPanel.Width) / 2);
            int targetY = Math.Max(20, (rightPanel.ClientSize.Height - cardPanel.Height) / 2);

            cardPanel.Location = new Point(targetX, targetY);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text;
            string confirmPassword = textBox3.Text;

            if (string.IsNullOrWhiteSpace(username))
            {
                ShowWarning("Please enter a username.", "Validation Error");
                textBox1.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                ShowWarning("Please enter a password.", "Validation Error");
                textBox2.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(confirmPassword))
            {
                ShowWarning("Please confirm your password.", "Validation Error");
                textBox3.Focus();
                return;
            }

            if (username.Length < 3)
            {
                ShowWarning(
                    "Username must be at least 3 characters.",
                    "Validation Error");

                textBox1.Focus();
                return;
            }

            if (!Regex.IsMatch(password, passwordPattern))
            {
                ShowWarning(
                    "Password must contain:\n\n" +
                    "• At least 8 characters\n" +
                    "• At least 1 uppercase letter\n" +
                    "• At least 1 lowercase letter\n" +
                    "• At least 1 number (0–9)\n" +
                    "• At least 1 special character (@$!%*?&)",
                    "Invalid Password");

                textBox2.Focus();
                return;
            }

            if (password != confirmPassword)
            {
                ShowWarning(
                    "Passwords do not match.",
                    "Validation Error");

                textBox3.Clear();
                textBox3.Focus();
                return;
            }

            try
            {
                using (NpgsqlConnection cn =
                       new NpgsqlConnection(connectionString))
                {
                    cn.Open();

                    if (UsernameExists(cn, username))
                    {
                        ShowWarning(
                            "Username already exists. Please choose another.",
                            "Signup Failed");

                        textBox1.Focus();
                        return;
                    }

                    InsertUser(cn, username, password);
                }

                MessageBox.Show(
                    "Account created successfully!\nPlease login to continue.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                Login loginForm = new Login();
                loginForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "A database error occurred:\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private bool UsernameExists(
            NpgsqlConnection cn,
            string username)
        {
            const string sql = @"
                SELECT COUNT(*)
                FROM t_user
                WHERE c_username = @username";

            using (NpgsqlCommand cmd =
                   new NpgsqlCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue(
                    "@username",
                    username);

                long count =
                    Convert.ToInt64(cmd.ExecuteScalar());

                return count > 0;
            }
        }

        private void InsertUser(
            NpgsqlConnection cn,
            string username,
            string password)
        {
            const string sql = @"
                INSERT INTO t_user
                (
                    c_username,
                    c_password_hash,
                    c_is_active
                )
                VALUES
                (
                    @username,
                    @password,
                    TRUE
                )";

            using (NpgsqlCommand cmd =
                   new NpgsqlCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue(
                    "@username",
                    username);

                cmd.Parameters.AddWithValue(
                    "@password",
                    password);

                cmd.ExecuteNonQuery();
            }
        }

        private static void ShowWarning(
            string message,
            string title)
        {
            MessageBox.Show(
                message,
                title,
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
    }
}
