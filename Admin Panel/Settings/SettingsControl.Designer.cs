using System.Drawing;
using System.Windows.Forms;

namespace MoneyMap.AdminPanel.Settings
{
    partial class SettingsControl
    {
        private Label lblTitle;
        private Label lblSubtitle;

        private Panel pnlDetails;

        private Label lblSettingDetails;
        private Label lblSettingId;
        private Label lblUser;
        private Label lblFontName;
        private Label lblFontSize;
        private Label lblTextColor;
        private Label lblBackgroundColor;

        private TextBox txtSettingId;
        private ComboBox cmbUser;
        private TextBox txtFontName;
        private TextBox txtFontSize;
        private TextBox txtTextColor;
        private TextBox txtBackgroundColor;

        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnClear;

        private Label lblSearch;
        private TextBox txtSearch;
        private Button btnClearSearch;

        private DataGridView dgvSettings;

        #region Dispose

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #endregion

        private System.ComponentModel.IContainer components = null;

        #region InitializeComponent

        private void InitializeComponent()
        {
            components =
                new System.ComponentModel.Container();

            lblTitle = new Label();
            lblSubtitle = new Label();

            pnlDetails = new Panel();

            lblSettingDetails = new Label();
            lblSettingId = new Label();
            lblUser = new Label();
            lblFontName = new Label();
            lblFontSize = new Label();
            lblTextColor = new Label();
            lblBackgroundColor = new Label();

            txtSettingId = new TextBox();
            cmbUser = new ComboBox();
            txtFontName = new TextBox();
            txtFontSize = new TextBox();
            txtTextColor = new TextBox();
            txtBackgroundColor = new TextBox();

            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnClear = new Button();

            lblSearch = new Label();
            txtSearch = new TextBox();
            btnClearSearch = new Button();

            dgvSettings = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)
                dgvSettings).BeginInit();

            SuspendLayout();

            #region Title

            lblTitle.AutoSize = true;

            lblTitle.Font =
                new Font(
                    "Segoe UI",
                    22F,
                    FontStyle.Bold);

            lblTitle.ForeColor =
                Color.FromArgb(15, 23, 42);

            lblTitle.Location =
                new Point(40, 25);

            lblTitle.Name =
                "lblTitle";

            lblTitle.Text =
                "Settings Management";

            #endregion

            #region Subtitle

            lblSubtitle.AutoSize = true;

            lblSubtitle.Font =
                new Font(
                    "Segoe UI",
                    10F);

            lblSubtitle.ForeColor =
                Color.FromArgb(100, 116, 139);

            lblSubtitle.Location =
                new Point(43, 65);

            lblSubtitle.Name =
                "lblSubtitle";

            lblSubtitle.Text =
                "Manage user interface settings";

            #endregion

            #region Details Panel

            pnlDetails.BackColor =
                Color.White;

            pnlDetails.BorderStyle =
                BorderStyle.FixedSingle;

            pnlDetails.Location =
                new Point(40, 100);

            pnlDetails.Name =
                "pnlDetails";

            pnlDetails.Size =
                new Size(1070, 220);

            #endregion

            #region Setting Details

            lblSettingDetails.AutoSize = true;

            lblSettingDetails.Font =
                new Font(
                    "Segoe UI",
                    12F,
                    FontStyle.Bold);

            lblSettingDetails.ForeColor =
                Color.FromArgb(15, 23, 42);

            lblSettingDetails.Location =
                new Point(20, 15);

            lblSettingDetails.Name =
                "lblSettingDetails";

            lblSettingDetails.Text =
                "Setting Details";

            #endregion

            #region Setting ID

            lblSettingId.AutoSize = true;

            lblSettingId.Font =
                new Font(
                    "Segoe UI",
                    9F);

            lblSettingId.ForeColor =
                Color.FromArgb(71, 85, 105);

            lblSettingId.Location =
                new Point(20, 55);

            lblSettingId.Text =
                "Setting ID";

            txtSettingId.BackColor =
                Color.FromArgb(241, 245, 249);

            txtSettingId.BorderStyle =
                BorderStyle.FixedSingle;

            txtSettingId.Location =
                new Point(20, 78);

            txtSettingId.Name =
                "txtSettingId";

            txtSettingId.ReadOnly =
                true;

            txtSettingId.Size =
                new Size(150, 27);

            #endregion

            #region User

            lblUser.AutoSize = true;

            lblUser.Font =
                new Font(
                    "Segoe UI",
                    9F);

            lblUser.ForeColor =
                Color.FromArgb(71, 85, 105);

            lblUser.Location =
                new Point(190, 55);

            lblUser.Text =
                "User";

