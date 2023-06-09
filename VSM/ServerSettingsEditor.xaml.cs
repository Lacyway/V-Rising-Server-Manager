using System;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using System.Text.Json;
using System.Collections.ObjectModel;
using ModernWpf.Controls;
using VRisingServerManager.Controls;

namespace VRisingServerManager
{
    /// <summary>
    /// Interaction logic for ServerSettingsEditor.xaml
    /// </summary>
    public partial class ServerSettingsEditor : Window
    {
        private ServerSettings serverSettings;
        private JsonSerializerOptions serializerOptions = new JsonSerializerOptions { WriteIndented = true };
        private readonly ObservableCollection<Server> servers;

        public ServerSettingsEditor(ObservableCollection<Server> sentServers, bool autoLoad = false, int indexToLoad = -1)
        {
            servers = sentServers;
            serverSettings = new ServerSettings();
            DataContext = serverSettings;
            InitializeComponent();

            if (autoLoad == true && indexToLoad != -1 && servers.Count > 0)
            {
                AutoLoad(indexToLoad);
            }
        }

        private void AutoLoad(int serverIndex)
        {
            string fileToLoad = servers[serverIndex].Path + @"\SaveData\Settings\ServerHostSettings.json";
            if (!File.Exists(fileToLoad))
            {
                _ = new ContentDialog
                {
                    Owner = this,
                    Title = "Error",
                    Content = $"Unable to load: {fileToLoad}\nMake sure it exists.",
                    CloseButtonText = "Ok",
                    DefaultButton = ContentDialogButton.Close
                }.ShowAsync();
                return;
            }
                

            using (StreamReader reader = new StreamReader(fileToLoad))
            {
                string LoadedJSON = reader.ReadToEnd();
                ServerSettings LoadedSettings = JsonSerializer.Deserialize<ServerSettings>(LoadedJSON);
                serverSettings = LoadedSettings;
                DataContext = serverSettings;
            }
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
                    FileName = "ServerHostSettings.json",
                    InitialDirectory = Directory.GetCurrentDirectory()
                };
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

        private async void FileMenuSave_Click(object sender, RoutedEventArgs e)
        {
            if (servers.Count > 0)
            {
                ContentDialog yesNoDialog = new()
                {
                    Content = "Save to a server automatically? A backup of the original will be created if it exists.",
                    PrimaryButtonText = "Yes",
                    SecondaryButtonText = "No"
                };

                if (await yesNoDialog.ShowAsync() is ContentDialogResult.Primary)
                {
                    EditorSaveDialog dialog = new(servers)
                    {
                        PrimaryButtonText = "Save",
                        CloseButtonText = "Cancel"
                    };
                    Server server;

                    if (await dialog.ShowAsync() is ContentDialogResult.Primary)
                    {
                        server = dialog.GetServer();
                        if (!Directory.Exists(server.Path + @"\SaveData\Settings"))
                        {
                            MessageBox.Show("SaveData folder not found in the server path. Please make sure you have started the server once.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        if (File.Exists(server.Path + @"\SaveData\Settings\ServerHostSettings.json"))
                            File.Copy(server.Path + @"\SaveData\Settings\ServerHostSettings.json", server.Path + @"\SaveData\Settings\ServerHostSettings.bak", true);

                        string SettingsJSON = JsonSerializer.Serialize(serverSettings, serializerOptions);
                        File.WriteAllText(server.Path + @"\SaveData\Settings\ServerHostSettings.json", SettingsJSON);
                        MessageBox.Show("File successfully saved to: \n" + server.Path + @"\SaveData\Settings\ServerHostSettings.json");
                        return;
                    }
                    else
                    {
                        return;
                    }
                }
            }

            try
            {
                string SettingsJSON = JsonSerializer.Serialize(serverSettings, serializerOptions);
                SaveFileDialog SaveSettingsDialog = new SaveFileDialog
                {
                    Filter = "\"JSON files\"|*.json",
                    DefaultExt = "json",
                    FileName = "ServerHostSettings.json",
                    InitialDirectory = Directory.GetCurrentDirectory()
                };
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

        private void FileMenuExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
