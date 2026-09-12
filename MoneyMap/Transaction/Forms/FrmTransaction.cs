using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using GP_1.Models;
using GP_1.Services;
using MoneyMap.Main;

namespace GP_1.Forms
{
    public enum TransactionViewMode
    {
        All,
        EditOnly,
        DeleteOnly
    }

    public partial class FrmTransaction : Form
    {
        private readonly int currentUserId;
        private readonly string currentUsername;
        private readonly TransactionViewMode viewMode;
        private readonly TransactionService transactionService = new TransactionService();
        private List<Transaction> allTransactions = new List<Transaction>();

        private DataGridViewButtonColumn? colUpdate;
        private DataGridViewButtonColumn? colDelete;

        public FrmTransaction(int userId, TransactionViewMode mode = TransactionViewMode.All, string username = "")
        {
            InitializeComponent();
            currentUserId = userId;
            viewMode = mode;
            currentUsername = string.IsNullOrWhiteSpace(username) ? transactionService.GetUsernameById(userId) : username;

            SetupViewMode();
            SetupCards();
            SetupGrid();
        }

        private void SetupViewMode()
        {
            switch (viewMode)
            {
                case TransactionViewMode.EditOnly:
                    this.Text = "Edit Transactions";
                    titleLabel.Text = "Edit Transactions";
                    subtitleLabel.Text = string.IsNullOrWhiteSpace(currentUsername)
                        ? "Select a transaction to update its details"
                        : $"User: {currentUsername} | Click 'Edit' to update any transaction";
                    btnInsert.Visible = false;
                    searchLabel.Location = new Point(560, 6);
                    searchBox.Location = new Point(560, 28);
                    searchBox.Size = new Size(240, 30);
                    break;

                case TransactionViewMode.DeleteOnly:
                    this.Text = "Delete Transactions";
                    titleLabel.Text = "Delete Transactions";
                    subtitleLabel.Text = string.IsNullOrWhiteSpace(currentUsername)
                        ? "Review and remove transactions from your account"
                        : $"User: {currentUsername} | Click 'Delete' to remove any transaction";
                    btnInsert.Visible = false;
                    searchLabel.Location = new Point(560, 6);
                    searchBox.Location = new Point(560, 28);
                    searchBox.Size = new Size(240, 30);
                    break;

                case TransactionViewMode.All:
                default:
                    this.Text = "All Transactions";
                    titleLabel.Text = "All Transactions";
                    subtitleLabel.Text = string.IsNullOrWhiteSpace(currentUsername)
                        ? "Comprehensive record of all your financial transactions"
                        : $"User: {currentUsername} | Viewing all income and expense transactions";
                    btnInsert.Visible = false;
                    searchLabel.Location = new Point(560, 6);
                    searchBox.Location = new Point(560, 28);
                    searchBox.Size = new Size(240, 30);
                    break;
            }
        }

        private void FrmTransaction_Load(object sender, EventArgs e)
        {
            SetupViewMode();
            LoadTransactions();
        }

        private void SetupCards()
        {
            Panel[] cards = { cardTotal, cardIncome, cardExpense, cardBalance };
            Color[] accentColors = {
                UITheme.DarkNavy,
                UITheme.IncomeGreen,
                UITheme.ExpenseRed,
                UITheme.BalanceBlue
            };

            for (int i = 0; i < cards.Length; i++)
            {
                int index = i;
                cards[i].Paint += (s, e) =>
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    Rectangle rect = cards[index].ClientRectangle;
                    rect.Width -= 1;
                    rect.Height -= 1;

                    using (Pen borderPen = new Pen(UITheme.BorderSubtle, 1))
                    {
                        e.Graphics.DrawRectangle(borderPen, rect);
                    }

                    // Left accent bar
                    using (SolidBrush accentBrush = new SolidBrush(accentColors[index]))
                    {
                        e.Graphics.FillRectangle(accentBrush, 0, 0, 4, cards[index].Height);
                    }
                };
            }

            gridPanel.Paint += (s, e) =>
            {
                Rectangle r = gridPanel.ClientRectangle;
                r.Width -= 1;
                r.Height -= 1;
                using (Pen p = new Pen(UITheme.BorderSubtle, 1))
                {
                    e.Graphics.DrawRectangle(p, r);
                }
            };
        }

