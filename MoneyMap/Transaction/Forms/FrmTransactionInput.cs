using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GP_1.Models;
using GP_1.Services;

namespace GP_1.Forms
{
    public partial class FrmTransactionInput : Form
    {
        private readonly int currentUserId;
        private readonly TransactionService transactionService = new TransactionService();
        private readonly Transaction? currentTransaction;

        public bool IsUpdateMode => currentTransaction != null;

        public FrmTransactionInput(int userId)
        {
            InitializeComponent();
            currentUserId = userId;
            SetupStyling();
        }

        public FrmTransactionInput(int userId, Transaction transaction)
        {
            InitializeComponent();
            currentUserId = userId;
            currentTransaction = transaction;
            SetupStyling();
        }

        private void SetupStyling()
        {
            footerPanel.Paint += (s, e) =>
            {
                using (Pen borderPen = new Pen(UITheme.BorderSubtle, 1))
                {
                    e.Graphics.DrawLine(borderPen, 0, 0, footerPanel.Width, 0);
                }
            };
        }

        private void FrmTransactionInput_Load(object sender, EventArgs e)
        {
            dtpTransactionDate.MaxDate = DateTime.Today.AddDays(365);
            dtpTransactionDate.Value = DateTime.Today;

            if (IsUpdateMode && currentTransaction != null)
            {
                this.Text = "Update Transaction";
                lblTitle.Text = "Update Transaction";
                lblSubtitle.Text = "Modify the existing transaction details";
                btnSave.Text = "Update Transaction";

                if (currentTransaction.TransactionType.Equals("Expense", StringComparison.OrdinalIgnoreCase))
                {
                    rdoExpense.Checked = true;
                }
                else
                {
                    rdoIncome.Checked = true;
                }

                LoadCategories();
                SelectCategoryById(currentTransaction.CategoryId);

                dtpTransactionDate.Value = currentTransaction.TransactionDate;
                txtDescription.Text = currentTransaction.Description;
                nudAmount.Value = Math.Max(nudAmount.Minimum, Math.Min(nudAmount.Maximum, currentTransaction.Amount));
            }
            else
            {
                this.Text = "Add Transaction";
                lblTitle.Text = "Add Transaction";
                lblSubtitle.Text = "Enter your transaction details below";
                btnSave.Text = "Save Transaction";
                rdoIncome.Checked = true;
                LoadCategories();
            }
        }

        private void rdoType_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton rdo && rdo.Checked)
            {
                LoadCategories();
            }
        }

        private void LoadCategories()
        {
            string typeName = rdoIncome.Checked ? "Income" : "Expense";
            List<Transaction> categories = transactionService.GetCategoriesByTypeName(typeName);

            cmbCategory.DataSource = null;
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "CategoryId";
            cmbCategory.DataSource = categories;

            if (categories.Count > 0)
            {
                cmbCategory.SelectedIndex = 0;
            }
        }

        private void SelectCategoryById(int categoryId)
        {
            if (cmbCategory.DataSource is List<Transaction> list)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].CategoryId == categoryId)
                    {
                        cmbCategory.SelectedIndex = i;
                        return;
                    }
                }
            }
        }

        private void nudAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '-')
            {
                e.Handled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }

            if (cmbCategory.SelectedItem is not Transaction selectedCategory || selectedCategory.CategoryId == 0)
            {
                MessageBox.Show("Please select a category.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCategory.Focus();
                return;
            }

            try
            {
                if (IsUpdateMode && currentTransaction != null)
                {
                    Transaction transaction = new Transaction
                    {
                        TransactionId = currentTransaction.TransactionId,
                        UserId = currentUserId,
                        CategoryId = selectedCategory.CategoryId,
                        TransactionDate = dtpTransactionDate.Value.Date,
                        Description = txtDescription.Text.Trim(),
                        Amount = nudAmount.Value
                    };

                    transactionService.UpdateTransaction(transaction);
                    MessageBox.Show("Transaction updated successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Transaction transaction = new Transaction
                    {
                        UserId = currentUserId,
                        CategoryId = selectedCategory.CategoryId,
                        TransactionDate = dtpTransactionDate.Value.Date,
                        Description = txtDescription.Text.Trim(),
                        Amount = nudAmount.Value
                    };

                    transactionService.AddTransaction(transaction);
                    
                    // Check if budget limit reached/exceeded for expense
                    if (!rdoIncome.Checked)
                    {
                        var alerts = MoneyMap.Budget.Services.BudgetService.CheckNewTransactionBudgetAlert(
                            currentUserId,
                            selectedCategory.CategoryId,
                            nudAmount.Value,
                            dtpTransactionDate.Value.Date);

                        if (alerts.Count > 0)
                        {
                            string warningMsg = string.Join("\n\n", alerts);
                            MessageBox.Show(
                                $"Transaction recorded successfully.\n\n{warningMsg}",
                                "Budget Alert Notification",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                        }
                        else
                        {
                            MessageBox.Show("Transaction added successfully.", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Transaction added successfully.", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving transaction: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool ValidateInput()
        {
            if (nudAmount.Value <= 0)
            {
                MessageBox.Show("Please enter a valid amount greater than 0.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudAmount.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtDescription.Text) && txtDescription.Text.Trim().Length > 255)
            {
                MessageBox.Show("Description cannot exceed 255 characters.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescription.Focus();
                return false;
            }

            return true;
        }
    }
}
