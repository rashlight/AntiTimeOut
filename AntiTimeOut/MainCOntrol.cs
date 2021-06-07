using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Security.Principal;
using System.ServiceProcess;
using System.Windows.Forms;

namespace AntiTimeOut
{
    public partial class MainControl : UserControl
    {
        private MainForm mainForm;

        public MainControl(MainForm main)
        {
            InitializeComponent();
            mainForm = main;

            try
            {
                statusTimer.Interval = Properties.Settings.Default.servicePollingTime;
            }
            catch
            {
                Properties.Settings.Default.servicePollingTime = 1000;
            }
        }

        private void PerformLoadServerFromFile()
        {
            try
            {
                ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher("root\\CIMV2",
                    "SELECT Name, PathName FROM Win32_Service");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    if ((string)queryObj["Name"] == "AntiTimeOut Network Service")
                    {
                        // For example, "drive\path_to_file\file.exe" "param1" "param2" will have
                        // index 0: empty string, index 1: drive\path_to_file\file.exe, etc...
                        // In this case we query the path, so select index 1
                        Properties.Settings.Default.loadedServiceDirectory = queryObj["PathName"].ToString().Split('"')[1];
                        Properties.Settings.Default.Save();
                    }
                }
            }
            catch (ManagementException exp)
            {
                string serviceWarning =
                       "We have detected you are running Anti Time-Out Client for the first time with " +
                       "an instance of Anti Time-Out Service (ATOService) already running in a Custom Directory.\n" +
                       "However, the query for WMI data failed: " + exp.Message + ", " +
                       "which will limit the detection of this service.\n" +
                       "PRESS YES TO SPECIFY THE LOCATION OF ATOClient, NO TO CONTINUE ANYWAY, CANCEL TO EXIT.";
                DialogResult dg = MessageBox.Show(serviceWarning, "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                switch (dg)
                {
                    case DialogResult.Yes:
                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            Properties.Settings.Default.loadedServiceDirectory = openFileDialog.FileName;
                            Properties.Settings.Default.Save();
                            MessageBox.Show("ATOService loaded. The program will now start.", "Anti Time-Out Client", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed to load service. The program will now exit.", "Anti Time-Out Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Application.Exit();
                        }
                        break;
                    case DialogResult.No:
                        break;
                    default:
                        Application.Exit();
                        break;
                }
            }
        }
        private void UpdateClientStatus()
        {
            if (ServiceExists("AntiTimeOut Network Service"))
            {
                switch (GetServiceStatus("AntiTimeOut Network Service"))
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

            if (WindowsIdentity.GetCurrent().Owner.IsWellKnown(WellKnownSidType.BuiltinAdministratorsSid)) // Is running as Admin
            {
                dateTimeTextBox.Text = DateTime.Today.ToString("ddd, MMM. dd") + " (Admin)";
                dateTimeTextBox.ForeColor = Color.SaddleBrown;
            }
            else dateTimeTextBox.Text = DateTime.Today.ToString("dddd, MMMM dd");
        }
        public bool ServiceExists(string ServiceName)
        {
            return ServiceController.GetServices().Any(serviceController => serviceController.ServiceName.Equals(ServiceName));
        }
        public ServiceControllerStatus GetServiceStatus(string ServiceName)
        {
            ServiceController sc = new ServiceController();
            sc.ServiceName = ServiceName;

            return sc.Status;
        }

        private void MainControl_Load(object sender, EventArgs e)
        {
            UpdateClientStatus();
            toolTip.SetToolTip(serviceButton, "Changes ATOService options");
            toolTip.SetToolTip(clientButton, "Modify client options");
            toolTip.SetToolTip(helpButton, "View documentation and indexes");
            toolTip.SetToolTip(creditsButton, "Who created this program?");      

            if (ServiceExists("AntiTimeOut Network Service") && string.IsNullOrWhiteSpace(Properties.Settings.Default.loadedServiceDirectory)) 
            {
                PerformLoadServerFromFile();
            }
        }
        private void statusTimer_Tick(object sender, EventArgs e)
        {
            UpdateClientStatus();
        }
        private void serviceButton_Click(object sender, EventArgs e)
        {
            mainForm.ChangeControl(this, new ServiceControl(mainForm));
        }
        private void creditsButton_Click(object sender, EventArgs e)
        {
            CreditsForm cf = new CreditsForm();
            cf.Show();
        }
        private void clientButton_Click(object sender, EventArgs e)
        {
            mainForm.ChangeControl(this, new ClientControl(mainForm));
        }
        private void helpButton_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, Application.StartupPath + "\\Help\\ATOHelp.chm");
        }
    }
}