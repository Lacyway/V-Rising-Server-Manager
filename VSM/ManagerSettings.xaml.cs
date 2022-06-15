using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace VRisingServerManager
{
    /// <summary>
    /// Interaction logic for ManagerSettings.xaml
    /// </summary>
    public partial class ManagerSettings : Window
    {
        public ManagerSettings()
        {
            InitializeComponent();
            // String collection doesn't add new values, only way as of now...
            if (Properties.Settings.Default.WebhookMessages.Count < 8)
            {
                for (int i = Properties.Settings.Default.WebhookMessages.Count; i <8; i++)
                {
                    Properties.Settings.Default.WebhookMessages.Add("Message to send.");
                }
                Properties.Settings.Default.Save();
            }            
        }

        private void SelectServerFolderButton_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog
            {
                RootFolder = Environment.SpecialFolder.MyComputer
            };
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK && dialog.SelectedPath != "")
            {
                Properties.Settings.Default.Server_Path = dialog.SelectedPath;
            }
        }

        private void SelectSaveFolderButton_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog
            {
                RootFolder = Environment.SpecialFolder.MyComputer
            };
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK && dialog.SelectedPath != "")
            {
                Properties.Settings.Default.Save_Path = dialog.SelectedPath;
            }
        }

        private void SelectLogFolderButton_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog
            {
                RootFolder = Environment.SpecialFolder.MyComputer
            };
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK && dialog.SelectedPath != "")
            {
                Properties.Settings.Default.Log_Path = dialog.SelectedPath;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Save();
            Close();
        }

        private void SelectGameSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                FileName = "ServerGameSettings.json"
            };
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                Properties.Settings.Default.GameSettingsFile = dialog.FileName;
        }

        private void SelectHostSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                FileName = "ServerHostSettings.json"
            };
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                Properties.Settings.Default.HostSettingsFile = dialog.FileName;
        }

        private void OpenSettingsFolder_Click(object sender, RoutedEventArgs e)
        {
            if (Directory.Exists(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Lacyway")))
                Process.Start("explorer.exe", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Lacyway");
        }
    }
}
