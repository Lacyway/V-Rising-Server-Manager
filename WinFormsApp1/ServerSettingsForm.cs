using System;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;

namespace ServerManager
{
    public partial class ServerSettingsForm : Form
    {
        public ServerSettingsForm()
        {
            InitializeComponent();
            Icon = Properties.Resources.logo;
            if (Properties.Settings.Default.AutoLoadHostSettings == true && File.Exists(Properties.Settings.Default.GameSettingsFile))
                LoadServerSettings(true);
        }

        private void SaveServerSettings()
        {
            bool Secure = false;
            bool ListOnMasterServer = true;
            bool AdminOnlyDebugEvents = true;
            bool DisableDebugEvents = false;
            bool RconEnabled = false;

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
            if (RCONRadioTrue.Checked == true)
            {
                RconEnabled = true;
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
                DisableDebugEvents = DisableDebugEvents,
                Rcon = new Rcon()
                {
                    Enabled = RconEnabled,
                    Password = RCONPasswordValue.Text,
                    Port = Convert.ToInt16(RCONPortNumber.Value)
                }
            };
            string ServerSettingsJSON = JsonConvert.SerializeObject(mainServer, Formatting.Indented);
            if (Directory.Exists(Properties.Settings.Default.Save_Path + @"\Saves\v1\" + Properties.Settings.Default.Save_Name))
            {
                SaveServerSettingsDialog.InitialDirectory = Properties.Settings.Default.Save_Path + @"\Saves\v1\" + Properties.Settings.Default.Save_Name;
            }
            else
            {
                SaveServerSettingsDialog.InitialDirectory = Properties.Settings.Default.Save_Path;
            }
            if (Properties.Settings.Default.AutoLoadHostSettings == true && MessageBox.Show("Save to auto-loaded file?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (File.Exists(Properties.Settings.Default.HostSettingsFile))
                {
                    File.Copy(Properties.Settings.Default.HostSettingsFile, Properties.Settings.Default.HostSettingsFile + ".bak", true);
                }
                File.WriteAllText(Properties.Settings.Default.HostSettingsFile, ServerSettingsJSON);
                MessageBox.Show("File successfully saved to: \n" + Properties.Settings.Default.HostSettingsFile);
            }
            else if (SaveServerSettingsDialog.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(SaveServerSettingsDialog.FileName))
                {
                    File.Copy(SaveServerSettingsDialog.FileName, SaveServerSettingsDialog.FileName + ".bak", true);
                }
                File.WriteAllText(SaveServerSettingsDialog.FileName, ServerSettingsJSON);
                MessageBox.Show("File successfully saved to: \n" + SaveServerSettingsDialog.FileName);
            }
        }

        private void LoadServerSettings(bool AutoLoad)
        {
            if (Directory.Exists(Properties.Settings.Default.Save_Path + @"\Saves\v1\" + Properties.Settings.Default.Save_Name))
            {
                LoadServerSettingsDialog.InitialDirectory = Properties.Settings.Default.Save_Path + @"\Saves\v1\" + Properties.Settings.Default.Save_Name;
            }
            else
            {
                LoadServerSettingsDialog.InitialDirectory = Properties.Settings.Default.Save_Path;
            }
            if (AutoLoad == true)
            {
                using (StreamReader reader = new StreamReader(Properties.Settings.Default.HostSettingsFile))
                {
                    string LoadedServerJSON = reader.ReadToEnd();
                    LoadHandler(LoadedServerJSON);
                }
            }
            else
            {
                if (LoadServerSettingsDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamReader reader = new StreamReader(LoadServerSettingsDialog.FileName))
                    {
                        string LoadedServerJSON = reader.ReadToEnd();
                        LoadHandler(LoadedServerJSON);
                    }
                }
            }
            
        }

        private void LoadHandler(string Loaded)
        {
            try 
            {
                ServerSettings LoadedServerSettings = JsonConvert.DeserializeObject<ServerSettings>(Loaded);
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
                if (LoadedServerSettings.Rcon.Enabled == true)
                {
                    RCONRadioTrue.Checked = true;
                }
                RCONPasswordValue.Text = LoadedServerSettings.Rcon.Password;
                RCONPortNumber.Value = LoadedServerSettings.Rcon.Port;
                }
            catch (NullReferenceException)
            {
                MessageBox.Show("One or more default values was missing.\nDefault values will be used.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void saveFileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveServerSettings();
        }

        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadServerSettings(false);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to quit?\nAll unsaved data will be lost.", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
