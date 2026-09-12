using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Npgsql;
using SignupPage;
using MoneyMap.Main;
using MoneyMap.Authentication;

namespace LoginPage
{
    public partial class Login : Form
    {
        private string connectionString = "Server=localhost;Port=5432;Database=MoneyMap;Username=postgres;Password=password";

        public int LoggedInUserId { get; private set; } = -1;

        public Login()
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

        private void Login_Load(object sender, EventArgs e)
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

                        object? result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            int userId = Convert.ToInt32(result);
                            SessionManager.SaveSession(userId, username);

                            MainForm mainForm = new MainForm(userId);

                            this.Hide();
                            mainForm.ShowDialog();

                            if (mainForm.LoggedOut)
                            {
                                textBox2.Clear();
                                this.Show();
                                CenterCard();
                                textBox2.Focus();
                            }
                            else
                            {
                                this.Close();
                            }
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
        private void button2_Click(object sender, EventArgs e)
        {
            Form1 signupForm = new Form1();
            signupForm.Show();
            this.Hide();
        }
    }
}