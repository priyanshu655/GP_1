using System;
using System.Windows.Forms;
using LoginPage;

namespace MoneyMap
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            Application.Run(new Login());
        }
    }
}
