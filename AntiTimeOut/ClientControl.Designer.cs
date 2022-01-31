namespace AntiTimeOut
{
    partial class ClientControl
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
            this.dateTimeTextBox = new System.Windows.Forms.TextBox();
            this.backButton = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.intervalPanel = new System.Windows.Forms.TabPage();
            this.ootRunOnceCheckBox = new System.Windows.Forms.CheckBox();
            this.ootSettingsButton = new System.Windows.Forms.Button();
            this.ootComboBox = new System.Windows.Forms.ComboBox();
            this.ootSaveButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lastRecordTextBox = new System.Windows.Forms.TextBox();
            this.serviceStatusTextBox = new System.Windows.Forms.TextBox();
            this.troubleshootTab = new System.Windows.Forms.TabPage();
            this.syncServerConfigCheckBox = new System.Windows.Forms.CheckBox();
            this.saiTextBox = new System.Windows.Forms.TextBox();
            this.saiSaveButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.configPanel = new System.Windows.Forms.TabPage();
            this.sbsModeCheckBox = new System.Windows.Forms.CheckBox();
            this.nvsModeCheckBox = new System.Windows.Forms.CheckBox();
            this.systrayCheckBox = new System.Windows.Forms.CheckBox();
            this.versionTextBox = new System.Windows.Forms.TextBox();
            this.authorLink1 = new System.Windows.Forms.LinkLabel();
            this.osStartupCheckBox = new System.Windows.Forms.CheckBox();
            this.managementPanel = new System.Windows.Forms.TabPage();
            this.resetConfigButton = new System.Windows.Forms.Button();
            this.deleteInstallStateButton = new System.Windows.Forms.Button();
            this.clearServiceLogButton = new System.Windows.Forms.Button();
            this.showDefServiceButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.authorLink2 = new System.Windows.Forms.LinkLabel();
            this.adminRestartButton = new System.Windows.Forms.Button();
            this.clientSettingsWatcher = new System.IO.FileSystemWatcher();
            this.troubleshootPanel = new System.Windows.Forms.TabPage();
            this.tabControl.SuspendLayout();
            this.intervalPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.troubleshootTab.SuspendLayout();
            this.configPanel.SuspendLayout();
            this.managementPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientSettingsWatcher)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimeTextBox
            // 
            this.dateTimeTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dateTimeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dateTimeTextBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dateTimeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.dateTimeTextBox.Location = new System.Drawing.Point(0, 18);
            this.dateTimeTextBox.Name = "dateTimeTextBox";
            this.dateTimeTextBox.ReadOnly = true;
            this.dateTimeTextBox.Size = new System.Drawing.Size(371, 27);
            this.dateTimeTextBox.TabIndex = 5;
            this.dateTimeTextBox.TabStop = false;
            this.dateTimeTextBox.Text = "CLIENT SETTINGS";
            this.dateTimeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.Location = new System.Drawing.Point(3, 63);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(365, 33);
            this.backButton.TabIndex = 8;
            this.backButton.Text = "<-- Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.intervalPanel);
            this.tabControl.Controls.Add(this.troubleshootTab);
            this.tabControl.Controls.Add(this.configPanel);
            this.tabControl.Controls.Add(this.managementPanel);
            this.tabControl.Location = new System.Drawing.Point(3, 102);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(365, 272);
            this.tabControl.TabIndex = 9;
            // 
            // intervalPanel
            // 
            this.intervalPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.intervalPanel.Controls.Add(this.ootRunOnceCheckBox);
            this.intervalPanel.Controls.Add(this.ootSettingsButton);
            this.intervalPanel.Controls.Add(this.ootComboBox);
            this.intervalPanel.Controls.Add(this.ootSaveButton);
            this.intervalPanel.Controls.Add(this.label2);
            this.intervalPanel.Controls.Add(this.groupBox1);
            this.intervalPanel.Location = new System.Drawing.Point(4, 25);
            this.intervalPanel.Name = "intervalPanel";
            this.intervalPanel.Padding = new System.Windows.Forms.Padding(3);
            this.intervalPanel.Size = new System.Drawing.Size(357, 243);
            this.intervalPanel.TabIndex = 0;
            this.intervalPanel.Text = "Intervals";
            // 
            // ootRunOnceCheckBox
            // 
            this.ootRunOnceCheckBox.AutoSize = true;
            this.ootRunOnceCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ootRunOnceCheckBox.Location = new System.Drawing.Point(86, 211);
            this.ootRunOnceCheckBox.Name = "ootRunOnceCheckBox";
            this.ootRunOnceCheckBox.Size = new System.Drawing.Size(94, 21);
            this.ootRunOnceCheckBox.TabIndex = 21;
            this.ootRunOnceCheckBox.Text = "Run Once";
            this.ootRunOnceCheckBox.UseVisualStyleBackColor = true;
            // 
            // ootSettingsButton
            // 
            this.ootSettingsButton.Location = new System.Drawing.Point(232, 207);
            this.ootSettingsButton.Name = "ootSettingsButton";
            this.ootSettingsButton.Size = new System.Drawing.Size(95, 29);
            this.ootSettingsButton.TabIndex = 20;
            this.ootSettingsButton.Text = "Settings...";
            this.ootSettingsButton.UseVisualStyleBackColor = true;
            this.ootSettingsButton.Visible = false;
            this.ootSettingsButton.Click += new System.EventHandler(this.ootSettingsButton_Click);
            // 
            // ootComboBox
            // 
            this.ootComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ootComboBox.FormattingEnabled = true;
            this.ootComboBox.Location = new System.Drawing.Point(29, 172);
            this.ootComboBox.Name = "ootComboBox";
            this.ootComboBox.Size = new System.Drawing.Size(302, 24);
            this.ootComboBox.TabIndex = 19;
            this.ootComboBox.SelectedIndexChanged += new System.EventHandler(this.ootComboBox_SelectedIndexChanged);
            // 
            // ootSaveButton
            // 
            this.ootSaveButton.Location = new System.Drawing.Point(181, 207);
            this.ootSaveButton.Name = "ootSaveButton";
            this.ootSaveButton.Size = new System.Drawing.Size(95, 29);
            this.ootSaveButton.TabIndex = 18;
            this.ootSaveButton.Text = "Save";
            this.ootSaveButton.UseVisualStyleBackColor = true;
            this.ootSaveButton.Click += new System.EventHandler(this.ootSaveButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(54, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(250, 25);
            this.label2.TabIndex = 17;
            this.label2.Text = "Out-Of-Time (OOT) action:\r\n";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lastRecordTextBox);
            this.groupBox1.Controls.Add(this.serviceStatusTextBox);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(345, 127);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Service Data Live Update";
            // 
            // lastRecordTextBox
            // 
            this.lastRecordTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lastRecordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lastRecordTextBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lastRecordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lastRecordTextBox.Location = new System.Drawing.Point(6, 101);
            this.lastRecordTextBox.Name = "lastRecordTextBox";
            this.lastRecordTextBox.ReadOnly = true;
            this.lastRecordTextBox.Size = new System.Drawing.Size(333, 16);
            this.lastRecordTextBox.TabIndex = 14;
            this.lastRecordTextBox.Text = "Last Recorded: HH:MM:SS MM/DD/YYYY";
            this.lastRecordTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // serviceStatusTextBox
            // 
            this.serviceStatusTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.serviceStatusTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.serviceStatusTextBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.serviceStatusTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serviceStatusTextBox.Location = new System.Drawing.Point(6, 27);
            this.serviceStatusTextBox.Name = "serviceStatusTextBox";
            this.serviceStatusTextBox.ReadOnly = true;
            this.serviceStatusTextBox.Size = new System.Drawing.Size(333, 68);
            this.serviceStatusTextBox.TabIndex = 15;
            this.serviceStatusTextBox.Text = "WAIT";
            this.serviceStatusTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // troubleshootTab
            // 
            this.troubleshootTab.BackColor = System.Drawing.Color.WhiteSmoke;
            this.troubleshootTab.Controls.Add(this.syncServerConfigCheckBox);
            this.troubleshootTab.Controls.Add(this.saiTextBox);
            this.troubleshootTab.Controls.Add(this.saiSaveButton);
            this.troubleshootTab.Controls.Add(this.label1);
            this.troubleshootTab.Location = new System.Drawing.Point(4, 25);
            this.troubleshootTab.Name = "troubleshootTab";
            this.troubleshootTab.Size = new System.Drawing.Size(357, 243);
            this.troubleshootTab.TabIndex = 1;
            this.troubleshootTab.Text = "Troubleshooting";
            // 
            // syncServerConfigCheckBox
            // 
            this.syncServerConfigCheckBox.AutoSize = true;
            this.syncServerConfigCheckBox.Location = new System.Drawing.Point(95, 129);
            this.syncServerConfigCheckBox.Name = "syncServerConfigCheckBox";
            this.syncServerConfigCheckBox.Size = new System.Drawing.Size(164, 20);
            this.syncServerConfigCheckBox.TabIndex = 24;
            this.syncServerConfigCheckBox.Text = "Sync with server config";
            this.syncServerConfigCheckBox.UseVisualStyleBackColor = true;
            this.syncServerConfigCheckBox.CheckedChanged += new System.EventHandler(this.syncServerConfigCheckBox_CheckedChanged);
            // 
            // saiTextBox
            // 
            this.saiTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.saiTextBox.Location = new System.Drawing.Point(31, 95);
            this.saiTextBox.Name = "saiTextBox";
            this.saiTextBox.Size = new System.Drawing.Size(301, 24);
            this.saiTextBox.TabIndex = 23;
            this.saiTextBox.Text = "1000";
            this.saiTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // saiSaveButton
            // 
            this.saiSaveButton.Location = new System.Drawing.Point(116, 158);
            this.saiSaveButton.Name = "saiSaveButton";
            this.saiSaveButton.Size = new System.Drawing.Size(131, 29);
            this.saiSaveButton.TabIndex = 21;
            this.saiSaveButton.Text = "Save";
            this.saiSaveButton.UseVisualStyleBackColor = true;
            this.saiSaveButton.Click += new System.EventHandler(this.saiSaveButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(51, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 25);
            this.label1.TabIndex = 20;
            this.label1.Text = "Service Polling Interval (ms):";
            // 
            // configPanel
            // 
            this.configPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.configPanel.Controls.Add(this.sbsModeCheckBox);
            this.configPanel.Controls.Add(this.nvsModeCheckBox);
            this.configPanel.Controls.Add(this.systrayCheckBox);
            this.configPanel.Controls.Add(this.adminRestartButton);
            this.configPanel.Controls.Add(this.versionTextBox);
            this.configPanel.Controls.Add(this.authorLink1);
            this.configPanel.Controls.Add(this.osStartupCheckBox);
            this.configPanel.Location = new System.Drawing.Point(4, 25);
            this.configPanel.Name = "configPanel";
            this.configPanel.Size = new System.Drawing.Size(357, 243);
            this.configPanel.TabIndex = 2;
            this.configPanel.Text = "Configurations";
            // 
            // sbsModeCheckBox
            // 
            this.sbsModeCheckBox.AutoSize = true;
            this.sbsModeCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.sbsModeCheckBox.Location = new System.Drawing.Point(102, 63);
            this.sbsModeCheckBox.Name = "sbsModeCheckBox";
            this.sbsModeCheckBox.Size = new System.Drawing.Size(149, 20);
            this.sbsModeCheckBox.TabIndex = 6;
            this.sbsModeCheckBox.Text = "Side-by-side Clients";
            this.sbsModeCheckBox.UseVisualStyleBackColor = true;
            this.sbsModeCheckBox.CheckedChanged += new System.EventHandler(this.sbsModeCheckBox_CheckedChanged);
            // 
            // nvsModeCheckBox
            // 
            this.nvsModeCheckBox.AutoSize = true;
            this.nvsModeCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.nvsModeCheckBox.Location = new System.Drawing.Point(115, 92);
            this.nvsModeCheckBox.Name = "nvsModeCheckBox";
            this.nvsModeCheckBox.Size = new System.Drawing.Size(123, 20);
            this.nvsModeCheckBox.TabIndex = 5;
            this.nvsModeCheckBox.Text = "Start in Taskbar";
            this.nvsModeCheckBox.UseVisualStyleBackColor = true;
            this.nvsModeCheckBox.CheckedChanged += new System.EventHandler(this.nvsModeCheckBox_CheckedChanged);
            // 
            // systrayCheckBox
            // 
            this.systrayCheckBox.AutoSize = true;
            this.systrayCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.systrayCheckBox.Location = new System.Drawing.Point(121, 121);
            this.systrayCheckBox.Name = "systrayCheckBox";
            this.systrayCheckBox.Size = new System.Drawing.Size(112, 20);
            this.systrayCheckBox.TabIndex = 2;
            this.systrayCheckBox.Text = "Systray Mode";
            this.systrayCheckBox.UseVisualStyleBackColor = true;
            this.systrayCheckBox.CheckedChanged += new System.EventHandler(this.systrayCheckBox_CheckedChanged);
            // 
            // versionTextBox
            // 
            this.versionTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.versionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.versionTextBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.versionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.versionTextBox.Location = new System.Drawing.Point(3, 200);
            this.versionTextBox.Name = "versionTextBox";
            this.versionTextBox.ReadOnly = true;
            this.versionTextBox.Size = new System.Drawing.Size(351, 17);
            this.versionTextBox.TabIndex = 1;
            this.versionTextBox.Text = "Version X.X.X.X, Windows XX-bit, .NET XX.X ";
            this.versionTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // authorLink1
            // 
            this.authorLink1.Location = new System.Drawing.Point(3, 218);
            this.authorLink1.Name = "authorLink1";
            this.authorLink1.Size = new System.Drawing.Size(351, 17);
            this.authorLink1.TabIndex = 0;
            this.authorLink1.TabStop = true;
            this.authorLink1.Text = "@rashlight 2020-2022";
            this.authorLink1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.authorLink1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.authorLink_LinkClicked);
            // 
            // osStartupCheckBox
            // 
            this.osStartupCheckBox.AutoSize = true;
            this.osStartupCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.osStartupCheckBox.Location = new System.Drawing.Point(66, 33);
            this.osStartupCheckBox.Name = "osStartupCheckBox";
            this.osStartupCheckBox.Size = new System.Drawing.Size(219, 20);
            this.osStartupCheckBox.TabIndex = 0;
            this.osStartupCheckBox.Text = "Run the program when OS starts";
            this.osStartupCheckBox.UseVisualStyleBackColor = true;
            this.osStartupCheckBox.CheckedChanged += new System.EventHandler(this.osStartupCheckBox_CheckedChanged);
            // 
            // managementPanel
            // 
            this.managementPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.managementPanel.Controls.Add(this.resetConfigButton);
            this.managementPanel.Controls.Add(this.deleteInstallStateButton);
            this.managementPanel.Controls.Add(this.clearServiceLogButton);
            this.managementPanel.Controls.Add(this.showDefServiceButton);
            this.managementPanel.Controls.Add(this.textBox1);
            this.managementPanel.Controls.Add(this.authorLink2);
            this.managementPanel.Location = new System.Drawing.Point(4, 25);
            this.managementPanel.Name = "managementPanel";
            this.managementPanel.Size = new System.Drawing.Size(357, 243);
            this.managementPanel.TabIndex = 3;
            this.managementPanel.Text = "Management";
            // 
            // resetConfigButton
            // 
            this.resetConfigButton.Location = new System.Drawing.Point(83, 143);
            this.resetConfigButton.Name = "resetConfigButton";
            this.resetConfigButton.Size = new System.Drawing.Size(196, 28);
            this.resetConfigButton.TabIndex = 10;
            this.resetConfigButton.Text = "Reset all configurations";
            this.resetConfigButton.UseVisualStyleBackColor = true;
            this.resetConfigButton.Click += new System.EventHandler(this.resetConfigButton_Click);
            // 
            // deleteInstallStateButton
            // 
            this.deleteInstallStateButton.Location = new System.Drawing.Point(54, 109);
            this.deleteInstallStateButton.Name = "deleteInstallStateButton";
            this.deleteInstallStateButton.Size = new System.Drawing.Size(245, 28);
            this.deleteInstallStateButton.TabIndex = 9;
            this.deleteInstallStateButton.Text = "Delete InstallState file (migration)";
            this.deleteInstallStateButton.UseVisualStyleBackColor = true;
            this.deleteInstallStateButton.Click += new System.EventHandler(this.deleteInstallStateButton_Click);
            // 
            // clearServiceLogButton
            // 
            this.clearServiceLogButton.Location = new System.Drawing.Point(83, 41);
            this.clearServiceLogButton.Name = "clearServiceLogButton";
            this.clearServiceLogButton.Size = new System.Drawing.Size(196, 28);
            this.clearServiceLogButton.TabIndex = 8;
            this.clearServiceLogButton.Text = "Clear service logs";
            this.clearServiceLogButton.UseVisualStyleBackColor = true;
            this.clearServiceLogButton.Click += new System.EventHandler(this.clearServiceLogButton_Click);
            // 
            // showDefServiceButton
            // 
            this.showDefServiceButton.Location = new System.Drawing.Point(54, 75);
            this.showDefServiceButton.Name = "showDefServiceButton";
            this.showDefServiceButton.Size = new System.Drawing.Size(245, 28);
            this.showDefServiceButton.TabIndex = 7;
            this.showDefServiceButton.Text = "Show service informations";
            this.showDefServiceButton.UseVisualStyleBackColor = true;
            this.showDefServiceButton.Click += new System.EventHandler(this.showDefServiceButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.textBox1.Location = new System.Drawing.Point(3, 200);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(351, 17);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "Perform these action with caution.";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // authorLink2
            // 
            this.authorLink2.Location = new System.Drawing.Point(3, 218);
            this.authorLink2.Name = "authorLink2";
            this.authorLink2.Size = new System.Drawing.Size(351, 17);
            this.authorLink2.TabIndex = 5;
            this.authorLink2.TabStop = true;
            this.authorLink2.Text = "@rashlight 2020-2022";
            this.authorLink2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.authorLink2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.authorLink_LinkClicked);
            // 
            // adminRestartButton
            // 
            this.adminRestartButton.Location = new System.Drawing.Point(77, 147);
            this.adminRestartButton.Name = "adminRestartButton";
            this.adminRestartButton.Size = new System.Drawing.Size(196, 28);
            this.adminRestartButton.TabIndex = 4;
            this.adminRestartButton.Text = " Restart as Administrator";
            this.adminRestartButton.UseVisualStyleBackColor = true;
            this.adminRestartButton.Click += new System.EventHandler(this.adminRestartButton_Click);
            // 
            // clientSettingsWatcher
            // 
            this.clientSettingsWatcher.EnableRaisingEvents = true;
            this.clientSettingsWatcher.Filter = "ServiceStatus.log";
            this.clientSettingsWatcher.NotifyFilter = System.IO.NotifyFilters.LastWrite;
            this.clientSettingsWatcher.SynchronizingObject = this;
            this.clientSettingsWatcher.Changed += new System.IO.FileSystemEventHandler(this.clientSettingsWatcher_Changed);
            // 
            // troubleshootPanel
            // 
            this.troubleshootPanel.Location = new System.Drawing.Point(4, 28);
            this.troubleshootPanel.Name = "troubleshootPanel";
            this.troubleshootPanel.Size = new System.Drawing.Size(357, 240);
            this.troubleshootPanel.TabIndex = 1;
            this.troubleshootPanel.Text = "Troubleshooting";
            this.troubleshootPanel.UseVisualStyleBackColor = true;
            // 
            // ClientControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.dateTimeTextBox);
            this.Name = "ClientControl";
            this.Size = new System.Drawing.Size(371, 377);
            this.Load += new System.EventHandler(this.ClientControl_Load);
            this.tabControl.ResumeLayout(false);
            this.intervalPanel.ResumeLayout(false);
            this.intervalPanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.troubleshootTab.ResumeLayout(false);
            this.troubleshootTab.PerformLayout();
            this.configPanel.ResumeLayout(false);
            this.configPanel.PerformLayout();
            this.managementPanel.ResumeLayout(false);
            this.managementPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientSettingsWatcher)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox dateTimeTextBox;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage intervalPanel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox lastRecordTextBox;
        private System.Windows.Forms.TextBox serviceStatusTextBox;
        private System.Windows.Forms.ComboBox ootComboBox;
        private System.Windows.Forms.Button ootSaveButton;
        private System.Windows.Forms.Label label2;
        private System.IO.FileSystemWatcher clientSettingsWatcher;
        private System.Windows.Forms.TabPage troubleshootTab;
        private System.Windows.Forms.TabPage troubleshootPanel;
        private System.Windows.Forms.Button saiSaveButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox saiTextBox;
        private System.Windows.Forms.TabPage configPanel;
        private System.Windows.Forms.CheckBox osStartupCheckBox;
        private System.Windows.Forms.LinkLabel authorLink1;
        private System.Windows.Forms.TextBox versionTextBox;
        private System.Windows.Forms.CheckBox systrayCheckBox;
        private System.Windows.Forms.Button adminRestartButton;
        private System.Windows.Forms.Button ootSettingsButton;
        private System.Windows.Forms.CheckBox nvsModeCheckBox;
        private System.Windows.Forms.CheckBox ootRunOnceCheckBox;
        private System.Windows.Forms.CheckBox sbsModeCheckBox;
        private System.Windows.Forms.CheckBox syncServerConfigCheckBox;
        private System.Windows.Forms.TabPage managementPanel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.LinkLabel authorLink2;
        private System.Windows.Forms.Button clearServiceLogButton;
        private System.Windows.Forms.Button showDefServiceButton;
        private System.Windows.Forms.Button deleteInstallStateButton;
        private System.Windows.Forms.Button resetConfigButton;
    }
}
