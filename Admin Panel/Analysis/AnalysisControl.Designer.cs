namespace MoneyMap.AdminPanel.Analysis
{
    partial class AnalysisControl
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;

        private System.Windows.Forms.Panel pnlUsers;
        private System.Windows.Forms.Panel pnlTransactions;
        private System.Windows.Forms.Panel pnlCategories;
        private System.Windows.Forms.Panel pnlBudgets;

        protected override void Dispose(bool disposing)
        {
            if (disposing &&
                (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle =
                new System.Windows.Forms.Label();

            this.lblSubtitle =
                new System.Windows.Forms.Label();

            this.pnlUsers =
                new System.Windows.Forms.Panel();

            this.pnlTransactions =
                new System.Windows.Forms.Panel();

            this.pnlCategories =
                new System.Windows.Forms.Panel();

            this.pnlBudgets =
                new System.Windows.Forms.Panel();

            this.SuspendLayout();

            #region Title

            this.lblTitle.AutoSize = true;

            this.lblTitle.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    20F,
                    System.Drawing.FontStyle.Bold);

            this.lblTitle.ForeColor =
                System.Drawing.Color.FromArgb(
                    15,
                    23,
                    42);

            this.lblTitle.Location =
                new System.Drawing.Point(
                    35,
                    20);

            this.lblTitle.Name =
                "lblTitle";

            this.lblTitle.Size =
                new System.Drawing.Size(
                    190,
                    37);

            this.lblTitle.TabIndex = 0;

            this.lblTitle.Text =
                "System Analysis";

            #endregion

            #region Subtitle

            this.lblSubtitle.AutoSize = true;

            this.lblSubtitle.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F);

            this.lblSubtitle.ForeColor =
                System.Drawing.Color.FromArgb(
                    100,
                    116,
                    139);

            this.lblSubtitle.Location =
                new System.Drawing.Point(
                    38,
                    58);

            this.lblSubtitle.Name =
                "lblSubtitle";

            this.lblSubtitle.Size =
                new System.Drawing.Size(
                    330,
                    15);

            this.lblSubtitle.TabIndex = 1;

            this.lblSubtitle.Text =
                "Overview of MoneyMap system activity";

            #endregion

            #region Users Panel

            this.pnlUsers.BackColor =
                System.Drawing.Color.White;

            this.pnlUsers.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.pnlUsers.Location =
                new System.Drawing.Point(
                    35,
                    90);

            this.pnlUsers.Name =
                "pnlUsers";

            this.pnlUsers.Size =
                new System.Drawing.Size(
                    500,
                    260);

            this.pnlUsers.TabIndex = 2;

            #endregion

            #region Transactions Panel

            this.pnlTransactions.BackColor =
                System.Drawing.Color.White;

            this.pnlTransactions.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.pnlTransactions.Location =
                new System.Drawing.Point(
                    555,
                    90);

            this.pnlTransactions.Name =
                "pnlTransactions";

            this.pnlTransactions.Size =
                new System.Drawing.Size(
                    500,
                    260);

            this.pnlTransactions.TabIndex = 3;

            #endregion

            #region Categories Panel

            this.pnlCategories.BackColor =
                System.Drawing.Color.White;

            this.pnlCategories.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.pnlCategories.Location =
                new System.Drawing.Point(
                    35,
                    370);

            this.pnlCategories.Name =
                "pnlCategories";

            this.pnlCategories.Size =
                new System.Drawing.Size(
                    500,
                    260);

            this.pnlCategories.TabIndex = 4;

            #endregion

            #region Budgets Panel

            this.pnlBudgets.BackColor =
                System.Drawing.Color.White;

            this.pnlBudgets.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.pnlBudgets.Location =
                new System.Drawing.Point(
                    555,
                    370);

            this.pnlBudgets.Name =
                "pnlBudgets";

            this.pnlBudgets.Size =
                new System.Drawing.Size(
                    500,
                    260);

            this.pnlBudgets.TabIndex = 5;

            #endregion

            #region UserControl

            this.AutoScaleDimensions =
                new System.Drawing.SizeF(
                    7F,
                    15F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.BackColor =
                System.Drawing.Color.FromArgb(
                    248,
                    250,
                    252);

            this.Controls.Add(
                this.pnlBudgets);

            this.Controls.Add(
                this.pnlCategories);

            this.Controls.Add(
                this.pnlTransactions);

            this.Controls.Add(
                this.pnlUsers);

            this.Controls.Add(
                this.lblSubtitle);

            this.Controls.Add(
                this.lblTitle);

            this.Name =
                "AnalysisControl";

            this.Size =
                new System.Drawing.Size(
                    1090,
                    660);

            this.ResumeLayout(false);
            this.PerformLayout();

            #endregion
        }

        #endregion
    }
}