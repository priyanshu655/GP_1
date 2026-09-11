
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using LoginPage;
using Npgsql;

namespace SignupPage
{
    public partial class Form1 : Form
    {
        private readonly string connectionString =
            "Server=localhost;Port=5432;Database=income_expense_db;User Id=postgres;Password=Deep@1710;";

        private readonly string passwordPattern =
            @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";

        public Form1()
        {
            InitializeComponent();
        }

        private void showPasswordButton_Click(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = !textBox2.UseSystemPasswordChar;
            showPasswordButton.Text = textBox2.UseSystemPasswordChar ? "Show" : "Hide";
        }

        private void showConfirmPasswordButton_Click(object sender, EventArgs e)
        {
            textBox3.UseSystemPasswordChar = !textBox3.UseSystemPasswordChar;
            showConfirmPasswordButton.Text = textBox3.UseSystemPasswordChar ? "Show" : "Hide";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
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

                    InsertUser(cn, username, BCrypt.Net.BCrypt.HashPassword(password));
                }

                MessageBox.Show(
                    "Account created successfully!\nPlease login to continue.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                Close();
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
            string passwordHash)
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
                    @passwordHash,
                    TRUE
                )";

            using (NpgsqlCommand cmd =
                   new NpgsqlCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue(
                    "@username",
                    username);

                cmd.Parameters.AddWithValue(
                    "@passwordHash",
                    passwordHash);

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

