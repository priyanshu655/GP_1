namespace MoneyMap.Main
{
    public partial class MainForm : System.Windows.Forms.Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorFiles = new System.Windows.Forms.ToolStripSeparator();
            this.closeFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transactionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setBudgetLimitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorTx = new System.Windows.Forms.ToolStripSeparator();
            this.closeTransactionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dashboardOverviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showIncomeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showExpenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.summaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorView = new System.Windows.Forms.ToolStripSeparator();
            this.closeViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.budgetTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appearanceSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeFontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeTextColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeBgColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorSettings1 = new System.Windows.Forms.ToolStripSeparator();
            this.profileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorSettings2 = new System.Windows.Forms.ToolStripSeparator();
            this.closeSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                        this.homeToolStripMenuItem,
                        this.filesToolStripMenuItem,
                        this.transactionToolStripMenuItem,
                        this.viewToolStripMenuItem,
                        this.budgetTopToolStripMenuItem,
                        this.settingsToolStripMenuItem,
                        this.logoutTopToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(950, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(78, 24);
            this.homeToolStripMenuItem.Text = "🏠 Home";
            this.homeToolStripMenuItem.Click += new System.EventHandler(this.homeToolStripMenuItem_Click);
            // 
            // filesToolStripMenuItem
            // 
            this.filesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                        this.importToolStripMenuItem,
                        this.exportToolStripMenuItem,
                        this.toolStripSeparatorFiles,
                        this.closeFilesToolStripMenuItem});
            this.filesToolStripMenuItem.Name = "filesToolStripMenuItem";
            this.filesToolStripMenuItem.Size = new System.Drawing.Size(50, 24);
            this.filesToolStripMenuItem.Text = "Files";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(235, 26);
            this.importToolStripMenuItem.Text = "Import CSV";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(235, 26);
            this.exportToolStripMenuItem.Text = "Export CSV";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // toolStripSeparatorFiles
            // 
            this.toolStripSeparatorFiles.Name = "toolStripSeparatorFiles";
            this.toolStripSeparatorFiles.Size = new System.Drawing.Size(232, 6);
            // 
            // closeFilesToolStripMenuItem
            // 
            this.closeFilesToolStripMenuItem.Name = "closeFilesToolStripMenuItem";
            this.closeFilesToolStripMenuItem.Size = new System.Drawing.Size(235, 26);
            this.closeFilesToolStripMenuItem.Text = "Close View";
            this.closeFilesToolStripMenuItem.Click += new System.EventHandler(this.closeViewToolStripMenuItem_Click);
            // 
            // transactionToolStripMenuItem
            // 
            this.transactionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                        this.createToolStripMenuItem,
                        this.updateToolStripMenuItem,
                        this.deleteToolStripMenuItem,
                        this.setBudgetLimitToolStripMenuItem,
                        this.toolStripSeparatorTx,
                        this.closeTransactionToolStripMenuItem});
            this.transactionToolStripMenuItem.Name = "transactionToolStripMenuItem";
            this.transactionToolStripMenuItem.Size = new System.Drawing.Size(96, 24);
            this.transactionToolStripMenuItem.Text = "Transaction";
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(240, 26);
            this.createToolStripMenuItem.Text = "Add New Transaction";
            this.createToolStripMenuItem.Click += new System.EventHandler(this.createToolStripMenuItem_Click);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(240, 26);
            this.updateToolStripMenuItem.Text = "Edit Transaction";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(240, 26);
            this.deleteToolStripMenuItem.Text = "Delete Transaction";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // setBudgetLimitToolStripMenuItem
            // 
            this.setBudgetLimitToolStripMenuItem.Name = "setBudgetLimitToolStripMenuItem";
            this.setBudgetLimitToolStripMenuItem.Size = new System.Drawing.Size(240, 26);
            this.setBudgetLimitToolStripMenuItem.Text = "Set Budget Limits...";
            this.setBudgetLimitToolStripMenuItem.Click += new System.EventHandler(this.budgetTopToolStripMenuItem_Click);
            // 
            // toolStripSeparatorTx
            // 
            this.toolStripSeparatorTx.Name = "toolStripSeparatorTx";
            this.toolStripSeparatorTx.Size = new System.Drawing.Size(237, 6);
            // 
            // closeTransactionToolStripMenuItem
            // 
            this.closeTransactionToolStripMenuItem.Name = "closeTransactionToolStripMenuItem";
            this.closeTransactionToolStripMenuItem.Size = new System.Drawing.Size(240, 26);
            this.closeTransactionToolStripMenuItem.Text = "Close View";
            this.closeTransactionToolStripMenuItem.Click += new System.EventHandler(this.closeViewToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                        this.dashboardOverviewToolStripMenuItem,
                        this.showAllToolStripMenuItem,
                        this.showIncomeToolStripMenuItem,
                        this.showExpenseToolStripMenuItem,
                        this.summaryToolStripMenuItem,
                        this.graphToolStripMenuItem,
                        this.toolStripSeparatorView,
                        this.closeViewToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // dashboardOverviewToolStripMenuItem
            // 
            this.dashboardOverviewToolStripMenuItem.Name = "dashboardOverviewToolStripMenuItem";
            this.dashboardOverviewToolStripMenuItem.Size = new System.Drawing.Size(230, 26);
            this.dashboardOverviewToolStripMenuItem.Text = "Dashboard Overview";
            this.dashboardOverviewToolStripMenuItem.Click += new System.EventHandler(this.homeToolStripMenuItem_Click);
            // 
            // showAllToolStripMenuItem
            // 
            this.showAllToolStripMenuItem.Name = "showAllToolStripMenuItem";
            this.showAllToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
            this.showAllToolStripMenuItem.Text = "Show All";
            this.showAllToolStripMenuItem.Click += new System.EventHandler(this.showAllToolStripMenuItem_Click);
            // 
            // showIncomeToolStripMenuItem
            // 
            this.showIncomeToolStripMenuItem.Name = "showIncomeToolStripMenuItem";
            this.showIncomeToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
            this.showIncomeToolStripMenuItem.Text = "Show Income";
            this.showIncomeToolStripMenuItem.Click += new System.EventHandler(this.showIncomeToolStripMenuItem_Click);
            // 
            // showExpenseToolStripMenuItem
            // 
            this.showExpenseToolStripMenuItem.Name = "showExpenseToolStripMenuItem";
            this.showExpenseToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
            this.showExpenseToolStripMenuItem.Text = "Show Expense";
            this.showExpenseToolStripMenuItem.Click += new System.EventHandler(this.showExpenseToolStripMenuItem_Click);
            // 
            // summaryToolStripMenuItem
            // 
            this.summaryToolStripMenuItem.Name = "summaryToolStripMenuItem";
            this.summaryToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
            this.summaryToolStripMenuItem.Text = "Summary";
            this.summaryToolStripMenuItem.Click += new System.EventHandler(this.summaryToolStripMenuItem_Click);
            // 
            // graphToolStripMenuItem
            // 
            this.graphToolStripMenuItem.Name = "graphToolStripMenuItem";
            this.graphToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
            this.graphToolStripMenuItem.Text = "Graph";
            this.graphToolStripMenuItem.Click += new System.EventHandler(this.graphToolStripMenuItem_Click);
            // 
            // toolStripSeparatorView
            // 
            this.toolStripSeparatorView.Name = "toolStripSeparatorView";
            this.toolStripSeparatorView.Size = new System.Drawing.Size(207, 6);
            // 
            // 
            // closeViewToolStripMenuItem
            // 
            this.closeViewToolStripMenuItem.Name = "closeViewToolStripMenuItem";
            this.closeViewToolStripMenuItem.Size = new System.Drawing.Size(230, 26);
            this.closeViewToolStripMenuItem.Text = "Close View";
            this.closeViewToolStripMenuItem.Click += new System.EventHandler(this.closeViewToolStripMenuItem_Click);
            // 
            // budgetTopToolStripMenuItem
            // 
            this.budgetTopToolStripMenuItem.Name = "budgetTopToolStripMenuItem";
            this.budgetTopToolStripMenuItem.Size = new System.Drawing.Size(95, 24);
            this.budgetTopToolStripMenuItem.Text = "🎯 Budgets";
            this.budgetTopToolStripMenuItem.Click += new System.EventHandler(this.budgetTopToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                        this.appearanceSettingsToolStripMenuItem,
                        this.changeFontToolStripMenuItem,
                        this.changeTextColorToolStripMenuItem,
                        this.changeBgColorToolStripMenuItem,
                        this.resetSettingsToolStripMenuItem,
                        this.toolStripSeparatorSettings1,
                        this.profileToolStripMenuItem,
                        this.logoutToolStripMenuItem,
                        this.toolStripSeparatorSettings2,
                        this.closeSettingsToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // appearanceSettingsToolStripMenuItem
            // 
            this.appearanceSettingsToolStripMenuItem.Name = "appearanceSettingsToolStripMenuItem";
            this.appearanceSettingsToolStripMenuItem.Size = new System.Drawing.Size(260, 26);
            this.appearanceSettingsToolStripMenuItem.Text = "Appearance Settings";
            this.appearanceSettingsToolStripMenuItem.Click += new System.EventHandler(this.appearanceSettingsToolStripMenuItem_Click);
            // 
            // changeFontToolStripMenuItem
            // 
            this.changeFontToolStripMenuItem.Name = "changeFontToolStripMenuItem";
            this.changeFontToolStripMenuItem.Size = new System.Drawing.Size(260, 26);
            this.changeFontToolStripMenuItem.Text = "Change Font & Size...";
            this.changeFontToolStripMenuItem.Click += new System.EventHandler(this.changeFontToolStripMenuItem_Click);
            // 
            // changeTextColorToolStripMenuItem
            // 
            this.changeTextColorToolStripMenuItem.Name = "changeTextColorToolStripMenuItem";
            this.changeTextColorToolStripMenuItem.Size = new System.Drawing.Size(260, 26);
            this.changeTextColorToolStripMenuItem.Text = "Change Text Color...";
            this.changeTextColorToolStripMenuItem.Click += new System.EventHandler(this.changeTextColorToolStripMenuItem_Click);
            // 
            // changeBgColorToolStripMenuItem
            // 
            this.changeBgColorToolStripMenuItem.Name = "changeBgColorToolStripMenuItem";
            this.changeBgColorToolStripMenuItem.Size = new System.Drawing.Size(260, 26);
            this.changeBgColorToolStripMenuItem.Text = "Change Background Color...";
            this.changeBgColorToolStripMenuItem.Click += new System.EventHandler(this.changeBgColorToolStripMenuItem_Click);
            // 
            // resetSettingsToolStripMenuItem
            // 
            this.resetSettingsToolStripMenuItem.Name = "resetSettingsToolStripMenuItem";
            this.resetSettingsToolStripMenuItem.Size = new System.Drawing.Size(260, 26);
            this.resetSettingsToolStripMenuItem.Text = "Reset Appearance to Default";
            this.resetSettingsToolStripMenuItem.Click += new System.EventHandler(this.resetSettingsToolStripMenuItem_Click);
            // 
            // toolStripSeparatorSettings1
            // 
            this.toolStripSeparatorSettings1.Name = "toolStripSeparatorSettings1";
            this.toolStripSeparatorSettings1.Size = new System.Drawing.Size(257, 6);
            // 
            // profileToolStripMenuItem
            // 
            this.profileToolStripMenuItem.Name = "profileToolStripMenuItem";
            this.profileToolStripMenuItem.Size = new System.Drawing.Size(260, 26);
            this.profileToolStripMenuItem.Text = "Profile";
            this.profileToolStripMenuItem.Click += new System.EventHandler(this.profileToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(260, 26);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // toolStripSeparatorSettings2
            // 
            this.toolStripSeparatorSettings2.Name = "toolStripSeparatorSettings2";
            this.toolStripSeparatorSettings2.Size = new System.Drawing.Size(257, 6);
            // 
            // closeSettingsToolStripMenuItem
            // 
            this.closeSettingsToolStripMenuItem.Name = "closeSettingsToolStripMenuItem";
            this.closeSettingsToolStripMenuItem.Size = new System.Drawing.Size(260, 26);
            this.closeSettingsToolStripMenuItem.Text = "Close View";
            this.closeSettingsToolStripMenuItem.Click += new System.EventHandler(this.closeViewToolStripMenuItem_Click);
            // 
            // logoutTopToolStripMenuItem
            // 
            this.logoutTopToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.logoutTopToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.logoutTopToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.logoutTopToolStripMenuItem.Name = "logoutTopToolStripMenuItem";
            this.logoutTopToolStripMenuItem.Size = new System.Drawing.Size(90, 24);
            this.logoutTopToolStripMenuItem.Text = "🚪 Logout";
            this.logoutTopToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 28);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(950, 522);
            this.mainPanel.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 550);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MoneyMap - Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorFiles;
        private System.Windows.Forms.ToolStripMenuItem closeFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transactionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setBudgetLimitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorTx;
        private System.Windows.Forms.ToolStripMenuItem closeTransactionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dashboardOverviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showIncomeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showExpenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem summaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorView;
        private System.Windows.Forms.ToolStripMenuItem closeViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem budgetTopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem appearanceSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeFontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeTextColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeBgColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorSettings1;
        private System.Windows.Forms.ToolStripMenuItem profileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorSettings2;
        private System.Windows.Forms.ToolStripMenuItem closeSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutTopToolStripMenuItem;
        private System.Windows.Forms.Panel mainPanel;
    }
}