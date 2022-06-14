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
            this.AutoLoadGameSettingsCheckbox = new System.Windows.Forms.CheckBox();
            this.AutoLoadHostSettingsCheckbox = new System.Windows.Forms.CheckBox();
            this.DiscordWebhookCheckbox = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.WebhookMessagesGroup = new System.Windows.Forms.GroupBox();
            this.UpdateWaitTextbox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.UpdateFoundTextbox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.UnableStartTextbox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.StoppedCrashTextbox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.StopMessageTextbox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.StartMessageTextbox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.AutoUpdateInterval = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.AutoLoadGameSettingsTextbox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SelectAutoLoadGameSettingsFileButton = new System.Windows.Forms.Button();
            this.SelectAutoLoadHostSettingsFileButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.AutoLoadHostSettingsTextbox = new System.Windows.Forms.TextBox();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.WebhookURLText = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.TestWebhookButton = new System.Windows.Forms.Button();
            this.WebhookMessagesGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AutoUpdateInterval)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(4, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server Folder:";
            // 
            // ServerFolderValue
            // 
            this.ServerFolderValue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ServerFolderValue.Location = new System.Drawing.Point(84, 4);
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
            this.SelectServerFolderButton.Location = new System.Drawing.Point(436, 4);
            this.SelectServerFolderButton.Name = "SelectServerFolderButton";
            this.SelectServerFolderButton.Size = new System.Drawing.Size(75, 23);
            this.SelectServerFolderButton.TabIndex = 2;
            this.SelectServerFolderButton.Text = "Select";
            this.SelectServerFolderButton.UseVisualStyleBackColor = true;
            this.SelectServerFolderButton.Click += new System.EventHandler(this.SelectServerFolderButton_Click);
            // 
            // SelectSaveFolderButton
            // 
            this.SelectSaveFolderButton.Location = new System.Drawing.Point(436, 34);
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
            this.SaveFolderValue.Location = new System.Drawing.Point(84, 34);
            this.SaveFolderValue.Name = "SaveFolderValue";
            this.SaveFolderValue.ReadOnly = true;
            this.SaveFolderValue.Size = new System.Drawing.Size(344, 23);
            this.SaveFolderValue.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(4, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Save Folder:";
            // 
            // SelectLogFolderButton
            // 
            this.SelectLogFolderButton.Location = new System.Drawing.Point(436, 64);
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
            this.LogFolderValue.Location = new System.Drawing.Point(84, 64);
            this.LogFolderValue.Name = "LogFolderValue";
            this.LogFolderValue.ReadOnly = true;
            this.LogFolderValue.Size = new System.Drawing.Size(344, 23);
            this.LogFolderValue.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(4, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Log Folder:";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(368, 384);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 9;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(448, 384);
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
            this.VerifyUpdateCheckbox.Location = new System.Drawing.Point(12, 100);
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
            this.AutoUpdateCheckbox.Location = new System.Drawing.Point(12, 124);
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
            this.SendMessageCheckbox.Location = new System.Drawing.Point(204, 124);
            this.SendMessageCheckbox.Name = "SendMessageCheckbox";
            this.SendMessageCheckbox.Size = new System.Drawing.Size(101, 19);
            this.SendMessageCheckbox.TabIndex = 16;
            this.SendMessageCheckbox.Text = "Send Message";
            this.toolTip1.SetToolTip(this.SendMessageCheckbox, "If the server should announce the restart for the update and wait 5 minutes befor" +
        "e updating.\r\nWARNING: Requires RCON enabled and set up in the RCON Console.");
            this.SendMessageCheckbox.UseVisualStyleBackColor = true;
            // 
            // AutoLoadGameSettingsCheckbox
            // 
            this.AutoLoadGameSettingsCheckbox.AutoSize = true;
            this.AutoLoadGameSettingsCheckbox.Location = new System.Drawing.Point(4, 8);
            this.AutoLoadGameSettingsCheckbox.Name = "AutoLoadGameSettingsCheckbox";
            this.AutoLoadGameSettingsCheckbox.Size = new System.Drawing.Size(157, 19);
            this.AutoLoadGameSettingsCheckbox.TabIndex = 17;
            this.AutoLoadGameSettingsCheckbox.Text = "Auto Load GameSettings";
            this.toolTip1.SetToolTip(this.AutoLoadGameSettingsCheckbox, "If enabled the Settings editor will automatically load this file when opened.");
            this.AutoLoadGameSettingsCheckbox.UseVisualStyleBackColor = true;
            // 
            // AutoLoadHostSettingsCheckbox
            // 
            this.AutoLoadHostSettingsCheckbox.AutoSize = true;
            this.AutoLoadHostSettingsCheckbox.Location = new System.Drawing.Point(4, 56);
            this.AutoLoadHostSettingsCheckbox.Name = "AutoLoadHostSettingsCheckbox";
            this.AutoLoadHostSettingsCheckbox.Size = new System.Drawing.Size(151, 19);
            this.AutoLoadHostSettingsCheckbox.TabIndex = 21;
            this.AutoLoadHostSettingsCheckbox.Text = "Auto Load HostSettings";
            this.toolTip1.SetToolTip(this.AutoLoadHostSettingsCheckbox, "If enabled the Server Settings editor will automatically load this file when open" +
        "ed.");
            this.AutoLoadHostSettingsCheckbox.UseVisualStyleBackColor = true;
            // 
            // DiscordWebhookCheckbox
            // 
            this.DiscordWebhookCheckbox.AutoSize = true;
            this.DiscordWebhookCheckbox.Location = new System.Drawing.Point(4, 8);
            this.DiscordWebhookCheckbox.Name = "DiscordWebhookCheckbox";
            this.DiscordWebhookCheckbox.Size = new System.Drawing.Size(158, 19);
            this.DiscordWebhookCheckbox.TabIndex = 25;
            this.DiscordWebhookCheckbox.Text = "Enable Discord Webhook";
            this.toolTip1.SetToolTip(this.DiscordWebhookCheckbox, "Enable discord webhook integration.");
            this.DiscordWebhookCheckbox.UseVisualStyleBackColor = true;
            this.DiscordWebhookCheckbox.CheckedChanged += new System.EventHandler(this.DiscordWebhookCheckbox_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 15);
            this.label8.TabIndex = 27;
            this.label8.Text = "URL:";
            this.toolTip1.SetToolTip(this.label8, "The URL of your discord webhook.");
            // 
            // WebhookMessagesGroup
            // 
            this.WebhookMessagesGroup.BackColor = System.Drawing.Color.Transparent;
            this.WebhookMessagesGroup.Controls.Add(this.UpdateWaitTextbox);
            this.WebhookMessagesGroup.Controls.Add(this.label14);
            this.WebhookMessagesGroup.Controls.Add(this.UpdateFoundTextbox);
            this.WebhookMessagesGroup.Controls.Add(this.label13);
            this.WebhookMessagesGroup.Controls.Add(this.UnableStartTextbox);
            this.WebhookMessagesGroup.Controls.Add(this.label12);
            this.WebhookMessagesGroup.Controls.Add(this.StoppedCrashTextbox);
            this.WebhookMessagesGroup.Controls.Add(this.label11);
            this.WebhookMessagesGroup.Controls.Add(this.StopMessageTextbox);
            this.WebhookMessagesGroup.Controls.Add(this.label10);
            this.WebhookMessagesGroup.Controls.Add(this.StartMessageTextbox);
            this.WebhookMessagesGroup.Controls.Add(this.label9);
            this.WebhookMessagesGroup.Enabled = false;
            this.WebhookMessagesGroup.Location = new System.Drawing.Point(8, 64);
            this.WebhookMessagesGroup.Name = "WebhookMessagesGroup";
            this.WebhookMessagesGroup.Size = new System.Drawing.Size(496, 280);
            this.WebhookMessagesGroup.TabIndex = 30;
            this.WebhookMessagesGroup.TabStop = false;
            this.WebhookMessagesGroup.Text = "Customize Messages";
            this.toolTip1.SetToolTip(this.WebhookMessagesGroup, "Set custom messages on certain events. Leave blank to disable the message.");
            // 
            // UpdateWaitTextbox
            // 
            this.UpdateWaitTextbox.Location = new System.Drawing.Point(8, 240);
            this.UpdateWaitTextbox.Name = "UpdateWaitTextbox";
            this.UpdateWaitTextbox.Size = new System.Drawing.Size(480, 23);
            this.UpdateWaitTextbox.TabIndex = 39;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 224);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(159, 15);
            this.label14.TabIndex = 38;
            this.label14.Text = "Auto-Update wait 5 minutes:";
            // 
            // UpdateFoundTextbox
            // 
            this.UpdateFoundTextbox.Location = new System.Drawing.Point(8, 200);
            this.UpdateFoundTextbox.Name = "UpdateFoundTextbox";
            this.UpdateFoundTextbox.Size = new System.Drawing.Size(480, 23);
            this.UpdateFoundTextbox.TabIndex = 37;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 184);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(114, 15);
            this.label13.TabIndex = 36;
            this.label13.Text = "Auto-Update found:";
            // 
            // UnableStartTextbox
            // 
            this.UnableStartTextbox.Location = new System.Drawing.Point(8, 160);
            this.UnableStartTextbox.Name = "UnableStartTextbox";
            this.UnableStartTextbox.Size = new System.Drawing.Size(480, 23);
            this.UnableStartTextbox.TabIndex = 35;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 144);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(128, 15);
            this.label12.TabIndex = 34;
            this.label12.Text = "Unable to start 5 times:";
            // 
            // StoppedCrashTextbox
            // 
            this.StoppedCrashTextbox.Location = new System.Drawing.Point(8, 120);
            this.StoppedCrashTextbox.Name = "StoppedCrashTextbox";
            this.StoppedCrashTextbox.Size = new System.Drawing.Size(480, 23);
            this.StoppedCrashTextbox.TabIndex = 33;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 104);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(128, 15);
            this.label11.TabIndex = 32;
            this.label11.Text = "Stopped unexpectedly:";
            // 
            // StopMessageTextbox
            // 
            this.StopMessageTextbox.Location = new System.Drawing.Point(8, 80);
            this.StopMessageTextbox.Name = "StopMessageTextbox";
            this.StopMessageTextbox.Size = new System.Drawing.Size(480, 23);
            this.StopMessageTextbox.TabIndex = 31;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 64);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 15);
            this.label10.TabIndex = 30;
            this.label10.Text = "Stop server:";
            // 
            // StartMessageTextbox
            // 
            this.StartMessageTextbox.Location = new System.Drawing.Point(8, 40);
            this.StartMessageTextbox.Name = "StartMessageTextbox";
            this.StartMessageTextbox.Size = new System.Drawing.Size(480, 23);
            this.StartMessageTextbox.TabIndex = 29;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 15);
            this.label9.TabIndex = 28;
            this.label9.Text = "Start server:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "Every";
            // 
            // AutoUpdateInterval
            // 
            this.AutoUpdateInterval.Enabled = false;
            this.AutoUpdateInterval.Location = new System.Drawing.Point(52, 148);
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
            this.label5.Location = new System.Drawing.Point(108, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 15);
            this.label5.TabIndex = 15;
            this.label5.Text = "Minutes";
            // 
            // AutoLoadGameSettingsTextbox
            // 
            this.AutoLoadGameSettingsTextbox.Location = new System.Drawing.Point(36, 28);
            this.AutoLoadGameSettingsTextbox.Name = "AutoLoadGameSettingsTextbox";
            this.AutoLoadGameSettingsTextbox.ReadOnly = true;
            this.AutoLoadGameSettingsTextbox.Size = new System.Drawing.Size(384, 23);
            this.AutoLoadGameSettingsTextbox.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 15);
            this.label6.TabIndex = 19;
            this.label6.Text = "File:";
            // 
            // SelectAutoLoadGameSettingsFileButton
            // 
            this.SelectAutoLoadGameSettingsFileButton.Location = new System.Drawing.Point(428, 28);
            this.SelectAutoLoadGameSettingsFileButton.Name = "SelectAutoLoadGameSettingsFileButton";
            this.SelectAutoLoadGameSettingsFileButton.Size = new System.Drawing.Size(75, 23);
            this.SelectAutoLoadGameSettingsFileButton.TabIndex = 20;
            this.SelectAutoLoadGameSettingsFileButton.Text = "Select";
            this.SelectAutoLoadGameSettingsFileButton.UseVisualStyleBackColor = true;
            this.SelectAutoLoadGameSettingsFileButton.Click += new System.EventHandler(this.SelectAutoLoadGameSettingsFileButton_Click);
            // 
            // SelectAutoLoadHostSettingsFileButton
            // 
            this.SelectAutoLoadHostSettingsFileButton.Location = new System.Drawing.Point(428, 76);
            this.SelectAutoLoadHostSettingsFileButton.Name = "SelectAutoLoadHostSettingsFileButton";
            this.SelectAutoLoadHostSettingsFileButton.Size = new System.Drawing.Size(75, 23);
            this.SelectAutoLoadHostSettingsFileButton.TabIndex = 24;
            this.SelectAutoLoadHostSettingsFileButton.Text = "Select";
            this.SelectAutoLoadHostSettingsFileButton.UseVisualStyleBackColor = true;
            this.SelectAutoLoadHostSettingsFileButton.Click += new System.EventHandler(this.SelectAutoLoadHostSettingsFileButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 15);
            this.label7.TabIndex = 23;
            this.label7.Text = "File:";
            // 
            // AutoLoadHostSettingsTextbox
            // 
            this.AutoLoadHostSettingsTextbox.Location = new System.Drawing.Point(36, 76);
            this.AutoLoadHostSettingsTextbox.Name = "AutoLoadHostSettingsTextbox";
            this.AutoLoadHostSettingsTextbox.ReadOnly = true;
            this.AutoLoadHostSettingsTextbox.Size = new System.Drawing.Size(384, 23);
            this.AutoLoadHostSettingsTextbox.TabIndex = 22;
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.DefaultExt = "json";
            this.OpenFileDialog.Filter = "\"JSON files\"|*.json";
            // 
            // WebhookURLText
            // 
            this.WebhookURLText.Location = new System.Drawing.Point(36, 28);
            this.WebhookURLText.Name = "WebhookURLText";
            this.WebhookURLText.ReadOnly = true;
            this.WebhookURLText.Size = new System.Drawing.Size(404, 23);
            this.WebhookURLText.TabIndex = 26;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(8, 8);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(520, 376);
            this.tabControl1.TabIndex = 28;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.LightGray;
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.ServerFolderValue);
            this.tabPage1.Controls.Add(this.SelectServerFolderButton);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.SaveFolderValue);
            this.tabPage1.Controls.Add(this.SelectSaveFolderButton);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.LogFolderValue);
            this.tabPage1.Controls.Add(this.SelectLogFolderButton);
            this.tabPage1.Controls.Add(this.VerifyUpdateCheckbox);
            this.tabPage1.Controls.Add(this.AutoUpdateCheckbox);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.SendMessageCheckbox);
            this.tabPage1.Controls.Add(this.AutoUpdateInterval);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(512, 348);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Manager";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.LightGray;
            this.tabPage2.Controls.Add(this.AutoLoadGameSettingsCheckbox);
            this.tabPage2.Controls.Add(this.AutoLoadGameSettingsTextbox);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.SelectAutoLoadGameSettingsFileButton);
            this.tabPage2.Controls.Add(this.SelectAutoLoadHostSettingsFileButton);
            this.tabPage2.Controls.Add(this.AutoLoadHostSettingsCheckbox);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.AutoLoadHostSettingsTextbox);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(512, 348);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Editors";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.LightGray;
            this.tabPage3.Controls.Add(this.TestWebhookButton);
            this.tabPage3.Controls.Add(this.WebhookMessagesGroup);
            this.tabPage3.Controls.Add(this.DiscordWebhookCheckbox);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.WebhookURLText);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(512, 348);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Webhook";
            // 
            // TestWebhookButton
            // 
            this.TestWebhookButton.Enabled = false;
            this.TestWebhookButton.Location = new System.Drawing.Point(448, 28);
            this.TestWebhookButton.Name = "TestWebhookButton";
            this.TestWebhookButton.Size = new System.Drawing.Size(59, 23);
            this.TestWebhookButton.TabIndex = 31;
            this.TestWebhookButton.Text = "Test";
            this.toolTip1.SetToolTip(this.TestWebhookButton, "Tests the webhook.");
            this.TestWebhookButton.UseVisualStyleBackColor = true;
            this.TestWebhookButton.Click += new System.EventHandler(this.TestWebhookButton_Click);
            // 
            // AppSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 413);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SaveButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AppSettings";
            this.Text = "Manager Settings";
            this.WebhookMessagesGroup.ResumeLayout(false);
            this.WebhookMessagesGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AutoUpdateInterval)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.CheckBox AutoLoadGameSettingsCheckbox;
        private System.Windows.Forms.TextBox AutoLoadGameSettingsTextbox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button SelectAutoLoadGameSettingsFileButton;
        private System.Windows.Forms.CheckBox AutoLoadHostSettingsCheckbox;
        private System.Windows.Forms.Button SelectAutoLoadHostSettingsFileButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox AutoLoadHostSettingsTextbox;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.CheckBox DiscordWebhookCheckbox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox WebhookURLText;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox WebhookMessagesGroup;
        private System.Windows.Forms.TextBox UpdateWaitTextbox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox UpdateFoundTextbox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox UnableStartTextbox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox StoppedCrashTextbox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox StopMessageTextbox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox StartMessageTextbox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button TestWebhookButton;
    }
}