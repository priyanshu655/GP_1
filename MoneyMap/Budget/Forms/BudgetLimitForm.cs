using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GP_1;
using MoneyMap.Budget.Services;

namespace MoneyMap.Budget.Forms
{
    public partial class BudgetLimitForm : Form
    {
        private readonly int userId;

        public BudgetLimitForm(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void BudgetLimitForm_Load(object sender, EventArgs e)
        {
            SetupGrid();
            LoadBudgetData();
        }

        private void SetupGrid()
        {
            UITheme.StyleDataGridView(dgvCategoryBudgets);
            dgvCategoryBudgets.ReadOnly = false;
            dgvCategoryBudgets.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvCategoryBudgets.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvCategoryBudgets.AutoGenerateColumns = false;
            dgvCategoryBudgets.Columns.Clear();
            dgvCategoryBudgets.RowTemplate.Height = 36;

            var colId = new DataGridViewTextBoxColumn
            {
                Name = "CategoryId",
                HeaderText = "ID",
                Visible = false,
                ReadOnly = true
            };

            var colName = new DataGridViewTextBoxColumn
            {
                Name = "CategoryName",
                HeaderText = "CATEGORY",
                ReadOnly = true,
                FillWeight = 120
            };
            colName.DefaultCellStyle.Font = UITheme.BodySemibold;

            var colSpent = new DataGridViewTextBoxColumn
            {
                Name = "CurrentSpent",
                HeaderText = "THIS MONTH SPENT",
                ReadOnly = true,
                FillWeight = 90
            };
            colSpent.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colSpent.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            colSpent.DefaultCellStyle.ForeColor = UITheme.DarkSlate;

            var colLimit = new DataGridViewTextBoxColumn
            {
                Name = "MonthlyLimit",
                HeaderText = "MONTHLY LIMIT (₹)",
                ReadOnly = false,
                FillWeight = 100
            };
            colLimit.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colLimit.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            colLimit.DefaultCellStyle.Font = UITheme.BodySemibold;
            colLimit.DefaultCellStyle.ForeColor = UITheme.DarkNavy;

            dgvCategoryBudgets.Columns.AddRange(colId, colName, colSpent, colLimit);
        }

        private void LoadBudgetData()
        {
            var summary = BudgetService.GetBudgetSummary(userId);
            numOverallLimit.Value = summary.OverallLimit;

            dgvCategoryBudgets.Rows.Clear();
            foreach (var cat in summary.CategoryBudgets)
            {
                int rowIndex = dgvCategoryBudgets.Rows.Add(
                    cat.CategoryId,
                    cat.CategoryName,
                    "₹" + cat.CurrentSpent.ToString("N2"),
                    cat.MonthlyLimit.ToString("F2")
                );

                if (cat.IsExceeded)
                {
                    dgvCategoryBudgets.Rows[rowIndex].Cells["CurrentSpent"].Style.ForeColor = UITheme.ExpenseRed;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dgvCategoryBudgets.EndEdit();

            decimal overallLimit = numOverallLimit.Value;
            var categoryLimits = new Dictionary<int, decimal>();

            foreach (DataGridViewRow row in dgvCategoryBudgets.Rows)
            {
                if (row.Cells["CategoryId"].Value == null) continue;
                int catId = Convert.ToInt32(row.Cells["CategoryId"].Value);
                string limitStr = row.Cells["MonthlyLimit"].Value?.ToString() ?? "0";

                if (decimal.TryParse(limitStr, out decimal limit))
                {
                    categoryLimits[catId] = Math.Max(0, limit);
                }
                else
                {
                    categoryLimits[catId] = 0;
                }
            }

            bool success = BudgetService.SaveAllBudgets(userId, overallLimit, categoryLimits, out string errorMessage);
            if (success)
            {
                MessageBox.Show(
                    "Monthly budget limits have been successfully saved!",
                    "Budget Updated",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(
                    $"Failed to save budget limits: {errorMessage}",
                    "Save Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
