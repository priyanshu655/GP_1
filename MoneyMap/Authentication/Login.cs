using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Npgsql;
using SignupPage;   // Needed to open your Signup Form1
using MoneyMap.Main;

namespace LoginPage
{
    public partial class Login : Form
    {
        // Same connection you use in Signup
        private readonly string connectionString = "Server=localhost;Port=5432;Database=income_expense_db;User Id=postgres;Password=Deep@1710;";

        // Holds the ID of the logged-in user (use this when opening a dashboard)
        public int LoggedInUserId { get; private set; } = -1;

        public Login()
        {
            InitializeComponent();
        }

        private void showPasswordButton_Click(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = !textBox2.UseSystemPasswordChar;
            showPasswordButton.Text = textBox2.UseSystemPasswordChar ? "Show" : "Hide";
        }

        // ── Login button (button1) ─────────────────────────────────────────
        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text;

            // 1. Empty checks
            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Please enter username.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter password.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return;
            }

            // 2. Database check
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
                {
                    con.Open();

                    const string sql = @"
                        SELECT c_user_id, c_password_hash
                        FROM t_user 
                        WHERE c_username      = @username
                          AND c_is_active     = TRUE;";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        using NpgsqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            int userId = reader.GetInt32(0);
                            string storedPassword = reader.GetString(1);
                            bool isLegacyPassword = !storedPassword.StartsWith("$2", StringComparison.Ordinal);
                            bool isValidPassword = isLegacyPassword
                                ? PasswordsMatch(password, storedPassword)
                                : BCrypt.Net.BCrypt.Verify(password, storedPassword);

                            reader.Close();

                            if (!isValidPassword)
                            {
                                ShowLoginFailed();
                                return;
                            }

                            if (isLegacyPassword)
                                UpgradeLegacyPassword(con, userId, password);

                            using MainForm mainForm = new MainForm(userId);
                            Hide();
                            mainForm.ShowDialog(this);
                            Close();
                        }

                        else
                        {
                            ShowLoginFailed();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error:\n\n" + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpgradeLegacyPassword(NpgsqlConnection connection, int userId, string password)
        {
            const string sql = @"
                UPDATE t_user
                SET c_password_hash = @passwordHash
                WHERE c_user_id = @userId;";

            using NpgsqlCommand command = new NpgsqlCommand(sql, connection);
            command.Parameters.AddWithValue("@passwordHash", BCrypt.Net.BCrypt.HashPassword(password));
            command.Parameters.AddWithValue("@userId", userId);
            command.ExecuteNonQuery();
        }

        private static bool PasswordsMatch(string enteredPassword, string storedPassword)
        {
            byte[] enteredBytes = Encoding.UTF8.GetBytes(enteredPassword);
            byte[] storedBytes = Encoding.UTF8.GetBytes(storedPassword);
            return enteredBytes.Length == storedBytes.Length &&
                   CryptographicOperations.FixedTimeEquals(enteredBytes, storedBytes);
        }

        private void ShowLoginFailed()
        {
            MessageBox.Show("Invalid username or password.", "Login Failed",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            textBox2.Clear();
            textBox2.Focus();
        }

        // ── Sign Up button (button2) ───────────────────────────────────────
        // If your designer named the "Don't have account?" link button2:
        private void button2_Click(object sender, EventArgs e)
        {
            using Form1 signupForm = new Form1();
            Hide();
            signupForm.ShowDialog(this);
            if (!IsDisposed)
                Show();
        }
    }
}
