using System;
using System.Windows.Forms;
using System.Net.Http;
using System.IO.Compression;
using System.IO;
using System.Diagnostics;
using System.Timers;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using ServerManager.RCON;

namespace ServerManager
{
    public partial class MainMenu : Form
    {

        public Process serverProcess = new Process();
        private static System.Timers.Timer RestartTimer;
        public bool userStopped = false;
        public static int restartAttempts = 0;
        HttpClient HttpClient = new HttpClient();
        System.Windows.Forms.Timer ucTimer = new System.Windows.Forms.Timer();
        public static dWebHook discordSender = new dWebHook();

        public MainMenu()
        {
            InitializeComponent();
            Icon = Properties.Resources.logo;
            if (Properties.Settings.Default.UpgradeRequired)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.UpgradeRequired = false;
                Properties.Settings.Default.Save();
            }
            if (Properties.Settings.Default.Save_Path == "notset")
            {
                Properties.Settings.Default.Save_Path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), @"AppData\LocalLow\Stunlock Studios\VRisingServer");
                Properties.Settings.Default.Save();
            }
            MainMenuConsole.AppendText("V Rising Server Manager Started\nServer Path: " + Properties.Settings.Default.Server_Path);
            ServerNameValue.Text = Properties.Settings.Default.Server_Name;
            SaveNameValue.Text = Properties.Settings.Default.Save_Name;
            ucTimer.Tick += AutoUpdateElapsed;
            Properties.Settings.Default.SettingChanging += (sender, e) =>
            {
                if (e.SettingName == "AutoUpdate")
                {
                    if (e.NewValue.ToString() == "True")
                    {
                        UpdateTimer();
                    }
                    else if (ucTimer.Enabled) ucTimer.Stop();
                }
                if (e.SettingName == "WebhookURL")
                {
                    discordSender.WebHook = e.NewValue.ToString();
                }
            };
            if (Properties.Settings.Default.LastUpdateUNIXTime != "")
                LastUpdateLabel.Text = "Last Update on Steam: " + DateTimeOffset.FromUnixTimeSeconds(long.Parse(Properties.Settings.Default.LastUpdateUNIXTime)).DateTime.ToString();
            if (Properties.Settings.Default.AutoUpdate == true) 
                UpdateTimer();
            BindIPTextbox.Text = Properties.Settings.Default.BindingIP;
            if (Properties.Settings.Default.BindToIP == true)
            {
                BindToIPCheckbox.Checked = true;
                BindIPTextbox.ReadOnly = false;
            }
            discordSender.WebHook = Properties.Settings.Default.WebhookURL;
            CheckServer();
        }

        private void UpdateTimer()
        {
            ucTimer.Interval = Properties.Settings.Default.AutoUpdateInterval * 60000;
            ucTimer.Start();
        }

        private async void AutoUpdateElapsed(object? sender, EventArgs e)
        {
            bool updateFound = await CheckForUpdate();
            if (updateFound == true) 
                AutoUpdateServer();
        }

        private async void AutoUpdateServer()
        {
            if (Properties.Settings.Default.EnableWebhook && discordSender.WebHook != "" && Properties.Settings.Default.WebhookMessages[4] != "")
                discordSender.SendMessage(Properties.Settings.Default.WebhookMessages[4]);
            userStopped = true;
            if (Properties.Settings.Default.AutoUpdateRCONMessage) 
                await SendRestartMessage();
            Process[] processList = Process.GetProcessesByName("vrisingserver");
            foreach (Process proc in processList)
            {
                if (proc.MainModule.FileName == Properties.Settings.Default.Server_Path + @"\VRisingServer.exe")
                {
                    MainMenuConsole.AppendText(Environment.NewLine + "Terminating server for update.");
                    proc.CloseMainWindow();
                    proc.WaitForExit();
                    MainMenuConsole.AppendText(Environment.NewLine + "Server terminated.");
                }
            }
            await UpdateGame();
            StartServer();
        }

        private async Task SendRestartMessage()
        {
            RemoteConClient rClient = new RemoteConClient();
            rClient.UseUtf8 = true;
            rClient.OnLog += async message =>
            {
                if (message == "Authentication success.")
                {
                    await Task.Delay(1000);
                    rClient.SendCommand("announcerestart 5", result =>
                    {
                        MainMenuConsole.AppendText(result);
                    });
                }
                
            };
            rClient.OnConnectionStateChange += state =>
            {
                if (state == RemoteConClient.ConnectionStateChange.Connected)
                {
                    rClient.Authenticate(Properties.Settings.Default.RCON_Pass);
                }
            };
            rClient.Connect(Properties.Settings.Default.RCON_Address, Properties.Settings.Default.RCON_Port);
            MainMenuConsole.AppendText(Environment.NewLine + "Waiting 5 minutes to update.");
            if (Properties.Settings.Default.EnableWebhook && discordSender.WebHook != "" && Properties.Settings.Default.WebhookMessages[5] != "")
                discordSender.SendMessage(Properties.Settings.Default.WebhookMessages[5]);
            await Task.Delay(300000);
            rClient.Disconnect();
        }

        private void CheckServer()
        {
            Process[] processList = Process.GetProcessesByName("vrisingserver");
            bool foundServer = false;
            foreach (Process proc in processList)
            {
                if (proc.MainModule.FileName == Properties.Settings.Default.Server_Path + @"\VRisingServer.exe")
                {
                    Process serverProcess = proc;
                    serverProcess.EnableRaisingEvents = true;
                    serverProcess.Exited += new EventHandler(serverProcessExited);
                    foundServer = true;
                }
            }
            if (foundServer == true)
            {
                StartGameServerButton.Enabled = false;
                StopGameServerButton.Enabled = true;
                StoppedPic.Visible = false;
                RunningPic.Visible = true;
                StatusLabel.Text = "Running";
                MainMenuConsole.AppendText(Environment.NewLine + "Server found running.");
            }
        }
        
        private async Task UpdateGame()
        {
            SteamCMDStatusLabel.ForeColor = System.Drawing.Color.Black;
            if (Process.GetProcessesByName("vrisingserver").Length > 0)
            {
                MessageBox.Show("Server is already running. Shut down the server before updating.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (File.Exists(Properties.Settings.Default.Server_Path + @"\SteamCMD\steamcmd.exe") == false)
            {
                if (MessageBox.Show("VSM will now download SteamCMD.\nThis is used to update and manage the server.\nIs this ok?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                    return;
                SteamCMDStatusLabel.Text = "SteamCMD: Downloading...";
                MainMenuConsole.AppendText(Environment.NewLine + "SteamCMD not found. Downloading...");
                byte[] fileBytes = await HttpClient.GetByteArrayAsync(@"https://steamcdn-a.akamaihd.net/client/installer/steamcmd.zip");
                await File.WriteAllBytesAsync(Properties.Settings.Default.Server_Path + @"\steamcmd.zip", fileBytes);
                if (File.Exists(Properties.Settings.Default.Server_Path + @"\SteamCMD\steamcmd.exe") == true)
                {
                    File.Delete(Properties.Settings.Default.Server_Path + @"\SteamCMD\steamcmd.exe");
                }
                MainMenuConsole.AppendText(Environment.NewLine + "Unzipping...");
                ZipFile.ExtractToDirectory(Properties.Settings.Default.Server_Path + @"\steamcmd.zip", Properties.Settings.Default.Server_Path + @"\SteamCMD");
                if (File.Exists(Properties.Settings.Default.Server_Path + @"\steamcmd.zip"))
                {
                    File.Delete(Properties.Settings.Default.Server_Path + @"\steamcmd.zip");
                }
            }
            else
            {
                SteamCMDStatusLabel.Text = "SteamCMD: Running...";
                MainMenuConsole.AppendText(Environment.NewLine + "SteamCMD found. Running...");
            }
            if (File.Exists(Properties.Settings.Default.Server_Path + @"\VRisingServer_Data\StreamingAssets\Settings\adminlist.txt") && File.Exists(Properties.Settings.Default.Server_Path + @"\VRisingServer_Data\StreamingAssets\Settings\banlist.txt") && Properties.Settings.Default.VerifyUpdate)
            {
                Directory.CreateDirectory(Properties.Settings.Default.Server_Path + @"\Backup");
                File.Copy(Properties.Settings.Default.Server_Path + @"\VRisingServer_Data\StreamingAssets\Settings\adminlist.txt", Properties.Settings.Default.Server_Path + @"\Backup\adminlist.txt", true);
                File.Copy(Properties.Settings.Default.Server_Path + @"\VRisingServer_Data\StreamingAssets\Settings\banlist.txt", Properties.Settings.Default.Server_Path + @"\Backup\banlist.txt", true);
            }
            SteamCMDStatusLabel.Text = "SteamCMD: Updating game...";
            MainMenuConsole.AppendText(Environment.NewLine + "Updating game...");
            string parameters = String.Format("+force_install_dir {0} +login anonymous +app_update 1829350 {1}+quit", Properties.Settings.Default.Server_Path, (Properties.Settings.Default.VerifyUpdate) ? "validate " : "");
            var steamcmd = Process.Start(Properties.Settings.Default.Server_Path + @"\SteamCMD\steamcmd.exe", parameters);
            await steamcmd.WaitForExitAsync();
            MainMenuConsole.AppendText(Environment.NewLine + "Update completed.");
            if (File.Exists(Properties.Settings.Default.Server_Path + @"\Backup\adminlist.txt") && File.Exists(Properties.Settings.Default.Server_Path + @"\Backup\banlist.txt") && Properties.Settings.Default.VerifyUpdate)
            {
                MainMenuConsole.AppendText(Environment.NewLine + "Restoring backups of adminlist and banlist.");
                Directory.CreateDirectory(Properties.Settings.Default.Server_Path + @"\Backup");
                File.Copy(Properties.Settings.Default.Server_Path + @"\Backup\adminlist.txt", Properties.Settings.Default.Server_Path + @"\VRisingServer_Data\StreamingAssets\Settings\adminlist.txt", true);
                File.Copy(Properties.Settings.Default.Server_Path + @"\Backup\banlist.txt", Properties.Settings.Default.Server_Path + @"\VRisingServer_Data\StreamingAssets\Settings\banlist.txt", true);
            }
            await CheckForUpdate();
            SteamCMDStatusLabel.Text = "SteamCMD Status: Not running";
        }

        private async Task<bool> CheckForUpdate()
        {
            bool foundUpdate = false;
            await Task.Run(() =>
            {                
                if (File.Exists(Properties.Settings.Default.Server_Path + @"\SteamCMD\steamcmd.exe") == false)
                {
                    SteamCMDStatusLabel.ForeColor = System.Drawing.Color.Red;
                    SteamCMDStatusLabel.Text = "SteamCMD AutoUpdate: ERROR, could not find SteamCMD.";
                    foundUpdate = false;
                }
                else
                {
                    SteamCMDStatusLabel.ForeColor = System.Drawing.Color.Black;
                    SteamCMDStatusLabel.Text = "SteamCMD AutoUpdate: Fetching information.";
                    string parameters = @"+login anonymous +app_info_update 1829350 +app_info_print 1829350 +quit";
                    Process steamCMD = new Process();
                    steamCMD.StartInfo.FileName = Properties.Settings.Default.Server_Path + @"\SteamCMD\steamcmd.exe";
                    steamCMD.StartInfo.CreateNoWindow = true;
                    steamCMD.StartInfo.UseShellExecute = false;
                    steamCMD.StartInfo.Arguments = parameters;
                    steamCMD.StartInfo.RedirectStandardOutput = true;
                    steamCMD.Start();
                    string output = steamCMD.StandardOutput.ReadToEnd();
                    string[] toScan = output.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    steamCMD.WaitForExit();
                    for (int i = 0; i < toScan.Length; i++)
                    {
                        if (toScan[i].Contains("\"branches\"") && toScan[i + 2].Contains("\"public\""))
                        {
                            string lastUpdated = Regex.Match(toScan[i + 5], "(?<=\")[0-9]+(?=\")").Value;
                            if (lastUpdated != Properties.Settings.Default.LastUpdateUNIXTime)
                            {
                                Properties.Settings.Default.LastUpdateUNIXTime = lastUpdated;
                                Properties.Settings.Default.Save();
                                foundUpdate = true;
                            }
                            if (Properties.Settings.Default.LastUpdateUNIXTime == "")
                            {
                                Properties.Settings.Default.LastUpdateUNIXTime = lastUpdated;
                                Properties.Settings.Default.Save();
                                foundUpdate = false;
                            }                            
                        }
                    }
                    SteamCMDStatusLabel.Text = "SteamCMD Status: Not running";
                    LastUpdateLabel.Text = "Last Update on Steam: " + DateTimeOffset.FromUnixTimeSeconds(long.Parse(Properties.Settings.Default.LastUpdateUNIXTime)).DateTime.ToString();
                }
            });
            return foundUpdate;
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            SettingsForm SettingsMenu = new SettingsForm();
            SettingsMenu.Show();
        }

        private void ServerSettingsButton_Click(object sender, EventArgs e)
        {
            ServerSettingsForm ServerSettingsMenu = new ServerSettingsForm();
            ServerSettingsMenu.Show();
        }

        private void AppSettingsButton_Click(object sender, EventArgs e)
        {
            AppSettings AppSettingsMenu = new AppSettings();
            AppSettingsMenu.ShowDialog();
        }

        private void SteamCMDButton_Click(object sender, EventArgs e)
        {
            UpdateGame();
        }

        private void StartServer()
        {
            Process[] processList = Process.GetProcessesByName("vrisingserver");
            foreach (Process proc in processList)
            {
                if (proc.MainModule.FileName == Properties.Settings.Default.Server_Path + @"\VRisingServer.exe")
                {
                    MessageBox.Show("Server is already running.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (restartAttempts == 5)
            {
                MainMenuConsole.AppendText(Environment.NewLine + "Unable to start server 5 times, disabling auto-restart.");
                AutoRestartCheck.Checked = false;
                StartGameServerButton.Enabled = true;
                StopGameServerButton.Enabled = false;
                if (Properties.Settings.Default.EnableWebhook && discordSender.WebHook != "" && Properties.Settings.Default.WebhookMessages[3] != "")
                    discordSender.SendMessage(Properties.Settings.Default.WebhookMessages[3]);
                return;
            }
            if (restartAttempts == 0) 
                SetTimer();
            restartAttempts++;
            if (File.Exists(Properties.Settings.Default.Server_Path + @"\VRisingServer.exe") == true)
            {
                StopGameServerButton.Enabled = true;
                StartGameServerButton.Enabled = false;
                string parameters = String.Format(@"-persistentDataPath ""{0}"" -serverName ""{1}"" -saveName ""{2}"" -logFile ""{3}\VRisingServer.log""{4}", Properties.Settings.Default.Save_Path, Properties.Settings.Default.Server_Name, Properties.Settings.Default.Save_Name, Properties.Settings.Default.Log_Path, (Properties.Settings.Default.BindToIP) ? String.Format(@" -address ""{0}""", BindIPTextbox.Text) : "");
                Process serverProcess = new Process();
                serverProcess.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
                serverProcess.StartInfo.FileName = Properties.Settings.Default.Server_Path + @"\VRisingServer.exe";
                serverProcess.StartInfo.UseShellExecute = true;
                serverProcess.StartInfo.Arguments = parameters;
                serverProcess.EnableRaisingEvents = true;
                serverProcess.Exited += new EventHandler(serverProcessExited);
                serverProcess.Start();
                StoppedPic.Visible = false;
                RunningPic.Visible = true;
                StatusLabel.Text = "Running";
                MainMenuConsole.AppendText("\nServer starting.\nServer name: " + Properties.Settings.Default.Server_Name + "\nSave name: " + Properties.Settings.Default.Save_Name);
                userStopped = false;
                if (Properties.Settings.Default.EnableWebhook && discordSender.WebHook != "" && Properties.Settings.Default.WebhookMessages[0]!= "")
                    discordSender.SendMessage(Properties.Settings.Default.WebhookMessages[0]);
            }
            else
            {
                MessageBox.Show("'VRisingServer.exe' not found. Please make sure server is installed correctly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private static void SetTimer()
        {
            if (RestartTimer != null)
            {
                RestartTimer.Start();
            }
            else
            {
                RestartTimer = new System.Timers.Timer(10000);
                RestartTimer.Elapsed += OnTimedEvent;
                RestartTimer.AutoReset = true;
                RestartTimer.Enabled = true;
            }            
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            restartAttempts = 0;
            RestartTimer.Stop();
        }

        private void StartGameServerButton_Click(object sender, EventArgs e)
        {            
            StartServer();
        }

        private void MainMenuConsole_TextChanged(object sender, EventArgs e)
        {
            if (MainMenuConsole.TextLength > 10000)
            {
                MainMenuConsole.ResetText();
            }
            MainMenuConsole.ScrollToCaret();
        }

        private void StopGameServerButton_Click(object sender, EventArgs e)
        {
            userStopped = true;
            StopGameServerButton.Enabled = false;
            MainMenuConsole.AppendText(Environment.NewLine + "Stopping server.");
            Process[] processList = Process.GetProcessesByName("vrisingserver");
            foreach (Process proc in processList)
            {
                if (proc.MainModule.FileName == Properties.Settings.Default.Server_Path + @"\VRisingServer.exe")
                {
                    proc.CloseMainWindow();
                }
            }
        }

        private void OpenGameFolderButton_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", Properties.Settings.Default.Server_Path);
        }

        private void serverProcessExited(object sender, EventArgs e)
        {
            if (userStopped == false && AutoRestartCheck.Checked == true)
            {
                Invoke(new Action(() =>
                {
                    if (Properties.Settings.Default.EnableWebhook && discordSender.WebHook != "" && Properties.Settings.Default.WebhookMessages[2] != "")
                        discordSender.SendMessage(Properties.Settings.Default.WebhookMessages[2]);
                    StoppedPic.Visible = true;
                    RunningPic.Visible = false;
                    StatusLabel.Text = "Stopped";
                    MainMenuConsole.AppendText(Environment.NewLine + "Server closed unexpectedly. Restarting.");                    
                    StartServer();
                }));                            
            }
            else
            {
                Invoke(new Action(() =>
                {
                    if (Properties.Settings.Default.EnableWebhook && discordSender.WebHook != "" && Properties.Settings.Default.WebhookMessages[1] != "")
                        discordSender.SendMessage(Properties.Settings.Default.WebhookMessages[1]);
                    StoppedPic.Visible = true;
                    RunningPic.Visible = false;
                    StatusLabel.Text = "Stopped";
                    StopGameServerButton.Enabled = false;
                    StartGameServerButton.Enabled = true;
                    MainMenuConsole.AppendText(Environment.NewLine + "Server stopped.");                    
                    userStopped = false;
                }));                   
            }
        }

        private void RCONButton_Click(object sender, EventArgs e)
        {
            RconConsole RconConsoleMenu = new RconConsole();
            RconConsoleMenu.Show();
        }

        private void ManageAdminsButton_Click(object sender, EventArgs e)
        {
            if (!File.Exists(Properties.Settings.Default.Server_Path + @"\VRisingServer_Data\StreamingAssets\Settings\adminlist.txt"))
            {
                MessageBox.Show("Unable to find adminlist.txt\nPlease make sure server path is correctly configured and installed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                AdminManager AdminManagerMenu = new AdminManager();
                AdminManagerMenu.Show();
            }            
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Server_Name = ServerNameValue.Text;
            Properties.Settings.Default.Save_Name = SaveNameValue.Text;
            Properties.Settings.Default.BindToIP = BindToIPCheckbox.Checked;
            Properties.Settings.Default.BindingIP = BindIPTextbox.Text;
            Properties.Settings.Default.Save();
            MainMenuConsole.AppendText(Environment.NewLine + "Launch info saved.");
        }

        private void BindToIPCheckbox_CheckStateChanged(object sender, EventArgs e)
        {
            BindIPTextbox.ReadOnly = !BindToIPCheckbox.Checked;
        }
    }
}
