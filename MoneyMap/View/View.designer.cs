
namespace GP_1
{
    public partial class View : System.Windows.Forms.Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showIncomeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showExpenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.summaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                        this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                        this.showAllToolStripMenuItem,
                        this.showIncomeToolStripMenuItem,
                        this.showExpenseToolStripMenuItem,
                        this.summaryToolStripMenuItem,
                        this.graphToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(61, 29);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // showAllToolStripMenuItem
            // 
            this.showAllToolStripMenuItem.Name = "showAllToolStripMenuItem";
            this.showAllToolStripMenuItem.Size = new System.Drawing.Size(210, 30);
            this.showAllToolStripMenuItem.Text = "Show All";
            this.showAllToolStripMenuItem.Click += new System.EventHandler(this.ShowAllToolStripMenuItem_Click);
            // 
            // showIncomeToolStripMenuItem
            // 
            this.showIncomeToolStripMenuItem.Name = "showIncomeToolStripMenuItem";
            this.showIncomeToolStripMenuItem.Size = new System.Drawing.Size(210, 30);
            this.showIncomeToolStripMenuItem.Text = "Show Income";
            this.showIncomeToolStripMenuItem.Click += new System.EventHandler(this.ShowIncomeToolStripMenuItem_Click);
            // 
            // showExpenseToolStripMenuItem
            // 
            this.showExpenseToolStripMenuItem.Name = "showExpenseToolStripMenuItem";
            this.showExpenseToolStripMenuItem.Size = new System.Drawing.Size(210, 30);
            this.showExpenseToolStripMenuItem.Text = "Show Expense";
            this.showExpenseToolStripMenuItem.Click += new System.EventHandler(this.ShowExpenseToolStripMenuItem_Click);
            // 
            // summaryToolStripMenuItem
            // 
            this.summaryToolStripMenuItem.Name = "summaryToolStripMenuItem";
            this.summaryToolStripMenuItem.Size = new System.Drawing.Size(210, 30);
            this.summaryToolStripMenuItem.Text = "Summary";
            this.summaryToolStripMenuItem.Click += new System.EventHandler(this.SummaryToolStripMenuItem_Click);
            // 
            // graphToolStripMenuItem
            // 
            this.graphToolStripMenuItem.Name = "graphToolStripMenuItem";
            this.graphToolStripMenuItem.Size = new System.Drawing.Size(210, 30);
            this.graphToolStripMenuItem.Text = "Graph";
            this.graphToolStripMenuItem.Click += new System.EventHandler(this.GraphToolStripMenuItem_Click);
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "View";
            this.Text = "View";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }


        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showIncomeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showExpenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem summaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphToolStripMenuItem;
    }
}