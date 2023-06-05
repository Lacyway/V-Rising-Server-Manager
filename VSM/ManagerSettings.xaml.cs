using System.Windows;

namespace VRisingServerManager
{
    /// <summary>
    /// Interaction logic for ManagerSettings.xaml
    /// </summary>
    public partial class ManagerSettings : Window
    {
        MainSettings localMainSettings;
        public ManagerSettings(MainSettings mainSettings)
        {
            localMainSettings = mainSettings;
            DataContext = localMainSettings;
            InitializeComponent();            
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            MainSettings.Save(localMainSettings);
            Close();
        }
    }
}
