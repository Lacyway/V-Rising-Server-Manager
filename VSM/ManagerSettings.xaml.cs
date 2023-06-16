using ModernWpf.Controls;
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

        private async void ModSupportCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (localMainSettings.AppSettings.EnableModSupport == false)
            {
                return;
            }

            ContentDialog yesNoDialog = new()
            {
                Title = "Warning",
                Content = "Mod support is still experimental. Most mods will work and install automatically unless the author has a different format that deviates from the standard.\nMake sure that the mods you install work on the latest version and create backups of your saves regularly if you are installing new mods.\nThe server manager cannot be responsible for mods breaking/corrupting your saves.\n\nEnable mod support?",
                PrimaryButtonText = "Yes",
                CloseButtonText = "No",
                Owner = this
            };

            if (await yesNoDialog.ShowAsync() != ContentDialogResult.Primary)
                localMainSettings.AppSettings.EnableModSupport = false;
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
