using System.Drawing;
using System.Windows.Forms;

namespace MoneyMap.AdminPanel.Transactions
{
    partial class TransactionsControl
    {
        private Label lblTitle;
        private Label lblSubtitle;

        private Panel pnlDetails;

        private Label lblTransactionDetails;
        private Label lblTransactionId;
        private Label lblUser;
        private Label lblCategory;
        private Label lblTransactionDate;
        private Label lblDescription;
        private Label lblAmount;

        private TextBox txtTransactionId;
        private ComboBox cmbUser;
        private ComboBox cmbCategory;
        private DateTimePicker dtpTransactionDate;
        private TextBox txtDescription;
        private TextBox txtAmount;

        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnClear;

        private Label lblSearch;
        private TextBox txtSearch;

        private Button btnClearSearch;

        private DataGridView dgvTransactions;

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

            lblTransactionDetails = new Label();
            lblTransactionId = new Label();
            lblUser = new Label();
            lblCategory = new Label();
            lblTransactionDate = new Label();
            lblDescription = new Label();
            lblAmount = new Label();

            txtTransactionId = new TextBox();
            cmbUser = new ComboBox();
            cmbCategory = new ComboBox();
            dtpTransactionDate = new DateTimePicker();
            txtDescription = new TextBox();
            txtAmount = new TextBox();

            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnClear = new Button();

            lblSearch = new Label();
            txtSearch = new TextBox();

            btnClearSearch = new Button();

