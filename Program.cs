using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NTCSAttendanceKiosk
{
    static class Program
    {
        // Unmanaged code to set the foreground window
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        public static Process PriorProcess()
        {
            // Returns a System.Diagnostics.Process pointing to
            // a pre-existing process with the same name as the
            // current one, if any; or null if the current process
            // is unique.
            // Source: https://stackoverflow.com/a/6416663/12946280
            Process curr = Process.GetCurrentProcess();
            Process[] procs = Process.GetProcessesByName(curr.ProcessName);
            foreach (Process p in procs)
            {
                if ((p.Id != curr.Id) &&
                    (p.MainModule.FileName == curr.MainModule.FileName))
                    return p;
            }
            return null;
        }


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Check if another instance of the app is running and exit if it is
            if (PriorProcess() != null)
            {
                Process current = Process.GetCurrentProcess();
                foreach (Process process in Process.GetProcessesByName(current.ProcessName))
                {
                    if (process.Id != current.Id)
                    {
                        SetForegroundWindow(process.MainWindowHandle);
                        break;
                    }
                }
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

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
                MessageBox.Show("The file location.txt does not exist. Please place the kiosk location name in that file and place it in <your user folder>\\kiosk_config\\. The kiosk program will now exit.", "Connection String File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
