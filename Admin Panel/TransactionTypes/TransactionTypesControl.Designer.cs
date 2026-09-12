using System.Drawing;
using System.Windows.Forms;

namespace MoneyMap.AdminPanel.TransactionTypes
{
    partial class TransactionTypesControl
    {
        private Label lblTitle;
        private Label lblSubtitle;

        private Panel pnlDetails;

        private Label lblTransactionTypeDetails;
        private Label lblTypeId;
        private Label lblTypeName;

        private TextBox txtTypeId;
        private TextBox txtTypeName;

        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnClear;

        private Label lblSearch;
        private TextBox txtSearch;
        private Button btnClearSearch;

        private DataGridView dgvTransactionTypes;

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

            lblTransactionTypeDetails = new Label();
            lblTypeId = new Label();
            lblTypeName = new Label();

            txtTypeId = new TextBox();
            txtTypeName = new TextBox();

            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnClear = new Button();

            lblSearch = new Label();
            txtSearch = new TextBox();
            btnClearSearch = new Button();

            dgvTransactionTypes = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)
                dgvTransactionTypes).BeginInit();

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
                "Transaction Types Management";

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
                "Manage all transaction types";

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

            #region Transaction Type Details

            lblTransactionTypeDetails.AutoSize = true;

            lblTransactionTypeDetails.Font =
                new Font(
                    "Segoe UI",
                    12F,
                    FontStyle.Bold);

            lblTransactionTypeDetails.ForeColor =
                Color.FromArgb(15, 23, 42);

            lblTransactionTypeDetails.Location =
                new Point(20, 15);

            lblTransactionTypeDetails.Name =
                "lblTransactionTypeDetails";

            lblTransactionTypeDetails.Text =
                "Transaction Type Details";

            #endregion

            #region Type ID

            lblTypeId.AutoSize = true;

            lblTypeId.Font =
                new Font(
                    "Segoe UI",
                    9F);

            lblTypeId.ForeColor =
                Color.FromArgb(71, 85, 105);

            lblTypeId.Location =
                new Point(20, 55);

            lblTypeId.Text =
                "Type ID";

            txtTypeId.BackColor =
                Color.FromArgb(241, 245, 249);

            txtTypeId.BorderStyle =
                BorderStyle.FixedSingle;

            txtTypeId.Location =
                new Point(20, 78);

            txtTypeId.Name =
                "txtTypeId";

            txtTypeId.ReadOnly =
                true;

            txtTypeId.Size =
                new Size(180, 27);

            #endregion

            #region Type Name

            lblTypeName.AutoSize = true;

            lblTypeName.Font =
                new Font(
                    "Segoe UI",
                    9F);

            lblTypeName.ForeColor =
                Color.FromArgb(71, 85, 105);

            lblTypeName.Location =
                new Point(230, 55);

            lblTypeName.Text =
                "Transaction Type";

            txtTypeName.BorderStyle =
                BorderStyle.FixedSingle;

            txtTypeName.Location =
                new Point(230, 78);

            txtTypeName.Name =
                "txtTypeName";

            txtTypeName.Size =
                new Size(350, 27);

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
                new Size(150, 40);

            btnAdd.Text =
                "Add Type";

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
                new Point(205, 270);

            btnEdit.Name =
                "btnEdit";

            btnEdit.Size =
                new Size(150, 40);

            btnEdit.Text =
                "Update Type";

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
                new Point(370, 270);

            btnDelete.Name =
                "btnDelete";

            btnDelete.Size =
                new Size(150, 40);

            btnDelete.Text =
                "Delete Type";

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
                new Point(535, 270);

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

            #region Transaction Types Grid

            dgvTransactionTypes.AllowUserToAddRows =
                false;

            dgvTransactionTypes.AllowUserToDeleteRows =
                false;

            dgvTransactionTypes.AllowUserToResizeRows =
                false;

            dgvTransactionTypes.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvTransactionTypes.BackgroundColor =
                Color.White;

            dgvTransactionTypes.BorderStyle =
                BorderStyle.None;

            dgvTransactionTypes.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(15, 23, 42);

            dgvTransactionTypes.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvTransactionTypes.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            dgvTransactionTypes.ColumnHeadersHeight =
                40;

            dgvTransactionTypes.EnableHeadersVisualStyles =
                false;

            dgvTransactionTypes.Location =
                new Point(40, 405);

            dgvTransactionTypes.MultiSelect =
                false;

            dgvTransactionTypes.Name =
                "dgvTransactionTypes";

            dgvTransactionTypes.ReadOnly =
                true;

            dgvTransactionTypes.RowHeadersVisible =
                false;

            dgvTransactionTypes.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvTransactionTypes.Size =
                new Size(1070, 190);

            dgvTransactionTypes.CellClick +=
                DgvTransactionTypes_CellClick;

            #endregion

            #region UserControl

            BackColor =
                Color.FromArgb(248, 250, 252);

            Controls.Add(lblTitle);
            Controls.Add(lblSubtitle);

            pnlDetails.Controls.Add(
                lblTransactionTypeDetails);

            pnlDetails.Controls.Add(
                lblTypeId);

            pnlDetails.Controls.Add(
                txtTypeId);

            pnlDetails.Controls.Add(
                lblTypeName);

            pnlDetails.Controls.Add(
                txtTypeName);

            Controls.Add(pnlDetails);

            Controls.Add(btnAdd);
            Controls.Add(btnEdit);
            Controls.Add(btnDelete);
            Controls.Add(btnClear);

            Controls.Add(lblSearch);
            Controls.Add(txtSearch);
            Controls.Add(btnClearSearch);

            Controls.Add(dgvTransactionTypes);

            Dock =
                DockStyle.Fill;

            Name =
                "TransactionTypesControl";

            Size =
                new Size(1150, 625);

            #endregion

            ((System.ComponentModel.ISupportInitialize)
                dgvTransactionTypes).EndInit();

            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}