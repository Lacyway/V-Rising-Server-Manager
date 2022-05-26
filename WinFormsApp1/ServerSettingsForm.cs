using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;

namespace ServerManager
{
    public partial class ServerSettingsForm : Form
    {
        public ServerSettingsForm()
        {
            InitializeComponent();
        }

        private void SaveServerSettings()
        {
            bool Secure = false;
            bool ListOnMasterServer = true;
            bool AdminOnlyDebugEvents = true;
            bool DisableDebugEvents = false;

            if (SecureRadioTrue.Checked == true)
            {
                Secure = true;
            }
            if (ListOnMasterServerRadioFalse.Checked == true)
            {
                ListOnMasterServer = false;
            }
            if (AdminOnlyDebugEventsRadioFalse.Checked == true)
            {
                AdminOnlyDebugEvents = false;
            }
            if (DisableDebugEventsRadioTrue.Checked == true)
            {
                DisableDebugEvents = true;
            }

            ServerSettings mainServer = new ServerSettings()
            {
                Name = NameValue.Text,
                Description = DescriptionValue.Text,
                Port = Convert.ToInt16(PortNumber.Value),
                QueryPort = Convert.ToInt16(QueryPortNumber.Value),
                MaxConnectedUsers = Convert.ToInt16(MaxConnectedUsersNumber.Value),
                MaxConnectedAdmins = Convert.ToInt16(MaxConnectedAdminsNumber.Value),
                ServerFps = Convert.ToInt16(ServerFpsNumber.Value),
                SaveName = SaveNameValue.Text,
                Password = PasswordValue.Text,
                Secure = Secure,
                ListOnMasterServer = ListOnMasterServer,
                AutoSaveCount = Convert.ToInt16(AutoSaveCountNumber.Value),
                AutoSaveInterval = Convert.ToInt16(AutoSaveIntervalNumber.Value),
                GameSettingsPreset = "",
                AdminOnlyDebugEvents = AdminOnlyDebugEvents,
                DisableDebugEvents = DisableDebugEvents
            };
            string ServerSettingsJSON = JsonConvert.SerializeObject(mainServer, Formatting.Indented);
            if (Directory.Exists(Properties.Settings.Default.Save_Path + "\\Saves\\v1\\" + Properties.Settings.Default.Save_Name))
            {
                SaveServerSettingsDialog.InitialDirectory = Properties.Settings.Default.Save_Path + "\\Saves\\v1\\" + Properties.Settings.Default.Save_Name;
            }
            else
            {
                SaveServerSettingsDialog.InitialDirectory = Properties.Settings.Default.Save_Path;
            }
            if (SaveServerSettingsDialog.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(SaveServerSettingsDialog.FileName))
                {
                    File.Copy(SaveServerSettingsDialog.FileName, SaveServerSettingsDialog.FileName + ".bak", true);
                }
                File.WriteAllText(SaveServerSettingsDialog.FileName, ServerSettingsJSON);
                MessageBox.Show("File successfully saved to: \n" + SaveServerSettingsDialog.FileName);
            }
        }

        private void LoadServerSettings()
        {
            if (Directory.Exists(Properties.Settings.Default.Save_Path + "\\Saves\\v1\\" + Properties.Settings.Default.Save_Name))
            {
                LoadServerSettingsDialog.InitialDirectory = Properties.Settings.Default.Save_Path + "\\Saves\\v1\\" + Properties.Settings.Default.Save_Name;
            }
            else
            {
                LoadServerSettingsDialog.InitialDirectory = Properties.Settings.Default.Save_Path;
            }
            if (LoadServerSettingsDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader reader = new StreamReader(LoadServerSettingsDialog.FileName))
                {
                    string LoadedServerJSON = reader.ReadToEnd();
                    ServerSettings LoadedServerSettings = JsonConvert.DeserializeObject<ServerSettings>(LoadedServerJSON);
                    NameValue.Text = LoadedServerSettings.Name;
                    DescriptionValue.Text = LoadedServerSettings.Description;
                    PortNumber.Value = LoadedServerSettings.Port;
                    QueryPortNumber.Value = LoadedServerSettings.QueryPort;
                    MaxConnectedUsersNumber.Value = LoadedServerSettings.MaxConnectedUsers;
                    MaxConnectedAdminsNumber.Value = LoadedServerSettings.MaxConnectedAdmins;
                    ServerFpsNumber.Value = LoadedServerSettings.ServerFps;
                    SaveNameValue.Text = LoadedServerSettings.SaveName;
                    PasswordValue.Text = LoadedServerSettings.Password;
                    if (LoadedServerSettings.Secure == true)
                    {
                        SecureRadioTrue.Checked = true;
                    }
                    if (LoadedServerSettings.ListOnMasterServer == false)
                    {
                        ListOnMasterServerRadioFalse.Checked = true;
                    }
                    AutoSaveCountNumber.Value = LoadedServerSettings.AutoSaveCount;
                    AutoSaveIntervalNumber.Value = LoadedServerSettings.AutoSaveInterval;
                    if (LoadedServerSettings.AdminOnlyDebugEvents == false)
                    {
                        AdminOnlyDebugEventsRadioFalse.Checked = true;
                    }
                    if (LoadedServerSettings.DisableDebugEvents == true)
                    {
                        DisableDebugEventsRadioTrue.Checked = true;
                    }
                }
            }
        }

        private void saveFileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveServerSettings();
        }

        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadServerSettings();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
