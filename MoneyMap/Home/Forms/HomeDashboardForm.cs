using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using GP_1;
using GP_1.Forms;
using MoneyMap.Budget.Forms;
using MoneyMap.Budget.Services;
using MoneyMap.Main;
using Npgsql;

namespace MoneyMap.Home.Forms
{
    public partial class HomeDashboardForm : Form
    {
        private readonly int userId;
        private BudgetSummary currentSummary = new BudgetSummary();

        public HomeDashboardForm(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            SetupStyling();
            SetupRecentGrid();
        }

        private void HomeDashboardForm_Load(object sender, EventArgs e)
        {
            LoadUserData();
            RefreshDashboard();
        }

        private void SetupStyling()
        {
            Panel[] cards = { cardBalance, cardIncome, cardExpense, cardBudget };
            Color[] accentColors = {
                UITheme.BalanceBlue,
                UITheme.IncomeGreen,
                UITheme.ExpenseRed,
                UITheme.DarkNavy
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

            pnlAlertBanner.Paint += (s, e) =>
            {
                using var p = new Pen(Color.FromArgb(252, 165, 165), 1);
                e.Graphics.DrawRectangle(p, 0, 0, pnlAlertBanner.Width - 1, pnlAlertBanner.Height - 1);
            };

            budgetCard.Paint += (s, e) =>
            {
                using var p = new Pen(UITheme.BorderSubtle, 1);
                e.Graphics.DrawRectangle(p, 0, 0, budgetCard.Width - 1, budgetCard.Height - 1);
            };

            recentCard.Paint += (s, e) =>
            {
                using var p = new Pen(UITheme.BorderSubtle, 1);
                e.Graphics.DrawRectangle(p, 0, 0, recentCard.Width - 1, recentCard.Height - 1);
            };

            pnlOverallProgress.Paint += PnlOverallProgress_Paint;
        }

        private void StatsPanel_Resize(object sender, EventArgs e)
        {
            int totalW = statsPanel.ClientSize.Width;
            int gap = 14;
            int cardW = Math.Max(160, (totalW - (gap * 3)) / 4);

            cardBalance.SetBounds(0, 10, cardW, 68);
            cardIncome.SetBounds(cardW + gap, 10, cardW, 68);
            cardExpense.SetBounds((cardW + gap) * 2, 10, cardW, 68);
            cardBudget.SetBounds((cardW + gap) * 3, 10, totalW - ((cardW + gap) * 3), 68);
        }

        private void SetupRecentGrid()
        {
            UITheme.StyleDataGridView(dgvRecentTransactions);
            dgvRecentTransactions.AutoGenerateColumns = false;
            dgvRecentTransactions.Columns.Clear();
            dgvRecentTransactions.RowTemplate.Height = 34;

            var colDate = new DataGridViewTextBoxColumn
            {
                Name = "Date",
                HeaderText = "DATE",
                FillWeight = 85
            };

            var colCat = new DataGridViewTextBoxColumn
            {
                Name = "Category",
                HeaderText = "CATEGORY",
                FillWeight = 110
            };
            colCat.DefaultCellStyle.Font = UITheme.BodySemibold;

            var colDesc = new DataGridViewTextBoxColumn
            {
                Name = "Description",
                HeaderText = "NOTE",
                FillWeight = 140
            };

            var colAmt = new DataGridViewTextBoxColumn
            {
                Name = "Amount",
                HeaderText = "AMOUNT",
                FillWeight = 95
            };
            colAmt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colAmt.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvRecentTransactions.Columns.AddRange(colDate, colCat, colDesc, colAmt);
            dgvRecentTransactions.CellFormatting += DgvRecentTransactions_CellFormatting;
        }

        private void DgvRecentTransactions_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvRecentTransactions.Rows.Count || e.CellStyle == null) return;

            var row = dgvRecentTransactions.Rows[e.RowIndex];
            string type = row.Tag?.ToString() ?? "";

            if (e.ColumnIndex == 3 && e.Value != null)
            {
                e.CellStyle.Font = UITheme.BodySemibold;
                e.CellStyle.ForeColor = type.Equals("Income", StringComparison.OrdinalIgnoreCase)
                    ? UITheme.IncomeGreenDark
                    : UITheme.ExpenseRed;
            }
        }

        private void LoadUserData()
        {
            try
            {
                using var con = Database.CreateConnection();
                using var cmd = new NpgsqlCommand("SELECT c_username FROM t_user WHERE c_user_id = @userId;", con);
                cmd.Parameters.AddWithValue("userId", userId);
                con.Open();
                object? res = cmd.ExecuteScalar();
                if (res != null && !string.IsNullOrWhiteSpace(res.ToString()))
                {
                    lblGreeting.Text = $"Welcome back, {res}! 👋";
                }
            }
            catch { }

            DateTime now = DateTime.Now;
            lblSubtitle.Text = $"{now:MMMM yyyy} • Financial overview & monthly budget limits";
        }

