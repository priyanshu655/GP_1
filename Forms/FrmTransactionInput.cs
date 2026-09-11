using GP_1.Models;
using GP_1.Services;

namespace GP_1.Forms
{
    public partial class FrmTransactionInput : Form
    {
        private const int CurrentUserId = 1;

        private TransactionService transactionService = new TransactionService();

        private Transaction? currentTransaction;

        public bool IsUpdateMode
        {
            get
            {
                return currentTransaction != null;
            }
        }

        public FrmTransactionInput()
        {
            InitializeComponent();
        }

        public FrmTransactionInput(Transaction transaction)
        {
            InitializeComponent();
            currentTransaction = transaction;
        }

        //START: Added By: Vishw Date: 11-sep-2026 Desc: Block negative value input on amount
        private void nudAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '-')
            {
                e.Handled = true;
            }
        }
        //END: Added By: Vishw Date: 11-sep-2026 Desc: Block negative value input on amount

        //START: Added By: Vishw Date: 11-sep-2026 Desc: Form load event - initialize controls and load data
        private void FrmTransactionInput_Load(object sender, EventArgs e)
        {
            dtpTransactionDate.MaxDate = DateTime.Today;
            dtpTransactionDate.Value = DateTime.Today;
            rdoIncome.Checked = true;

            LoadIncomeCategories();
            LoadExpenseCategories();
            UpdateCategoryVisibility();

            if (IsUpdateMode)
            {
                this.Text = "Update Income / Expense";
                btnSave.Text = "Update";
                LoadTransactionIntoControls();
            }
        }
        //END: Added By: Vishw Date: 11-sep-2026 Desc: Form load event - initialize controls and load data

        //START: Added By: Vishw Date: 11-sep-2026 Desc: Load income categories into ComboBox
        private void LoadIncomeCategories()
        {
            List<Transaction> incomeCategories = transactionService.GetCategoriesByTypeName("Income");

            cmbIncomeCategory.DataSource = null;
            cmbIncomeCategory.DisplayMember = "CategoryName";
            cmbIncomeCategory.ValueMember = "CategoryId";
            cmbIncomeCategory.DataSource = incomeCategories;
            cmbIncomeCategory.SelectedIndex = -1;
        }
        //END: Added By: Vishw Date: 11-sep-2026 Desc: Load income categories into ComboBox

        //START: Added By: Vishw Date: 11-sep-2026 Desc: Load expense categories into ListBox
        private void LoadExpenseCategories()
        {
            List<Transaction> expenseCategories = transactionService.GetCategoriesByTypeName("Expense");

            lstExpenseCategory.DataSource = null;
            lstExpenseCategory.DisplayMember = "CategoryName";
            lstExpenseCategory.ValueMember = "CategoryId";
            lstExpenseCategory.DataSource = expenseCategories;
            lstExpenseCategory.ClearSelected();
        }
        //END: Added By: Vishw Date: 11-sep-2026 Desc: Load expense categories into ListBox

        //START: Added By: Vishw Date: 11-sep-2026 Desc: Load the selected transaction into the input controls
        private void LoadTransactionIntoControls()
        {
            if (currentTransaction == null)
            {
                return;
            }

            dtpTransactionDate.Value = currentTransaction.TransactionDate;
            txtDescription.Text = currentTransaction.Description;
            nudAmount.Value = currentTransaction.Amount;

            if (currentTransaction.TransactionType == "Income")
            {
                rdoIncome.Checked = true;
                SelectIncomeCategory(currentTransaction.CategoryId);
            }
            else
            {
                rdoExpense.Checked = true;
                SelectExpenseCategory(currentTransaction.CategoryId);
            }
        }
        //END: Added By: Vishw Date: 11-sep-2026 Desc: Load the selected transaction into the input controls

        //START: Added By: Vishw Date: 11-sep-2026 Desc: Select income category in ComboBox by ID
        private void SelectIncomeCategory(int categoryId)
        {
            for (int i = 0; i < cmbIncomeCategory.Items.Count; i++)
            {
                Transaction? category = cmbIncomeCategory.Items[i] as Transaction;

                if (category != null && category.CategoryId == categoryId)
                {
                    cmbIncomeCategory.SelectedIndex = i;
                    return;
                }
            }
        }
        //END: Added By: Vishw Date: 11-sep-2026 Desc: Select income category in ComboBox by ID

        //START: Added By: Vishw Date: 11-sep-2026 Desc: Select expense category in ListBox by ID
        private void SelectExpenseCategory(int categoryId)
        {
            for (int i = 0; i < lstExpenseCategory.Items.Count; i++)
            {
                Transaction? category = lstExpenseCategory.Items[i] as Transaction;

                if (category != null && category.CategoryId == categoryId)
                {
                    lstExpenseCategory.SelectedIndex = i;
                    return;
                }
            }
        }
        //END: Added By: Vishw Date: 11-sep-2026 Desc: Select expense category in ListBox by ID

        //START: Added By: Vishw Date: 11-sep-2026 Desc: Update category control visibility based on radio button selection
        private void UpdateCategoryVisibility()
        {
            if (rdoIncome.Checked)
            {
                cmbIncomeCategory.Visible = true;
                lstExpenseCategory.Visible = false;
            }
            else
            {
                cmbIncomeCategory.Visible = false;
                lstExpenseCategory.Visible = true;
            }
        }
        //END: Added By: Vishw Date: 11-sep-2026 Desc: Update category control visibility based on radio button selection

        //START: Added By: Vishw Date: 11-sep-2026 Desc: Radio button checked changed event handlers
        private void rdoIncome_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCategoryVisibility();
        }

        private void rdoExpense_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCategoryVisibility();
        }
        //END: Added By: Vishw Date: 11-sep-2026 Desc: Radio button checked changed event handlers

        //START: Added By: Vishw Date: 11-sep-2026 Desc: Save button click - insert or update the transaction
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }

            int categoryId = GetSelectedCategoryId();

            if (categoryId == 0)
            {
                MessageBox.Show("Please select a category.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (IsUpdateMode)
            {
                Transaction transaction = new Transaction();
                transaction.TransactionId = currentTransaction!.TransactionId;
                transaction.UserId = CurrentUserId;
                transaction.CategoryId = categoryId;
                transaction.TransactionDate = dtpTransactionDate.Value.Date;
                transaction.Description = txtDescription.Text.Trim();
                transaction.Amount = nudAmount.Value;

                transactionService.UpdateTransaction(transaction);
            }
            else
            {
                Transaction transaction = new Transaction();
                transaction.UserId = CurrentUserId;
                transaction.CategoryId = categoryId;
                transaction.TransactionDate = dtpTransactionDate.Value.Date;
                transaction.Description = txtDescription.Text.Trim();
                transaction.Amount = nudAmount.Value;

                transactionService.AddTransaction(transaction);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        //END: Added By: Vishw Date: 11-sep-2026 Desc: Save button click - insert or update the transaction

        //START: Added By: Vishw Date: 11-sep-2026 Desc: Cancel button click - close without saving
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        //END: Added By: Vishw Date: 11-sep-2026 Desc: Cancel button click - close without saving

        //START: Added By: Vishw Date: 11-sep-2026 Desc: Validate user input before insert or update
        private bool ValidateInput()
        {
            if (!rdoIncome.Checked && !rdoExpense.Checked)
            {
                MessageBox.Show("Please select a transaction type.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (nudAmount.Value <= 0)
            {
                MessageBox.Show("Please enter a valid amount.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudAmount.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtDescription.Text) && txtDescription.Text.Trim().Length > 255)
            {
                MessageBox.Show("Description cannot exceed 255 characters.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescription.Focus();
                return false;
            }

            return true;
        }
        //END: Added By: Vishw Date: 11-sep-2026 Desc: Validate user input before insert or update

        //START: Added By: Vishw Date: 11-sep-2026 Desc: Get selected category ID from appropriate control
        private int GetSelectedCategoryId()
        {
            if (rdoIncome.Checked)
            {
                if (cmbIncomeCategory.SelectedIndex >= 0 && cmbIncomeCategory.SelectedItem is Transaction selectedIncomeCategory)
                {
                    return selectedIncomeCategory.CategoryId;
                }
            }
            else if (rdoExpense.Checked)
            {
                if (lstExpenseCategory.SelectedIndex >= 0 && lstExpenseCategory.SelectedItem is Transaction selectedExpenseCategory)
                {
                    return selectedExpenseCategory.CategoryId;
                }
            }

            return 0;
        }
        //END: Added By: Vishw Date: 11-sep-2026 Desc: Get selected category ID from appropriate control
    }
}