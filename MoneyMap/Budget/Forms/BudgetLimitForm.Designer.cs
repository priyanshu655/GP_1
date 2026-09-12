namespace MoneyMap.Budget.Forms
{
    partial class BudgetLimitForm
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
            this.btnClose = new System.Windows.Forms.Button();
            this.mainContainer = new System.Windows.Forms.Panel();
            this.pnlOverallCard = new System.Windows.Forms.Panel();
            this.lblOverallTitle = new System.Windows.Forms.Label();
            this.lblOverallDesc = new System.Windows.Forms.Label();
            this.numOverallLimit = new System.Windows.Forms.NumericUpDown();
            this.lblCurrency = new System.Windows.Forms.Label();
            this.pnlCategoryCard = new System.Windows.Forms.Panel();
            this.lblCategoryTitle = new System.Windows.Forms.Label();
            this.lblCategoryDesc = new System.Windows.Forms.Label();
            this.dgvCategoryBudgets = new System.Windows.Forms.DataGridView();
            this.bottomBar = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.headerPanel.SuspendLayout();
            this.mainContainer.SuspendLayout();
            this.pnlOverallCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOverallLimit)).BeginInit();
            this.pnlCategoryCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategoryBudgets)).BeginInit();
            this.bottomBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.White;
            this.headerPanel.Controls.Add(this.lblTitle);
            this.headerPanel.Controls.Add(this.lblSubtitle);
            this.headerPanel.Controls.Add(this.btnClose);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Padding = new System.Windows.Forms.Padding(24, 16, 24, 16);
            this.headerPanel.Size = new System.Drawing.Size(680, 75);
            this.headerPanel.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(24, 31, 42);
            this.lblTitle.Location = new System.Drawing.Point(22, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(270, 28);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🎯 Monthly Budget Setter";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblSubtitle.Location = new System.Drawing.Point(24, 44);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(430, 15);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Set overall monthly limits and individual category thresholds (Food, Rent, etc.).";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(243, 244, 246);
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(75, 85, 99);
            this.btnClose.Location = new System.Drawing.Point(636, 16);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(32, 32);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "✕";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // mainContainer
            // 
            this.mainContainer.AutoScroll = true;
            this.mainContainer.Controls.Add(this.pnlCategoryCard);
            this.mainContainer.Controls.Add(this.pnlOverallCard);
            this.mainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainContainer.Location = new System.Drawing.Point(0, 75);
            this.mainContainer.Name = "mainContainer";
            this.mainContainer.Padding = new System.Windows.Forms.Padding(20);
            this.mainContainer.Size = new System.Drawing.Size(680, 485);
            this.mainContainer.TabIndex = 1;
            // 
            // pnlOverallCard
            // 
            this.pnlOverallCard.BackColor = System.Drawing.Color.White;
            this.pnlOverallCard.Controls.Add(this.lblCurrency);
            this.pnlOverallCard.Controls.Add(this.numOverallLimit);
            this.pnlOverallCard.Controls.Add(this.lblOverallDesc);
            this.pnlOverallCard.Controls.Add(this.lblOverallTitle);
            this.pnlOverallCard.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlOverallCard.Location = new System.Drawing.Point(20, 20);
            this.pnlOverallCard.Name = "pnlOverallCard";
            this.pnlOverallCard.Padding = new System.Windows.Forms.Padding(16);
            this.pnlOverallCard.Size = new System.Drawing.Size(640, 95);
            this.pnlOverallCard.TabIndex = 0;
            // 
            // lblOverallTitle
            // 
            this.lblOverallTitle.AutoSize = true;
            this.lblOverallTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblOverallTitle.ForeColor = System.Drawing.Color.FromArgb(24, 31, 42);
            this.lblOverallTitle.Location = new System.Drawing.Point(14, 14);
            this.lblOverallTitle.Name = "lblOverallTitle";
            this.lblOverallTitle.Size = new System.Drawing.Size(206, 20);
            this.lblOverallTitle.TabIndex = 0;
            this.lblOverallTitle.Text = "📊 Overall Monthly Budget";
            // 
            // lblOverallDesc
            // 
            this.lblOverallDesc.AutoSize = true;
            this.lblOverallDesc.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblOverallDesc.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblOverallDesc.Location = new System.Drawing.Point(16, 40);
            this.lblOverallDesc.Name = "lblOverallDesc";
            this.lblOverallDesc.Size = new System.Drawing.Size(325, 15);
            this.lblOverallDesc.TabIndex = 1;
            this.lblOverallDesc.Text = "Maximum total expenditure allowed across all categories (₹)";
            // 
            // numOverallLimit
            // 
            this.numOverallLimit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numOverallLimit.DecimalPlaces = 2;
            this.numOverallLimit.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.numOverallLimit.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numOverallLimit.Location = new System.Drawing.Point(450, 32);
            this.numOverallLimit.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numOverallLimit.Name = "numOverallLimit";
            this.numOverallLimit.Size = new System.Drawing.Size(170, 27);
            this.numOverallLimit.TabIndex = 2;
            this.numOverallLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numOverallLimit.ThousandsSeparator = true;
            // 
            // lblCurrency
            // 
            this.lblCurrency.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblCurrency.ForeColor = System.Drawing.Color.FromArgb(75, 85, 99);
            this.lblCurrency.Location = new System.Drawing.Point(426, 35);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(19, 20);
            this.lblCurrency.TabIndex = 3;
            this.lblCurrency.Text = "₹";
            // 
            // pnlCategoryCard
            // 
            this.pnlCategoryCard.BackColor = System.Drawing.Color.White;
            this.pnlCategoryCard.Controls.Add(this.dgvCategoryBudgets);
            this.pnlCategoryCard.Controls.Add(this.lblCategoryDesc);
            this.pnlCategoryCard.Controls.Add(this.lblCategoryTitle);
            this.pnlCategoryCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCategoryCard.Location = new System.Drawing.Point(20, 115);
            this.pnlCategoryCard.Margin = new System.Windows.Forms.Padding(0, 16, 0, 0);
            this.pnlCategoryCard.Name = "pnlCategoryCard";
            this.pnlCategoryCard.Padding = new System.Windows.Forms.Padding(16);
            this.pnlCategoryCard.Size = new System.Drawing.Size(640, 350);
            this.pnlCategoryCard.TabIndex = 1;
            // 
            // lblCategoryTitle
            // 
            this.lblCategoryTitle.AutoSize = true;
            this.lblCategoryTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblCategoryTitle.ForeColor = System.Drawing.Color.FromArgb(24, 31, 42);
            this.lblCategoryTitle.Location = new System.Drawing.Point(14, 14);
            this.lblCategoryTitle.Name = "lblCategoryTitle";
            this.lblCategoryTitle.Size = new System.Drawing.Size(222, 20);
            this.lblCategoryTitle.TabIndex = 0;
            this.lblCategoryTitle.Text = "🏷️ Category Budget Limits (₹)";
            // 
            // lblCategoryDesc
            // 
            this.lblCategoryDesc.AutoSize = true;
            this.lblCategoryDesc.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblCategoryDesc.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblCategoryDesc.Location = new System.Drawing.Point(16, 38);
            this.lblCategoryDesc.Name = "lblCategoryDesc";
            this.lblCategoryDesc.Size = new System.Drawing.Size(362, 15);
            this.lblCategoryDesc.TabIndex = 1;
            this.lblCategoryDesc.Text = "Enter limit for each category. Set 0 for categories with no limit.";
            // 
            // dgvCategoryBudgets
            // 
            this.dgvCategoryBudgets.AllowUserToAddRows = false;
            this.dgvCategoryBudgets.AllowUserToDeleteRows = false;
            this.dgvCategoryBudgets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCategoryBudgets.BackgroundColor = System.Drawing.Color.White;
            this.dgvCategoryBudgets.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCategoryBudgets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategoryBudgets.Location = new System.Drawing.Point(16, 65);
            this.dgvCategoryBudgets.Name = "dgvCategoryBudgets";
            this.dgvCategoryBudgets.RowHeadersVisible = false;
            this.dgvCategoryBudgets.RowTemplate.Height = 36;
            this.dgvCategoryBudgets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCategoryBudgets.Size = new System.Drawing.Size(608, 265);
            this.dgvCategoryBudgets.TabIndex = 2;
            // 
            // bottomBar
            // 
            this.bottomBar.BackColor = System.Drawing.Color.White;
            this.bottomBar.Controls.Add(this.btnSave);
            this.bottomBar.Controls.Add(this.btnCancel);
            this.bottomBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomBar.Location = new System.Drawing.Point(0, 560);
            this.bottomBar.Name = "bottomBar";
            this.bottomBar.Padding = new System.Windows.Forms.Padding(20, 12, 20, 12);
            this.bottomBar.Size = new System.Drawing.Size(680, 60);
            this.bottomBar.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(490, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(170, 36);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "💾 Save Limits";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(243, 244, 246);
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(75, 85, 99);
            this.btnCancel.Location = new System.Drawing.Point(375, 12);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 36);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // BudgetLimitForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(248, 249, 251);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(680, 620);
            this.Controls.Add(this.mainContainer);
            this.Controls.Add(this.bottomBar);
            this.Controls.Add(this.headerPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BudgetLimitForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Monthly Budget Setter";
            this.Load += new System.EventHandler(this.BudgetLimitForm_Load);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.mainContainer.ResumeLayout(false);
            this.pnlOverallCard.ResumeLayout(false);
            this.pnlOverallCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOverallLimit)).EndInit();
            this.pnlCategoryCard.ResumeLayout(false);
            this.pnlCategoryCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategoryBudgets)).EndInit();
            this.bottomBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel mainContainer;
        private System.Windows.Forms.Panel pnlOverallCard;
        private System.Windows.Forms.Label lblOverallTitle;
        private System.Windows.Forms.Label lblOverallDesc;
        private System.Windows.Forms.NumericUpDown numOverallLimit;
        private System.Windows.Forms.Label lblCurrency;
        private System.Windows.Forms.Panel pnlCategoryCard;
        private System.Windows.Forms.Label lblCategoryTitle;
        private System.Windows.Forms.Label lblCategoryDesc;
        private System.Windows.Forms.DataGridView dgvCategoryBudgets;
        private System.Windows.Forms.Panel bottomBar;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
