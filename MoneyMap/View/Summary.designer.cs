namespace GP_1
{
    partial class Summary
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
            this.btnClose = new System.Windows.Forms.Button();
            this.pickerPanel = new System.Windows.Forms.Panel();
            this.lblSelectMonth = new System.Windows.Forms.Label();
            this.monthPicker = new System.Windows.Forms.DateTimePicker();
            this.cardsPanel = new System.Windows.Forms.Panel();
            this.cardIncome = new System.Windows.Forms.Panel();
            this.lblIncomeIcon = new System.Windows.Forms.Label();
            this.lblIncomeTitle = new System.Windows.Forms.Label();
            this.lblIncomeVal = new System.Windows.Forms.Label();
            this.lblIncomeSub = new System.Windows.Forms.Label();
            this.cardExpense = new System.Windows.Forms.Panel();
            this.lblExpenseIcon = new System.Windows.Forms.Label();
            this.lblExpenseTitle = new System.Windows.Forms.Label();
            this.lblExpenseVal = new System.Windows.Forms.Label();
            this.lblExpenseSub = new System.Windows.Forms.Label();
            this.cardBalance = new System.Windows.Forms.Panel();
            this.lblBalanceIcon = new System.Windows.Forms.Label();
            this.lblBalanceTitle = new System.Windows.Forms.Label();
            this.lblBalanceVal = new System.Windows.Forms.Label();
            this.lblBalanceSub = new System.Windows.Forms.Label();
            this.analyticsCard = new System.Windows.Forms.Panel();
            this.lblAnalyticsTitle = new System.Windows.Forms.Label();
            this.lblAnalyticsSub = new System.Windows.Forms.Label();
            this.healthBadge = new System.Windows.Forms.Label();
            this.progressCanvas = new System.Windows.Forms.PictureBox();

            this.topPanel.SuspendLayout();
            this.pickerPanel.SuspendLayout();
            this.cardsPanel.SuspendLayout();
            this.cardIncome.SuspendLayout();
            this.cardExpense.SuspendLayout();
            this.cardBalance.SuspendLayout();
            this.analyticsCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressCanvas)).BeginInit();
            this.SuspendLayout();

            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.White;
            this.topPanel.Controls.Add(this.pickerPanel);
            this.topPanel.Controls.Add(this.btnClose);
            this.topPanel.Controls.Add(this.titleLabel);
            this.topPanel.Controls.Add(this.subtitleLabel);
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
            this.titleLabel.Size = new System.Drawing.Size(305, 37);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Monthly Summary";

            // 
            // subtitleLabel
            // 
            this.subtitleLabel.AutoSize = true;
            this.subtitleLabel.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.subtitleLabel.ForeColor = System.Drawing.Color.FromArgb(110, 118, 130);
            this.subtitleLabel.Location = new System.Drawing.Point(2, 45);
            this.subtitleLabel.Name = "subtitleLabel";
            this.subtitleLabel.Size = new System.Drawing.Size(340, 21);
            this.subtitleLabel.TabIndex = 1;
            this.subtitleLabel.Text = "Overview of monthly cash flow and savings rate";

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
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "✕ Close View";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // 
            // pickerPanel
            // 
            this.pickerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pickerPanel.Controls.Add(this.lblSelectMonth);
            this.pickerPanel.Controls.Add(this.monthPicker);
            this.pickerPanel.Location = new System.Drawing.Point(530, 6);
            this.pickerPanel.Name = "pickerPanel";
            this.pickerPanel.Size = new System.Drawing.Size(280, 64);
            this.pickerPanel.TabIndex = 2;

            // 
            // lblSelectMonth
            // 
            this.lblSelectMonth.AutoSize = true;
            this.lblSelectMonth.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblSelectMonth.ForeColor = System.Drawing.Color.FromArgb(110, 118, 130);
            this.lblSelectMonth.Location = new System.Drawing.Point(0, 4);
            this.lblSelectMonth.Name = "lblSelectMonth";
            this.lblSelectMonth.Size = new System.Drawing.Size(103, 20);
            this.lblSelectMonth.TabIndex = 0;
            this.lblSelectMonth.Text = "Select Month:";

            // 
            // monthPicker
            // 
            this.monthPicker.CustomFormat = "MMMM yyyy";
            this.monthPicker.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.monthPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.monthPicker.Location = new System.Drawing.Point(0, 28);
            this.monthPicker.Name = "monthPicker";
            this.monthPicker.Size = new System.Drawing.Size(275, 30);
            this.monthPicker.TabIndex = 1;

            // 
            // cardsPanel
            // 
            this.cardsPanel.Controls.Add(this.cardIncome);
            this.cardsPanel.Controls.Add(this.cardExpense);
            this.cardsPanel.Controls.Add(this.cardBalance);
            this.cardsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.cardsPanel.Location = new System.Drawing.Point(24, 95);
            this.cardsPanel.Name = "cardsPanel";
            this.cardsPanel.Padding = new System.Windows.Forms.Padding(0, 12, 0, 16);
            this.cardsPanel.Size = new System.Drawing.Size(950, 145);
            this.cardsPanel.TabIndex = 1;
            this.cardsPanel.Resize += new System.EventHandler(this.CardsPanel_Resize);

            // 
            // cardIncome
            // 
            this.cardIncome.BackColor = System.Drawing.Color.White;
            this.cardIncome.Controls.Add(this.lblIncomeIcon);
            this.cardIncome.Controls.Add(this.lblIncomeTitle);
            this.cardIncome.Controls.Add(this.lblIncomeVal);
            this.cardIncome.Controls.Add(this.lblIncomeSub);
            this.cardIncome.Location = new System.Drawing.Point(0, 12);
            this.cardIncome.Name = "cardIncome";
            this.cardIncome.Size = new System.Drawing.Size(295, 115);
            this.cardIncome.TabIndex = 0;

            // 
            // lblIncomeIcon
            // 
            this.lblIncomeIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIncomeIcon.AutoSize = true;
            this.lblIncomeIcon.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblIncomeIcon.ForeColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.lblIncomeIcon.Location = new System.Drawing.Point(250, 12);
            this.lblIncomeIcon.Name = "lblIncomeIcon";
            this.lblIncomeIcon.Size = new System.Drawing.Size(37, 37);
            this.lblIncomeIcon.TabIndex = 3;
            this.lblIncomeIcon.Text = "▲";

            // 
            // lblIncomeTitle
            // 
            this.lblIncomeTitle.AutoSize = true;
            this.lblIncomeTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblIncomeTitle.ForeColor = System.Drawing.Color.FromArgb(110, 118, 130);
            this.lblIncomeTitle.Location = new System.Drawing.Point(16, 14);
            this.lblIncomeTitle.Name = "lblIncomeTitle";
            this.lblIncomeTitle.Size = new System.Drawing.Size(111, 20);
            this.lblIncomeTitle.TabIndex = 0;
            this.lblIncomeTitle.Text = "TOTAL INCOME";

            // 
            // lblIncomeVal
            // 
            this.lblIncomeVal.AutoSize = true;
            this.lblIncomeVal.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblIncomeVal.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.lblIncomeVal.Location = new System.Drawing.Point(14, 38);
            this.lblIncomeVal.Name = "lblIncomeVal";
            this.lblIncomeVal.Size = new System.Drawing.Size(95, 41);
            this.lblIncomeVal.TabIndex = 1;
            this.lblIncomeVal.Text = "₹0.00";

            // 
            // lblIncomeSub
            // 
            this.lblIncomeSub.AutoSize = true;
            this.lblIncomeSub.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblIncomeSub.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblIncomeSub.Location = new System.Drawing.Point(16, 82);
            this.lblIncomeSub.Name = "lblIncomeSub";
            this.lblIncomeSub.Size = new System.Drawing.Size(126, 19);
            this.lblIncomeSub.TabIndex = 2;
            this.lblIncomeSub.Text = "100% of cash inflow";

            // 
            // cardExpense
            // 
            this.cardExpense.BackColor = System.Drawing.Color.White;
            this.cardExpense.Controls.Add(this.lblExpenseIcon);
            this.cardExpense.Controls.Add(this.lblExpenseTitle);
            this.cardExpense.Controls.Add(this.lblExpenseVal);
            this.cardExpense.Controls.Add(this.lblExpenseSub);
            this.cardExpense.Location = new System.Drawing.Point(320, 12);
            this.cardExpense.Name = "cardExpense";
            this.cardExpense.Size = new System.Drawing.Size(295, 115);
            this.cardExpense.TabIndex = 1;

            // 
            // lblExpenseIcon
            // 
            this.lblExpenseIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblExpenseIcon.AutoSize = true;
            this.lblExpenseIcon.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblExpenseIcon.ForeColor = System.Drawing.Color.FromArgb(235, 87, 87);
            this.lblExpenseIcon.Location = new System.Drawing.Point(250, 12);
            this.lblExpenseIcon.Name = "lblExpenseIcon";
            this.lblExpenseIcon.Size = new System.Drawing.Size(37, 37);
            this.lblExpenseIcon.TabIndex = 3;
            this.lblExpenseIcon.Text = "▼";

            // 
            // lblExpenseTitle
            // 
            this.lblExpenseTitle.AutoSize = true;
            this.lblExpenseTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblExpenseTitle.ForeColor = System.Drawing.Color.FromArgb(110, 118, 130);
            this.lblExpenseTitle.Location = new System.Drawing.Point(16, 14);
            this.lblExpenseTitle.Name = "lblExpenseTitle";
            this.lblExpenseTitle.Size = new System.Drawing.Size(122, 20);
            this.lblExpenseTitle.TabIndex = 0;
            this.lblExpenseTitle.Text = "TOTAL EXPENSES";

            // 
            // lblExpenseVal
            // 
            this.lblExpenseVal.AutoSize = true;
            this.lblExpenseVal.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblExpenseVal.ForeColor = System.Drawing.Color.FromArgb(235, 87, 87);
            this.lblExpenseVal.Location = new System.Drawing.Point(14, 38);
            this.lblExpenseVal.Name = "lblExpenseVal";
            this.lblExpenseVal.Size = new System.Drawing.Size(95, 41);
            this.lblExpenseVal.TabIndex = 1;
            this.lblExpenseVal.Text = "₹0.00";

            // 
            // lblExpenseSub
            // 
            this.lblExpenseSub.AutoSize = true;
            this.lblExpenseSub.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblExpenseSub.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblExpenseSub.Location = new System.Drawing.Point(16, 82);
            this.lblExpenseSub.Name = "lblExpenseSub";
            this.lblExpenseSub.Size = new System.Drawing.Size(142, 19);
            this.lblExpenseSub.TabIndex = 2;
            this.lblExpenseSub.Text = "0% of monthly income";

            // 
            // cardBalance
            // 
            this.cardBalance.BackColor = System.Drawing.Color.White;
            this.cardBalance.Controls.Add(this.lblBalanceIcon);
            this.cardBalance.Controls.Add(this.lblBalanceTitle);
            this.cardBalance.Controls.Add(this.lblBalanceVal);
            this.cardBalance.Controls.Add(this.lblBalanceSub);
            this.cardBalance.Location = new System.Drawing.Point(640, 12);
            this.cardBalance.Name = "cardBalance";
            this.cardBalance.Size = new System.Drawing.Size(295, 115);
            this.cardBalance.TabIndex = 2;

            // 
            // lblBalanceIcon
            // 
            this.lblBalanceIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBalanceIcon.AutoSize = true;
            this.lblBalanceIcon.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblBalanceIcon.ForeColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.lblBalanceIcon.Location = new System.Drawing.Point(250, 12);
            this.lblBalanceIcon.Name = "lblBalanceIcon";
            this.lblBalanceIcon.Size = new System.Drawing.Size(37, 37);
            this.lblBalanceIcon.TabIndex = 3;
            this.lblBalanceIcon.Text = "★";

            // 
            // lblBalanceTitle
            // 
            this.lblBalanceTitle.AutoSize = true;
            this.lblBalanceTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblBalanceTitle.ForeColor = System.Drawing.Color.FromArgb(110, 118, 130);
            this.lblBalanceTitle.Location = new System.Drawing.Point(16, 14);
            this.lblBalanceTitle.Name = "lblBalanceTitle";
            this.lblBalanceTitle.Size = new System.Drawing.Size(107, 20);
            this.lblBalanceTitle.TabIndex = 0;
            this.lblBalanceTitle.Text = "NET SAVINGS";

            // 
            // lblBalanceVal
            // 
            this.lblBalanceVal.AutoSize = true;
            this.lblBalanceVal.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblBalanceVal.ForeColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.lblBalanceVal.Location = new System.Drawing.Point(14, 38);
            this.lblBalanceVal.Name = "lblBalanceVal";
            this.lblBalanceVal.Size = new System.Drawing.Size(95, 41);
            this.lblBalanceVal.TabIndex = 1;
            this.lblBalanceVal.Text = "₹0.00";

            // 
            // lblBalanceSub
            // 
            this.lblBalanceSub.AutoSize = true;
            this.lblBalanceSub.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblBalanceSub.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblBalanceSub.Location = new System.Drawing.Point(16, 82);
            this.lblBalanceSub.Name = "lblBalanceSub";
            this.lblBalanceSub.Size = new System.Drawing.Size(130, 19);
            this.lblBalanceSub.TabIndex = 2;
            this.lblBalanceSub.Text = "Savings rate: 0.0%";

            // 
            // analyticsCard
            // 
            this.analyticsCard.BackColor = System.Drawing.Color.White;
            this.analyticsCard.Controls.Add(this.healthBadge);
            this.analyticsCard.Controls.Add(this.lblAnalyticsSub);
            this.analyticsCard.Controls.Add(this.lblAnalyticsTitle);
            this.analyticsCard.Controls.Add(this.progressCanvas);
            this.analyticsCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.analyticsCard.Location = new System.Drawing.Point(24, 240);
            this.analyticsCard.Name = "analyticsCard";
            this.analyticsCard.Padding = new System.Windows.Forms.Padding(20);
            this.analyticsCard.Size = new System.Drawing.Size(950, 360);
            this.analyticsCard.TabIndex = 2;

            // 
            // lblAnalyticsTitle
            // 
            this.lblAnalyticsTitle.AutoSize = true;
            this.lblAnalyticsTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblAnalyticsTitle.ForeColor = System.Drawing.Color.FromArgb(35, 42, 52);
            this.lblAnalyticsTitle.Location = new System.Drawing.Point(18, 16);
            this.lblAnalyticsTitle.Name = "lblAnalyticsTitle";
            this.lblAnalyticsTitle.Size = new System.Drawing.Size(206, 28);
            this.lblAnalyticsTitle.TabIndex = 0;
            this.lblAnalyticsTitle.Text = "Cash Flow Analytics";

            // 
            // lblAnalyticsSub
            // 
            this.lblAnalyticsSub.AutoSize = true;
            this.lblAnalyticsSub.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAnalyticsSub.ForeColor = System.Drawing.Color.FromArgb(110, 118, 130);
            this.lblAnalyticsSub.Location = new System.Drawing.Point(20, 46);
            this.lblAnalyticsSub.Name = "lblAnalyticsSub";
            this.lblAnalyticsSub.Size = new System.Drawing.Size(350, 20);
            this.lblAnalyticsSub.TabIndex = 1;
            this.lblAnalyticsSub.Text = "Visual breakdown of your financial distribution";

            // 
            // healthBadge
            // 
            this.healthBadge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.healthBadge.BackColor = System.Drawing.Color.FromArgb(235, 249, 241);
            this.healthBadge.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.healthBadge.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.healthBadge.Location = new System.Drawing.Point(620, 18);
            this.healthBadge.Name = "healthBadge";
            this.healthBadge.Padding = new System.Windows.Forms.Padding(12, 6, 12, 6);
            this.healthBadge.Size = new System.Drawing.Size(310, 36);
            this.healthBadge.TabIndex = 2;
            this.healthBadge.Text = "Status: Healthy Cash Flow";
            this.healthBadge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // progressCanvas
            // 
            this.progressCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressCanvas.BackColor = System.Drawing.Color.White;
            this.progressCanvas.Location = new System.Drawing.Point(20, 80);
            this.progressCanvas.Name = "progressCanvas";
            this.progressCanvas.Size = new System.Drawing.Size(910, 260);
            this.progressCanvas.TabIndex = 3;
            this.progressCanvas.TabStop = false;

            // 
            // Summary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(248, 249, 251);
            this.ClientSize = new System.Drawing.Size(998, 620);
            this.Controls.Add(this.analyticsCard);
            this.Controls.Add(this.cardsPanel);
            this.Controls.Add(this.topPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "Summary";
            this.Padding = new System.Windows.Forms.Padding(24, 20, 24, 20);
            this.Text = "Summary Dashboard";
            this.Load += new System.EventHandler(this.Summary_Load);

            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.pickerPanel.ResumeLayout(false);
            this.pickerPanel.PerformLayout();
            this.cardsPanel.ResumeLayout(false);
            this.cardIncome.ResumeLayout(false);
            this.cardIncome.PerformLayout();
            this.cardExpense.ResumeLayout(false);
            this.cardExpense.PerformLayout();
            this.cardBalance.ResumeLayout(false);
            this.cardBalance.PerformLayout();
            this.analyticsCard.ResumeLayout(false);
            this.analyticsCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressCanvas)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label subtitleLabel;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pickerPanel;
        private System.Windows.Forms.Label lblSelectMonth;
        private System.Windows.Forms.DateTimePicker monthPicker;
        private System.Windows.Forms.Panel cardsPanel;
        private System.Windows.Forms.Panel cardIncome;
        private System.Windows.Forms.Label lblIncomeTitle;
        private System.Windows.Forms.Label lblIncomeVal;
        private System.Windows.Forms.Label lblIncomeSub;
        private System.Windows.Forms.Label lblIncomeIcon;
        private System.Windows.Forms.Panel cardExpense;
        private System.Windows.Forms.Label lblExpenseTitle;
        private System.Windows.Forms.Label lblExpenseVal;
        private System.Windows.Forms.Label lblExpenseSub;
        private System.Windows.Forms.Label lblExpenseIcon;
        private System.Windows.Forms.Panel cardBalance;
        private System.Windows.Forms.Label lblBalanceTitle;
        private System.Windows.Forms.Label lblBalanceVal;
        private System.Windows.Forms.Label lblBalanceSub;
        private System.Windows.Forms.Label lblBalanceIcon;
        private System.Windows.Forms.Panel analyticsCard;
        private System.Windows.Forms.Label lblAnalyticsTitle;
        private System.Windows.Forms.Label lblAnalyticsSub;
        private System.Windows.Forms.Label healthBadge;
        private System.Windows.Forms.PictureBox progressCanvas;
    }
}