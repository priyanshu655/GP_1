using System;
using System.Windows.Forms;
using SignupPage;

namespace MoneyMap
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            Application.Run(new Form1());
        }
    }
}