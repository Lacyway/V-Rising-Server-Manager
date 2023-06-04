using System;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Forms;

namespace VRisingServerManager
{
    /// <summary>
    /// Interaction logic for CreateServer.xaml
    /// </summary>
    public partial class CreateServer : Window
    {
        Server newServer = new Server();
        MainSettings settings;
        public JsonSerializerOptions serializerOptions = new JsonSerializerOptions { WriteIndented = true };

        public CreateServer(MainSettings mainSettings)
        {            
            InitializeComponent();
            settings = mainSettings;
            DataContext = newServer;
        }

        private void ServerPathButton_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog
            {
                RootFolder = Environment.SpecialFolder.Desktop,
                SelectedPath = newServer.Path
            };

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK && dialog.SelectedPath != "")
            {
                newServer.Path = dialog.SelectedPath;
            }            
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (Server server in settings.Servers)
            {
                if (server.Name == newServer.Name)
                {
                    System.Windows.MessageBox.Show("Another server with this name already exists. Please choose another name!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }                    
            }

            if (!Directory.Exists(newServer.Path))
                Directory.CreateDirectory(newServer.Path);

            if (File.Exists(newServer.Path + @"\VRisingServer.exe"))
            {
                if (System.Windows.MessageBox.Show("There seems to be another server located in this folder. It's recommended to choose another directory to avoid problems.\r\rContinue anyway?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                    return;
            }

            settings.Servers.Add(newServer);
            settings.Save(settings);
            Close();
        }
    }
}
