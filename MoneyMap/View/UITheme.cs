using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GP_1
{
    public static class UITheme
    {
        // ── Currency ─────────────────────────────────────────────────────────
        public const string CurrencySymbol             = "₹";

        // ── Brand Colors (Matching Login & Sign Up) ──────────────────────────
        public static readonly Color DarkNavy          = Color.FromArgb(24, 31, 42);    // #181F2A
        public static readonly Color DarkSlate         = Color.FromArgb(35, 42, 52);    // #232A34
        public static readonly Color PrimaryGreen      = Color.FromArgb(46, 204, 113);  // #2ECC71
        public static readonly Color PrimaryGreenDark  = Color.FromArgb(39, 174, 96);   // #27AE60
        public static readonly Color LightCanvas       = Color.FromArgb(248, 249, 251); // #F8F9FB
        public static readonly Color CardBg           = Color.White;
        public static readonly Color BorderSubtle      = Color.FromArgb(226, 232, 240); // #E2E8F0
        public static readonly Color BorderStrong      = Color.FromArgb(203, 213, 225); // #CBD5E1

        // ── Text Colors ──────────────────────────────────────────────────────
        public static readonly Color TextPrimary       = Color.FromArgb(35, 42, 52);    // #232A34
        public static readonly Color TextSecondary     = Color.FromArgb(110, 118, 130); // #6E7682
        public static readonly Color TextMuted         = Color.FromArgb(148, 163, 184); // #94A3B8
        public static readonly Color TextOnDark        = Color.FromArgb(240, 243, 246);
        public static readonly Color TextOnDarkMuted   = Color.FromArgb(160, 174, 192);

        // ── Financial Accents ────────────────────────────────────────────────
        public static readonly Color IncomeGreen       = Color.FromArgb(46, 204, 113);  // #2ECC71
        public static readonly Color IncomeGreenDark   = Color.FromArgb(39, 174, 96);   // #27AE60
        public static readonly Color IncomeBg          = Color.FromArgb(235, 249, 241); // #EBF9F1

        public static readonly Color ExpenseRed        = Color.FromArgb(235, 87, 87);   // #EB5757
        public static readonly Color ExpenseRedDark    = Color.FromArgb(192, 57, 43);   // #C0392B
        public static readonly Color ExpenseBg         = Color.FromArgb(253, 237, 237); // #FDEDED

        public static readonly Color BalanceBlue       = Color.FromArgb(52, 152, 219);  // #3498DB
        public static readonly Color BalanceBlueDark   = Color.FromArgb(41, 128, 185);  // #2980B9
        public static readonly Color BalanceBg        = Color.FromArgb(235, 243, 250); // #EBF3FA

        public static readonly Color NeutralPurple     = Color.FromArgb(155, 89, 182);  // #9B59B6
        public static readonly Color NeutralPurpleBg   = Color.FromArgb(245, 238, 250); // #F5EEFA

        // ── Fonts ────────────────────────────────────────────────────────────
        public static readonly Font HeaderFont         = new Font("Segoe UI", 16F, FontStyle.Bold);
        public static readonly Font SubHeaderFont      = new Font("Segoe UI", 12F, FontStyle.Bold);
        public static readonly Font SectionFont        = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
        public static readonly Font BodyFont           = new Font("Segoe UI", 9.5F, FontStyle.Regular);
        public static readonly Font BodySemibold       = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        public static readonly Font SmallFont          = new Font("Segoe UI", 8.5F, FontStyle.Regular);
        public static readonly Font SmallSemibold       = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
        public static readonly Font StatNumberFont     = new Font("Segoe UI", 18F, FontStyle.Bold);
        public static readonly Font StatNumberSmall    = new Font("Segoe UI", 13F, FontStyle.Bold);

        // ── DataGridView Modern Styler ───────────────────────────────────────
        public static void StyleDataGridView(DataGridView dgv)
        {
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.FromArgb(241, 245, 249);
            dgv.EnableHeadersVisualStyles = false;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.ReadOnly = true;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.RowTemplate.Height = 42;

            // Column Headers
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersHeight = 44;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(71, 85, 105);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(12, 0, 12, 0);

            // Default Cell Style
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = TextPrimary;
            dgv.DefaultCellStyle.Font = BodyFont;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(232, 248, 240);
            dgv.DefaultCellStyle.SelectionForeColor = DarkSlate;
            dgv.DefaultCellStyle.Padding = new Padding(12, 0, 12, 0);
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Alternating Row Style
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 250, 252);
            dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(232, 248, 240);
            dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = DarkSlate;

            // Enable double buffering for flicker-free scrolling
            typeof(DataGridView).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty,
                null, dgv, new object[] { true });
        }

        // ── Rounded Rectangle GraphicsPath ───────────────────────────────────
        public static GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            if (radius <= 0)
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
            arc.Y = rect.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // Bottom Left
            arc.X = rect.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }

        // ── Custom MenuStrip Dark Theme Renderer ─────────────────────────────
        public class ModernDarkMenuRenderer : ToolStripProfessionalRenderer
        {
            public ModernDarkMenuRenderer() : base(new ModernDarkColorTable()) { }

            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                if (!e.Item.Enabled) return;

                if (e.Item.Selected || e.Item.Pressed)
                {
                    Rectangle rect = new Rectangle(Point.Empty, e.Item.Size);
                    using (SolidBrush brush = new SolidBrush(Color.FromArgb(39, 174, 96))) // Emerald hover
                    {
                        e.Graphics.FillRectangle(brush, rect);
                    }
                }
                else
                {
                    base.OnRenderMenuItemBackground(e);
                }
            }

            protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
            {
                e.TextColor = Color.White;
                base.OnRenderItemText(e);
            }
        }

        private class ModernDarkColorTable : ProfessionalColorTable
        {
            public override Color MenuStripGradientBegin => DarkNavy;
            public override Color MenuStripGradientEnd => DarkNavy;
            public override Color ToolStripDropDownBackground => DarkNavy;
            public override Color ImageMarginGradientBegin => DarkNavy;
            public override Color ImageMarginGradientMiddle => DarkNavy;
            public override Color ImageMarginGradientEnd => DarkNavy;
            public override Color MenuBorder => Color.FromArgb(40, 50, 65);
            public override Color MenuItemBorder => Color.Transparent;
            public override Color MenuItemSelected => Color.FromArgb(39, 174, 96);
            public override Color MenuItemSelectedGradientBegin => Color.FromArgb(39, 174, 96);
            public override Color MenuItemSelectedGradientEnd => Color.FromArgb(39, 174, 96);
            public override Color MenuItemPressedGradientBegin => Color.FromArgb(30, 130, 76);
            public override Color MenuItemPressedGradientEnd => Color.FromArgb(30, 130, 76);
            public override Color SeparatorDark => Color.FromArgb(50, 62, 80);
            public override Color SeparatorLight => Color.Transparent;
        }
    }
}
