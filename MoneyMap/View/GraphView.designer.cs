namespace GP_1
{
    partial class GraphView
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.statsPanel = new System.Windows.Forms.Panel();
            this.chipIncome = new System.Windows.Forms.Panel();
            this.lblChipIncomeVal = new System.Windows.Forms.Label();
            this.lblChipIncomeTitle = new System.Windows.Forms.Label();
            this.chipExpense = new System.Windows.Forms.Panel();
            this.lblChipExpenseVal = new System.Windows.Forms.Label();
            this.lblChipExpenseTitle = new System.Windows.Forms.Label();
            this.chipBalance = new System.Windows.Forms.Panel();
            this.lblChipBalanceVal = new System.Windows.Forms.Label();
            this.lblChipBalanceTitle = new System.Windows.Forms.Label();
            this.chartCard = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();

            this.topPanel.SuspendLayout();
            this.pickerPanel.SuspendLayout();
            this.statsPanel.SuspendLayout();
            this.chipIncome.SuspendLayout();
            this.chipExpense.SuspendLayout();
            this.chipBalance.SuspendLayout();
            this.chartCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.titleLabel.Size = new System.Drawing.Size(250, 37);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Financial Graph";

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
            this.subtitleLabel.Text = "Visual breakdown of monthly income vs expenses";

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
            this.pickerPanel.Controls.Add(this.dateTimePicker1);
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
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "MMMM yyyy";
            this.dateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(0, 28);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(275, 30);
            this.dateTimePicker1.TabIndex = 1;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.MonthPicker_ValueChanged);

            // 
            // statsPanel
            // 
            this.statsPanel.Controls.Add(this.chipIncome);
            this.statsPanel.Controls.Add(this.chipExpense);
            this.statsPanel.Controls.Add(this.chipBalance);
            this.statsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.statsPanel.Location = new System.Drawing.Point(24, 95);
            this.statsPanel.Name = "statsPanel";
            this.statsPanel.Padding = new System.Windows.Forms.Padding(0, 10, 0, 14);
            this.statsPanel.Size = new System.Drawing.Size(950, 85);
            this.statsPanel.TabIndex = 1;
            this.statsPanel.Resize += new System.EventHandler(this.StatsPanel_Resize);

            // 
            // chipIncome
            // 
            this.chipIncome.BackColor = System.Drawing.Color.White;
            this.chipIncome.Controls.Add(this.lblChipIncomeVal);
            this.chipIncome.Controls.Add(this.lblChipIncomeTitle);
            this.chipIncome.Location = new System.Drawing.Point(0, 10);
            this.chipIncome.Name = "chipIncome";
            this.chipIncome.Size = new System.Drawing.Size(295, 60);
            this.chipIncome.TabIndex = 0;

            // 
            // lblChipIncomeTitle
            // 
            this.lblChipIncomeTitle.AutoSize = true;
            this.lblChipIncomeTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblChipIncomeTitle.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.lblChipIncomeTitle.Location = new System.Drawing.Point(14, 8);
            this.lblChipIncomeTitle.Name = "lblChipIncomeTitle";
            this.lblChipIncomeTitle.Size = new System.Drawing.Size(106, 19);
            this.lblChipIncomeTitle.TabIndex = 0;
            this.lblChipIncomeTitle.Text = "TOTAL INCOME";

            // 
            // lblChipIncomeVal
            // 
            this.lblChipIncomeVal.AutoSize = true;
            this.lblChipIncomeVal.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            this.lblChipIncomeVal.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.lblChipIncomeVal.Location = new System.Drawing.Point(12, 26);
            this.lblChipIncomeVal.Name = "lblChipIncomeVal";
            this.lblChipIncomeVal.Size = new System.Drawing.Size(73, 31);
            this.lblChipIncomeVal.TabIndex = 1;
            this.lblChipIncomeVal.Text = "₹0.00";

            // 
            // chipExpense
            // 
            this.chipExpense.BackColor = System.Drawing.Color.White;
            this.chipExpense.Controls.Add(this.lblChipExpenseVal);
            this.chipExpense.Controls.Add(this.lblChipExpenseTitle);
            this.chipExpense.Location = new System.Drawing.Point(320, 10);
            this.chipExpense.Name = "chipExpense";
            this.chipExpense.Size = new System.Drawing.Size(295, 60);
            this.chipExpense.TabIndex = 1;

            // 
            // lblChipExpenseTitle
            // 
            this.lblChipExpenseTitle.AutoSize = true;
            this.lblChipExpenseTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblChipExpenseTitle.ForeColor = System.Drawing.Color.FromArgb(235, 87, 87);
            this.lblChipExpenseTitle.Location = new System.Drawing.Point(14, 8);
            this.lblChipExpenseTitle.Name = "lblChipExpenseTitle";
            this.lblChipExpenseTitle.Size = new System.Drawing.Size(117, 19);
            this.lblChipExpenseTitle.TabIndex = 0;
            this.lblChipExpenseTitle.Text = "TOTAL EXPENSES";

            // 
            // lblChipExpenseVal
            // 
            this.lblChipExpenseVal.AutoSize = true;
            this.lblChipExpenseVal.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            this.lblChipExpenseVal.ForeColor = System.Drawing.Color.FromArgb(235, 87, 87);
            this.lblChipExpenseVal.Location = new System.Drawing.Point(12, 26);
            this.lblChipExpenseVal.Name = "lblChipExpenseVal";
            this.lblChipExpenseVal.Size = new System.Drawing.Size(73, 31);
            this.lblChipExpenseVal.TabIndex = 1;
            this.lblChipExpenseVal.Text = "₹0.00";

            // 
            // chipBalance
            // 
            this.chipBalance.BackColor = System.Drawing.Color.White;
            this.chipBalance.Controls.Add(this.lblChipBalanceVal);
            this.chipBalance.Controls.Add(this.lblChipBalanceTitle);
            this.chipBalance.Location = new System.Drawing.Point(640, 10);
            this.chipBalance.Name = "chipBalance";
            this.chipBalance.Size = new System.Drawing.Size(295, 60);
            this.chipBalance.TabIndex = 2;

            // 
            // lblChipBalanceTitle
            // 
            this.lblChipBalanceTitle.AutoSize = true;
            this.lblChipBalanceTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblChipBalanceTitle.ForeColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.lblChipBalanceTitle.Location = new System.Drawing.Point(14, 8);
            this.lblChipBalanceTitle.Name = "lblChipBalanceTitle";
            this.lblChipBalanceTitle.Size = new System.Drawing.Size(102, 19);
            this.lblChipBalanceTitle.TabIndex = 0;
            this.lblChipBalanceTitle.Text = "NET BALANCE";

            // 
            // lblChipBalanceVal
            // 
            this.lblChipBalanceVal.AutoSize = true;
            this.lblChipBalanceVal.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            this.lblChipBalanceVal.ForeColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.lblChipBalanceVal.Location = new System.Drawing.Point(12, 26);
            this.lblChipBalanceVal.Name = "lblChipBalanceVal";
            this.lblChipBalanceVal.Size = new System.Drawing.Size(73, 31);
            this.lblChipBalanceVal.TabIndex = 1;
            this.lblChipBalanceVal.Text = "₹0.00";

            // 
            // chartCard
            // 
            this.chartCard.BackColor = System.Drawing.Color.White;
            this.chartCard.Controls.Add(this.pictureBox1);
            this.chartCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartCard.Location = new System.Drawing.Point(24, 180);
            this.chartCard.Name = "chartCard";
            this.chartCard.Padding = new System.Windows.Forms.Padding(16);
            this.chartCard.Size = new System.Drawing.Size(950, 420);
            this.chartCard.TabIndex = 2;

            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(16, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(918, 388);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;

            // 
            // GraphView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(248, 249, 251);
            this.ClientSize = new System.Drawing.Size(998, 620);
            this.Controls.Add(this.chartCard);
            this.Controls.Add(this.statsPanel);
            this.Controls.Add(this.topPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "GraphView";
            this.Padding = new System.Windows.Forms.Padding(24, 20, 24, 20);
            this.Text = "Financial Graph";
            this.Load += new System.EventHandler(this.GraphView_Load);

            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.pickerPanel.ResumeLayout(false);
            this.pickerPanel.PerformLayout();
            this.statsPanel.ResumeLayout(false);
            this.chipIncome.ResumeLayout(false);
            this.chipIncome.PerformLayout();
            this.chipExpense.ResumeLayout(false);
            this.chipExpense.PerformLayout();
            this.chipBalance.ResumeLayout(false);
            this.chipBalance.PerformLayout();
            this.chartCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label subtitleLabel;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pickerPanel;
        private System.Windows.Forms.Label lblSelectMonth;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Panel statsPanel;
        private System.Windows.Forms.Panel chipIncome;
        private System.Windows.Forms.Label lblChipIncomeTitle;
        private System.Windows.Forms.Label lblChipIncomeVal;
        private System.Windows.Forms.Panel chipExpense;
        private System.Windows.Forms.Label lblChipExpenseTitle;
        private System.Windows.Forms.Label lblChipExpenseVal;
        private System.Windows.Forms.Panel chipBalance;
        private System.Windows.Forms.Label lblChipBalanceTitle;
        private System.Windows.Forms.Label lblChipBalanceVal;
        private System.Windows.Forms.Panel chartCard;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}