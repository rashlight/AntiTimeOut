﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AntiTimeOut
{
    public partial class CreditsForm : Form
    {
        public CreditsForm()
        {
            InitializeComponent();          
        }

        private void CreditsForm_Deactivate(object sender, EventArgs e)
        {
            Close();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
