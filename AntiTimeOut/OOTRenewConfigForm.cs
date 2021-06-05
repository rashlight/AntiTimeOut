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

        public OOTRenewConfigForm()
        {
            InitializeComponent();

            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                networkInterfaceComboBox.Items.Add(ni.Name);
            }
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

                if (!string.IsNullOrWhiteSpace(ssidTextBox.Text))
                {
                    SSID = ProfileName;
                }
                else SSID = string.Empty;

                if (!string.IsNullOrWhiteSpace((string)networkInterfaceComboBox.SelectedItem))
                {
                    InterfaceName = (string)networkInterfaceComboBox.SelectedItem;
                }
                else InterfaceName = string.Empty;

                this.DialogResult = DialogResult.OK;

                string err = string.Empty;

                OKButton.Enabled = false;
                cancelButton.Enabled = false;

                await Task.Run(() => 
                {
                    string argsString = "wlan connect name=" + ProfileName +
                            (!string.IsNullOrWhiteSpace(SSID) ? " ssid=" + SSID : "") +
                            (!string.IsNullOrWhiteSpace(InterfaceName) ? " interface=" + InterfaceName : "");

                    var process = new System.Diagnostics.Process
                    {
                        StartInfo = { FileName = "netsh.exe", Arguments = argsString, CreateNoWindow = true, UseShellExecute = false, RedirectStandardError = true },
                        EnableRaisingEvents = true,
                    };

                    process.Start();
                    err = process.StandardError.ReadToEnd();
                });

                if (!string.IsNullOrWhiteSpace(err))
                {
                    MessageBox.Show("Can't connect to the specified network.\nVerify your input (adapter) and try again.", "AntiTimeOut", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else Close();

                OKButton.Enabled = true;
                cancelButton.Enabled = true;
            }
            else
            {
                MessageBox.Show("Network Name (1) is in incorrect format!", "AntiTimeOut", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}
