using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Npgsql;
using MoneyMap.Main;

namespace GP_1
{
    public partial class ShowExpense : Form
    {
        private DataTable dataTable = new DataTable();
        private readonly int currentUserId;

        public ShowExpense(int userId = 1)
        {
            InitializeComponent();
            currentUserId = userId;
            SetupCards();
            SetupGrid();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (this.Parent is Panel parentPanel && parentPanel.FindForm() is MainForm mainForm)
            {
                mainForm.CloseCurrentView();
            }
            else
            {
                this.Close();
            }
        }

        private void ShowExpense_Load(object sender, EventArgs e)
        {
            LoadCategoryCheckboxes();
            LoadTransactions("Expense");
        }

        private void SetupCards()
        {
            Panel[] cards = { cardTotal, cardExpense, cardAverage };
            Color[] accentColors = {
                UITheme.DarkNavy,
                UITheme.ExpenseRed,
                UITheme.BalanceBlue
            };

            for (int i = 0; i < cards.Length; i++)
            {
                int index = i;
                cards[i].Paint += (s, e) =>
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    Rectangle rect = cards[index].ClientRectangle;
                    rect.Width -= 1;
                    rect.Height -= 1;

                    using (Pen borderPen = new Pen(UITheme.BorderSubtle, 1))
                    {
                        e.Graphics.DrawRectangle(borderPen, rect);
                    }

                    using (SolidBrush accentBrush = new SolidBrush(accentColors[index]))
                    {
                        e.Graphics.FillRectangle(accentBrush, 0, 0, 4, cards[index].Height);
                    }
                };
            }

            filterPanel.Paint += (s, e) =>
            {
                Rectangle r = filterPanel.ClientRectangle;
                r.Width -= 1;
                r.Height -= 1;
                using (Pen p = new Pen(UITheme.BorderSubtle, 1))
                {
                    e.Graphics.DrawRectangle(p, r);
                }
            };

            gridPanel.Paint += (s, e) =>
            {
                Rectangle r = gridPanel.ClientRectangle;
                r.Width -= 1;
                r.Height -= 1;
                using (Pen p = new Pen(UITheme.BorderSubtle, 1))
                {
                    e.Graphics.DrawRectangle(p, r);
                }
            };
        }

        private void LoadCategoryCheckboxes()
        {
            flowCategories.Controls.Clear();
            var categories = new System.Collections.Generic.List<string>();

            try
            {
                using (NpgsqlConnection con = Database.CreateConnection())
                {
                    con.Open();
                    string sql = @"SELECT DISTINCT c.c_category_name 
                                   FROM t_category c 
                                   JOIN t_transaction_type tt ON c.c_type_id = tt.c_type_id 
                                   WHERE LOWER(tt.c_type_name) = 'expense' 
                                   ORDER BY c.c_category_name;";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
                    using (NpgsqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            string cat = rdr.GetString(0);
                            if (!string.IsNullOrWhiteSpace(cat) && !categories.Contains(cat))
                            {
                                categories.Add(cat);
                            }
                        }
                    }
                }
            }
            catch { }

            if (categories.Count == 0)
            {
                categories.AddRange(new[] { "Food", "Groceries", "Rent", "Utilities", "Transportation", "Entertainment", "Healthcare", "Shopping", "Education", "Travel", "Other Expense" });
            }

            foreach (var cat in categories)
            {
                CheckBox chk = new CheckBox
                {
                    Text = cat,
                    Tag = cat,
                    AutoSize = true,
                    Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                    ForeColor = Color.FromArgb(51, 65, 85),
                    Cursor = Cursors.Hand,
                    Margin = new Padding(3, 4, 10, 3),
                    UseVisualStyleBackColor = true
                };
                chk.CheckedChanged += CategoryCheckBox_CheckedChanged;
                flowCategories.Controls.Add(chk);
            }

