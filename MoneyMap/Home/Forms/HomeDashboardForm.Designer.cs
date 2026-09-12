namespace MoneyMap.Home.Forms
{
    partial class HomeDashboardForm
    {
        private System.ComponentModel.IContainer components = null;

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
            this.headerPanel = new System.Windows.Forms.Panel();
            this.lblGreeting = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.btnAddTransaction = new System.Windows.Forms.Button();
            this.btnSetBudget = new System.Windows.Forms.Button();
            this.pnlAlertBanner = new System.Windows.Forms.Panel();
            this.lblAlertIcon = new System.Windows.Forms.Label();
            this.lblAlertText = new System.Windows.Forms.Label();
            this.btnDismissAlert = new System.Windows.Forms.Button();
            this.statsPanel = new System.Windows.Forms.Panel();
            this.cardBalance = new System.Windows.Forms.Panel();
            this.lblBalanceValue = new System.Windows.Forms.Label();
            this.lblBalanceTitle = new System.Windows.Forms.Label();
            this.cardIncome = new System.Windows.Forms.Panel();
            this.lblIncomeValue = new System.Windows.Forms.Label();
            this.lblIncomeTitle = new System.Windows.Forms.Label();
            this.cardExpense = new System.Windows.Forms.Panel();
            this.lblExpenseValue = new System.Windows.Forms.Label();
            this.lblExpenseTitle = new System.Windows.Forms.Label();
            this.cardBudget = new System.Windows.Forms.Panel();
            this.lblBudgetValue = new System.Windows.Forms.Label();
            this.lblBudgetTitle = new System.Windows.Forms.Label();
            this.bodyTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.budgetCard = new System.Windows.Forms.Panel();
            this.lblBudgetCardTitle = new System.Windows.Forms.Label();
            this.lblBudgetCardSubtitle = new System.Windows.Forms.Label();
            this.pnlOverallProgress = new System.Windows.Forms.Panel();
            this.lblOverallProgressText = new System.Windows.Forms.Label();
            this.flowCategoryBudgets = new System.Windows.Forms.FlowLayoutPanel();
            this.btnEditBudgets = new System.Windows.Forms.Button();
            this.recentCard = new System.Windows.Forms.Panel();
            this.lblRecentTitle = new System.Windows.Forms.Label();
            this.lblRecentSubtitle = new System.Windows.Forms.Label();
            this.btnViewAll = new System.Windows.Forms.Button();
            this.dgvRecentTransactions = new System.Windows.Forms.DataGridView();
            this.mainScrollPanel = new System.Windows.Forms.Panel();
            this.headerPanel.SuspendLayout();
            this.pnlAlertBanner.SuspendLayout();
            this.statsPanel.SuspendLayout();
            this.cardBalance.SuspendLayout();
            this.cardIncome.SuspendLayout();
            this.cardExpense.SuspendLayout();
            this.cardBudget.SuspendLayout();
            this.bodyTableLayout.SuspendLayout();
            this.budgetCard.SuspendLayout();
            this.recentCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentTransactions)).BeginInit();
            this.mainScrollPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.White;
            this.headerPanel.Controls.Add(this.btnSetBudget);
            this.headerPanel.Controls.Add(this.btnAddTransaction);
            this.headerPanel.Controls.Add(this.lblSubtitle);
            this.headerPanel.Controls.Add(this.lblGreeting);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(24, 16);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.headerPanel.Size = new System.Drawing.Size(950, 75);
            this.headerPanel.TabIndex = 0;
            // 
            // lblGreeting
            // 
            this.lblGreeting.AutoSize = true;
            this.lblGreeting.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblGreeting.ForeColor = System.Drawing.Color.FromArgb(24, 31, 42);
            this.lblGreeting.Location = new System.Drawing.Point(12, 10);
            this.lblGreeting.Name = "lblGreeting";
            this.lblGreeting.Size = new System.Drawing.Size(248, 30);
            this.lblGreeting.TabIndex = 0;
            this.lblGreeting.Text = "Welcome to MoneyMap";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblSubtitle.Location = new System.Drawing.Point(14, 44);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(325, 15);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Financial dashboard, spending analytics & monthly budget limits";
            // 
            // btnAddTransaction
            // 
            this.btnAddTransaction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddTransaction.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnAddTransaction.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddTransaction.FlatAppearance.BorderSize = 0;
            this.btnAddTransaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTransaction.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnAddTransaction.ForeColor = System.Drawing.Color.White;
            this.btnAddTransaction.Location = new System.Drawing.Point(780, 18);
            this.btnAddTransaction.Name = "btnAddTransaction";
            this.btnAddTransaction.Size = new System.Drawing.Size(155, 36);
            this.btnAddTransaction.TabIndex = 2;
            this.btnAddTransaction.Text = "➕ New Transaction";
            this.btnAddTransaction.UseVisualStyleBackColor = false;
            this.btnAddTransaction.Click += new System.EventHandler(this.btnAddTransaction_Click);
            // 
            // btnSetBudget
            // 
            this.btnSetBudget.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetBudget.BackColor = System.Drawing.Color.FromArgb(243, 244, 246);
            this.btnSetBudget.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSetBudget.FlatAppearance.BorderSize = 0;
            this.btnSetBudget.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetBudget.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSetBudget.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.btnSetBudget.Location = new System.Drawing.Point(620, 18);
            this.btnSetBudget.Name = "btnSetBudget";
            this.btnSetBudget.Size = new System.Drawing.Size(150, 36);
            this.btnSetBudget.TabIndex = 3;
            this.btnSetBudget.Text = "🎯 Set Budgets";
            this.btnSetBudget.UseVisualStyleBackColor = false;
            this.btnSetBudget.Click += new System.EventHandler(this.btnSetBudget_Click);
            // 
            // pnlAlertBanner
            // 
            this.pnlAlertBanner.BackColor = System.Drawing.Color.FromArgb(254, 242, 242);
            this.pnlAlertBanner.Controls.Add(this.btnDismissAlert);
            this.pnlAlertBanner.Controls.Add(this.lblAlertText);
            this.pnlAlertBanner.Controls.Add(this.lblAlertIcon);
            this.pnlAlertBanner.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAlertBanner.Location = new System.Drawing.Point(24, 91);
            this.pnlAlertBanner.Name = "pnlAlertBanner";
            this.pnlAlertBanner.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.pnlAlertBanner.Size = new System.Drawing.Size(950, 44);
            this.pnlAlertBanner.TabIndex = 1;
            this.pnlAlertBanner.Visible = false;
            // 
            // lblAlertIcon
            // 
            this.lblAlertIcon.AutoSize = true;
            this.lblAlertIcon.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblAlertIcon.Location = new System.Drawing.Point(12, 10);
            this.lblAlertIcon.Name = "lblAlertIcon";
            this.lblAlertIcon.Size = new System.Drawing.Size(28, 21);
            this.lblAlertIcon.TabIndex = 0;
            this.lblAlertIcon.Text = "⚠️";
            // 
            // lblAlertText
            // 
            this.lblAlertText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAlertText.AutoEllipsis = true;
            this.lblAlertText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblAlertText.ForeColor = System.Drawing.Color.FromArgb(185, 28, 28);
            this.lblAlertText.Location = new System.Drawing.Point(44, 12);
            this.lblAlertText.Name = "lblAlertText";
            this.lblAlertText.Size = new System.Drawing.Size(860, 20);
            this.lblAlertText.TabIndex = 1;
            this.lblAlertText.Text = "Budget Alert Notification";
            // 
            // btnDismissAlert
            // 
            this.btnDismissAlert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDismissAlert.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDismissAlert.FlatAppearance.BorderSize = 0;
            this.btnDismissAlert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDismissAlert.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDismissAlert.ForeColor = System.Drawing.Color.FromArgb(185, 28, 28);
            this.btnDismissAlert.Location = new System.Drawing.Point(915, 8);
            this.btnDismissAlert.Name = "btnDismissAlert";
            this.btnDismissAlert.Size = new System.Drawing.Size(24, 24);
            this.btnDismissAlert.TabIndex = 2;
            this.btnDismissAlert.Text = "✕";
            this.btnDismissAlert.UseVisualStyleBackColor = true;
            this.btnDismissAlert.Click += new System.EventHandler(this.btnDismissAlert_Click);
            // 
            // statsPanel
            // 
            this.statsPanel.Controls.Add(this.cardBudget);
            this.statsPanel.Controls.Add(this.cardExpense);
            this.statsPanel.Controls.Add(this.cardIncome);
            this.statsPanel.Controls.Add(this.cardBalance);
            this.statsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.statsPanel.Location = new System.Drawing.Point(24, 135);
            this.statsPanel.Name = "statsPanel";
            this.statsPanel.Padding = new System.Windows.Forms.Padding(0, 10, 0, 14);
            this.statsPanel.Size = new System.Drawing.Size(950, 92);
            this.statsPanel.TabIndex = 2;
            this.statsPanel.Resize += new System.EventHandler(this.StatsPanel_Resize);
            // 
            // cardBalance
            // 
            this.cardBalance.BackColor = System.Drawing.Color.White;
            this.cardBalance.Controls.Add(this.lblBalanceValue);
            this.cardBalance.Controls.Add(this.lblBalanceTitle);
            this.cardBalance.Location = new System.Drawing.Point(0, 10);
            this.cardBalance.Name = "cardBalance";
            this.cardBalance.Size = new System.Drawing.Size(220, 68);
            this.cardBalance.TabIndex = 0;
            // 
            // lblBalanceTitle
            // 
            this.lblBalanceTitle.AutoSize = true;
            this.lblBalanceTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.lblBalanceTitle.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblBalanceTitle.Location = new System.Drawing.Point(14, 10);
            this.lblBalanceTitle.Name = "lblBalanceTitle";
            this.lblBalanceTitle.Size = new System.Drawing.Size(89, 13);
            this.lblBalanceTitle.TabIndex = 0;
            this.lblBalanceTitle.Text = "TOTAL BALANCE";
            // 
            // lblBalanceValue
            // 
            this.lblBalanceValue.AutoSize = true;
            this.lblBalanceValue.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            this.lblBalanceValue.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.lblBalanceValue.Location = new System.Drawing.Point(12, 28);
            this.lblBalanceValue.Name = "lblBalanceValue";
            this.lblBalanceValue.Size = new System.Drawing.Size(61, 25);
            this.lblBalanceValue.TabIndex = 1;
            this.lblBalanceValue.Text = "₹0.00";
            // 
            // cardIncome
            // 
            this.cardIncome.BackColor = System.Drawing.Color.White;
            this.cardIncome.Controls.Add(this.lblIncomeValue);
            this.cardIncome.Controls.Add(this.lblIncomeTitle);
            this.cardIncome.Location = new System.Drawing.Point(235, 10);
            this.cardIncome.Name = "cardIncome";
            this.cardIncome.Size = new System.Drawing.Size(220, 68);
            this.cardIncome.TabIndex = 1;
            // 
            // lblIncomeTitle
            // 
            this.lblIncomeTitle.AutoSize = true;
            this.lblIncomeTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.lblIncomeTitle.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblIncomeTitle.Location = new System.Drawing.Point(14, 10);
            this.lblIncomeTitle.Name = "lblIncomeTitle";
            this.lblIncomeTitle.Size = new System.Drawing.Size(120, 13);
            this.lblIncomeTitle.TabIndex = 0;
            this.lblIncomeTitle.Text = "THIS MONTH INCOME";
            // 
            // lblIncomeValue
            // 
            this.lblIncomeValue.AutoSize = true;
            this.lblIncomeValue.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            this.lblIncomeValue.ForeColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.lblIncomeValue.Location = new System.Drawing.Point(12, 28);
            this.lblIncomeValue.Name = "lblIncomeValue";
            this.lblIncomeValue.Size = new System.Drawing.Size(73, 25);
            this.lblIncomeValue.TabIndex = 1;
            this.lblIncomeValue.Text = "+₹0.00";
            // 
            // cardExpense
            // 
            this.cardExpense.BackColor = System.Drawing.Color.White;
            this.cardExpense.Controls.Add(this.lblExpenseValue);
            this.cardExpense.Controls.Add(this.lblExpenseTitle);
            this.cardExpense.Location = new System.Drawing.Point(470, 10);
            this.cardExpense.Name = "cardExpense";
            this.cardExpense.Size = new System.Drawing.Size(220, 68);
            this.cardExpense.TabIndex = 2;
            // 
            // lblExpenseTitle
            // 
            this.lblExpenseTitle.AutoSize = true;
            this.lblExpenseTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.lblExpenseTitle.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblExpenseTitle.Location = new System.Drawing.Point(14, 10);
            this.lblExpenseTitle.Name = "lblExpenseTitle";
            this.lblExpenseTitle.Size = new System.Drawing.Size(111, 13);
            this.lblExpenseTitle.TabIndex = 0;
            this.lblExpenseTitle.Text = "THIS MONTH SPENT";
            // 
            // lblExpenseValue
            // 
            this.lblExpenseValue.AutoSize = true;
            this.lblExpenseValue.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            this.lblExpenseValue.ForeColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.lblExpenseValue.Location = new System.Drawing.Point(12, 28);
            this.lblExpenseValue.Name = "lblExpenseValue";
            this.lblExpenseValue.Size = new System.Drawing.Size(68, 25);
            this.lblExpenseValue.TabIndex = 1;
            this.lblExpenseValue.Text = "-₹0.00";
            // 
            // cardBudget
            // 
            this.cardBudget.BackColor = System.Drawing.Color.White;
            this.cardBudget.Controls.Add(this.lblBudgetValue);
            this.cardBudget.Controls.Add(this.lblBudgetTitle);
            this.cardBudget.Location = new System.Drawing.Point(705, 10);
            this.cardBudget.Name = "cardBudget";
            this.cardBudget.Size = new System.Drawing.Size(245, 68);
            this.cardBudget.TabIndex = 3;
            // 
            // lblBudgetTitle
            // 
            this.lblBudgetTitle.AutoSize = true;
            this.lblBudgetTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.lblBudgetTitle.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblBudgetTitle.Location = new System.Drawing.Point(14, 10);
            this.lblBudgetTitle.Name = "lblBudgetTitle";
            this.lblBudgetTitle.Size = new System.Drawing.Size(102, 13);
            this.lblBudgetTitle.TabIndex = 0;
            this.lblBudgetTitle.Text = "MONTHLY BUDGET";
            // 
            // lblBudgetValue
            // 
            this.lblBudgetValue.AutoSize = true;
            this.lblBudgetValue.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            this.lblBudgetValue.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.lblBudgetValue.Location = new System.Drawing.Point(12, 28);
            this.lblBudgetValue.Name = "lblBudgetValue";
            this.lblBudgetValue.Size = new System.Drawing.Size(117, 25);
            this.lblBudgetValue.TabIndex = 1;
            this.lblBudgetValue.Text = "No Limit Set";
            // 
            // bodyTableLayout
            // 
            this.bodyTableLayout.ColumnCount = 2;
            this.bodyTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48F));
            this.bodyTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52F));
            this.bodyTableLayout.Controls.Add(this.budgetCard, 0, 0);
            this.bodyTableLayout.Controls.Add(this.recentCard, 1, 0);
            this.bodyTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bodyTableLayout.Location = new System.Drawing.Point(24, 227);
            this.bodyTableLayout.Name = "bodyTableLayout";
            this.bodyTableLayout.RowCount = 1;
            this.bodyTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.bodyTableLayout.Size = new System.Drawing.Size(950, 373);
            this.bodyTableLayout.TabIndex = 3;
            // 
            // budgetCard
            // 
            this.budgetCard.BackColor = System.Drawing.Color.White;
            this.budgetCard.Controls.Add(this.btnEditBudgets);
            this.budgetCard.Controls.Add(this.flowCategoryBudgets);
            this.budgetCard.Controls.Add(this.pnlOverallProgress);
            this.budgetCard.Controls.Add(this.lblOverallProgressText);
            this.budgetCard.Controls.Add(this.lblBudgetCardSubtitle);
            this.budgetCard.Controls.Add(this.lblBudgetCardTitle);
            this.budgetCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.budgetCard.Location = new System.Drawing.Point(3, 3);
            this.budgetCard.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.budgetCard.Name = "budgetCard";
            this.budgetCard.Padding = new System.Windows.Forms.Padding(16);
            this.budgetCard.Size = new System.Drawing.Size(443, 367);
            this.budgetCard.TabIndex = 0;
            // 
            // lblBudgetCardTitle
            // 
            this.lblBudgetCardTitle.AutoSize = true;
            this.lblBudgetCardTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblBudgetCardTitle.ForeColor = System.Drawing.Color.FromArgb(24, 31, 42);
            this.lblBudgetCardTitle.Location = new System.Drawing.Point(14, 14);
            this.lblBudgetCardTitle.Name = "lblBudgetCardTitle";
            this.lblBudgetCardTitle.Size = new System.Drawing.Size(202, 21);
            this.lblBudgetCardTitle.TabIndex = 0;
            this.lblBudgetCardTitle.Text = "🎯 Monthly Budget Limit";
            // 
            // lblBudgetCardSubtitle
            // 
            this.lblBudgetCardSubtitle.AutoSize = true;
            this.lblBudgetCardSubtitle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblBudgetCardSubtitle.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblBudgetCardSubtitle.Location = new System.Drawing.Point(16, 38);
            this.lblBudgetCardSubtitle.Name = "lblBudgetCardSubtitle";
            this.lblBudgetCardSubtitle.Size = new System.Drawing.Size(268, 15);
            this.lblBudgetCardSubtitle.TabIndex = 1;
            this.lblBudgetCardSubtitle.Text = "Live tracking of monthly overall & category limits";
            // 
            // lblOverallProgressText
            // 
            this.lblOverallProgressText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOverallProgressText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblOverallProgressText.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblOverallProgressText.Location = new System.Drawing.Point(16, 62);
            this.lblOverallProgressText.Name = "lblOverallProgressText";
            this.lblOverallProgressText.Size = new System.Drawing.Size(410, 18);
            this.lblOverallProgressText.TabIndex = 2;
            this.lblOverallProgressText.Text = "Overall Spent: ₹0.00 / Limit: ₹0.00 (0%)";
            // 
            // pnlOverallProgress
            // 
            this.pnlOverallProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlOverallProgress.BackColor = System.Drawing.Color.FromArgb(243, 244, 246);
            this.pnlOverallProgress.Location = new System.Drawing.Point(18, 83);
            this.pnlOverallProgress.Name = "pnlOverallProgress";
            this.pnlOverallProgress.Size = new System.Drawing.Size(408, 14);
            this.pnlOverallProgress.TabIndex = 3;
            // 
            // flowCategoryBudgets
            // 
            this.flowCategoryBudgets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowCategoryBudgets.AutoScroll = true;
            this.flowCategoryBudgets.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowCategoryBudgets.Location = new System.Drawing.Point(18, 108);
            this.flowCategoryBudgets.Name = "flowCategoryBudgets";
            this.flowCategoryBudgets.Size = new System.Drawing.Size(408, 205);
            this.flowCategoryBudgets.TabIndex = 4;
            this.flowCategoryBudgets.WrapContents = false;
            // 
            // btnEditBudgets
            // 
            this.btnEditBudgets.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditBudgets.BackColor = System.Drawing.Color.FromArgb(243, 244, 246);
            this.btnEditBudgets.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditBudgets.FlatAppearance.BorderSize = 0;
            this.btnEditBudgets.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditBudgets.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnEditBudgets.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnEditBudgets.Location = new System.Drawing.Point(18, 323);
            this.btnEditBudgets.Name = "btnEditBudgets";
            this.btnEditBudgets.Size = new System.Drawing.Size(408, 32);
            this.btnEditBudgets.TabIndex = 5;
            this.btnEditBudgets.Text = "⚙️ Configure Budget Limits";
            this.btnEditBudgets.UseVisualStyleBackColor = false;
            this.btnEditBudgets.Click += new System.EventHandler(this.btnSetBudget_Click);
            // 
            // recentCard
            // 
            this.recentCard.BackColor = System.Drawing.Color.White;
            this.recentCard.Controls.Add(this.dgvRecentTransactions);
            this.recentCard.Controls.Add(this.btnViewAll);
            this.recentCard.Controls.Add(this.lblRecentSubtitle);
            this.recentCard.Controls.Add(this.lblRecentTitle);
            this.recentCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recentCard.Location = new System.Drawing.Point(459, 3);
            this.recentCard.Name = "recentCard";
            this.recentCard.Padding = new System.Windows.Forms.Padding(16);
            this.recentCard.Size = new System.Drawing.Size(488, 367);
            this.recentCard.TabIndex = 1;
            // 
            // lblRecentTitle
            // 
            this.lblRecentTitle.AutoSize = true;
            this.lblRecentTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblRecentTitle.ForeColor = System.Drawing.Color.FromArgb(24, 31, 42);
            this.lblRecentTitle.Location = new System.Drawing.Point(14, 14);
            this.lblRecentTitle.Name = "lblRecentTitle";
            this.lblRecentTitle.Size = new System.Drawing.Size(188, 21);
            this.lblRecentTitle.TabIndex = 0;
            this.lblRecentTitle.Text = "🕒 Recent Transactions";
            // 
            // lblRecentSubtitle
            // 
            this.lblRecentSubtitle.AutoSize = true;
            this.lblRecentSubtitle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblRecentSubtitle.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblRecentSubtitle.Location = new System.Drawing.Point(16, 38);
            this.lblRecentSubtitle.Name = "lblRecentSubtitle";
            this.lblRecentSubtitle.Size = new System.Drawing.Size(176, 15);
            this.lblRecentSubtitle.TabIndex = 1;
            this.lblRecentSubtitle.Text = "Your latest recorded operations";
            // 
            // btnViewAll
            // 
            this.btnViewAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewAll.FlatAppearance.BorderSize = 0;
            this.btnViewAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewAll.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnViewAll.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnViewAll.Location = new System.Drawing.Point(375, 14);
            this.btnViewAll.Name = "btnViewAll";
            this.btnViewAll.Size = new System.Drawing.Size(95, 26);
            this.btnViewAll.TabIndex = 2;
            this.btnViewAll.Text = "View All ➔";
            this.btnViewAll.UseVisualStyleBackColor = true;
            this.btnViewAll.Click += new System.EventHandler(this.btnViewAll_Click);
            // 
            // dgvRecentTransactions
            // 
            this.dgvRecentTransactions.AllowUserToAddRows = false;
            this.dgvRecentTransactions.AllowUserToDeleteRows = false;
            this.dgvRecentTransactions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRecentTransactions.BackgroundColor = System.Drawing.Color.White;
            this.dgvRecentTransactions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRecentTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecentTransactions.Location = new System.Drawing.Point(16, 65);
            this.dgvRecentTransactions.Name = "dgvRecentTransactions";
            this.dgvRecentTransactions.RowHeadersVisible = false;
            this.dgvRecentTransactions.RowTemplate.Height = 34;
            this.dgvRecentTransactions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecentTransactions.Size = new System.Drawing.Size(456, 290);
            this.dgvRecentTransactions.TabIndex = 3;
            // 
            // mainScrollPanel
            // 
            this.mainScrollPanel.AutoScroll = true;
            this.mainScrollPanel.Controls.Add(this.bodyTableLayout);
            this.mainScrollPanel.Controls.Add(this.statsPanel);
            this.mainScrollPanel.Controls.Add(this.pnlAlertBanner);
            this.mainScrollPanel.Controls.Add(this.headerPanel);
            this.mainScrollPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainScrollPanel.Location = new System.Drawing.Point(0, 0);
            this.mainScrollPanel.Name = "mainScrollPanel";
            this.mainScrollPanel.Padding = new System.Windows.Forms.Padding(24, 16, 24, 16);
            this.mainScrollPanel.Size = new System.Drawing.Size(998, 620);
            this.mainScrollPanel.TabIndex = 0;
            // 
            // HomeDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(248, 249, 251);
            this.ClientSize = new System.Drawing.Size(998, 620);
            this.Controls.Add(this.mainScrollPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HomeDashboardForm";
            this.Text = "Home Dashboard";
            this.Load += new System.EventHandler(this.HomeDashboardForm_Load);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.pnlAlertBanner.ResumeLayout(false);
            this.pnlAlertBanner.PerformLayout();
            this.statsPanel.ResumeLayout(false);
            this.cardBalance.ResumeLayout(false);
            this.cardBalance.PerformLayout();
            this.cardIncome.ResumeLayout(false);
            this.cardIncome.PerformLayout();
            this.cardExpense.ResumeLayout(false);
            this.cardExpense.PerformLayout();
            this.cardBudget.ResumeLayout(false);
            this.cardBudget.PerformLayout();
            this.bodyTableLayout.ResumeLayout(false);
            this.budgetCard.ResumeLayout(false);
            this.budgetCard.PerformLayout();
            this.recentCard.ResumeLayout(false);
            this.recentCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentTransactions)).EndInit();
            this.mainScrollPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblGreeting;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Button btnAddTransaction;
        private System.Windows.Forms.Button btnSetBudget;
        private System.Windows.Forms.Panel pnlAlertBanner;
        private System.Windows.Forms.Label lblAlertIcon;
        private System.Windows.Forms.Label lblAlertText;
        private System.Windows.Forms.Button btnDismissAlert;
        private System.Windows.Forms.Panel statsPanel;
        private System.Windows.Forms.Panel cardBalance;
        private System.Windows.Forms.Label lblBalanceTitle;
        private System.Windows.Forms.Label lblBalanceValue;
        private System.Windows.Forms.Panel cardIncome;
        private System.Windows.Forms.Label lblIncomeTitle;
        private System.Windows.Forms.Label lblIncomeValue;
        private System.Windows.Forms.Panel cardExpense;
        private System.Windows.Forms.Label lblExpenseTitle;
        private System.Windows.Forms.Label lblExpenseValue;
        private System.Windows.Forms.Panel cardBudget;
        private System.Windows.Forms.Label lblBudgetTitle;
        private System.Windows.Forms.Label lblBudgetValue;
        private System.Windows.Forms.TableLayoutPanel bodyTableLayout;
        private System.Windows.Forms.Panel budgetCard;
        private System.Windows.Forms.Label lblBudgetCardTitle;
        private System.Windows.Forms.Label lblBudgetCardSubtitle;
        private System.Windows.Forms.Label lblOverallProgressText;
        private System.Windows.Forms.Panel pnlOverallProgress;
        private System.Windows.Forms.FlowLayoutPanel flowCategoryBudgets;
        private System.Windows.Forms.Button btnEditBudgets;
        private System.Windows.Forms.Panel recentCard;
        private System.Windows.Forms.Label lblRecentTitle;
        private System.Windows.Forms.Label lblRecentSubtitle;
        private System.Windows.Forms.Button btnViewAll;
        private System.Windows.Forms.DataGridView dgvRecentTransactions;
        private System.Windows.Forms.Panel mainScrollPanel;
    }
}
