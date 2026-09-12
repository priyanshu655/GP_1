using System.Drawing;
using System.Windows.Forms;

namespace MoneyMap.AdminPanel.Categories
{
    partial class CategoriesControl
    {
        private Label lblTitle;
        private Label lblSubtitle;

        private Panel pnlDetails;

        private Label lblCategoryDetails;
        private Label lblCategoryId;
        private Label lblType;
        private Label lblCategoryName;

        private TextBox txtCategoryId;
        private ComboBox cmbType;
        private TextBox txtCategoryName;

        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnClear;

        private Label lblSearch;
        private TextBox txtSearch;

        private Button btnClearSearch;

        private DataGridView dgvCategories;

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

            lblCategoryDetails = new Label();
            lblCategoryId = new Label();
            lblType = new Label();
            lblCategoryName = new Label();

            txtCategoryId = new TextBox();
            cmbType = new ComboBox();
            txtCategoryName = new TextBox();

            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnClear = new Button();

            lblSearch = new Label();
            txtSearch = new TextBox();

            btnClearSearch = new Button();

            dgvCategories = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)
                dgvCategories).BeginInit();

            SuspendLayout();

            #region Title

            lblTitle.AutoSize = true;

            lblTitle.Font = new Font(
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
                "Categories Management";

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
                "Manage and monitor all categories";

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

            #region Category Details Title

            lblCategoryDetails.AutoSize = true;

            lblCategoryDetails.Font =
                new Font(
                    "Segoe UI",
                    12F,
                    FontStyle.Bold);

            lblCategoryDetails.ForeColor =
                Color.FromArgb(15, 23, 42);

            lblCategoryDetails.Location =
                new Point(20, 15);

            lblCategoryDetails.Name =
                "lblCategoryDetails";

            lblCategoryDetails.Text =
                "Category Details";

            #endregion

            #region Category ID

            lblCategoryId.AutoSize = true;

            lblCategoryId.Font =
                new Font(
                    "Segoe UI",
                    9F);

            lblCategoryId.ForeColor =
                Color.FromArgb(71, 85, 105);

            lblCategoryId.Location =
                new Point(20, 55);

            lblCategoryId.Text =
                "Category ID";

            txtCategoryId.BackColor =
                Color.FromArgb(241, 245, 249);

            txtCategoryId.BorderStyle =
                BorderStyle.FixedSingle;

            txtCategoryId.Location =
                new Point(20, 78);

            txtCategoryId.Name =
                "txtCategoryId";

            txtCategoryId.ReadOnly =
                true;

            txtCategoryId.Size =
                new Size(180, 27);

            #endregion

            #region Type

            lblType.AutoSize = true;

            lblType.Font =
                new Font(
                    "Segoe UI",
                    9F);

            lblType.ForeColor =
                Color.FromArgb(71, 85, 105);

            lblType.Location =
                new Point(230, 55);

            lblType.Text =
                "Transaction Type";

            cmbType.DropDownStyle =
                ComboBoxStyle.DropDownList;

            cmbType.FormattingEnabled =
                true;

            cmbType.Location =
                new Point(230, 78);

            cmbType.Name =
                "cmbType";

            cmbType.Size =
                new Size(220, 28);

            #endregion

            #region Category Name

            lblCategoryName.AutoSize = true;

            lblCategoryName.Font =
                new Font(
                    "Segoe UI",
                    9F);

            lblCategoryName.ForeColor =
                Color.FromArgb(71, 85, 105);

            lblCategoryName.Location =
                new Point(480, 55);

            lblCategoryName.Text =
                "Category Name";

            txtCategoryName.BorderStyle =
                BorderStyle.FixedSingle;

            txtCategoryName.Location =
                new Point(480, 78);

            txtCategoryName.Name =
                "txtCategoryName";

            txtCategoryName.Size =
                new Size(380, 27);

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
                new Size(120, 40);

            btnAdd.Text =
                "Add Category";

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
                new Point(175, 270);

            btnEdit.Name =
                "btnEdit";

            btnEdit.Size =
                new Size(120, 40);

            btnEdit.Text =
                "Update Category";

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
                new Point(310, 270);

            btnDelete.Name =
                "btnDelete";

            btnDelete.Size =
                new Size(120, 40);

            btnDelete.Text =
                "Delete Category";

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
                new Point(445, 270);

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
                new Point(365, 355);

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

            #region Categories Grid

            dgvCategories.AllowUserToAddRows =
                false;

            dgvCategories.AllowUserToDeleteRows =
                false;

            dgvCategories.AllowUserToResizeRows =
                false;

            dgvCategories.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvCategories.BackgroundColor =
                Color.White;

            dgvCategories.BorderStyle =
                BorderStyle.None;

            dgvCategories.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(15, 23, 42);

            dgvCategories.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvCategories.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            dgvCategories.ColumnHeadersHeight =
                40;

            dgvCategories.EnableHeadersVisualStyles =
                false;

            dgvCategories.Location =
                new Point(40, 400);

            dgvCategories.MultiSelect =
                false;

            dgvCategories.Name =
                "dgvCategories";

            dgvCategories.ReadOnly =
                true;

            dgvCategories.RowHeadersVisible =
                false;

            dgvCategories.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvCategories.Size =
                new Size(1070, 450);

            dgvCategories.CellClick +=
                DgvCategories_CellClick;

            #endregion

            #region UserControl

            BackColor =
                Color.FromArgb(248, 250, 252);

            Controls.Add(lblTitle);
            Controls.Add(lblSubtitle);

            pnlDetails.Controls.Add(
                lblCategoryDetails);

            pnlDetails.Controls.Add(
                lblCategoryId);

            pnlDetails.Controls.Add(
                txtCategoryId);

            pnlDetails.Controls.Add(
                lblType);

            pnlDetails.Controls.Add(
                cmbType);

            pnlDetails.Controls.Add(
                lblCategoryName);

            pnlDetails.Controls.Add(
                txtCategoryName);

            Controls.Add(pnlDetails);

            Controls.Add(btnAdd);
            Controls.Add(btnEdit);
            Controls.Add(btnDelete);
            Controls.Add(btnClear);

            Controls.Add(lblSearch);
            Controls.Add(txtSearch);

            Controls.Add(btnClearSearch);

            Controls.Add(dgvCategories);

            Dock =
                DockStyle.Fill;

            Name =
                "CategoriesControl";

            Size =
                new Size(1150, 625);

            #endregion

            ((System.ComponentModel.ISupportInitialize)
                dgvCategories).EndInit();

            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}