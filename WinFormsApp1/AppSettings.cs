using System;
using System.Windows.Forms;

namespace ServerManager
{
    public partial class AppSettings : Form
    {
        public AppSettings()
        {
            InitializeComponent();
            Icon = Properties.Resources.logo;
            ServerFolderValue.Text = Properties.Settings.Default.Server_Path;
            SaveFolderValue.Text = Properties.Settings.Default.Save_Path;
            LogFolderValue.Text = Properties.Settings.Default.Log_Path;
            VerifyUpdateCheckbox.Checked = Properties.Settings.Default.VerifyUpdate;
            if (Properties.Settings.Default.AutoUpdate == true)
            {
                AutoUpdateCheckbox.Checked = true;
                AutoUpdateInterval.Enabled = true;
            }
            AutoUpdateInterval.Value = Properties.Settings.Default.AutoUpdateInterval;
            SendMessageCheckbox.Checked = Properties.Settings.Default.AutoUpdateRCONMessage;
        }

        private void SelectServerFolderButton_Click(object sender, EventArgs e)
        {
            if (OpenFolderDialog.ShowDialog() == DialogResult.OK)
            {
                ServerFolderValue.Text = OpenFolderDialog.SelectedPath;
            }
        }
        private void SelectSaveFolderButton_Click(object sender, EventArgs e)
        {
            if (OpenFolderDialog.ShowDialog() == DialogResult.OK)
            {
                SaveFolderValue.Text = OpenFolderDialog.SelectedPath;
            }
        }

        private void SelectLogFolderButton_Click(object sender, EventArgs e)
        {
            if (OpenFolderDialog.ShowDialog() == DialogResult.OK)
            {
                LogFolderValue.Text = OpenFolderDialog.SelectedPath;
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?\nUnsaved changes will be lost.", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Server_Path = ServerFolderValue.Text;
            Properties.Settings.Default.Save_Path = SaveFolderValue.Text;
            Properties.Settings.Default.Log_Path = LogFolderValue.Text;
            Properties.Settings.Default.AutoUpdateInterval = Convert.ToInt32(AutoUpdateInterval.Value);
            Properties.Settings.Default.AutoUpdate = AutoUpdateCheckbox.Checked;
            Properties.Settings.Default.VerifyUpdate = VerifyUpdateCheckbox.Checked;
            Properties.Settings.Default.AutoUpdateRCONMessage = SendMessageCheckbox.Checked;
            Properties.Settings.Default.Save();
            Close();
        }

        private void AutoUpdateCheckbox_CheckStateChanged(object sender, EventArgs e)
        {
            AutoUpdateInterval.Enabled = AutoUpdateCheckbox.Checked;
            SendMessageCheckbox.Enabled = AutoUpdateCheckbox.Checked;
        }
    }
}
