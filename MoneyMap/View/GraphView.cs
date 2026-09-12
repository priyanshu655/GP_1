using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using Npgsql;
using MoneyMap.Main;

namespace GP_1
{
    public partial class GraphView : Form
    {
        private readonly int currentUserId;
        private decimal currentIncome = 0;
        private decimal currentExpense = 0;

        public GraphView(int userId = 1)
        {
            InitializeComponent();
            this.currentUserId = userId;
            SetupChips();
            pictureBox1.Resize += (s, e) => DrawGraph();
        }

        private void GraphView_Load(object sender, EventArgs e)
        {
            LoadDataAndDraw();
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

        private void SetupChips()
        {
            Panel[] chips = { chipIncome, chipExpense, chipBalance };
            Color[] accentColors = {
                UITheme.IncomeGreen,
                UITheme.ExpenseRed,
                UITheme.BalanceBlue
            };

            for (int i = 0; i < chips.Length; i++)
            {
                int index = i;
                chips[i].Paint += (s, e) =>
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    Rectangle rect = chips[index].ClientRectangle;
                    rect.Width -= 1;
                    rect.Height -= 1;

                    using (Pen borderPen = new Pen(UITheme.BorderSubtle, 1))
                    {
                        e.Graphics.DrawRectangle(borderPen, rect);
                    }

                    using (SolidBrush accentBrush = new SolidBrush(accentColors[index]))
                    {
                        e.Graphics.FillRectangle(accentBrush, 0, 0, 4, chips[index].Height);
                    }
                };
            }

            chartCard.Paint += (s, e) =>
            {
                Rectangle r = chartCard.ClientRectangle;
                r.Width -= 1;
                r.Height -= 1;
                using (Pen p = new Pen(UITheme.BorderSubtle, 1))
                {
                    e.Graphics.DrawRectangle(p, r);
                }
            };
        }

        private void StatsPanel_Resize(object sender, EventArgs e)
        {
            int totalW = statsPanel.ClientSize.Width;
            int gap = 14;
            int cardW = Math.Max(180, (totalW - (gap * 2)) / 3);

            chipIncome.SetBounds(0, 10, cardW, 60);
            chipExpense.SetBounds(cardW + gap, 10, cardW, 60);
            chipBalance.SetBounds((cardW + gap) * 2, 10, totalW - ((cardW + gap) * 2), 60);
        }

        private void MonthPicker_ValueChanged(object? sender, EventArgs e)
        {
            LoadDataAndDraw();
        }

        private void LoadDataAndDraw()
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
                    command.Parameters.AddWithValue("month", dateTimePicker1.Value.Date);
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

            lblChipIncomeVal.Text = "+₹" + currentIncome.ToString("N2");
            lblChipExpenseVal.Text = "-₹" + currentExpense.ToString("N2");
            lblChipBalanceVal.Text = (balance >= 0 ? "+₹" : "-₹") + Math.Abs(balance).ToString("N2");
            lblChipBalanceVal.ForeColor = balance >= 0 ? UITheme.PrimaryGreenDark : UITheme.ExpenseRed;

            DrawGraph();
        }

        private void DrawGraph()
        {
            int w = pictureBox1.Width;
            int h = pictureBox1.Height;
            if (w <= 50 || h <= 50) return;

            Bitmap bitmap = new Bitmap(w, h);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                g.Clear(Color.White);

                decimal balance = currentIncome - currentExpense;
                bool hasData = currentIncome > 0 || currentExpense > 0;

                if (!hasData)
                {
                    DrawEmptyState(g, w, h);
                }
                else
                {
                    DrawChartContent(g, w, h, currentIncome, currentExpense, balance);
                }
            }

