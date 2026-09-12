namespace MoneyMap.Setting.Forms
{
    partial class SettingForm
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
            this.headerPanel = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.fontCard = new System.Windows.Forms.Panel();
            this.lblFontSection = new System.Windows.Forms.Label();
            this.lblFontFamily = new System.Windows.Forms.Label();
            this.cmbFontFamily = new System.Windows.Forms.ComboBox();
            this.lblFontSize = new System.Windows.Forms.Label();
            this.numFontSize = new System.Windows.Forms.NumericUpDown();
            this.btnBrowseFont = new System.Windows.Forms.Button();
            this.colorCard = new System.Windows.Forms.Panel();
            this.lblColorSection = new System.Windows.Forms.Label();
            this.lblTextColor = new System.Windows.Forms.Label();
            this.btnPickTextColor = new System.Windows.Forms.Button();
            this.pnlTextColorSample = new System.Windows.Forms.Panel();
            this.lblBgColor = new System.Windows.Forms.Label();
            this.btnPickBgColor = new System.Windows.Forms.Button();
            this.pnlBgColorSample = new System.Windows.Forms.Panel();
            this.previewCard = new System.Windows.Forms.Panel();
            this.lblPreviewSection = new System.Windows.Forms.Label();
            this.pnlLivePreview = new System.Windows.Forms.Panel();
            this.lblPreviewHeading = new System.Windows.Forms.Label();
            this.lblPreviewSampleText = new System.Windows.Forms.Label();
            this.lblPreviewAmount = new System.Windows.Forms.Label();
            this.txtPreviewInput = new System.Windows.Forms.TextBox();
            this.bottomBar = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.headerPanel.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.fontCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFontSize)).BeginInit();
            this.colorCard.SuspendLayout();
            this.previewCard.SuspendLayout();
            this.pnlLivePreview.SuspendLayout();
            this.bottomBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.White;
            this.headerPanel.Controls.Add(this.lblTitle);
            this.headerPanel.Controls.Add(this.lblSubtitle);
            this.headerPanel.Controls.Add(this.btnClose);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Padding = new System.Windows.Forms.Padding(24, 16, 24, 16);
            this.headerPanel.Size = new System.Drawing.Size(950, 75);
            this.headerPanel.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(24, 31, 42);
            this.lblTitle.Location = new System.Drawing.Point(24, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(248, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Appearance & Settings";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblSubtitle.Location = new System.Drawing.Point(26, 46);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(465, 15);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Customize your font family, font size, typography colors, and background theme globally.";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(243, 244, 246);
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(75, 85, 99);
            this.btnClose.Location = new System.Drawing.Point(825, 20);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 34);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "✕ Close View";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // contentPanel
            // 
            this.contentPanel.AutoScroll = true;
            this.contentPanel.Controls.Add(this.tableLayoutPanel);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(0, 75);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Padding = new System.Windows.Forms.Padding(20);
            this.contentPanel.Size = new System.Drawing.Size(950, 435);
            this.contentPanel.TabIndex = 1;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tableLayoutPanel.Controls.Add(this.fontCard, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.colorCard, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.previewCard, 2, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel.Location = new System.Drawing.Point(20, 20);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 340F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(910, 340);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // fontCard
            // 
            this.fontCard.BackColor = System.Drawing.Color.White;
            this.fontCard.Controls.Add(this.lblFontSection);
            this.fontCard.Controls.Add(this.lblFontFamily);
            this.fontCard.Controls.Add(this.cmbFontFamily);
            this.fontCard.Controls.Add(this.lblFontSize);
            this.fontCard.Controls.Add(this.numFontSize);
            this.fontCard.Controls.Add(this.btnBrowseFont);
            this.fontCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fontCard.Location = new System.Drawing.Point(3, 3);
            this.fontCard.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.fontCard.Name = "fontCard";
            this.fontCard.Padding = new System.Windows.Forms.Padding(16);
            this.fontCard.Size = new System.Drawing.Size(290, 334);
            this.fontCard.TabIndex = 0;
            // 
            // lblFontSection
            // 
            this.lblFontSection.AutoSize = true;
            this.lblFontSection.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblFontSection.ForeColor = System.Drawing.Color.FromArgb(24, 31, 42);
            this.lblFontSection.Location = new System.Drawing.Point(16, 16);
            this.lblFontSection.Name = "lblFontSection";
            this.lblFontSection.Size = new System.Drawing.Size(126, 21);
            this.lblFontSection.TabIndex = 0;
            this.lblFontSection.Text = "🔤 Font Settings";
            // 
            // lblFontFamily
            // 
            this.lblFontFamily.AutoSize = true;
            this.lblFontFamily.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblFontFamily.ForeColor = System.Drawing.Color.FromArgb(75, 85, 99);
            this.lblFontFamily.Location = new System.Drawing.Point(16, 56);
            this.lblFontFamily.Name = "lblFontFamily";
            this.lblFontFamily.Size = new System.Drawing.Size(70, 15);
            this.lblFontFamily.TabIndex = 1;
            this.lblFontFamily.Text = "Font Family";
            // 
            // cmbFontFamily
            // 
            this.cmbFontFamily.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFontFamily.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFontFamily.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbFontFamily.FormattingEnabled = true;
            this.cmbFontFamily.Location = new System.Drawing.Point(19, 76);
            this.cmbFontFamily.Name = "cmbFontFamily";
            this.cmbFontFamily.Size = new System.Drawing.Size(252, 25);
            this.cmbFontFamily.TabIndex = 2;
            this.cmbFontFamily.SelectedIndexChanged += new System.EventHandler(this.Control_ValueChanged);
            // 
            // lblFontSize
            // 
            this.lblFontSize.AutoSize = true;
            this.lblFontSize.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblFontSize.ForeColor = System.Drawing.Color.FromArgb(75, 85, 99);
            this.lblFontSize.Location = new System.Drawing.Point(16, 120);
            this.lblFontSize.Name = "lblFontSize";
            this.lblFontSize.Size = new System.Drawing.Size(54, 15);
            this.lblFontSize.TabIndex = 3;
            this.lblFontSize.Text = "Font Size";
            // 
            // numFontSize
            // 
            this.numFontSize.DecimalPlaces = 1;
            this.numFontSize.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.numFontSize.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numFontSize.Location = new System.Drawing.Point(19, 140);
            this.numFontSize.Maximum = new decimal(new int[] {
            18,
            0,
            0,
            0});
            this.numFontSize.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numFontSize.Name = "numFontSize";
            this.numFontSize.Size = new System.Drawing.Size(120, 24);
            this.numFontSize.TabIndex = 4;
            this.numFontSize.Value = new decimal(new int[] {
            95,
            0,
            0,
            65536});
            this.numFontSize.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            // 
            // btnBrowseFont
            // 
            this.btnBrowseFont.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseFont.BackColor = System.Drawing.Color.FromArgb(243, 244, 246);
            this.btnBrowseFont.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowseFont.FlatAppearance.BorderSize = 0;
            this.btnBrowseFont.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseFont.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnBrowseFont.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.btnBrowseFont.Location = new System.Drawing.Point(19, 185);
            this.btnBrowseFont.Name = "btnBrowseFont";
            this.btnBrowseFont.Size = new System.Drawing.Size(252, 36);
            this.btnBrowseFont.TabIndex = 5;
            this.btnBrowseFont.Text = "🔍 Open Font Dialog...";
            this.btnBrowseFont.UseVisualStyleBackColor = false;
            this.btnBrowseFont.Click += new System.EventHandler(this.btnBrowseFont_Click);
            // 
            // colorCard
            // 
            this.colorCard.BackColor = System.Drawing.Color.White;
            this.colorCard.Controls.Add(this.lblColorSection);
            this.colorCard.Controls.Add(this.lblTextColor);
            this.colorCard.Controls.Add(this.btnPickTextColor);
            this.colorCard.Controls.Add(this.pnlTextColorSample);
            this.colorCard.Controls.Add(this.lblBgColor);
            this.colorCard.Controls.Add(this.btnPickBgColor);
            this.colorCard.Controls.Add(this.pnlBgColorSample);
            this.colorCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorCard.Location = new System.Drawing.Point(306, 3);
            this.colorCard.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.colorCard.Name = "colorCard";
            this.colorCard.Padding = new System.Windows.Forms.Padding(16);
            this.colorCard.Size = new System.Drawing.Size(290, 334);
            this.colorCard.TabIndex = 1;
            // 
            // lblColorSection
            // 
            this.lblColorSection.AutoSize = true;
            this.lblColorSection.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblColorSection.ForeColor = System.Drawing.Color.FromArgb(24, 31, 42);
            this.lblColorSection.Location = new System.Drawing.Point(16, 16);
            this.lblColorSection.Name = "lblColorSection";
            this.lblColorSection.Size = new System.Drawing.Size(133, 21);
            this.lblColorSection.TabIndex = 0;
            this.lblColorSection.Text = "🎨 Color Theme";
            // 
            // lblTextColor
            // 
            this.lblTextColor.AutoSize = true;
            this.lblTextColor.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblTextColor.ForeColor = System.Drawing.Color.FromArgb(75, 85, 99);
            this.lblTextColor.Location = new System.Drawing.Point(16, 56);
            this.lblTextColor.Name = "lblTextColor";
            this.lblTextColor.Size = new System.Drawing.Size(60, 15);
            this.lblTextColor.TabIndex = 1;
            this.lblTextColor.Text = "Text Color";
            // 
            // btnPickTextColor
            // 
            this.btnPickTextColor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPickTextColor.BackColor = System.Drawing.Color.FromArgb(243, 244, 246);
            this.btnPickTextColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPickTextColor.FlatAppearance.BorderSize = 0;
            this.btnPickTextColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPickTextColor.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnPickTextColor.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.btnPickTextColor.Location = new System.Drawing.Point(60, 76);
            this.btnPickTextColor.Name = "btnPickTextColor";
            this.btnPickTextColor.Size = new System.Drawing.Size(211, 32);
            this.btnPickTextColor.TabIndex = 3;
            this.btnPickTextColor.Text = "Choose Text Color...";
            this.btnPickTextColor.UseVisualStyleBackColor = false;
            this.btnPickTextColor.Click += new System.EventHandler(this.btnPickTextColor_Click);
            // 
            // pnlTextColorSample
            // 
            this.pnlTextColorSample.BackColor = System.Drawing.Color.FromArgb(24, 31, 42);
            this.pnlTextColorSample.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTextColorSample.Location = new System.Drawing.Point(19, 76);
            this.pnlTextColorSample.Name = "pnlTextColorSample";
            this.pnlTextColorSample.Size = new System.Drawing.Size(32, 32);
            this.pnlTextColorSample.TabIndex = 2;
            // 
            // lblBgColor
            // 
            this.lblBgColor.AutoSize = true;
            this.lblBgColor.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblBgColor.ForeColor = System.Drawing.Color.FromArgb(75, 85, 99);
            this.lblBgColor.Location = new System.Drawing.Point(16, 130);
            this.lblBgColor.Name = "lblBgColor";
            this.lblBgColor.Size = new System.Drawing.Size(103, 15);
            this.lblBgColor.TabIndex = 4;
            this.lblBgColor.Text = "Background Color";
            // 
            // btnPickBgColor
            // 
            this.btnPickBgColor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPickBgColor.BackColor = System.Drawing.Color.FromArgb(243, 244, 246);
            this.btnPickBgColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPickBgColor.FlatAppearance.BorderSize = 0;
            this.btnPickBgColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPickBgColor.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnPickBgColor.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.btnPickBgColor.Location = new System.Drawing.Point(60, 150);
            this.btnPickBgColor.Name = "btnPickBgColor";
            this.btnPickBgColor.Size = new System.Drawing.Size(211, 32);
            this.btnPickBgColor.TabIndex = 6;
            this.btnPickBgColor.Text = "Choose Background...";
            this.btnPickBgColor.UseVisualStyleBackColor = false;
            this.btnPickBgColor.Click += new System.EventHandler(this.btnPickBgColor_Click);
            // 
            // pnlBgColorSample
            // 
            this.pnlBgColorSample.BackColor = System.Drawing.Color.FromArgb(248, 249, 251);
            this.pnlBgColorSample.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBgColorSample.Location = new System.Drawing.Point(19, 150);
            this.pnlBgColorSample.Name = "pnlBgColorSample";
            this.pnlBgColorSample.Size = new System.Drawing.Size(32, 32);
            this.pnlBgColorSample.TabIndex = 5;
            // 
            // previewCard
            // 
            this.previewCard.BackColor = System.Drawing.Color.White;
            this.previewCard.Controls.Add(this.lblPreviewSection);
            this.previewCard.Controls.Add(this.pnlLivePreview);
            this.previewCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewCard.Location = new System.Drawing.Point(609, 3);
            this.previewCard.Name = "previewCard";
            this.previewCard.Padding = new System.Windows.Forms.Padding(16);
            this.previewCard.Size = new System.Drawing.Size(298, 334);
            this.previewCard.TabIndex = 2;
            // 
            // lblPreviewSection
            // 
            this.lblPreviewSection.AutoSize = true;
            this.lblPreviewSection.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblPreviewSection.ForeColor = System.Drawing.Color.FromArgb(24, 31, 42);
            this.lblPreviewSection.Location = new System.Drawing.Point(16, 16);
            this.lblPreviewSection.Name = "lblPreviewSection";
            this.lblPreviewSection.Size = new System.Drawing.Size(130, 21);
            this.lblPreviewSection.TabIndex = 0;
            this.lblPreviewSection.Text = "👁️ Live Preview";
            // 
            // pnlLivePreview
            // 
            this.pnlLivePreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlLivePreview.BackColor = System.Drawing.Color.FromArgb(248, 249, 251);
            this.pnlLivePreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLivePreview.Controls.Add(this.lblPreviewHeading);
            this.pnlLivePreview.Controls.Add(this.lblPreviewSampleText);
            this.pnlLivePreview.Controls.Add(this.lblPreviewAmount);
            this.pnlLivePreview.Controls.Add(this.txtPreviewInput);
            this.pnlLivePreview.Location = new System.Drawing.Point(19, 56);
            this.pnlLivePreview.Name = "pnlLivePreview";
            this.pnlLivePreview.Padding = new System.Windows.Forms.Padding(16);
            this.pnlLivePreview.Size = new System.Drawing.Size(260, 250);
            this.pnlLivePreview.TabIndex = 1;
            // 
            // lblPreviewHeading
            // 
            this.lblPreviewHeading.AutoSize = true;
            this.lblPreviewHeading.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblPreviewHeading.ForeColor = System.Drawing.Color.FromArgb(24, 31, 42);
            this.lblPreviewHeading.Location = new System.Drawing.Point(16, 16);
            this.lblPreviewHeading.Name = "lblPreviewHeading";
            this.lblPreviewHeading.Size = new System.Drawing.Size(162, 21);
            this.lblPreviewHeading.TabIndex = 0;
            this.lblPreviewHeading.Text = "Dashboard Preview";
            // 
            // lblPreviewSampleText
            // 
            this.lblPreviewSampleText.AutoSize = true;
            this.lblPreviewSampleText.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblPreviewSampleText.ForeColor = System.Drawing.Color.FromArgb(24, 31, 42);
            this.lblPreviewSampleText.Location = new System.Drawing.Point(16, 50);
            this.lblPreviewSampleText.Name = "lblPreviewSampleText";
            this.lblPreviewSampleText.Size = new System.Drawing.Size(211, 17);
            this.lblPreviewSampleText.TabIndex = 1;
            this.lblPreviewSampleText.Text = "Salary Deposit • Primary Account";
            // 
            // lblPreviewAmount
            // 
            this.lblPreviewAmount.AutoSize = true;
            this.lblPreviewAmount.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblPreviewAmount.ForeColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.lblPreviewAmount.Location = new System.Drawing.Point(16, 80);
            this.lblPreviewAmount.Name = "lblPreviewAmount";
            this.lblPreviewAmount.Size = new System.Drawing.Size(126, 25);
            this.lblPreviewAmount.TabIndex = 2;
            this.lblPreviewAmount.Text = "+$12,450.00";
            // 
            // txtPreviewInput
            // 
            this.txtPreviewInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPreviewInput.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtPreviewInput.Location = new System.Drawing.Point(16, 195);
            this.txtPreviewInput.Name = "txtPreviewInput";
            this.txtPreviewInput.Size = new System.Drawing.Size(226, 24);
            this.txtPreviewInput.TabIndex = 3;
            this.txtPreviewInput.Text = "Sample Transaction Note...";
            // 
            // bottomBar
            // 
            this.bottomBar.BackColor = System.Drawing.Color.White;
            this.bottomBar.Controls.Add(this.btnSave);
            this.bottomBar.Controls.Add(this.btnReset);
            this.bottomBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomBar.Location = new System.Drawing.Point(0, 510);
            this.bottomBar.Name = "bottomBar";
            this.bottomBar.Padding = new System.Windows.Forms.Padding(24, 12, 24, 12);
            this.bottomBar.Size = new System.Drawing.Size(950, 60);
            this.bottomBar.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(746, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(180, 36);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "💾 Save & Apply Globally";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(243, 244, 246);
            this.btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnReset.ForeColor = System.Drawing.Color.FromArgb(75, 85, 99);
            this.btnReset.Location = new System.Drawing.Point(580, 12);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(150, 36);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "↺ Reset to Default";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(248, 249, 251);
            this.ClientSize = new System.Drawing.Size(950, 570);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.bottomBar);
            this.Controls.Add(this.headerPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SettingForm";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.contentPanel.ResumeLayout(false);
            this.tableLayoutPanel.ResumeLayout(false);
            this.fontCard.ResumeLayout(false);
            this.fontCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFontSize)).EndInit();
            this.colorCard.ResumeLayout(false);
            this.colorCard.PerformLayout();
            this.previewCard.ResumeLayout(false);
            this.previewCard.PerformLayout();
            this.pnlLivePreview.ResumeLayout(false);
            this.pnlLivePreview.PerformLayout();
            this.bottomBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Panel fontCard;
        private System.Windows.Forms.Label lblFontSection;
        private System.Windows.Forms.Label lblFontFamily;
        private System.Windows.Forms.ComboBox cmbFontFamily;
        private System.Windows.Forms.Label lblFontSize;
        private System.Windows.Forms.NumericUpDown numFontSize;
        private System.Windows.Forms.Button btnBrowseFont;
        private System.Windows.Forms.Panel colorCard;
        private System.Windows.Forms.Label lblColorSection;
        private System.Windows.Forms.Label lblTextColor;
        private System.Windows.Forms.Button btnPickTextColor;
        private System.Windows.Forms.Panel pnlTextColorSample;
        private System.Windows.Forms.Label lblBgColor;
        private System.Windows.Forms.Button btnPickBgColor;
        private System.Windows.Forms.Panel pnlBgColorSample;
        private System.Windows.Forms.Panel previewCard;
        private System.Windows.Forms.Label lblPreviewSection;
        private System.Windows.Forms.Panel pnlLivePreview;
        private System.Windows.Forms.Label lblPreviewHeading;
        private System.Windows.Forms.Label lblPreviewSampleText;
        private System.Windows.Forms.Label lblPreviewAmount;
        private System.Windows.Forms.TextBox txtPreviewInput;
        private System.Windows.Forms.Panel bottomBar;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnReset;
    }
}
