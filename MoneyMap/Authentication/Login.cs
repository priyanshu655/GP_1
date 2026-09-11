using System;
using System.Windows.Forms;
using Npgsql;
using SignupPage;   // Needed to open your Signup Form1
using MoneyMap.Main;

namespace LoginPage
{
    public partial class Login : Form
    {
        // Same connection you use in Signup
        private string connectionString = "Server=localhost;Port=5432;Database=MoneyMap;Username=postgres;Password=password";

        // Holds the ID of the logged-in user (use this when opening a dashboard)
        public int LoggedInUserId { get; private set; } = -1;

        public Login()
        {
            InitializeComponent();
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

                    string sql = @"
                        SELECT c_user_id 
                        FROM t_user 
                        WHERE c_username      = @username 
                          AND c_password_hash = @password 
                          AND c_is_active     = TRUE;";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        object result = cmd.ExecuteScalar();

                        if (result != null)
{
    int userId = Convert.ToInt32(result);

    MainForm mainForm = new MainForm(userId);

    this.Hide();

    mainForm.ShowDialog();

    this.Close();
}

                        else
                        {
                            MessageBox.Show("Invalid username or password.", "Login Failed",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBox2.Clear();
                            textBox2.Focus();
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

        // ── Sign Up button (button2) ───────────────────────────────────────
        // If your designer named the "Don't have account?" link button2:
        private void button2_Click(object sender, EventArgs e)
        {
            Form1 signupForm = new Form1();
            signupForm.Show();
            this.Hide();
        }
    }
}