            cmbUser.DropDownStyle =
                ComboBoxStyle.DropDownList;

            cmbUser.FormattingEnabled =
                true;

            cmbUser.Location =
                new Point(190, 78);

            cmbUser.Name =
                "cmbUser";

            cmbUser.Size =
                new Size(220, 28);

            #endregion

            #region Font Name

            lblFontName.AutoSize = true;

            lblFontName.Font =
                new Font(
                    "Segoe UI",
                    9F);

            lblFontName.ForeColor =
                Color.FromArgb(71, 85, 105);

            lblFontName.Location =
                new Point(430, 55);

            lblFontName.Text =
                "Font Name";

            txtFontName.BorderStyle =
                BorderStyle.FixedSingle;

            txtFontName.Location =
                new Point(430, 78);

            txtFontName.Name =
                "txtFontName";

            txtFontName.Size =
                new Size(220, 27);

            #endregion

            #region Font Size

            lblFontSize.AutoSize = true;

            lblFontSize.Font =
                new Font(
                    "Segoe UI",
                    9F);

            lblFontSize.ForeColor =
                Color.FromArgb(71, 85, 105);

            lblFontSize.Location =
                new Point(670, 55);

            lblFontSize.Text =
                "Font Size";

            txtFontSize.BorderStyle =
                BorderStyle.FixedSingle;

            txtFontSize.Location =
                new Point(670, 78);

            txtFontSize.Name =
                "txtFontSize";

            txtFontSize.Size =
                new Size(150, 27);

            #endregion

            #region Text Color

            lblTextColor.AutoSize = true;

            lblTextColor.Font =
                new Font(
                    "Segoe UI",
                    9F);

            lblTextColor.ForeColor =
                Color.FromArgb(71, 85, 105);

            lblTextColor.Location =
                new Point(20, 125);

            lblTextColor.Text =
                "Text Color";

            txtTextColor.BorderStyle =
                BorderStyle.FixedSingle;

            txtTextColor.Location =
                new Point(20, 148);

            txtTextColor.Name =
                "txtTextColor";

            txtTextColor.Size =
                new Size(250, 27);

            #endregion

            #region Background Color

            lblBackgroundColor.AutoSize = true;

            lblBackgroundColor.Font =
                new Font(
                    "Segoe UI",
                    9F);

            lblBackgroundColor.ForeColor =
                Color.FromArgb(71, 85, 105);

            lblBackgroundColor.Location =
                new Point(290, 125);

            lblBackgroundColor.Text =
                "Background Color";

            txtBackgroundColor.BorderStyle =
                BorderStyle.FixedSingle;

            txtBackgroundColor.Location =
                new Point(290, 148);

            txtBackgroundColor.Name =
                "txtBackgroundColor";

            txtBackgroundColor.Size =
                new Size(250, 27);

            #endregion

            #region Add Button

            btnAdd.BackColor =
                Color.FromArgb(16, 185, 129);

            btnAdd.FlatAppearance.BorderSize =
                0;

            btnAdd.FlatStyle =
                FlatStyle.Flat;

            btnAdd.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            btnAdd.ForeColor =
                Color.White;

            btnAdd.Location =
                new Point(40, 340);

            btnAdd.Name =
                "btnAdd";

            btnAdd.Size =
                new Size(120, 40);

            btnAdd.Text =
                "Add Setting";

            btnAdd.UseVisualStyleBackColor =
                false;

            btnAdd.Click +=
                BtnAdd_Click;

            #endregion

            #region Edit Button

            btnEdit.BackColor =
                Color.FromArgb(59, 130, 246);

            btnEdit.FlatAppearance.BorderSize =
                0;

            btnEdit.FlatStyle =
                FlatStyle.Flat;

            btnEdit.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            btnEdit.ForeColor =
                Color.White;

            btnEdit.Location =
                new Point(175, 340);

            btnEdit.Name =
                "btnEdit";

            btnEdit.Size =
                new Size(130, 40);

            btnEdit.Text =
                "Update Setting";

            btnEdit.UseVisualStyleBackColor =
                false;

            btnEdit.Click +=
                BtnEdit_Click;

            #endregion

            #region Delete Button

            btnDelete.BackColor =
                Color.FromArgb(239, 68, 68);

            btnDelete.FlatAppearance.BorderSize =
                0;

            btnDelete.FlatStyle =
                FlatStyle.Flat;

            btnDelete.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            btnDelete.ForeColor =
                Color.White;

            btnDelete.Location =
                new Point(320, 340);

            btnDelete.Name =
                "btnDelete";

            btnDelete.Size =
                new Size(130, 40);

            btnDelete.Text =
                "Delete Setting";

