using System;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;

namespace GP_1
{
    public partial class GraphView : Form
    {
        public GraphView()
        {
            InitializeComponent();
            dateTimePicker1.ValueChanged += MonthPicker_ValueChanged;
            DrawGraph();
        }

        private void MonthPicker_ValueChanged(object? sender, EventArgs e) => DrawGraph();

        private void DrawGraph()
        {
            decimal income = 0, expense = 0;
            using NpgsqlConnection connection = Database.CreateConnection();
            using NpgsqlCommand command = new NpgsqlCommand("SELECT tt.c_type_name, COALESCE(SUM(t.c_amount), 0) FROM t_transaction t JOIN t_category c ON c.c_category_id = t.c_category_id JOIN t_transaction_type tt ON tt.c_type_id = c.c_type_id WHERE date_trunc('month', t.c_transaction_date) = date_trunc('month', @month::date) GROUP BY tt.c_type_name", connection);
            command.Parameters.AddWithValue("month", dateTimePicker1.Value.Date);
            connection.Open();
            using NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader.GetString(0).Equals("Income", StringComparison.OrdinalIgnoreCase)) income = reader.GetDecimal(1);
                if (reader.GetString(0).Equals("Expense", StringComparison.OrdinalIgnoreCase)) expense = reader.GetDecimal(1);
            }
            decimal balance = income - expense;
            Bitmap bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using Graphics graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);
            decimal maximum = Math.Max(1, Math.Max(income, Math.Max(expense, Math.Abs(balance))));
            DrawBar(graphics, "Income", income, maximum, 60, Color.SeaGreen);
            DrawBar(graphics, "Expense", expense, maximum, 180, Color.IndianRed);
            DrawBar(graphics, "Balance", balance, maximum, 300, Color.SteelBlue);
            Image? oldImage = pictureBox1.Image;
            pictureBox1.Image = bitmap;
            oldImage?.Dispose();
        }

        private void DrawBar(Graphics graphics, string name, decimal value, decimal maximum, int x, Color color)
        {
            int height = (int)(Math.Abs(value) * 220 / maximum);
            using SolidBrush brush = new SolidBrush(color);
            graphics.FillRectangle(brush, x, 260 - height, 65, height);
            graphics.DrawString(name, Font, Brushes.Black, x, 270);
            graphics.DrawString(value.ToString("0.00"), Font, Brushes.Black, x, 35);
        }
    }
}
