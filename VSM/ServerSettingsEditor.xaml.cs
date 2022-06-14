using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.Text.Json;

namespace VRisingServerManager
{
    /// <summary>
    /// Interaction logic for ServerSettingsEditor.xaml
    /// </summary>
    public partial class ServerSettingsEditor : Window
    {
        public ServerSettings serverSettings;
        public JsonSerializerOptions serializerOptions = new JsonSerializerOptions { WriteIndented = true };

        public ServerSettingsEditor()
        {
            serverSettings = new ServerSettings();
            DataContext = serverSettings;
            InitializeComponent();
            if (Properties.Settings.Default.AutoLoadHostSettings == true && File.Exists(Properties.Settings.Default.HostSettingsFile))
                AutoLoad();
        }

        private void FileMenuLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string? FileToLoad = "temp";
                OpenFileDialog OpenSettingsDialog = new OpenFileDialog
                {
                    Filter = "\"JSON files\"|*.json",
                    DefaultExt = "json",
                    FileName = "ServerHostSettings.json"
                };
                if (Directory.Exists(Properties.Settings.Default.Save_Path + @"\Saves\v1\" + Properties.Settings.Default.Save_Name))
                {
                    OpenSettingsDialog.InitialDirectory = Properties.Settings.Default.Save_Path + @"\Saves\v1\" + Properties.Settings.Default.Save_Name;
                }
                else
                {
                    OpenSettingsDialog.InitialDirectory = Properties.Settings.Default.Save_Path;
                }
                if (OpenSettingsDialog.ShowDialog() == true && FileToLoad != null)
                {
                    FileToLoad = OpenSettingsDialog.FileName;
                }
                else
                {
                    return;
                }
                using (StreamReader reader = new StreamReader(FileToLoad))
                {
                    string LoadedJSON = reader.ReadToEnd();
                    ServerSettings LoadedSettings = JsonSerializer.Deserialize<ServerSettings>(LoadedJSON);
                    serverSettings = LoadedSettings;
                    DataContext = serverSettings;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void FileMenuSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string SettingsJSON = JsonSerializer.Serialize(serverSettings, serializerOptions);
                if (Properties.Settings.Default.AutoLoadHostSettings == true)
                {
                    if (MessageBox.Show("Save to auto-loaded file?", "Save", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        if (File.Exists(Properties.Settings.Default.HostSettingsFile))
                        {
                            File.Copy(Properties.Settings.Default.HostSettingsFile, Properties.Settings.Default.HostSettingsFile + ".bak", true);
                        }
                        File.WriteAllText(Properties.Settings.Default.HostSettingsFile, SettingsJSON);
                        MessageBox.Show("File successfully saved to: \n" + Properties.Settings.Default.HostSettingsFile);
                        return;
                    }
                }
                SaveFileDialog SaveSettingsDialog = new SaveFileDialog
                {
                    Filter = "\"JSON files\"|*.json",
                    DefaultExt = "json",
                    FileName = "ServerHostSettings.json"
                };
                if (Directory.Exists(Properties.Settings.Default.Save_Path + @"\Saves\v1\" + Properties.Settings.Default.Save_Name))
                {
                    SaveSettingsDialog.InitialDirectory = Properties.Settings.Default.Save_Path + @"\Saves\v1\" + Properties.Settings.Default.Save_Name;
                }
                else
                {
                    SaveSettingsDialog.InitialDirectory = Properties.Settings.Default.Save_Path;
                }
                if (SaveSettingsDialog.ShowDialog() == true)
                {
                    if (File.Exists(SaveSettingsDialog.FileName))
                    {
                        File.Copy(SaveSettingsDialog.FileName, SaveSettingsDialog.FileName + ".bak", true);
                    }
                    File.WriteAllText(SaveSettingsDialog.FileName, SettingsJSON);
                    MessageBox.Show("File successfully saved to: \n" + SaveSettingsDialog.FileName);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void AutoLoad()
        {
            using (StreamReader reader = new StreamReader(Properties.Settings.Default.HostSettingsFile))
            {
                string LoadedJSON = reader.ReadToEnd();
                ServerSettings LoadedSettings = JsonSerializer.Deserialize<ServerSettings>(LoadedJSON);
                serverSettings = LoadedSettings;
                DataContext = serverSettings;
            }
        }

        private void FileMenuExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
