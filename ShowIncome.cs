using System;
using System.Windows.Forms;
using Npgsql;

namespace GP_1
{
    public partial class ShowIncome : Form
    {
        public ShowIncome()
        {
            InitializeComponent();
            LoadTransactions("Income");
        }

        private void LoadTransactions(string type)
        {
            listView1.View = System.Windows.Forms.View.Details;
            listView1.Columns.Add("Date", 130);
            listView1.Columns.Add("Category", 150);
            listView1.Columns.Add("Description", 250);
            listView1.Columns.Add("Amount", 130);
            using NpgsqlConnection connection = Database.CreateConnection();
            using NpgsqlCommand command = new NpgsqlCommand("SELECT t.c_transaction_date, c.c_category_name, t.c_description, t.c_amount FROM t_transaction t JOIN t_category c ON c.c_category_id = t.c_category_id JOIN t_transaction_type tt ON tt.c_type_id = c.c_type_id WHERE tt.c_type_name = @type ORDER BY t.c_transaction_date DESC", connection);
            command.Parameters.AddWithValue("type", type);
            connection.Open();
            using NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem item = new ListViewItem(reader.GetFieldValue<DateOnly>(0).ToString("dd-MMM-yyyy"));
                item.SubItems.Add(reader["c_category_name"].ToString());
                item.SubItems.Add(reader["c_description"].ToString());
                item.SubItems.Add(Convert.ToDecimal(reader["c_amount"]).ToString("0.00"));
                listView1.Items.Add(item);
            }
        }
    }
}
