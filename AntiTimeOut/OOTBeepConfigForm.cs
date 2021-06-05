using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using System.Windows.Forms;

namespace AntiTimeOut
{
    public partial class OOTBeepConfigForm : Form
    {
        public string sfxName { get; protected set; }

        public OOTBeepConfigForm(string dir)
        {
            InitializeComponent();
            LoadSFXList(dir);
            folderBrowserDialog.SelectedPath = Path.GetDirectoryName(dir);
        }

        private void LoadSFXList(string dir)
        {
            sfxNameListBox.Items.Clear();
            dirTextBox.Text = dir;
            DirectoryInfo di = new DirectoryInfo(@dir);
            FileInfo[] fi = di.GetFiles("*.wav");
            foreach (FileInfo file in fi)
            {
                sfxNameListBox.Items.Add(file.Name);
            }
        }
      
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
        private void OKButton_Click(object sender, EventArgs e)
        {
            if (sfxNameListBox.SelectedIndex < 0)
            {
                MessageBox.Show("Select an option from the list to continue...", "AntiTimeOut", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sfxName = dirTextBox.Text + "\\" + (string)sfxNameListBox.SelectedItem;
            this.DialogResult = DialogResult.OK;
            Close();
        }
        private void testSoundButton_Click(object sender, EventArgs e)
        {
            if (sfxNameListBox.SelectedIndex < 0)
            {
                MessageBox.Show("Select an option from the list to continue...", "AntiTimeOut", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                using (System.Media.SoundPlayer sp = new System.Media.SoundPlayer(dirTextBox.Text + "\\" + (string)sfxNameListBox.SelectedItem))
                {
                    sp.Play();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("Cannot play sound: " + exp.Message, "AntiTimeOut", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
        }
        private void folderChooseCutton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.ShowDialog();
            LoadSFXList(folderBrowserDialog.SelectedPath);
        }     
    }
}
