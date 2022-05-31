using System;
using System.Windows.Forms;
using System.Net;
using System.IO.Compression;
using System.IO;
using System.Diagnostics;
using System.Timers;

namespace ServerManager
{
        public partial class MainMenu : Form
        {

        public Process serverProcess = new Process();
        private static System.Timers.Timer RestartTimer;

        public MainMenu()
        {
            InitializeComponent();
            if (Properties.Settings.Default.UpgradeRequired)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.UpgradeRequired = false;
                Properties.Settings.Default.Save();
            }
            MainMenuConsole.AppendText("V Rising Server Manager Started\nServer Path: " + Properties.Settings.Default.Server_Path);
            ServerNameValue.Text = Properties.Settings.Default.Server_Name;
            SaveNameValue.Text = Properties.Settings.Default.Save_Name;
            CheckServer();
        }

        public void CheckServer()
        {
            Process[] processList = Process.GetProcessesByName("vrisingserver");
            bool foundServer = false;
            foreach (Process proc in processList)
            {
                if (proc.MainModule.FileName == Properties.Settings.Default.Server_Path + "\\VRisingServer.exe")
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
        public bool userStopped = false;
        public static string serverName = "V Rising Server";
        public static string saveName = "world1";
        public static int restartAttempts = 0;
        public async void StartSteamCMD()
        {
            if (Process.GetProcessesByName("vrisingserver").Length > 0)
            {
                MessageBox.Show("Server is already running. Shut down the server before updating.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (File.Exists(Properties.Settings.Default.Server_Path + "\\SteamCMD\\steamcmd.exe") == false)
            {
                MainMenuConsole.AppendText(Environment.NewLine + "SteamCMD not found. Downloading...");
                using (WebClient wc = new WebClient())
                {
                    Uri SteamCMDLink = new Uri("https://steamcdn-a.akamaihd.net/client/installer/steamcmd.zip");
                    Directory.CreateDirectory(Properties.Settings.Default.Server_Path);
                    MainMenuConsole.AppendText(Environment.NewLine + "Checking if folder exists...");
                    await wc.DownloadFileTaskAsync(SteamCMDLink, Properties.Settings.Default.Server_Path + "\\steamcmd.zip");
                }
                if (File.Exists(Properties.Settings.Default.Server_Path + "\\SteamCMD\\steamcmd.exe") == true)
                {
                    File.Delete(Properties.Settings.Default.Server_Path + "\\SteamCMD\\steamcmd.exe");
                }
                MainMenuConsole.AppendText(Environment.NewLine + "Unzipping...");
                ZipFile.ExtractToDirectory(Properties.Settings.Default.Server_Path + "\\steamcmd.zip", Properties.Settings.Default.Server_Path + "\\SteamCMD");
                MainMenuConsole.AppendText(Environment.NewLine + "Done!");
                if (File.Exists(Properties.Settings.Default.Server_Path + "\\steamcmd.zip"))
                {
                    File.Delete(Properties.Settings.Default.Server_Path + "\\steamcmd.zip");
                }
            }
            else
            {
                MainMenuConsole.AppendText(Environment.NewLine + "SteamCMD found. Running...");
            }
            if (File.Exists(Properties.Settings.Default.Server_Path + "\\VRisingServer.exe") == false)
            {
                MainMenuConsole.AppendText(Environment.NewLine + "Server not found. Install required.");
                string parameters = String.Format("+force_install_dir {0} +login anonymous +app_update 1829350 +quit", Properties.Settings.Default.Server_Path);
                var steamcmd = Process.Start(Properties.Settings.Default.Server_Path + "\\SteamCMD\\steamcmd.exe", parameters);
                steamcmd.WaitForExit();
                MainMenuConsole.AppendText(Environment.NewLine + "Install completed.");
            }
            else
            {
                MainMenuConsole.AppendText(Environment.NewLine + "Server found. Updating.");
                string parameters = String.Format("+force_install_dir {0} +login anonymous +app_update 1829350 +quit", Properties.Settings.Default.Server_Path);
                var steamcmd = Process.Start(Properties.Settings.Default.Server_Path + "\\SteamCMD\\steamcmd.exe", parameters);
                steamcmd.WaitForExit();
                MainMenuConsole.AppendText(Environment.NewLine + "Update completed.");
            }
            
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            SettingsForm SettingsMenu = new SettingsForm();
            SettingsMenu.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ServerSettingsForm ServerSettingsMenu = new ServerSettingsForm();
            ServerSettingsMenu.ShowDialog();
        }

        private void AppSettingsButton_Click(object sender, EventArgs e)
        {
            AppSettings AppSettingsMenu = new AppSettings();
            AppSettingsMenu.ShowDialog();
        }

        private void SteamCMDButton_Click(object sender, EventArgs e)
        {
            StartSteamCMD();
        }

        public async void StartServer()
        {
            if (Process.GetProcessesByName("vrisingserver").Length > 0)
            {
                MessageBox.Show("Server is already running.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }            
            if (restartAttempts == 5)
            {
                MainMenuConsole.AppendText(Environment.NewLine + "Unable to start server 5 times, disabling auto-restart.");
                AutoRestartCheck.Checked = false;
                StartGameServerButton.Enabled = true;
                StopGameServerButton.Enabled = false;
                return;
            }
            if (restartAttempts == 0)
            {
                SetTimer();
            }
            restartAttempts++;
            if (File.Exists(Properties.Settings.Default.Server_Path + "\\VRisingServer.exe") == true)
            {
                StopGameServerButton.Enabled = true;
                StartGameServerButton.Enabled = false;
                string parameters = String.Format("-persistentDataPath {0} -serverName \"{1}\" -saveName \"{2}\" -logFile \"{3}\\VRisingServer.log\"", Properties.Settings.Default.Save_Path, Properties.Settings.Default.Server_Name, Properties.Settings.Default.Save_Name, Properties.Settings.Default.Log_Path);
                Process serverProcess = new Process();
                serverProcess.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
                serverProcess.StartInfo.FileName = Properties.Settings.Default.Server_Path + "\\VRisingServer.exe";
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

        public void StartGameServerButton_Click(object sender, EventArgs e)
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

        public void StopGameServerButton_Click(object sender, EventArgs e)
        {
            userStopped = true;
            StopGameServerButton.Enabled = false;
            MainMenuConsole.AppendText(Environment.NewLine + "Stopping server.");
            Process[] processList = Process.GetProcessesByName("vrisingserver");
            foreach (Process proc in processList)
            {
                if (proc.MainModule.FileName == Properties.Settings.Default.Server_Path + "\\VRisingServer.exe")
                {
                    proc.CloseMainWindow();
                }
            }
        }

        private void ServerNameValue_Leave(object sender, EventArgs e)
        {
            Properties.Settings.Default.Server_Name = ServerNameValue.Text;
            Properties.Settings.Default.Save();
        }

        private void SaveNameValue_Leave(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save_Name = SaveNameValue.Text;
            Properties.Settings.Default.Save();
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
            RconConsoleMenu.ShowDialog();
        }

        private void ManageAdminsButton_Click(object sender, EventArgs e)
        {
            if (!File.Exists(Properties.Settings.Default.Server_Path + "\\VRisingServer_Data\\StreamingAssets\\Settings\\adminlist.txt"))
            {
                MessageBox.Show("Unable to find adminlist.txt\nPlease make sure server path is correctly configured.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                AdminManager AdminManagerMenu = new AdminManager();
                AdminManagerMenu.ShowDialog();
            }            
        }
    }
}
