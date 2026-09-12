namespace LoginPage
{
    partial class Login
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.mainPanel = new System.Windows.Forms.Panel();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.cardPanel = new System.Windows.Forms.Panel();
            this.bottomFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.signupQuestionLabel = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.subtitleLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.footerLabel = new System.Windows.Forms.Label();
            this.featureBullet4 = new System.Windows.Forms.Label();
            this.featureBullet3 = new System.Windows.Forms.Label();
            this.featureBullet2 = new System.Windows.Forms.Label();
            this.featureBullet1 = new System.Windows.Forms.Label();
            this.taglineLabel = new System.Windows.Forms.Label();
            this.logoLabel = new System.Windows.Forms.Label();
            this.moneyIcon = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            this.rightPanel.SuspendLayout();
            this.cardPanel.SuspendLayout();
            this.bottomFlow.SuspendLayout();
            this.leftPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.White;
            this.mainPanel.Controls.Add(this.rightPanel);
            this.mainPanel.Controls.Add(this.leftPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(960, 620);
            this.mainPanel.TabIndex = 0;
            // 
            // rightPanel
            // 
            this.rightPanel.AutoScroll = true;
            this.rightPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.rightPanel.Controls.Add(this.cardPanel);
            this.rightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightPanel.Location = new System.Drawing.Point(360, 0);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(600, 620);
            this.rightPanel.TabIndex = 1;
            this.rightPanel.Resize += new System.EventHandler(this.RightPanel_Resize);
            // 
            // cardPanel
            // 
            this.cardPanel.BackColor = System.Drawing.Color.White;
            this.cardPanel.Controls.Add(this.bottomFlow);
            this.cardPanel.Controls.Add(this.button1);
            this.cardPanel.Controls.Add(this.textBox2);
            this.cardPanel.Controls.Add(this.passwordLabel);
            this.cardPanel.Controls.Add(this.textBox1);
            this.cardPanel.Controls.Add(this.usernameLabel);
            this.cardPanel.Controls.Add(this.subtitleLabel);
            this.cardPanel.Controls.Add(this.titleLabel);
            this.cardPanel.Location = new System.Drawing.Point(80, 70);
            this.cardPanel.Name = "cardPanel";
            this.cardPanel.Padding = new System.Windows.Forms.Padding(36, 36, 36, 36);
            this.cardPanel.Size = new System.Drawing.Size(440, 480);
            this.cardPanel.TabIndex = 0;
            // 
            // bottomFlow
            // 
            this.bottomFlow.Controls.Add(this.signupQuestionLabel);
            this.bottomFlow.Controls.Add(this.button2);
            this.bottomFlow.Dock = System.Windows.Forms.DockStyle.Top;
            this.bottomFlow.Location = new System.Drawing.Point(36, 396);
            this.bottomFlow.Margin = new System.Windows.Forms.Padding(0);
            this.bottomFlow.Name = "bottomFlow";
            this.bottomFlow.Padding = new System.Windows.Forms.Padding(0, 14, 0, 0);
            this.bottomFlow.Size = new System.Drawing.Size(368, 45);
            this.bottomFlow.TabIndex = 7;
            this.bottomFlow.WrapContents = false;
            // 
            // signupQuestionLabel
            // 
            this.signupQuestionLabel.AutoSize = true;
            this.signupQuestionLabel.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.signupQuestionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.signupQuestionLabel.Location = new System.Drawing.Point(0, 17);
            this.signupQuestionLabel.Margin = new System.Windows.Forms.Padding(0, 3, 4, 0);
            this.signupQuestionLabel.Name = "signupQuestionLabel";
            this.signupQuestionLabel.Size = new System.Drawing.Size(147, 17);
            this.signupQuestionLabel.TabIndex = 0;
            this.signupQuestionLabel.Text = "Don\'t have an account?";
            // 
            // button2
            // 
            this.button2.AutoSize = true;
            this.button2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.button2.Location = new System.Drawing.Point(151, 14);
            this.button2.Margin = new System.Windows.Forms.Padding(0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(117, 27);
            this.button2.TabIndex = 1;
            this.button2.Text = "Create Account";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(150)))), ((int)(((byte)(105)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(36, 352);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(368, 44);
            this.button1.TabIndex = 6;
            this.button1.Text = "Sign In  ➔";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.textBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.textBox2.Location = new System.Drawing.Point(36, 285);
            this.textBox2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 40);
            this.textBox2.Name = "textBox2";
            this.textBox2.PlaceholderText = "Enter your password";
            this.textBox2.Size = new System.Drawing.Size(368, 27);
            this.textBox2.TabIndex = 5;
            this.textBox2.UseSystemPasswordChar = true;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.passwordLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.passwordLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.passwordLabel.Location = new System.Drawing.Point(36, 246);
            this.passwordLabel.Margin = new System.Windows.Forms.Padding(0);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Padding = new System.Windows.Forms.Padding(0, 18, 0, 6);
            this.passwordLabel.Size = new System.Drawing.Size(71, 39);
            this.passwordLabel.TabIndex = 4;
            this.passwordLabel.Text = "PASSWORD";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.textBox1.Location = new System.Drawing.Point(36, 219);
            this.textBox1.Margin = new System.Windows.Forms.Padding(0);
            this.textBox1.Name = "textBox1";
            this.textBox1.PlaceholderText = "Enter your username";
            this.textBox1.Size = new System.Drawing.Size(368, 27);
            this.textBox1.TabIndex = 3;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.usernameLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.usernameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.usernameLabel.Location = new System.Drawing.Point(36, 178);
            this.usernameLabel.Margin = new System.Windows.Forms.Padding(0);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Padding = new System.Windows.Forms.Padding(0, 20, 0, 6);
            this.usernameLabel.Size = new System.Drawing.Size(68, 41);
            this.usernameLabel.TabIndex = 2;
            this.usernameLabel.Text = "USERNAME";
            // 
            // subtitleLabel
            // 
            this.subtitleLabel.AutoSize = true;
            this.subtitleLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.subtitleLabel.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.subtitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.subtitleLabel.Location = new System.Drawing.Point(36, 81);
            this.subtitleLabel.Margin = new System.Windows.Forms.Padding(0);
            this.subtitleLabel.Name = "subtitleLabel";
            this.subtitleLabel.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.subtitleLabel.Size = new System.Drawing.Size(262, 23);
            this.subtitleLabel.TabIndex = 1;
            this.subtitleLabel.Text = "Sign in to access your finances and records.";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.titleLabel.Location = new System.Drawing.Point(36, 36);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.titleLabel.Size = new System.Drawing.Size(236, 45);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Welcome Back 👋";
            // 
            // leftPanel
            // 
            this.leftPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.leftPanel.Controls.Add(this.footerLabel);
            this.leftPanel.Controls.Add(this.featureBullet4);
            this.leftPanel.Controls.Add(this.featureBullet3);
            this.leftPanel.Controls.Add(this.featureBullet2);
            this.leftPanel.Controls.Add(this.featureBullet1);
            this.leftPanel.Controls.Add(this.taglineLabel);
            this.leftPanel.Controls.Add(this.logoLabel);
            this.leftPanel.Controls.Add(this.moneyIcon);
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftPanel.Location = new System.Drawing.Point(0, 0);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Padding = new System.Windows.Forms.Padding(36, 48, 36, 32);
            this.leftPanel.Size = new System.Drawing.Size(360, 620);
            this.leftPanel.TabIndex = 0;
            // 
            // footerLabel
            // 
            this.footerLabel.AutoSize = true;
            this.footerLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footerLabel.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.footerLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.footerLabel.Location = new System.Drawing.Point(36, 573);
            this.footerLabel.Name = "footerLabel";
            this.footerLabel.Size = new System.Drawing.Size(248, 15);
            this.footerLabel.TabIndex = 7;
            this.footerLabel.Text = "MoneyMap © 2026 • Smart Financial Decisions";
            // 
            // featureBullet4
            // 
            this.featureBullet4.AutoSize = true;
            this.featureBullet4.Dock = System.Windows.Forms.DockStyle.Top;
            this.featureBullet4.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.featureBullet4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.featureBullet4.Location = new System.Drawing.Point(36, 298);
            this.featureBullet4.Margin = new System.Windows.Forms.Padding(0);
            this.featureBullet4.Name = "featureBullet4";
            this.featureBullet4.Padding = new System.Windows.Forms.Padding(0, 0, 0, 12);
            this.featureBullet4.Size = new System.Drawing.Size(262, 29);
            this.featureBullet4.TabIndex = 6;
            this.featureBullet4.Text = "🔔  Instant Alerts on Budget Exceeding";
            // 
            // featureBullet3
            // 
            this.featureBullet3.AutoSize = true;
            this.featureBullet3.Dock = System.Windows.Forms.DockStyle.Top;
            this.featureBullet3.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.featureBullet3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.featureBullet3.Location = new System.Drawing.Point(36, 269);
            this.featureBullet3.Margin = new System.Windows.Forms.Padding(0);
            this.featureBullet3.Name = "featureBullet3";
            this.featureBullet3.Padding = new System.Windows.Forms.Padding(0, 0, 0, 12);
            this.featureBullet3.Size = new System.Drawing.Size(232, 29);
            this.featureBullet3.TabIndex = 5;
            this.featureBullet3.Text = "📁  Seamless CSV Import & Export";
            // 
            // featureBullet2
            // 
            this.featureBullet2.AutoSize = true;
            this.featureBullet2.Dock = System.Windows.Forms.DockStyle.Top;
            this.featureBullet2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.featureBullet2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.featureBullet2.Location = new System.Drawing.Point(36, 240);
            this.featureBullet2.Margin = new System.Windows.Forms.Padding(0);
            this.featureBullet2.Name = "featureBullet2";
            this.featureBullet2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 12);
            this.featureBullet2.Size = new System.Drawing.Size(248, 29);
            this.featureBullet2.TabIndex = 4;
            this.featureBullet2.Text = "🎯  Monthly & Category Budget Limits";
            // 
            // featureBullet1
            // 
            this.featureBullet1.AutoSize = true;
            this.featureBullet1.Dock = System.Windows.Forms.DockStyle.Top;
            this.featureBullet1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.featureBullet1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.featureBullet1.Location = new System.Drawing.Point(36, 211);
            this.featureBullet1.Margin = new System.Windows.Forms.Padding(0);
            this.featureBullet1.Name = "featureBullet1";
            this.featureBullet1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 12);
            this.featureBullet1.Size = new System.Drawing.Size(249, 29);
            this.featureBullet1.TabIndex = 3;
            this.featureBullet1.Text = "📊  Real-Time Income & Expense Track";
            // 
            // taglineLabel
            // 
            this.taglineLabel.AutoSize = true;
            this.taglineLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.taglineLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.taglineLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.taglineLabel.Location = new System.Drawing.Point(36, 142);
            this.taglineLabel.Margin = new System.Windows.Forms.Padding(0);
            this.taglineLabel.Name = "taglineLabel";
            this.taglineLabel.Padding = new System.Windows.Forms.Padding(0, 6, 0, 44);
            this.taglineLabel.Size = new System.Drawing.Size(245, 69);
            this.taglineLabel.TabIndex = 2;
            this.taglineLabel.Text = "Smart, elegant personal finance\r\ntracking made simple and powerful.";
            // 
            // logoLabel
            // 
            this.logoLabel.AutoSize = true;
            this.logoLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.logoLabel.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.logoLabel.ForeColor = System.Drawing.Color.White;
            this.logoLabel.Location = new System.Drawing.Point(36, 97);
            this.logoLabel.Margin = new System.Windows.Forms.Padding(0);
            this.logoLabel.Name = "logoLabel";
            this.logoLabel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.logoLabel.Size = new System.Drawing.Size(189, 45);
            this.logoLabel.TabIndex = 1;
            this.logoLabel.Text = "MoneyMap";
            // 
            // moneyIcon
            // 
            this.moneyIcon.AutoSize = true;
            this.moneyIcon.Dock = System.Windows.Forms.DockStyle.Top;
            this.moneyIcon.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold);
            this.moneyIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.moneyIcon.Location = new System.Drawing.Point(36, 48);
            this.moneyIcon.Margin = new System.Windows.Forms.Padding(0);
            this.moneyIcon.Name = "moneyIcon";
            this.moneyIcon.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.moneyIcon.Size = new System.Drawing.Size(64, 49);
            this.moneyIcon.TabIndex = 0;
            this.moneyIcon.Text = "₹";
            // 
            // Login
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(960, 620);
            this.Controls.Add(this.mainPanel);
            this.MinimumSize = new System.Drawing.Size(780, 560);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MoneyMap — Sign In";
            this.Load += new System.EventHandler(this.Login_Load);
            this.mainPanel.ResumeLayout(false);
            this.rightPanel.ResumeLayout(false);
            this.cardPanel.ResumeLayout(false);
            this.cardPanel.PerformLayout();
            this.bottomFlow.ResumeLayout(false);
            this.bottomFlow.PerformLayout();
            this.leftPanel.ResumeLayout(false);
            this.leftPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Panel rightPanel;
        private System.Windows.Forms.Panel cardPanel;

        private System.Windows.Forms.Label moneyIcon;
        private System.Windows.Forms.Label logoLabel;
        private System.Windows.Forms.Label taglineLabel;
        private System.Windows.Forms.Label featureBullet1;
        private System.Windows.Forms.Label featureBullet2;
        private System.Windows.Forms.Label featureBullet3;
        private System.Windows.Forms.Label featureBullet4;
        private System.Windows.Forms.Label footerLabel;

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label subtitleLabel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;

        private System.Windows.Forms.FlowLayoutPanel bottomFlow;
        private System.Windows.Forms.Label signupQuestionLabel;
        private System.Windows.Forms.Button button2;
    }
}