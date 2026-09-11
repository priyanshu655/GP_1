using System;
using System.Windows.Forms;

namespace GP_1
{
    public partial class View : Form
    {

        public View()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void OpenChild(Form child)
        {
            foreach (Form openChild in MdiChildren)
            {
                openChild.Close();
            }

            child.MdiParent = this;
            child.FormBorderStyle = FormBorderStyle.None;
            child.ControlBox = false;
            child.WindowState = FormWindowState.Normal;
            child.TopLevel      = false;
            child.Dock          = DockStyle.Fill;
            child.BringToFront();
            child.Show();
        }

        private void ShowAllToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            OpenChild(new ShowAll());
        }

        private void ShowIncomeToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            OpenChild(new ShowIncome());
        }

        private void ShowExpenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChild(new ShowExpense());
        }

        private void SummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChild(new Summary());
        }

        private void GraphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChild(new GraphView());
        }
    }
}
