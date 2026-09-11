using System;
using System.Drawing;
using System.Windows.Forms;

namespace GP_1
{
    public partial class SettingForm : Form
    {
        private int userId;

        // In-memory holding fields for user selections before saving
        private Font selectedFont;
        private Color selectedTextColor;
        private Color selectedBackgroundColor;

        /// <summary>
        /// Parameterless constructor required by the Visual Studio Windows Forms Designer.
        /// Defaults to userId = 1 for testing.
        /// </summary>
        public SettingForm() : this(1)
        {
        }

        /// <summary>
        /// Main constructor that receives the logged-in user ID from HomePage or Login.
        /// </summary>
        /// <param name="userId">The ID of the currently logged-in user.</param>
        public SettingForm(int userId)
        {
            InitializeComponent();
            this.userId = userId;

            // Initialize default values before loading from database
            this.selectedFont = this.Font;
            this.selectedTextColor = Color.Black;
            this.selectedBackgroundColor = Color.White;
        }

        /// <summary>
        /// Form Load event: fetches user settings from PostgreSQL and displays them.
        /// </summary>
        private void SettingForm_Load(object sender, EventArgs e)
        {
            // Resolve to an existing user in the database if defaulting to 1 during testing
            this.userId = SettingsManager.ResolveValidUserId(this.userId);
            LoadUserSettings();
        }

        /// <summary>
        /// Loads saved settings for this user from the database.
        /// If not found, loads sensible defaults.
        /// </summary>
        private void LoadUserSettings()
        {
            // Fetch settings from database using SettingsManager
            SettingsManager.LoadSettings(
                this.userId,
                out this.selectedFont,
                out this.selectedTextColor,
                out this.selectedBackgroundColor);

            // Update preview and labels
            UpdatePreview();
        }

        /// <summary>
        /// Updates the preview panel and sample text to reflect current selections.
        /// </summary>
        private void UpdatePreview()
        {
            // Update Preview Panel & Label
            pnlPreview.BackColor = selectedBackgroundColor;
            lblPreview.ForeColor = selectedTextColor;
            lblPreview.Font = selectedFont;
        }

        /// <summary>
        /// Opens FontDialog to choose a new font and updates preview immediately.
        /// </summary>
        private void btnChangeFont_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = selectedFont;

            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                selectedFont = fontDialog1.Font;
                UpdatePreview();
            }
        }

        /// <summary>
        /// Opens ColorDialog to choose a new text color and updates preview immediately.
        /// </summary>
        private void btnChangeTextColor_Click(object sender, EventArgs e)
        {
            colorDialogText.Color = selectedTextColor;

            if (colorDialogText.ShowDialog() == DialogResult.OK)
            {
                selectedTextColor = colorDialogText.Color;
                UpdatePreview();
            }
        }

        /// <summary>
        /// Opens ColorDialog to choose a new background color and updates preview immediately.
        /// </summary>
        private void btnChangeBackgroundColor_Click(object sender, EventArgs e)
        {
            colorDialogBackground.Color = selectedBackgroundColor;

            if (colorDialogBackground.ShowDialog() == DialogResult.OK)
            {
                selectedBackgroundColor = colorDialogBackground.Color;
                UpdatePreview();
            }
        }

        /// <summary>
        /// Saves current selections to the PostgreSQL database via SettingsManager.
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.userId = SettingsManager.ResolveValidUserId(this.userId);

                SettingsManager.SaveSettings(
                    this.userId,
                    this.selectedFont,
                    this.selectedTextColor,
                    this.selectedBackgroundColor);

                MessageBox.Show(
                    "Settings saved successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception)
            {
                // Error dialog is already handled by SettingsManager.
                // We keep the form open so the user can retry or adjust their settings.
            }
        }
    }
}
