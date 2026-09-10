using GP_1.Models;
using GP_1.Services;

namespace GP_1.Forms
{
    public partial class FrmTransaction : Form
    {
        private const int CurrentUserId = 1;

        private long selectedTransactionId = 0;

        private TransactionService transactionService = new TransactionService();

        public FrmTransaction()
        {
            InitializeComponent();
        }

        //START: Added By: Vishw Date: 10-sep-2026 Desc: Block negative value input on amount
        private void nudAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '-')
            {
                e.Handled = true;
            }
        }
        //END: Added By: Vishw Date: 10-sep-2026 Desc: Block negative value input on amount

        //START: Added By: Vishw Date: 10-sep-2026 Desc: Form load event - initialize controls and load data
        private void FrmTransaction_Load(object sender, EventArgs e)
        {
            dtpTransactionDate.MaxDate = DateTime.Today;
            dtpTransactionDate.Value = DateTime.Today;
            rdoIncome.Checked = true;

            LoadIncomeCategories();
            LoadExpenseCategories();
            UpdateCategoryVisibility();
            LoadTransactions();
        }
        //END: Added By: Vishw Date: 10-sep-2026 Desc: Form load event - initialize controls and load data

        //START: Added By: Vishw Date: 10-sep-2026 Desc: Load income categories into ComboBox
        private void LoadIncomeCategories()
        {
            List<Transaction> incomeCategories = transactionService.GetCategoriesByTypeName("Income");

            cmbIncomeCategory.DataSource = null;
            cmbIncomeCategory.DisplayMember = "CategoryName";
            cmbIncomeCategory.ValueMember = "CategoryId";
            cmbIncomeCategory.DataSource = incomeCategories;
            cmbIncomeCategory.SelectedIndex = -1;
        }
        //END: Added By: Vishw Date: 10-sep-2026 Desc: Load income categories into ComboBox

        //START: Added By: Vishw Date: 10-sep-2026 Desc: Load expense categories into ListBox
        private void LoadExpenseCategories()
        {
            List<Transaction> expenseCategories = transactionService.GetCategoriesByTypeName("Expense");

            lstExpenseCategory.DataSource = null;
            lstExpenseCategory.DisplayMember = "CategoryName";
            lstExpenseCategory.ValueMember = "CategoryId";
            lstExpenseCategory.DataSource = expenseCategories;
            lstExpenseCategory.ClearSelected();
        }
        //END: Added By: Vishw Date: 10-sep-2026 Desc: Load expense categories into ListBox

        //START: Added By: Vishw Date: 10-sep-2026 Desc: Load transactions into ListView
        private void LoadTransactions()
        {
            lstvTransactions.Items.Clear();

            List<Transaction> transactions = transactionService.GetTransactionsByUserId(CurrentUserId);

            foreach (Transaction transaction in transactions)
            {
                ListViewItem item = new ListViewItem(transaction.TransactionId.ToString());
                item.SubItems.Add(transaction.TransactionDate.ToString("dd-MM-yyyy"));
                item.SubItems.Add(transaction.Description);
                item.SubItems.Add(transaction.TransactionType);
                item.SubItems.Add(transaction.CategoryName);
                item.SubItems.Add(transaction.Amount.ToString("N2"));
                item.Tag = transaction;
                lstvTransactions.Items.Add(item);
            }
        }
        //END: Added By: Vishw Date: 10-sep-2026 Desc: Load transactions into ListView

        //START: Added By: Vishw Date: 10-sep-2026 Desc: Update category control visibility based on radio button selection
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
        //END: Added By: Vishw Date: 10-sep-2026 Desc: Update category control visibility based on radio button selection

        //START: Added By: Vishw Date: 10-sep-2026 Desc: Radio button checked changed event handlers
        private void rdoIncome_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCategoryVisibility();
        }

        private void rdoExpense_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCategoryVisibility();
        }
        //END: Added By: Vishw Date: 10-sep-2026 Desc: Radio button checked changed event handlers

        //START: Added By: Vishw Date: 10-sep-2026 Desc: ListView selection changed event - load selected transaction into form
        private void lstvTransactions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstvTransactions.SelectedItems.Count == 0)
            {
                return;
            }

            ListViewItem selectedItem = lstvTransactions.SelectedItems[0];
            Transaction? transaction = selectedItem.Tag as Transaction;

            if (transaction == null)
            {
                return;
            }

            selectedTransactionId = transaction.TransactionId;

            dtpTransactionDate.Value = transaction.TransactionDate;
            txtDescription.Text = transaction.Description;
            nudAmount.Value = transaction.Amount;

            if (transaction.TransactionType == "Income")
            {
                rdoIncome.Checked = true;

                for (int i = 0; i < cmbIncomeCategory.Items.Count; i++)
                {
                    Transaction? cat = cmbIncomeCategory.Items[i] as Transaction;
                    if (cat != null && cat.CategoryId == transaction.CategoryId)
                    {
                        cmbIncomeCategory.SelectedIndex = i;
                        break;
                    }
                }
            }
            else
            {
                rdoExpense.Checked = true;

                for (int i = 0; i < lstExpenseCategory.Items.Count; i++)
                {
                    Transaction? cat = lstExpenseCategory.Items[i] as Transaction;
                    if (cat != null && cat.CategoryId == transaction.CategoryId)
                    {
                        lstExpenseCategory.SelectedIndex = i;
                        break;
                    }
                }
            }
        }
        //END: Added By: Vishw Date: 10-sep-2026 Desc: ListView selection changed event - load selected transaction into form

        //START: Added By: Vishw Date: 10-sep-2026 Desc: Add button click event - insert a new transaction
        private void btnAdd_Click(object sender, EventArgs e)
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

            Transaction transaction = new Transaction();
            transaction.UserId = CurrentUserId;
            transaction.CategoryId = categoryId;
            transaction.TransactionDate = dtpTransactionDate.Value.Date;
            transaction.Description = txtDescription.Text.Trim();
            transaction.Amount = nudAmount.Value;

            transactionService.AddTransaction(transaction);

            MessageBox.Show("Transaction added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ClearForm();
            LoadTransactions();
        }
        //END: Added By: Vishw Date: 10-sep-2026 Desc: Add button click event - insert a new transaction

        //START: Added By: Vishw Date: 10-sep-2026 Desc: Update button click event - update the selected transaction
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedTransactionId == 0)
            {
                MessageBox.Show("Please select a transaction to update.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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

            Transaction transaction = new Transaction();
            transaction.TransactionId = selectedTransactionId;
            transaction.UserId = CurrentUserId;
            transaction.CategoryId = categoryId;
            transaction.TransactionDate = dtpTransactionDate.Value.Date;
            transaction.Description = txtDescription.Text.Trim();
            transaction.Amount = nudAmount.Value;

            transactionService.UpdateTransaction(transaction);

            MessageBox.Show("Transaction updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ClearForm();
            LoadTransactions();
        }
        //END: Added By: Vishw Date: 10-sep-2026 Desc: Update button click event - update the selected transaction

        //START: Added By: Vishw Date: 10-sep-2026 Desc: Delete button click event - delete the selected transaction
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedTransactionId == 0)
            {
                MessageBox.Show("Please select a transaction to delete.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this transaction?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.No)
            {
                return;
            }

            transactionService.DeleteTransaction(selectedTransactionId, CurrentUserId);

            MessageBox.Show("Transaction deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ClearForm();
            LoadTransactions();
        }
        //END: Added By: Vishw Date: 10-sep-2026 Desc: Delete button click event - delete the selected transaction

        //START: Added By: Vishw Date: 10-sep-2026 Desc: Clear button click event - reset all input controls
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
        //END: Added By: Vishw Date: 10-sep-2026 Desc: Clear button click event - reset all input controls

        //START: Added By: Vishw Date: 10-sep-2026 Desc: Validate user input before insert or update
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
        //END: Added By: Vishw Date: 10-sep-2026 Desc: Validate user input before insert or update

        //START: Added By: Vishw Date: 10-sep-2026 Desc: Get selected category ID from appropriate control
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
        //END: Added By: Vishw Date: 10-sep-2026 Desc: Get selected category ID from appropriate control

        //START: Added By: Vishw Date: 10-sep-2026 Desc: Clear and reset all form controls
        private void ClearForm()
        {
            txtDescription.Text = string.Empty;
            nudAmount.Value = nudAmount.Minimum;
            dtpTransactionDate.Value = DateTime.Today;
            rdoIncome.Checked = true;
            cmbIncomeCategory.SelectedIndex = -1;
            lstExpenseCategory.ClearSelected();
            selectedTransactionId = 0;
            lstvTransactions.SelectedItems.Clear();
        }
        //END: Added By: Vishw Date: 10-sep-2026 Desc: Clear and reset all form controls
    }
}
