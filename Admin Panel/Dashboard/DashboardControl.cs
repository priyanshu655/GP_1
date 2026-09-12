using System;
using System.Windows.Forms;

using Npgsql;

namespace MoneyMap.AdminPanel.Dashboard
{
    public partial class DashboardControl : UserControl
    {
        #region Constructor

        public DashboardControl()
        {
            InitializeComponent();
            LoadDashboard();
        }

        #endregion

        #region Methods

        private void LoadDashboard()
        {
            using (NpgsqlConnection connection = GP_1.Database.CreateConnection())
            {
                connection.Open();

                lblUsersCount.Text = GetCount(connection, "t_user").ToString();
                lblTransactionsCount.Text = GetCount(connection, "t_transaction").ToString();
                lblCategoriesCount.Text = GetCount(connection, "t_category").ToString();
                lblBudgetsCount.Text = GetCount(connection, "t_budget").ToString();
            }
        }

        private int GetCount(NpgsqlConnection connection, string tableName)
        {
            string query = "SELECT COUNT(*) FROM " + tableName;

            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
            {
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        #endregion
    }
}