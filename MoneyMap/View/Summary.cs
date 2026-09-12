using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Npgsql;
using MoneyMap.Main;

namespace GP_1
{
    public partial class Summary : Form
    {
        private readonly int currentUserId;
        private decimal currentIncome = 0;
        private decimal currentExpense = 0;

        public Summary(int userId = 1)
        {
            InitializeComponent();
            this.currentUserId = userId;
            SetupCards();
            monthPicker.ValueChanged += MonthPicker_ValueChanged;
            progressCanvas.Paint += ProgressCanvas_Paint;
            progressCanvas.Resize += (s, e) => progressCanvas.Invalidate();
        }

        private void Summary_Load(object sender, EventArgs e)
        {
            LoadSummary();
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

        private void SetupCards()
        {
            Panel[] cards = { cardIncome, cardExpense, cardBalance };
            Color[] accentColors = {
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

                    using (SolidBrush accentBrush = new SolidBrush(accentColors[index]))
                    {
                        e.Graphics.FillRectangle(accentBrush, 0, 0, 4, cards[index].Height);
                    }
                };
            }

            analyticsCard.Paint += (s, e) =>
            {
                Rectangle r = analyticsCard.ClientRectangle;
                r.Width -= 1;
                r.Height -= 1;
                using (Pen p = new Pen(UITheme.BorderSubtle, 1))
                {
                    e.Graphics.DrawRectangle(p, r);
                }
            };
        }

        private void CardsPanel_Resize(object sender, EventArgs e)
        {
            int totalW = cardsPanel.ClientSize.Width;
            int gap = 16;
            int cardW = Math.Max(200, (totalW - (gap * 2)) / 3);

            cardIncome.SetBounds(0, 12, cardW, 115);
            cardExpense.SetBounds(cardW + gap, 12, cardW, 115);
            cardBalance.SetBounds((cardW + gap) * 2, 12, totalW - ((cardW + gap) * 2), 115);
        }

        private void MonthPicker_ValueChanged(object? sender, EventArgs e)
        {
            LoadSummary();
        }

        private void LoadSummary()
        {
            currentIncome = 0;
            currentExpense = 0;

            try
            {
                using (NpgsqlConnection connection = Database.CreateConnection())
                using (NpgsqlCommand command = new NpgsqlCommand(
                    @"SELECT tt.c_type_name, COALESCE(SUM(t.c_amount), 0) 
                      FROM t_transaction t 
                      JOIN t_category c ON c.c_category_id = t.c_category_id 
                      JOIN t_transaction_type tt ON tt.c_type_id = c.c_type_id 
                      WHERE date_trunc('month', t.c_transaction_date) = date_trunc('month', @month::date) 
                        AND t.c_user_id = @userId
                      GROUP BY tt.c_type_name",
                    connection))
                {
                    command.Parameters.AddWithValue("month", monthPicker.Value.Date);
                    command.Parameters.AddWithValue("userId", currentUserId);
                    connection.Open();
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string type = reader.GetString(0);
                            decimal sum = reader.GetDecimal(1);
                            if (type.Equals("Income", StringComparison.OrdinalIgnoreCase)) currentIncome = sum;
                            if (type.Equals("Expense", StringComparison.OrdinalIgnoreCase)) currentExpense = sum;
                        }
                    }
                }
            }
            catch { }

            decimal balance = currentIncome - currentExpense;
            decimal expenseRate = currentIncome > 0 ? (currentExpense / currentIncome) * 100 : (currentExpense > 0 ? 100 : 0);
            decimal savingsRate = currentIncome > 0 ? (balance / currentIncome) * 100 : 0;

            lblIncomeVal.Text = "+₹" + currentIncome.ToString("N2");
            lblExpenseVal.Text = "-₹" + currentExpense.ToString("N2");
            lblBalanceVal.Text = (balance >= 0 ? "+₹" : "-₹") + Math.Abs(balance).ToString("N2");
            lblBalanceVal.ForeColor = balance >= 0 ? UITheme.PrimaryGreenDark : UITheme.ExpenseRed;

            lblExpenseSub.Text = $"{expenseRate:0.#}% of monthly income";
            lblBalanceSub.Text = $"Savings rate: {Math.Max(0, savingsRate):0.#}%";

            // Update health badge
            if (currentIncome == 0 && currentExpense == 0)
            {
                healthBadge.Text = "Status: No Activity Recorded";
                healthBadge.BackColor = Color.FromArgb(241, 245, 249);
                healthBadge.ForeColor = UITheme.TextSecondary;
            }
            else if (balance >= 0 && savingsRate >= 20)
            {
                healthBadge.Text = $"Status: Excellent ({savingsRate:0.#}% Saved)";
                healthBadge.BackColor = UITheme.IncomeBg;
                healthBadge.ForeColor = UITheme.IncomeGreenDark;
            }
            else if (balance >= 0)
            {
                healthBadge.Text = $"Status: Moderate ({savingsRate:0.#}% Saved)";
                healthBadge.BackColor = Color.FromArgb(254, 249, 231);
                healthBadge.ForeColor = Color.FromArgb(217, 119, 6);
            }
            else
            {
                healthBadge.Text = "Status: Deficit (Expenses exceed Income)";
                healthBadge.BackColor = UITheme.ExpenseBg;
                healthBadge.ForeColor = UITheme.ExpenseRed;
            }

