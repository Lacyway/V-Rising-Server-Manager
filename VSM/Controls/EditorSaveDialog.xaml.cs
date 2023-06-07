using ModernWpf.Controls;
using System.Collections.ObjectModel;

namespace VRisingServerManager.Controls
{
    /// <summary>
    /// Interaction logic for EditorSaveDialog.xaml
    /// </summary>
    public partial class EditorSaveDialog : ContentDialog
    {
        public EditorSaveDialog(ObservableCollection<Server> servers)
        {
            DataContext = servers;
            InitializeComponent();
            if (servers.Count > 0 )
                ServerCombo.SelectedIndex = 0;
        }

        public Server? GetServer() => ServerCombo.SelectedItem as Server;
    }
}
