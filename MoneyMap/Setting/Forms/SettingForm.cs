using System;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Windows.Forms;
using MoneyMap.Main;
using MoneyMap.Setting.Services;

namespace MoneyMap.Setting.Forms
{
    public partial class SettingForm : Form
    {
        private readonly int userId;
        private Color currentTextColor;
        private Color currentBgColor;
        private bool isInitializing = true;

        public SettingForm(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            PopulateFontFamilies();
            LoadCurrentSettings();
            isInitializing = false;
            UpdatePreview();
        }

        private void PopulateFontFamilies()
        {
            cmbFontFamily.Items.Clear();

            // Curated recommended fonts at the top
            string[] topFonts = { "Segoe UI", "Segoe UI Semibold", "Arial", "Calibri", "Century Gothic", "Consolas", "Georgia", "Lucida Sans", "Tahoma", "Trebuchet MS", "Verdana" };
            foreach (var font in topFonts)
            {
                if (!cmbFontFamily.Items.Contains(font))
                {
                    cmbFontFamily.Items.Add(font);
                }
            }

            // Populate system fonts
            using (var installedFonts = new InstalledFontCollection())
            {
                foreach (var family in installedFonts.Families)
                {
                    if (!cmbFontFamily.Items.Contains(family.Name))
                    {
                        cmbFontFamily.Items.Add(family.Name);
                    }
                }
            }

            if (cmbFontFamily.Items.Count > 0 && cmbFontFamily.SelectedIndex == -1)
            {
                cmbFontFamily.SelectedIndex = 0;
            }
        }

        private void LoadCurrentSettings()
        {
            var settings = SettingsManager.LoadSettings(userId);

            int fontIndex = cmbFontFamily.FindStringExact(settings.FontName);
            if (fontIndex >= 0)
            {
                cmbFontFamily.SelectedIndex = fontIndex;
            }
            else
            {
                cmbFontFamily.Text = settings.FontName;
            }

            numFontSize.Value = (decimal)Math.Clamp(settings.FontSize, 8f, 18f);

            currentTextColor = settings.TextColor;
            pnlTextColorSample.BackColor = currentTextColor;

            currentBgColor = settings.BackgroundColor;
            pnlBgColorSample.BackColor = currentBgColor;
        }

        private void UpdatePreview()
        {
            if (isInitializing) return;

            string selectedFamily = cmbFontFamily.SelectedItem?.ToString() ?? cmbFontFamily.Text;
            if (string.IsNullOrWhiteSpace(selectedFamily))
            {
                selectedFamily = "Segoe UI";
            }

            float fontSize = (float)numFontSize.Value;

            Font previewFont;
            try
            {
                previewFont = new Font(selectedFamily, fontSize, FontStyle.Regular);
            }
            catch
            {
                previewFont = new Font("Segoe UI", fontSize, FontStyle.Regular);
            }

            Font previewBoldFont;
            try
            {
                previewBoldFont = new Font(selectedFamily, fontSize + 2.5f, FontStyle.Bold);
            }
            catch
            {
                previewBoldFont = new Font("Segoe UI", fontSize + 2.5f, FontStyle.Bold);
            }

            // Update live preview controls
            pnlLivePreview.BackColor = currentBgColor;
            lblPreviewHeading.Font = previewBoldFont;
            lblPreviewHeading.ForeColor = currentTextColor;

            lblPreviewSampleText.Font = previewFont;
            lblPreviewSampleText.ForeColor = currentTextColor;

            lblPreviewAmount.Font = new Font(previewBoldFont.FontFamily, fontSize + 4f, FontStyle.Bold);

            txtPreviewInput.Font = previewFont;
            txtPreviewInput.ForeColor = currentTextColor;

            pnlTextColorSample.BackColor = currentTextColor;
            pnlBgColorSample.BackColor = currentBgColor;
        }

        private void Control_ValueChanged(object sender, EventArgs e)
        {
            UpdatePreview();
        }

        private void btnBrowseFont_Click(object sender, EventArgs e)
        {
            using (var fontDialog = new FontDialog())
            {
                string currentFamily = cmbFontFamily.SelectedItem?.ToString() ?? "Segoe UI";
                float currentSize = (float)numFontSize.Value;
                fontDialog.Font = new Font(currentFamily, currentSize);
                fontDialog.ShowEffects = false;

                if (fontDialog.ShowDialog(this) == DialogResult.OK)
                {
                    string chosenName = fontDialog.Font.FontFamily.Name;
                    int idx = cmbFontFamily.FindStringExact(chosenName);
                    if (idx >= 0)
                    {
                        cmbFontFamily.SelectedIndex = idx;
                    }
                    else
                    {
                        cmbFontFamily.Items.Insert(0, chosenName);
                        cmbFontFamily.SelectedIndex = 0;
                    }

                    numFontSize.Value = (decimal)Math.Clamp(fontDialog.Font.Size, 8f, 18f);
                    UpdatePreview();
                }
            }
        }

        private void btnPickTextColor_Click(object sender, EventArgs e)
        {
            using (var colorDialog = new ColorDialog())
            {
                colorDialog.Color = currentTextColor;
                colorDialog.FullOpen = true;

                if (colorDialog.ShowDialog(this) == DialogResult.OK)
                {
                    currentTextColor = colorDialog.Color;
                    UpdatePreview();
                }
            }
        }

        private void btnPickBgColor_Click(object sender, EventArgs e)
        {
            using (var colorDialog = new ColorDialog())
            {
                colorDialog.Color = currentBgColor;
                colorDialog.FullOpen = true;

                if (colorDialog.ShowDialog(this) == DialogResult.OK)
                {
                    currentBgColor = colorDialog.Color;
                    UpdatePreview();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string fontName = cmbFontFamily.SelectedItem?.ToString() ?? cmbFontFamily.Text;
            if (string.IsNullOrWhiteSpace(fontName)) fontName = "Segoe UI";
            float fontSize = (float)numFontSize.Value;

            bool success = SettingsManager.SaveSettings(userId, fontName, fontSize, currentTextColor, currentBgColor);
            if (success)
            {
                MessageBox.Show("Settings saved and applied globally successfully!", "Settings Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "Are you sure you want to reset all appearance settings to default values?",
                "Reset Settings",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                bool success = SettingsManager.ResetSettings(userId);
                if (success)
                {
                    LoadCurrentSettings();
                    UpdatePreview();
                    MessageBox.Show("Settings have been reset to default values.", "Reset Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (this.ParentForm is MainForm mainForm)
            {
                mainForm.CloseCurrentView();
            }
            else if (this.Parent?.Parent is MainForm parentMainForm)
            {
                parentMainForm.CloseCurrentView();
            }
            else
            {
                this.Close();
            }
        }
    }
}
