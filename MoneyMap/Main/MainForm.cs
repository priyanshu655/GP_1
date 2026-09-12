using System;
using System.Drawing;
using System.Windows.Forms;
using GP_1;
using GP_1.Forms;
using MoneyMap.Authentication;
using MoneyMap.Budget.Forms;
using MoneyMap.Home.Forms;
using MoneyMap.Setting.Forms;
using MoneyMap.Setting.Services;

namespace MoneyMap.Main
{
    public partial class MainForm : Form
    {
        private readonly int userId;
        private System.Windows.Forms.Timer? sessionTimer;

        public bool LoggedOut { get; private set; } = false;

        public MainForm(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            ApplyTheme();
            SettingsManager.SettingsChanged += SettingsManager_SettingsChanged;
        }

        private void SettingsManager_SettingsChanged(int uId)
        {
            if (uId == this.userId && !this.IsDisposed)
            {
                ApplyUserSettings();
            }
        }

        private void ApplyUserSettings()
        {
            var settings = SettingsManager.LoadSettings(userId);
            this.BackColor = settings.BackgroundColor;
            mainPanel.BackColor = settings.BackgroundColor;

            if (mainPanel.Tag is Form activeChild && !activeChild.IsDisposed)
            {
                SettingsManager.ApplySettings(activeChild, settings);
            }
        }

        private void ApplyTheme()
        {
            this.BackColor = UITheme.LightCanvas;
            mainPanel.BackColor = UITheme.LightCanvas;

            menuStrip1.Renderer = new UITheme.ModernDarkMenuRenderer();
            menuStrip1.BackColor = UITheme.DarkNavy;
            menuStrip1.ForeColor = Color.White;
            menuStrip1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            menuStrip1.Padding = new Padding(12, 6, 12, 6);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Default home view when dashboard opens
            LoadChildForm(new HomeDashboardForm(userId));

            // Start 2-hour session timer
            InitializeSessionTimer();
        }

        private void InitializeSessionTimer()
        {
            var session = SessionManager.GetActiveSession();
            if (session == null)
            {
                // If opened with no active session, save session now for current user
                SessionManager.SaveSession(userId, "User");
            }

            sessionTimer = new System.Windows.Forms.Timer();
            sessionTimer.Interval = 10000; // Check every 10 seconds
            sessionTimer.Tick += SessionTimer_Tick;
            sessionTimer.Start();
        }

        private void SessionTimer_Tick(object? sender, EventArgs e)
        {
            var session = SessionManager.GetActiveSession();
            if (session == null || DateTime.UtcNow >= session.ExpiryTime)
            {
                sessionTimer?.Stop();
                MessageBox.Show(
                    "Your session has expired (2 hours maximum duration). You have been automatically logged out for security.",
                    "Session Expired",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                PerformLogout();
            }
        }

        public void PerformLogout()
        {
            LoggedOut = true;
            SessionManager.ClearSession();
            sessionTimer?.Stop();
            sessionTimer?.Dispose();
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            sessionTimer?.Stop();
            sessionTimer?.Dispose();
            base.OnFormClosing(e);
        }

        /// <summary>
        /// Loads a Form inside mainPanel so it smoothly fills the entire available area.
        /// </summary>
        public void LoadChildForm(Form childForm)
        {
            CloseCurrentView();

            // Embed child form directly into mainPanel covering the whole space
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.ControlBox = false;
            childForm.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(childForm);
            mainPanel.Tag = childForm;

            // Apply global user settings to newly opened view
            SettingsManager.ApplySettings(childForm, userId);

            childForm.Show();
            childForm.BringToFront();
        }

        /// <summary>
        /// Closes and cleans up any currently loaded view from the main panel.
        /// </summary>
        public void CloseCurrentView()
        {
            while (mainPanel.Controls.Count > 0)
            {
                Control oldControl = mainPanel.Controls[0];
                mainPanel.Controls.RemoveAt(0);
                oldControl.Dispose();
            }
        }

        // ══════════════════════════════════════════════════════
        //  HOME / DASHBOARD MENU HANDLER
        // ══════════════════════════════════════════════════════

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadChildForm(new HomeDashboardForm(userId));
        }

