using System;
using System.Text;
using System.Windows.Forms;
using GP_1.Services;

namespace GP_1
{
    /// <summary>
    /// Temporary standalone form to test CSV Import/Export logic independently
    /// of the main application UI. The MenuStrip here mirrors the "File" menu
    /// from the project spec (Import Records / Export Records / Exit).
    /// All results and validation messages are shown via popup message boxes only.
    /// </summary>
    public partial class ImportExportForm : Form
    {
        #region Variable Declaration

        // TODO: Move to a config file (App.config / appsettings.json) once the
        // team sets up shared configuration. Hardcoded here only for isolated testing.
        private const string _connectionString =
            "Host=localhost;Port=5432;Database=Project;Username=postgres;Password=Trup@1903";

        #endregion

        #region Common

        public ImportExportForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        //START: Added By: Trupti Date: 11-Sep-2026 Desc: Handle Import Records menu click
        private void importRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog { Filter = "CSV Files (*.csv)|*.csv" })
            {
                if (ofd.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    CsvService service = new CsvService(_connectionString);
                    CsvImportResult result = service.ImportTransactions(ofd.FileName);

                    ShowImportResultPopup(result);
                }
                catch (Exception)
                {
                    MessageBox.Show(
                        "The records could not be imported. Please check the file format and try again.",
                        "Import Records",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }
        //END: Added By: Trupti Date: 11-Sep-2026 Desc: Handle Import Records menu click

        //START: Added By: Trupti Date: 11-Sep-2026 Desc: Handle Export Records menu click
        private void exportRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "CSV Files (*.csv)|*.csv",
                FileName = "transactions_export.csv"
            })
            {
                if (sfd.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    CsvService service = new CsvService(_connectionString);
                    service.ExportTransactions(sfd.FileName);

                    MessageBox.Show(
                        "The records were exported successfully.",
                        "Export Records",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show(
                        "The records could not be exported. Please check the destination folder and try again.",
                        "Export Records",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }
        //END: Added By: Trupti Date: 11-Sep-2026 Desc: Handle Export Records menu click

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region Functions

        //START: Added By: Trupti Date: 11-Sep-2026 Desc: Show import result as a popup, following message standards (what/why/next step)
        private void ShowImportResultPopup(CsvImportResult result)
        {
            if (result.TotalRows == 0)
            {
                MessageBox.Show(
                    "The selected CSV file has no records to import. Please select a file that contains at least one data row.",
                    "Import Records",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else if (result.FailedCount == 0)
            {
                MessageBox.Show(
                    $"All {result.SuccessCount} record(s) were imported successfully.",
                    "Import Records",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else if (result.SuccessCount == 0)
            {
                MessageBox.Show(
                    $"None of the {result.TotalRows} record(s) could be imported. Please review the details below and correct these rows, then try again.\n\n" +
                    BuildErrorSummary(result),
                    "Import Records",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show(
                    $"{result.SuccessCount} of {result.TotalRows} record(s) were imported successfully. " +
                    $"{result.FailedCount} record(s) could not be imported. Please review the details below and correct these rows.\n\n" +
                    BuildErrorSummary(result),
                    "Import Records",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
        //END: Added By: Trupti Date: 11-Sep-2026 Desc: Show import result as a popup, following message standards (what/why/next step)

        private string BuildErrorSummary(CsvImportResult result)
        {
            StringBuilder sb = new StringBuilder();

            foreach (string error in result.Errors)
            {
                sb.AppendLine("- " + error);
            }

            return sb.ToString();
        }

        #endregion
    }
}