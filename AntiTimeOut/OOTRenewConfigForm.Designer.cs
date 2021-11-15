namespace AntiTimeOut
{
    partial class OOTRenewConfigForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ssidTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.networkInterfaceComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.networkNameTextBox = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Red Hat Display", 10F);
            this.label1.Location = new System.Drawing.Point(12, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "1: Network Name: (*)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Red Hat Display", 10F);
            this.label2.Location = new System.Drawing.Point(11, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "2: SSID:";
            // 
            // ssidTextBox
            // 
            this.ssidTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ssidTextBox.Location = new System.Drawing.Point(82, 78);
            this.ssidTextBox.Name = "ssidTextBox";
            this.ssidTextBox.Size = new System.Drawing.Size(468, 23);
            this.ssidTextBox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Red Hat Display", 10F);
            this.label3.Location = new System.Drawing.Point(11, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 22);
            this.label3.TabIndex = 5;
            this.label3.Text = "3: Interface:";
            // 
            // networkInterfaceComboBox
            // 
            this.networkInterfaceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.networkInterfaceComboBox.FormattingEnabled = true;
            this.networkInterfaceComboBox.Location = new System.Drawing.Point(116, 108);
            this.networkInterfaceComboBox.Name = "networkInterfaceComboBox";
            this.networkInterfaceComboBox.Size = new System.Drawing.Size(434, 24);
            this.networkInterfaceComboBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Red Hat Display", 12F);
            this.label4.Location = new System.Drawing.Point(34, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(489, 26);
            this.label4.TabIndex = 8;
            this.label4.Text = "(*): Required, SSID & Interface might be auto-selected.";
            this.label4.UseMnemonic = false;
            // 
            // networkNameTextBox
            // 
            this.networkNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.networkNameTextBox.Location = new System.Drawing.Point(183, 49);
            this.networkNameTextBox.Name = "networkNameTextBox";
            this.networkNameTextBox.Size = new System.Drawing.Size(367, 23);
            this.networkNameTextBox.TabIndex = 9;
            // 
            // cancelButton
            // 
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(282, 147);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(268, 31);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OKButton.Location = new System.Drawing.Point(16, 147);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(260, 31);
            this.OKButton.TabIndex = 10;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // OOTRenewConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 190);
            this.ControlBox = false;
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.networkNameTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.networkInterfaceComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ssidTextBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "OOTRenewConfigForm";
            this.Text = "AntiTimeOut - Network Config";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ssidTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox networkInterfaceComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox networkNameTextBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button OKButton;
    }
}