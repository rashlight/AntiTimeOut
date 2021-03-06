using System;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceProcess;
using System.IO;
using System.Diagnostics;
using System.Security.Principal;

namespace AntiTimeOut
{
    public enum LimitAction
    {
        THROW_EXCEPTION = -1,
        DO_NOTHING = 0,
        WRITE_WARNING_LOG_ENDLESS = 1,
        WRITE_WARNING_LOG_ONCE = 2,
    }

    public enum CommandAction
    {
        CONNECTION_TEST = 128,
        ERASE_EVENTLOGS = 129,
        CHANGE_LOGLVL_NONE = 130,
        CHANGE_LOGLVL_CONSERVATIVE = 131,
        CHANGE_LOGLVL_NORMAL = 132,
        CHANGE_LOGLVL_VERBOSE = 133,
    }

    public partial class ServiceControl : UserControl
    {
        MainForm mainForm;
        /// <summary>
        /// A variable to tell if an action is in progress
        /// </summary>
        private bool isInProgress = false;

        private const int OVER_INTERVAL = 3600000;
        private const int OVER_TIMEOUT = 3600000;
        private const int OVER_FAILURE_LIMIT = 60;
        private const int OVER_CMD_TIMEOUT = 3600000;

        private Task<int> RunProcessAsync(string fileName, string arguments)
        {
            var tcs = new TaskCompletionSource<int>();

            var process = new Process
            {
                StartInfo = { FileName = fileName, Arguments = arguments, Verb = "runas" },
                EnableRaisingEvents = true
            };

            process.Exited += (sender, args) =>
            {
                tcs.SetResult(process.ExitCode);
                process.Dispose();
            };

            try
            {
                process.Start();
            }
            catch (Exception exp)
            {
                MessageBox.Show("Process failed to start: " + exp.Message, "AntiTimeOut", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return Task.FromResult(0x4C7); //ERROR_CANCELLED
            }         

            return tcs.Task;
        }

        public ServiceControl(MainForm main)
        {
            InitializeComponent();
            mainForm = main;
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
        private void UpdateClientStatus()
        {
            if (ServiceExists(MainForm.SERVICE_NAME))
            {
                switch (GetServiceStatus(MainForm.SERVICE_NAME))
                {
                    case ServiceControllerStatus.Running:
                        {
                            serviceStatusTextBox.ForeColor = Color.ForestGreen;
                            serviceStatusTextBox.Text = "SERVICE STATUS: ONLINE";
                            break;
                        }
                    case ServiceControllerStatus.Paused:
                        {
                            serviceStatusTextBox.ForeColor = Color.MidnightBlue;
                            serviceStatusTextBox.Text = "SERVICE STATUS: PAUSED";
                            break;
                        }
                    case ServiceControllerStatus.Stopped:
                        {
                            serviceStatusTextBox.ForeColor = Color.DarkRed;
                            serviceStatusTextBox.Text = "SERVICE STATUS: OFFLINE";
                            break;
                        }
                    case ServiceControllerStatus.StartPending:
                        {
                            serviceStatusTextBox.ForeColor = Color.Olive;
                            serviceStatusTextBox.Text = "SERVICE STATUS: STARTING...";
                            break;
                        }
                    case ServiceControllerStatus.PausePending:
                        {
                            serviceStatusTextBox.ForeColor = Color.Olive;
                            serviceStatusTextBox.Text = "SERVICE STATUS: PAUSING...";
                            break;
                        }
                    case ServiceControllerStatus.StopPending:
                        {
                            serviceStatusTextBox.ForeColor = Color.Olive;
                            serviceStatusTextBox.Text = "SERVICE STATUS: STOPPING...";
                            break;
                        }
                    case ServiceControllerStatus.ContinuePending:
                        {
                            serviceStatusTextBox.ForeColor = Color.Olive;
                            serviceStatusTextBox.Text = "SERVICE STATUS: WAKING...";
                            break;
                        }
                    default: break;
                }
            }
            else
            {
                serviceStatusTextBox.ForeColor = Color.DarkSlateGray;
                serviceStatusTextBox.Text = "SERVICE STATUS: UNAVAILABLE";
                
            }
        }
        private void UpdateServiceAvailability()
        {
            if (!ServiceExists(MainForm.SERVICE_NAME))
            {
                serviceAvailTextBox.ForeColor = Color.DarkRed;
                serviceAvailTextBox.Text = "Service is NOT INSTALLED.";
                if (!isInProgress)
                {
                    installButton.Enabled = true;
                    uninstallButton.Enabled = false;
                }
            }
            else
            {
                serviceAvailTextBox.ForeColor = Color.ForestGreen;
                serviceAvailTextBox.Text = "Service is INSTALLED.";
                if (!isInProgress)
                {
                    installButton.Enabled = false;
                    uninstallButton.Enabled = true;
                }
            }
        }
        private void UpdateServiceParameters()
        {
            try
            {
                string[] parameters = File.ReadAllText(MainForm.DataFilePath + "\\ServiceConfig.cfg").Split(' ');
                intervalTextBox.Text = parameters[0];
                timeOutTextBox.Text = parameters[1];
                urlTextBox.Text = parameters[2];
                failureLimitTextBox.Text = parameters[3];
                failModeComboBox.SelectedIndex = 0;
                for (int i = 0; i < failModeComboBox.Items.Count; i++)
                {
                    if (parameters[4].ToString() == failModeComboBox.Items[i].ToString())
                    {
                        failModeComboBox.SelectedIndex = i;
                        break;
                    }
                }
            }
            catch
            {
            }
        }

        public bool ServiceExists(string ServiceName)
        {
            return ServiceController.GetServices().Any(serviceController => serviceController.ServiceName.Equals(ServiceName));
        }
        public bool IsServiceRunning(string ServiceName)
        {
            ServiceController sc = new ServiceController();
            sc.ServiceName = ServiceName;

            if (sc.Status == ServiceControllerStatus.Running)
            {
                sc.Dispose();
                return true;
            }
            else
            {
                sc.Dispose();
                return false;
            }
        }
        public bool IsServicePaused(string ServiceName)
        {
            ServiceController sc = new ServiceController();
            sc.ServiceName = ServiceName;

            if (sc.Status == ServiceControllerStatus.Paused)
            {
                sc.Dispose();
                return true;
            }
            else
            {
                sc.Dispose();
                return false;
            }
        }
        public void StartService(string ServiceName)
        {          
            ServiceController sc = new ServiceController();
            sc.ServiceName = ServiceName;

            if (sc.Status != ServiceControllerStatus.Running && sc.Status != ServiceControllerStatus.Paused)
            {
                try
                {
                    sc.Start();
                    sc.WaitForStatus(ServiceControllerStatus.Running);
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Source + ": " + exp.InnerException.Message + "\nCheck your privileges and try again.", "AntiTimeOut", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (sc.Status == ServiceControllerStatus.Paused) MessageBox.Show("Can't start action while paused, use \"Continue\" button instead.", "AntiTimeOut", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else MessageBox.Show("Service already started or doesn't exists.", "AntiTimeOut", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            sc.Dispose();
        }
        public void StopService(string ServiceName)
        {
            ServiceController sc = new ServiceController();
            sc.ServiceName = ServiceName;

            if (sc.Status != ServiceControllerStatus.Stopped)
            {
                try
                {
                    // Stop the service, and wait until its status is "Stopped".
                    sc.Stop();
                    sc.WaitForStatus(ServiceControllerStatus.Stopped);                                   
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Source + ": " + exp.InnerException.Message + "\nCheck your privileges and try again.", "AntiTimeOut", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Service is already stopped or doesn't exists.", "AntiTimeOut", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            sc.Dispose();
        }
        public void PauseService(string ServiceName)
        {
            ServiceController sc = new ServiceController();
            sc.ServiceName = ServiceName;

            if (sc.Status != ServiceControllerStatus.Paused && sc.Status != ServiceControllerStatus.Stopped)
            {
                try
                {
                    // Pause the service, and wait until its status is "Paused".
                    sc.Pause();
                    sc.WaitForStatus(ServiceControllerStatus.Paused);
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Source + ": " + exp.InnerException.Message + "\nCheck your privileges and try again.", "AntiTimeOut", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Service is already paused, stopped or doesn't exists.", "AntiTimeOut", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            sc.Dispose();
        }
        public void ContinueService(string ServiceName)
        {
            ServiceController sc = new ServiceController();
            sc.ServiceName = ServiceName;

            if (sc.Status != ServiceControllerStatus.ContinuePending && sc.Status == ServiceControllerStatus.Paused)
            {
                try
                {
                    // Continue the service, and wait until its status is "Running".
                    sc.Continue();
                    sc.WaitForStatus(ServiceControllerStatus.Running);
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Source + ": " + exp.InnerException.Message + "\nCheck your privileges and try again.", "AntiTimeOut", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Service is running, stopped or doesn't exists.", "AntiTimeOut", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            sc.Dispose();
        }
        public ServiceControllerStatus GetServiceStatus(string ServiceName)
        {
            ServiceController sc = new ServiceController();
            sc.ServiceName = ServiceName;

            ServiceControllerStatus scs = sc.Status;
            sc.Dispose();

            return scs;
        }

        private void ServiceControl_Load(object sender, EventArgs e)
        {
            try
            {
                if (Properties.Settings.Default.isServerUpdateSync)
                {
                    // Get the service interval
                    statusTimer.Interval = Convert.ToInt32(File.ReadAllText(MainForm.DataFilePath + "\\ServiceConfig.cfg").Split(' ')[0]);
                }
                else statusTimer.Interval = Properties.Settings.Default.servicePollingTime;
            }
            catch
            {
                Properties.Settings.Default.servicePollingTime = 1000;
            }

            foreach (string action in Enum.GetNames(typeof(CommandAction)))
            {
                commandComboBox.Items.Add(action);
            }
            foreach (string action in Enum.GetNames(typeof(LimitAction)))
            {
                failModeComboBox.Items.Add(action);
            }

            if (!WindowsIdentity.GetCurrent().Owner.IsWellKnown(WellKnownSidType.BuiltinAdministratorsSid))
            {
                adminBlockPanel.Visible = true;
            }

            UpdateClientStatus();
            UpdateServiceAvailability();

            // Update installation buttons
            if (!ServiceExists(MainForm.SERVICE_NAME))
            {
                uninstallButton.Enabled = false;
            }
            else
            {
                installButton.Enabled = false;
            }

            // Update command boxes
            commandComboBox.SelectedIndex = Properties.Settings.Default.commandSelectedIndex;
            commandTimeOutTextBox.Text = Properties.Settings.Default.commandDelay.ToString();

            UpdateServiceParameters();
        }
        private void statusTimer_Tick(object sender, EventArgs e)
        {
            UpdateClientStatus();
            UpdateServiceAvailability();
        }
        private void backButton_Click(object sender, EventArgs e)
        {
            mainForm.ChangeControl(this, new MainControl(mainForm));
        }
        private async void installButton_Click(object sender, EventArgs e)
        {
            isInProgress = true;
            backButton.Enabled = false;
            installButton.Enabled = false;
            tabControl.Enabled = false;

            installButton.Text = "Please wait...";

            if (File.Exists(MainForm.DataFilePath + "\\AntiTimeOutService.exe"))
            {
                openFileDialog.InitialDirectory = MainForm.DataFilePath;
            }
            DialogResult dg = openFileDialog.ShowDialog();
            if (dg != DialogResult.OK)
            {
                installButton.Text = "Install";
                tabControl.Enabled = true;
                backButton.Enabled = true;
                isInProgress = false;
                return;
            }

            if (Process.GetProcessesByName("mmc").Length > 0)
            {
                dg = MessageBox.Show("In order to complete this installation, Microsoft Management Console must be terminated." +
                "\nClick \"OK\" to terminate ALL mmc.exe processes and continue, or \"Cancel\" to exit.", "AntiTimeOut", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (dg != DialogResult.OK)
                {
                    installButton.Text = "Install";
                    tabControl.Enabled = true;
                    backButton.Enabled = true;
                    isInProgress = false;
                    return;
                }

                foreach (Process proc in Process.GetProcessesByName("mmc"))
                {
                    proc.Kill();
                }
            }
            
            int result = await RunProcessAsync(openFileDialog.FileName, "-i");
            tabControl.Enabled = true;
            if (result == 0 && ServiceExists(MainForm.SERVICE_NAME))
            {
                MessageBox.Show("Service installed successfully.", "AntiTimeOut", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Register new directory forcefully
                Properties.Settings.Default.loadedServiceDirectory = Path.GetDirectoryName(openFileDialog.FileName);
                Properties.Settings.Default.Save();
                MainForm.DataFilePath = Properties.Settings.Default.loadedServiceDirectory;
                uninstallButton.Enabled = true;
            }
            else
            {
                MessageBox.Show("Installation failed, error code " + result + "\nCheck the service installation log for more information.", "AntiTimeOut", MessageBoxButtons.OK, MessageBoxIcon.Error);
                installButton.Enabled = true;
            }

            UpdateServiceAvailability();

            installButton.Text = "Install";
            backButton.Enabled = true;
            isInProgress = false;
        }
        private async void uninstallButton_Click(object sender, EventArgs e)
        {
            isInProgress = true;
            backButton.Enabled = false;
            uninstallButton.Enabled = false;
            tabControl.Enabled = false;

            uninstallButton.Text = "Please wait...";

            if (MessageBox.Show("Are you sure to uninstall AntiTimeOutService?\n", "AntiTimeOut", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
            {
                backButton.Enabled = true;
                tabControl.Enabled = true;
                isInProgress = false;
                return;
            }

            string dir = string.Empty;

            if (!File.Exists(MainForm.DataFilePath + "\\AntiTimeOutService.exe"))
            {
                DialogResult dg = MessageBox.Show("Can't execute " + MainForm.DataFilePath + "\\AntiTimeOutService.exe" +
                    "\nDo you want to specify location of AntiTimeOutService.exe?", "AntiTimeOut", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dg != DialogResult.Yes || openFileDialog.ShowDialog() != DialogResult.OK)
                {                    
                    uninstallButton.Text = "Uninstall";
                    backButton.Enabled = true;
                    tabControl.Enabled = true;
                    isInProgress = false;
                    return;
                }

                dir = openFileDialog.FileName;

                // Register new directory forcefully
                Properties.Settings.Default.loadedServiceDirectory = Path.GetDirectoryName(openFileDialog.FileName);
                Properties.Settings.Default.Save();
            }
            else
            {
                dir = MainForm.DataFilePath + "\\AntiTimeOutService.exe";
            }

            if (Process.GetProcessesByName("mmc").Length > 0)
            {
                DialogResult dg = MessageBox.Show("In order to complete this uninstallation, Microsoft Management Console must be terminated." +
                "\nClick \"OK\" to TERMINATE ALL mmc.exe processes and continue, or \"Cancel\" to exit.", "AntiTimeOut", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (dg != DialogResult.OK)
                {
                    uninstallButton.Text = "Uninstall";
                    backButton.Enabled = true;
                    tabControl.Enabled = true;
                    isInProgress = false;
                    return;
                }

                foreach (Process proc in Process.GetProcessesByName("mmc"))
                {
                    proc.Kill();
                }
            }

            int result = await RunProcessAsync(dir, "-u");
            tabControl.Enabled = true;
            if (result == 0 && !ServiceExists(MainForm.SERVICE_NAME))
            {
                MessageBox.Show("Service uninstalled successfully.", "AntiTimeOut", MessageBoxButtons.OK, MessageBoxIcon.Information);
                installButton.Enabled = true;
            }
            else
            {
                MessageBox.Show("Uninstallation failed, error code " + result + "\nCheck the service installation log for more information.", "AntiTimeOut", MessageBoxButtons.OK, MessageBoxIcon.Error);
                uninstallButton.Enabled = true;
            }

            UpdateServiceAvailability();

            uninstallButton.Text = "Uninstall";
            backButton.Enabled = true;
            isInProgress = false;
        }
        private void serviceAppLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("services.msc");
        }
        private async void startServiceButton_Click(object sender, EventArgs e)
        {
            tabControl.Enabled = false;
            backButton.Enabled = false;

            startServiceButton.Text = "WAIT";

            await Task.Run(() =>
            {
                if (ServiceExists(MainForm.SERVICE_NAME))
                {
                    StartService(MainForm.SERVICE_NAME);
                }
                else
                {
                    MessageBox.Show("This operation is unavailable.\nPlease check your service's installation and try again.", "AntiTimeOut", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            });

            startServiceButton.Text = "Start";

            backButton.Enabled = true;
            tabControl.Enabled = true;
        }
        private async void stopServiceButton_Click(object sender, EventArgs e)
        {
            tabControl.Enabled = false;
            backButton.Enabled = false;

            stopServiceButton.Text = "WAIT";

            await Task.Run(() =>
            {
                if (ServiceExists(MainForm.SERVICE_NAME))
                {
                    StopService(MainForm.SERVICE_NAME);
                }
                else
                {
                    MessageBox.Show("This operation is unavailable.\nPlease check your service's installation and try again.", "AntiTimeOut", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            });

            stopServiceButton.Text = "Stop";

            backButton.Enabled = true;
            tabControl.Enabled = true;
        }
        private async void pauseServiceButton_Click(object sender, EventArgs e)
        {
            tabControl.Enabled = false;
            backButton.Enabled = false;

            pauseServiceButton.Text = "WAIT";

            await Task.Run(() =>
            {
                if (ServiceExists(MainForm.SERVICE_NAME))
                {
                    PauseService(MainForm.SERVICE_NAME);
                }
                else
                {
                    MessageBox.Show("This operation is unavailable.\nPlease check your service's installation and try again.", "AntiTimeOut", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            });

            pauseServiceButton.Text = "Pause";

            backButton.Enabled = true;
            tabControl.Enabled = true;
        }
        private async void continueServiceButton_Click(object sender, EventArgs e)
        {
            tabControl.Enabled = false;
            backButton.Enabled = false;

            continueServiceButton.Text = "WAIT";

            await Task.Run(() =>
            {
                if (ServiceExists(MainForm.SERVICE_NAME))
                {
                    ContinueService(MainForm.SERVICE_NAME);
                }
                else
                {
                    MessageBox.Show("This operation is unavailable.\nPlease check your service's installation and try again.", "AntiTimeOut", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            });

            continueServiceButton.Text = "Continue";

            backButton.Enabled = true;
            tabControl.Enabled = true;
        }
        private void skipAdminButton_Click(object sender, EventArgs e)
        {
            adminBlockPanel.Visible = false;
        }
        private async void sendButton_Click(object sender, EventArgs e)
        {
            int timeOut = 0;
            int index = commandComboBox.SelectedIndex;

            if (index < 0)
            {
                MessageBox.Show("Choose a command to continue...", "AntiTimeOut", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!IsDigitsOnly(commandTimeOutTextBox.Text))
            {
                MessageBox.Show("Your timeout is in incorrect format!", "AntiTimeOut", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                timeOut = Convert.ToInt32(commandTimeOutTextBox.Text);
                if (timeOut <= 0) throw new ArgumentOutOfRangeException("The timeout cannot be smaller or equals to 0.");
                if (timeOut >= OVER_CMD_TIMEOUT)
                {
                    TimeSpan span = new TimeSpan(0, 0, 0, 0, timeOut);
                    string beautifySpan = $"{span.Days} days, {span.Hours} hours, {span.Seconds} seconds and {span.Milliseconds} ms.";
                    DialogResult dg = MessageBox.Show(
                        "You are trying to set command timeout to\n" + beautifySpan +
                        "\nAre you sure to do this?", "AntiTimeOut", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (dg != DialogResult.OK) return;
                }
            }
            catch
            {
                MessageBox.Show("The timeout value is out of range! (1 to " + int.MaxValue + ")", "AntiTimeOut", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!commandConfirmCheckBox.Checked)
            {
                MessageBox.Show("Confirm your action to continue...", "AntiTimeOut", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            backButton.Enabled = false;
            tabControl.Enabled = false;

            await Task.Run(() =>
            {
                try
                {
                    var service = new System.ServiceProcess.ServiceController(MainForm.SERVICE_NAME, Environment.MachineName);
                    if (service.Status == ServiceControllerStatus.Stopped || service.Status == ServiceControllerStatus.StopPending) throw new ConstraintException("Can't send command to a stopped service.");              
                    service.ExecuteCommand(index + 128);
                    if (service.Status == ServiceControllerStatus.Running || service.Status == ServiceControllerStatus.StartPending)
                    {
                        service.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromMilliseconds(timeOut));
                    }
                    else
                    {
                        service.WaitForStatus(ServiceControllerStatus.Paused, TimeSpan.FromMilliseconds(timeOut));
                    }
                    MessageBox.Show("Command send successfully.", "AntiTimeOut", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Source + ": " + exp.Message + "\nCheck your privileges and try again.", "AntiTimeOut", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });

            Properties.Settings.Default.commandSelectedIndex = commandComboBox.SelectedIndex;
            Properties.Settings.Default.commandDelay = timeOut;
            Properties.Settings.Default.Save();

            commandConfirmCheckBox.Checked = false;

            backButton.Enabled = true;
            tabControl.Enabled = true;
        }
        private void paramChangeOnceButton_Click(object sender, EventArgs e)
        {
            if (!IsDigitsOnly(intervalTextBox.Text) || !IsDigitsOnly(timeOutTextBox.Text) || !IsDigitsOnly(failureLimitTextBox.Text))
            {
                MessageBox.Show("Interval (1), Timeout (2) or Failure Limit (4) is in incorrect format!", "AntiTImeOut", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Convert.ToInt32(intervalTextBox.Text) <= 0 || Convert.ToInt32(timeOutTextBox.Text) < 0)
            {
                MessageBox.Show("Interval(1), Timeout(2) or Failure Limit(4) is not in range (1 -> " + int.MaxValue + ")", "AntiTimeOut", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (failModeComboBox.SelectedIndex < 0)
            {
                MessageBox.Show("Choose a failure mode (5) to continue...", "AntiTimeOut", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int interval;
            int timeOut;
            string link = urlTextBox.Text;
            ulong failLimit;
            int failMode = failModeComboBox.SelectedIndex;

            try
            {
                interval = Convert.ToInt32(intervalTextBox.Text);
                timeOut = Convert.ToInt32(timeOutTextBox.Text);
                failLimit = Convert.ToUInt64(failureLimitTextBox.Text);

                ServiceConfigForm scf = new ServiceConfigForm(interval, timeOut, link, failLimit, failMode);
                scf.ShowDialog();
            }
            catch (Exception exp)
            {
                MessageBox.Show("This operation has caused an exeption:\n" + exp.Source + ": " + exp.Message, "AntiTimeOut", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void paramChangePermentButton_Click(object sender, EventArgs e)
        {
            // Values checking
            if (!IsDigitsOnly(intervalTextBox.Text) || !IsDigitsOnly(timeOutTextBox.Text) || !IsDigitsOnly(failureLimitTextBox.Text))
            {
                MessageBox.Show("Interval(1), Timeout(2) or/and Failure Limit(4) is in incorrect format!", "AntiTimeOut", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (failModeComboBox.SelectedIndex < 0)
            {
                MessageBox.Show("Choose a failure mode (5) to continue...", "AntiTimeOut", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (Convert.ToInt32(intervalTextBox.Text) <= 0 || Convert.ToInt32(timeOutTextBox.Text) <= 0 || Convert.ToInt32(failureLimitTextBox.Text) <= 0)
                {
                    MessageBox.Show("Interval(1), Timeout(2) or/and Failure Limit(4) is not in range! (1 -> " + int.MaxValue + ")", "AntiTimeOut", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Interval(1), Timeout(2) or/and Failure Limit(4) is not in range! (1 -> " + int.MaxValue + ")", "AntiTimeOut", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (Convert.ToInt32(intervalTextBox.Text) >= OVER_INTERVAL)
            {
                int tmpInterval = Convert.ToInt32(intervalTextBox.Text);
                TimeSpan span = new TimeSpan(0, 0, 0, 0, tmpInterval);
                string beautifySpan = $"{span.Days} days, {span.Hours} hours, {span.Seconds} seconds and {span.Milliseconds} ms.";
                DialogResult dg = MessageBox.Show(
                    "You are trying to set Interval (1) to\n" + beautifySpan + 
                    "\nAre you sure to do this?", "AntiTimeOut", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dg != DialogResult.OK) return;
            }

            if (Convert.ToInt32(timeOutTextBox.Text) >= OVER_TIMEOUT)
            {
                int tmpTimeout = Convert.ToInt32(timeOutTextBox.Text);
                TimeSpan span = new TimeSpan(0, 0, 0, 0, tmpTimeout);
                string beautifySpan = $"{span.Days} days, {span.Hours} hours, {span.Seconds} seconds and {span.Milliseconds} ms.";
                DialogResult dg = MessageBox.Show(
                    "You are trying to set Timeout (2) to\n" + beautifySpan +
                    "\nAre you sure to do this?", "AntiTimeOut", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dg != DialogResult.OK) return;
            }

            if (Convert.ToInt32(failureLimitTextBox.Text) >= OVER_FAILURE_LIMIT)
            {
                int tmpFailureLimit = Convert.ToInt32(failureLimitTextBox.Text);
                DialogResult dg = MessageBox.Show(
                    "You are trying to set Failure Limit (23) to " + tmpFailureLimit + " times." +
                    "\nAre you sure to do this?", "AntiTimeOut", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dg != DialogResult.OK) return;
            }

            // Values assignment
            int interval;
            int timeOut;
            string link = urlTextBox.Text;
            ulong failLimit;

            try
            {
                interval = Convert.ToInt32(intervalTextBox.Text);
                timeOut = Convert.ToInt32(timeOutTextBox.Text);
                failLimit = Convert.ToUInt64(failureLimitTextBox.Text);
                bool convResult = Enum.TryParse<LimitAction>(failModeComboBox.GetItemText(failModeComboBox.SelectedItem), out LimitAction failMode);
                if (!convResult) throw new AccessViolationException("Cannot parse regulated limit setting.");

                var configFolderName = MainForm.DataFilePath;
                Directory.CreateDirectory(configFolderName);
                File.WriteAllText(configFolderName + "\\ServiceConfig.cfg", interval + " " + timeOut + " " + link + " " + failLimit + " " + failMode.ToString());
                if (Properties.Settings.Default.isServerUpdateSync)
                {
                    DialogResult dg = MessageBox.Show("Parameters changed successfully. (Restart service to take effect)\nDo you want to apply for client as well? (restart required)", "AntiTimeOut", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (dg == DialogResult.OK) Application.Restart();
                }
                else MessageBox.Show("Parameters changed successfully. (Restart service to take effect)", "AntiTimeOut", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exp)
            {
                MessageBox.Show("This operation has caused an exeption:\n" + exp.Source + ": " + exp.Message, "AntiTimeOut", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    } 
}