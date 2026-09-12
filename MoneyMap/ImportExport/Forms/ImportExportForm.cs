using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Text;
using System.Windows.Forms;
using GP_1.Services;
using MoneyMap.Main;

namespace GP_1.Forms
{
    public enum ImportExportMode
    {
        ImportOnly,
        ExportOnly,
        Both
    }

    public partial class ImportExportForm : Form
    {
        private readonly int currentUserId;
        private readonly ImportExportMode currentMode;
        private readonly CsvService csvService;

        public ImportExportForm(int userId = 1, ImportExportMode mode = ImportExportMode.ImportOnly)
        {
            InitializeComponent();
            currentUserId = userId;
            currentMode = mode;
            csvService = new CsvService();
            SetupMode();
            SetupCards();
        }

        private void SetupMode()
        {
            switch (currentMode)
            {
                case ImportExportMode.ImportOnly:
                    this.Text = "Import Transactions (CSV)";
                    titleLabel.Text = "Import Transactions (CSV)";
                    subtitleLabel.Text = "Upload and import transaction records into your MoneyMap account";
                    cardImport.Visible = true;
                    cardExport.Visible = false;
                    break;

                case ImportExportMode.ExportOnly:
                    this.Text = "Export Transactions (CSV)";
                    titleLabel.Text = "Export Transactions (CSV)";
                    subtitleLabel.Text = "Export your financial transactions to a CSV spreadsheet file";
                    cardImport.Visible = false;
                    cardExport.Visible = true;
                    break;

                case ImportExportMode.Both:
                default:
                    this.Text = "CSV Import & Export";
                    titleLabel.Text = "CSV Import & Export";
                    subtitleLabel.Text = "Export financial records to CSV or import bulk data effortlessly";
                    cardImport.Visible = true;
                    cardExport.Visible = true;
                    break;
            }
        }

        private void ImportExportForm_Load(object sender, EventArgs e)
        {
            SetupMode();
            if (currentMode == ImportExportMode.ImportOnly)
            {
                LogMessage("CSV Import tool ready.");
                LogMessage($"Active User ID: {currentUserId} | Select a CSV file to begin importing.");
            }
            else if (currentMode == ImportExportMode.ExportOnly)
            {
                LogMessage("CSV Export tool ready.");
                LogMessage($"Active User ID: {currentUserId} | Choose an export option above.");
            }
            else
            {
                LogMessage("CSV Import & Export tool ready.");
                LogMessage($"Active User ID: {currentUserId}");
            }
        }

        private void SetupCards()
        {
            void ApplyCardStyle(Panel card, Color accentColor)
            {
                card.Paint += (s, e) =>
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    Rectangle rect = card.ClientRectangle;
                    rect.Width -= 1;
                    rect.Height -= 1;

                    using (Pen borderPen = new Pen(UITheme.BorderSubtle, 1))
                    {
                        e.Graphics.DrawRectangle(borderPen, rect);
                    }

                    // Left accent bar
                    using (SolidBrush accentBrush = new SolidBrush(accentColor))
                    {
                        e.Graphics.FillRectangle(accentBrush, 0, 0, 4, card.Height);
                    }
                };
            }

            ApplyCardStyle(cardImport, UITheme.PrimaryGreenDark);
            ApplyCardStyle(cardExport, UITheme.BalanceBlueDark);
            ApplyCardStyle(cardResult, UITheme.DarkNavy);
        }

