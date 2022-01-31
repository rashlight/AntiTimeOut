using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AntiTimeOut
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool isOpenForm = true;
            Mutex mutex = new Mutex();

            if (!Properties.Settings.Default.isSBSMode)
            {
                mutex = new Mutex(true, Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetExecutingAssembly().Location), out isOpenForm);
            }

            if (isOpenForm)
            {
                if (Environment.OSVersion.Version.Major <= 6)
                {
                    SetProcessDPIAware();
                }
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
            else
            {
                Process current = Process.GetCurrentProcess();
                foreach (Process process in Process.GetProcessesByName(current.ProcessName))
                {
                    if (process.Id != current.Id)
                    {
                        int SW_RESTORE = 9;
                        ShowWindow(process.MainWindowHandle, SW_RESTORE);
                        SetForegroundWindow(process.MainWindowHandle);
                        break;
                    }
                }
                MessageBox.Show("Only one instance of AntiTimeOut can be opened. This instance will now exit.",
                    "AntiTimeOut - Different Instance", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            mutex.Dispose();
        }

        [DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);
    }
}
