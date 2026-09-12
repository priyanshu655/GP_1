
using GP_1.Models;
using GP_1.Services;

namespace GP_1.Forms
{
    public partial class FrmTransaction : Form
    {
        private readonly int currentUserId;

        private readonly string currentUsername;

        private TransactionService transactionService = new TransactionService();

        public FrmTransaction(int userId, string username)
        {
            InitializeComponent();
            currentUserId = userId;
            currentUsername = username;
        }

        //START: Added By: Vishw Date: 11-sep-2026 Desc: Form load event - load transactions
        private void FrmTransaction_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Welcome, " + currentUsername + "!";
            LoadTransactions();
        }
        //END: Added By: Vishw Date: 11-sep-2026 Desc: Form load event - load transactions

        //START: Added By: Vishw Date: 11-sep-2026 Desc: Load transactions into DataGridView
        private void LoadTransactions()
        {
            List<Transaction> transactions = transactionService.GetTransactionsByUserId(currentUserId);

            dgridTransactions.DataSource = null;
            dgridTransactions.DataSource = transactions;
        }
        //END: Added By: Vishw Date: 11-sep-2026 Desc: Load transactions into DataGridView

        //START: Added By: Vishw Date: 11-sep-2026 Desc: Insert button click - open popup to add a new transaction
        private void btnInsert_Click(object sender, EventArgs e)
        {
            using (FrmTransactionInput frmInput = new FrmTransactionInput(currentUserId))
            {
                if (frmInput.ShowDialog(this) == DialogResult.OK)
                {
                    MessageBox.Show("Transaction added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTransactions();
                }
            }
        }
        //END: Added By: Vishw Date: 11-sep-2026 Desc: Insert button click - open popup to add a new transaction

        //START: Added By: Vishw Date: 11-sep-2026 Desc: Grid cell click event - handle update and delete button columns
        private void dgridTransactions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            Transaction? selectedTransaction = dgridTransactions.Rows[e.RowIndex].DataBoundItem as Transaction;

            if (selectedTransaction == null)
            {
                return;
            }

            if (e.ColumnIndex == colUpdate.Index)
            {
                OpenUpdatePopup(selectedTransaction);
            }
            else if (e.ColumnIndex == colDelete.Index)
            {
                ConfirmDelete(selectedTransaction);
            }
        }
        //END: Added By: Vishw Date: 11-sep-2026 Desc: Grid cell click event - handle update and delete button columns

        //START: Added By: Vishw Date: 11-sep-2026 Desc: Open popup with the selected transaction loaded for update
        private void OpenUpdatePopup(Transaction transaction)
        {
            using (FrmTransactionInput frmInput = new FrmTransactionInput(currentUserId, transaction))
            {
                if (frmInput.ShowDialog(this) == DialogResult.OK)
                {
                    MessageBox.Show("Transaction updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTransactions();
                }
            }
        }
        //END: Added By: Vishw Date: 11-sep-2026 Desc: Open popup with the selected transaction loaded for update

        //START: Added By: Vishw Date: 11-sep-2026 Desc: Confirm and delete the selected transaction
        private void ConfirmDelete(Transaction transaction)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this transaction?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.No)
            {
                return;
            }

            transactionService.DeleteTransaction(transaction.TransactionId, currentUserId);

            MessageBox.Show("Transaction deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadTransactions();
        }
        //END: Added By: Vishw Date: 11-sep-2026 Desc: Confirm and delete the selected transaction
    }
}