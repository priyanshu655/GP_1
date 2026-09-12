namespace MoneyMap.AdminPanel
{
    partial class AdminDashboard
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnTransactions;
        private System.Windows.Forms.Button btnCategories;
        private System.Windows.Forms.Button btnTransactionTypes;
        private System.Windows.Forms.Button btnBudgets;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnAnalysis;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.btnAnalysis = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnBudgets = new System.Windows.Forms.Button();
            this.btnTransactionTypes = new System.Windows.Forms.Button();
            this.btnCategories = new System.Windows.Forms.Button();
            this.btnTransactions = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();

            this.pnlHeader.SuspendLayout();
            this.pnlSidebar.SuspendLayout();
            this.SuspendLayout();

            #region Header

            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.btnLogout);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1200, 75);
            this.pnlHeader.TabIndex = 0;

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font(
                "Segoe UI",
                22F,
                System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(25, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(174, 41);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Admin Panel";

            this.btnLogout.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Right;
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font(
                "Segoe UI",
                10F,
                System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(1085, 20);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(90, 35);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.BtnLogout_Click);

            #endregion

            #region Sidebar

            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.pnlSidebar.Controls.Add(this.btnAnalysis);
            this.pnlSidebar.Controls.Add(this.btnSettings);
            this.pnlSidebar.Controls.Add(this.btnBudgets);
            this.pnlSidebar.Controls.Add(this.btnTransactionTypes);
            this.pnlSidebar.Controls.Add(this.btnCategories);
            this.pnlSidebar.Controls.Add(this.btnTransactions);
            this.pnlSidebar.Controls.Add(this.btnUsers);
            this.pnlSidebar.Controls.Add(this.btnDashboard);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 75);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(250, 625);
            this.pnlSidebar.TabIndex = 1;

            #region Dashboard

            this.btnDashboard.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.btnDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font(
                "Segoe UI",
                11F);
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Location = new System.Drawing.Point(0, 0);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(250, 60);
            this.btnDashboard.TabIndex = 0;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnDashboard.UseVisualStyleBackColor = false;

            #endregion

            #region Users

            this.btnUsers.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.btnUsers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUsers.FlatAppearance.BorderSize = 0;
            this.btnUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsers.Font = new System.Drawing.Font(
                "Segoe UI",
                11F);
            this.btnUsers.ForeColor = System.Drawing.Color.White;
            this.btnUsers.Location = new System.Drawing.Point(0, 60);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(250, 60);
            this.btnUsers.TabIndex = 1;
            this.btnUsers.Text = "Users";
            this.btnUsers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsers.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnUsers.UseVisualStyleBackColor = false;

            #endregion

            #region Transactions

            this.btnTransactions.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.btnTransactions.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTransactions.FlatAppearance.BorderSize = 0;
            this.btnTransactions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransactions.Font = new System.Drawing.Font(
                "Segoe UI",
                11F);
            this.btnTransactions.ForeColor = System.Drawing.Color.White;
            this.btnTransactions.Location = new System.Drawing.Point(0, 120);
            this.btnTransactions.Name = "btnTransactions";
            this.btnTransactions.Size = new System.Drawing.Size(250, 60);
            this.btnTransactions.TabIndex = 2;
            this.btnTransactions.Text = "Transactions";
            this.btnTransactions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTransactions.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnTransactions.UseVisualStyleBackColor = false;

            #endregion

            #region Categories

            this.btnCategories.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.btnCategories.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCategories.FlatAppearance.BorderSize = 0;
            this.btnCategories.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategories.Font = new System.Drawing.Font(
                "Segoe UI",
                11F);
            this.btnCategories.ForeColor = System.Drawing.Color.White;
            this.btnCategories.Location = new System.Drawing.Point(0, 180);
            this.btnCategories.Name = "btnCategories";
            this.btnCategories.Size = new System.Drawing.Size(250, 60);
            this.btnCategories.TabIndex = 3;
            this.btnCategories.Text = "Categories";
            this.btnCategories.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategories.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnCategories.UseVisualStyleBackColor = false;

            #endregion

            #region Transaction Types

            this.btnTransactionTypes.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.btnTransactionTypes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTransactionTypes.FlatAppearance.BorderSize = 0;
            this.btnTransactionTypes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransactionTypes.Font = new System.Drawing.Font(
                "Segoe UI",
                11F);
            this.btnTransactionTypes.ForeColor = System.Drawing.Color.White;
            this.btnTransactionTypes.Location = new System.Drawing.Point(0, 240);
            this.btnTransactionTypes.Name = "btnTransactionTypes";
            this.btnTransactionTypes.Size = new System.Drawing.Size(250, 60);
            this.btnTransactionTypes.TabIndex = 4;
            this.btnTransactionTypes.Text = "Transaction Types";
            this.btnTransactionTypes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTransactionTypes.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnTransactionTypes.UseVisualStyleBackColor = false;

            #endregion

            #region Budgets

            this.btnBudgets.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.btnBudgets.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBudgets.FlatAppearance.BorderSize = 0;
            this.btnBudgets.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBudgets.Font = new System.Drawing.Font(
                "Segoe UI",
                11F);
            this.btnBudgets.ForeColor = System.Drawing.Color.White;
            this.btnBudgets.Location = new System.Drawing.Point(0, 300);
            this.btnBudgets.Name = "btnBudgets";
            this.btnBudgets.Size = new System.Drawing.Size(250, 60);
            this.btnBudgets.TabIndex = 5;
            this.btnBudgets.Text = "Budgets";
            this.btnBudgets.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBudgets.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnBudgets.UseVisualStyleBackColor = false;

            #endregion

            #region Settings

            this.btnSettings.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.btnSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font(
                "Segoe UI",
                11F);
            this.btnSettings.ForeColor = System.Drawing.Color.White;
            this.btnSettings.Location = new System.Drawing.Point(0, 360);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(250, 60);
            this.btnSettings.TabIndex = 6;
            this.btnSettings.Text = "Settings";
            this.btnSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnSettings.UseVisualStyleBackColor = false;

            #endregion

            #region System Analysis

            this.btnAnalysis.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.btnAnalysis.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAnalysis.FlatAppearance.BorderSize = 0;
            this.btnAnalysis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnalysis.Font = new System.Drawing.Font(
                "Segoe UI",
                11F);
            this.btnAnalysis.ForeColor = System.Drawing.Color.White;
            this.btnAnalysis.Location = new System.Drawing.Point(0, 420);
            this.btnAnalysis.Name = "btnAnalysis";
            this.btnAnalysis.Size = new System.Drawing.Size(250, 60);
            this.btnAnalysis.TabIndex = 7;
            this.btnAnalysis.Text = "System Analysis";
            this.btnAnalysis.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAnalysis.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnAnalysis.UseVisualStyleBackColor = false;

            #endregion

            #endregion

            #region Main Panel

            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(250, 75);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(950, 625);
            this.pnlMain.TabIndex = 2;

            #endregion

            #region Form

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlSidebar);
            this.Controls.Add(this.pnlHeader);
            this.Name = "AdminDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MoneyMap - Admin Panel";

            #endregion

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlSidebar.ResumeLayout(false);
            this.ResumeLayout(false);

            this.btnDashboard.Click += new System.EventHandler(this.BtnDashboard_Click);
            this.btnUsers.Click += new System.EventHandler(this.BtnUsers_Click);
            this.btnTransactions.Click += new System.EventHandler(this.BtnTransactions_Click);
            this.btnCategories.Click += new System.EventHandler(this.BtnCategories_Click);
            this.btnTransactionTypes.Click += new System.EventHandler(this.BtnTransactionTypes_Click);
            this.btnBudgets.Click += new System.EventHandler(this.BtnBudgets_Click);
            this.btnSettings.Click += new System.EventHandler(this.BtnSettings_Click);
            this.btnAnalysis.Click += new System.EventHandler(this.BtnAnalysis_Click);
        }

        #endregion
    }
}