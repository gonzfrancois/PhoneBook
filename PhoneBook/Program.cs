using System;
using System.Windows.Forms;
using PhoneBook.Form;

namespace PhoneBook
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            if (!SingleInstance.Start())
            {
                var strPtr = Environment.GetCommandLineArgs().Length > 1 ? Environment.GetCommandLineArgs()[1] : string.Empty;
                SingleInstance.ShowFirstInstance(strPtr);
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                Application.Run(new Home(Environment.GetCommandLineArgs()));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            SingleInstance.Stop();
        }
    }
}
