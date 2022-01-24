namespace AntiTimeOut
{
    partial class MainControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.serviceStatusTextBox = new System.Windows.Forms.TextBox();
            this.dateTimeTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.creditsButton = new System.Windows.Forms.Button();
            this.helpButton = new System.Windows.Forms.Button();
            this.clientButton = new System.Windows.Forms.Button();
            this.serviceButton = new System.Windows.Forms.Button();
            this.statusTimer = new System.Windows.Forms.Timer(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // serviceStatusTextBox
            // 
            this.serviceStatusTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.serviceStatusTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.serviceStatusTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serviceStatusTextBox.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.serviceStatusTextBox.Location = new System.Drawing.Point(0, 58);
            this.serviceStatusTextBox.Name = "serviceStatusTextBox";
            this.serviceStatusTextBox.ReadOnly = true;
            this.serviceStatusTextBox.Size = new System.Drawing.Size(371, 15);
            this.serviceStatusTextBox.TabIndex = 5;
            this.serviceStatusTextBox.TabStop = false;
            this.serviceStatusTextBox.Text = "SERVICE STATUS: UNKNOWN";
            this.serviceStatusTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dateTimeTextBox
            // 
            this.dateTimeTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dateTimeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dateTimeTextBox.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeTextBox.Location = new System.Drawing.Point(0, 12);
            this.dateTimeTextBox.Name = "dateTimeTextBox";
            this.dateTimeTextBox.ReadOnly = true;
            this.dateTimeTextBox.Size = new System.Drawing.Size(371, 40);
            this.dateTimeTextBox.TabIndex = 4;
            this.dateTimeTextBox.TabStop = false;
            this.dateTimeTextBox.Text = "CHOOSE AN OPTION:";
            this.dateTimeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.creditsButton);
            this.panel1.Controls.Add(this.helpButton);
            this.panel1.Controls.Add(this.clientButton);
            this.panel1.Controls.Add(this.serviceButton);
            this.panel1.Location = new System.Drawing.Point(53, 92);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(268, 268);
            this.panel1.TabIndex = 3;
            // 
            // creditsButton
            // 
            this.creditsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.creditsButton.Cursor = System.Windows.Forms.Cursors.Cross;
            this.creditsButton.Image = global::AntiTimeOut.Properties.Resources.credits;
            this.creditsButton.Location = new System.Drawing.Point(137, 137);
            this.creditsButton.Name = "creditsButton";
            this.creditsButton.Size = new System.Drawing.Size(128, 128);
            this.creditsButton.TabIndex = 9;
            this.creditsButton.UseVisualStyleBackColor = true;
            this.creditsButton.Click += new System.EventHandler(this.creditsButton_Click);
            // 
            // helpButton
            // 
            this.helpButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.helpButton.Cursor = System.Windows.Forms.Cursors.Help;
            this.helpButton.Image = global::AntiTimeOut.Properties.Resources.help;
            this.helpButton.Location = new System.Drawing.Point(3, 137);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(128, 128);
            this.helpButton.TabIndex = 8;
            this.helpButton.UseVisualStyleBackColor = true;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // clientButton
            // 
            this.clientButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.clientButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clientButton.Image = global::AntiTimeOut.Properties.Resources.client;
            this.clientButton.Location = new System.Drawing.Point(137, 3);
            this.clientButton.Name = "clientButton";
            this.clientButton.Size = new System.Drawing.Size(128, 128);
            this.clientButton.TabIndex = 7;
            this.clientButton.UseVisualStyleBackColor = true;
            this.clientButton.Click += new System.EventHandler(this.clientButton_Click);
            // 
            // serviceButton
            // 
            this.serviceButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.serviceButton.Image = global::AntiTimeOut.Properties.Resources.services1;
            this.serviceButton.Location = new System.Drawing.Point(3, 3);
            this.serviceButton.Name = "serviceButton";
            this.serviceButton.Size = new System.Drawing.Size(128, 128);
            this.serviceButton.TabIndex = 6;
            this.serviceButton.UseVisualStyleBackColor = true;
            this.serviceButton.Click += new System.EventHandler(this.serviceButton_Click);
            // 
            // statusTimer
            // 
            this.statusTimer.Enabled = true;
            this.statusTimer.Interval = 1000;
            this.statusTimer.Tick += new System.EventHandler(this.statusTimer_Tick);
            // 
            // toolTip
            // 
            this.toolTip.AutomaticDelay = 1500;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "AntiTimeOutService.exe";
            this.openFileDialog.Filter = "ATOService|AntiTimeOutService.exe";
            this.openFileDialog.SupportMultiDottedExtensions = true;
            // 
            // MainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.serviceStatusTextBox);
            this.Controls.Add(this.dateTimeTextBox);
            this.Controls.Add(this.panel1);
            this.Name = "MainControl";
            this.Size = new System.Drawing.Size(371, 377);
            this.Load += new System.EventHandler(this.MainControl_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox serviceStatusTextBox;
        private System.Windows.Forms.TextBox dateTimeTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button creditsButton;
        private System.Windows.Forms.Button helpButton;
        private System.Windows.Forms.Button clientButton;
        private System.Windows.Forms.Button serviceButton;
        private System.Windows.Forms.Timer statusTimer;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}
