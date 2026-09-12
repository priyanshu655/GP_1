using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Npgsql;
using MoneyMap.Main;

namespace GP_1
{
    public partial class ShowAll : Form
    {
        private DataTable dataTable = new DataTable();
        private readonly int currentUserId;

        public ShowAll(int userId = 1)
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

        private void ShowAll_Load(object sender, EventArgs e)
        {
            try
            {
                using (NpgsqlConnection con = Database.CreateConnection())
                using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT c_username FROM t_user WHERE c_user_id = @userId;", con))
                {
                    cmd.Parameters.AddWithValue("userId", currentUserId);
                    con.Open();
                    object? res = cmd.ExecuteScalar();
                    if (res != null && !string.IsNullOrWhiteSpace(res.ToString()))
                    {
                        subtitleLabel.Text = $"User: {res} | Comprehensive history of all income and expenses";
                    }
                }
            }
            catch { }

            LoadCategoryCheckboxes();
            FetchDataInListView();
        }

        private void SetupCards()
        {
            Panel[] cards = { cardTotal, cardIncome, cardExpense, cardBalance };
            Color[] accentColors = {
                UITheme.DarkNavy,
                UITheme.IncomeGreen,
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

                    // Left accent bar
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
                    using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT DISTINCT c_category_name FROM t_category ORDER BY c_category_name;", con))
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
                categories.AddRange(new[] { "Salary", "Freelance", "Investment", "Food", "Groceries", "Rent", "Utilities", "Transportation", "Entertainment", "Healthcare", "Shopping" });
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

            // Category filter: If NO checkbox is checked, show all! If 1+ checked, filter by them
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
                filterExpressions.Add($"(c_category_name LIKE '%{filter}%' OR c_description LIKE '%{filter}%' OR c_type_name LIKE '%{filter}%')");
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
            int cardW = Math.Max(160, (totalW - (gap * 3)) / 4);

            cardTotal.SetBounds(0, 10, cardW, 68);
            cardIncome.SetBounds(cardW + gap, 10, cardW, 68);
            cardExpense.SetBounds((cardW + gap) * 2, 10, cardW, 68);
            cardBalance.SetBounds((cardW + gap) * 3, 10, totalW - ((cardW + gap) * 3), 68);
        }

        private void SetupGrid()
        {
            UITheme.StyleDataGridView(dgvTransactions);

            dgvTransactions.AutoGenerateColumns = false;
            dgvTransactions.Columns.Clear();

            DataGridViewTextBoxColumn colDate = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DateFormatted",
                HeaderText = "DATE",
                FillWeight = 85
            };

            DataGridViewTextBoxColumn colType = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "c_type_name",
                HeaderText = "TYPE",
                FillWeight = 70
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

            dgvTransactions.Columns.AddRange(colDate, colType, colCategory, colDesc, colAmount);
            dgvTransactions.CellFormatting += DgvTransactions_CellFormatting;
        }

        private void DgvTransactions_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvTransactions.Rows.Count || e.CellStyle == null) return;

            var row = dgvTransactions.Rows[e.RowIndex];
            string type = row.Cells[1].Value?.ToString() ?? "";

            // Style amount
            if (e.ColumnIndex == 4 && e.Value != null)
            {
                e.CellStyle.Font = UITheme.BodySemibold;
                if (type.Equals("Income", StringComparison.OrdinalIgnoreCase))
                {
                    e.CellStyle.ForeColor = UITheme.IncomeGreenDark;
                }
                else
                {
                    e.CellStyle.ForeColor = UITheme.ExpenseRed;
                }
            }

            // Style Type
            if (e.ColumnIndex == 1 && e.Value != null)
            {
                e.CellStyle.Font = UITheme.SmallSemibold;
                if (type.Equals("Income", StringComparison.OrdinalIgnoreCase))
                {
                    e.CellStyle.ForeColor = UITheme.IncomeGreenDark;
                }
                else
                {
                    e.CellStyle.ForeColor = UITheme.ExpenseRed;
                }
            }
        }

        public void FetchDataInListView()
        {
            dataTable = new DataTable();
            dataTable.Columns.Add("c_transaction_date", typeof(DateTime));
            dataTable.Columns.Add("DateFormatted", typeof(string));
            dataTable.Columns.Add("c_type_name", typeof(string));
            dataTable.Columns.Add("c_category_name", typeof(string));
            dataTable.Columns.Add("c_description", typeof(string));
            dataTable.Columns.Add("c_amount", typeof(decimal));
            dataTable.Columns.Add("AmountFormatted", typeof(string));

            try
            {
                using (NpgsqlConnection cn = Database.CreateConnection())
                using (NpgsqlCommand cmd = new NpgsqlCommand(
                    @"SELECT t.c_transaction_date, tt.c_type_name, c.c_category_name, t.c_description, t.c_amount 
                      FROM t_transaction t 
                      JOIN t_category c ON c.c_category_id = t.c_category_id 
                      JOIN t_transaction_type tt ON tt.c_type_id = c.c_type_id 
                      WHERE t.c_user_id = @userId
                      ORDER BY t.c_transaction_date DESC, t.c_transaction_id DESC",
                    cn))
                {
                    cmd.Parameters.AddWithValue("userId", currentUserId);
                    cn.Open();
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateOnly dOnly = reader.GetFieldValue<DateOnly>(0);
                            DateTime dt = dOnly.ToDateTime(TimeOnly.MinValue);
                            string type = reader["c_type_name"].ToString() ?? "";
                            string cat = reader["c_category_name"].ToString() ?? "";
                            string desc = reader["c_description"].ToString() ?? "";
                            decimal amt = Convert.ToDecimal(reader["c_amount"]);

                            string amtStr = (type.Equals("Income", StringComparison.OrdinalIgnoreCase) ? "+₹" : "-₹") + amt.ToString("N2");

                            dataTable.Rows.Add(dt, dt.ToString("dd-MMM-yyyy"), type, cat, desc, amt, amtStr);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading data: " + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            dgvTransactions.DataSource = dataTable.DefaultView;
            ApplyFilters();
        }

        private void UpdateStats()
        {
            int count = dataTable.DefaultView.Count;
            decimal totalIncome = 0;
            decimal totalExpense = 0;

            foreach (DataRowView rowView in dataTable.DefaultView)
            {
                string type = rowView["c_type_name"].ToString() ?? "";
                decimal amt = Convert.ToDecimal(rowView["c_amount"]);
                if (type.Equals("Income", StringComparison.OrdinalIgnoreCase))
                {
                    totalIncome += amt;
                }
                else
                {
                    totalExpense += amt;
                }
            }

            decimal balance = totalIncome - totalExpense;

            lblTotalCount.Text = count.ToString();
            lblIncomeSum.Text = "+₹" + totalIncome.ToString("N2");
            lblExpenseSum.Text = "-₹" + totalExpense.ToString("N2");
            lblBalanceSum.Text = (balance >= 0 ? "+₹" : "-₹") + Math.Abs(balance).ToString("N2");
            lblBalanceSum.ForeColor = balance >= 0 ? UITheme.PrimaryGreenDark : UITheme.ExpenseRed;

            emptyLabel.Visible = count == 0;
        }
    }
}
