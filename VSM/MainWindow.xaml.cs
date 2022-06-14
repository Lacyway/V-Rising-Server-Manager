using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Diagnostics;
using System.Timers;
using System.Net.Http;
using System.IO.Compression;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using VRisingServerManager.RCON;

namespace VRisingServerManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public Process serverProcess = new Process();
        private static System.Timers.Timer RestartTimer;
        public bool userStopped = false;
        public static int restartAttempts = 0;
        HttpClient HttpClient = new HttpClient();
        System.Windows.Forms.Timer ucTimer = new System.Windows.Forms.Timer();
        public static dWebHook discordSender = new dWebHook();

        public MainWindow()
        {
            InitializeComponent();
            MainMenuConsole.AppendText("VSM started.");
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
                LastUpdateText.Text = "Last Update on Steam: " + DateTimeOffset.FromUnixTimeSeconds(long.Parse(Properties.Settings.Default.LastUpdateUNIXTime)).DateTime.ToString();
            if (Properties.Settings.Default.AutoUpdate == true)
                UpdateTimer();            
            discordSender.WebHook = Properties.Settings.Default.WebhookURL;
            CheckServer();
        }

        private void StartServer()
        {
            Process[] processList = Process.GetProcessesByName("vrisingserver");
            foreach (Process proc in processList)
            {
                if (proc.MainModule.FileName == Properties.Settings.Default.Server_Path + @"\VRisingServer.exe")
                {
                    System.Windows.MessageBox.Show("Server is already running.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            if (restartAttempts == 5)
            {
                LogToConsole("Unable to start server 5 times, disabling auto-restart.");
                AutoRestartCheckbox.IsChecked = false;
                StartServerButton.IsEnabled = true;
                StopServerButton.IsEnabled = false;                
                if (Properties.Settings.Default.EnableWebhook && discordSender.WebHook != "" && Properties.Settings.Default.WebhookMessages[3] != "")
                    discordSender.SendMessage(Properties.Settings.Default.WebhookMessages[3]);
                return;
            }
            if (restartAttempts == 0)
                SetTimer();
            restartAttempts++;
            if (File.Exists(Properties.Settings.Default.Server_Path + @"\VRisingServer.exe") == true)
            {
                StopServerButton.IsEnabled = true;
                StartServerButton.IsEnabled = false;
                string parameters = String.Format(@"-persistentDataPath ""{0}"" -serverName ""{1}"" -saveName ""{2}"" -logFile ""{3}\VRisingServer.log""{4}", Properties.Settings.Default.Save_Path, Properties.Settings.Default.Server_Name, Properties.Settings.Default.Save_Name, Properties.Settings.Default.Log_Path, (Properties.Settings.Default.BindToIP) ? String.Format(@" -address ""{0}""", BindToIPTextbox.Text) : "");
                Process serverProcess = new Process();
                serverProcess.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
                serverProcess.StartInfo.FileName = Properties.Settings.Default.Server_Path + @"\VRisingServer.exe";
                serverProcess.StartInfo.UseShellExecute = true;
                serverProcess.StartInfo.Arguments = parameters;
                serverProcess.EnableRaisingEvents = true;
                serverProcess.Exited += new EventHandler(serverProcessExited);
                serverProcess.Start();
                //StoppedPic.Visible = false;
                //RunningPic.Visible = true;
                StatusText.Text = "Status: Running";
                LogToConsole("Server starting.\rServer name: " + Properties.Settings.Default.Server_Name + "\rSave name: " + Properties.Settings.Default.Save_Name);
                userStopped = false;
                if (Properties.Settings.Default.EnableWebhook && discordSender.WebHook != "" && Properties.Settings.Default.WebhookMessages[0] != "")
                    discordSender.SendMessage(Properties.Settings.Default.WebhookMessages[0]);
            }
            else
            {
                System.Windows.MessageBox.Show("'VRisingServer.exe' not found. Please make sure server is installed correctly.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UpdateSteamCMDStatus(string status)
        {
            Dispatcher.Invoke(new Action(() =>
            {
                SteamCMDStatusText.Text = status;
            }));
        }
        private void UpdateLastUpdateStatus(string status)
        {
            Dispatcher.Invoke(new Action(() =>
            {
                LastUpdateText.Text = status;
            }));
        }

        private void UpdateTimer()
        {
            ucTimer.Interval = Properties.Settings.Default.AutoUpdateInterval * 60000;
            ucTimer.Start();
        }

        private async Task UpdateGame()
        {            
            if (Process.GetProcessesByName("vrisingserver").Length > 0)
            {
                System.Windows.MessageBox.Show("Server is already running. Shut down the server before updating.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (File.Exists(Properties.Settings.Default.Server_Path + @"\SteamCMD\steamcmd.exe") == false)
            {
                if (System.Windows.Forms.MessageBox.Show("VSM will now download SteamCMD.\nThis is used to update and manage the server.\nIs this ok?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No)
                    return;
                UpdateSteamCMDStatus("SteamCMD: Downloading...");
                LogToConsole("SteamCMD not found. Downloading...");
                byte[] fileBytes = await HttpClient.GetByteArrayAsync(@"https://steamcdn-a.akamaihd.net/client/installer/steamcmd.zip");
                await File.WriteAllBytesAsync(Properties.Settings.Default.Server_Path + @"\steamcmd.zip", fileBytes);
                if (File.Exists(Properties.Settings.Default.Server_Path + @"\SteamCMD\steamcmd.exe") == true)
                {
                    File.Delete(Properties.Settings.Default.Server_Path + @"\SteamCMD\steamcmd.exe");
                }
                LogToConsole("Unzipping...");
                ZipFile.ExtractToDirectory(Properties.Settings.Default.Server_Path + @"\steamcmd.zip", Properties.Settings.Default.Server_Path + @"\SteamCMD");
                if (File.Exists(Properties.Settings.Default.Server_Path + @"\steamcmd.zip"))
                {
                    File.Delete(Properties.Settings.Default.Server_Path + @"\steamcmd.zip");
                }
            }
            else
            {
                UpdateSteamCMDStatus("SteamCMD: Running...");
                LogToConsole("SteamCMD found. Running...");
            }
            if (File.Exists(Properties.Settings.Default.Server_Path + @"\VRisingServer_Data\StreamingAssets\Settings\adminlist.txt") && File.Exists(Properties.Settings.Default.Server_Path + @"\VRisingServer_Data\StreamingAssets\Settings\banlist.txt") && Properties.Settings.Default.VerifyUpdate)
            {
                Directory.CreateDirectory(Properties.Settings.Default.Server_Path + @"\Backup");
                File.Copy(Properties.Settings.Default.Server_Path + @"\VRisingServer_Data\StreamingAssets\Settings\adminlist.txt", Properties.Settings.Default.Server_Path + @"\Backup\adminlist.txt", true);
                File.Copy(Properties.Settings.Default.Server_Path + @"\VRisingServer_Data\StreamingAssets\Settings\banlist.txt", Properties.Settings.Default.Server_Path + @"\Backup\banlist.txt", true);
            }
            UpdateSteamCMDStatus("SteamCMD: Updating game...");
            LogToConsole("Updating game...");
            string parameters = String.Format("+force_install_dir {0} +login anonymous +app_update 1829350 {1}+quit", Properties.Settings.Default.Server_Path, (Properties.Settings.Default.VerifyUpdate) ? "validate " : "");
            var steamcmd = Process.Start(Properties.Settings.Default.Server_Path + @"\SteamCMD\steamcmd.exe", parameters);
            await steamcmd.WaitForExitAsync();
            LogToConsole("Update completed.");
            if (File.Exists(Properties.Settings.Default.Server_Path + @"\Backup\adminlist.txt") && File.Exists(Properties.Settings.Default.Server_Path + @"\Backup\banlist.txt") && Properties.Settings.Default.VerifyUpdate)
            {
                LogToConsole("Restoring backups of adminlist and banlist.");
                Directory.CreateDirectory(Properties.Settings.Default.Server_Path + @"\Backup");
                File.Copy(Properties.Settings.Default.Server_Path + @"\Backup\adminlist.txt", Properties.Settings.Default.Server_Path + @"\VRisingServer_Data\StreamingAssets\Settings\adminlist.txt", true);
                File.Copy(Properties.Settings.Default.Server_Path + @"\Backup\banlist.txt", Properties.Settings.Default.Server_Path + @"\VRisingServer_Data\StreamingAssets\Settings\banlist.txt", true);
            }
            await CheckForUpdate();
        }

        private async Task<bool> CheckForUpdate()
        {
            bool foundUpdate = false;
            await Task.Run(() =>
            {
                if (File.Exists(Properties.Settings.Default.Server_Path + @"\SteamCMD\steamcmd.exe") == false)
                {
                    UpdateSteamCMDStatus("SteamCMD AutoUpdate: ERROR, could not find SteamCMD.");
                    foundUpdate = false;
                }
                else
                {
                    UpdateSteamCMDStatus("SteamCMD AutoUpdate: Fetching information.");
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
                    UpdateSteamCMDStatus("SteamCMD Status: Not running");
                    UpdateLastUpdateStatus("Last Update on Steam: " + DateTimeOffset.FromUnixTimeSeconds(long.Parse(Properties.Settings.Default.LastUpdateUNIXTime)).DateTime.ToString());
                }
            });
            return foundUpdate;
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
                    LogToConsole("Terminating server for update.");
                    proc.CloseMainWindow();
                    proc.WaitForExit();
                    LogToConsole("Server terminated.");
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
                        LogToConsole(result);
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
            LogToConsole("Waiting 5 minutes to update.");
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
                StartServerButton.IsEnabled = false;
                StopServerButton.IsEnabled = true;
                //StoppedPic.Visible = false;
                //RunningPic.Visible = true;
                StatusText.Text = "Status: Running";
                LogToConsole("Server found running.");
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

        private async void AutoUpdateElapsed(object? sender, EventArgs e)
        {
            bool updateFound = await CheckForUpdate();
            if (updateFound == true)
                AutoUpdateServer();
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            restartAttempts = 0;
            RestartTimer.Stop();
        }

        private void serverProcessExited(object sender, EventArgs e)
        {
            Dispatcher.Invoke(new Action(() =>
            {
                if (userStopped == false && AutoRestartCheckbox.IsChecked == true)
                {
                    if (Properties.Settings.Default.EnableWebhook && discordSender.WebHook != "" && Properties.Settings.Default.WebhookMessages[2] != "")
                        discordSender.SendMessage(Properties.Settings.Default.WebhookMessages[2]);
                    //StoppedPic.Visible = true;
                    //RunningPic.Visible = false;
                    StatusText.Text = "Status: Stopped";
                    LogToConsole("Server closed unexpectedly. Restarting.");
                    StartServer();
                }
                else
                {
                    if (Properties.Settings.Default.EnableWebhook && discordSender.WebHook != "" && Properties.Settings.Default.WebhookMessages[1] != "")
                        discordSender.SendMessage(Properties.Settings.Default.WebhookMessages[1]);
                    //StoppedPic.Visible = true;
                    //RunningPic.Visible = false;
                    StatusText.Text = "Status: Stopped";
                    StopServerButton.IsEnabled = false;
                    StartServerButton.IsEnabled = true;
                    LogToConsole("Server stopped.");
                    userStopped = false;
                }
            }));            
        }

        private void LogToConsole(string output)
        {
            Dispatcher.Invoke(new Action(() =>
            {
                MainMenuConsole.AppendText("\r" + output);
                MainMenuConsole.ScrollToEnd();
            }));            
        }

        private void SaveSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void ManageAdminsButton_Click(object sender, RoutedEventArgs e)
        {
            if (!System.Windows.Application.Current.Windows.OfType<AdminManager>().Any())
            {
                AdminManager aManager = new AdminManager();
                aManager.Show();
            }
        }

        private void GameSettingsEditorButton_Click(object sender, RoutedEventArgs e)
        {
            if (!System.Windows.Application.Current.Windows.OfType<GameSettingsEditor>().Any())
            {
                GameSettingsEditor gSettingsEditor = new GameSettingsEditor();
                gSettingsEditor.Show();
            }
        }

        private void ServerSettingsEditorButton_Click(object sender, RoutedEventArgs e)
        {
            if (!System.Windows.Application.Current.Windows.OfType<ServerSettingsEditor>().Any())
            {
                ServerSettingsEditor sSettingsEditor = new ServerSettingsEditor();
                sSettingsEditor.Show();
            }
        }

        private void ManagerSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            if (!System.Windows.Application.Current.Windows.OfType<ManagerSettings>().Any())
            {
                ManagerSettings mSettings = new ManagerSettings();
                mSettings.Show();
            }
        }

        private void RCONConsoleButton_Click(object sender, RoutedEventArgs e)
        {
            if (!System.Windows.Application.Current.Windows.OfType<RconConsole>().Any())
            {
                RconConsole rConsole = new RconConsole();
                rConsole.Show();
            }
        }

        private void StartServerButton_Click(object sender, RoutedEventArgs e)
        {
            StartServer();
        }

        private void StopServerButton_Click(object sender, RoutedEventArgs e)
        {
            userStopped = true;
            StopServerButton.IsEnabled = false;
            LogToConsole("Stopping server.");
            Process[] processList = Process.GetProcessesByName("vrisingserver");
            foreach (Process proc in processList)
            {
                if (proc.MainModule.FileName == Properties.Settings.Default.Server_Path + @"\VRisingServer.exe")
                {
                    proc.CloseMainWindow();
                }
            }
        }

        private void UpdateServerButton_Click(object sender, RoutedEventArgs e)
        {
            _ = UpdateGame();
        }

        private void OpenServerFolderButton_Click(object sender, RoutedEventArgs e)
        {
            if (Directory.Exists(Properties.Settings.Default.Server_Path))
                Process.Start("explorer.exe", Properties.Settings.Default.Server_Path);
            else
                System.Windows.MessageBox.Show("Unable to find server folder.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