        public void RefreshDashboard()
        {
            currentSummary = BudgetService.GetBudgetSummary(userId);

            // 1. Stat Cards
            lblBalanceValue.Text = (currentSummary.TotalBalance >= 0 ? "₹" : "-₹") + Math.Abs(currentSummary.TotalBalance).ToString("N2");
            lblBalanceValue.ForeColor = currentSummary.TotalBalance >= 0 ? UITheme.PrimaryGreenDark : UITheme.ExpenseRed;

            lblIncomeValue.Text = "+₹" + currentSummary.ThisMonthIncome.ToString("N2");
            lblExpenseValue.Text = "-₹" + currentSummary.ThisMonthExpense.ToString("N2");

            if (currentSummary.HasOverallLimit)
            {
                lblBudgetValue.Text = $"₹{currentSummary.OverallSpent:N0} / ₹{currentSummary.OverallLimit:N0}";
                lblBudgetValue.ForeColor = currentSummary.IsOverallExceeded ? UITheme.ExpenseRed :
                                          currentSummary.IsOverallWarning ? Color.FromArgb(217, 119, 6) : UITheme.DarkNavy;
            }
            else
            {
                lblBudgetValue.Text = "No Limit Set";
                lblBudgetValue.ForeColor = Color.FromArgb(107, 114, 128);
            }

            // 2. Alert Banner
            if (currentSummary.Alerts.Count > 0)
            {
                pnlAlertBanner.Visible = true;
                lblAlertText.Text = currentSummary.Alerts[0] + (currentSummary.Alerts.Count > 1 ? $" (+{currentSummary.Alerts.Count - 1} more alert{(currentSummary.Alerts.Count > 2 ? "s" : "")})" : "");
            }
            else
            {
                pnlAlertBanner.Visible = false;
            }

            // 3. Overall Progress
            if (currentSummary.HasOverallLimit)
            {
                decimal remaining = currentSummary.OverallLimit - currentSummary.OverallSpent;
                string remText = remaining >= 0 ? $"Remaining: ₹{remaining:N2}" : $"Over limit by: ₹{Math.Abs(remaining):N2}";
                lblOverallProgressText.Text = $"Overall Spent: ₹{currentSummary.OverallSpent:N2} / Limit: ₹{currentSummary.OverallLimit:N2} ({currentSummary.OverallPercentage}%) • {remText}";
            }
            else
            {
                lblOverallProgressText.Text = $"Overall Spent This Month: ₹{currentSummary.OverallSpent:N2} (No monthly ceiling configured)";
            }
            pnlOverallProgress.Invalidate();

            // 4. Category Budget Items
            PopulateCategoryBudgets();

            // 5. Recent Transactions
            LoadRecentTransactions();
        }

        private void PnlOverallProgress_Paint(object? sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            int w = pnlOverallProgress.Width;
            int h = pnlOverallProgress.Height;

            // Background track
            using (var bgBrush = new SolidBrush(Color.FromArgb(243, 244, 246)))
            {
                e.Graphics.FillRectangle(bgBrush, 0, 0, w, h);
            }

            if (!currentSummary.HasOverallLimit || currentSummary.OverallLimit <= 0) return;

            float ratio = Math.Min(1.0f, (float)(currentSummary.OverallSpent / currentSummary.OverallLimit));
            int fillW = (int)(w * ratio);

            Color barColor;
            if (currentSummary.IsOverallExceeded)
            {
                barColor = Color.FromArgb(239, 68, 68); // Red
            }
            else if (currentSummary.IsOverallWarning)
            {
                barColor = Color.FromArgb(245, 158, 11); // Amber
            }
            else
            {
                barColor = Color.FromArgb(37, 99, 235); // Blue
            }

            if (fillW > 0)
            {
                using (var barBrush = new SolidBrush(barColor))
                {
                    e.Graphics.FillRectangle(barBrush, 0, 0, fillW, h);
                }
            }
        }

