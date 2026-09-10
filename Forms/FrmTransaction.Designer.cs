namespace GP_1.Forms
{
    partial class FrmTransaction
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblTransactionRecords = new System.Windows.Forms.Label();
            this.lstvTransactions = new System.Windows.Forms.ListView();
            this.colId = new System.Windows.Forms.ColumnHeader();
            this.colDate = new System.Windows.Forms.ColumnHeader();
            this.colDescription = new System.Windows.Forms.ColumnHeader();
            this.colType = new System.Windows.Forms.ColumnHeader();
            this.colCategory = new System.Windows.Forms.ColumnHeader();
            this.colAmount = new System.Windows.Forms.ColumnHeader();
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
            this.grpTransactionInput.Controls.Add(this.btnAdd);
            this.grpTransactionInput.Controls.Add(this.btnUpdate);
            this.grpTransactionInput.Controls.Add(this.btnDelete);
            this.grpTransactionInput.Controls.Add(this.btnClear);
            this.grpTransactionInput.Location = new System.Drawing.Point(12, 12);
            this.grpTransactionInput.Name = "grpTransactionInput";
            this.grpTransactionInput.Size = new System.Drawing.Size(796, 296);
            this.grpTransactionInput.TabIndex = 0;
            this.grpTransactionInput.TabStop = false;
            this.grpTransactionInput.Text = "Income / Expense Input";

            // lblType
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(20, 35);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(31, 15);
            this.lblType.TabIndex = 0;
            this.lblType.Text = "Type";

            // rdoIncome
            this.rdoIncome.AutoSize = true;
            this.rdoIncome.Checked = true;
            this.rdoIncome.Location = new System.Drawing.Point(80, 33);
            this.rdoIncome.Name = "rdoIncome";
            this.rdoIncome.Size = new System.Drawing.Size(63, 19);
            this.rdoIncome.TabIndex = 1;
            this.rdoIncome.TabStop = true;
            this.rdoIncome.Text = "Income";
            this.rdoIncome.UseVisualStyleBackColor = true;
            this.rdoIncome.CheckedChanged += new System.EventHandler(this.rdoIncome_CheckedChanged);

            // rdoExpense
            this.rdoExpense.AutoSize = true;
            this.rdoExpense.Location = new System.Drawing.Point(160, 33);
            this.rdoExpense.Name = "rdoExpense";
            this.rdoExpense.Size = new System.Drawing.Size(67, 19);
            this.rdoExpense.TabIndex = 2;
            this.rdoExpense.Text = "Expense";
            this.rdoExpense.UseVisualStyleBackColor = true;
            this.rdoExpense.CheckedChanged += new System.EventHandler(this.rdoExpense_CheckedChanged);

            // lblDate
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(20, 75);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(31, 15);
            this.lblDate.TabIndex = 3;
            this.lblDate.Text = "Date";

            // dtpTransactionDate
            this.dtpTransactionDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTransactionDate.Location = new System.Drawing.Point(80, 72);
            this.dtpTransactionDate.Name = "dtpTransactionDate";
            this.dtpTransactionDate.Size = new System.Drawing.Size(140, 23);
            this.dtpTransactionDate.TabIndex = 4;

            // lblAmount
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(20, 115);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(51, 15);
            this.lblAmount.TabIndex = 5;
            this.lblAmount.Text = "Amount";

            // nudAmount
            this.nudAmount.DecimalPlaces = 2;
            this.nudAmount.Location = new System.Drawing.Point(80, 112);
            this.nudAmount.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            this.nudAmount.Minimum = new decimal(new int[] { 1, 0, 0, 131072 });
            this.nudAmount.Name = "nudAmount";
            this.nudAmount.Size = new System.Drawing.Size(140, 23);
            this.nudAmount.TabIndex = 6;
            this.nudAmount.Value = new decimal(new int[] { 1, 0, 0, 131072 });
            this.nudAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudAmount_KeyPress);

            // lblDescription
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(250, 75);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(67, 15);
            this.lblDescription.TabIndex = 7;
            this.lblDescription.Text = "Description";

            // txtDescription
            this.txtDescription.Location = new System.Drawing.Point(340, 72);
            this.txtDescription.MaxLength = 255;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(440, 23);
            this.txtDescription.TabIndex = 8;

            // lblCategory
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(250, 115);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(55, 15);
            this.lblCategory.TabIndex = 9;
            this.lblCategory.Text = "Category";

            // cmbIncomeCategory
            this.cmbIncomeCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIncomeCategory.FormattingEnabled = true;
            this.cmbIncomeCategory.Location = new System.Drawing.Point(340, 112);
            this.cmbIncomeCategory.Name = "cmbIncomeCategory";
            this.cmbIncomeCategory.Size = new System.Drawing.Size(200, 23);
            this.cmbIncomeCategory.TabIndex = 10;

            // lstExpenseCategory
            this.lstExpenseCategory.FormattingEnabled = true;
            this.lstExpenseCategory.ItemHeight = 15;
            this.lstExpenseCategory.Location = new System.Drawing.Point(340, 112);
            this.lstExpenseCategory.Name = "lstExpenseCategory";
            this.lstExpenseCategory.Size = new System.Drawing.Size(200, 124);
            this.lstExpenseCategory.TabIndex = 11;
            this.lstExpenseCategory.Visible = false;

            // btnAdd
            this.btnAdd.Location = new System.Drawing.Point(370, 245);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(110, 40);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // btnUpdate
            this.btnUpdate.Location = new System.Drawing.Point(490, 245);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(110, 40);
            this.btnUpdate.TabIndex = 13;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            // btnDelete
            this.btnDelete.Location = new System.Drawing.Point(610, 245);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(110, 40);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // btnClear
            this.btnClear.Location = new System.Drawing.Point(726, 245);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(60, 40);
            this.btnClear.TabIndex = 15;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            // lblTransactionRecords
            this.lblTransactionRecords.AutoSize = true;
            this.lblTransactionRecords.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTransactionRecords.Location = new System.Drawing.Point(12, 322);
            this.lblTransactionRecords.Name = "lblTransactionRecords";
            this.lblTransactionRecords.Size = new System.Drawing.Size(128, 15);
            this.lblTransactionRecords.TabIndex = 1;
            this.lblTransactionRecords.Text = "Transaction Records";

            // lstvTransactions
            this.lstvTransactions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                this.colId,
                this.colDate,
                this.colDescription,
                this.colType,
                this.colCategory,
                this.colAmount});
            this.lstvTransactions.FullRowSelect = true;
            this.lstvTransactions.GridLines = true;
            this.lstvTransactions.Location = new System.Drawing.Point(12, 342);
            this.lstvTransactions.Name = "lstvTransactions";
            this.lstvTransactions.Size = new System.Drawing.Size(796, 300);
            this.lstvTransactions.TabIndex = 16;
            this.lstvTransactions.UseCompatibleStateImageBehavior = false;
            this.lstvTransactions.View = System.Windows.Forms.View.Details;
            this.lstvTransactions.SelectedIndexChanged += new System.EventHandler(this.lstvTransactions_SelectedIndexChanged);

            // colId
            this.colId.Text = "ID";
            this.colId.Width = 50;

            // colDate
            this.colDate.Text = "Date";
            this.colDate.Width = 100;

            // colDescription
            this.colDescription.Text = "Description";
            this.colDescription.Width = 250;

            // colType
            this.colType.Text = "Type";
            this.colType.Width = 80;

            // colCategory
            this.colCategory.Text = "Category";
            this.colCategory.Width = 120;

            // colAmount
            this.colAmount.Text = "Amount";
            this.colAmount.Width = 100;

            // FrmTransaction
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 658);
            this.Controls.Add(this.grpTransactionInput);
            this.Controls.Add(this.lblTransactionRecords);
            this.Controls.Add(this.lstvTransactions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmTransaction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Income / Expense Transaction";
            this.Load += new System.EventHandler(this.FrmTransaction_Load);
            this.grpTransactionInput.ResumeLayout(false);
            this.grpTransactionInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
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
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblTransactionRecords;
        private System.Windows.Forms.ListView lstvTransactions;
        private System.Windows.Forms.ColumnHeader colId;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.ColumnHeader colDescription;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.ColumnHeader colCategory;
        private System.Windows.Forms.ColumnHeader colAmount;
    }
}