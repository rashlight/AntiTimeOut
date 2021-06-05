namespace AntiTimeOut
{
    partial class OOTBeepConfigForm
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
            this.sfxNameListBox = new System.Windows.Forms.ListBox();
            this.folderChooseCutton = new System.Windows.Forms.Button();
            this.dirTextBox = new System.Windows.Forms.TextBox();
            this.OKButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.testSoundButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // sfxNameListBox
            // 
            this.sfxNameListBox.Font = new System.Drawing.Font("Roboto Mono", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sfxNameListBox.FormattingEnabled = true;
            this.sfxNameListBox.ItemHeight = 18;
            this.sfxNameListBox.Location = new System.Drawing.Point(12, 53);
            this.sfxNameListBox.Name = "sfxNameListBox";
            this.sfxNameListBox.Size = new System.Drawing.Size(383, 364);
            this.sfxNameListBox.TabIndex = 0;
            // 
            // folderChooseCutton
            // 
            this.folderChooseCutton.Font = new System.Drawing.Font("Red Hat Display", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.folderChooseCutton.Location = new System.Drawing.Point(362, 12);
            this.folderChooseCutton.Name = "folderChooseCutton";
            this.folderChooseCutton.Size = new System.Drawing.Size(33, 31);
            this.folderChooseCutton.TabIndex = 2;
            this.folderChooseCutton.Text = "...";
            this.folderChooseCutton.UseVisualStyleBackColor = true;
            this.folderChooseCutton.Click += new System.EventHandler(this.folderChooseCutton_Click);
            // 
            // dirTextBox
            // 
            this.dirTextBox.Font = new System.Drawing.Font("Red Hat Display", 10F);
            this.dirTextBox.Location = new System.Drawing.Point(12, 12);
            this.dirTextBox.Name = "dirTextBox";
            this.dirTextBox.ReadOnly = true;
            this.dirTextBox.Size = new System.Drawing.Size(344, 30);
            this.dirTextBox.TabIndex = 3;
            // 
            // OKButton
            // 
            this.OKButton.Font = new System.Drawing.Font("Roboto Mono", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OKButton.Location = new System.Drawing.Point(138, 426);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(128, 31);
            this.OKButton.TabIndex = 4;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Font = new System.Drawing.Font("Roboto Mono", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(272, 426);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(123, 31);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // testSoundButton
            // 
            this.testSoundButton.Font = new System.Drawing.Font("Roboto Mono", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testSoundButton.Location = new System.Drawing.Point(12, 426);
            this.testSoundButton.Name = "testSoundButton";
            this.testSoundButton.Size = new System.Drawing.Size(120, 31);
            this.testSoundButton.TabIndex = 6;
            this.testSoundButton.Text = "Test Sound";
            this.testSoundButton.UseVisualStyleBackColor = true;
            this.testSoundButton.Click += new System.EventHandler(this.testSoundButton_Click);
            // 
            // OOTBeepConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 465);
            this.ControlBox = false;
            this.Controls.Add(this.testSoundButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.dirTextBox);
            this.Controls.Add(this.folderChooseCutton);
            this.Controls.Add(this.sfxNameListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OOTBeepConfigForm";
            this.Text = "AntiTimeOut - Select a sound file... (.wav)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox sfxNameListBox;
        private System.Windows.Forms.Button folderChooseCutton;
        private System.Windows.Forms.TextBox dirTextBox;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button testSoundButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    }
}