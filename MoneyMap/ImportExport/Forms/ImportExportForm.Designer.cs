namespace GP_1.Forms
{
    partial class ImportExportForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.topPanel = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.subtitleLabel = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.mainScrollPanel = new System.Windows.Forms.Panel();
            this.cardsContainer = new System.Windows.Forms.Panel();
            this.cardImport = new System.Windows.Forms.Panel();
            this.lblImportTitle = new System.Windows.Forms.Label();
            this.lblImportDesc = new System.Windows.Forms.Label();
            this.btnImportCsv = new System.Windows.Forms.Button();
            this.btnDownloadTemplate = new System.Windows.Forms.Button();
            this.cardExport = new System.Windows.Forms.Panel();
            this.lblExportTitle = new System.Windows.Forms.Label();
            this.lblExportDesc = new System.Windows.Forms.Label();
            this.btnExportMy = new System.Windows.Forms.Button();
            this.btnExportAll = new System.Windows.Forms.Button();
            this.cardResult = new System.Windows.Forms.Panel();
            this.lblResultTitle = new System.Windows.Forms.Label();
            this.lblResultStatus = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();

            this.topPanel.SuspendLayout();
            this.mainScrollPanel.SuspendLayout();
            this.cardsContainer.SuspendLayout();
            this.cardImport.SuspendLayout();
            this.cardExport.SuspendLayout();
            this.cardResult.SuspendLayout();
            this.SuspendLayout();

            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.White;
            this.topPanel.Controls.Add(this.titleLabel);
            this.topPanel.Controls.Add(this.subtitleLabel);
            this.topPanel.Controls.Add(this.btnClose);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(24, 20);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(950, 75);
            this.topPanel.TabIndex = 0;

            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(24, 31, 42);
            this.titleLabel.Location = new System.Drawing.Point(0, 8);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(275, 37);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "CSV Import & Export";

            // 
            // subtitleLabel
            // 
            this.subtitleLabel.AutoSize = true;
            this.subtitleLabel.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.subtitleLabel.ForeColor = System.Drawing.Color.FromArgb(110, 118, 130);
            this.subtitleLabel.Location = new System.Drawing.Point(2, 45);
            this.subtitleLabel.Name = "subtitleLabel";
            this.subtitleLabel.Size = new System.Drawing.Size(420, 21);
            this.subtitleLabel.TabIndex = 1;
            this.subtitleLabel.Text = "Export financial records to CSV or import bulk data effortlessly";

            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnClose.Location = new System.Drawing.Point(825, 20);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(125, 36);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "✕ Close View";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // 
            // mainScrollPanel
            // 
            this.mainScrollPanel.AutoScroll = true;
            this.mainScrollPanel.Controls.Add(this.cardsContainer);
            this.mainScrollPanel.Controls.Add(this.cardResult);
            this.mainScrollPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainScrollPanel.Location = new System.Drawing.Point(24, 95);
            this.mainScrollPanel.Name = "mainScrollPanel";
            this.mainScrollPanel.Padding = new System.Windows.Forms.Padding(0, 16, 0, 0);
            this.mainScrollPanel.Size = new System.Drawing.Size(950, 505);
            this.mainScrollPanel.TabIndex = 1;

            // 
            // cardsContainer
            // 
            this.cardsContainer.Controls.Add(this.cardImport);
            this.cardsContainer.Controls.Add(this.cardExport);
            this.cardsContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.cardsContainer.Location = new System.Drawing.Point(0, 16);
            this.cardsContainer.Name = "cardsContainer";
            this.cardsContainer.Size = new System.Drawing.Size(950, 210);
            this.cardsContainer.TabIndex = 0;
            this.cardsContainer.Resize += new System.EventHandler(this.CardsContainer_Resize);

            // 
            // cardImport
            // 
            this.cardImport.BackColor = System.Drawing.Color.White;
            this.cardImport.Controls.Add(this.lblImportTitle);
            this.cardImport.Controls.Add(this.lblImportDesc);
            this.cardImport.Controls.Add(this.btnImportCsv);
            this.cardImport.Controls.Add(this.btnDownloadTemplate);
            this.cardImport.Location = new System.Drawing.Point(0, 0);
            this.cardImport.Name = "cardImport";
            this.cardImport.Padding = new System.Windows.Forms.Padding(20);
            this.cardImport.Size = new System.Drawing.Size(460, 200);
            this.cardImport.TabIndex = 0;

            // 
            // lblImportTitle
            // 
            this.lblImportTitle.AutoSize = true;
            this.lblImportTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblImportTitle.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.lblImportTitle.Location = new System.Drawing.Point(16, 16);
            this.lblImportTitle.Name = "lblImportTitle";
            this.lblImportTitle.Size = new System.Drawing.Size(262, 28);
            this.lblImportTitle.TabIndex = 0;
            this.lblImportTitle.Text = "Import Transactions (CSV)";

            // 
            // lblImportDesc
            // 
            this.lblImportDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblImportDesc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblImportDesc.ForeColor = System.Drawing.Color.FromArgb(110, 118, 130);
            this.lblImportDesc.Location = new System.Drawing.Point(18, 48);
            this.lblImportDesc.Name = "lblImportDesc";
            this.lblImportDesc.Size = new System.Drawing.Size(422, 54);
            this.lblImportDesc.TabIndex = 1;
            this.lblImportDesc.Text = "Import transaction rows into your database. Header format:\r\nc_user_id, c_category_id, c_transaction_date, c_description, c_amount";

            // 
            // btnImportCsv
            // 
            this.btnImportCsv.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnImportCsv.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImportCsv.FlatAppearance.BorderSize = 0;
            this.btnImportCsv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportCsv.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnImportCsv.ForeColor = System.Drawing.Color.White;
            this.btnImportCsv.Location = new System.Drawing.Point(20, 120);
            this.btnImportCsv.Name = "btnImportCsv";
            this.btnImportCsv.Size = new System.Drawing.Size(185, 38);
            this.btnImportCsv.TabIndex = 2;
            this.btnImportCsv.Text = "📥 Browse & Import CSV";
            this.btnImportCsv.UseVisualStyleBackColor = false;
            this.btnImportCsv.Click += new System.EventHandler(this.btnImportCsv_Click);

            // 
            // btnDownloadTemplate
            // 
            this.btnDownloadTemplate.BackColor = System.Drawing.Color.White;
            this.btnDownloadTemplate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDownloadTemplate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnDownloadTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownloadTemplate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDownloadTemplate.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.btnDownloadTemplate.Location = new System.Drawing.Point(215, 120);
            this.btnDownloadTemplate.Name = "btnDownloadTemplate";
            this.btnDownloadTemplate.Size = new System.Drawing.Size(160, 38);
            this.btnDownloadTemplate.TabIndex = 3;
            this.btnDownloadTemplate.Text = "📄 Sample Template";
            this.btnDownloadTemplate.UseVisualStyleBackColor = false;
            this.btnDownloadTemplate.Click += new System.EventHandler(this.btnDownloadTemplate_Click);

            // 
            // cardExport
            // 
            this.cardExport.BackColor = System.Drawing.Color.White;
            this.cardExport.Controls.Add(this.lblExportTitle);
            this.cardExport.Controls.Add(this.lblExportDesc);
            this.cardExport.Controls.Add(this.btnExportMy);
            this.cardExport.Controls.Add(this.btnExportAll);
            this.cardExport.Location = new System.Drawing.Point(480, 0);
            this.cardExport.Name = "cardExport";
            this.cardExport.Padding = new System.Windows.Forms.Padding(20);
            this.cardExport.Size = new System.Drawing.Size(460, 200);
            this.cardExport.TabIndex = 1;

            // 
            // lblExportTitle
            // 
            this.lblExportTitle.AutoSize = true;
            this.lblExportTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblExportTitle.ForeColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.lblExportTitle.Location = new System.Drawing.Point(16, 16);
            this.lblExportTitle.Name = "lblExportTitle";
            this.lblExportTitle.Size = new System.Drawing.Size(257, 28);
            this.lblExportTitle.TabIndex = 0;
            this.lblExportTitle.Text = "Export Transactions (CSV)";

            // 
            // lblExportDesc
            // 
            this.lblExportDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblExportDesc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblExportDesc.ForeColor = System.Drawing.Color.FromArgb(110, 118, 130);
            this.lblExportDesc.Location = new System.Drawing.Point(18, 48);
            this.lblExportDesc.Name = "lblExportDesc";
            this.lblExportDesc.Size = new System.Drawing.Size(422, 54);
            this.lblExportDesc.TabIndex = 1;
            this.lblExportDesc.Text = "Export financial transactions to a comma-separated (.csv) file suitable for Microsoft Excel, Google Sheets, or backup storage.";

            // 
            // btnExportMy
            // 
            this.btnExportMy.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.btnExportMy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportMy.FlatAppearance.BorderSize = 0;
            this.btnExportMy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportMy.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnExportMy.ForeColor = System.Drawing.Color.White;
            this.btnExportMy.Location = new System.Drawing.Point(20, 120);
            this.btnExportMy.Name = "btnExportMy";
            this.btnExportMy.Size = new System.Drawing.Size(185, 38);
            this.btnExportMy.TabIndex = 2;
            this.btnExportMy.Text = "📤 Export My Records";
            this.btnExportMy.UseVisualStyleBackColor = false;
            this.btnExportMy.Click += new System.EventHandler(this.btnExportMy_Click);

            // 
            // btnExportAll
            // 
            this.btnExportAll.BackColor = System.Drawing.Color.FromArgb(35, 42, 52);
            this.btnExportAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportAll.FlatAppearance.BorderSize = 0;
            this.btnExportAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportAll.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnExportAll.ForeColor = System.Drawing.Color.White;
            this.btnExportAll.Location = new System.Drawing.Point(215, 120);
            this.btnExportAll.Name = "btnExportAll";
            this.btnExportAll.Size = new System.Drawing.Size(170, 38);
            this.btnExportAll.TabIndex = 3;
            this.btnExportAll.Text = "🌐 Export All Data";
            this.btnExportAll.UseVisualStyleBackColor = false;
            this.btnExportAll.Click += new System.EventHandler(this.btnExportAll_Click);

            // 
            // cardResult
            // 
            this.cardResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cardResult.BackColor = System.Drawing.Color.White;
            this.cardResult.Controls.Add(this.lblResultTitle);
            this.cardResult.Controls.Add(this.lblResultStatus);
            this.cardResult.Controls.Add(this.txtLog);
            this.cardResult.Location = new System.Drawing.Point(0, 230);
            this.cardResult.Name = "cardResult";
            this.cardResult.Padding = new System.Windows.Forms.Padding(20);
            this.cardResult.Size = new System.Drawing.Size(950, 260);
            this.cardResult.TabIndex = 1;

            // 
            // lblResultTitle
            // 
            this.lblResultTitle.AutoSize = true;
            this.lblResultTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblResultTitle.ForeColor = System.Drawing.Color.FromArgb(35, 42, 52);
            this.lblResultTitle.Location = new System.Drawing.Point(16, 14);
            this.lblResultTitle.Name = "lblResultTitle";
            this.lblResultTitle.Size = new System.Drawing.Size(167, 25);
            this.lblResultTitle.TabIndex = 0;
            this.lblResultTitle.Text = "Status & Activity Log";

            // 
            // lblResultStatus
            // 
            this.lblResultStatus.AutoSize = true;
            this.lblResultStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblResultStatus.ForeColor = System.Drawing.Color.FromArgb(110, 118, 130);
            this.lblResultStatus.Location = new System.Drawing.Point(18, 42);
            this.lblResultStatus.Name = "lblResultStatus";
            this.lblResultStatus.Size = new System.Drawing.Size(258, 20);
            this.lblResultStatus.TabIndex = 1;
            this.lblResultStatus.Text = "Ready to import or export transactions.";

            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.BackColor = System.Drawing.Color.FromArgb(248, 249, 251);
            this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLog.Font = new System.Drawing.Font("Consolas", 9.5F);
            this.txtLog.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.txtLog.Location = new System.Drawing.Point(20, 70);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(910, 170);
            this.txtLog.TabIndex = 2;

            // 
            // ImportExportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(248, 249, 251);
            this.ClientSize = new System.Drawing.Size(998, 620);
            this.Controls.Add(this.mainScrollPanel);
            this.Controls.Add(this.topPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "ImportExportForm";
            this.Padding = new System.Windows.Forms.Padding(24, 20, 24, 20);
            this.Text = "CSV Import & Export";
            this.Load += new System.EventHandler(this.ImportExportForm_Load);

            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.mainScrollPanel.ResumeLayout(false);
            this.cardsContainer.ResumeLayout(false);
            this.cardImport.ResumeLayout(false);
            this.cardImport.PerformLayout();
            this.cardExport.ResumeLayout(false);
            this.cardExport.PerformLayout();
            this.cardResult.ResumeLayout(false);
            this.cardResult.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label subtitleLabel;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel mainScrollPanel;
        private System.Windows.Forms.Panel cardsContainer;
        private System.Windows.Forms.Panel cardImport;
        private System.Windows.Forms.Label lblImportTitle;
        private System.Windows.Forms.Label lblImportDesc;
        private System.Windows.Forms.Button btnImportCsv;
        private System.Windows.Forms.Button btnDownloadTemplate;
        private System.Windows.Forms.Panel cardExport;
        private System.Windows.Forms.Label lblExportTitle;
        private System.Windows.Forms.Label lblExportDesc;
        private System.Windows.Forms.Button btnExportMy;
        private System.Windows.Forms.Button btnExportAll;
        private System.Windows.Forms.Panel cardResult;
        private System.Windows.Forms.Label lblResultTitle;
        private System.Windows.Forms.Label lblResultStatus;
        private System.Windows.Forms.TextBox txtLog;
    }
}
