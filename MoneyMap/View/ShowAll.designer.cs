namespace GP_1
{
    partial class ShowAll
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
            this.topPanel = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.subtitleLabel = new System.Windows.Forms.Label();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.searchLabel = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.filterPanel = new System.Windows.Forms.Panel();
            this.lblFilterTitle = new System.Windows.Forms.Label();
            this.flowCategories = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClearFilter = new System.Windows.Forms.Button();
            this.statsPanel = new System.Windows.Forms.Panel();
            this.cardTotal = new System.Windows.Forms.Panel();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.lblTotalTitle = new System.Windows.Forms.Label();
            this.cardIncome = new System.Windows.Forms.Panel();
            this.lblIncomeSum = new System.Windows.Forms.Label();
            this.lblIncomeTitle = new System.Windows.Forms.Label();
            this.cardExpense = new System.Windows.Forms.Panel();
            this.lblExpenseSum = new System.Windows.Forms.Label();
            this.lblExpenseTitle = new System.Windows.Forms.Label();
            this.cardBalance = new System.Windows.Forms.Panel();
            this.lblBalanceSum = new System.Windows.Forms.Label();
            this.lblBalanceTitle = new System.Windows.Forms.Label();
            this.gridPanel = new System.Windows.Forms.Panel();
            this.dgvTransactions = new System.Windows.Forms.DataGridView();
            this.emptyLabel = new System.Windows.Forms.Label();

            this.topPanel.SuspendLayout();
            this.filterPanel.SuspendLayout();
            this.statsPanel.SuspendLayout();
            this.cardTotal.SuspendLayout();
            this.cardIncome.SuspendLayout();
            this.cardExpense.SuspendLayout();
            this.cardBalance.SuspendLayout();
            this.gridPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).BeginInit();
            this.SuspendLayout();

            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.White;
            this.topPanel.Controls.Add(this.titleLabel);
            this.topPanel.Controls.Add(this.subtitleLabel);
            this.topPanel.Controls.Add(this.btnClose);
            this.topPanel.Controls.Add(this.searchBox);
            this.topPanel.Controls.Add(this.searchLabel);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(24, 20);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(950, 75);
            this.topPanel.TabIndex = 0;

            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(35, 42, 52);
            this.titleLabel.Location = new System.Drawing.Point(0, 8);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(225, 37);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "All Transactions";

            // 
            // subtitleLabel
            // 
            this.subtitleLabel.AutoSize = true;
            this.subtitleLabel.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.subtitleLabel.ForeColor = System.Drawing.Color.FromArgb(110, 118, 130);
            this.subtitleLabel.Location = new System.Drawing.Point(2, 45);
            this.subtitleLabel.Name = "subtitleLabel";
            this.subtitleLabel.Size = new System.Drawing.Size(332, 21);
            this.subtitleLabel.TabIndex = 1;
            this.subtitleLabel.Text = "Comprehensive history of all income and expenses";

            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnClose.Location = new System.Drawing.Point(825, 20);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(125, 36);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "✕ Close View";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // 
            // searchLabel
            // 
            this.searchLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchLabel.AutoSize = true;
            this.searchLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.searchLabel.ForeColor = System.Drawing.Color.FromArgb(110, 118, 130);
            this.searchLabel.Location = new System.Drawing.Point(540, 10);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.Size = new System.Drawing.Size(59, 20);
            this.searchLabel.TabIndex = 2;
            this.searchLabel.Text = "Search:";

            // 
            // searchBox
            // 
            this.searchBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.searchBox.Location = new System.Drawing.Point(540, 34);
            this.searchBox.Name = "searchBox";
            this.searchBox.PlaceholderText = "Search category / note...";
            this.searchBox.Size = new System.Drawing.Size(265, 30);
            this.searchBox.TabIndex = 3;
            this.searchBox.TextChanged += new System.EventHandler(this.SearchBox_TextChanged);

            // 
            // filterPanel
            // 
            this.filterPanel.BackColor = System.Drawing.Color.White;
            this.filterPanel.Controls.Add(this.flowCategories);
            this.filterPanel.Controls.Add(this.btnClearFilter);
            this.filterPanel.Controls.Add(this.lblFilterTitle);
            this.filterPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.filterPanel.Location = new System.Drawing.Point(24, 95);
            this.filterPanel.Name = "filterPanel";
            this.filterPanel.Padding = new System.Windows.Forms.Padding(12, 6, 12, 6);
            this.filterPanel.Size = new System.Drawing.Size(950, 48);
            this.filterPanel.TabIndex = 1;
            // 
            // lblFilterTitle
            // 
            this.lblFilterTitle.AutoSize = true;
            this.lblFilterTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblFilterTitle.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblFilterTitle.Location = new System.Drawing.Point(12, 13);
            this.lblFilterTitle.Name = "lblFilterTitle";
            this.lblFilterTitle.Size = new System.Drawing.Size(115, 21);
            this.lblFilterTitle.TabIndex = 0;
            this.lblFilterTitle.Text = "🏷️ Categories:";
            // 
            // btnClearFilter
            // 
            this.btnClearFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearFilter.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.btnClearFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearFilter.FlatAppearance.BorderSize = 0;
            this.btnClearFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearFilter.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F);
            this.btnClearFilter.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.btnClearFilter.Location = new System.Drawing.Point(845, 9);
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.Size = new System.Drawing.Size(95, 28);
            this.btnClearFilter.TabIndex = 2;
            this.btnClearFilter.Text = "Clear Filters";
            this.btnClearFilter.UseVisualStyleBackColor = false;
            this.btnClearFilter.Click += new System.EventHandler(this.btnClearFilter_Click);
            // 
            // flowCategories
            // 
            this.flowCategories.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowCategories.AutoScroll = true;
            this.flowCategories.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.flowCategories.Location = new System.Drawing.Point(135, 6);
            this.flowCategories.Name = "flowCategories";
            this.flowCategories.Size = new System.Drawing.Size(700, 36);
            this.flowCategories.TabIndex = 1;
            this.flowCategories.WrapContents = true;
            // 
            // statsPanel
            // 
            this.statsPanel.Controls.Add(this.cardTotal);
            this.statsPanel.Controls.Add(this.cardIncome);
            this.statsPanel.Controls.Add(this.cardExpense);
            this.statsPanel.Controls.Add(this.cardBalance);
            this.statsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.statsPanel.Location = new System.Drawing.Point(24, 143);
            this.statsPanel.Name = "statsPanel";
            this.statsPanel.Padding = new System.Windows.Forms.Padding(0, 12, 0, 16);
            this.statsPanel.Size = new System.Drawing.Size(950, 95);
            this.statsPanel.TabIndex = 2;
            this.statsPanel.Resize += new System.EventHandler(this.StatsPanel_Resize);

            // 
            // cardTotal
            // 
            this.cardTotal.BackColor = System.Drawing.Color.White;
            this.cardTotal.Controls.Add(this.lblTotalCount);
            this.cardTotal.Controls.Add(this.lblTotalTitle);
            this.cardTotal.Location = new System.Drawing.Point(0, 12);
            this.cardTotal.Name = "cardTotal";
            this.cardTotal.Size = new System.Drawing.Size(220, 68);
            this.cardTotal.TabIndex = 0;

            // 
            // lblTotalTitle
            // 
            this.lblTotalTitle.AutoSize = true;
            this.lblTotalTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblTotalTitle.ForeColor = System.Drawing.Color.FromArgb(110, 118, 130);
            this.lblTotalTitle.Location = new System.Drawing.Point(14, 10);
            this.lblTotalTitle.Name = "lblTotalTitle";
            this.lblTotalTitle.Size = new System.Drawing.Size(117, 19);
            this.lblTotalTitle.TabIndex = 0;
            this.lblTotalTitle.Text = "TOTAL RECORDS";

            // 
            // lblTotalCount
            // 
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTotalCount.ForeColor = System.Drawing.Color.FromArgb(35, 42, 52);
            this.lblTotalCount.Location = new System.Drawing.Point(12, 28);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(29, 35);
            this.lblTotalCount.TabIndex = 1;
            this.lblTotalCount.Text = "0";

            // 
            // cardIncome
            // 
            this.cardIncome.BackColor = System.Drawing.Color.White;
            this.cardIncome.Controls.Add(this.lblIncomeSum);
            this.cardIncome.Controls.Add(this.lblIncomeTitle);
            this.cardIncome.Location = new System.Drawing.Point(235, 12);
            this.cardIncome.Name = "cardIncome";
            this.cardIncome.Size = new System.Drawing.Size(220, 68);
            this.cardIncome.TabIndex = 1;

            // 
            // lblIncomeTitle
            // 
            this.lblIncomeTitle.AutoSize = true;
            this.lblIncomeTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblIncomeTitle.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.lblIncomeTitle.Location = new System.Drawing.Point(14, 10);
            this.lblIncomeTitle.Name = "lblIncomeTitle";
            this.lblIncomeTitle.Size = new System.Drawing.Size(106, 19);
            this.lblIncomeTitle.TabIndex = 0;
            this.lblIncomeTitle.Text = "TOTAL INCOME";

            // 
            // lblIncomeSum
            // 
            this.lblIncomeSum.AutoSize = true;
            this.lblIncomeSum.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblIncomeSum.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.lblIncomeSum.Location = new System.Drawing.Point(12, 28);
            this.lblIncomeSum.Name = "lblIncomeSum";
            this.lblIncomeSum.Size = new System.Drawing.Size(78, 35);
            this.lblIncomeSum.TabIndex = 1;
            this.lblIncomeSum.Text = "₹0.00";

            // 
            // cardExpense
            // 
            this.cardExpense.BackColor = System.Drawing.Color.White;
            this.cardExpense.Controls.Add(this.lblExpenseSum);
            this.cardExpense.Controls.Add(this.lblExpenseTitle);
            this.cardExpense.Location = new System.Drawing.Point(470, 12);
            this.cardExpense.Name = "cardExpense";
            this.cardExpense.Size = new System.Drawing.Size(220, 68);
            this.cardExpense.TabIndex = 2;

            // 
            // lblExpenseTitle
            // 
            this.lblExpenseTitle.AutoSize = true;
            this.lblExpenseTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblExpenseTitle.ForeColor = System.Drawing.Color.FromArgb(235, 87, 87);
            this.lblExpenseTitle.Location = new System.Drawing.Point(14, 10);
            this.lblExpenseTitle.Name = "lblExpenseTitle";
            this.lblExpenseTitle.Size = new System.Drawing.Size(117, 19);
            this.lblExpenseTitle.TabIndex = 0;
            this.lblExpenseTitle.Text = "TOTAL EXPENSES";

            // 
            // lblExpenseSum
            // 
            this.lblExpenseSum.AutoSize = true;
            this.lblExpenseSum.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblExpenseSum.ForeColor = System.Drawing.Color.FromArgb(235, 87, 87);
            this.lblExpenseSum.Location = new System.Drawing.Point(12, 28);
            this.lblExpenseSum.Name = "lblExpenseSum";
            this.lblExpenseSum.Size = new System.Drawing.Size(78, 35);
            this.lblExpenseSum.TabIndex = 1;
            this.lblExpenseSum.Text = "₹0.00";

            // 
            // cardBalance
            // 
            this.cardBalance.BackColor = System.Drawing.Color.White;
            this.cardBalance.Controls.Add(this.lblBalanceSum);
            this.cardBalance.Controls.Add(this.lblBalanceTitle);
            this.cardBalance.Location = new System.Drawing.Point(705, 12);
            this.cardBalance.Name = "cardBalance";
            this.cardBalance.Size = new System.Drawing.Size(220, 68);
            this.cardBalance.TabIndex = 3;

            // 
            // lblBalanceTitle
            // 
            this.lblBalanceTitle.AutoSize = true;
            this.lblBalanceTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblBalanceTitle.ForeColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.lblBalanceTitle.Location = new System.Drawing.Point(14, 10);
            this.lblBalanceTitle.Name = "lblBalanceTitle";
            this.lblBalanceTitle.Size = new System.Drawing.Size(102, 19);
            this.lblBalanceTitle.TabIndex = 0;
            this.lblBalanceTitle.Text = "NET BALANCE";

            // 
            // lblBalanceSum
            // 
            this.lblBalanceSum.AutoSize = true;
            this.lblBalanceSum.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblBalanceSum.ForeColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.lblBalanceSum.Location = new System.Drawing.Point(12, 28);
            this.lblBalanceSum.Name = "lblBalanceSum";
            this.lblBalanceSum.Size = new System.Drawing.Size(78, 35);
            this.lblBalanceSum.TabIndex = 1;
            this.lblBalanceSum.Text = "₹0.00";

            // 
            // gridPanel
            // 
            this.gridPanel.BackColor = System.Drawing.Color.White;
            this.gridPanel.Controls.Add(this.emptyLabel);
            this.gridPanel.Controls.Add(this.dgvTransactions);
            this.gridPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPanel.Location = new System.Drawing.Point(24, 190);
            this.gridPanel.Name = "gridPanel";
            this.gridPanel.Padding = new System.Windows.Forms.Padding(1);
            this.gridPanel.Size = new System.Drawing.Size(950, 410);
            this.gridPanel.TabIndex = 2;

            // 
            // dgvTransactions
            // 
            this.dgvTransactions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTransactions.Location = new System.Drawing.Point(1, 1);
            this.dgvTransactions.Name = "dgvTransactions";
            this.dgvTransactions.RowHeadersWidth = 51;
            this.dgvTransactions.Size = new System.Drawing.Size(948, 408);
            this.dgvTransactions.TabIndex = 0;

            // 
            // emptyLabel
            // 
            this.emptyLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.emptyLabel.AutoSize = true;
            this.emptyLabel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.emptyLabel.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.emptyLabel.Location = new System.Drawing.Point(375, 180);
            this.emptyLabel.Name = "emptyLabel";
            this.emptyLabel.Size = new System.Drawing.Size(200, 25);
            this.emptyLabel.TabIndex = 1;
            this.emptyLabel.Text = "No transactions found.";
            this.emptyLabel.Visible = false;

            // 
            // ShowAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(248, 249, 251);
            this.ClientSize = new System.Drawing.Size(998, 620);
            this.Controls.Add(this.gridPanel);
            this.Controls.Add(this.statsPanel);
            this.Controls.Add(this.filterPanel);
            this.Controls.Add(this.topPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "ShowAll";
            this.Padding = new System.Windows.Forms.Padding(24, 20, 24, 20);
            this.Text = "All Transactions";
            this.Load += new System.EventHandler(this.ShowAll_Load);

            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.filterPanel.ResumeLayout(false);
            this.filterPanel.PerformLayout();
            this.statsPanel.ResumeLayout(false);
            this.cardTotal.ResumeLayout(false);
            this.cardTotal.PerformLayout();
            this.cardIncome.ResumeLayout(false);
            this.cardIncome.PerformLayout();
            this.cardExpense.ResumeLayout(false);
            this.cardExpense.PerformLayout();
            this.cardBalance.ResumeLayout(false);
            this.cardBalance.PerformLayout();
            this.gridPanel.ResumeLayout(false);
            this.gridPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label subtitleLabel;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Label searchLabel;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel filterPanel;
        private System.Windows.Forms.Label lblFilterTitle;
        private System.Windows.Forms.FlowLayoutPanel flowCategories;
        private System.Windows.Forms.Button btnClearFilter;
        private System.Windows.Forms.Panel statsPanel;
        private System.Windows.Forms.Panel cardTotal;
        private System.Windows.Forms.Label lblTotalTitle;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.Panel cardIncome;
        private System.Windows.Forms.Label lblIncomeTitle;
        private System.Windows.Forms.Label lblIncomeSum;
        private System.Windows.Forms.Panel cardExpense;
        private System.Windows.Forms.Label lblExpenseTitle;
        private System.Windows.Forms.Label lblExpenseSum;
        private System.Windows.Forms.Panel cardBalance;
        private System.Windows.Forms.Label lblBalanceTitle;
        private System.Windows.Forms.Label lblBalanceSum;
        private System.Windows.Forms.Panel gridPanel;
        private System.Windows.Forms.DataGridView dgvTransactions;
        private System.Windows.Forms.Label emptyLabel;
    }
}
