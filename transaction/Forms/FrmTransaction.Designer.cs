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
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnInsert = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.dgridTransactions = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUpdate = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgridTransactions)).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(16, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(269, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Income / Expense Transaction";

            // lblWelcome
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Location = new System.Drawing.Point(16, 46);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(60, 15);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "Welcome";

            // btnInsert
            this.btnInsert.Location = new System.Drawing.Point(728, 12);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(120, 36);
            this.btnInsert.TabIndex = 2;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);

            // dgridTransactions
            this.dgridTransactions.AllowUserToAddRows = false;
            this.dgridTransactions.AllowUserToDeleteRows = false;
            this.dgridTransactions.AutoGenerateColumns = false;
            this.dgridTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgridTransactions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colId,
                this.colDate,
                this.colDescription,
                this.colType,
                this.colCategory,
                this.colAmount,
                this.colUpdate,
                this.colDelete});
            this.dgridTransactions.Location = new System.Drawing.Point(12, 78);
            this.dgridTransactions.Name = "dgridTransactions";
            this.dgridTransactions.RowHeadersVisible = false;
            this.dgridTransactions.Size = new System.Drawing.Size(836, 430);
            this.dgridTransactions.TabIndex = 2;
            this.dgridTransactions.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgridTransactions_CellClick);

            // colId
            this.colId.DataPropertyName = "TransactionId";
            this.colId.HeaderText = "ID";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Width = 60;

            // colDate
            this.colDate.DataPropertyName = "TransactionDate";
            this.colDate.DefaultCellStyle.Format = "dd-MM-yyyy";
            this.colDate.HeaderText = "Date";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            this.colDate.Width = 100;

            // colDescription
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            this.colDescription.Width = 260;

            // colType
            this.colType.DataPropertyName = "TransactionType";
            this.colType.HeaderText = "Type";
            this.colType.Name = "colType";
            this.colType.ReadOnly = true;
            this.colType.Width = 90;

            // colCategory
            this.colCategory.DataPropertyName = "CategoryName";
            this.colCategory.HeaderText = "Category";
            this.colCategory.Name = "colCategory";
            this.colCategory.ReadOnly = true;
            this.colCategory.Width = 130;

            // colAmount
            this.colAmount.DataPropertyName = "Amount";
            this.colAmount.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colAmount.DefaultCellStyle.Format = "N2";
            this.colAmount.HeaderText = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            this.colAmount.Width = 100;

            // colUpdate
            this.colUpdate.HeaderText = "";
            this.colUpdate.Name = "colUpdate";
            this.colUpdate.ReadOnly = true;
            this.colUpdate.Text = "Update";
            this.colUpdate.UseColumnTextForButtonValue = true;
            this.colUpdate.Width = 90;

            // colDelete
            this.colDelete.HeaderText = "";
            this.colDelete.Name = "colDelete";
            this.colDelete.ReadOnly = true;
            this.colDelete.Text = "Delete";
            this.colDelete.UseColumnTextForButtonValue = true;
            this.colDelete.Width = 90;

            // FrmTransaction
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 520);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.dgridTransactions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmTransaction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Income / Expense Transaction";
            this.Load += new System.EventHandler(this.FrmTransaction_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgridTransactions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.DataGridView dgridTransactions;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewButtonColumn colUpdate;
        private System.Windows.Forms.DataGridViewButtonColumn colDelete;
    }
}