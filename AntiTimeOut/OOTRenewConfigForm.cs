using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AntiTimeOut
{
    public partial class OOTRenewConfigForm : Form
    {
        public string ProfileName { get; protected set; }
        public string SSID { get; protected set; }
        public string InterfaceName { get; protected set; }

        private System.Diagnostics.Process process;
        private bool isTestingNetwork = false;

        public OOTRenewConfigForm()
        {
            InitializeComponent();

            process = new System.Diagnostics.Process
            {
                StartInfo = {
                    FileName = "netsh.exe",
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true
                },
                EnableRaisingEvents = false,
            };

            string savedInterface = Properties.Settings.Default.ootRenewInterface;
            networkInterfaceComboBox.Items.Add("Default");
            networkInterfaceComboBox.SelectedIndex = 0;
            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                networkInterfaceComboBox.Items.Add(ni.Name);
                if (savedInterface == ni.Name)
                {
                    networkInterfaceComboBox.SelectedItem = ni.Name;
                }
            }            

            networkNameTextBox.Text = Properties.Settings.Default.ootRenewName;
            networkSSIDTextBox.Text = Properties.Settings.Default.ootRenewSSID;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

            Close();
        }

        private async void OKButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(networkNameTextBox.Text))
            {
                ProfileName = networkNameTextBox.Text;

                if (!string.IsNullOrWhiteSpace(networkSSIDTextBox.Text))
                {
                    SSID = networkSSIDTextBox.Text;
                }
                else SSID = string.Empty;

                if (networkInterfaceComboBox.SelectedIndex > 0 && !string.IsNullOrWhiteSpace((string)networkInterfaceComboBox.SelectedItem))
                {
                    InterfaceName = (string)networkInterfaceComboBox.SelectedItem;
                }
                else InterfaceName = string.Empty;

                bool errCode = false;

                OKButton.Enabled = false;
                cancelButton.Enabled = false;

                isTestingNetwork = true;
                await Task.Run(() => 
                {
                    string argsString = "wlan connect name=\"" + ProfileName + "\"" +
                            (!string.IsNullOrWhiteSpace(SSID) ? " ssid=\"" + SSID + "\"" : "") +
                            (!string.IsNullOrWhiteSpace(InterfaceName) ? " interface=\"" + InterfaceName + "\"" : "");

                    process.StartInfo.Arguments = argsString;
                    process.Start();
                    errCode = process.WaitForExit(60000);
                    if (!errCode) process.Kill();
                });
                isTestingNetwork = false;

                if (!errCode || process.ExitCode != 0)
                {
                    string err = process.StandardOutput.ReadToEnd();
                    Show();
                    MessageBox.Show(
                        "Can't connect to \"" + ProfileName + "\":\n" + err +
                        "\nVerify your input or adapters and try again.", "AntiTimeOut",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else 
                {
                    Properties.Settings.Default.ootRenewName = ProfileName;
                    Properties.Settings.Default.ootRenewSSID = SSID;
                    if (networkInterfaceComboBox.SelectedIndex > 0)
                        Properties.Settings.Default.ootRenewInterface = networkInterfaceComboBox.SelectedItem.ToString();
                    else Properties.Settings.Default.ootRenewInterface = string.Empty;
                    Properties.Settings.Default.Save();

                    this.DialogResult = DialogResult.OK;
                    Close(); 
                }

                OKButton.Enabled = true;
                cancelButton.Enabled = true;
            }
            else
            {
                MessageBox.Show("Profile Name (1) is in incorrect format!", "AntiTimeOut", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void OOTRenewConfigForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isTestingNetwork) 
            {
                e.Cancel = true;
                Show();
            }
        }
    }
}
