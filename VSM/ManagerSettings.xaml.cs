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

            if (mainSettings.Servers.Count > 0 )
            {
                ServerCombo.SelectedIndex = 0;
                ServerCombo2.SelectedIndex = 0;
            }
            else
            {
                ServerCombo.IsEnabled = false;
                ServerCombo2.IsEnabled = false;
                ResetServerButton.IsEnabled = false;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            MainSettings.Save(localMainSettings);
            Close();
        }

        private void ResetServerButton_Click(object sender, RoutedEventArgs e)
        {
            localMainSettings.Servers[ServerCombo.SelectedIndex].WebhookMessages = new();
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {            
            localMainSettings.WebhookSettings.UpdateFound = new Webhook().UpdateFound;
            localMainSettings.WebhookSettings.UpdateWait = new Webhook().UpdateWait;
        }
    }
}
