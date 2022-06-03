namespace ServerManager
{
    partial class AppSettings
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.ServerFolderValue = new System.Windows.Forms.TextBox();
            this.OpenFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SelectServerFolderButton = new System.Windows.Forms.Button();
            this.SelectSaveFolderButton = new System.Windows.Forms.Button();
            this.SaveFolderValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SelectLogFolderButton = new System.Windows.Forms.Button();
            this.LogFolderValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.VerifyUpdateCheckbox = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.AutoUpdateCheckbox = new System.Windows.Forms.CheckBox();
            this.SendMessageCheckbox = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.AutoUpdateInterval = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.AutoUpdateInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(0, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server Folder:";
            // 
            // ServerFolderValue
            // 
            this.ServerFolderValue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ServerFolderValue.Location = new System.Drawing.Point(80, 8);
            this.ServerFolderValue.Name = "ServerFolderValue";
            this.ServerFolderValue.ReadOnly = true;
            this.ServerFolderValue.Size = new System.Drawing.Size(344, 23);
            this.ServerFolderValue.TabIndex = 1;
            // 
            // OpenFolderDialog
            // 
            this.OpenFolderDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // SelectServerFolderButton
            // 
            this.SelectServerFolderButton.Location = new System.Drawing.Point(432, 8);
            this.SelectServerFolderButton.Name = "SelectServerFolderButton";
            this.SelectServerFolderButton.Size = new System.Drawing.Size(75, 23);
            this.SelectServerFolderButton.TabIndex = 2;
            this.SelectServerFolderButton.Text = "Select";
            this.SelectServerFolderButton.UseVisualStyleBackColor = true;
            this.SelectServerFolderButton.Click += new System.EventHandler(this.SelectServerFolderButton_Click);
            // 
            // SelectSaveFolderButton
            // 
            this.SelectSaveFolderButton.Location = new System.Drawing.Point(432, 38);
            this.SelectSaveFolderButton.Name = "SelectSaveFolderButton";
            this.SelectSaveFolderButton.Size = new System.Drawing.Size(75, 23);
            this.SelectSaveFolderButton.TabIndex = 5;
            this.SelectSaveFolderButton.Text = "Select";
            this.SelectSaveFolderButton.UseVisualStyleBackColor = true;
            this.SelectSaveFolderButton.Click += new System.EventHandler(this.SelectSaveFolderButton_Click);
            // 
            // SaveFolderValue
            // 
            this.SaveFolderValue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.SaveFolderValue.Location = new System.Drawing.Point(80, 38);
            this.SaveFolderValue.Name = "SaveFolderValue";
            this.SaveFolderValue.ReadOnly = true;
            this.SaveFolderValue.Size = new System.Drawing.Size(344, 23);
            this.SaveFolderValue.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(0, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Save Folder:";
            // 
            // SelectLogFolderButton
            // 
            this.SelectLogFolderButton.Location = new System.Drawing.Point(432, 68);
            this.SelectLogFolderButton.Name = "SelectLogFolderButton";
            this.SelectLogFolderButton.Size = new System.Drawing.Size(75, 23);
            this.SelectLogFolderButton.TabIndex = 8;
            this.SelectLogFolderButton.Text = "Select";
            this.SelectLogFolderButton.UseVisualStyleBackColor = true;
            this.SelectLogFolderButton.Click += new System.EventHandler(this.SelectLogFolderButton_Click);
            // 
            // LogFolderValue
            // 
            this.LogFolderValue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.LogFolderValue.Location = new System.Drawing.Point(80, 68);
            this.LogFolderValue.Name = "LogFolderValue";
            this.LogFolderValue.ReadOnly = true;
            this.LogFolderValue.Size = new System.Drawing.Size(344, 23);
            this.LogFolderValue.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(0, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Log Folder:";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(352, 160);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 9;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(432, 160);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 10;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // VerifyUpdateCheckbox
            // 
            this.VerifyUpdateCheckbox.AutoSize = true;
            this.VerifyUpdateCheckbox.Location = new System.Drawing.Point(8, 104);
            this.VerifyUpdateCheckbox.Name = "VerifyUpdateCheckbox";
            this.VerifyUpdateCheckbox.Size = new System.Drawing.Size(101, 19);
            this.VerifyUpdateCheckbox.TabIndex = 11;
            this.VerifyUpdateCheckbox.Text = "Verify Updates";
            this.toolTip1.SetToolTip(this.VerifyUpdateCheckbox, "If SteamCMD should verify the installation after updating.");
            this.VerifyUpdateCheckbox.UseVisualStyleBackColor = true;
            // 
            // AutoUpdateCheckbox
            // 
            this.AutoUpdateCheckbox.AutoSize = true;
            this.AutoUpdateCheckbox.Location = new System.Drawing.Point(8, 128);
            this.AutoUpdateCheckbox.Name = "AutoUpdateCheckbox";
            this.AutoUpdateCheckbox.Size = new System.Drawing.Size(189, 19);
            this.AutoUpdateCheckbox.TabIndex = 12;
            this.AutoUpdateCheckbox.Text = "Automatically look for updates";
            this.toolTip1.SetToolTip(this.AutoUpdateCheckbox, "Will automatically look for updates at a set interval.");
            this.AutoUpdateCheckbox.UseVisualStyleBackColor = true;
            this.AutoUpdateCheckbox.CheckStateChanged += new System.EventHandler(this.AutoUpdateCheckbox_CheckStateChanged);
            // 
            // SendMessageCheckbox
            // 
            this.SendMessageCheckbox.AutoSize = true;
            this.SendMessageCheckbox.Enabled = false;
            this.SendMessageCheckbox.Location = new System.Drawing.Point(200, 128);
            this.SendMessageCheckbox.Name = "SendMessageCheckbox";
            this.SendMessageCheckbox.Size = new System.Drawing.Size(101, 19);
            this.SendMessageCheckbox.TabIndex = 16;
            this.SendMessageCheckbox.Text = "Send Message";
            this.toolTip1.SetToolTip(this.SendMessageCheckbox, "If the server should announce the restart for the update and wait 5 minutes befor" +
        "e updating.\r\nWARNING: Requires RCON enabled and set up in the RCON Console.");
            this.SendMessageCheckbox.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "Every";
            // 
            // AutoUpdateInterval
            // 
            this.AutoUpdateInterval.Enabled = false;
            this.AutoUpdateInterval.Location = new System.Drawing.Point(48, 152);
            this.AutoUpdateInterval.Maximum = new decimal(new int[] {
            720,
            0,
            0,
            0});
            this.AutoUpdateInterval.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.AutoUpdateInterval.Name = "AutoUpdateInterval";
            this.AutoUpdateInterval.Size = new System.Drawing.Size(48, 23);
            this.AutoUpdateInterval.TabIndex = 14;
            this.AutoUpdateInterval.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(104, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 15);
            this.label5.TabIndex = 15;
            this.label5.Text = "Minutes";
            // 
            // AppSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 187);
            this.Controls.Add(this.SendMessageCheckbox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.AutoUpdateInterval);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.AutoUpdateCheckbox);
            this.Controls.Add(this.VerifyUpdateCheckbox);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.SelectLogFolderButton);
            this.Controls.Add(this.LogFolderValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SelectSaveFolderButton);
            this.Controls.Add(this.SaveFolderValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SelectServerFolderButton);
            this.Controls.Add(this.ServerFolderValue);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AppSettings";
            this.Text = "AppSettings";
            ((System.ComponentModel.ISupportInitialize)(this.AutoUpdateInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ServerFolderValue;
        private System.Windows.Forms.FolderBrowserDialog OpenFolderDialog;
        private System.Windows.Forms.Button SelectServerFolderButton;
        private System.Windows.Forms.Button SelectSaveFolderButton;
        private System.Windows.Forms.TextBox SaveFolderValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SelectLogFolderButton;
        private System.Windows.Forms.TextBox LogFolderValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.CheckBox VerifyUpdateCheckbox;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox AutoUpdateCheckbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown AutoUpdateInterval;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox SendMessageCheckbox;
    }
}