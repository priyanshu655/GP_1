using System.Drawing;
using System.Windows.Forms;

namespace MoneyMap.AdminPanel.Users
{
    partial class UsersControl
    {
        private Label lblTitle;
        private Label lblSubtitle;

        private Panel pnlDetails;

        private Label lblUserDetails;
        private Label lblUserId;
        private Label lblUsername;
        private Label lblPassword;

        private TextBox txtUserId;
        private TextBox txtUsername;
        private TextBox txtPassword;

        private CheckBox chkIsActive;

        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnClear;

        private Label lblSearch;
        private TextBox txtSearch;
        private Button btnClearSearch;

        private DataGridView dgvUsers;

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

            lblUserDetails = new Label();
            lblUserId = new Label();
            lblUsername = new Label();
            lblPassword = new Label();

            txtUserId = new TextBox();
            txtUsername = new TextBox();
            txtPassword = new TextBox();

            chkIsActive = new CheckBox();

            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnClear = new Button();

            lblSearch = new Label();
            txtSearch = new TextBox();
            btnClearSearch = new Button();

            dgvUsers = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)
                dgvUsers).BeginInit();

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
                "Users Management";

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
                "Manage and monitor all users";

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
                new Size(1070, 150);

            #endregion

            #region User Details Title

            lblUserDetails.AutoSize = true;

            lblUserDetails.Font =
                new Font(
                    "Segoe UI",
                    12F,
                    FontStyle.Bold);

            lblUserDetails.ForeColor =
                Color.FromArgb(15, 23, 42);

            lblUserDetails.Location =
                new Point(20, 15);

            lblUserDetails.Name =
                "lblUserDetails";

            lblUserDetails.Text =
                "User Details";

            #endregion

            #region User ID

            lblUserId.AutoSize = true;

            lblUserId.Font =
                new Font(
                    "Segoe UI",
                    9F);

            lblUserId.ForeColor =
                Color.FromArgb(71, 85, 105);

            lblUserId.Location =
                new Point(20, 55);

            lblUserId.Text =
                "User ID";

            txtUserId.BackColor =
                Color.FromArgb(241, 245, 249);

            txtUserId.BorderStyle =
                BorderStyle.FixedSingle;

            txtUserId.Location =
                new Point(20, 78);

            txtUserId.Name =
                "txtUserId";

            txtUserId.ReadOnly =
                true;

            txtUserId.Size =
                new Size(150, 27);

            #endregion

            #region Username

            lblUsername.AutoSize = true;

            lblUsername.Font =
                new Font(
                    "Segoe UI",
                    9F);

            lblUsername.ForeColor =
                Color.FromArgb(71, 85, 105);

            lblUsername.Location =
                new Point(190, 55);

            lblUsername.Text =
                "Username";

            txtUsername.BorderStyle =
                BorderStyle.FixedSingle;

            txtUsername.Location =
                new Point(190, 78);

            txtUsername.Name =
                "txtUsername";

            txtUsername.Size =
                new Size(250, 27);

            #endregion

            #region Password

            lblPassword.AutoSize = true;

            lblPassword.Font =
                new Font(
                    "Segoe UI",
                    9F);

            lblPassword.ForeColor =
                Color.FromArgb(71, 85, 105);

            lblPassword.Location =
                new Point(460, 55);

            lblPassword.Text =
                "Password Hash";

            txtPassword.BorderStyle =
                BorderStyle.FixedSingle;

            txtPassword.Location =
                new Point(460, 78);

            txtPassword.Name =
                "txtPassword";

            txtPassword.Size =
                new Size(300, 27);

            #endregion

            #region Active

            chkIsActive.AutoSize = true;

            chkIsActive.Checked =
                true;

            chkIsActive.CheckState =
                CheckState.Checked;

            chkIsActive.Font =
                new Font(
                    "Segoe UI",
                    9F);

            chkIsActive.ForeColor =
                Color.FromArgb(71, 85, 105);

            chkIsActive.Location =
                new Point(790, 80);

            chkIsActive.Name =
                "chkIsActive";

            chkIsActive.Text =
                "Active";

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
                new Point(40, 270);

            btnAdd.Name =
                "btnAdd";

            btnAdd.Size =
                new Size(110, 40);

            btnAdd.Text =
                "Add User";

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
                new Point(165, 270);

            btnEdit.Name =
                "btnEdit";

            btnEdit.Size =
                new Size(110, 40);

            btnEdit.Text =
                "Update User";

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
                new Point(290, 270);

            btnDelete.Name =
                "btnDelete";

            btnDelete.Size =
                new Size(110, 40);

            btnDelete.Text =
                "Delete User";

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
                new Point(415, 270);

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
                new Point(40, 335);

            lblSearch.Text =
                "Search";

            txtSearch.BorderStyle =
                BorderStyle.FixedSingle;

            txtSearch.Location =
                new Point(40, 357);

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
                new Point(360, 355);

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

            #region Users Grid

            dgvUsers.AllowUserToAddRows =
                false;

            dgvUsers.AllowUserToDeleteRows =
                false;

            dgvUsers.AllowUserToResizeRows =
                false;

            dgvUsers.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvUsers.BackgroundColor =
                Color.White;

            dgvUsers.BorderStyle =
                BorderStyle.None;

            dgvUsers.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(15, 23, 42);

            dgvUsers.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvUsers.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            dgvUsers.ColumnHeadersHeight =
                40;

            dgvUsers.EnableHeadersVisualStyles =
                false;

            dgvUsers.Location =
                new Point(40, 405);

            dgvUsers.MultiSelect =
                false;

            dgvUsers.Name =
                "dgvUsers";

            dgvUsers.ReadOnly =
                true;

            dgvUsers.RowHeadersVisible =
                false;

            dgvUsers.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvUsers.Size =
                new Size(1070, 190);

            dgvUsers.CellClick +=
                DgvUsers_CellClick;

            #endregion

            #region UserControl

            BackColor =
                Color.FromArgb(248, 250, 252);

            Controls.Add(lblTitle);
            Controls.Add(lblSubtitle);

            pnlDetails.Controls.Add(
                lblUserDetails);

            pnlDetails.Controls.Add(
                lblUserId);

            pnlDetails.Controls.Add(
                txtUserId);

            pnlDetails.Controls.Add(
                lblUsername);

            pnlDetails.Controls.Add(
                txtUsername);

            pnlDetails.Controls.Add(
                lblPassword);

            pnlDetails.Controls.Add(
                txtPassword);

            pnlDetails.Controls.Add(
                chkIsActive);

            Controls.Add(pnlDetails);

            Controls.Add(btnAdd);
            Controls.Add(btnEdit);
            Controls.Add(btnDelete);
            Controls.Add(btnClear);

            Controls.Add(lblSearch);
            Controls.Add(txtSearch);
            Controls.Add(btnClearSearch);

            Controls.Add(dgvUsers);

            Dock =
                DockStyle.Fill;

            Name =
                "UsersControl";

            Size =
                new Size(1150, 625);

            #endregion

            ((System.ComponentModel.ISupportInitialize)
                dgvUsers).EndInit();

            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}