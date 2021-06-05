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
            this.tabControl1 = new System.Windows.Forms.TabControl();
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
            this.saiTextBox = new System.Windows.Forms.TextBox();
            this.saiSaveButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.handlingPanel = new System.Windows.Forms.TabPage();
            this.sbsModeCheckBox = new System.Windows.Forms.CheckBox();
            this.nvsModeCheckBox = new System.Windows.Forms.CheckBox();
            this.adminRestartButton = new System.Windows.Forms.Button();
            this.systrayCheckBox = new System.Windows.Forms.CheckBox();
            this.versionTextBox = new System.Windows.Forms.TextBox();
            this.authorLink = new System.Windows.Forms.LinkLabel();
            this.osStartupCheckBox = new System.Windows.Forms.CheckBox();
            this.clientSettingsWatcher = new System.IO.FileSystemWatcher();
            this.troubleshootPanel = new System.Windows.Forms.TabPage();
            this.syncServerConfigCheckBox = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.intervalPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.troubleshootTab.SuspendLayout();
            this.handlingPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientSettingsWatcher)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimeTextBox
            // 
            this.dateTimeTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dateTimeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.intervalPanel);
            this.tabControl1.Controls.Add(this.troubleshootTab);
            this.tabControl1.Controls.Add(this.handlingPanel);
            this.tabControl1.Location = new System.Drawing.Point(3, 102);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(365, 272);
            this.tabControl1.TabIndex = 9;
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
            this.lastRecordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lastRecordTextBox.Location = new System.Drawing.Point(6, 99);
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
            this.serviceStatusTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serviceStatusTextBox.Location = new System.Drawing.Point(6, 23);
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
            // saiTextBox
            // 
            this.saiTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.saiTextBox.Location = new System.Drawing.Point(31, 107);
            this.saiTextBox.Name = "saiTextBox";
            this.saiTextBox.Size = new System.Drawing.Size(301, 24);
            this.saiTextBox.TabIndex = 23;
            this.saiTextBox.Text = "1000";
            this.saiTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // saiSaveButton
            // 
            this.saiSaveButton.Location = new System.Drawing.Point(116, 170);
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
            this.label1.Location = new System.Drawing.Point(51, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 25);
            this.label1.TabIndex = 20;
            this.label1.Text = "Service Polling Interval (ms):";
            // 
            // handlingPanel
            // 
            this.handlingPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.handlingPanel.Controls.Add(this.sbsModeCheckBox);
            this.handlingPanel.Controls.Add(this.nvsModeCheckBox);
            this.handlingPanel.Controls.Add(this.adminRestartButton);
            this.handlingPanel.Controls.Add(this.systrayCheckBox);
            this.handlingPanel.Controls.Add(this.versionTextBox);
            this.handlingPanel.Controls.Add(this.authorLink);
            this.handlingPanel.Controls.Add(this.osStartupCheckBox);
            this.handlingPanel.Location = new System.Drawing.Point(4, 25);
            this.handlingPanel.Name = "handlingPanel";
            this.handlingPanel.Size = new System.Drawing.Size(357, 243);
            this.handlingPanel.TabIndex = 2;
            this.handlingPanel.Text = "Handlings";
            // 
            // sbsModeCheckBox
            // 
            this.sbsModeCheckBox.AutoSize = true;
            this.sbsModeCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.sbsModeCheckBox.Location = new System.Drawing.Point(101, 89);
            this.sbsModeCheckBox.Name = "sbsModeCheckBox";
            this.sbsModeCheckBox.Size = new System.Drawing.Size(155, 21);
            this.sbsModeCheckBox.TabIndex = 6;
            this.sbsModeCheckBox.Text = "Side-by-side Clients";
            this.sbsModeCheckBox.UseVisualStyleBackColor = true;
            this.sbsModeCheckBox.CheckedChanged += new System.EventHandler(this.sbsModeCheckBox_CheckedChanged);
            // 
            // nvsModeCheckBox
            // 
            this.nvsModeCheckBox.AutoSize = true;
            this.nvsModeCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.nvsModeCheckBox.Location = new System.Drawing.Point(86, 61);
            this.nvsModeCheckBox.Name = "nvsModeCheckBox";
            this.nvsModeCheckBox.Size = new System.Drawing.Size(191, 21);
            this.nvsModeCheckBox.TabIndex = 5;
            this.nvsModeCheckBox.Text = "Non-Visible Startup Mode";
            this.nvsModeCheckBox.UseVisualStyleBackColor = true;
            this.nvsModeCheckBox.CheckedChanged += new System.EventHandler(this.nvsModeCheckBox_CheckedChanged);
            // 
            // adminRestartButton
            // 
            this.adminRestartButton.Location = new System.Drawing.Point(81, 148);
            this.adminRestartButton.Name = "adminRestartButton";
            this.adminRestartButton.Size = new System.Drawing.Size(196, 28);
            this.adminRestartButton.TabIndex = 4;
            this.adminRestartButton.Text = " Restart as Administrator";
            this.adminRestartButton.UseVisualStyleBackColor = true;
            this.adminRestartButton.Click += new System.EventHandler(this.adminRestartButton_Click);
            // 
            // systrayCheckBox
            // 
            this.systrayCheckBox.AutoSize = true;
            this.systrayCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.systrayCheckBox.Location = new System.Drawing.Point(121, 117);
            this.systrayCheckBox.Name = "systrayCheckBox";
            this.systrayCheckBox.Size = new System.Drawing.Size(116, 21);
            this.systrayCheckBox.TabIndex = 2;
            this.systrayCheckBox.Text = "Systray Mode";
            this.systrayCheckBox.UseVisualStyleBackColor = true;
            this.systrayCheckBox.CheckedChanged += new System.EventHandler(this.systrayCheckBox_CheckedChanged);
            // 
            // versionTextBox
            // 
            this.versionTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.versionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.versionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.versionTextBox.Location = new System.Drawing.Point(3, 200);
            this.versionTextBox.Name = "versionTextBox";
            this.versionTextBox.ReadOnly = true;
            this.versionTextBox.Size = new System.Drawing.Size(351, 17);
            this.versionTextBox.TabIndex = 1;
            this.versionTextBox.Text = "Version X.X.X.X, Windows XX-bit, .NET XX.X ";
            this.versionTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // authorLink
            // 
            this.authorLink.Location = new System.Drawing.Point(3, 218);
            this.authorLink.Name = "authorLink";
            this.authorLink.Size = new System.Drawing.Size(351, 17);
            this.authorLink.TabIndex = 0;
            this.authorLink.TabStop = true;
            this.authorLink.Text = "@rashlight 2020-2021";
            this.authorLink.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.authorLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.authorLink_LinkClicked);
            // 
            // osStartupCheckBox
            // 
            this.osStartupCheckBox.AutoSize = true;
            this.osStartupCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.osStartupCheckBox.Location = new System.Drawing.Point(64, 33);
            this.osStartupCheckBox.Name = "osStartupCheckBox";
            this.osStartupCheckBox.Size = new System.Drawing.Size(237, 21);
            this.osStartupCheckBox.TabIndex = 0;
            this.osStartupCheckBox.Text = "Run the program when OS starts";
            this.osStartupCheckBox.UseVisualStyleBackColor = true;
            this.osStartupCheckBox.CheckedChanged += new System.EventHandler(this.osStartupCheckBox_CheckedChanged);
            // 
            // clientSettingsWatcher
            // 
            this.clientSettingsWatcher.EnableRaisingEvents = true;
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
            // syncServerConfigCheckBox
            // 
            this.syncServerConfigCheckBox.AutoSize = true;
            this.syncServerConfigCheckBox.Location = new System.Drawing.Point(95, 141);
            this.syncServerConfigCheckBox.Name = "syncServerConfigCheckBox";
            this.syncServerConfigCheckBox.Size = new System.Drawing.Size(175, 21);
            this.syncServerConfigCheckBox.TabIndex = 24;
            this.syncServerConfigCheckBox.Text = "Sync with server config";
            this.syncServerConfigCheckBox.UseVisualStyleBackColor = true;
            // 
            // ClientControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.dateTimeTextBox);
            this.Name = "ClientControl";
            this.Size = new System.Drawing.Size(371, 377);
            this.Load += new System.EventHandler(this.ClientControl_Load);
            this.tabControl1.ResumeLayout(false);
            this.intervalPanel.ResumeLayout(false);
            this.intervalPanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.troubleshootTab.ResumeLayout(false);
            this.troubleshootTab.PerformLayout();
            this.handlingPanel.ResumeLayout(false);
            this.handlingPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientSettingsWatcher)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox dateTimeTextBox;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.TabControl tabControl1;
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
        private System.Windows.Forms.TabPage handlingPanel;
        private System.Windows.Forms.CheckBox osStartupCheckBox;
        private System.Windows.Forms.LinkLabel authorLink;
        private System.Windows.Forms.TextBox versionTextBox;
        private System.Windows.Forms.CheckBox systrayCheckBox;
        private System.Windows.Forms.Button adminRestartButton;
        private System.Windows.Forms.Button ootSettingsButton;
        private System.Windows.Forms.CheckBox nvsModeCheckBox;
        private System.Windows.Forms.CheckBox ootRunOnceCheckBox;
        private System.Windows.Forms.CheckBox sbsModeCheckBox;
        private System.Windows.Forms.CheckBox syncServerConfigCheckBox;
    }
}
