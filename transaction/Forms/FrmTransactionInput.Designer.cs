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
            this.grpTransactionInput = new System.Windows.Forms.GroupBox();
            this.lblType = new System.Windows.Forms.Label();
            this.rdoIncome = new System.Windows.Forms.RadioButton();
            this.rdoExpense = new System.Windows.Forms.RadioButton();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpTransactionDate = new System.Windows.Forms.DateTimePicker();
            this.lblAmount = new System.Windows.Forms.Label();
            this.nudAmount = new System.Windows.Forms.NumericUpDown();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbIncomeCategory = new System.Windows.Forms.ComboBox();
            this.lstExpenseCategory = new System.Windows.Forms.ListBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpTransactionInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).BeginInit();
            this.SuspendLayout();

            // grpTransactionInput
            this.grpTransactionInput.Controls.Add(this.lblType);
            this.grpTransactionInput.Controls.Add(this.rdoIncome);
            this.grpTransactionInput.Controls.Add(this.rdoExpense);
            this.grpTransactionInput.Controls.Add(this.lblDate);
            this.grpTransactionInput.Controls.Add(this.dtpTransactionDate);
            this.grpTransactionInput.Controls.Add(this.lblAmount);
            this.grpTransactionInput.Controls.Add(this.nudAmount);
            this.grpTransactionInput.Controls.Add(this.lblDescription);
            this.grpTransactionInput.Controls.Add(this.txtDescription);
            this.grpTransactionInput.Controls.Add(this.lblCategory);
            this.grpTransactionInput.Controls.Add(this.cmbIncomeCategory);
            this.grpTransactionInput.Controls.Add(this.lstExpenseCategory);
            this.grpTransactionInput.Controls.Add(this.btnSave);
            this.grpTransactionInput.Controls.Add(this.btnCancel);
            this.grpTransactionInput.Location = new System.Drawing.Point(12, 12);
            this.grpTransactionInput.Name = "grpTransactionInput";
            this.grpTransactionInput.Size = new System.Drawing.Size(436, 296);
            this.grpTransactionInput.TabIndex = 0;
            this.grpTransactionInput.TabStop = false;
            this.grpTransactionInput.Text = "Income / Expense Input";

            // lblType
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(20, 37);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(31, 15);
            this.lblType.TabIndex = 0;
            this.lblType.Text = "Type";

            // rdoIncome
            this.rdoIncome.AutoSize = true;
            this.rdoIncome.Checked = true;
            this.rdoIncome.Location = new System.Drawing.Point(80, 35);
            this.rdoIncome.Name = "rdoIncome";
            this.rdoIncome.Size = new System.Drawing.Size(63, 19);
            this.rdoIncome.TabIndex = 1;
            this.rdoIncome.TabStop = true;
            this.rdoIncome.Text = "Income";
            this.rdoIncome.UseVisualStyleBackColor = true;
            this.rdoIncome.CheckedChanged += new System.EventHandler(this.rdoIncome_CheckedChanged);

            // rdoExpense
            this.rdoExpense.AutoSize = true;
            this.rdoExpense.Location = new System.Drawing.Point(170, 35);
            this.rdoExpense.Name = "rdoExpense";
            this.rdoExpense.Size = new System.Drawing.Size(67, 19);
            this.rdoExpense.TabIndex = 2;
            this.rdoExpense.Text = "Expense";
            this.rdoExpense.UseVisualStyleBackColor = true;
            this.rdoExpense.CheckedChanged += new System.EventHandler(this.rdoExpense_CheckedChanged);

            // lblDate
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(20, 82);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(31, 15);
            this.lblDate.TabIndex = 3;
            this.lblDate.Text = "Date";

            // dtpTransactionDate
            this.dtpTransactionDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTransactionDate.Location = new System.Drawing.Point(110, 79);
            this.dtpTransactionDate.Name = "dtpTransactionDate";
            this.dtpTransactionDate.Size = new System.Drawing.Size(120, 23);
            this.dtpTransactionDate.TabIndex = 4;

            // lblAmount
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(250, 82);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(51, 15);
            this.lblAmount.TabIndex = 5;
            this.lblAmount.Text = "Amount";

            // nudAmount
            this.nudAmount.DecimalPlaces = 2;
            this.nudAmount.Location = new System.Drawing.Point(320, 79);
            this.nudAmount.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            this.nudAmount.Minimum = new decimal(new int[] { 1, 0, 0, 131072 });
            this.nudAmount.Name = "nudAmount";
            this.nudAmount.Size = new System.Drawing.Size(100, 23);
            this.nudAmount.TabIndex = 6;
            this.nudAmount.Value = new decimal(new int[] { 1, 0, 0, 131072 });
            this.nudAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudAmount_KeyPress);

            // lblDescription
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(20, 117);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(67, 15);
            this.lblDescription.TabIndex = 7;
            this.lblDescription.Text = "Description";

            // txtDescription
            this.txtDescription.Location = new System.Drawing.Point(110, 114);
            this.txtDescription.MaxLength = 255;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(310, 23);
            this.txtDescription.TabIndex = 8;

            // lblCategory
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(20, 147);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(55, 15);
            this.lblCategory.TabIndex = 9;
            this.lblCategory.Text = "Category";

            // cmbIncomeCategory
            this.cmbIncomeCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIncomeCategory.FormattingEnabled = true;
            this.cmbIncomeCategory.Location = new System.Drawing.Point(110, 144);
            this.cmbIncomeCategory.Name = "cmbIncomeCategory";
            this.cmbIncomeCategory.Size = new System.Drawing.Size(180, 23);
            this.cmbIncomeCategory.TabIndex = 10;

            // lstExpenseCategory
            this.lstExpenseCategory.FormattingEnabled = true;
            this.lstExpenseCategory.ItemHeight = 15;
            this.lstExpenseCategory.Location = new System.Drawing.Point(110, 144);
            this.lstExpenseCategory.Name = "lstExpenseCategory";
            this.lstExpenseCategory.Size = new System.Drawing.Size(180, 104);
            this.lstExpenseCategory.TabIndex = 11;
            this.lstExpenseCategory.Visible = false;

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(140, 255);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 32);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Add";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(250, 255);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 32);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // FrmTransactionInput
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(460, 320);
            this.Controls.Add(this.grpTransactionInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTransactionInput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Income / Expense";
            this.Load += new System.EventHandler(this.FrmTransactionInput_Load);
            this.grpTransactionInput.ResumeLayout(false);
            this.grpTransactionInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.GroupBox grpTransactionInput;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.RadioButton rdoIncome;
        private System.Windows.Forms.RadioButton rdoExpense;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpTransactionDate;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.NumericUpDown nudAmount;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbIncomeCategory;
        private System.Windows.Forms.ListBox lstExpenseCategory;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}