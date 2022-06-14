using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Windows.Navigation;

namespace VRisingServerManager
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AdminManager : Window
    {
        public AdminManager()
        {
            InitializeComponent();
            ReloadList(Properties.Settings.Default.Server_Path + @"\VRisingServer_Data\StreamingAssets\Settings\adminlist.txt");
        }

        public void ReloadList(string filePath)
        {
            if (File.Exists(Properties.Settings.Default.Server_Path + @"\VRisingServer_Data\StreamingAssets\Settings\adminlist.txt"))
            {
                AdminList.Items.Clear();
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        AdminList.Items.Add(line);
                    }
                    sr.Close();
                }
            }
            else
            {
                MessageBox.Show("Unable to find adminlist.txt\nPlease make sure server path is correctly configured.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddAdminButton_Click(object sender, RoutedEventArgs e)
        {
            if (AdminToAdd.Text != "")
            {
                AdminList.Items.Add(AdminToAdd.Text);
            }
            else
            {
                MessageBox.Show("ID to add is empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RemoveAdminButton_Click(object sender, RoutedEventArgs e)
        {
            if (AdminList.SelectedIndex != -1)
            {
                AdminList.Items.RemoveAt(AdminList.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Please select an ID to remove.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start("explorer.exe", "https://steamid.io/lookup");
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(Properties.Settings.Default.Server_Path + @"\VRisingServer_Data\StreamingAssets\Settings\adminlist.txt"))
            {
                string sPath = string.Format(@"{0}\VRisingServer_Data\StreamingAssets\Settings\adminlist.txt", Properties.Settings.Default.Server_Path);
                StreamWriter SaveFile = new StreamWriter(sPath);
                foreach (var item in AdminList.Items)
                {
                    SaveFile.WriteLine(item);
                }
                SaveFile.Close();
                Close();
            }
            else
            {
                MessageBox.Show("Unable to find adminlist.txt\nPlease make sure server path is correctly configured.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ReloadButton_Click(object sender, RoutedEventArgs e)
        {
            ReloadList(Properties.Settings.Default.Server_Path + @"\VRisingServer_Data\StreamingAssets\Settings\adminlist.txt");
        }
    }
}
