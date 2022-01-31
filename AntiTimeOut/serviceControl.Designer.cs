namespace AntiTimeOut
{
    partial class ServiceControl
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
            this.backButton = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.installationPage = new System.Windows.Forms.TabPage();
            this.uninstallButton = new System.Windows.Forms.Button();
            this.serviceAvailTextBox = new System.Windows.Forms.TextBox();
            this.installButton = new System.Windows.Forms.Button();
            this.conditionPage = new System.Windows.Forms.TabPage();
            this.adminBlockPanel = new System.Windows.Forms.Panel();
            this.skipAdminButton = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.serviceAppLinkLabel = new System.Windows.Forms.LinkLabel();
            this.continueServiceButton = new System.Windows.Forms.Button();
            this.pauseServiceButton = new System.Windows.Forms.Button();
            this.stopServiceButton = new System.Windows.Forms.Button();
            this.startServiceButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.commandsPage = new System.Windows.Forms.TabPage();
            this.commandTimeOutTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.commandConfirmCheckBox = new System.Windows.Forms.CheckBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.commandComboBox = new System.Windows.Forms.ComboBox();
            this.paramPage = new System.Windows.Forms.TabPage();
            this.paramChangeOnceButton = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.timeOutTextBox = new System.Windows.Forms.TextBox();
            this.paramChangePermentButton = new System.Windows.Forms.Button();
            this.failModeComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.failureLimitTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.intervalTextBox = new System.Windows.Forms.TextBox();
            this.statusTimer = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tabControl.SuspendLayout();
            this.installationPage.SuspendLayout();
            this.conditionPage.SuspendLayout();
            this.adminBlockPanel.SuspendLayout();
            this.commandsPage.SuspendLayout();
            this.paramPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // serviceStatusTextBox
            // 
            this.serviceStatusTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.serviceStatusTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.serviceStatusTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serviceStatusTextBox.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.serviceStatusTextBox.Location = new System.Drawing.Point(0, 20);
            this.serviceStatusTextBox.Name = "serviceStatusTextBox";
            this.serviceStatusTextBox.ReadOnly = true;
            this.serviceStatusTextBox.Size = new System.Drawing.Size(371, 23);
            this.serviceStatusTextBox.TabIndex = 6;
            this.serviceStatusTextBox.TabStop = false;
            this.serviceStatusTextBox.Text = "SERVICE STATUS: UNKNOWN";
            this.serviceStatusTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.Location = new System.Drawing.Point(3, 63);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(365, 33);
            this.backButton.TabIndex = 7;
            this.backButton.Text = "<-- Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.installationPage);
            this.tabControl.Controls.Add(this.conditionPage);
            this.tabControl.Controls.Add(this.commandsPage);
            this.tabControl.Controls.Add(this.paramPage);
            this.tabControl.Location = new System.Drawing.Point(3, 102);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(365, 272);
            this.tabControl.TabIndex = 8;
            // 
            // installationPage
            // 
            this.installationPage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.installationPage.Controls.Add(this.uninstallButton);
            this.installationPage.Controls.Add(this.serviceAvailTextBox);
            this.installationPage.Controls.Add(this.installButton);
            this.installationPage.Location = new System.Drawing.Point(4, 25);
            this.installationPage.Name = "installationPage";
            this.installationPage.Size = new System.Drawing.Size(357, 243);
            this.installationPage.TabIndex = 2;
            this.installationPage.Text = "Availibility";
            // 
            // uninstallButton
            // 
            this.uninstallButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uninstallButton.Location = new System.Drawing.Point(38, 162);
            this.uninstallButton.Name = "uninstallButton";
            this.uninstallButton.Size = new System.Drawing.Size(282, 59);
            this.uninstallButton.TabIndex = 10;
            this.uninstallButton.Text = "Uninstall";
            this.uninstallButton.UseVisualStyleBackColor = true;
            this.uninstallButton.Click += new System.EventHandler(this.uninstallButton_Click);
            // 
            // serviceAvailTextBox
            // 
            this.serviceAvailTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.serviceAvailTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.serviceAvailTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serviceAvailTextBox.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.serviceAvailTextBox.Location = new System.Drawing.Point(3, 28);
            this.serviceAvailTextBox.Name = "serviceAvailTextBox";
            this.serviceAvailTextBox.ReadOnly = true;
            this.serviceAvailTextBox.Size = new System.Drawing.Size(351, 23);
            this.serviceAvailTextBox.TabIndex = 9;
            this.serviceAvailTextBox.TabStop = false;
            this.serviceAvailTextBox.Text = "Service is NIL";
            this.serviceAvailTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // installButton
            // 
            this.installButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.installButton.Location = new System.Drawing.Point(38, 82);
            this.installButton.Name = "installButton";
            this.installButton.Size = new System.Drawing.Size(282, 59);
            this.installButton.TabIndex = 0;
            this.installButton.Text = "Install";
            this.installButton.UseVisualStyleBackColor = true;
            this.installButton.Click += new System.EventHandler(this.installButton_Click);
            // 
            // conditionPage
            // 
            this.conditionPage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.conditionPage.Controls.Add(this.adminBlockPanel);
            this.conditionPage.Controls.Add(this.serviceAppLinkLabel);
            this.conditionPage.Controls.Add(this.continueServiceButton);
            this.conditionPage.Controls.Add(this.pauseServiceButton);
            this.conditionPage.Controls.Add(this.stopServiceButton);
            this.conditionPage.Controls.Add(this.startServiceButton);
            this.conditionPage.Controls.Add(this.label7);
            this.conditionPage.Location = new System.Drawing.Point(4, 25);
            this.conditionPage.Name = "conditionPage";
            this.conditionPage.Size = new System.Drawing.Size(357, 243);
            this.conditionPage.TabIndex = 3;
            this.conditionPage.Text = "Conditions";
            // 
            // adminBlockPanel
            // 
            this.adminBlockPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.adminBlockPanel.Controls.Add(this.skipAdminButton);
            this.adminBlockPanel.Controls.Add(this.label9);
            this.adminBlockPanel.Location = new System.Drawing.Point(4, 73);
            this.adminBlockPanel.Name = "adminBlockPanel";
            this.adminBlockPanel.Size = new System.Drawing.Size(350, 116);
            this.adminBlockPanel.TabIndex = 11;
            this.adminBlockPanel.Visible = false;
            // 
            // skipAdminButton
            // 
            this.skipAdminButton.Location = new System.Drawing.Point(108, 61);
            this.skipAdminButton.Name = "skipAdminButton";
            this.skipAdminButton.Size = new System.Drawing.Size(127, 28);
            this.skipAdminButton.TabIndex = 1;
            this.skipAdminButton.Text = "Access Anyway";
            this.skipAdminButton.UseVisualStyleBackColor = true;
            this.skipAdminButton.Click += new System.EventHandler(this.skipAdminButton_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(65, 38);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(199, 16);
            this.label9.TabIndex = 0;
            this.label9.Text = "Administrator rights are required.";
            // 
            // serviceAppLinkLabel
            // 
            this.serviceAppLinkLabel.AutoSize = true;
            this.serviceAppLinkLabel.Location = new System.Drawing.Point(22, 209);
            this.serviceAppLinkLabel.Name = "serviceAppLinkLabel";
            this.serviceAppLinkLabel.Size = new System.Drawing.Size(292, 16);
            this.serviceAppLinkLabel.TabIndex = 10;
            this.serviceAppLinkLabel.TabStop = true;
            this.serviceAppLinkLabel.Text = "Want to manage other options? (Open Services)";
            this.serviceAppLinkLabel.VisitedLinkColor = System.Drawing.Color.Blue;
            this.serviceAppLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.serviceAppLinkLabel_LinkClicked);
            // 
            // continueServiceButton
            // 
            this.continueServiceButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.continueServiceButton.Location = new System.Drawing.Point(182, 134);
            this.continueServiceButton.Name = "continueServiceButton";
            this.continueServiceButton.Size = new System.Drawing.Size(172, 55);
            this.continueServiceButton.TabIndex = 9;
            this.continueServiceButton.Text = "Continue";
            this.continueServiceButton.UseVisualStyleBackColor = true;
            this.continueServiceButton.Click += new System.EventHandler(this.continueServiceButton_Click);
            // 
            // pauseServiceButton
            // 
            this.pauseServiceButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pauseServiceButton.Location = new System.Drawing.Point(4, 134);
            this.pauseServiceButton.Name = "pauseServiceButton";
            this.pauseServiceButton.Size = new System.Drawing.Size(172, 55);
            this.pauseServiceButton.TabIndex = 8;
            this.pauseServiceButton.Text = "Pause";
            this.pauseServiceButton.UseVisualStyleBackColor = true;
            this.pauseServiceButton.Click += new System.EventHandler(this.pauseServiceButton_Click);
            // 
            // stopServiceButton
            // 
            this.stopServiceButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopServiceButton.Location = new System.Drawing.Point(182, 73);
            this.stopServiceButton.Name = "stopServiceButton";
            this.stopServiceButton.Size = new System.Drawing.Size(172, 55);
            this.stopServiceButton.TabIndex = 7;
            this.stopServiceButton.Text = "Stop";
            this.stopServiceButton.UseVisualStyleBackColor = true;
            this.stopServiceButton.Click += new System.EventHandler(this.stopServiceButton_Click);
            // 
            // startServiceButton
            // 
            this.startServiceButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startServiceButton.Location = new System.Drawing.Point(3, 73);
            this.startServiceButton.Name = "startServiceButton";
            this.startServiceButton.Size = new System.Drawing.Size(173, 55);
            this.startServiceButton.TabIndex = 6;
            this.startServiceButton.Text = "Start";
            this.startServiceButton.UseVisualStyleBackColor = true;
            this.startServiceButton.Click += new System.EventHandler(this.startServiceButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(17, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(321, 26);
            this.label7.TabIndex = 5;
            this.label7.Text = "Change service\'s current status:";
            // 
            // commandsPage
            // 
            this.commandsPage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.commandsPage.Controls.Add(this.commandTimeOutTextBox);
            this.commandsPage.Controls.Add(this.label10);
            this.commandsPage.Controls.Add(this.commandConfirmCheckBox);
            this.commandsPage.Controls.Add(this.sendButton);
            this.commandsPage.Controls.Add(this.label8);
            this.commandsPage.Controls.Add(this.commandComboBox);
            this.commandsPage.Location = new System.Drawing.Point(4, 25);
            this.commandsPage.Name = "commandsPage";
            this.commandsPage.Padding = new System.Windows.Forms.Padding(3);
            this.commandsPage.Size = new System.Drawing.Size(357, 243);
            this.commandsPage.TabIndex = 0;
            this.commandsPage.Text = "Commands";
            // 
            // commandTimeOutTextBox
            // 
            this.commandTimeOutTextBox.Location = new System.Drawing.Point(169, 116);
            this.commandTimeOutTextBox.Name = "commandTimeOutTextBox";
            this.commandTimeOutTextBox.Size = new System.Drawing.Size(118, 22);
            this.commandTimeOutTextBox.TabIndex = 6;
            this.commandTimeOutTextBox.Text = "5000";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(69, 117);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 16);
            this.label10.TabIndex = 5;
            this.label10.Text = "Timeout (ms):";
            // 
            // commandConfirmCheckBox
            // 
            this.commandConfirmCheckBox.AutoSize = true;
            this.commandConfirmCheckBox.Location = new System.Drawing.Point(72, 146);
            this.commandConfirmCheckBox.Name = "commandConfirmCheckBox";
            this.commandConfirmCheckBox.Size = new System.Drawing.Size(207, 20);
            this.commandConfirmCheckBox.TabIndex = 3;
            this.commandConfirmCheckBox.Text = "This action cannot be undone.";
            this.commandConfirmCheckBox.UseVisualStyleBackColor = true;
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(94, 175);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(172, 29);
            this.sendButton.TabIndex = 2;
            this.sendButton.Text = "SEND";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(40, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(277, 26);
            this.label8.TabIndex = 1;
            this.label8.Text = "Send command to service: ";
            // 
            // commandComboBox
            // 
            this.commandComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.commandComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.commandComboBox.FormattingEnabled = true;
            this.commandComboBox.Location = new System.Drawing.Point(6, 77);
            this.commandComboBox.Name = "commandComboBox";
            this.commandComboBox.Size = new System.Drawing.Size(345, 26);
            this.commandComboBox.TabIndex = 0;
            // 
            // paramPage
            // 
            this.paramPage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.paramPage.Controls.Add(this.paramChangeOnceButton);
            this.paramPage.Controls.Add(this.label11);
            this.paramPage.Controls.Add(this.timeOutTextBox);
            this.paramPage.Controls.Add(this.paramChangePermentButton);
            this.paramPage.Controls.Add(this.failModeComboBox);
            this.paramPage.Controls.Add(this.label6);
            this.paramPage.Controls.Add(this.label5);
            this.paramPage.Controls.Add(this.failureLimitTextBox);
            this.paramPage.Controls.Add(this.label4);
            this.paramPage.Controls.Add(this.urlTextBox);
            this.paramPage.Controls.Add(this.label3);
            this.paramPage.Controls.Add(this.label2);
            this.paramPage.Controls.Add(this.intervalTextBox);
            this.paramPage.Location = new System.Drawing.Point(4, 25);
            this.paramPage.Name = "paramPage";
            this.paramPage.Padding = new System.Windows.Forms.Padding(3);
            this.paramPage.Size = new System.Drawing.Size(357, 243);
            this.paramPage.TabIndex = 1;
            this.paramPage.Text = "Parameters";
            // 
            // paramChangeOnceButton
            // 
            this.paramChangeOnceButton.Location = new System.Drawing.Point(13, 196);
            this.paramChangeOnceButton.Name = "paramChangeOnceButton";
            this.paramChangeOnceButton.Size = new System.Drawing.Size(161, 38);
            this.paramChangeOnceButton.TabIndex = 16;
            this.paramChangeOnceButton.Text = "Modify Once";
            this.paramChangeOnceButton.UseVisualStyleBackColor = true;
            this.paramChangeOnceButton.Click += new System.EventHandler(this.paramChangeOnceButton_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 85);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(101, 16);
            this.label11.TabIndex = 15;
            this.label11.Text = "2: Timeout (ms):";
            // 
            // timeOutTextBox
            // 
            this.timeOutTextBox.Location = new System.Drawing.Point(133, 82);
            this.timeOutTextBox.Name = "timeOutTextBox";
            this.timeOutTextBox.Size = new System.Drawing.Size(209, 22);
            this.timeOutTextBox.TabIndex = 14;
            this.timeOutTextBox.Text = "1000";
            // 
            // paramChangePermentButton
            // 
            this.paramChangePermentButton.Location = new System.Drawing.Point(180, 196);
            this.paramChangePermentButton.Name = "paramChangePermentButton";
            this.paramChangePermentButton.Size = new System.Drawing.Size(162, 38);
            this.paramChangePermentButton.TabIndex = 13;
            this.paramChangePermentButton.Text = "Modify Permanently";
            this.paramChangePermentButton.UseVisualStyleBackColor = true;
            this.paramChangePermentButton.Click += new System.EventHandler(this.paramChangePermentButton_Click);
            // 
            // failModeComboBox
            // 
            this.failModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.failModeComboBox.FormattingEnabled = true;
            this.failModeComboBox.Location = new System.Drawing.Point(110, 166);
            this.failModeComboBox.Name = "failModeComboBox";
            this.failModeComboBox.Size = new System.Drawing.Size(231, 24);
            this.failModeComboBox.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 169);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "5: Fail Mode:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "4: Failure Limit:";
            // 
            // failureLimitTextBox
            // 
            this.failureLimitTextBox.Location = new System.Drawing.Point(125, 138);
            this.failureLimitTextBox.Name = "failureLimitTextBox";
            this.failureLimitTextBox.Size = new System.Drawing.Size(216, 22);
            this.failureLimitTextBox.TabIndex = 6;
            this.failureLimitTextBox.Text = "2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "3: URL:";
            // 
            // urlTextBox
            // 
            this.urlTextBox.Location = new System.Drawing.Point(78, 110);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(264, 22);
            this.urlTextBox.TabIndex = 4;
            this.urlTextBox.Text = "1.1.1.1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "1: Interval (ms):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(345, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Change service startup configurations:";
            // 
            // intervalTextBox
            // 
            this.intervalTextBox.Location = new System.Drawing.Point(128, 54);
            this.intervalTextBox.Name = "intervalTextBox";
            this.intervalTextBox.Size = new System.Drawing.Size(214, 22);
            this.intervalTextBox.TabIndex = 0;
            this.intervalTextBox.Text = "1000";
            // 
            // statusTimer
            // 
            this.statusTimer.Enabled = true;
            this.statusTimer.Interval = 1000;
            this.statusTimer.Tick += new System.EventHandler(this.statusTimer_Tick);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "AntiTimeOutService.exe";
            this.openFileDialog.Filter = "ATOService|AntiTimeOutService.exe";
            this.openFileDialog.SupportMultiDottedExtensions = true;
            this.openFileDialog.Title = "Please choose the location of AntiTimeOutService.exe...";
            // 
            // ServiceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.serviceStatusTextBox);
            this.Name = "ServiceControl";
            this.Size = new System.Drawing.Size(371, 377);
            this.Load += new System.EventHandler(this.ServiceControl_Load);
            this.tabControl.ResumeLayout(false);
            this.installationPage.ResumeLayout(false);
            this.installationPage.PerformLayout();
            this.conditionPage.ResumeLayout(false);
            this.conditionPage.PerformLayout();
            this.adminBlockPanel.ResumeLayout(false);
            this.adminBlockPanel.PerformLayout();
            this.commandsPage.ResumeLayout(false);
            this.commandsPage.PerformLayout();
            this.paramPage.ResumeLayout(false);
            this.paramPage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox serviceStatusTextBox;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage commandsPage;
        private System.Windows.Forms.ComboBox commandComboBox;
        private System.Windows.Forms.TabPage paramPage;
        private System.Windows.Forms.Timer statusTimer;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.TabPage installationPage;
        private System.Windows.Forms.Button installButton;
        private System.Windows.Forms.Button uninstallButton;
        private System.Windows.Forms.TextBox serviceAvailTextBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TextBox intervalTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox failureLimitTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox urlTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button paramChangePermentButton;
        private System.Windows.Forms.ComboBox failModeComboBox;
        private System.Windows.Forms.CheckBox commandConfirmCheckBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox commandTimeOutTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox timeOutTextBox;
        private System.Windows.Forms.Button paramChangeOnceButton;
        private System.Windows.Forms.TabPage conditionPage;
        private System.Windows.Forms.Panel adminBlockPanel;
        private System.Windows.Forms.Button skipAdminButton;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.LinkLabel serviceAppLinkLabel;
        private System.Windows.Forms.Button continueServiceButton;
        private System.Windows.Forms.Button pauseServiceButton;
        private System.Windows.Forms.Button stopServiceButton;
        private System.Windows.Forms.Button startServiceButton;
        private System.Windows.Forms.Label label7;
    }
}
