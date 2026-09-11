using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace GP_1
{
    public partial class ShowAll : Form
    {
        public ShowAll()
        {
            InitializeComponent();
            InitializeListView();
            FetchDataInListView();
        }

        private void InitializeListView()
        {
            listView1.View = System.Windows.Forms.View.Details;
            listView1.Columns.Add("Date", 130);
            listView1.Columns.Add("Type", 120);
            listView1.Columns.Add("Category", 150);
            listView1.Columns.Add("Description", 250);
            listView1.Columns.Add("Amount", 130);
        }

        public void FetchDataInListView()
        {
            listView1.Items.Clear();
            using (NpgsqlConnection cn = Database.CreateConnection())
            using (
                NpgsqlCommand cmd = new NpgsqlCommand(
                    "SELECT t.c_transaction_date, tt.c_type_name, c.c_category_name, t.c_description, t.c_amount FROM t_transaction t JOIN t_category c ON c.c_category_id = t.c_category_id JOIN t_transaction_type tt ON tt.c_type_id = c.c_type_id ORDER BY t.c_transaction_date DESC, t.c_transaction_id DESC",
                    cn
                )
            )
            {
                try
                {
                    cn.Open();
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ListViewItem item = new ListViewItem(
                                reader.GetFieldValue<DateOnly>(0).ToString("dd-MMM-yyyy")
                            );
                            item.SubItems.Add(reader["c_type_name"].ToString());
                            item.SubItems.Add(reader["c_category_name"].ToString());
                            item.SubItems.Add(reader["c_description"].ToString());
                            item.SubItems.Add(Convert.ToDecimal(reader["c_amount"]).ToString("0.00"));

                            listView1.Items.Add(item);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Error loading data at ListView: " + ex.Message,
                        "ListView Load Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }
    }
}