        private void CardsContainer_Resize(object sender, EventArgs e)
        {
            int totalW = cardsContainer.ClientSize.Width;

            if (currentMode == ImportExportMode.ImportOnly)
            {
                cardImport.SetBounds(0, 0, totalW, 200);
            }
            else if (currentMode == ImportExportMode.ExportOnly)
            {
                cardExport.SetBounds(0, 0, totalW, 200);
            }
            else
            {
                int gap = 16;
                int halfW = (totalW - gap) / 2;
                cardImport.SetBounds(0, 0, halfW, 200);
                cardExport.SetBounds(halfW + gap, 0, totalW - (halfW + gap), 200);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // If embedded in a parent container (like MainForm's mainPanel), close via parent or Dispose
            if (this.Parent is Panel parentPanel && parentPanel.FindForm() is MainForm mainForm)
            {
                mainForm.CloseCurrentView();
            }
            else
            {
                this.Close();
            }
        }

        private void btnImportCsv_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog
            {
                Title = "Select Transaction CSV File to Import",
                Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*",
                Multiselect = false
            })
            {
                if (ofd.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    LogMessage($"\n--- Starting CSV Import from: {Path.GetFileName(ofd.FileName)} ---");
                    lblResultStatus.Text = "Processing CSV import...";
                    lblResultStatus.ForeColor = UITheme.TextSecondary;

                    CsvImportResult result = csvService.ImportTransactions(ofd.FileName, currentUserId);

                    if (result.TotalRows == 0)
                    {
                        lblResultStatus.Text = "No data rows found in selected file.";
                        lblResultStatus.ForeColor = UITheme.ExpenseRed;
                        LogMessage("⚠️ The selected CSV file has no records to import.");

                        MessageBox.Show(
                            "The selected CSV file has no records to import. Please select a file that contains at least one data row.",
                            "Import Records",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                    else if (result.FailedCount == 0)
                    {
                        lblResultStatus.Text = $"Successfully imported {result.SuccessCount} of {result.TotalRows} record(s).";
                        lblResultStatus.ForeColor = UITheme.PrimaryGreenDark;
                        LogMessage($"✓ SUCCESS: All {result.SuccessCount} record(s) were imported successfully into the database.");

                        MessageBox.Show(
                            $"All {result.SuccessCount} record(s) were imported successfully.",
                            "Import Records",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        lblResultStatus.Text = $"{result.SuccessCount} imported successfully, {result.FailedCount} failed.";
                        lblResultStatus.ForeColor = result.SuccessCount > 0 ? UITheme.BalanceBlueDark : UITheme.ExpenseRed;

                        LogMessage($"⚠️ PARTIAL / FAILED IMPORT: {result.SuccessCount} succeeded, {result.FailedCount} failed out of {result.TotalRows} total rows.");
                        foreach (string err in result.Errors)
                        {
                            LogMessage($"  - {err}");
                        }

                        StringBuilder sb = new StringBuilder();
                        foreach (string error in result.Errors)
                        {
                            sb.AppendLine("• " + error);
                        }

                        MessageBox.Show(
                            $"{result.SuccessCount} of {result.TotalRows} record(s) imported successfully.\n" +
                            $"{result.FailedCount} record(s) could not be imported.\n\n" +
                            "Error details:\n" + sb.ToString(),
                            "Import Results",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    lblResultStatus.Text = "An unexpected error occurred during import.";
                    lblResultStatus.ForeColor = UITheme.ExpenseRed;
                    LogMessage($"❌ ERROR: {ex.Message}");

                    MessageBox.Show(
                        "The records could not be imported: " + ex.Message,
                        "Import Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void btnDownloadTemplate_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog
            {
                Title = "Save Sample CSV Template",
                Filter = "CSV Files (*.csv)|*.csv",
                FileName = "transactions_sample_template.csv"
            })
            {
                if (sfd.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    csvService.GenerateSampleTemplate(sfd.FileName, currentUserId);
                    LogMessage($"✓ Template saved successfully at: {sfd.FileName}");

                    MessageBox.Show(
                        "Sample CSV template generated successfully!\nYou can fill in your data and import it.",
                        "Template Created",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    LogMessage($"❌ Failed to create template: {ex.Message}");
                    MessageBox.Show("Could not save template: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnExportMy_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog
            {
                Title = "Export My Transactions to CSV",
                Filter = "CSV Files (*.csv)|*.csv",
                FileName = $"my_transactions_{DateTime.Today:yyyyMMdd}.csv"
            })
            {
                if (sfd.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    LogMessage($"\n--- Exporting transactions for user {currentUserId} ---");
                    int count = csvService.ExportTransactions(sfd.FileName, currentUserId);

                    lblResultStatus.Text = $"Export completed: {count} record(s) exported.";
                    lblResultStatus.ForeColor = UITheme.BalanceBlueDark;
                    LogMessage($"✓ SUCCESS: {count} transaction record(s) exported to {Path.GetFileName(sfd.FileName)}");

                    MessageBox.Show(
                        $"Successfully exported {count} transaction record(s) to:\n{sfd.FileName}",
                        "Export Records",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    lblResultStatus.Text = "Failed to export transactions.";
                    lblResultStatus.ForeColor = UITheme.ExpenseRed;
                    LogMessage($"❌ Export error: {ex.Message}");

                    MessageBox.Show(
                        "The records could not be exported: " + ex.Message,
                        "Export Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void btnExportAll_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog
            {
                Title = "Export All Transactions to CSV",
                Filter = "CSV Files (*.csv)|*.csv",
                FileName = $"all_transactions_{DateTime.Today:yyyyMMdd}.csv"
            })
            {
                if (sfd.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    LogMessage($"\n--- Exporting all transactions in database ---");
                    int count = csvService.ExportTransactions(sfd.FileName, null);

                    lblResultStatus.Text = $"Export completed: {count} record(s) exported.";
                    lblResultStatus.ForeColor = UITheme.BalanceBlueDark;
                    LogMessage($"✓ SUCCESS: {count} total transaction record(s) exported to {Path.GetFileName(sfd.FileName)}");

                    MessageBox.Show(
                        $"Successfully exported {count} transaction record(s) to:\n{sfd.FileName}",
                        "Export All Records",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    lblResultStatus.Text = "Failed to export all transactions.";
                    lblResultStatus.ForeColor = UITheme.ExpenseRed;
                    LogMessage($"❌ Export error: {ex.Message}");

                    MessageBox.Show(
                        "The records could not be exported: " + ex.Message,
                        "Export Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void LogMessage(string message)
        {
            string timeStamp = DateTime.Now.ToString("HH:mm:ss");
            txtLog.AppendText($"[{timeStamp}] {message}\r\n");
        }
    }
}