        private void PopulateCategoryBudgets()
        {
            flowCategoryBudgets.Controls.Clear();

            if (currentSummary.CategoryBudgets.Count == 0)
            {
                var lblEmpty = new Label
                {
                    Text = "No expense categories found.",
                    Font = new Font("Segoe UI", 9F),
                    ForeColor = Color.FromArgb(156, 163, 175),
                    AutoSize = true,
                    Margin = new Padding(8, 16, 8, 8)
                };
                flowCategoryBudgets.Controls.Add(lblEmpty);
                return;
            }

            int itemWidth = Math.Max(200, flowCategoryBudgets.ClientSize.Width - 12);

            foreach (var cat in currentSummary.CategoryBudgets)
            {
                var rowPanel = new Panel
                {
                    Width = itemWidth,
                    Height = 44,
                    Margin = new Padding(0, 0, 0, 8),
                    BackColor = Color.FromArgb(249, 250, 251)
                };

                // Category Name + Limit status text
                string statusText = cat.HasLimit
                    ? $"Spent: ₹{cat.CurrentSpent:N0} / ₹{cat.MonthlyLimit:N0} ({cat.Percentage}%)"
                    : $"Spent: ₹{cat.CurrentSpent:N0} (No limit)";

                var lblName = new Label
                {
                    Text = cat.CategoryName,
                    Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(31, 41, 55),
                    Location = new Point(8, 4),
                    AutoSize = true
                };

                var lblStatus = new Label
                {
                    Text = statusText,
                    Font = new Font("Segoe UI", 8F),
                    ForeColor = cat.IsExceeded ? Color.FromArgb(239, 68, 68) :
                                cat.IsWarning ? Color.FromArgb(217, 119, 6) : Color.FromArgb(107, 114, 128),
                    Anchor = AnchorStyles.Top | AnchorStyles.Right,
                    Location = new Point(rowPanel.Width - 230, 4),
                    Size = new Size(220, 16),
                    TextAlign = ContentAlignment.TopRight
                };

                // Mini Progress Bar Panel
                var miniProgress = new Panel
                {
                    Location = new Point(8, 24),
                    Size = new Size(rowPanel.Width - 16, 8),
                    BackColor = Color.FromArgb(229, 231, 235),
                    Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
                };

                miniProgress.Paint += (s, e) =>
                {
                    if (!cat.HasLimit || cat.MonthlyLimit <= 0) return;
                    float r = Math.Min(1.0f, (float)(cat.CurrentSpent / cat.MonthlyLimit));
                    int pW = (int)(miniProgress.Width * r);
                    Color col = cat.IsExceeded ? Color.FromArgb(239, 68, 68) :
                                cat.IsWarning ? Color.FromArgb(245, 158, 11) : Color.FromArgb(16, 185, 129);

                    if (pW > 0)
                    {
                        using var br = new SolidBrush(col);
                        e.Graphics.FillRectangle(br, 0, 0, pW, miniProgress.Height);
                    }
                };

                rowPanel.Controls.Add(lblName);
                rowPanel.Controls.Add(lblStatus);
                rowPanel.Controls.Add(miniProgress);

                flowCategoryBudgets.Controls.Add(rowPanel);
            }
        }

        private void LoadRecentTransactions()
        {
            dgvRecentTransactions.Rows.Clear();
            try
            {
                using var conn = Database.CreateConnection();
                conn.Open();
                string sql = @"
                    SELECT t.c_transaction_date, tt.c_type_name, c.c_category_name, t.c_description, t.c_amount
                    FROM t_transaction t
                    JOIN t_category c ON c.c_category_id = t.c_category_id
                    JOIN t_transaction_type tt ON tt.c_type_id = c.c_type_id
                    WHERE t.c_user_id = @userId
                    ORDER BY t.c_transaction_date DESC, t.c_transaction_id DESC
                    LIMIT 7;";

                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("userId", userId);
                using var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    DateOnly dOnly = rdr.GetFieldValue<DateOnly>(0);
                    DateTime dt = dOnly.ToDateTime(TimeOnly.MinValue);
                    string type = rdr.GetString(1);
                    string cat = rdr.GetString(2);
                    string desc = rdr.IsDBNull(3) ? "" : rdr.GetString(3);
                    decimal amt = rdr.GetDecimal(4);

                    string amtFormatted = (type.Equals("Income", StringComparison.OrdinalIgnoreCase) ? "+₹" : "-₹") + amt.ToString("N2");

                    int idx = dgvRecentTransactions.Rows.Add(
                        dt.ToString("dd-MMM"),
                        cat,
                        desc,
                        amtFormatted
                    );
                    dgvRecentTransactions.Rows[idx].Tag = type;
                }
            }
            catch { }
        }

        private void btnAddTransaction_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmTransactionInput(userId))
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    RefreshDashboard();
                }
            }
        }

        private void btnSetBudget_Click(object sender, EventArgs e)
        {
            using (var budgetForm = new BudgetLimitForm(userId))
            {
                if (budgetForm.ShowDialog(this) == DialogResult.OK)
                {
                    RefreshDashboard();
                }
            }
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            if (this.Parent is Panel pnl && pnl.FindForm() is MainForm mainForm)
            {
                mainForm.LoadChildForm(new ShowAll(userId));
            }
        }

        private void btnDismissAlert_Click(object sender, EventArgs e)
        {
            pnlAlertBanner.Visible = false;
        }
    }
}
