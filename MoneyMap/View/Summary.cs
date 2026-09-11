using System;
using System.Windows.Forms;
using Npgsql;

namespace GP_1
{
    public partial class Summary : Form
    {
        public Summary()
        {
            InitializeComponent();
            monthPicker.ValueChanged += MonthPicker_ValueChanged;
            LoadSummary();
        }

        private void MonthPicker_ValueChanged(object? sender, EventArgs e) => LoadSummary();

        private void LoadSummary()
        {
            decimal income = 0, expense = 0;
            using NpgsqlConnection connection = Database.CreateConnection();
            using NpgsqlCommand command = new NpgsqlCommand("SELECT tt.c_type_name, COALESCE(SUM(t.c_amount), 0) FROM t_transaction t JOIN t_category c ON c.c_category_id = t.c_category_id JOIN t_transaction_type tt ON tt.c_type_id = c.c_type_id WHERE date_trunc('month', t.c_transaction_date) = date_trunc('month', @month::date) GROUP BY tt.c_type_name", connection);
            command.Parameters.AddWithValue("month", monthPicker.Value.Date);
            connection.Open();
            using NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader.GetString(0).Equals("Income", StringComparison.OrdinalIgnoreCase)) income = reader.GetDecimal(1);
                if (reader.GetString(0).Equals("Expense", StringComparison.OrdinalIgnoreCase)) expense = reader.GetDecimal(1);
            }
            decimal balance = income - expense;
            decimal maximum = Math.Max(1, Math.Max(income, Math.Max(expense, Math.Abs(balance))));
            SetValue(incomeLabel, incomeBar, income, maximum);
            SetValue(expenseLabel, expenseBar, expense, maximum);
            SetValue(balanceLabel, balanceBar, balance, maximum);
        }

        private static void SetValue(Label label, ProgressBar bar, decimal value, decimal maximum)
        {
            label.Text = value.ToString("0.00");
            bar.Value = (int)Math.Min(100, Math.Max(0, Math.Round(Math.Abs(value) * 100 / maximum)));
        }
    }
}
