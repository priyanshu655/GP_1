using System;
using System.Windows.Forms;
using LoginPage;
using MoneyMap.Authentication;
using MoneyMap.Main;

namespace MoneyMap
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Check if there is an active saved session (< 2 hours old)
            var activeSession = SessionManager.GetActiveSession();

            if (activeSession != null)
            {
                // Auto-login: Open MainForm directly without prompting for login
                MainForm mainForm = new MainForm(activeSession.UserId);
                Application.Run(mainForm);

                // If user logged out or session expired, show Login screen
                if (mainForm.LoggedOut)
                {
                    Application.Run(new Login());
                }
            }
            else
            {
                Application.Run(new Login());
            }
        }
    }
}