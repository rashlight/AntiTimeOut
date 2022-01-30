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