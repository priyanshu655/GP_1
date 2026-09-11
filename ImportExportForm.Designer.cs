namespace GP_1
{
    partial class ImportExportForm
    {
        #region Variable Declaration

        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importRecordsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportRecordsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;

        #endregion

        #region Common

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #endregion

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importRecordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportRecordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripMain.SuspendLayout();
            this.SuspendLayout();
            //
            // menuStripMain
            //
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(600, 24);
            this.menuStripMain.TabIndex = 0;
            this.menuStripMain.Text = "menuStripMain";
            //
            // fileToolStripMenuItem
            //
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importRecordsToolStripMenuItem,
            this.exportRecordsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            //
            // importRecordsToolStripMenuItem
            //
            this.importRecordsToolStripMenuItem.Name = "importRecordsToolStripMenuItem";
            this.importRecordsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.importRecordsToolStripMenuItem.Text = "Import Records";
            this.importRecordsToolStripMenuItem.Click += new System.EventHandler(this.importRecordsToolStripMenuItem_Click);
            //
            // exportRecordsToolStripMenuItem
            //
            this.exportRecordsToolStripMenuItem.Name = "exportRecordsToolStripMenuItem";
            this.exportRecordsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exportRecordsToolStripMenuItem.Text = "Export Records";
            this.exportRecordsToolStripMenuItem.Click += new System.EventHandler(this.exportRecordsToolStripMenuItem_Click);
            //
            // toolStripSeparator1
            //
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            //
            // exitToolStripMenuItem
            //
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            //
            // ImportExportForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.menuStripMain);
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "ImportExportForm";
            this.Text = "Import / Export Test Form";
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}