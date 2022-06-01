namespace ServerManager
{
    partial class ServerSettingsForm
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.loadFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SecureRadioFalse = new System.Windows.Forms.RadioButton();
            this.SecureRadioTrue = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ListOnMasterServerRadioFalse = new System.Windows.Forms.RadioButton();
            this.ListOnMasterServerRadioTrue = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.AdminOnlyDebugEventsRadioFalse = new System.Windows.Forms.RadioButton();
            this.AdminOnlyDebugEventsRadioTrue = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.DisableDebugEventsRadioFalse = new System.Windows.Forms.RadioButton();
            this.DisableDebugEventsRadioTrue = new System.Windows.Forms.RadioButton();
            this.NameValue = new System.Windows.Forms.TextBox();
            this.DescriptionValue = new System.Windows.Forms.TextBox();
            this.PortNumber = new System.Windows.Forms.NumericUpDown();
            this.QueryPortNumber = new System.Windows.Forms.NumericUpDown();
            this.MaxConnectedUsersNumber = new System.Windows.Forms.NumericUpDown();
            this.MaxConnectedAdminsNumber = new System.Windows.Forms.NumericUpDown();
            this.ServerFpsNumber = new System.Windows.Forms.NumericUpDown();
            this.SaveNameValue = new System.Windows.Forms.TextBox();
            this.PasswordValue = new System.Windows.Forms.TextBox();
            this.AutoSaveCountNumber = new System.Windows.Forms.NumericUpDown();
            this.AutoSaveIntervalNumber = new System.Windows.Forms.NumericUpDown();
            this.SaveServerSettingsDialog = new System.Windows.Forms.SaveFileDialog();
            this.LoadServerSettingsDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.RCONPortNumber = new System.Windows.Forms.NumericUpDown();
            this.RCONPasswordValue = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.RCONRadioFalse = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.RCONRadioTrue = new System.Windows.Forms.RadioButton();
            this.menuStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PortNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QueryPortNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxConnectedUsersNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxConnectedAdminsNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerFpsNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AutoSaveCountNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AutoSaveIntervalNumber)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RCONPortNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadFileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(370, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip2";
            // 
            // loadFileToolStripMenuItem
            // 
            this.loadFileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveFileToolStripMenuItem,
            this.saveFileToolStripMenuItem1,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.loadFileToolStripMenuItem.Name = "loadFileToolStripMenuItem";
            this.loadFileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.loadFileToolStripMenuItem.Text = "File";
            // 
            // saveFileToolStripMenuItem
            // 
            this.saveFileToolStripMenuItem.Name = "saveFileToolStripMenuItem";
            this.saveFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.saveFileToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.saveFileToolStripMenuItem.Text = "Load File";
            this.saveFileToolStripMenuItem.Click += new System.EventHandler(this.saveFileToolStripMenuItem_Click);
            // 
            // saveFileToolStripMenuItem1
            // 
            this.saveFileToolStripMenuItem1.Name = "saveFileToolStripMenuItem1";
            this.saveFileToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveFileToolStripMenuItem1.Size = new System.Drawing.Size(164, 22);
            this.saveFileToolStripMenuItem1.Text = "Save File";
            this.saveFileToolStripMenuItem1.Click += new System.EventHandler(this.saveFileToolStripMenuItem1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(161, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Port";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "QueryPort";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "MaxConnectedUsers";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 15);
            this.label6.TabIndex = 6;
            this.label6.Text = "MaxConnectedAdmins";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 176);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 15);
            this.label7.TabIndex = 7;
            this.label7.Text = "ServerFps";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 200);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 15);
            this.label8.TabIndex = 8;
            this.label8.Text = "SaveName";
            this.toolTip1.SetToolTip(this.label8, "Use save name in main window instead.");
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 224);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 15);
            this.label9.TabIndex = 9;
            this.label9.Text = "Password";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SecureRadioFalse);
            this.groupBox1.Controls.Add(this.SecureRadioTrue);
            this.groupBox1.Location = new System.Drawing.Point(8, 248);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(112, 40);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Secure";
            // 
            // SecureRadioFalse
            // 
            this.SecureRadioFalse.AutoSize = true;
            this.SecureRadioFalse.Checked = true;
            this.SecureRadioFalse.Location = new System.Drawing.Point(56, 16);
            this.SecureRadioFalse.Name = "SecureRadioFalse";
            this.SecureRadioFalse.Size = new System.Drawing.Size(51, 19);
            this.SecureRadioFalse.TabIndex = 1;
            this.SecureRadioFalse.TabStop = true;
            this.SecureRadioFalse.Text = "False";
            this.SecureRadioFalse.UseVisualStyleBackColor = true;
            // 
            // SecureRadioTrue
            // 
            this.SecureRadioTrue.AutoSize = true;
            this.SecureRadioTrue.Location = new System.Drawing.Point(8, 16);
            this.SecureRadioTrue.Name = "SecureRadioTrue";
            this.SecureRadioTrue.Size = new System.Drawing.Size(47, 19);
            this.SecureRadioTrue.TabIndex = 0;
            this.SecureRadioTrue.Text = "True";
            this.SecureRadioTrue.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ListOnMasterServerRadioFalse);
            this.groupBox2.Controls.Add(this.ListOnMasterServerRadioTrue);
            this.groupBox2.Location = new System.Drawing.Point(8, 296);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(128, 40);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ListOnMasterServer";
            // 
            // ListOnMasterServerRadioFalse
            // 
            this.ListOnMasterServerRadioFalse.AutoSize = true;
            this.ListOnMasterServerRadioFalse.Location = new System.Drawing.Point(56, 16);
            this.ListOnMasterServerRadioFalse.Name = "ListOnMasterServerRadioFalse";
            this.ListOnMasterServerRadioFalse.Size = new System.Drawing.Size(51, 19);
            this.ListOnMasterServerRadioFalse.TabIndex = 1;
            this.ListOnMasterServerRadioFalse.Text = "False";
            this.ListOnMasterServerRadioFalse.UseVisualStyleBackColor = true;
            // 
            // ListOnMasterServerRadioTrue
            // 
            this.ListOnMasterServerRadioTrue.AutoSize = true;
            this.ListOnMasterServerRadioTrue.Checked = true;
            this.ListOnMasterServerRadioTrue.Location = new System.Drawing.Point(8, 16);
            this.ListOnMasterServerRadioTrue.Name = "ListOnMasterServerRadioTrue";
            this.ListOnMasterServerRadioTrue.Size = new System.Drawing.Size(47, 19);
            this.ListOnMasterServerRadioTrue.TabIndex = 0;
            this.ListOnMasterServerRadioTrue.TabStop = true;
            this.ListOnMasterServerRadioTrue.Text = "True";
            this.ListOnMasterServerRadioTrue.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 344);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 15);
            this.label10.TabIndex = 12;
            this.label10.Text = "AutoSaveCount";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 368);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 15);
            this.label11.TabIndex = 13;
            this.label11.Text = "AutoSaveInterval";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.AdminOnlyDebugEventsRadioFalse);
            this.groupBox3.Controls.Add(this.AdminOnlyDebugEventsRadioTrue);
            this.groupBox3.Location = new System.Drawing.Point(8, 392);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(152, 40);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "AdminOnlyDebugEvents";
            // 
            // AdminOnlyDebugEventsRadioFalse
            // 
            this.AdminOnlyDebugEventsRadioFalse.AutoSize = true;
            this.AdminOnlyDebugEventsRadioFalse.Location = new System.Drawing.Point(56, 16);
            this.AdminOnlyDebugEventsRadioFalse.Name = "AdminOnlyDebugEventsRadioFalse";
            this.AdminOnlyDebugEventsRadioFalse.Size = new System.Drawing.Size(51, 19);
            this.AdminOnlyDebugEventsRadioFalse.TabIndex = 1;
            this.AdminOnlyDebugEventsRadioFalse.Text = "False";
            this.AdminOnlyDebugEventsRadioFalse.UseVisualStyleBackColor = true;
            // 
            // AdminOnlyDebugEventsRadioTrue
            // 
            this.AdminOnlyDebugEventsRadioTrue.AutoSize = true;
            this.AdminOnlyDebugEventsRadioTrue.Checked = true;
            this.AdminOnlyDebugEventsRadioTrue.Location = new System.Drawing.Point(8, 16);
            this.AdminOnlyDebugEventsRadioTrue.Name = "AdminOnlyDebugEventsRadioTrue";
            this.AdminOnlyDebugEventsRadioTrue.Size = new System.Drawing.Size(47, 19);
            this.AdminOnlyDebugEventsRadioTrue.TabIndex = 0;
            this.AdminOnlyDebugEventsRadioTrue.TabStop = true;
            this.AdminOnlyDebugEventsRadioTrue.Text = "True";
            this.AdminOnlyDebugEventsRadioTrue.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.DisableDebugEventsRadioFalse);
            this.groupBox4.Controls.Add(this.DisableDebugEventsRadioTrue);
            this.groupBox4.Location = new System.Drawing.Point(8, 440);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(128, 40);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "DisableDebugEvents";
            // 
            // DisableDebugEventsRadioFalse
            // 
            this.DisableDebugEventsRadioFalse.AutoSize = true;
            this.DisableDebugEventsRadioFalse.Checked = true;
            this.DisableDebugEventsRadioFalse.Location = new System.Drawing.Point(56, 16);
            this.DisableDebugEventsRadioFalse.Name = "DisableDebugEventsRadioFalse";
            this.DisableDebugEventsRadioFalse.Size = new System.Drawing.Size(51, 19);
            this.DisableDebugEventsRadioFalse.TabIndex = 1;
            this.DisableDebugEventsRadioFalse.TabStop = true;
            this.DisableDebugEventsRadioFalse.Text = "False";
            this.DisableDebugEventsRadioFalse.UseVisualStyleBackColor = true;
            // 
            // DisableDebugEventsRadioTrue
            // 
            this.DisableDebugEventsRadioTrue.AutoSize = true;
            this.DisableDebugEventsRadioTrue.Location = new System.Drawing.Point(8, 16);
            this.DisableDebugEventsRadioTrue.Name = "DisableDebugEventsRadioTrue";
            this.DisableDebugEventsRadioTrue.Size = new System.Drawing.Size(47, 19);
            this.DisableDebugEventsRadioTrue.TabIndex = 0;
            this.DisableDebugEventsRadioTrue.Text = "True";
            this.DisableDebugEventsRadioTrue.UseVisualStyleBackColor = true;
            // 
            // NameValue
            // 
            this.NameValue.Enabled = false;
            this.NameValue.Location = new System.Drawing.Point(168, 24);
            this.NameValue.Name = "NameValue";
            this.NameValue.Size = new System.Drawing.Size(192, 23);
            this.NameValue.TabIndex = 14;
            this.NameValue.Text = "V Rising Server";
            this.toolTip1.SetToolTip(this.NameValue, "Use server name in main window instead.");
            // 
            // DescriptionValue
            // 
            this.DescriptionValue.Location = new System.Drawing.Point(168, 48);
            this.DescriptionValue.Name = "DescriptionValue";
            this.DescriptionValue.Size = new System.Drawing.Size(192, 23);
            this.DescriptionValue.TabIndex = 15;
            // 
            // PortNumber
            // 
            this.PortNumber.Location = new System.Drawing.Point(240, 72);
            this.PortNumber.Maximum = new decimal(new int[] {
            66000,
            0,
            0,
            0});
            this.PortNumber.Name = "PortNumber";
            this.PortNumber.Size = new System.Drawing.Size(120, 23);
            this.PortNumber.TabIndex = 16;
            this.PortNumber.Value = new decimal(new int[] {
            9876,
            0,
            0,
            0});
            // 
            // QueryPortNumber
            // 
            this.QueryPortNumber.Location = new System.Drawing.Point(240, 96);
            this.QueryPortNumber.Maximum = new decimal(new int[] {
            66000,
            0,
            0,
            0});
            this.QueryPortNumber.Name = "QueryPortNumber";
            this.QueryPortNumber.Size = new System.Drawing.Size(120, 23);
            this.QueryPortNumber.TabIndex = 17;
            this.QueryPortNumber.Value = new decimal(new int[] {
            9877,
            0,
            0,
            0});
            // 
            // MaxConnectedUsersNumber
            // 
            this.MaxConnectedUsersNumber.Location = new System.Drawing.Point(240, 120);
            this.MaxConnectedUsersNumber.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.MaxConnectedUsersNumber.Name = "MaxConnectedUsersNumber";
            this.MaxConnectedUsersNumber.Size = new System.Drawing.Size(120, 23);
            this.MaxConnectedUsersNumber.TabIndex = 18;
            this.MaxConnectedUsersNumber.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // MaxConnectedAdminsNumber
            // 
            this.MaxConnectedAdminsNumber.Location = new System.Drawing.Point(240, 144);
            this.MaxConnectedAdminsNumber.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.MaxConnectedAdminsNumber.Name = "MaxConnectedAdminsNumber";
            this.MaxConnectedAdminsNumber.Size = new System.Drawing.Size(120, 23);
            this.MaxConnectedAdminsNumber.TabIndex = 19;
            this.MaxConnectedAdminsNumber.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // ServerFpsNumber
            // 
            this.ServerFpsNumber.Location = new System.Drawing.Point(240, 168);
            this.ServerFpsNumber.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.ServerFpsNumber.Name = "ServerFpsNumber";
            this.ServerFpsNumber.Size = new System.Drawing.Size(120, 23);
            this.ServerFpsNumber.TabIndex = 20;
            this.ServerFpsNumber.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // SaveNameValue
            // 
            this.SaveNameValue.Enabled = false;
            this.SaveNameValue.Location = new System.Drawing.Point(168, 192);
            this.SaveNameValue.Name = "SaveNameValue";
            this.SaveNameValue.Size = new System.Drawing.Size(192, 23);
            this.SaveNameValue.TabIndex = 21;
            this.SaveNameValue.Text = "world1";
            // 
            // PasswordValue
            // 
            this.PasswordValue.Location = new System.Drawing.Point(168, 216);
            this.PasswordValue.Name = "PasswordValue";
            this.PasswordValue.Size = new System.Drawing.Size(192, 23);
            this.PasswordValue.TabIndex = 22;
            // 
            // AutoSaveCountNumber
            // 
            this.AutoSaveCountNumber.Location = new System.Drawing.Point(240, 336);
            this.AutoSaveCountNumber.Name = "AutoSaveCountNumber";
            this.AutoSaveCountNumber.Size = new System.Drawing.Size(120, 23);
            this.AutoSaveCountNumber.TabIndex = 23;
            this.AutoSaveCountNumber.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // AutoSaveIntervalNumber
            // 
            this.AutoSaveIntervalNumber.Location = new System.Drawing.Point(240, 360);
            this.AutoSaveIntervalNumber.Maximum = new decimal(new int[] {
            7200,
            0,
            0,
            0});
            this.AutoSaveIntervalNumber.Name = "AutoSaveIntervalNumber";
            this.AutoSaveIntervalNumber.Size = new System.Drawing.Size(120, 23);
            this.AutoSaveIntervalNumber.TabIndex = 24;
            this.AutoSaveIntervalNumber.Value = new decimal(new int[] {
            600,
            0,
            0,
            0});
            // 
            // SaveServerSettingsDialog
            // 
            this.SaveServerSettingsDialog.DefaultExt = "json";
            this.SaveServerSettingsDialog.FileName = "ServerHostSettings.json";
            this.SaveServerSettingsDialog.Filter = "\"JSON files\"|*.json";
            this.SaveServerSettingsDialog.Title = "Save Server Settings";
            // 
            // LoadServerSettingsDialog
            // 
            this.LoadServerSettingsDialog.DefaultExt = "json";
            this.LoadServerSettingsDialog.FileName = "ServerHostSettings.json";
            this.LoadServerSettingsDialog.Filter = "\"JSON files\"|*.json";
            this.LoadServerSettingsDialog.Title = "Load Server Settings";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.RCONPortNumber);
            this.groupBox5.Controls.Add(this.RCONPasswordValue);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.RCONRadioFalse);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.RCONRadioTrue);
            this.groupBox5.Location = new System.Drawing.Point(8, 488);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(352, 88);
            this.groupBox5.TabIndex = 25;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "RCON";
            // 
            // RCONPortNumber
            // 
            this.RCONPortNumber.Location = new System.Drawing.Point(240, 56);
            this.RCONPortNumber.Maximum = new decimal(new int[] {
            66000,
            0,
            0,
            0});
            this.RCONPortNumber.Name = "RCONPortNumber";
            this.RCONPortNumber.Size = new System.Drawing.Size(104, 23);
            this.RCONPortNumber.TabIndex = 27;
            this.RCONPortNumber.Value = new decimal(new int[] {
            25575,
            0,
            0,
            0});
            // 
            // RCONPasswordValue
            // 
            this.RCONPasswordValue.Location = new System.Drawing.Point(168, 32);
            this.RCONPasswordValue.Name = "RCONPasswordValue";
            this.RCONPasswordValue.Size = new System.Drawing.Size(176, 23);
            this.RCONPasswordValue.TabIndex = 27;
            this.RCONPasswordValue.Text = "somepassword";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 64);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 15);
            this.label13.TabIndex = 26;
            this.label13.Text = "Port";
            // 
            // RCONRadioFalse
            // 
            this.RCONRadioFalse.AutoSize = true;
            this.RCONRadioFalse.Checked = true;
            this.RCONRadioFalse.Location = new System.Drawing.Point(56, 16);
            this.RCONRadioFalse.Name = "RCONRadioFalse";
            this.RCONRadioFalse.Size = new System.Drawing.Size(51, 19);
            this.RCONRadioFalse.TabIndex = 3;
            this.RCONRadioFalse.TabStop = true;
            this.RCONRadioFalse.Text = "False";
            this.RCONRadioFalse.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 40);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 15);
            this.label12.TabIndex = 26;
            this.label12.Text = "Password";
            // 
            // RCONRadioTrue
            // 
            this.RCONRadioTrue.AutoSize = true;
            this.RCONRadioTrue.Location = new System.Drawing.Point(8, 16);
            this.RCONRadioTrue.Name = "RCONRadioTrue";
            this.RCONRadioTrue.Size = new System.Drawing.Size(47, 19);
            this.RCONRadioTrue.TabIndex = 2;
            this.RCONRadioTrue.Text = "True";
            this.RCONRadioTrue.UseVisualStyleBackColor = true;
            // 
            // ServerSettingsForm
            // 
            this.ClientSize = new System.Drawing.Size(370, 581);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.AutoSaveIntervalNumber);
            this.Controls.Add(this.AutoSaveCountNumber);
            this.Controls.Add(this.PasswordValue);
            this.Controls.Add(this.SaveNameValue);
            this.Controls.Add(this.ServerFpsNumber);
            this.Controls.Add(this.MaxConnectedAdminsNumber);
            this.Controls.Add(this.MaxConnectedUsersNumber);
            this.Controls.Add(this.QueryPortNumber);
            this.Controls.Add(this.PortNumber);
            this.Controls.Add(this.DescriptionValue);
            this.Controls.Add(this.NameValue);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "ServerSettingsForm";
            this.Text = "Server Settings Editor";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PortNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QueryPortNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxConnectedUsersNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxConnectedAdminsNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServerFpsNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AutoSaveCountNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AutoSaveIntervalNumber)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RCONPortNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem loadFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveFileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton SecureRadioFalse;
        private System.Windows.Forms.RadioButton SecureRadioTrue;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton ListOnMasterServerRadioFalse;
        private System.Windows.Forms.RadioButton ListOnMasterServerRadioTrue;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton AdminOnlyDebugEventsRadioFalse;
        private System.Windows.Forms.RadioButton AdminOnlyDebugEventsRadioTrue;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton DisableDebugEventsRadioFalse;
        private System.Windows.Forms.RadioButton DisableDebugEventsRadioTrue;
        private System.Windows.Forms.TextBox NameValue;
        private System.Windows.Forms.TextBox DescriptionValue;
        private System.Windows.Forms.NumericUpDown PortNumber;
        private System.Windows.Forms.NumericUpDown QueryPortNumber;
        private System.Windows.Forms.NumericUpDown MaxConnectedUsersNumber;
        private System.Windows.Forms.NumericUpDown MaxConnectedAdminsNumber;
        private System.Windows.Forms.NumericUpDown ServerFpsNumber;
        private System.Windows.Forms.TextBox SaveNameValue;
        private System.Windows.Forms.TextBox PasswordValue;
        private System.Windows.Forms.NumericUpDown AutoSaveCountNumber;
        private System.Windows.Forms.NumericUpDown AutoSaveIntervalNumber;
        private System.Windows.Forms.SaveFileDialog SaveServerSettingsDialog;
        private System.Windows.Forms.OpenFileDialog LoadServerSettingsDialog;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton RCONRadioFalse;
        private System.Windows.Forms.RadioButton RCONRadioTrue;
        private System.Windows.Forms.TextBox RCONPasswordValue;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown RCONPortNumber;
        private System.Windows.Forms.Label label13;
    }
}