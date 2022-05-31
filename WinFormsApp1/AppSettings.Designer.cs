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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppSettings));
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
            this.ServerFolderValue.Enabled = false;
            this.ServerFolderValue.Location = new System.Drawing.Point(80, 8);
            this.ServerFolderValue.Name = "ServerFolderValue";
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
            this.SaveFolderValue.Enabled = false;
            this.SaveFolderValue.Location = new System.Drawing.Point(80, 38);
            this.SaveFolderValue.Name = "SaveFolderValue";
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
            this.LogFolderValue.Enabled = false;
            this.LogFolderValue.Location = new System.Drawing.Point(80, 68);
            this.LogFolderValue.Name = "LogFolderValue";
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
            this.SaveButton.Location = new System.Drawing.Point(352, 104);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 9;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(432, 104);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 10;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // AppSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 138);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AppSettings";
            this.Text = "AppSettings";
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
    }
}