            btnDelete.UseVisualStyleBackColor =
                false;

            btnDelete.Click +=
                BtnDelete_Click;

            #endregion

            #region Clear Button

            btnClear.BackColor =
                Color.FromArgb(100, 116, 139);

            btnClear.FlatAppearance.BorderSize =
                0;

            btnClear.FlatStyle =
                FlatStyle.Flat;

            btnClear.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            btnClear.ForeColor =
                Color.White;

            btnClear.Location =
                new Point(465, 340);

            btnClear.Name =
                "btnClear";

            btnClear.Size =
                new Size(100, 40);

            btnClear.Text =
                "Clear";

            btnClear.UseVisualStyleBackColor =
                false;

            btnClear.Click +=
                BtnClear_Click;

            #endregion

            #region Search

            lblSearch.AutoSize = true;

            lblSearch.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            lblSearch.ForeColor =
                Color.FromArgb(71, 85, 105);

            lblSearch.Location =
                new Point(40, 405);

            lblSearch.Text =
                "Search";

            txtSearch.BorderStyle =
                BorderStyle.FixedSingle;

            txtSearch.Location =
                new Point(40, 427);

            txtSearch.Name =
                "txtSearch";

            txtSearch.Size =
                new Size(300, 27);

            txtSearch.TextChanged +=
                TxtSearch_TextChanged;

            #endregion

            #region Clear Search Button

            btnClearSearch.BackColor =
                Color.FromArgb(100, 116, 139);

            btnClearSearch.FlatAppearance.BorderSize =
                0;

            btnClearSearch.FlatStyle =
                FlatStyle.Flat;

            btnClearSearch.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            btnClearSearch.ForeColor =
                Color.White;

            btnClearSearch.Location =
                new Point(360, 425);

            btnClearSearch.Name =
                "btnClearSearch";

            btnClearSearch.Size =
                new Size(120, 32);

            btnClearSearch.Text =
                "Clear Search";

            btnClearSearch.UseVisualStyleBackColor =
                false;

            btnClearSearch.Click +=
                BtnClearSearch_Click;

            #endregion

            #region Settings Grid

            dgvSettings.AllowUserToAddRows =
                false;

            dgvSettings.AllowUserToDeleteRows =
                false;

            dgvSettings.AllowUserToResizeRows =
                false;

            dgvSettings.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvSettings.BackgroundColor =
                Color.White;

            dgvSettings.BorderStyle =
                BorderStyle.None;

            dgvSettings.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(15, 23, 42);

            dgvSettings.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvSettings.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            dgvSettings.ColumnHeadersHeight =
                40;

            dgvSettings.EnableHeadersVisualStyles =
                false;

            dgvSettings.Location =
                new Point(40, 470);

            dgvSettings.MultiSelect =
                false;

            dgvSettings.Name =
                "dgvSettings";

            dgvSettings.ReadOnly =
                true;

            dgvSettings.RowHeadersVisible =
                false;

            dgvSettings.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvSettings.Size =
                new Size(1070, 400 );

            dgvSettings.CellClick +=
                DgvSettings_CellClick;

            #endregion

            #region UserControl

            BackColor =
                Color.FromArgb(248, 250, 252);

            Controls.Add(lblTitle);
            Controls.Add(lblSubtitle);

            pnlDetails.Controls.Add(
                lblSettingDetails);

            pnlDetails.Controls.Add(
                lblSettingId);

            pnlDetails.Controls.Add(
                txtSettingId);

            pnlDetails.Controls.Add(
                lblUser);

            pnlDetails.Controls.Add(
                cmbUser);

            pnlDetails.Controls.Add(
                lblFontName);

            pnlDetails.Controls.Add(
                txtFontName);

            pnlDetails.Controls.Add(
                lblFontSize);

            pnlDetails.Controls.Add(
                txtFontSize);

            pnlDetails.Controls.Add(
                lblTextColor);

            pnlDetails.Controls.Add(
                txtTextColor);

            pnlDetails.Controls.Add(
                lblBackgroundColor);

            pnlDetails.Controls.Add(
                txtBackgroundColor);

            Controls.Add(pnlDetails);

            Controls.Add(btnAdd);
            Controls.Add(btnEdit);
            Controls.Add(btnDelete);
            Controls.Add(btnClear);

            Controls.Add(lblSearch);
            Controls.Add(txtSearch);
            Controls.Add(btnClearSearch);

            Controls.Add(dgvSettings);

            Dock =
                DockStyle.Fill;

            Name =
                "SettingsControl";

            Size =
                new Size(1150, 625);

            #endregion

            ((System.ComponentModel.ISupportInitialize)
                dgvSettings).EndInit();

            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}