            progressCanvas.Invalidate();
        }

        private void ProgressCanvas_Paint(object? sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Color.White);

            int w = progressCanvas.Width;
            int h = progressCanvas.Height;
            if (w < 100 || h < 100) return;

            decimal totalVolume = currentIncome + currentExpense;
            decimal maximum = Math.Max(1, Math.Max(currentIncome, Math.Max(currentExpense, Math.Abs(currentIncome - currentExpense))));

            int startY = 10;
            int barHeight = 16;
            int rowSpacing = 54;

            // 1. Income Progress Bar
            DrawStyledProgressBar(g, "Income Target", currentIncome, maximum, UITheme.IncomeGreen, UITheme.IncomeGreenDark, 0, startY, w, barHeight);

            // 2. Expense Progress Bar
            DrawStyledProgressBar(g, "Monthly Spending", currentExpense, maximum, UITheme.ExpenseRed, UITheme.ExpenseRedDark, 0, startY + rowSpacing, w, barHeight);

            // 3. Net Savings Progress Bar
            decimal net = currentIncome - currentExpense;
            Color netColor = net >= 0 ? UITheme.BalanceBlue : UITheme.ExpenseRed;
            Color netColorDark = net >= 0 ? UITheme.BalanceBlueDark : UITheme.ExpenseRedDark;
            DrawStyledProgressBar(g, "Net Savings / Capital Growth", Math.Max(0, net), maximum, netColor, netColorDark, 0, startY + (rowSpacing * 2), w, barHeight);

            // 4. Combined Split Distribution Bar
            int splitY = startY + (rowSpacing * 3);
            if (splitY + 30 <= h)
            {
                DrawSplitDistributionBar(g, 0, splitY, w, 20);
            }
        }

        private void DrawStyledProgressBar(Graphics g, string label, decimal val, decimal max, Color c1, Color c2, int x, int y, int totalW, int barH)
        {
            using (Font titleFont = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold))
            using (Font valFont = new Font("Segoe UI", 9.5F, FontStyle.Regular))
            {
                g.DrawString(label, titleFont, new SolidBrush(UITheme.TextPrimary), x, y);
                string valText = "₹" + val.ToString("N2");
                SizeF valSize = g.MeasureString(valText, valFont);
                g.DrawString(valText, valFont, new SolidBrush(UITheme.TextSecondary), totalW - valSize.Width, y);
            }

            int barY = y + 24;
            Rectangle trackRect = new Rectangle(x, barY, totalW, barH);

            // Background Track
            using (GraphicsPath trackPath = UITheme.GetRoundedPath(trackRect, barH / 2))
            using (SolidBrush trackBrush = new SolidBrush(Color.FromArgb(241, 245, 249)))
            {
                g.FillPath(trackBrush, trackPath);
            }

            // Fill Bar
            int fillW = max > 0 ? (int)((val / max) * totalW) : 0;
            fillW = Math.Max(0, Math.Min(totalW, fillW));

            if (fillW > barH)
            {
                Rectangle fillRect = new Rectangle(x, barY, fillW, barH);
                using (GraphicsPath fillPath = UITheme.GetRoundedPath(fillRect, barH / 2))
                using (LinearGradientBrush fillBrush = new LinearGradientBrush(fillRect, c1, c2, LinearGradientMode.Horizontal))
                {
                    g.FillPath(fillBrush, fillPath);
                }
            }
        }

        private void DrawSplitDistributionBar(Graphics g, int x, int y, int totalW, int barH)
        {
            using (Font lblFont = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold))
            {
                g.DrawString("Cash Flow Distribution (Spent vs Saved)", lblFont, new SolidBrush(UITheme.TextPrimary), x, y);
            }

            int barY = y + 24;
            Rectangle trackRect = new Rectangle(x, barY, totalW, barH);

            if (currentIncome <= 0)
            {
                using (GraphicsPath trackPath = UITheme.GetRoundedPath(trackRect, barH / 2))
                using (SolidBrush trackBrush = new SolidBrush(Color.FromArgb(241, 245, 249)))
                {
                    g.FillPath(trackBrush, trackPath);
                }
                return;
            }

            decimal expenseRatio = Math.Min(1, currentExpense / currentIncome);
            decimal savedRatio = Math.Max(0, 1 - expenseRatio);

            int expenseW = (int)(totalW * expenseRatio);
            int savedW = totalW - expenseW;

            // Draw track with rounded path
            using (GraphicsPath trackPath = UITheme.GetRoundedPath(trackRect, barH / 2))
            {
                using (SolidBrush expenseBrush = new SolidBrush(UITheme.ExpenseRed))
                {
                    g.FillPath(expenseBrush, trackPath);
                }

                if (savedW > 0 && expenseW < totalW)
                {
                    g.SetClip(trackPath);
                    Rectangle savedRect = new Rectangle(x + expenseW, barY, savedW, barH);
                    using (SolidBrush savedBrush = new SolidBrush(UITheme.IncomeGreen))
                    {
                        g.FillRectangle(savedBrush, savedRect);
                    }
                    g.ResetClip();
                }
            }

            // Legend below
            int legendY = barY + barH + 6;
            using (Font legFont = new Font("Segoe UI", 8.5F))
            {
                string expText = $"● Spent: {expenseRatio * 100:0.#}% (₹{currentExpense:N2})";
                string savText = $"● Saved: {savedRatio * 100:0.#}% (₹{Math.Max(0, currentIncome - currentExpense):N2})";

                g.DrawString(expText, legFont, new SolidBrush(UITheme.ExpenseRed), x, legendY);
                SizeF savSize = g.MeasureString(savText, legFont);
                g.DrawString(savText, legFont, new SolidBrush(UITheme.IncomeGreenDark), totalW - savSize.Width, legendY);
            }
        }
    }
}
