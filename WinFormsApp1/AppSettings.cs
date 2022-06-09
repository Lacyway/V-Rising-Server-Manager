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
            AutoLoadGameSettingsCheckbox.Checked = Properties.Settings.Default.AutoLoadGameSettings;
            AutoLoadHostSettingsCheckbox.Checked = Properties.Settings.Default.AutoLoadHostSettings;
            AutoLoadGameSettingsTextbox.Text = Properties.Settings.Default.GameSettingsFile;
            AutoLoadHostSettingsTextbox.Text = Properties.Settings.Default.HostSettingsFile;
            DiscordWebhookCheckbox.Checked = Properties.Settings.Default.EnableWebhook;
            WebhookURLText.Text = Properties.Settings.Default.WebhookURL;
            WebhookMessagesGroup.Enabled = Properties.Settings.Default.EnableWebhook;
            StartMessageTextbox.Text = Properties.Settings.Default.WebhookMessages[0];
            StopMessageTextbox.Text = Properties.Settings.Default.WebhookMessages[1];
            StoppedCrashTextbox.Text = Properties.Settings.Default.WebhookMessages[2];
            UnableStartTextbox.Text = Properties.Settings.Default.WebhookMessages[3];
            UpdateFoundTextbox.Text = Properties.Settings.Default.WebhookMessages[4];
            UpdateWaitTextbox.Text = Properties.Settings.Default.WebhookMessages[5];
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
            if (MessageBox.Show("Are you sure? Unsaved changes will be lost.", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
            Properties.Settings.Default.AutoLoadGameSettings = AutoLoadGameSettingsCheckbox.Checked;
            Properties.Settings.Default.AutoLoadHostSettings = AutoLoadHostSettingsCheckbox.Checked;
            Properties.Settings.Default.GameSettingsFile = AutoLoadGameSettingsTextbox.Text;
            Properties.Settings.Default.HostSettingsFile = AutoLoadHostSettingsTextbox.Text;
            Properties.Settings.Default.EnableWebhook = DiscordWebhookCheckbox.Checked;
            Properties.Settings.Default.WebhookURL = WebhookURLText.Text;
            Properties.Settings.Default.WebhookMessages[0] = StartMessageTextbox.Text;
            Properties.Settings.Default.WebhookMessages[1] = StopMessageTextbox.Text;
            Properties.Settings.Default.WebhookMessages[2] = StoppedCrashTextbox.Text;
            Properties.Settings.Default.WebhookMessages[3] = UnableStartTextbox.Text;
            Properties.Settings.Default.WebhookMessages[4] = UpdateFoundTextbox.Text;
            Properties.Settings.Default.WebhookMessages[5] = UpdateWaitTextbox.Text;
            Properties.Settings.Default.Save();
            Close();
        }

        private void AutoUpdateCheckbox_CheckStateChanged(object sender, EventArgs e)
        {
            AutoUpdateInterval.Enabled = AutoUpdateCheckbox.Checked;
            SendMessageCheckbox.Enabled = AutoUpdateCheckbox.Checked;
        }

        private void SelectAutoLoadGameSettingsFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog.FileName = "ServerGameSettings.json";
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
                AutoLoadGameSettingsTextbox.Text = OpenFileDialog.FileName;
        }

        private void SelectAutoLoadHostSettingsFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog.FileName = "ServerHostSettings.json";
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
                AutoLoadHostSettingsTextbox.Text = OpenFileDialog.FileName;
        }

        private void DiscordWebhookCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            WebhookURLText.ReadOnly = (DiscordWebhookCheckbox.Checked) ? false : true;
            WebhookMessagesGroup.Enabled = DiscordWebhookCheckbox.Checked;
            TestWebhookButton.Enabled = DiscordWebhookCheckbox.Checked;
        }

        private void TestWebhookButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.WebhookURL = WebhookURLText.Text;
            Properties.Settings.Default.Save();
            MainMenu.discordSender.SendMessage("Webhook success.");
        }
    }
}
