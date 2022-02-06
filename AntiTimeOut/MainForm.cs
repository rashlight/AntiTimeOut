using System;
using System.IO;
using System.Management;
using System.Text;
using System.Windows.Forms;

namespace AntiTimeOut
{
    public enum ServiceError
    {
        THROW_EXCEPTION = -1,
        DO_NOTHING = 0,
        BEEP = 1,
        RESET_WLAN_CONNECTION = 2,
    }

    public partial class MainForm : Form
    {
        public bool ErrorRunOnce = false;
        /// <summary>
        /// The service directory, loaded by MainForm.GetServiceDirectory()
        /// </summary>
        public static string DataFilePath = "";
        public const string SERVICE_NAME = "Anti Time-Out Network Service";

        public void ChangeControl(Control currentControl, Control newControl)
        {
            if (newControl == null)
            {
                throw new ArgumentNullException("Cannot initialize a new control.");
            }
            if (currentControl != null)
            {
                mainPanel.Controls.Remove(currentControl);
                currentControl.Dispose();
            }
            mainPanel.Controls.Add(newControl);
        }
        private void ReportError(string time, bool isRunOnce)
        {
            if (ErrorRunOnce && isRunOnce) return;

            switch (Properties.Settings.Default.serviceErrorAction)
            {
                case (int)ServiceError.THROW_EXCEPTION:
                    throw new Exception("An User-Handled AntiTimeOutService exception has been detected.");
                case (int)ServiceError.BEEP:
                    using (System.Media.SoundPlayer soundPlayer = new System.Media.SoundPlayer(Properties.Settings.Default.ootBeepSFXDir))
                    {
                        try
                        {
                            soundPlayer.Play();
                        }
                        catch
                        {
                            System.Media.SystemSounds.Beep.Play();
                        }
                    }
                    break;
                case (int)ServiceError.RESET_WLAN_CONNECTION:
                    string argsString = "wlan connect name=" + Properties.Settings.Default.ootRenewName +
                            (!string.IsNullOrWhiteSpace(Properties.Settings.Default.ootRenewSSID) ? " ssid=" + Properties.Settings.Default.ootRenewSSID : "") +
                            (!string.IsNullOrWhiteSpace(Properties.Settings.Default.ootRenewInterface) ? " interface=" + Properties.Settings.Default.ootRenewInterface : "");

                    var flush_process = new System.Diagnostics.Process
                    {
                        StartInfo = { FileName = "ipconfig.exe", Arguments = "/flushdns", CreateNoWindow = true, UseShellExecute = false },
                        EnableRaisingEvents = true
                    };

                    var netsh_process = new System.Diagnostics.Process
                    {
                        StartInfo = { FileName = "netsh.exe", Arguments = argsString, CreateNoWindow = true, UseShellExecute = false },
                        EnableRaisingEvents = true
                    };

                    flush_process.Start();
                    netsh_process.Start();

                    break;
                default:
                    break;
            }

            if (isRunOnce) ErrorRunOnce = true;
        }

        private string GetServiceDirectory()
        {
            // We check the default location first
            if (!string.IsNullOrEmpty(Properties.Settings.Default.loadedServiceDirectory))
            {
                DataFilePath = Properties.Settings.Default.loadedServiceDirectory;
            }
            else 
            {
                // Then we use WMI to check the service location (if exist)
                try
                {
                    ManagementObjectSearcher searcher =
                        new ManagementObjectSearcher("root\\CIMV2",
                        "SELECT Name, PathName FROM Win32_Service");

                    foreach (ManagementObject queryObj in searcher.Get())
                    {
                        if ((string)queryObj["Name"] == MainForm.SERVICE_NAME)
                        {
                            // For example, "drive\path_to_file\file.exe" "param1" "param2" will have
                            // index 0: empty string, index 1: drive\path_to_file\file.exe, index 2: param1, etc.
                            // In this case we query the path, so select index 1
                            DataFilePath = Path.GetDirectoryName(queryObj["PathName"].ToString().Split('"')[1]);
                        }
                    }
                }
                catch
                {
                    
                }

                if (string.IsNullOrWhiteSpace(DataFilePath))
                {
                    // If there are none, then give up and use drive\path_to_client\Service
                    DataFilePath = AppDomain.CurrentDomain.BaseDirectory + "\\Service";
                }
            }

            // Then check if service exists
            bool isSkipped = false;
            while (!File.Exists(DataFilePath + "\\AntiTimeOutService.exe"))
            {
                if (isSkipped) break;
                DialogResult dg = MessageBox.Show("There are no AntiTimeOutService available at \"" + DataFilePath + "\\AntiTimeOutService.exe" + "\"\n\n" +
                    "This can happened due to folder migration, wrong file / directory name or no services installed.\n\n" +
                    "Press Abort to quit, Retry to select a service folder, or Ignore to force continue (not recommended).", "AntiTimeOut - Service not found", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                if (dg == DialogResult.Abort) Environment.Exit(1);
                if (dg == DialogResult.Retry)
                {
                    folderBrowserDialog.ShowDialog();
                    DataFilePath = folderBrowserDialog.SelectedPath;
                }
                if (dg == DialogResult.Ignore) 
                { 
                    isSkipped = true;
                    DataFilePath = String.Empty;
                } 
            }

            return DataFilePath;
        }

        public MainForm()
        {
            InitializeComponent();
            if (Properties.Settings.Default.isNVSMode)
            {
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Properties.Settings.Default.loadedServiceDirectory = GetServiceDirectory();
            Properties.Settings.Default.Save();
            try
            {
                fileSystemWatcher.Path = DataFilePath;
            }
            catch
            {
                fileSystemWatcher.Path = string.Empty;
            }
            
            mainPanel.Controls.Add(new MainControl(this));
        }

        private void fileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            string fileStr = "";
            using (FileStream fs = File.Open(DataFilePath + "\\ServiceStatus.log", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                try
                {
                    // Read the file
                    byte[] b = new byte[128];
                    UTF8Encoding temp = new UTF8Encoding(true);
                    while (fs.Read(b, 0, b.Length) > 0)
                    {
                        fileStr += temp.GetString(b);
                    }

                    if (string.IsNullOrWhiteSpace(fileStr)) return;

                    // Check if service status is ERROR
                    string[] data = fileStr.Split(' ');
                    if (Convert.ToBoolean(data[1]))
                    {
                        ReportError(data[0], Properties.Settings.Default.isRunOnceMode);
                    }
                    else ErrorRunOnce = false;
                }
                catch
                {

                }
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized && Properties.Settings.Default.isSystrayMode)
            {
                Hide();
                notifyIcon.Visible = true;
            }
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.ShowInTaskbar = true;
                Show();
                this.WindowState = FormWindowState.Normal;
                notifyIcon.Visible = false;
            }
        }

        private void maximizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreditsForm cf = new CreditsForm();
            cf.Show();
        }
    }
}