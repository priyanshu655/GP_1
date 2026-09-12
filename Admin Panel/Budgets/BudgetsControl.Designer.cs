using System.Drawing;
using System.Windows.Forms;

namespace MoneyMap.AdminPanel.Budgets
{
    partial class BudgetsControl
    {
        private Label lblTitle;
        private Label lblSubtitle;

        private Panel pnlDetails;

        private Label lblBudgetDetails;
        private Label lblBudgetId;
        private Label lblUser;
        private Label lblBudgetPercentage;
        private Label lblBudgetMonth;

        private TextBox txtBudgetId;
        private ComboBox cmbUser;
        private TextBox txtBudgetPercentage;
        private DateTimePicker dtpBudgetMonth;

        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnClear;

        private Label lblSearch;
        private TextBox txtSearch;
        private Button btnClearSearch;

        private DataGridView dgvBudgets;

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

            lblBudgetDetails = new Label();
            lblBudgetId = new Label();
            lblUser = new Label();
            lblBudgetPercentage = new Label();
            lblBudgetMonth = new Label();

            txtBudgetId = new TextBox();
            cmbUser = new ComboBox();
            txtBudgetPercentage = new TextBox();
            dtpBudgetMonth = new DateTimePicker();

            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnClear = new Button();

            lblSearch = new Label();
            txtSearch = new TextBox();
            btnClearSearch = new Button();

            dgvBudgets = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)
                dgvBudgets).BeginInit();

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
                "Budgets Management";

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
                "Manage and monitor all budgets";

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
                new Size(1070, 180);

            #endregion

            #region Budget Details

            lblBudgetDetails.AutoSize = true;

            lblBudgetDetails.Font =
                new Font(
                    "Segoe UI",
                    12F,
                    FontStyle.Bold);

            lblBudgetDetails.ForeColor =
                Color.FromArgb(15, 23, 42);

            lblBudgetDetails.Location =
                new Point(20, 15);

            lblBudgetDetails.Name =
                "lblBudgetDetails";

            lblBudgetDetails.Text =
                "Budget Details";

            #endregion

            #region Budget ID

            lblBudgetId.AutoSize = true;

            lblBudgetId.Font =
                new Font(
                    "Segoe UI",
                    9F);

            lblBudgetId.ForeColor =
                Color.FromArgb(71, 85, 105);

            lblBudgetId.Location =
                new Point(20, 55);

            lblBudgetId.Text =
                "Budget ID";

            txtBudgetId.BackColor =
                Color.FromArgb(241, 245, 249);

            txtBudgetId.BorderStyle =
                BorderStyle.FixedSingle;

            txtBudgetId.Location =
                new Point(20, 78);

            txtBudgetId.Name =
                "txtBudgetId";

            txtBudgetId.ReadOnly =
                true;

            txtBudgetId.Size =
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
                new Size(240, 28);

            #endregion

            #region Budget Percentage

            lblBudgetPercentage.AutoSize = true;

            lblBudgetPercentage.Font =
                new Font(
                    "Segoe UI",
                    9F);

            lblBudgetPercentage.ForeColor =
                Color.FromArgb(71, 85, 105);

            lblBudgetPercentage.Location =
                new Point(450, 55);

            lblBudgetPercentage.Text =
                "Budget Percentage";

            txtBudgetPercentage.BorderStyle =
                BorderStyle.FixedSingle;

            txtBudgetPercentage.Location =
                new Point(450, 78);

            txtBudgetPercentage.Name =
                "txtBudgetPercentage";

            txtBudgetPercentage.Size =
                new Size(200, 27);

            #endregion

            #region Budget Month

            lblBudgetMonth.AutoSize = true;

            lblBudgetMonth.Font =
                new Font(
                    "Segoe UI",
                    9F);

            lblBudgetMonth.ForeColor =
                Color.FromArgb(71, 85, 105);

            lblBudgetMonth.Location =
                new Point(670, 55);

            lblBudgetMonth.Text =
                "Budget Month";

            dtpBudgetMonth.Format =
                DateTimePickerFormat.Custom;

            dtpBudgetMonth.CustomFormat =
                "MMMM yyyy";

            dtpBudgetMonth.ShowUpDown =
                true;

            dtpBudgetMonth.Location =
                new Point(670, 78);

            dtpBudgetMonth.Name =
                "dtpBudgetMonth";

            dtpBudgetMonth.Size =
                new Size(200, 27);

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
                new Point(40, 300);

            btnAdd.Name =
                "btnAdd";

            btnAdd.Size =
                new Size(120, 40);

            btnAdd.Text =
                "Add Budget";

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
                new Point(175, 300);

            btnEdit.Name =
                "btnEdit";

            btnEdit.Size =
                new Size(130, 40);

            btnEdit.Text =
                "Update Budget";

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
                new Point(320, 300);

            btnDelete.Name =
                "btnDelete";

            btnDelete.Size =
                new Size(130, 40);

            btnDelete.Text =
                "Delete Budget";

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
                new Point(465, 300);

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
                new Point(40, 365);

            lblSearch.Text =
                "Search";

            txtSearch.BorderStyle =
                BorderStyle.FixedSingle;

            txtSearch.Location =
                new Point(40, 387);

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
                new Point(360, 385);

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

            #region Budgets Grid

            dgvBudgets.AllowUserToAddRows =
                false;

            dgvBudgets.AllowUserToDeleteRows =
                false;

            dgvBudgets.AllowUserToResizeRows =
                false;

            dgvBudgets.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvBudgets.BackgroundColor =
                Color.White;

            dgvBudgets.BorderStyle =
                BorderStyle.None;

            dgvBudgets.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(15, 23, 42);

            dgvBudgets.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvBudgets.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            dgvBudgets.ColumnHeadersHeight =
                40;

            dgvBudgets.EnableHeadersVisualStyles =
                false;

            dgvBudgets.Location =
                new Point(40, 430);

            dgvBudgets.MultiSelect =
                false;

            dgvBudgets.Name =
                "dgvBudgets";

            dgvBudgets.ReadOnly =
                true;

            dgvBudgets.RowHeadersVisible =
                false;

            dgvBudgets.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvBudgets.Size =
                new Size(1070, 430);

            dgvBudgets.CellClick +=
                DgvBudgets_CellClick;

            #endregion

            #region UserControl

            BackColor =
                Color.FromArgb(248, 250, 252);

            Controls.Add(lblTitle);
            Controls.Add(lblSubtitle);

            pnlDetails.Controls.Add(
                lblBudgetDetails);

            pnlDetails.Controls.Add(
                lblBudgetId);

            pnlDetails.Controls.Add(
                txtBudgetId);

            pnlDetails.Controls.Add(
                lblUser);

            pnlDetails.Controls.Add(
                cmbUser);

            pnlDetails.Controls.Add(
                lblBudgetPercentage);

            pnlDetails.Controls.Add(
                txtBudgetPercentage);

            pnlDetails.Controls.Add(
                lblBudgetMonth);

            pnlDetails.Controls.Add(
                dtpBudgetMonth);

            Controls.Add(pnlDetails);

            Controls.Add(btnAdd);
            Controls.Add(btnEdit);
            Controls.Add(btnDelete);
            Controls.Add(btnClear);

            Controls.Add(lblSearch);
            Controls.Add(txtSearch);
            Controls.Add(btnClearSearch);

            Controls.Add(dgvBudgets);

            Dock =
                DockStyle.Fill;

            Name =
                "BudgetsControl";

            Size =
                new Size(1150, 625);

            #endregion

            ((System.ComponentModel.ISupportInitialize)
                dgvBudgets).EndInit();

            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}