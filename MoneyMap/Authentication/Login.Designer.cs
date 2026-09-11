namespace LoginPage
{
    public partial class Login : System.Windows.Forms.Form
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);

            // Main containers
            this.mainPanel  = new System.Windows.Forms.Panel();
            this.leftPanel  = new System.Windows.Forms.Panel();
            this.rightPanel = new System.Windows.Forms.Panel();

            // Left panel controls
            this.moneyIcon    = new System.Windows.Forms.Label();
            this.logoLabel    = new System.Windows.Forms.Label();
            this.taglineLabel = new System.Windows.Forms.Label();
            this.footerLabel  = new System.Windows.Forms.Label();

            // Right panel controls
            this.titleLabel         = new System.Windows.Forms.Label();
            this.subtitleLabel      = new System.Windows.Forms.Label();
            this.usernameLabel      = new System.Windows.Forms.Label();
            this.textBox1           = new System.Windows.Forms.TextBox();
            this.passwordLabel      = new System.Windows.Forms.Label();
            this.textBox2           = new System.Windows.Forms.TextBox();
            this.showPasswordButton = new System.Windows.Forms.Button();
            this.button1            = new System.Windows.Forms.Button();
            this.signupQuestionLabel = new System.Windows.Forms.Label();
            this.button2            = new System.Windows.Forms.Button();

            // ── Suspend layouts ──────────────────────────────────────────────
            this.mainPanel.SuspendLayout();
            this.leftPanel.SuspendLayout();
            this.rightPanel.SuspendLayout();
            this.SuspendLayout();

            // ================================================================
            //  MAIN PANEL
            // ================================================================
            this.mainPanel.BackColor = System.Drawing.Color.White;
            this.mainPanel.Controls.Add(this.rightPanel);  // Fill first
            this.mainPanel.Controls.Add(this.leftPanel);   // Left on top
            this.mainPanel.Dock     = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Name     = "mainPanel";
            this.mainPanel.TabIndex = 0;

            // ================================================================
            //  LEFT PANEL
            // ================================================================
            this.leftPanel.BackColor = System.Drawing.Color.FromArgb(24, 31, 42);
            this.leftPanel.Dock      = System.Windows.Forms.DockStyle.Left;
            this.leftPanel.Width     = 380;
            this.leftPanel.Name      = "leftPanel";
            this.leftPanel.Padding   = new System.Windows.Forms.Padding(40, 0, 40, 0);

            // Money Icon
            this.moneyIcon.AutoSize  = true;
            this.moneyIcon.Font      = new System.Drawing.Font(
                "Segoe UI", 52F, System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point);
            this.moneyIcon.ForeColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.moneyIcon.Name      = "moneyIcon";
            this.moneyIcon.Text      = "$";

            // Logo Label
            this.logoLabel.AutoSize  = true;
            this.logoLabel.Font      = new System.Drawing.Font(
                "Segoe UI", 28F, System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point);
            this.logoLabel.ForeColor = System.Drawing.Color.White;
            this.logoLabel.Name      = "logoLabel";
            this.logoLabel.Text      = "MoneyMap";

            // Tagline Label
            this.taglineLabel.AutoSize  = false;
            this.taglineLabel.Font      = new System.Drawing.Font(
                "Segoe UI", 11F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point);
            this.taglineLabel.ForeColor = System.Drawing.Color.FromArgb(190, 198, 210);
            this.taglineLabel.Name      = "taglineLabel";
            this.taglineLabel.Text      =
                "Welcome back!\r\n\r\n" +
                "Login to continue tracking\r\n" +
                "your income, expenses,\r\n" +
                "and financial goals.";
            this.taglineLabel.TextAlign = System.Drawing.ContentAlignment.TopLeft;

            // Footer Label
            this.footerLabel.AutoSize  = true;
            this.footerLabel.Font      = new System.Drawing.Font(
                "Segoe UI", 9F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point);
            this.footerLabel.ForeColor = System.Drawing.Color.FromArgb(130, 140, 155);
            this.footerLabel.Name      = "footerLabel";
            this.footerLabel.Text      = "Smart money. Better decisions.";

            // Add controls to left panel
            this.leftPanel.Controls.Add(this.footerLabel);
            this.leftPanel.Controls.Add(this.taglineLabel);
            this.leftPanel.Controls.Add(this.logoLabel);
            this.leftPanel.Controls.Add(this.moneyIcon);

            // ================================================================
            //  RIGHT PANEL
            // ================================================================
            this.rightPanel.BackColor  = System.Drawing.Color.FromArgb(248, 249, 251);
            this.rightPanel.Dock       = System.Windows.Forms.DockStyle.Fill;
            this.rightPanel.Name       = "rightPanel";
            this.rightPanel.AutoScroll = true;

            // Title
            this.titleLabel.AutoSize  = false;
            this.titleLabel.Font      = new System.Drawing.Font(
                "Segoe UI", 26F, System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point);
            this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(35, 42, 52);
            this.titleLabel.Name      = "titleLabel";
            this.titleLabel.Text      = "Welcome Back";
            this.titleLabel.Height    = 55;

            // Subtitle
            this.subtitleLabel.AutoSize  = false;
            this.subtitleLabel.Font      = new System.Drawing.Font(
                "Segoe UI", 10F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point);
            this.subtitleLabel.ForeColor = System.Drawing.Color.FromArgb(110, 118, 130);
            this.subtitleLabel.Name      = "subtitleLabel";
            this.subtitleLabel.Text      = "Login to access your MoneyMap account.";
            this.subtitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.subtitleLabel.Height    = 35;

            // Username Label
            this.usernameLabel.AutoSize  = false;
            this.usernameLabel.Font      = new System.Drawing.Font(
                "Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point);
            this.usernameLabel.ForeColor = System.Drawing.Color.FromArgb(55, 63, 75);
            this.usernameLabel.Name      = "usernameLabel";
            this.usernameLabel.Text      = "Username";
            this.usernameLabel.Height    = 22;

            // Username TextBox
            this.textBox1.BackColor    = System.Drawing.Color.White;
            this.textBox1.BorderStyle  = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font         = new System.Drawing.Font(
                "Segoe UI", 11F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point);
            this.textBox1.ForeColor      = System.Drawing.Color.FromArgb(40, 45, 52);
            this.textBox1.Name           = "textBox1";
            this.textBox1.PlaceholderText = "Enter your username";
            this.textBox1.Height         = 35;
            this.textBox1.TabIndex       = 0;
            this.toolTip.SetToolTip(this.textBox1, "Enter the username you chose when creating your account.");

            // Password Label
            this.passwordLabel.AutoSize  = false;
            this.passwordLabel.Font      = new System.Drawing.Font(
                "Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point);
            this.passwordLabel.ForeColor = System.Drawing.Color.FromArgb(55, 63, 75);
            this.passwordLabel.Name      = "passwordLabel";
            this.passwordLabel.Text      = "Password";
            this.passwordLabel.Height    = 22;

            // Password TextBox
            this.textBox2.BackColor           = System.Drawing.Color.White;
            this.textBox2.BorderStyle         = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Font                = new System.Drawing.Font(
                "Segoe UI", 11F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point);
            this.textBox2.ForeColor             = System.Drawing.Color.FromArgb(40, 45, 52);
            this.textBox2.Name                  = "textBox2";
            this.textBox2.PlaceholderText       = "Enter your password";
            this.textBox2.UseSystemPasswordChar = true;
            this.textBox2.Height                = 35;
            this.textBox2.TabIndex              = 1;
            this.toolTip.SetToolTip(this.textBox2, "Enter your password. Select Show to check what you typed.");

            // Show password button
            this.showPasswordButton.BackColor                 = System.Drawing.Color.White;
            this.showPasswordButton.FlatAppearance.BorderSize = 0;
            this.showPasswordButton.FlatStyle                 = System.Windows.Forms.FlatStyle.Flat;
            this.showPasswordButton.Font                      = new System.Drawing.Font("Segoe UI", 9F);
            this.showPasswordButton.ForeColor                 = System.Drawing.Color.FromArgb(39, 174, 96);
            this.showPasswordButton.Name                      = "showPasswordButton";
            this.showPasswordButton.Text                      = "Show";
            this.showPasswordButton.UseVisualStyleBackColor   = false;
            this.showPasswordButton.Cursor                    = System.Windows.Forms.Cursors.Hand;
            this.showPasswordButton.Size                      = new System.Drawing.Size(72, 35);
            this.showPasswordButton.TabIndex                  = 2;
            this.toolTip.SetToolTip(this.showPasswordButton, "Show or hide your password.");
            this.showPasswordButton.Click += new System.EventHandler(this.showPasswordButton_Click);

            // Login Button
            this.button1.BackColor                       = System.Drawing.Color.FromArgb(46, 204, 113);
            this.button1.FlatAppearance.BorderSize       = 0;
            this.button1.FlatAppearance.MouseOverBackColor =
                System.Drawing.Color.FromArgb(39, 174, 96);
            this.button1.FlatStyle                       = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font                            = new System.Drawing.Font(
                "Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor                       = System.Drawing.Color.White;
            this.button1.Name                            = "button1";
            this.button1.Text                            = "Login";
            this.button1.UseVisualStyleBackColor         = false;
            this.button1.Cursor                          = System.Windows.Forms.Cursors.Hand;
            this.button1.Height                          = 46;
            this.button1.TabIndex                        = 3;
            this.toolTip.SetToolTip(this.button1, "Sign in to MoneyMap.");
            this.button1.Click += new System.EventHandler(this.button1_Click);

            // "Don't have an account?" label
            this.signupQuestionLabel.AutoSize  = true;
            this.signupQuestionLabel.Font      = new System.Drawing.Font(
                "Segoe UI", 9.5F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point);
            this.signupQuestionLabel.ForeColor = System.Drawing.Color.FromArgb(110, 118, 130);
            this.signupQuestionLabel.Name      = "signupQuestionLabel";
            this.signupQuestionLabel.Text      = "Don't have an account?";

            // Sign Up Button
            this.button2.BackColor                 = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle                 = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font                      = new System.Drawing.Font(
                "Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point);
            this.button2.ForeColor                 = System.Drawing.Color.FromArgb(39, 174, 96);
            this.button2.Name                      = "button2";
            this.button2.Text                      = "Sign Up";
            this.button2.UseVisualStyleBackColor   = false;
            this.button2.Cursor                    = System.Windows.Forms.Cursors.Hand;
            this.button2.Size                      = new System.Drawing.Size(80, 28);
            this.button2.TabIndex                  = 4;
            this.toolTip.SetToolTip(this.button2, "Create a new MoneyMap account.");
            this.button2.Click += new System.EventHandler(this.button2_Click);

            // Add controls to right panel
            this.rightPanel.Controls.Add(this.titleLabel);
            this.rightPanel.Controls.Add(this.subtitleLabel);
            this.rightPanel.Controls.Add(this.usernameLabel);
            this.rightPanel.Controls.Add(this.textBox1);
            this.rightPanel.Controls.Add(this.passwordLabel);
            this.rightPanel.Controls.Add(this.textBox2);
            this.rightPanel.Controls.Add(this.showPasswordButton);
            this.rightPanel.Controls.Add(this.button1);
            this.rightPanel.Controls.Add(this.signupQuestionLabel);
            this.rightPanel.Controls.Add(this.button2);

            // ================================================================
            //  FORM
            // ================================================================
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.White;
            this.ClientSize          = new System.Drawing.Size(1000, 650);
            this.MinimumSize         = new System.Drawing.Size(700, 500);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox         = true;
            this.MinimizeBox         = true;
            this.Name                = "Login";
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text                = "MoneyMap - Login";
            this.AcceptButton        = this.button1;

            this.Load   += new System.EventHandler(this.Login_Load);
            this.Resize += new System.EventHandler(this.Login_Resize);

            // ── Resume layouts ───────────────────────────────────────────────
            this.mainPanel.ResumeLayout(false);
            this.leftPanel.ResumeLayout(false);
            this.leftPanel.PerformLayout();
            this.rightPanel.ResumeLayout(false);
            this.rightPanel.PerformLayout();
            this.ResumeLayout(false);
        }

        // ====================================================================
        //  Layout engine
        // ====================================================================
        private const int PAD = 40;
        // Allow room for the button text at high-DPI display scaling.
        private const int PasswordToggleWidth = 72;
        private const int PasswordToggleGap = 10;

        private void UpdateLayout()
        {
            int W = this.ClientSize.Width;
            int H = this.ClientSize.Height;

            bool narrow = W < 768;

            // ── Panel docking ────────────────────────────────────────────────
            if (narrow)
            {
                leftPanel.Dock   = System.Windows.Forms.DockStyle.Top;
                leftPanel.Height = (int)(H * 0.30);
            }
            else
            {
                leftPanel.Dock  = System.Windows.Forms.DockStyle.Left;
                leftPanel.Width = (int)(W * 0.38);
            }

            rightPanel.Dock = System.Windows.Forms.DockStyle.Fill;

            // ── Left panel ───────────────────────────────────────────────────
            LayoutLeftPanel(narrow);

            // ── Right panel ──────────────────────────────────────────────────
            int rW = rightPanel.Width;
            if (rW < 50) return;

            LayoutRightPanel(rW, H, narrow);
        }

        private void LayoutLeftPanel(bool narrow)
        {
            int lW = leftPanel.Width;
            int lH = leftPanel.Height;
            int px = leftPanel.Padding.Left;   // 40

            if (narrow)
            {
                moneyIcon.Location   = new System.Drawing.Point((lW - moneyIcon.Width) / 2, 10);
                logoLabel.Location   = new System.Drawing.Point((lW - logoLabel.Width)  / 2,
                                           moneyIcon.Bottom + 4);
                taglineLabel.Visible = false;
                footerLabel.Location = new System.Drawing.Point(px, lH - footerLabel.Height - 8);
            }
            else
            {
                taglineLabel.Visible = true;

                moneyIcon.Location    = new System.Drawing.Point(px, (int)(lH * 0.15));
                logoLabel.Location    = new System.Drawing.Point(px, moneyIcon.Bottom + 6);
                taglineLabel.Location = new System.Drawing.Point(px, logoLabel.Bottom + 18);
                taglineLabel.Width    = lW - px * 2;
                taglineLabel.Height   = (int)(lH * 0.28);
                footerLabel.Location  = new System.Drawing.Point(px, lH - footerLabel.Height - 20);
            }
        }

        private void LayoutRightPanel(int rW, int H, bool narrow)
        {
            int pad        = narrow ? 24 : PAD;
            int fieldWidth = rW - pad * 2;
            if (fieldWidth < 10) return;

            int x = pad;
            int y = narrow ? 20 : (int)(H * 0.12);
            if (y < 20) y = 20;

            // Title
            titleLabel.Location = new System.Drawing.Point(x, y);
            titleLabel.Width    = fieldWidth;
            y = titleLabel.Bottom + 6;

            // Subtitle
            subtitleLabel.Location = new System.Drawing.Point(x, y);
            subtitleLabel.Width    = fieldWidth;
            y = subtitleLabel.Bottom + 28;

            // Username
            usernameLabel.Location = new System.Drawing.Point(x, y);
            usernameLabel.Width    = fieldWidth;
            y = usernameLabel.Bottom + 5;

            textBox1.Location = new System.Drawing.Point(x, y);
            textBox1.Width    = fieldWidth;
            y = textBox1.Bottom + 22;

            // Password
            passwordLabel.Location = new System.Drawing.Point(x, y);
            passwordLabel.Width    = fieldWidth;
            y = passwordLabel.Bottom + 5;

            textBox2.Location = new System.Drawing.Point(x, y);
            textBox2.Width    = fieldWidth - PasswordToggleWidth - PasswordToggleGap;
            showPasswordButton.Size = new System.Drawing.Size(PasswordToggleWidth, textBox2.Height);
            showPasswordButton.Location = new System.Drawing.Point(textBox2.Right + PasswordToggleGap, textBox2.Top);
            y = textBox2.Bottom + 30;

            // Login button
            button1.Location = new System.Drawing.Point(x, y);
            button1.Width    = fieldWidth;
            y = button1.Bottom + 22;

            // "Don't have an account?" + Sign Up on same row
            signupQuestionLabel.Location = new System.Drawing.Point(x, y + 3);
            button2.Location             = new System.Drawing.Point(
                                               signupQuestionLabel.Right + 2, y);
        }

        private void Login_Load(object sender, System.EventArgs e)
        {
            UpdateLayout();
        }

        private void Login_Resize(object sender, System.EventArgs e)
        {
            UpdateLayout();
        }

        // ====================================================================
        //  Field declarations
        // ====================================================================
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Panel rightPanel;

        private System.Windows.Forms.Label moneyIcon;
        private System.Windows.Forms.Label logoLabel;
        private System.Windows.Forms.Label taglineLabel;
        private System.Windows.Forms.Label footerLabel;

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label subtitleLabel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label signupQuestionLabel;

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button showPasswordButton;

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolTip toolTip;
    }
}
