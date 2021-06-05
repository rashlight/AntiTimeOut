using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace AntiTimeOut
{
    public partial class ServiceConfigForm : Form
    {
        public ServiceConfigForm(int interval, int timeOut, string link, ulong failLimit, int failAction)
        {
            InitializeComponent();
            System.Media.SystemSounds.Beep.Play();
            paramsTextBox.Text = "\"" + interval + "\" \"" + timeOut + "\" \"" + link + "\" \"" + failLimit + "\" \"" + failAction + "\"";
        }

        private void serviceLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("services.msc");
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}