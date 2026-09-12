using System.Drawing;
using System.Windows.Forms;

namespace MoneyMap.AdminPanel.Dashboard
{
    partial class DashboardControl
    {
        private Label lblDashboardTitle;
        private Label lblDashboardSubtitle;

        private Panel pnlUsers;
        private Panel pnlTransactions;
        private Panel pnlCategories;
        private Panel pnlBudgets;

        private Label lblUsersTitle;
        private Label lblUsersCount;

        private Label lblTransactionsTitle;
        private Label lblTransactionsCount;

        private Label lblCategoriesTitle;
        private Label lblCategoriesCount;

        private Label lblBudgetsTitle;
        private Label lblBudgetsCount;

        #region Dispose

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #endregion

        private System.ComponentModel.IContainer components = null;

        #region InitializeComponent

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            lblDashboardTitle = new Label();
            lblDashboardSubtitle = new Label();

            pnlUsers = new Panel();
            pnlTransactions = new Panel();
            pnlCategories = new Panel();
            pnlBudgets = new Panel();

            lblUsersTitle = new Label();
            lblUsersCount = new Label();

            lblTransactionsTitle = new Label();
            lblTransactionsCount = new Label();

            lblCategoriesTitle = new Label();
            lblCategoriesCount = new Label();

            lblBudgetsTitle = new Label();
            lblBudgetsCount = new Label();

            SuspendLayout();

            // Dashboard Title
            lblDashboardTitle.AutoSize = true;
            lblDashboardTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblDashboardTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblDashboardTitle.Location = new Point(40, 30);
            lblDashboardTitle.Text = "Dashboard";

            // Dashboard Subtitle
            lblDashboardSubtitle.AutoSize = true;
            lblDashboardSubtitle.Font = new Font("Segoe UI", 10F);
            lblDashboardSubtitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblDashboardSubtitle.Location = new Point(42, 75);
            lblDashboardSubtitle.Text = "Overview of your MoneyMap system";

            // Users Panel
            pnlUsers.BackColor = Color.FromArgb(239, 246, 255);
            pnlUsers.BorderStyle = BorderStyle.FixedSingle;
            pnlUsers.Location = new Point(40, 125);
            pnlUsers.Size = new Size(270, 160);

            lblUsersTitle.AutoSize = true;
            lblUsersTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblUsersTitle.ForeColor = Color.FromArgb(71, 85, 105);
            lblUsersTitle.Location = new Point(25, 25);
            lblUsersTitle.Text = "Total Users";

            lblUsersCount.AutoSize = true;
            lblUsersCount.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblUsersCount.ForeColor = Color.FromArgb(15, 23, 42);
            lblUsersCount.Location = new Point(25, 55);

            pnlUsers.Controls.Add(lblUsersTitle);
            pnlUsers.Controls.Add(lblUsersCount);

            // Transactions Panel
            pnlTransactions.BackColor = Color.FromArgb(236, 253, 245);
            pnlTransactions.BorderStyle = BorderStyle.FixedSingle;
            pnlTransactions.Location = new Point(330, 125);
            pnlTransactions.Size = new Size(270, 160);

            lblTransactionsTitle.AutoSize = true;
            lblTransactionsTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTransactionsTitle.ForeColor = Color.FromArgb(71, 85, 105);
            lblTransactionsTitle.Location = new Point(25, 25);
            lblTransactionsTitle.Text = "Total Transactions";

            lblTransactionsCount.AutoSize = true;
            lblTransactionsCount.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblTransactionsCount.ForeColor = Color.FromArgb(15, 23, 42);
            lblTransactionsCount.Location = new Point(25, 55);

            pnlTransactions.Controls.Add(lblTransactionsTitle);
            pnlTransactions.Controls.Add(lblTransactionsCount);

            // Categories Panel
            pnlCategories.BackColor = Color.FromArgb(245, 243, 255);
            pnlCategories.BorderStyle = BorderStyle.FixedSingle;
            pnlCategories.Location = new Point(620, 125);
            pnlCategories.Size = new Size(270, 160);

            lblCategoriesTitle.AutoSize = true;
            lblCategoriesTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblCategoriesTitle.ForeColor = Color.FromArgb(71, 85, 105);
            lblCategoriesTitle.Location = new Point(25, 25);
            lblCategoriesTitle.Text = "Total Categories";

            lblCategoriesCount.AutoSize = true;
            lblCategoriesCount.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblCategoriesCount.ForeColor = Color.FromArgb(15, 23, 42);
            lblCategoriesCount.Location = new Point(25, 55);

            pnlCategories.Controls.Add(lblCategoriesTitle);
            pnlCategories.Controls.Add(lblCategoriesCount);

            // Budgets Panel
            pnlBudgets.BackColor = Color.FromArgb(255, 247, 237);
            pnlBudgets.BorderStyle = BorderStyle.FixedSingle;
            pnlBudgets.Location = new Point(910, 125);
            pnlBudgets.Size = new Size(270, 160);

            lblBudgetsTitle.AutoSize = true;
            lblBudgetsTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblBudgetsTitle.ForeColor = Color.FromArgb(71, 85, 105);
            lblBudgetsTitle.Location = new Point(25, 25);
            lblBudgetsTitle.Text = "Total Budgets";

            lblBudgetsCount.AutoSize = true;
            lblBudgetsCount.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblBudgetsCount.ForeColor = Color.FromArgb(15, 23, 42);
            lblBudgetsCount.Location = new Point(25, 55);

            pnlBudgets.Controls.Add(lblBudgetsTitle);
            pnlBudgets.Controls.Add(lblBudgetsCount);

            // DashboardControl
            BackColor = Color.FromArgb(248, 250, 252);
            Controls.Add(lblDashboardTitle);
            Controls.Add(lblDashboardSubtitle);
            Controls.Add(pnlUsers);
            Controls.Add(pnlTransactions);
            Controls.Add(pnlCategories);
            Controls.Add(pnlBudgets);
            Dock = DockStyle.Fill;
            Name = "DashboardControl";
            Size = new Size(1430, 780);

            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}