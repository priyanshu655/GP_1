using System;
using System.Windows.Forms;

namespace MoneyMap.Main
{
    public partial class MainForm : Form
    {
        private readonly int userId;

        public MainForm(int userId)
        {
            InitializeComponent();

            this.userId = userId;
        }
    }
}