        // ══════════════════════════════════════════════════════
        //  FILES (IMPORT / EXPORT) MENU HANDLERS
        // ══════════════════════════════════════════════════════

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadChildForm(new ImportExportForm(userId, ImportExportMode.ImportOnly));
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadChildForm(new ImportExportForm(userId, ImportExportMode.ExportOnly));
        }

        // ══════════════════════════════════════════════════════
        //  TRANSACTION MENU HANDLERS
        // ══════════════════════════════════════════════════════

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FrmTransactionInput frmInput = new FrmTransactionInput(userId))
            {
                SettingsManager.ApplySettings(frmInput, userId);
                if (frmInput.ShowDialog(this) == DialogResult.OK)
                {
                    if (mainPanel.Tag is HomeDashboardForm home)
                    {
                        home.RefreshDashboard();
                    }
                    else if (mainPanel.Tag is FrmTransaction frmTx)
                    {
                        frmTx.LoadTransactions();
                    }
                    else if (mainPanel.Tag is ShowAll showAll)
                    {
                        showAll.FetchDataInListView();
                    }
                }
            }
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadChildForm(new FrmTransaction(userId, TransactionViewMode.EditOnly));
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadChildForm(new FrmTransaction(userId, TransactionViewMode.DeleteOnly));
        }

        // ══════════════════════════════════════════════════════
        //  BUDGET MENU HANDLER
        // ══════════════════════════════════════════════════════

        private void budgetTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var budgetForm = new BudgetLimitForm(userId))
            {
                SettingsManager.ApplySettings(budgetForm, userId);
                if (budgetForm.ShowDialog(this) == DialogResult.OK)
                {
                    if (mainPanel.Tag is HomeDashboardForm home)
                    {
                        home.RefreshDashboard();
                    }
                }
            }
        }

        // ══════════════════════════════════════════════════════
        //  VIEW MENU HANDLERS
        // ══════════════════════════════════════════════════════

        private void showAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadChildForm(new ShowAll(userId));
        }

        private void showIncomeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadChildForm(new ShowIncome(userId));
        }

        private void showExpenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadChildForm(new ShowExpense(userId));
        }

        private void summaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadChildForm(new Summary(userId));
        }

        private void graphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadChildForm(new GraphView(userId));
        }

        private void closeViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseCurrentView();
        }

        // ══════════════════════════════════════════════════════
        //  SETTINGS MENU HANDLERS
        // ══════════════════════════════════════════════════════

        private void appearanceSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadChildForm(new SettingForm(userId));
        }

        private void changeFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var settings = SettingsManager.LoadSettings(userId);
            using var fontDialog = new FontDialog();
            fontDialog.Font = settings.CreateFont();
            fontDialog.ShowEffects = false;

            if (fontDialog.ShowDialog(this) == DialogResult.OK)
            {
                SettingsManager.SaveSettings(
                    userId,
                    fontDialog.Font.FontFamily.Name,
                    fontDialog.Font.Size,
                    settings.TextColor,
                    settings.BackgroundColor);
                MessageBox.Show("Font settings updated globally!", "Font Changed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void changeTextColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var settings = SettingsManager.LoadSettings(userId);
            using var colorDialog = new ColorDialog();
            colorDialog.Color = settings.TextColor;
            colorDialog.FullOpen = true;

            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                SettingsManager.SaveSettings(
                    userId,
                    settings.FontName,
                    settings.FontSize,
                    colorDialog.Color,
                    settings.BackgroundColor);
                MessageBox.Show("Text color updated globally!", "Color Changed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void changeBgColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var settings = SettingsManager.LoadSettings(userId);
            using var colorDialog = new ColorDialog();
            colorDialog.Color = settings.BackgroundColor;
            colorDialog.FullOpen = true;

            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                SettingsManager.SaveSettings(
                    userId,
                    settings.FontName,
                    settings.FontSize,
                    settings.TextColor,
                    colorDialog.Color);
                MessageBox.Show("Background color updated globally!", "Background Changed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void resetSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "Are you sure you want to reset all appearance settings to default values?",
                "Reset Appearance",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                SettingsManager.ResetSettings(userId);
                MessageBox.Show("Appearance settings reset to default.", "Reset Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Logged in as User ID: {userId}",
                "Profile", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to logout?",
                "Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                PerformLogout();
            }
        }
    }
}