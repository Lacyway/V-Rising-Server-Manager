namespace ServerManager
{
    partial class RconConsole
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RconConsole));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PasswordValue = new System.Windows.Forms.TextBox();
            this.PortNumber = new System.Windows.Forms.NumericUpDown();
            this.AddressValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.RconConsoleMain = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CommandList = new System.Windows.Forms.ListBox();
            this.CommandInfoBox = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ParameterBox = new System.Windows.Forms.TextBox();
            this.SendCommandButton = new System.Windows.Forms.Button();
            this.DisconnectButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PortNumber)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PasswordValue);
            this.groupBox1.Controls.Add(this.PortNumber);
            this.groupBox1.Controls.Add(this.AddressValue);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(248, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // PasswordValue
            // 
            this.PasswordValue.Location = new System.Drawing.Point(96, 68);
            this.PasswordValue.Name = "PasswordValue";
            this.PasswordValue.Size = new System.Drawing.Size(144, 23);
            this.PasswordValue.TabIndex = 5;
            this.PasswordValue.Text = "somepassword";
            // 
            // PortNumber
            // 
            this.PortNumber.Location = new System.Drawing.Point(168, 44);
            this.PortNumber.Maximum = new decimal(new int[] {
            66000,
            0,
            0,
            0});
            this.PortNumber.Name = "PortNumber";
            this.PortNumber.Size = new System.Drawing.Size(72, 23);
            this.PortNumber.TabIndex = 4;
            this.PortNumber.Value = new decimal(new int[] {
            25575,
            0,
            0,
            0});
            // 
            // AddressValue
            // 
            this.AddressValue.Location = new System.Drawing.Point(96, 20);
            this.AddressValue.Name = "AddressValue";
            this.AddressValue.Size = new System.Drawing.Size(144, 23);
            this.AddressValue.TabIndex = 3;
            this.AddressValue.Text = "127.0.0.1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP Address";
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(8, 120);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(75, 23);
            this.ConnectButton.TabIndex = 1;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // RconConsoleMain
            // 
            this.RconConsoleMain.BackColor = System.Drawing.Color.Black;
            this.RconConsoleMain.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RconConsoleMain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.RconConsoleMain.Location = new System.Drawing.Point(8, 328);
            this.RconConsoleMain.Name = "RconConsoleMain";
            this.RconConsoleMain.ReadOnly = true;
            this.RconConsoleMain.Size = new System.Drawing.Size(784, 112);
            this.RconConsoleMain.TabIndex = 2;
            this.RconConsoleMain.Text = "";
            this.RconConsoleMain.TextChanged += new System.EventHandler(this.RconConsoleMain_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CommandList);
            this.groupBox2.Location = new System.Drawing.Point(600, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Command";
            // 
            // CommandList
            // 
            this.CommandList.FormattingEnabled = true;
            this.CommandList.ItemHeight = 15;
            this.CommandList.Items.AddRange(new object[] {
            "announce",
            "announcerestart"});
            this.CommandList.Location = new System.Drawing.Point(8, 16);
            this.CommandList.Name = "CommandList";
            this.CommandList.Size = new System.Drawing.Size(184, 79);
            this.CommandList.TabIndex = 0;
            this.CommandList.SelectedIndexChanged += new System.EventHandler(this.CommandList_SelectedIndexChanged);
            // 
            // CommandInfoBox
            // 
            this.CommandInfoBox.Location = new System.Drawing.Point(408, 192);
            this.CommandInfoBox.Name = "CommandInfoBox";
            this.CommandInfoBox.Size = new System.Drawing.Size(384, 88);
            this.CommandInfoBox.TabIndex = 5;
            this.CommandInfoBox.Text = "Select a command.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 272);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Parameter";
            // 
            // ParameterBox
            // 
            this.ParameterBox.Enabled = false;
            this.ParameterBox.Location = new System.Drawing.Point(8, 296);
            this.ParameterBox.Name = "ParameterBox";
            this.ParameterBox.Size = new System.Drawing.Size(696, 23);
            this.ParameterBox.TabIndex = 7;
            // 
            // SendCommandButton
            // 
            this.SendCommandButton.Enabled = false;
            this.SendCommandButton.Location = new System.Drawing.Point(712, 296);
            this.SendCommandButton.Name = "SendCommandButton";
            this.SendCommandButton.Size = new System.Drawing.Size(75, 23);
            this.SendCommandButton.TabIndex = 8;
            this.SendCommandButton.Text = "Send";
            this.SendCommandButton.UseVisualStyleBackColor = true;
            this.SendCommandButton.Click += new System.EventHandler(this.SendCommandButton_Click);
            // 
            // DisconnectButton
            // 
            this.DisconnectButton.Enabled = false;
            this.DisconnectButton.Location = new System.Drawing.Point(88, 120);
            this.DisconnectButton.Name = "DisconnectButton";
            this.DisconnectButton.Size = new System.Drawing.Size(75, 23);
            this.DisconnectButton.TabIndex = 9;
            this.DisconnectButton.Text = "Disconnect";
            this.DisconnectButton.UseVisualStyleBackColor = true;
            this.DisconnectButton.Click += new System.EventHandler(this.DisconnectButton_Click);
            // 
            // RconConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DisconnectButton);
            this.Controls.Add(this.SendCommandButton);
            this.Controls.Add(this.ParameterBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CommandInfoBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.RconConsoleMain);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RconConsole";
            this.Text = "RCON Console";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PortNumber)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox PasswordValue;
        private System.Windows.Forms.NumericUpDown PortNumber;
        private System.Windows.Forms.TextBox AddressValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.RichTextBox RconConsoleMain;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox CommandList;
        private System.Windows.Forms.RichTextBox CommandInfoBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ParameterBox;
        private System.Windows.Forms.Button SendCommandButton;
        private System.Windows.Forms.Button DisconnectButton;
    }
}