            btnClearFilter.Visible = false;
        }

        private void CategoryCheckBox_CheckedChanged(object? sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void btnClearFilter_Click(object? sender, EventArgs e)
        {
            foreach (Control ctrl in flowCategories.Controls)
            {
                if (ctrl is CheckBox chk)
                {
                    chk.Checked = false;
                }
            }
            ApplyFilters();
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            if (dataTable == null || dataTable.DefaultView == null) return;

            var checkedCategories = new System.Collections.Generic.List<string>();
            foreach (Control ctrl in flowCategories.Controls)
            {
                if (ctrl is CheckBox chk && chk.Checked)
                {
                    checkedCategories.Add(chk.Tag?.ToString() ?? chk.Text);
                }
            }

            btnClearFilter.Visible = checkedCategories.Count > 0;

            var filterExpressions = new System.Collections.Generic.List<string>();

            // Category filter: If NO checkbox is selected, show all expense records!
            if (checkedCategories.Count > 0)
            {
                var catClauses = new System.Collections.Generic.List<string>();
                foreach (var cat in checkedCategories)
                {
                    catClauses.Add($"c_category_name = '{cat.Replace("'", "''")}'");
                }
                filterExpressions.Add("(" + string.Join(" OR ", catClauses) + ")");
            }

            // Search text filter
            string filter = searchBox.Text.Trim().Replace("'", "''");
            if (!string.IsNullOrWhiteSpace(filter))
            {
                filterExpressions.Add($"(c_category_name LIKE '%{filter}%' OR c_description LIKE '%{filter}%')");
            }

            if (filterExpressions.Count == 0)
            {
                dataTable.DefaultView.RowFilter = "";
            }
            else
            {
                dataTable.DefaultView.RowFilter = string.Join(" AND ", filterExpressions);
            }

            UpdateStats();
        }

        private void StatsPanel_Resize(object sender, EventArgs e)
        {
            int totalW = statsPanel.ClientSize.Width;
            int gap = 14;
            int cardW = Math.Max(180, (totalW - (gap * 2)) / 3);

            cardTotal.SetBounds(0, 10, cardW, 68);
            cardExpense.SetBounds(cardW + gap, 10, cardW, 68);
            cardAverage.SetBounds((cardW + gap) * 2, 10, totalW - ((cardW + gap) * 2), 68);
        }

        private void SetupGrid()
        {
            UITheme.StyleDataGridView(dgvExpense);

            dgvExpense.AutoGenerateColumns = false;
            dgvExpense.Columns.Clear();

            DataGridViewTextBoxColumn colDate = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DateFormatted",
                HeaderText = "DATE",
                FillWeight = 85
            };

            DataGridViewTextBoxColumn colCategory = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "c_category_name",
                HeaderText = "CATEGORY",
                FillWeight = 110
            };

            DataGridViewTextBoxColumn colDesc = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "c_description",
                HeaderText = "DESCRIPTION",
                FillWeight = 180
            };

            DataGridViewTextBoxColumn colAmount = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "AmountFormatted",
                HeaderText = "AMOUNT",
                FillWeight = 90
            };
            colAmount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colAmount.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvExpense.Columns.AddRange(colDate, colCategory, colDesc, colAmount);
            dgvExpense.CellFormatting += DgvExpense_CellFormatting;
        }

        private void DgvExpense_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvExpense.Rows.Count || e.CellStyle == null) return;

            if (e.ColumnIndex == 3 && e.Value != null)
            {
                e.CellStyle.Font = UITheme.BodySemibold;
                e.CellStyle.ForeColor = UITheme.ExpenseRed;
            }
        }

        private void LoadTransactions(string type)
        {
            dataTable = new DataTable();
            dataTable.Columns.Add("c_transaction_date", typeof(DateTime));
            dataTable.Columns.Add("DateFormatted", typeof(string));
            dataTable.Columns.Add("c_category_name", typeof(string));
            dataTable.Columns.Add("c_description", typeof(string));
            dataTable.Columns.Add("c_amount", typeof(decimal));
            dataTable.Columns.Add("AmountFormatted", typeof(string));

            try
            {
                using (NpgsqlConnection connection = Database.CreateConnection())
                using (NpgsqlCommand command = new NpgsqlCommand(
                    @"SELECT t.c_transaction_date, c.c_category_name, t.c_description, t.c_amount 
                      FROM t_transaction t 
                      JOIN t_category c ON c.c_category_id = t.c_category_id 
                      JOIN t_transaction_type tt ON tt.c_type_id = c.c_type_id 
                      WHERE tt.c_type_name = @type AND t.c_user_id = @userId 
                      ORDER BY t.c_transaction_date DESC, t.c_transaction_id DESC",
                    connection))
                {
                    command.Parameters.AddWithValue("type", type);
                    command.Parameters.AddWithValue("userId", currentUserId);
                    connection.Open();
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateOnly dOnly = reader.GetFieldValue<DateOnly>(0);
                            DateTime dt = dOnly.ToDateTime(TimeOnly.MinValue);
                            string cat = reader["c_category_name"].ToString() ?? "";
                            string desc = reader["c_description"].ToString() ?? "";
                            decimal amt = Convert.ToDecimal(reader["c_amount"]);

                            dataTable.Rows.Add(dt, dt.ToString("dd-MMM-yyyy"), cat, desc, amt, "-₹" + amt.ToString("N2"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading expense data: " + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            dgvExpense.DataSource = dataTable.DefaultView;
            ApplyFilters();
        }

        private void UpdateStats()
        {
            int count = dataTable.DefaultView.Count;
            decimal totalExpense = 0;

            foreach (DataRowView rowView in dataTable.DefaultView)
            {
                totalExpense += Convert.ToDecimal(rowView["c_amount"]);
            }

            decimal avg = count > 0 ? totalExpense / count : 0;

            lblTotalCount.Text = count.ToString();
            lblExpenseSum.Text = "-₹" + totalExpense.ToString("N2");
            lblAverageSum.Text = "₹" + avg.ToString("N2");

            emptyLabel.Visible = count == 0;
        }
    }
}
