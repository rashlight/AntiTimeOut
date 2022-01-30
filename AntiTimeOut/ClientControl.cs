using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace AntiTimeOut
{
    public partial class ClientControl : UserControl
    {
        // TODO: Add the controls to a layout panel
        private readonly Point ootRunOnceCheckBoxDefaultLocation = new Point(86, 211);
        private readonly Point ootRunOnceCheckBoxNewLocation = new Point(36, 211);
        private readonly Point ootSaveButtonDefaultLocation = new Point(181, 207);
        private readonly Point ootSaveButtonNewLocation = new Point(131, 207);

        private MainForm mainForm;
        private OOTBeepConfigForm ootbcf;
        private OOTRenewConfigForm ootrcf;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

        public ClientControl(MainForm main)
        {
            InitializeComponent();
            mainForm = main;

            try
            {
                string logDir = MainForm.DataFilePath;
                clientSettingsWatcher.Path = logDir;
            }
            catch
            {
                clientSettingsWatcher.Path = null;
            }

            // Add UAC shield
            const int BCM_SETSHIELD = 0x160C;
            adminRestartButton.FlatStyle = FlatStyle.System;
            SendMessage(adminRestartButton.Handle, BCM_SETSHIELD, 0, 1);
        }

        private void SetStartup()
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey
                ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (osStartupCheckBox.Checked)
                rk.SetValue(Application.ProductName, Application.ExecutablePath);
            else
                rk.DeleteValue(Application.ProductName, false);
        }
        private bool GetStartup()
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey
                ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            return (string)rk.GetValue(Application.ProductName) == Application.ExecutablePath;
        }
        private bool IsDigitsOnly(string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return false;

            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
        /// <summary>
        /// Updates the ServiceStatus.log infomation to Live Update.
        /// For more information, check the Anti Time-Out Client wiki.
        /// </summary>
        private void UpdateStatus()
        {
            string fileStr = "";
            try 
            {
                using (FileStream fs = File.Open(clientSettingsWatcher.Path + "\\ServiceStatus.log", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    try
                    {
                        byte[] b = new byte[128];
                        UTF8Encoding temp = new UTF8Encoding(true);
                        while (fs.Read(b, 0, b.Length) > 0)
                        {
                            fileStr += temp.GetString(b);
                        }

                        if (string.IsNullOrWhiteSpace(fileStr)) return;

                        string[] data = fileStr.Split(' ');
                        if (data[0] != "OK")
                        {
                            if (Convert.ToBoolean(data[1]))
                            {
                                serviceStatusTextBox.ForeColor = Color.DarkRed;
                                serviceStatusTextBox.Text = "ERROR";
                            }
                            else
                            {
                                serviceStatusTextBox.ForeColor = Color.Olive;
                                serviceStatusTextBox.Text = "WARNING";
                            }
                        }
                        else
                        {
                            serviceStatusTextBox.ForeColor = Color.ForestGreen;
                            serviceStatusTextBox.Text = "OK";
                        }

                        lastRecordTextBox.Text = "Last Recorded: " + data[2] + " " + data[3] + " " + data[4];
                    }
                    catch
                    {
                        serviceStatusTextBox.ForeColor = Color.DarkSlateGray;
                        serviceStatusTextBox.Text = "ERROR";
                        lastRecordTextBox.Text = "Last Recorded: Can't parse status file";
                    }
                }
            }
            catch
            {
                serviceStatusTextBox.ForeColor = Color.DarkSlateGray;
                serviceStatusTextBox.Text = "NO DATA";
                lastRecordTextBox.Text = "Last Recorded: Can't access / read status file";
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            mainForm.ChangeControl(this, new MainControl(mainForm));
        }
        private void ClientControl_Load(object sender, EventArgs e)
        {
            foreach (string action in Enum.GetNames(typeof(ServiceError)))
            {
                ootComboBox.Items.Add(action);
            }

            versionTextBox.Text = "Version " + System.Reflection.Assembly.GetEntryAssembly().GetName().Version +
                                  ", Windows " + (Environment.Is64BitOperatingSystem ? "64" : "32") + "bit" + 
                                  ", .NET " + AppDomain.CurrentDomain.SetupInformation.TargetFrameworkName.Replace(".NETFramework,Version=", "");

            UpdateStatus();

            ootRunOnceCheckBox.Checked = Properties.Settings.Default.isRunOnceMode;
            systrayCheckBox.Checked = Properties.Settings.Default.isSystrayMode;
            ootComboBox.SelectedIndex = Properties.Settings.Default.ootSelectedModeIndex;

            syncServerConfigCheckBox.Checked = Properties.Settings.Default.isServerUpdateSync;
            if (Properties.Settings.Default.isServerUpdateSync)
            {
                saiTextBox.Enabled = false;
                string updateTime = "1000";
                try
                {
                    // Get the service interval
                    updateTime = File.ReadAllText(MainForm.DataFilePath + "\\ServiceConfig.cfg").Split(' ')[0];
                }
                catch
                {
                }
                saiTextBox.Text = updateTime;
            }

            osStartupCheckBox.Checked = GetStartup();
            sbsModeCheckBox.Checked = Properties.Settings.Default.isSBSMode;
            nvsModeCheckBox.Checked = Properties.Settings.Default.isNVSMode;
            systrayCheckBox.Checked = Properties.Settings.Default.isSystrayMode;
            systrayCheckBox.Enabled = !nvsModeCheckBox.Checked;
        }
        private void ootSaveButton_Click(object sender, EventArgs e)
        {
            if (ootComboBox.SelectedIndex < 0)
            {
                MessageBox.Show("Choose an Out-Of-Time action to continue...", "AntiTimeOut", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            bool convResult = Enum.TryParse(ootComboBox.GetItemText(ootComboBox.SelectedItem), out ServiceError result);
            if (!convResult)
            {
                MessageBox.Show("Can't parse this Out-Of-Time action.\nCheck your selection and try again.", "AntiTimeOut", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Properties.Settings.Default.serviceErrorAction = (int)result;
            Properties.Settings.Default.Save();

            switch (result)
            {
                case ServiceError.DO_NOTHING:
                    break;
                case ServiceError.BEEP:
                    if (ootbcf == null || ootbcf.DialogResult != DialogResult.OK)
                    {
                        MessageBox.Show("Parameters not set! Go to \"Settings...\" button to set options.", "AntiTimeOut", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    break;
                case ServiceError.RESET_WLAN_CONNECTION:
                    if (ootrcf == null || ootrcf.DialogResult != DialogResult.OK)
                    {
                        MessageBox.Show("Parameters not set! Go to \"Settings...\" button to set options.", "AntiTimeOut", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    break;
                case ServiceError.THROW_EXCEPTION:
                    break;
                default: break;
            }

            try
            {
                Properties.Settings.Default.ootSelectedModeIndex = ootComboBox.SelectedIndex;
                Properties.Settings.Default.isRunOnceMode = ootRunOnceCheckBox.Checked;
                MessageBox.Show("Saved successfully.", "AntiTimeOut", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exp)
            {
                Properties.Settings.Default.ootSelectedModeIndex = 0;
                Properties.Settings.Default.isRunOnceMode = true;
                MessageBox.Show("An unexpected exception has been detected: " + exp.ToString() + "Saving default fallback action to " + Enum.GetName(typeof(ServiceError), 0), "AntiTimeOut", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Properties.Settings.Default.Save();
            }
        }
        private void clientSettingsWatcher_Changed(object sender, System.IO.FileSystemEventArgs e)
        {
            UpdateStatus();
        }
        private void saiSaveButton_Click(object sender, EventArgs e)
        {
            if (!IsDigitsOnly(saiTextBox.Text) || string.IsNullOrWhiteSpace(saiTextBox.Text))
            {
                MessageBox.Show("Interval is in incorrect format!", "AntiTimeOut", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Convert.ToInt32(saiTextBox.Text) <= 0)
            {
                MessageBox.Show("\"Service Availibility Interval\" value is not in range! (1 -> " + int.MaxValue + ")", "AntiTimeOut", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Properties.Settings.Default.servicePollingTime = Convert.ToInt32(saiTextBox.Text);
            Properties.Settings.Default.Save();
            MessageBox.Show("Saved successfully.", "AntiTimeOut", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void authorLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/rashlight/");
        }
        private void osStartupCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SetStartup();
        }
        private void systrayCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isSystrayMode = systrayCheckBox.Checked;
            Properties.Settings.Default.Save();
        }
        private void adminRestartButton_Click(object sender, EventArgs e)
        {
            var process = new System.Diagnostics.Process
            {
                StartInfo = { FileName = Application.ExecutablePath, Arguments = "", Verb = "runas" },
                EnableRaisingEvents = true
            };

            try
            {
                process.Start();
                mainForm.Close();
            }
            catch (System.ComponentModel.Win32Exception)
            {
                MessageBox.Show("Can't start process as Administrator.\nCheck your privileges and try again.", "AntiTimeOut", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }           
        }
        private void ootComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Enum.TryParse((string)ootComboBox.SelectedItem, out ServiceError result)) throw new NullReferenceException("There is no reference to the action provided.");
            
            if (result == ServiceError.THROW_EXCEPTION)
            {
                ootRunOnceCheckBox.Checked = true;
                ootRunOnceCheckBox.Enabled = false;
            }
            else
            {
                ootRunOnceCheckBox.Enabled = true;
            }

            if (result == ServiceError.BEEP || result == ServiceError.RESET_WLAN_CONNECTION)
            {
                ootSaveButton.Location = ootSaveButtonNewLocation;
                ootRunOnceCheckBox.Location = ootRunOnceCheckBoxNewLocation;
                ootSettingsButton.Visible = true;
            }
            else
            {
                ootSaveButton.Location = ootSaveButtonDefaultLocation;
                ootRunOnceCheckBox.Location = ootRunOnceCheckBoxDefaultLocation;
                ootSettingsButton.Visible = false;
            }
        }
        private void ootSettingsButton_Click(object sender, EventArgs e)
        {
            if (!Enum.TryParse((string)ootComboBox.SelectedItem, out ServiceError result))
            {
                MessageBox.Show("Cannot parse regulated Out-Of-Time setting", "AntiTimeOut", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            switch (result) 
            {
                case ServiceError.BEEP:
                    {
                        ootbcf = new OOTBeepConfigForm();
                        ootbcf.ShowDialog();                        
                        break;
                    }
                case ServiceError.RESET_WLAN_CONNECTION:
                    {
                        ootrcf = new OOTRenewConfigForm();
                        ootrcf.ShowDialog();
                        break;
                    }
                default: throw new AccessViolationException("This Out-Of-Time setting is not available.");
            }
        }
        private void nvsModeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isNVSMode = nvsModeCheckBox.Checked;
            Properties.Settings.Default.Save();
            systrayCheckBox.Checked = nvsModeCheckBox.Checked;
            systrayCheckBox.Enabled = !nvsModeCheckBox.Checked;
        }
        private void sbsModeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isSBSMode = sbsModeCheckBox.Checked;
            Properties.Settings.Default.Save();
        }
        private void clearServiceLogButton_Click(object sender, EventArgs e)
        {
            bool isExists = File.Exists(MainForm.DataFilePath + "\\install.log");

            if (!isExists)
            {
                MessageBox.Show(
                    "There are no install.log at\n" + MainForm.DataFilePath + "\n" +
                    "Check this later when service regenerate the file or delete it manually.",
                    "AntiTimeOut", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string message = "This action will delete the installation log file at\n" + MainForm.DataFilePath + "\\install.log" +
                "\n\nThe file is used for error purposes, but can affect service setup time. " +
                "\n\nAre you sure to do this?";

            DialogResult dg = MessageBox.Show(message, "AntiTimeOut", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dg == DialogResult.OK)
            {
                try
                {
                    File.Delete(MainForm.DataFilePath + "\\install.log");
                }
                catch (Exception exp)
                {
                    MessageBox.Show("This operation has caused an exeption:\n" + exp.Source + ": " + exp.Message, "AntiTimeOut", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Installation log deleted successfully.", "AntiTimeOut", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void showDefServiceButton_Click(object sender, EventArgs e)
        {
            string assemblyPath = MainForm.DataFilePath + "\\AntiTimeOutService.exe";
            bool isServiceExists = File.Exists(assemblyPath);
            string version = isServiceExists ? FileVersionInfo.GetVersionInfo(assemblyPath).FileVersion : "Unknown";
            bool isSpecial = isServiceExists ? FileVersionInfo.GetVersionInfo(assemblyPath).IsSpecialBuild : false;
            bool isConfigExists = File.Exists(MainForm.DataFilePath + "\\ServiceConfig.cfg");
            string cfgContent = isConfigExists ? File.ReadAllText(MainForm.DataFilePath + "\\ServiceConfig.cfg") : "Unknown";

            string message = "Location: " + MainForm.DataFilePath + "\n" +
                "Service exists: " + isServiceExists.ToString() + "\n" +
                "Version: " + version + "\n" +
                "Special build: " + isSpecial.ToString() + "\n" +
                "Configuration file exists: " + isConfigExists.ToString() + "\n" +
                "Configuration contents: " + cfgContent;
            MessageBox.Show(message, "AntiTimeOut", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void deleteInstallStateButton_Click(object sender, EventArgs e)
        {
            bool isExists = File.Exists(MainForm.DataFilePath + "\\AntiTimeOutService.InstallState");

            if (!isExists)
            {
                MessageBox.Show(
                    "There are no InstallState file at\n" + MainForm.DataFilePath + "\n" +
                    "Check this later when service regenerate the file or delete it manually.",
                    "AntiTimeOut", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string message = "This action will delete the InstallState file at\n" + MainForm.DataFilePath + "\\AntiTimeOutService.InstallState" +
                "\n\nUsually, an InstallState file supports the uninstallation of AntiTimeOutService, however " +
                "if there are errors (mainly in service upgrades), it is first recommended to delete this file." +
                "\n\nAre you sure to do this?";

            DialogResult dg = MessageBox.Show(message, "AntiTimeOut", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dg == DialogResult.OK)
            {
                try
                {
                    File.Delete(MainForm.DataFilePath + "\\AntiTimeOutService.InstallState");
                }
                catch (Exception exp)
                {
                    MessageBox.Show("This operation has caused an exeption:\n" + exp.Source + ": " + exp.Message, "AntiTimeOut", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("InstallState deleted successfully.", "AntiTimeOut", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void resetConfigButton_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Do you want to reset all client configs?\nTHIS ACTION IS IRREVERSIBLE AND REQUIRE A RESTART!", "AntiTimeOut", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dg == DialogResult.OK)
            {
                dg = MessageBox.Show("Do you want to reset all client configs (AGAIN?)\nTHIS ACTION IS IRREVERSIBLE AND REQUIRE A RESTART!", "AntiTimeOut", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dg == DialogResult.OK)
                {
                    Properties.Settings.Default.Reset();
                    Application.Restart();
                }
            }
        }
        private void syncServerConfigCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            saiTextBox.Enabled = !syncServerConfigCheckBox.Checked;
            if (syncServerConfigCheckBox.Checked)
            {
                string updateTime = "1000";
                try
                {
                    // Get the service interval
                    updateTime = File.ReadAllText(MainForm.DataFilePath + "\\ServiceConfig.cfg").Split(' ')[0];
                }
                catch
                {
                }
                saiTextBox.Text = updateTime;
            }
            else
            {
                saiTextBox.Text = "1000";
            }
        }
    }
}