using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Text.RegularExpressions;
using System.Threading;
using System.ComponentModel;

namespace VRisingServerManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainSettings vsmSettings = new();
        private static dWebhook discordSender = new();
        private static HttpClient httpClient = new();
        private PeriodicTimer? autoUpdateTimer;

        public MainWindow()
        {
            if (!File.Exists(Directory.GetCurrentDirectory() + @"\VSMSettings.json"))
                MainSettings.Save(vsmSettings);
            else
                vsmSettings = MainSettings.Load();

            DataContext = vsmSettings;
            InitializeComponent();

            vsmSettings.AppSettings.PropertyChanged += AppSettings_PropertyChanged;
            vsmSettings.Servers.CollectionChanged += Servers_CollectionChanged; // MVVM method not working

            vsmSettings.AppSettings.Version = new AppSettings().Version;

            LogToConsole("V Rising Server Manager started." + ((vsmSettings.Servers.Count > 0) ? "\r" + vsmSettings.Servers.Count.ToString() + " servers loaded from config." : "\rNo servers found, press 'Add Server' to get started."));

            ScanForServers();
            SetupTimer();
            if (vsmSettings.AppSettings.AutoUpdateApp == true)
                LookForUpdate();
        }

        private async void LookForUpdate()
        {
            string latestVersion = await httpClient.GetStringAsync("https://raw.githubusercontent.com/Lacyway/V-Rising-Server-Manager/master/VERSION");
            latestVersion = latestVersion.Trim();

            if (latestVersion != vsmSettings.AppSettings.Version)
            {
                if (MessageBox.Show($"There is a new version available for download. Would you like to automatically update?\r\rCurrent: {vsmSettings.AppSettings.Version}\rLatest: {latestVersion}", "VSM Updater - New Update Found", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Process.Start("VSMUpdater.exe");
                    Application.Current.MainWindow.Close();
                }
            }
            else
            {
                LogToConsole($"Running latest version: {latestVersion}");
            }
        }

        /// <summary>
        /// Sets up the timer for AutoUpdates
        /// </summary>
        private void SetupTimer()
        {
            if (vsmSettings.AppSettings.AutoUpdate == true)
            {
#if DEBUG
                autoUpdateTimer = new PeriodicTimer(TimeSpan.FromSeconds(10));
#else
                autoUpdateTimer = new PeriodicTimer(TimeSpan.FromMinutes(vsmSettings.AppSettings.AutoUpdateInterval));
#endif
                AutoUpdateLoop();
            }
        }

        private async void AutoUpdateLoop()
        {
            while (await autoUpdateTimer.WaitForNextTickAsync())
            {
                bool foundUpdate = await CheckForUpdate();
                if (foundUpdate == true && vsmSettings.Servers.Count > 0)
                {
                    if (vsmSettings.WebhookSettings.Enabled == true)
                        SendDiscordMessage("An update was found for the game. Starting auto-update.");
                    await AutoUpdate();
                }
            }
        }
        
        private void LogToConsole(string logMessage)
        {
            Dispatcher.Invoke(new Action(() =>
            {
                MainMenuConsole.AppendText(logMessage + "\r");
                MainMenuConsole.ScrollToEnd();
            }));
        }

        private void SendDiscordMessage(string message)
        {
            if (vsmSettings.WebhookSettings.Enabled == false || message == "")
                return;

            if (discordSender.WebHook == null && vsmSettings.WebhookSettings.URL != "")
            {
                discordSender.WebHook = vsmSettings.WebhookSettings.URL;
            }
            //else
            //{
            //    LogToConsole("Webhook tried to send a message but URL is undefined.");
            //}

            discordSender.SendMessage(message);
        }

        /// <summary>
        /// Updates SteamCMD, used when the executable could not be found
        /// </summary>
        /// <returns><see cref="bool"/> true if succeeded</returns>
        private async Task<bool> UpdateSteamCMD()
        {            
            string workingDir = Directory.GetCurrentDirectory();
            LogToConsole("SteamCMD not found. Downloading...");
            byte[] fileBytes = await httpClient.GetByteArrayAsync(@"https://steamcdn-a.akamaihd.net/client/installer/steamcmd.zip");
            await File.WriteAllBytesAsync(workingDir + @"\steamcmd.zip", fileBytes);
            if (File.Exists(workingDir + @"\SteamCMD\steamcmd.exe") == true)
            {
                File.Delete(workingDir + @"\SteamCMD\steamcmd.exe");
            }
            LogToConsole("Unzipping...");
            ZipFile.ExtractToDirectory(workingDir + @"\steamcmd.zip", workingDir + @"\SteamCMD");
            if (File.Exists(workingDir + @"\steamcmd.zip"))
            {
                File.Delete(workingDir + @"\steamcmd.zip");
            }

            LogToConsole("Fetching V Rising AppInfo.");
            await CheckForUpdate();

            return true;
        }

        private async Task<bool> UpdateGame(Server server)
        {
            server.Runtime.State = ServerRuntime.ServerState.Updating;

            if (server.Runtime.Process != null)
            {
                LogToConsole("Server is already running. Exiting.");
                return false;
            }

            if (!File.Exists(Directory.GetCurrentDirectory() + @"\SteamCMD\steamcmd.exe"))
            {
                bool sCMDSuccess = await UpdateSteamCMD();
                if (!sCMDSuccess == true)
                {
                    LogToConsole("Unable to download SteamCMD. Exiting update process.");
                    server.Runtime.State = ServerRuntime.ServerState.Stopped;
                    return false;
                }
            }

            string workingDir = Directory.GetCurrentDirectory();
            LogToConsole("Updating game server: " + server.Name);
            string[] installScript = { "force_install_dir \"" + server.Path + "\"", "login anonymous", (vsmSettings.AppSettings.VerifyUpdates) ? "app_update 1829350 validate" : "app_update 1829350", "quit" };
            if (File.Exists(server.Path + @"\steamcmd.txt"))
                File.Delete(server.Path + @"\steamcmd.txt");
            File.WriteAllLines(server.Path + @"\steamcmd.txt", installScript);
            string parameters = "+runscript " + server.Path + @"\steamcmd.txt";
            Process steamcmd = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = workingDir + @"\SteamCMD\steamcmd.exe",
                    Arguments = parameters,
                    CreateNoWindow = !vsmSettings.AppSettings.ShowSteamWindow
                }
            };
            steamcmd.Start();
            await steamcmd.WaitForExitAsync();
            LogToConsole("Update completed on server: " + server.Name);
            server.Runtime.State = ServerRuntime.ServerState.Stopped;
            return true;
        }

        private async Task<bool> StartServer(Server server)
        {
            if (server.Runtime.Process != null)
            {
                LogToConsole($"ERROR: {server.Name} is already running");
                return false;
            }

            if (File.Exists(server.Path + @"\VRisingServer.exe"))
            {
                LogToConsole("Starting server: " + server.Name + (server.Runtime.RestartAttempts > 0 ? $" Attempt {server.Runtime.RestartAttempts}/3." : ""));
                if (vsmSettings.WebhookSettings.Enabled == true)
                    SendDiscordMessage($"Starting server **{server.LaunchSettings.DisplayName}**." + (server.Runtime.RestartAttempts > 0 ? $" Attempt {server.Runtime.RestartAttempts}/3." : ""));
                string parameters = $@"-persistentDataPath ""{server.Path + @"\SaveData"}"" -serverName ""{server.Name}"" -saveName ""{server.LaunchSettings.WorldName}"" -logFile ""{server.Path + @"\logs\VRisingServer.log"}""{(server.LaunchSettings.BindToIP ? $@" -address ""{server.LaunchSettings.BindingIP}""" : "")}";
                Process serverProcess = new()
                {
                    StartInfo = new ProcessStartInfo
                    {
                        WindowStyle = ProcessWindowStyle.Minimized,
                        FileName = server.Path + @"\VRisingServer.exe",
                        UseShellExecute = true,
                        Arguments = parameters
                    },
                    EnableRaisingEvents = true
                };
                serverProcess.Exited += new EventHandler((sender, e) => ServerProcessExited(sender, e, server));
                serverProcess.Start();
                server.Runtime.State = ServerRuntime.ServerState.Running;
                server.Runtime.UserStopped = false;
                server.Runtime.Process = serverProcess;                
                return true;
            }
            else
            {
                LogToConsole("'VRisingServer.exe' not found. Please make sure server is installed correctly.");
                return false;
            }
        }

        private void ScanForServers()
        {
            int foundServers = 0;

            Process[] serverProcesses = Process.GetProcessesByName("vrisingserver");
            foreach (Process process in serverProcesses)
            {
                foreach (Server server in vsmSettings.Servers)
                {
                    if (process.MainModule.FileName == server.Path + @"\VRisingServer.exe")
                    {
                        server.Runtime.State = ServerRuntime.ServerState.Running;
                        process.EnableRaisingEvents = true;
                        process.Exited += new EventHandler((sender, e) => ServerProcessExited(sender, e, server));
                        server.Runtime.Process = process;
                        foundServers++;
                    }                        
                }
            }
            if (foundServers > 0)
            {
                LogToConsole($"Found {foundServers} servers that are running.");
            }
        }

        private async Task AutoUpdate()
        {
            if (!File.Exists(Directory.GetCurrentDirectory() + @"\SteamCMD\steamcmd.exe"))
            {
                await UpdateSteamCMD();
            }            

            List<Task> serverTasks = new List<Task>();
            List<Server> runningServers = new List<Server>();

            foreach(Server server in vsmSettings.Servers)
            {
                if (server.Runtime.State == ServerRuntime.ServerState.Running)
                {
                    serverTasks.Add(StopServer(server));
                    runningServers.Add(server);
                }
            }

            LogToConsole($"AutoUpdate starting on {vsmSettings.Servers.Count} server(s)." + ((runningServers.Count > 0) ? $"\rShutting down {runningServers.Count} server(s) before proceeding." : ""));

            await Task.WhenAll(serverTasks.ToArray());
            serverTasks.Clear();

            foreach (Server server in vsmSettings.Servers)
            {
                await UpdateGame(server);
            }

            foreach (Server server in runningServers)
            {
                serverTasks.Add(StartServer(server));
            }

            await Task.WhenAll(serverTasks.ToArray());
            LogToConsole("Auto-update completed.");
        }

        private async Task<bool> StopServer(Server server)
        {
            LogToConsole("Stopping server: " + server.Name);
            if (vsmSettings.WebhookSettings.Enabled == true)
                SendDiscordMessage($"Stopping server **{server.LaunchSettings.DisplayName}**.");
            bool success;
            bool close = server.Runtime.Process.CloseMainWindow();            
            if (close)
            {
                await server.Runtime.Process.WaitForExitAsync();
                server.Runtime.Process = null;
                success = true;
            }
            else
            {
                success = false;
            }
            return success;
        }

        private async Task<bool> RemoveServer(Server server)
        {            
            int serverIndex = vsmSettings.Servers.IndexOf(server);
            if (MessageBox.Show($"Are you sure you want to remove the server {server.Name}?\nThis action is permanent and all files will be removed.", "Remove Server - Verification", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
            {
                return false;
            }
            if (serverIndex != -1)
            {
                if (MessageBox.Show($@"Create a backup of the save?{Environment.NewLine}It will be saved to: {Directory.GetCurrentDirectory()}\Backups\{server.Name}_Bak.zip", "Remove Server - Backup", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (!Directory.Exists(Directory.GetCurrentDirectory() + @"\Backups"))
                        Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\Backups");
                    if (Directory.Exists(server.Path + @"\SaveData\Saves\v2\" + server.LaunchSettings.WorldName))
                    {
                        if (File.Exists(Directory.GetCurrentDirectory() + @"\Backups\" + server.Name + "_Bak.zip"))
                            File.Delete(Directory.GetCurrentDirectory() + @"\Backups\" + server.Name + "_Bak.zip");
                        ZipFile.CreateFromDirectory(server.Path + @"\Saves\v2\" + server.LaunchSettings.WorldName, Directory.GetCurrentDirectory() + @"\Backups\" + server.Name + "_Bak.zip");
                    }                    
                }
                vsmSettings.Servers.RemoveAt(serverIndex);
                if (Directory.Exists(server.Path))
                    Directory.Delete(server.Path, true);
                return true;                
            }
            else
            {
                return false;
            }
        }

        private async Task<bool> CheckForUpdate()
        {
            bool foundUpdate = false;
            if (!File.Exists(Directory.GetCurrentDirectory() + @"\SteamCMD\steamcmd.exe"))
            {
                LogToConsole("ERROR: Could not find SteamCMD when checking for updates.");
                return foundUpdate;
            }
            else
            {
                string parameters = @"+login anonymous +app_info_update 1829350 +app_info_print 1829350 +quit";
                Process steamCMD = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = Directory.GetCurrentDirectory() + @"\SteamCMD\steamcmd.exe",
                        CreateNoWindow = true,
                        UseShellExecute = false,
                        Arguments = parameters,
                        RedirectStandardOutput = true
                    }
                };
                steamCMD.Start();
                string output = await steamCMD.StandardOutput.ReadToEndAsync();
                string[] toScan = output.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                await steamCMD.WaitForExitAsync();
                for (int i = 0; i < toScan.Length; i++)
                {
                    if (toScan[i].Contains("\"branches\"") && toScan[i + 2].Contains("\"public\""))
                    {
                        string lastUpdated = Regex.Match(toScan[i + 5], "(?<=\")[0-9]+(?=\")").Value;
                        if (lastUpdated != vsmSettings.AppSettings.LastUpdateTimeUNIX)
                        {
                            vsmSettings.AppSettings.LastUpdateTimeUNIX = lastUpdated;
                            foundUpdate = true;
                        }
                        if (vsmSettings.AppSettings.LastUpdateTimeUNIX == "")
                        {
                            vsmSettings.AppSettings.LastUpdateTimeUNIX = lastUpdated;
                            foundUpdate = false;
                        }
                    }
                }
                vsmSettings.AppSettings.LastUpdateTime = "Last Update on Steam: " + DateTimeOffset.FromUnixTimeSeconds(long.Parse(vsmSettings.AppSettings.LastUpdateTimeUNIX)).DateTime.ToString();
            }
            MainSettings.Save(vsmSettings);
            return foundUpdate;
        }

        private async void ReadLog(Server server)
        {
            using (FileStream fs = new FileStream(server.Path + @"\Logs\VRisingServer.log", FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
            using (StreamReader sr = new StreamReader(fs))
            {
                string ipAddress = "";
                string steamID = "";
                int foundVariables = 0;

                while (foundVariables < 3 && server.Runtime.Process != null)
                {
                    string line = await sr.ReadLineAsync();
                    if (line != null)
                    {
                        if (line.Contains("SteamPlatformSystem - OnPolicyResponse - Public IP: "))
                        {
                            ipAddress = line.Split("SteamPlatformSystem - OnPolicyResponse - Public IP: ")[1];
                            foundVariables++;
                        }
                        if (line.Contains("SteamNetworking - Successfully logged in with the SteamGameServer API. SteamID: "))
                        {
                            steamID = line.Split("SteamNetworking - Successfully logged in with the SteamGameServer API. SteamID: ")[1];
                            foundVariables++;
                        }
                        if (line.Contains("Shutting down Asynchronous Streaming"))
                            foundVariables++;
                    }                    
                }

                if (foundVariables == 3)
                    SendDiscordMessage($"Server **{server.LaunchSettings.DisplayName}** is ready.\rPublic IP: {ipAddress}\rSteam ID: {steamID}");

                sr.Close();
                fs.Close();
            }
        }

        #region Events
        private async void ServerProcessExited(object sender, EventArgs e, Server server)
        {
            server.Runtime.State = ServerRuntime.ServerState.Stopped;

            switch (server.Runtime.Process.ExitCode)
            {
                case 1:
                    LogToConsole($"{server.Name} crashed.");
                    break;
                case -2147483645:
                    LogToConsole($"{server.Name} exited with code '-2147483645' which can occur when ports failed to open. Make sure no other server is using the same ports.");
                    break;
            }

            server.Runtime.Process = null;

            if (server.Runtime.RestartAttempts >= 3)
            {
                LogToConsole($"Server '{server.Name}' attempted to restart 3 times unsuccessfully. Disabling auto-restart.");
                if (vsmSettings.WebhookSettings.Enabled == true)
                    SendDiscordMessage($"Server **{server.LaunchSettings.DisplayName}** attempted to restart 3 times unsuccessfully. Disabling auto-restart.");
                server.Runtime.RestartAttempts = 0;
                server.AutoRestart = false;
                return;
            }

            if (server.AutoRestart == true && server.Runtime.UserStopped == false)
            {
                server.Runtime.RestartAttempts++;
                if (vsmSettings.WebhookSettings.Enabled == true)
                    SendDiscordMessage($"Server **{server.LaunchSettings.DisplayName}** stopped unexpectedly. Restarting.");
                await StartServer(server);
            }
        }

        private void AppSettings_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "AutoUpdate":
                    if (vsmSettings.AppSettings.AutoUpdate == true)
                    {
#if DEBUG
                        autoUpdateTimer = new PeriodicTimer(TimeSpan.FromSeconds(10));
#else
                        autoUpdateTimer = new PeriodicTimer(TimeSpan.FromMinutes(vsmSettings.AppSettings.AutoUpdateInterval));
#endif
                        AutoUpdateLoop();
                    }
                    else
                    {
                        if (autoUpdateTimer != null)
                        {
                            autoUpdateTimer.Dispose();
                        }
                    }
                    break;
                case "AutoUpdateInterval":
                    if (vsmSettings.AppSettings.AutoUpdate == true && autoUpdateTimer != null)
                    {
                        autoUpdateTimer.Dispose();
#if DEBUG
                        autoUpdateTimer = new PeriodicTimer(TimeSpan.FromSeconds(10));
#else
                        autoUpdateTimer = new PeriodicTimer(TimeSpan.FromMinutes(vsmSettings.AppSettings.AutoUpdateInterval));
#endif                        
                        AutoUpdateLoop();
                    }
                    break;
            }
        }

        private void Servers_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            int serversLength = ServerTabControl.Items.Count;
            if (serversLength > 0)
            {
                ServerTabControl.SelectedIndex = serversLength - 1;
            }
        }
#endregion

        #region Buttons
        private async void StartServerButton_Click(object sender, RoutedEventArgs e)
        {
            Server server = ((Button)sender).DataContext as Server;

            MainSettings.Save(vsmSettings);

            bool started = await StartServer(server);

            await Task.Delay(3000);

            if (started == true && vsmSettings.WebhookSettings.Enabled)
                ReadLog(server);
        }

        private async void UpdateServerButton_Click(object sender, RoutedEventArgs e)
        {
            Server server = ((Button)sender).DataContext as Server;

            await UpdateGame(server);
        }

        private async void StopServerButton_Click(object sender, RoutedEventArgs e)
        {
            Server server = ((Button)sender).DataContext as Server;

            server.Runtime.UserStopped = true;

            bool success = await StopServer(server);
            if (success)
            {
                LogToConsole("Successfully stopped server: " + server.Name);
            }
            else
            {
                LogToConsole("Unable to stop server: " + server.Name);
            }   
        }

        private async void RemoveServerButton_Click(object sender, RoutedEventArgs e)
        {
            Server server = ((Button)sender).DataContext as Server;

            if (server == null)
            {
                LogToConsole("ERROR: Unable to find selected server to delete");
                return;
            }
            bool success = await RemoveServer(server);
            if (!success)
                LogToConsole("There was an error deleting the server or the action was aborted.");
            else
                MainSettings.Save(vsmSettings);
        }

        private void ServerSettingsEditorButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Application.Current.Windows.OfType<ServerSettingsEditor>().Any())
            {
                ServerSettingsEditor sSettingsEditor = new ServerSettingsEditor();
                sSettingsEditor.Show();
            }
        }

        private void ManageAdminsButton_Click(object sender, RoutedEventArgs e)
        {
            Server server = ((Button)sender).DataContext as Server;

            if (!File.Exists(server.Path + @"\SaveData\Settings\adminlist.txt"))
            {
                LogToConsole("Unable to find adminlist.txt, please make sure the server is installed correctly.");
                return;
            }

            if (!Application.Current.Windows.OfType<AdminManager>().Any())
            {
                AdminManager aManager = new AdminManager(server);
                aManager.Show();
            }
        }

        private void ServerFolderButton_Click(object sender, RoutedEventArgs e)
        {
            Server server = ((Button)sender).DataContext as Server;

            if (Directory.Exists(server.Path))
                Process.Start("explorer.exe", server.Path);
            else
                LogToConsole("Unable to find server folder.");
        }
        private void AddServerButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Application.Current.Windows.OfType<CreateServer>().Any())
            {
                CreateServer cServer = new(vsmSettings);
                cServer.Show();
            }
        }

        private void GameSettingsEditor_Click(object sender, RoutedEventArgs e)
        {
            if (!Application.Current.Windows.OfType<GameSettingsEditor>().Any())
            {
                GameSettingsEditor gSettingsEditor = new();
                gSettingsEditor.Show();
            }
        }

        private void ManagerSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Application.Current.Windows.OfType<ManagerSettings>().Any())
            {
                ManagerSettings mSettings = new(vsmSettings);
                mSettings.Show();
            }
        }

        private void VersionButton_Click(object sender, RoutedEventArgs e)
        {
            LookForUpdate();
        }
        #endregion        
    }
}