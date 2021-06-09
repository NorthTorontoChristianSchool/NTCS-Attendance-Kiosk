using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace NTCSAttendanceKiosk
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Make a mutex and detect if another instance of the program is running
            Mutex mutex = new Mutex(true, "AtteNTCSKioskMutex", out bool mutexResult);

            if (!mutexResult)
            {
                // Exit if it's already running
                return;
            }

            // Prevent the mutex from being released by the GC
            GC.KeepAlive(mutex);

            // Read the connection string from the file
            try
            {
                SqlConnectionInfo.ConnectionString = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\kiosk_config\\connection_string.txt");
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("The file connection_string.txt does not exist. Please place the connection string in that file and place it in <your user folder>\\kiosk_config\\. The kiosk program will now exit.", "Connection String File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (IOException)
            {
                MessageBox.Show("File I/O error when loading connection_string.txt. The kiosk program will now exit.", "File I/O Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Read the kiosk location name from the file
            try
            {
                SqlConnectionInfo.KioskLocation = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\kiosk_config\\location.txt");
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("The file location.txt does not exist. Please place the connection string in that file and place it in <your user folder>\\kiosk_config\\. The kiosk program will now exit.", "Connection String File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (IOException)
            {
                MessageBox.Show("File I/O error when loading location.txt. The kiosk program will now exit.", "File I/O Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Application.Run(new KioskForm());
        }
    }
}