            Image? oldImage = pictureBox1.Image;
            pictureBox1.Image = bitmap;
            oldImage?.Dispose();
        }

        private void DrawEmptyState(Graphics g, int w, int h)
        {
            string title = "No Transaction Data";
            string subtitle = $"There are no records for {dateTimePicker1.Value:MMMM yyyy}.";

            using (Font tFont = new Font("Segoe UI Semibold", 13F, FontStyle.Bold))
            using (Font sFont = new Font("Segoe UI", 10F, FontStyle.Regular))
            {
                SizeF tSize = g.MeasureString(title, tFont);
                SizeF sSize = g.MeasureString(subtitle, sFont);

                float cx = w / 2f;
                float cy = (h / 2f) - 20;

                // Draw decorative circle
                int circleSize = 64;
                Rectangle circleRect = new Rectangle((int)(cx - circleSize / 2), (int)(cy - circleSize - 10), circleSize, circleSize);
                using (SolidBrush cBrush = new SolidBrush(Color.FromArgb(241, 245, 249)))
                {
                    g.FillEllipse(cBrush, circleRect);
                }

                using (Font iconFont = new Font("Segoe UI", 22F, FontStyle.Bold))
                {
                    string icon = "📊";
                    SizeF iSize = g.MeasureString(icon, iconFont);
                    g.DrawString(icon, iconFont, new SolidBrush(UITheme.TextMuted), cx - (iSize.Width / 2), circleRect.Y + 12);
                }

                g.DrawString(title, tFont, new SolidBrush(UITheme.TextPrimary), cx - (tSize.Width / 2), cy + 10);
                g.DrawString(subtitle, sFont, new SolidBrush(UITheme.TextSecondary), cx - (sSize.Width / 2), cy + 36);
            }
        }

        private void DrawChartContent(Graphics g, int w, int h, decimal income, decimal expense, decimal balance)
        {
            decimal rawMax = Math.Max(1, Math.Max(income, Math.Max(expense, Math.Abs(balance))));
            decimal maxScale = CalculateNiceMax(rawMax);

            int leftPadding = 75;
            int rightPadding = 40;
            int topPadding = 45;
            int bottomPadding = 75;

            int chartWidth = w - leftPadding - rightPadding;
            int chartHeight = h - topPadding - bottomPadding;
            int baseY = topPadding + chartHeight;

            // 1. Draw Grid Lines & Scale Numbers
            int gridCount = 4;
            using (Pen gridPen = new Pen(Color.FromArgb(241, 245, 249), 1))
            using (Font scaleFont = new Font("Segoe UI", 8.5F, FontStyle.Regular))
            {
                gridPen.DashStyle = DashStyle.Dash;

                for (int i = 0; i <= gridCount; i++)
                {
                    int gy = baseY - (int)((i / (float)gridCount) * chartHeight);
                    decimal val = (maxScale / gridCount) * i;

                    // Grid line
                    g.DrawLine(gridPen, leftPadding, gy, w - rightPadding, gy);

                    // Scale label
                    string scaleText = FormatCurrencyShort(val);
                    SizeF textSize = g.MeasureString(scaleText, scaleFont);
                    g.DrawString(scaleText, scaleFont, new SolidBrush(UITheme.TextMuted), leftPadding - textSize.Width - 10, gy - (textSize.Height / 2));
                }
            }

            // 2. Draw Baseline
            using (Pen basePen = new Pen(Color.FromArgb(226, 232, 240), 2))
            {
                g.DrawLine(basePen, leftPadding, baseY, w - rightPadding, baseY);
            }

            // 3. Compute Column Positions
            int colWidth = Math.Max(55, Math.Min(110, chartWidth / 7));
            int colSpacing = chartWidth / 4;

            int x1 = leftPadding + colSpacing - (colWidth / 2);
            int x2 = leftPadding + (colSpacing * 2) - (colWidth / 2);
            int x3 = leftPadding + (colSpacing * 3) - (colWidth / 2);

            // 4. Draw Bars
            // Income Bar
            DrawModernBar(g, "Income", "+₹" + income.ToString("N2"), income, maxScale, x1, baseY, colWidth, chartHeight,
                UITheme.IncomeGreen, UITheme.IncomeGreenDark, UITheme.IncomeBg, "● Total Inflow");

            // Expense Bar
            DrawModernBar(g, "Expenses", "-₹" + expense.ToString("N2"), expense, maxScale, x2, baseY, colWidth, chartHeight,
                UITheme.ExpenseRed, UITheme.ExpenseRedDark, UITheme.ExpenseBg, "● Total Outflow");

            // Balance Bar
            Color balC1 = balance >= 0 ? UITheme.BalanceBlue : UITheme.ExpenseRed;
            Color balC2 = balance >= 0 ? UITheme.BalanceBlueDark : UITheme.ExpenseRedDark;
            Color balBg = balance >= 0 ? UITheme.BalanceBg : UITheme.ExpenseBg;
            string balPrefix = balance >= 0 ? "+₹" : "-₹";
            string balSub = balance >= 0 ? "● Net Surplus" : "● Net Deficit";

            DrawModernBar(g, "Net Savings", balPrefix + Math.Abs(balance).ToString("N2"), Math.Abs(balance), maxScale, x3, baseY, colWidth, chartHeight,
                balC1, balC2, balBg, balSub);
        }

        private void DrawModernBar(Graphics g, string name, string valText, decimal val, decimal maxScale,
            int x, int baseY, int colWidth, int maxChartHeight, Color c1, Color c2, Color pillBg, string subText)
        {
            int barHeight = maxScale > 0 ? (int)((val / maxScale) * maxChartHeight) : 0;
            barHeight = Math.Max(4, Math.Min(maxChartHeight, barHeight));

            int barY = baseY - barHeight;
            Rectangle barRect = new Rectangle(x, barY, colWidth, barHeight);

            // Bar shape with rounded top
            int cornerRadius = Math.Min(8, colWidth / 4);
            using (GraphicsPath path = GetTopRoundedPath(barRect, cornerRadius))
            {
                // Gradient Fill
                using (LinearGradientBrush brush = new LinearGradientBrush(barRect, c1, c2, LinearGradientMode.Vertical))
                {
                    g.FillPath(brush, path);
                }

                // Subtle inner top highlight
                using (Pen topHighlight = new Pen(Color.FromArgb(80, Color.White), 1.5f))
                {
                    g.DrawLine(topHighlight, x + 2, barY + 1, x + colWidth - 2, barY + 1);
                }
            }

            // Floating value pill badge above bar
            using (Font valFont = new Font("Segoe UI Semibold", 9F, FontStyle.Bold))
            {
                SizeF valSize = g.MeasureString(valText, valFont);
                int pillPaddingH = 8;
                int pillPaddingV = 4;
                int pillW = (int)valSize.Width + (pillPaddingH * 2);
                int pillH = (int)valSize.Height + (pillPaddingV * 2);
                int pillX = x + (colWidth / 2) - (pillW / 2);
                int pillY = Math.Max(10, barY - pillH - 6);

                Rectangle pillRect = new Rectangle(pillX, pillY, pillW, pillH);
                using (GraphicsPath pillPath = UITheme.GetRoundedPath(pillRect, pillH / 2))
                using (SolidBrush pBgBrush = new SolidBrush(pillBg))
                using (Pen pBorderPen = new Pen(c1, 1))
                using (SolidBrush pTextBrush = new SolidBrush(c2))
                {
                    g.FillPath(pBgBrush, pillPath);
                    g.DrawPath(pBorderPen, pillPath);
                    g.DrawString(valText, valFont, pTextBrush, pillX + pillPaddingH, pillY + pillPaddingV);
                }
            }

            // X-Axis Labels below baseline
            using (Font titleFont = new Font("Segoe UI Semibold", 10F, FontStyle.Bold))
            using (Font subFont = new Font("Segoe UI", 8.5F, FontStyle.Regular))
            {
                SizeF titleSize = g.MeasureString(name, titleFont);
                SizeF subSize = g.MeasureString(subText, subFont);

                int cx = x + (colWidth / 2);
                g.DrawString(name, titleFont, new SolidBrush(UITheme.TextPrimary), cx - (titleSize.Width / 2), baseY + 10);
                g.DrawString(subText, subFont, new SolidBrush(c2), cx - (subSize.Width / 2), baseY + 30);
            }
        }

        private GraphicsPath GetTopRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            if (radius <= 0 || rect.Height < radius * 2)
            {
                path.AddRectangle(rect);
                return path;
            }

            int diameter = radius * 2;
            Rectangle arc = new Rectangle(rect.Location, new Size(diameter, diameter));

            // Top Left
            path.AddArc(arc, 180, 90);

            // Top Right
            arc.X = rect.Right - diameter;
            path.AddArc(arc, 270, 90);

            // Bottom Right
            path.AddLine(rect.Right, rect.Bottom, rect.Right, rect.Bottom);

            // Bottom Left
            path.AddLine(rect.Right, rect.Bottom, rect.Left, rect.Bottom);
            path.AddLine(rect.Left, rect.Bottom, rect.Left, rect.Top + radius);

            path.CloseFigure();
            return path;
        }

        private static decimal CalculateNiceMax(decimal val)
        {
            if (val <= 0) return 1000;
            if (val <= 500) return 500;
            if (val <= 1000) return 1000;
            if (val <= 2500) return 2500;
            if (val <= 5000) return 5000;
            if (val <= 10000) return 10000;

            // Round up to next nice round number
            decimal magnitude = (decimal)Math.Pow(10, Math.Floor(Math.Log10((double)val)));
            decimal normalized = val / magnitude;

            if (normalized <= 1.25m) return 1.25m * magnitude;
            if (normalized <= 2.5m) return 2.5m * magnitude;
            if (normalized <= 5.0m) return 5.0m * magnitude;
            if (normalized <= 7.5m) return 7.5m * magnitude;
            return 10.0m * magnitude;
        }

        private static string FormatCurrencyShort(decimal amount)
        {
            if (amount >= 10_000_000)
                return "₹" + (amount / 10_000_000m).ToString("0.##") + " Cr";
            if (amount >= 100_000)
                return "₹" + (amount / 100_000m).ToString("0.##") + " L";
            if (amount >= 1_000)
                return "₹" + (amount / 1_000m).ToString("0.#") + "k";
            return "₹" + amount.ToString("0");
        }
    }
}