            dgvTransactions = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)
                dgvTransactions).BeginInit();

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
                "Transactions Management";

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
                "Manage and monitor all transactions";

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
                new Size(1070, 190);

            #endregion

            #region Transaction Details Title

            lblTransactionDetails.AutoSize = true;

            lblTransactionDetails.Font =
                new Font(
                    "Segoe UI",
                    12F,
                    FontStyle.Bold);

            lblTransactionDetails.ForeColor =
                Color.FromArgb(15, 23, 42);

            lblTransactionDetails.Location =
                new Point(20, 15);

            lblTransactionDetails.Name =
                "lblTransactionDetails";

            lblTransactionDetails.Text =
                "Transaction Details";

            #endregion

            #region Transaction ID

            lblTransactionId.AutoSize = true;

            lblTransactionId.Font =
                new Font(
                    "Segoe UI",
                    9F);

            lblTransactionId.ForeColor =
                Color.FromArgb(71, 85, 105);

            lblTransactionId.Location =
                new Point(20, 55);

            lblTransactionId.Text =
                "Transaction ID";

            txtTransactionId.BackColor =
                Color.FromArgb(241, 245, 249);

            txtTransactionId.BorderStyle =
                BorderStyle.FixedSingle;

            txtTransactionId.Location =
                new Point(20, 78);

            txtTransactionId.Name =
                "txtTransactionId";

            txtTransactionId.ReadOnly =
                true;

            txtTransactionId.Size =
                new Size(160, 27);

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
                new Point(200, 55);

            lblUser.Text =
                "User";

            cmbUser.DropDownStyle =
                ComboBoxStyle.DropDownList;

            cmbUser.FormattingEnabled =
                true;

            cmbUser.Location =
                new Point(200, 78);

            cmbUser.Name =
                "cmbUser";

            cmbUser.Size =
                new Size(220, 28);

            #endregion

            #region Category

            lblCategory.AutoSize = true;

            lblCategory.Font =
                new Font(
                    "Segoe UI",
                    9F);

            lblCategory.ForeColor =
                Color.FromArgb(71, 85, 105);

            lblCategory.Location =
                new Point(440, 55);

            lblCategory.Text =
                "Category";

            cmbCategory.DropDownStyle =
                ComboBoxStyle.DropDownList;

            cmbCategory.FormattingEnabled =
                true;

            cmbCategory.Location =
                new Point(440, 78);

            cmbCategory.Name =
                "cmbCategory";

            cmbCategory.Size =
                new Size(220, 28);

            #endregion

            #region Transaction Date

            lblTransactionDate.AutoSize = true;

            lblTransactionDate.Font =
                new Font(
                    "Segoe UI",
                    9F);

            lblTransactionDate.ForeColor =
                Color.FromArgb(71, 85, 105);

            lblTransactionDate.Location =
                new Point(680, 55);

            lblTransactionDate.Text =
                "Transaction Date";

            dtpTransactionDate.Format =
                DateTimePickerFormat.Short;

            dtpTransactionDate.Location =
                new Point(680, 78);

            dtpTransactionDate.Name =
                "dtpTransactionDate";

            dtpTransactionDate.Size =
                new Size(180, 27);

            #endregion

            #region Description

            lblDescription.AutoSize = true;

            lblDescription.Font =
                new Font(
                    "Segoe UI",
                    9F);

            lblDescription.ForeColor =
                Color.FromArgb(71, 85, 105);

            lblDescription.Location =
                new Point(20, 120);

            lblDescription.Text =
                "Description";

            txtDescription.BorderStyle =
                BorderStyle.FixedSingle;

            txtDescription.Location =
                new Point(20, 143);

            txtDescription.Name =
                "txtDescription";

            txtDescription.Size =
                new Size(500, 27);

            #endregion

            #region Amount

            lblAmount.AutoSize = true;

            lblAmount.Font =
                new Font(
                    "Segoe UI",
                    9F);

            lblAmount.ForeColor =
                Color.FromArgb(71, 85, 105);

            lblAmount.Location =
                new Point(540, 120);

            lblAmount.Text =
                "Amount";

            txtAmount.BorderStyle =
                BorderStyle.FixedSingle;

            txtAmount.Location =
                new Point(540, 143);

            txtAmount.Name =
                "txtAmount";

            txtAmount.Size =
                new Size(180, 27);

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
                new Point(40, 310);

            btnAdd.Name =
                "btnAdd";

            btnAdd.Size =
                new Size(130, 40);

            btnAdd.Text =
                "Add Transaction";

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
                new Point(185, 310);

            btnEdit.Name =
                "btnEdit";

            btnEdit.Size =
                new Size(130, 40);

            btnEdit.Text =
                "Update Transaction";

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
                new Point(330, 310);

            btnDelete.Name =
                "btnDelete";

            btnDelete.Size =
                new Size(130, 40);

            btnDelete.Text =
                "Delete Transaction";

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
                new Point(475, 310);

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
                new Point(40, 370);

            lblSearch.Text =
                "Search";

            txtSearch.BorderStyle =
                BorderStyle.FixedSingle;

            txtSearch.Location =
                new Point(40, 392);

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
                new Point(360, 390);

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

            #region Transactions Grid

            dgvTransactions.AllowUserToAddRows =
                false;

            dgvTransactions.AllowUserToDeleteRows =
                false;

            dgvTransactions.AllowUserToResizeRows =
                false;

            dgvTransactions.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvTransactions.BackgroundColor =
                Color.White;

            dgvTransactions.BorderStyle =
                BorderStyle.None;

            dgvTransactions.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(15, 23, 42);

            dgvTransactions.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvTransactions.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            dgvTransactions.ColumnHeadersHeight =
                40;

            dgvTransactions.EnableHeadersVisualStyles =
                false;

            dgvTransactions.Location =
                new Point(40, 435);

            dgvTransactions.MultiSelect =
                false;

            dgvTransactions.Name =
                "dgvTransactions";

            dgvTransactions.ReadOnly =
                true;

            dgvTransactions.RowHeadersVisible =
                false;

            dgvTransactions.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvTransactions.Size =
                new Size(1070, 430);

            dgvTransactions.CellClick +=
                DgvTransactions_CellClick;

            #endregion

            #region UserControl

            BackColor =
                Color.FromArgb(248, 250, 252);

            Controls.Add(lblTitle);
            Controls.Add(lblSubtitle);

            pnlDetails.Controls.Add(
                lblTransactionDetails);

            pnlDetails.Controls.Add(
                lblTransactionId);

            pnlDetails.Controls.Add(
                txtTransactionId);

            pnlDetails.Controls.Add(
                lblUser);

            pnlDetails.Controls.Add(
                cmbUser);

            pnlDetails.Controls.Add(
                lblCategory);

            pnlDetails.Controls.Add(
                cmbCategory);

            pnlDetails.Controls.Add(
                lblTransactionDate);

            pnlDetails.Controls.Add(
                dtpTransactionDate);

            pnlDetails.Controls.Add(
                lblDescription);

            pnlDetails.Controls.Add(
                txtDescription);

            pnlDetails.Controls.Add(
                lblAmount);

            pnlDetails.Controls.Add(
                txtAmount);

            Controls.Add(pnlDetails);

            Controls.Add(btnAdd);
            Controls.Add(btnEdit);
            Controls.Add(btnDelete);
            Controls.Add(btnClear);

            Controls.Add(lblSearch);
            Controls.Add(txtSearch);

            Controls.Add(btnClearSearch);

            Controls.Add(dgvTransactions);

            Dock =
                DockStyle.Fill;

            Name =
                "TransactionsControl";

            Size =
                new Size(1150, 625);

            #endregion

            ((System.ComponentModel.ISupportInitialize)
                dgvTransactions).EndInit();

            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}