        private void StatsPanel_Resize(object sender, EventArgs e)
        {
            int totalW = statsPanel.ClientSize.Width;
            int gap = 14;
            int cardW = Math.Max(160, (totalW - (gap * 3)) / 4);

            cardTotal.SetBounds(0, 10, cardW, 68);
            cardIncome.SetBounds(cardW + gap, 10, cardW, 68);
            cardExpense.SetBounds((cardW + gap) * 2, 10, cardW, 68);
            cardBalance.SetBounds((cardW + gap) * 3, 10, totalW - ((cardW + gap) * 3), 68);
        }

        private void SetupGrid()
        {
            UITheme.StyleDataGridView(dgridTransactions);

            dgridTransactions.AutoGenerateColumns = false;
            dgridTransactions.Columns.Clear();

            DataGridViewTextBoxColumn colDate = new DataGridViewTextBoxColumn
            {
                Name = "colDate",
                DataPropertyName = "TransactionDate",
                HeaderText = "DATE",
                FillWeight = 85
            };
            colDate.DefaultCellStyle.Format = "dd-MMM-yyyy";

            DataGridViewTextBoxColumn colType = new DataGridViewTextBoxColumn
            {
                Name = "colType",
                DataPropertyName = "TransactionType",
                HeaderText = "TYPE",
                FillWeight = 70
            };

            DataGridViewTextBoxColumn colCategory = new DataGridViewTextBoxColumn
            {
                Name = "colCategory",
                DataPropertyName = "CategoryName",
                HeaderText = "CATEGORY",
                FillWeight = 110
            };

            DataGridViewTextBoxColumn colDesc = new DataGridViewTextBoxColumn
            {
                Name = "colDesc",
                DataPropertyName = "Description",
                HeaderText = "DESCRIPTION",
                FillWeight = 180
            };

            DataGridViewTextBoxColumn colAmount = new DataGridViewTextBoxColumn
            {
                Name = "colAmount",
                DataPropertyName = "Amount",
                HeaderText = "AMOUNT",
                FillWeight = 90
            };
            colAmount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colAmount.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            var cols = new List<DataGridViewColumn> { colDate, colType, colCategory, colDesc, colAmount };

            if (viewMode == TransactionViewMode.EditOnly)
            {
                colUpdate = new DataGridViewButtonColumn
                {
                    Name = "colUpdate",
                    HeaderText = "ACTION",
                    Text = "Edit",
                    UseColumnTextForButtonValue = true,
                    FillWeight = 65
                };
                cols.Add(colUpdate);
            }
            else if (viewMode == TransactionViewMode.DeleteOnly)
            {
                colDelete = new DataGridViewButtonColumn
                {
                    Name = "colDelete",
                    HeaderText = "ACTION",
                    Text = "Delete",
                    UseColumnTextForButtonValue = true,
                    FillWeight = 65
                };
                cols.Add(colDelete);
            }

            dgridTransactions.Columns.AddRange(cols.ToArray());
            dgridTransactions.CellFormatting += DgridTransactions_CellFormatting;
            dgridTransactions.CellPainting += DgridTransactions_CellPainting;
        }

