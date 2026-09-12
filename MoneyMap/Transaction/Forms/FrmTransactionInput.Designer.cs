namespace GP_1.Forms
{
    partial class FrmTransactionInput
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.bodyPanel = new System.Windows.Forms.Panel();
            this.lblType = new System.Windows.Forms.Label();
            this.rdoIncome = new System.Windows.Forms.RadioButton();
            this.rdoExpense = new System.Windows.Forms.RadioButton();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpTransactionDate = new System.Windows.Forms.DateTimePicker();
            this.lblAmount = new System.Windows.Forms.Label();
            this.nudAmount = new System.Windows.Forms.NumericUpDown();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.footerPanel = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            this.headerPanel.SuspendLayout();
            this.bodyPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).BeginInit();
            this.footerPanel.SuspendLayout();
            this.SuspendLayout();

            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(24, 31, 42);
            this.headerPanel.Controls.Add(this.lblTitle);
            this.headerPanel.Controls.Add(this.lblSubtitle);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Padding = new System.Windows.Forms.Padding(24, 14, 24, 14);
            this.headerPanel.Size = new System.Drawing.Size(460, 68);
            this.headerPanel.TabIndex = 0;

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(185, 28);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Add Transaction";

            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(160, 174, 192);
            this.lblSubtitle.Location = new System.Drawing.Point(21, 38);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(235, 19);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Enter your transaction details below";

            // 
            // bodyPanel
            // 
            this.bodyPanel.BackColor = System.Drawing.Color.White;
            this.bodyPanel.Controls.Add(this.lblType);
            this.bodyPanel.Controls.Add(this.rdoIncome);
            this.bodyPanel.Controls.Add(this.rdoExpense);
            this.bodyPanel.Controls.Add(this.lblDate);
            this.bodyPanel.Controls.Add(this.dtpTransactionDate);
            this.bodyPanel.Controls.Add(this.lblAmount);
            this.bodyPanel.Controls.Add(this.nudAmount);
            this.bodyPanel.Controls.Add(this.lblCategory);
            this.bodyPanel.Controls.Add(this.cmbCategory);
            this.bodyPanel.Controls.Add(this.lblDescription);
            this.bodyPanel.Controls.Add(this.txtDescription);
            this.bodyPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bodyPanel.Location = new System.Drawing.Point(0, 68);
            this.bodyPanel.Name = "bodyPanel";
            this.bodyPanel.Padding = new System.Windows.Forms.Padding(24, 18, 24, 18);
            this.bodyPanel.Size = new System.Drawing.Size(460, 292);
            this.bodyPanel.TabIndex = 1;

            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblType.ForeColor = System.Drawing.Color.FromArgb(110, 118, 130);
            this.lblType.Location = new System.Drawing.Point(24, 14);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(142, 19);
            this.lblType.TabIndex = 0;
            this.lblType.Text = "TRANSACTION TYPE";

            // 
            // rdoIncome
            // 
            this.rdoIncome.AutoSize = true;
            this.rdoIncome.Checked = true;
            this.rdoIncome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdoIncome.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.rdoIncome.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.rdoIncome.Location = new System.Drawing.Point(26, 38);
            this.rdoIncome.Name = "rdoIncome";
            this.rdoIncome.Size = new System.Drawing.Size(95, 25);
            this.rdoIncome.TabIndex = 1;
            this.rdoIncome.TabStop = true;
            this.rdoIncome.Text = "● Income";
            this.rdoIncome.UseVisualStyleBackColor = true;
            this.rdoIncome.CheckedChanged += new System.EventHandler(this.rdoType_CheckedChanged);

            // 
            // rdoExpense
            // 
            this.rdoExpense.AutoSize = true;
            this.rdoExpense.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdoExpense.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.rdoExpense.ForeColor = System.Drawing.Color.FromArgb(235, 87, 87);
            this.rdoExpense.Location = new System.Drawing.Point(145, 38);
            this.rdoExpense.Name = "rdoExpense";
            this.rdoExpense.Size = new System.Drawing.Size(100, 25);
            this.rdoExpense.TabIndex = 2;
            this.rdoExpense.Text = "● Expense";
            this.rdoExpense.UseVisualStyleBackColor = true;
            this.rdoExpense.CheckedChanged += new System.EventHandler(this.rdoType_CheckedChanged);

            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(110, 118, 130);
            this.lblDate.Location = new System.Drawing.Point(24, 76);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(43, 19);
            this.lblDate.TabIndex = 3;
            this.lblDate.Text = "DATE";

            // 
            // dtpTransactionDate
            // 
            this.dtpTransactionDate.CalendarFont = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpTransactionDate.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpTransactionDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTransactionDate.Location = new System.Drawing.Point(26, 98);
            this.dtpTransactionDate.Name = "dtpTransactionDate";
            this.dtpTransactionDate.Size = new System.Drawing.Size(190, 29);
            this.dtpTransactionDate.TabIndex = 4;

            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblAmount.ForeColor = System.Drawing.Color.FromArgb(110, 118, 130);
            this.lblAmount.Location = new System.Drawing.Point(232, 76);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(89, 19);
            this.lblAmount.TabIndex = 5;
            this.lblAmount.Text = "AMOUNT (₹)";

            // 
            // nudAmount
            // 
            this.nudAmount.DecimalPlaces = 2;
            this.nudAmount.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.nudAmount.Location = new System.Drawing.Point(234, 98);
            this.nudAmount.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            this.nudAmount.Name = "nudAmount";
            this.nudAmount.Size = new System.Drawing.Size(198, 29);
            this.nudAmount.TabIndex = 6;
            this.nudAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudAmount_KeyPress);

            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblCategory.ForeColor = System.Drawing.Color.FromArgb(110, 118, 130);
            this.lblCategory.Location = new System.Drawing.Point(24, 140);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(78, 19);
            this.lblCategory.TabIndex = 7;
            this.lblCategory.Text = "CATEGORY";

            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(26, 162);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(406, 29);
            this.cmbCategory.TabIndex = 8;

            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblDescription.ForeColor = System.Drawing.Color.FromArgb(110, 118, 130);
            this.lblDescription.Location = new System.Drawing.Point(24, 204);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(161, 19);
            this.lblDescription.TabIndex = 9;
            this.lblDescription.Text = "DESCRIPTION / NOTE";

            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDescription.Location = new System.Drawing.Point(26, 226);
            this.txtDescription.MaxLength = 255;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.PlaceholderText = "e.g., Monthly salary, Grocery shopping, Utilities...";
            this.txtDescription.Size = new System.Drawing.Size(406, 29);
            this.txtDescription.TabIndex = 10;

            // 
            // footerPanel
            // 
            this.footerPanel.BackColor = System.Drawing.Color.FromArgb(248, 249, 251);
            this.footerPanel.Controls.Add(this.btnSave);
            this.footerPanel.Controls.Add(this.btnCancel);
            this.footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footerPanel.Location = new System.Drawing.Point(0, 360);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.Padding = new System.Windows.Forms.Padding(24, 12, 24, 12);
            this.footerPanel.Size = new System.Drawing.Size(460, 60);
            this.footerPanel.TabIndex = 2;

            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(282, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 36);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save Transaction";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(35, 42, 52);
            this.btnCancel.Location = new System.Drawing.Point(176, 12);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 36);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // 
            // FrmTransactionInput
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(460, 420);
            this.Controls.Add(this.bodyPanel);
            this.Controls.Add(this.footerPanel);
            this.Controls.Add(this.headerPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTransactionInput";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Transaction";
            this.Load += new System.EventHandler(this.FrmTransactionInput_Load);

            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.bodyPanel.ResumeLayout(false);
            this.bodyPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).EndInit();
            this.footerPanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel bodyPanel;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.RadioButton rdoIncome;
        private System.Windows.Forms.RadioButton rdoExpense;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpTransactionDate;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.NumericUpDown nudAmount;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Panel footerPanel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
