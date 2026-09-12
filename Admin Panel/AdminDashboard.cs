using System;
using System.Drawing;
using System.Windows.Forms;
using MoneyMap.AdminPanel.Users;
using MoneyMap.AdminPanel.Transactions;
using MoneyMap.AdminPanel.Categories;
using MoneyMap.AdminPanel.TransactionTypes;
using MoneyMap.AdminPanel.Budgets;
using MoneyMap.AdminPanel.Settings;
using MoneyMap.AdminPanel.Analysis;

using MoneyMap.AdminPanel.Dashboard;

namespace MoneyMap.AdminPanel
{
    public partial class AdminDashboard : Form
    {
        #region Constructor

        public AdminDashboard()
        {
            InitializeComponent();

            SelectButton(btnDashboard);
            LoadControl(new DashboardControl());
        }

        #endregion

        #region Events

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnDashboard_Click(object sender, EventArgs e)
        {
            SelectButton(btnDashboard);
            LoadControl(new DashboardControl());
        }

        private void BtnUsers_Click(object sender, EventArgs e)
        {
            SelectButton(btnUsers);
            LoadControl(new UsersControl());
        }

        private void BtnTransactions_Click(object sender, EventArgs e)
        {
            SelectButton(btnTransactions);
            LoadControl(new TransactionsControl());
        }

        private void BtnCategories_Click(object sender, EventArgs e)
        {
            SelectButton(btnCategories);
            LoadControl(new CategoriesControl());
        }

        private void BtnTransactionTypes_Click(object sender, EventArgs e)
        {
            SelectButton(btnTransactionTypes);
            LoadControl(new TransactionTypesControl());
        }

        private void BtnBudgets_Click(object sender, EventArgs e)
        {
            SelectButton(btnBudgets);
            LoadControl(new BudgetsControl());
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            SelectButton(btnSettings);
            LoadControl(new SettingsControl());
        }

        private void BtnAnalysis_Click(object sender, EventArgs e)
        {
            SelectButton(btnAnalysis);
            LoadControl(new AnalysisControl());
        }

        #endregion

        #region Methods

        private void LoadControl(UserControl control)
        {
            pnlMain.Controls.Clear();
            control.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(control);
        }

        private void SelectButton(Button selectedButton)
        {
            foreach (Control control in pnlSidebar.Controls)
            {
                if (control is Button button)
                {
                    button.BackColor = Color.FromArgb(15, 23, 42);
                }
            }

            selectedButton.BackColor = Color.FromArgb(16, 185, 129);
        }

        #endregion
    }
}