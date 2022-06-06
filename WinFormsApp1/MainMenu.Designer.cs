namespace ServerManager
{
    partial class MainMenu
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
            this.SettingsButton = new System.Windows.Forms.Button();
            this.ServerSettingsButton = new System.Windows.Forms.Button();
            this.SteamCMDButton = new System.Windows.Forms.Button();
            this.AppSettingsButton = new System.Windows.Forms.Button();
            this.MainMenuConsole = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.StartGameServerButton = new System.Windows.Forms.Button();
            this.StopGameServerButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.AutoRestartCheck = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ServerNameValue = new System.Windows.Forms.TextBox();
            this.SaveNameValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.OpenGameFolderButton = new System.Windows.Forms.Button();
            this.RunningPic = new System.Windows.Forms.PictureBox();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.StoppedPic = new System.Windows.Forms.PictureBox();
            this.RCONButton = new System.Windows.Forms.Button();
            this.ManageAdminsButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.BindIPTextbox = new System.Windows.Forms.TextBox();
            this.BindToIPCheckbox = new System.Windows.Forms.CheckBox();
            this.MainMenuStatusStrip = new System.Windows.Forms.StatusStrip();
            this.SteamCMDStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.SpacerLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.LastUpdateLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RunningPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StoppedPic)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.MainMenuStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // SettingsButton
            // 
            this.SettingsButton.Location = new System.Drawing.Point(8, 16);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(144, 24);
            this.SettingsButton.TabIndex = 0;
            this.SettingsButton.Text = "Settings Editor";
            this.SettingsButton.UseVisualStyleBackColor = true;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // ServerSettingsButton
            // 
            this.ServerSettingsButton.Location = new System.Drawing.Point(8, 48);
            this.ServerSettingsButton.Name = "ServerSettingsButton";
            this.ServerSettingsButton.Size = new System.Drawing.Size(144, 24);
            this.ServerSettingsButton.TabIndex = 1;
            this.ServerSettingsButton.Text = "Server Settings Editor";
            this.ServerSettingsButton.UseVisualStyleBackColor = true;
            this.ServerSettingsButton.Click += new System.EventHandler(this.ServerSettingsButton_Click);
            // 
            // SteamCMDButton
            // 
            this.SteamCMDButton.Location = new System.Drawing.Point(8, 88);
            this.SteamCMDButton.Name = "SteamCMDButton";
            this.SteamCMDButton.Size = new System.Drawing.Size(125, 24);
            this.SteamCMDButton.TabIndex = 2;
            this.SteamCMDButton.Text = "Update Game Server";
            this.SteamCMDButton.UseVisualStyleBackColor = true;
            this.SteamCMDButton.Click += new System.EventHandler(this.SteamCMDButton_Click);
            // 
            // AppSettingsButton
            // 
            this.AppSettingsButton.Location = new System.Drawing.Point(640, 168);
            this.AppSettingsButton.Name = "AppSettingsButton";
            this.AppSettingsButton.Size = new System.Drawing.Size(141, 24);
            this.AppSettingsButton.TabIndex = 3;
            this.AppSettingsButton.Text = "Manager Settings";
            this.AppSettingsButton.UseVisualStyleBackColor = true;
            this.AppSettingsButton.Click += new System.EventHandler(this.AppSettingsButton_Click);
            // 
            // MainMenuConsole
            // 
            this.MainMenuConsole.BackColor = System.Drawing.Color.Black;
            this.MainMenuConsole.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.MainMenuConsole.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MainMenuConsole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.MainMenuConsole.Location = new System.Drawing.Point(8, 288);
            this.MainMenuConsole.Name = "MainMenuConsole";
            this.MainMenuConsole.ReadOnly = true;
            this.MainMenuConsole.ShortcutsEnabled = false;
            this.MainMenuConsole.Size = new System.Drawing.Size(784, 168);
            this.MainMenuConsole.TabIndex = 4;
            this.MainMenuConsole.Text = "";
            this.MainMenuConsole.TextChanged += new System.EventHandler(this.MainMenuConsole_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SettingsButton);
            this.groupBox1.Controls.Add(this.ServerSettingsButton);
            this.groupBox1.Location = new System.Drawing.Point(632, 200);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(160, 80);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Editors";
            // 
            // StartGameServerButton
            // 
            this.StartGameServerButton.Location = new System.Drawing.Point(8, 56);
            this.StartGameServerButton.Name = "StartGameServerButton";
            this.StartGameServerButton.Size = new System.Drawing.Size(125, 24);
            this.StartGameServerButton.TabIndex = 6;
            this.StartGameServerButton.Text = "Start Game Server";
            this.StartGameServerButton.UseVisualStyleBackColor = true;
            this.StartGameServerButton.Click += new System.EventHandler(this.StartGameServerButton_Click);
            // 
            // StopGameServerButton
            // 
            this.StopGameServerButton.Enabled = false;
            this.StopGameServerButton.Location = new System.Drawing.Point(144, 56);
            this.StopGameServerButton.Name = "StopGameServerButton";
            this.StopGameServerButton.Size = new System.Drawing.Size(125, 24);
            this.StopGameServerButton.TabIndex = 7;
            this.StopGameServerButton.Text = "Stop Game Server";
            this.StopGameServerButton.UseVisualStyleBackColor = true;
            this.StopGameServerButton.Click += new System.EventHandler(this.StopGameServerButton_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            // 
            // AutoRestartCheck
            // 
            this.AutoRestartCheck.Location = new System.Drawing.Point(8, 24);
            this.AutoRestartCheck.Name = "AutoRestartCheck";
            this.AutoRestartCheck.Size = new System.Drawing.Size(91, 19);
            this.AutoRestartCheck.TabIndex = 9;
            this.AutoRestartCheck.Text = "Auto Restart";
            this.toolTip1.SetToolTip(this.AutoRestartCheck, "Automatically restarts the server unless manually stopped.");
            this.AutoRestartCheck.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Server Name:";
            // 
            // ServerNameValue
            // 
            this.ServerNameValue.Location = new System.Drawing.Point(88, 24);
            this.ServerNameValue.Name = "ServerNameValue";
            this.ServerNameValue.Size = new System.Drawing.Size(184, 23);
            this.ServerNameValue.TabIndex = 12;
            // 
            // SaveNameValue
            // 
            this.SaveNameValue.Location = new System.Drawing.Point(88, 56);
            this.SaveNameValue.Name = "SaveNameValue";
            this.SaveNameValue.Size = new System.Drawing.Size(184, 23);
            this.SaveNameValue.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 15);
            this.label2.TabIndex = 13;
            this.label2.Text = "Save Name:";
            // 
            // OpenGameFolderButton
            // 
            this.OpenGameFolderButton.Location = new System.Drawing.Point(144, 88);
            this.OpenGameFolderButton.Name = "OpenGameFolderButton";
            this.OpenGameFolderButton.Size = new System.Drawing.Size(125, 24);
            this.OpenGameFolderButton.TabIndex = 15;
            this.OpenGameFolderButton.Text = "Open Game Folder";
            this.OpenGameFolderButton.UseVisualStyleBackColor = true;
            this.OpenGameFolderButton.Click += new System.EventHandler(this.OpenGameFolderButton_Click);
            // 
            // RunningPic
            // 
            this.RunningPic.Image = global::ServerManager.Properties.Resources.running;
            this.RunningPic.Location = new System.Drawing.Point(240, 16);
            this.RunningPic.Name = "RunningPic";
            this.RunningPic.Size = new System.Drawing.Size(32, 32);
            this.RunningPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.RunningPic.TabIndex = 16;
            this.RunningPic.TabStop = false;
            this.RunningPic.Visible = false;
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(144, 24);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(51, 15);
            this.StatusLabel.TabIndex = 17;
            this.StatusLabel.Text = "Stopped";
            // 
            // StoppedPic
            // 
            this.StoppedPic.Image = global::ServerManager.Properties.Resources.stopped;
            this.StoppedPic.Location = new System.Drawing.Point(240, 16);
            this.StoppedPic.Name = "StoppedPic";
            this.StoppedPic.Size = new System.Drawing.Size(32, 32);
            this.StoppedPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.StoppedPic.TabIndex = 18;
            this.StoppedPic.TabStop = false;
            // 
            // RCONButton
            // 
            this.RCONButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RCONButton.Location = new System.Drawing.Point(8, 120);
            this.RCONButton.Name = "RCONButton";
            this.RCONButton.Size = new System.Drawing.Size(125, 24);
            this.RCONButton.TabIndex = 19;
            this.RCONButton.Text = "RCON Console";
            this.RCONButton.UseVisualStyleBackColor = true;
            this.RCONButton.Click += new System.EventHandler(this.RCONButton_Click);
            // 
            // ManageAdminsButton
            // 
            this.ManageAdminsButton.Location = new System.Drawing.Point(144, 120);
            this.ManageAdminsButton.Name = "ManageAdminsButton";
            this.ManageAdminsButton.Size = new System.Drawing.Size(125, 24);
            this.ManageAdminsButton.TabIndex = 20;
            this.ManageAdminsButton.Text = "Manage Admins";
            this.ManageAdminsButton.UseVisualStyleBackColor = true;
            this.ManageAdminsButton.Click += new System.EventHandler(this.ManageAdminsButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.StartGameServerButton);
            this.groupBox2.Controls.Add(this.StoppedPic);
            this.groupBox2.Controls.Add(this.RCONButton);
            this.groupBox2.Controls.Add(this.StatusLabel);
            this.groupBox2.Controls.Add(this.RunningPic);
            this.groupBox2.Controls.Add(this.ManageAdminsButton);
            this.groupBox2.Controls.Add(this.SteamCMDButton);
            this.groupBox2.Controls.Add(this.StopGameServerButton);
            this.groupBox2.Controls.Add(this.OpenGameFolderButton);
            this.groupBox2.Controls.Add(this.AutoRestartCheck);
            this.groupBox2.Location = new System.Drawing.Point(8, 128);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(280, 152);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Server Management";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(8, 80);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 23;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.BindIPTextbox);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.BindToIPCheckbox);
            this.groupBox3.Controls.Add(this.SaveButton);
            this.groupBox3.Controls.Add(this.ServerNameValue);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.SaveNameValue);
            this.groupBox3.Location = new System.Drawing.Point(8, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(416, 112);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Server Launch Settings";
            // 
            // BindIPTextbox
            // 
            this.BindIPTextbox.Location = new System.Drawing.Point(280, 56);
            this.BindIPTextbox.Name = "BindIPTextbox";
            this.BindIPTextbox.ReadOnly = true;
            this.BindIPTextbox.Size = new System.Drawing.Size(128, 23);
            this.BindIPTextbox.TabIndex = 1;
            // 
            // BindToIPCheckbox
            // 
            this.BindToIPCheckbox.AutoSize = true;
            this.BindToIPCheckbox.Location = new System.Drawing.Point(280, 24);
            this.BindToIPCheckbox.Name = "BindToIPCheckbox";
            this.BindToIPCheckbox.Size = new System.Drawing.Size(77, 19);
            this.BindToIPCheckbox.TabIndex = 0;
            this.BindToIPCheckbox.Text = "Bind to IP";
            this.BindToIPCheckbox.UseVisualStyleBackColor = true;
            this.BindToIPCheckbox.CheckStateChanged += new System.EventHandler(this.BindToIPCheckbox_CheckStateChanged);
            // 
            // MainMenuStatusStrip
            // 
            this.MainMenuStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SteamCMDStatusLabel,
            this.SpacerLabel,
            this.LastUpdateLabel});
            this.MainMenuStatusStrip.Location = new System.Drawing.Point(0, 458);
            this.MainMenuStatusStrip.Name = "MainMenuStatusStrip";
            this.MainMenuStatusStrip.Size = new System.Drawing.Size(800, 22);
            this.MainMenuStatusStrip.SizingGrip = false;
            this.MainMenuStatusStrip.TabIndex = 25;
            this.MainMenuStatusStrip.Text = "statusStrip1";
            // 
            // SteamCMDStatusLabel
            // 
            this.SteamCMDStatusLabel.Name = "SteamCMDStatusLabel";
            this.SteamCMDStatusLabel.Size = new System.Drawing.Size(173, 17);
            this.SteamCMDStatusLabel.Text = "SteamCMD Status: Not running";
            // 
            // SpacerLabel
            // 
            this.SpacerLabel.Name = "SpacerLabel";
            this.SpacerLabel.Size = new System.Drawing.Size(612, 17);
            this.SpacerLabel.Spring = true;
            // 
            // LastUpdateLabel
            // 
            this.LastUpdateLabel.Name = "LastUpdateLabel";
            this.LastUpdateLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 480);
            this.Controls.Add(this.MainMenuStatusStrip);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.MainMenuConsole);
            this.Controls.Add(this.AppSettingsButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainMenu";
            this.Text = "V Rising Server Manager";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RunningPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StoppedPic)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.MainMenuStatusStrip.ResumeLayout(false);
            this.MainMenuStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SettingsButton;
        private System.Windows.Forms.Button ServerSettingsButton;
        private System.Windows.Forms.Button SteamCMDButton;
        private System.Windows.Forms.Button AppSettingsButton;
        private System.Windows.Forms.RichTextBox MainMenuConsole;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button StartGameServerButton;
        private System.Windows.Forms.Button StopGameServerButton;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox AutoRestartCheck;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ServerNameValue;
        private System.Windows.Forms.TextBox SaveNameValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button OpenGameFolderButton;
        private System.Windows.Forms.PictureBox RunningPic;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.PictureBox StoppedPic;
        private System.Windows.Forms.Button RCONButton;
        private System.Windows.Forms.Button ManageAdminsButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.StatusStrip MainMenuStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel SteamCMDStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel LastUpdateLabel;
        private System.Windows.Forms.ToolStripStatusLabel SpacerLabel;
        private System.Windows.Forms.TextBox BindIPTextbox;
        private System.Windows.Forms.CheckBox BindToIPCheckbox;
    }
}