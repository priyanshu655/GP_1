namespace GP_1
{
    public partial class Summary : System.Windows.Forms.Form
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
    this.monthPicker = new System.Windows.Forms.DateTimePicker();
    this.incomeLabel = new System.Windows.Forms.Label();
    this.incomeBar = new System.Windows.Forms.ProgressBar();
    this.expenseLabel = new System.Windows.Forms.Label();
    this.expenseBar = new System.Windows.Forms.ProgressBar();
    this.balanceLabel = new System.Windows.Forms.Label();
    this.balanceBar = new System.Windows.Forms.ProgressBar();
    this.SuspendLayout();
    
    // 
    // monthPicker
    // 
    this.monthPicker.Location = new System.Drawing.Point(40, 40);
    this.monthPicker.Name = "monthPicker";
    this.monthPicker.Size = new System.Drawing.Size(200, 26);
    this.monthPicker.TabIndex = 0;
    
    // 
    // incomeLabel
    // 
    this.incomeLabel.Location = new System.Drawing.Point(40, 100);
    this.incomeLabel.Name = "incomeLabel";
    this.incomeLabel.Text = "Income:";
    this.incomeLabel.Size = new System.Drawing.Size(100, 23);
    this.incomeLabel.TabIndex = 1;
    
    // 
    // incomeBar
    // 
    this.incomeBar.Location = new System.Drawing.Point(150, 100);
    this.incomeBar.Name = "incomeBar";
    this.incomeBar.Size = new System.Drawing.Size(200, 23);
    this.incomeBar.TabIndex = 2;
    
    // 
    // expenseLabel
    // 
    this.expenseLabel.Location = new System.Drawing.Point(40, 150);
    this.expenseLabel.Name = "expenseLabel";
    this.expenseLabel.Text = "Expenses:";
    this.expenseLabel.Size = new System.Drawing.Size(100, 23);
    this.expenseLabel.TabIndex = 3;
    
    // 
    // expenseBar
    // 
    this.expenseBar.Location = new System.Drawing.Point(150, 150);
    this.expenseBar.Name = "expenseBar";
    this.expenseBar.Size = new System.Drawing.Size(200, 23);
    this.expenseBar.TabIndex = 4;
    
    // 
    // balanceLabel
    // 
    this.balanceLabel.Location = new System.Drawing.Point(40, 200);
    this.balanceLabel.Name = "balanceLabel";
    this.balanceLabel.Text = "Balance:";
    this.balanceLabel.Size = new System.Drawing.Size(100, 23);
    this.balanceLabel.TabIndex = 5;
    
    // 
    // balanceBar
    // 
    this.balanceBar.Location = new System.Drawing.Point(150, 200);
    this.balanceBar.Name = "balanceBar";
    this.balanceBar.Size = new System.Drawing.Size(200, 23);
    this.balanceBar.TabIndex = 6;
    
    // 
    // Summary Form Layout
    // 
    this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
    this.ClientSize = new System.Drawing.Size(662, 507);
    
    // CRITICAL: Add the UI elements to the Form's control tree
    this.Controls.Add(this.monthPicker);
    this.Controls.Add(this.incomeLabel);
    this.Controls.Add(this.incomeBar);
    this.Controls.Add(this.expenseLabel);
    this.Controls.Add(this.expenseBar);
    this.Controls.Add(this.balanceLabel);
    this.Controls.Add(this.balanceBar);
    
    this.Name = "Summary";
    this.Text = "Summary Dashboard";
    this.ResumeLayout(false);
    this.PerformLayout();
}

        #endregion

        private System.Windows.Forms.DateTimePicker monthPicker;
        private System.Windows.Forms.Label incomeLabel;
        private System.Windows.Forms.Label expenseLabel;
        private System.Windows.Forms.Label balanceLabel;
        private System.Windows.Forms.ProgressBar incomeBar;
        private System.Windows.Forms.ProgressBar expenseBar;
        private System.Windows.Forms.ProgressBar balanceBar;
    }
}