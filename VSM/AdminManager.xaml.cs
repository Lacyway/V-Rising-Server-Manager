using System.Windows;
using System.IO;
using System.Diagnostics;
using System.Windows.Navigation;

namespace VRisingServerManager
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AdminManager : Window
    {
        Server serverToManage;

        public AdminManager(Server server)
        {
            InitializeComponent();
            serverToManage = server;
            ReloadList(serverToManage.Path + @"\SaveData\Settings\adminlist.txt");
        }

        public void ReloadList(string filePath)
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
            if (AdminList.Items.Count > 0)
                AdminList.SelectedIndex = 0;
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
                if (AdminList.Items.Count > 0)
                    AdminList.SelectedIndex = 0;
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
            if (File.Exists(serverToManage.Path + @"\SaveData\Settings\adminlist.txt"))
            {
                string sPath = @$"{serverToManage.Path}\SaveData\Settings\adminlist.txt";
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
            ReloadList(serverToManage.Path + @"\SaveData\Settings\adminlist.txt");
        }
    }
}