        private void DgridTransactions_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgridTransactions.Rows.Count || e.CellStyle == null || e.ColumnIndex < 0) return;

            var row = dgridTransactions.Rows[e.RowIndex];
            if (row.DataBoundItem is not Transaction item) return;

            bool isIncome = item.TransactionType.Equals("Income", StringComparison.OrdinalIgnoreCase);
            var col = dgridTransactions.Columns[e.ColumnIndex];

            // Style amount
            if (col.Name == "colAmount" && e.Value != null)
            {
                e.CellStyle.Font = UITheme.BodySemibold;
                e.Value = (isIncome ? "+₹" : "-₹") + item.Amount.ToString("N2");
                e.FormattingApplied = true;
                e.CellStyle.ForeColor = isIncome ? UITheme.IncomeGreenDark : UITheme.ExpenseRed;
            }

            // Style Type
            if (col.Name == "colType" && e.Value != null)
            {
                e.CellStyle.Font = UITheme.SmallSemibold;
                e.CellStyle.ForeColor = isIncome ? UITheme.IncomeGreenDark : UITheme.ExpenseRed;
            }
        }

        private void DgridTransactions_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.Graphics == null || e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var col = dgridTransactions.Columns[e.ColumnIndex];
            if (col == colUpdate || col == colDelete)
            {
                e.PaintBackground(e.ClipBounds, true);

                bool isEdit = (col == colUpdate);
                string btnText = isEdit ? "Edit" : "Delete";
                Color btnBg = isEdit ? Color.FromArgb(238, 242, 246) : Color.FromArgb(254, 242, 242);
                Color btnBorder = isEdit ? Color.FromArgb(203, 213, 225) : Color.FromArgb(254, 202, 202);
                Color btnFg = isEdit ? Color.FromArgb(51, 65, 85) : Color.FromArgb(220, 38, 38);

                Rectangle btnRect = new Rectangle(e.CellBounds.X + 6, e.CellBounds.Y + 7, e.CellBounds.Width - 12, e.CellBounds.Height - 14);

                using (GraphicsPath path = UITheme.GetRoundedPath(btnRect, 4))
                {
                    using (SolidBrush brush = new SolidBrush(btnBg))
                    {
                        e.Graphics.FillPath(brush, path);
                    }
                    using (Pen pen = new Pen(btnBorder, 1))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }

                TextRenderer.DrawText(
                    e.Graphics,
                    btnText,
                    UITheme.SmallSemibold,
                    btnRect,
                    btnFg,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                e.Handled = true;
            }
        }

        public void LoadTransactions()
        {
            try
            {
                allTransactions = transactionService.GetTransactionsByUserId(currentUserId);
                ApplyFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading transactions: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void ApplyFilter()
        {
            string filter = searchBox.Text.Trim();
            List<Transaction> filtered;

            if (string.IsNullOrWhiteSpace(filter))
            {
                filtered = allTransactions;
            }
            else
            {
                filtered = allTransactions.Where(t =>
                    (!string.IsNullOrEmpty(t.CategoryName) && t.CategoryName.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (!string.IsNullOrEmpty(t.Description) && t.Description.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (!string.IsNullOrEmpty(t.TransactionType) && t.TransactionType.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0)
                ).ToList();
            }

            dgridTransactions.DataSource = null;
            dgridTransactions.DataSource = filtered;

            UpdateStats(filtered);
        }

        private void UpdateStats(List<Transaction> list)
        {
            int count = list.Count;
            decimal totalIncome = list.Where(t => t.TransactionType.Equals("Income", StringComparison.OrdinalIgnoreCase)).Sum(t => t.Amount);
            decimal totalExpense = list.Where(t => t.TransactionType.Equals("Expense", StringComparison.OrdinalIgnoreCase)).Sum(t => t.Amount);
            decimal balance = totalIncome - totalExpense;

            lblTotalCount.Text = count.ToString();
            lblIncomeSum.Text = "+₹" + totalIncome.ToString("N2");
            lblExpenseSum.Text = "-₹" + totalExpense.ToString("N2");
            lblBalanceSum.Text = (balance >= 0 ? "+₹" : "-₹") + Math.Abs(balance).ToString("N2");
            lblBalanceSum.ForeColor = balance >= 0 ? UITheme.PrimaryGreenDark : UITheme.ExpenseRed;

            emptyLabel.Visible = count == 0;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            using (FrmTransactionInput frmInput = new FrmTransactionInput(currentUserId))
            {
                if (frmInput.ShowDialog(this) == DialogResult.OK)
                {
                    LoadTransactions();
                }
            }
        }

        private void dgridTransactions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgridTransactions.Rows.Count || e.ColumnIndex < 0) return;

            if (dgridTransactions.Rows[e.RowIndex].DataBoundItem is not Transaction selectedTransaction) return;

            var col = dgridTransactions.Columns[e.ColumnIndex];
            if (col == colUpdate)
            {
                OpenUpdatePopup(selectedTransaction);
            }
            else if (col == colDelete)
            {
                ConfirmDelete(selectedTransaction);
            }
        }

        private void OpenUpdatePopup(Transaction transaction)
        {
            using (FrmTransactionInput frmInput = new FrmTransactionInput(currentUserId, transaction))
            {
                if (frmInput.ShowDialog(this) == DialogResult.OK)
                {
                    LoadTransactions();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (this.Parent is Panel parentPanel && parentPanel.FindForm() is MainForm mainForm)
            {
                mainForm.CloseCurrentView();
            }
            else
            {
                this.Close();
            }
        }

        private void ConfirmDelete(Transaction transaction)
        {
            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete this {transaction.TransactionType} transaction:\n\n" +
                $"Category: {transaction.CategoryName}\n" +
                $"Amount: ₹{transaction.Amount:N2}\n" +
                $"Date: {transaction.TransactionDate:dd-MMM-yyyy}?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    transactionService.DeleteTransaction(transaction.TransactionId, currentUserId);
                    LoadTransactions();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting transaction: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
