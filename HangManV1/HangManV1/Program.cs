using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HangManV1
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());

            do
            {
                if (LoginForm.UserSuccessfullyAuthenticated)
                {
                    Application.Run(new HangManFormV1());
                }
                if (!LoginForm.UserSuccessfullyAuthenticated)
                {
                    Application.Run(new LoginForm());
                }
            } while ((HangManFormV1.gameRunning));
        }
    }
}
