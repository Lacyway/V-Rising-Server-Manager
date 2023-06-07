using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Threading;
using VRisingServerManager.RCON;
using System.Windows.Forms.VisualStyles;

namespace VRisingServerManager
{
    /// <summary>
    /// Interaction logic for RconConsole.xaml
    /// </summary>
    public partial class RconConsole : Window
    {
        RemoteConClient rClient;
        Server server;

        public RconConsole(Server loadedServer)
        {
            server = loadedServer;
            DataContext = server;
            InitializeComponent();
            RconConsoleOutput.AppendText("RCON client ready.");
        }

        private void LogToConsole(string output)
        {
            Dispatcher.Invoke(new Action(() =>
            {
                RconConsoleOutput.AppendText("\r" + output);
                RconConsoleOutput.ScrollToEnd();
            }));            
        }

        private void Connect()
        {
            rClient = new RemoteConClient();
            rClient.UseUtf8 = true;
            Dispatcher.Invoke(new Action(() =>
            {
                ConnectButton.IsEnabled = false;
            }));            
            rClient.OnLog += message =>
            {
                LogToConsole(message);
            };
            rClient.OnConnectionStateChange += state =>
            {
                if (state == RemoteConClient.ConnectionStateChange.Connected)
                {
                    rClient.Authenticate(server.RconServerSettings.Password);
                    Dispatcher.Invoke(new Action(() =>
                    {
                        DisconnectButton.IsEnabled = true;
                        ParamaterTextbox.IsEnabled = true;
                        SendCommandButton.IsEnabled = true;                        
                    }));
                }
                if (state == RemoteConClient.ConnectionStateChange.Disconnected)
                {                    
                    Dispatcher.Invoke(new Action(() =>
                    {
                        DisconnectButton.IsEnabled = false;
                        ConnectButton.IsEnabled = true;
                        ParamaterTextbox.IsEnabled = false;
                        SendCommandButton.IsEnabled = false;                        
                    }));
                    LogToConsole("Disconnected.");
                }
                if (state == RemoteConClient.ConnectionStateChange.ConnectionLost)
                {
                    Dispatcher.Invoke(new Action(() =>
                    {
                        DisconnectButton.IsEnabled = false;
                        ConnectButton.IsEnabled = true;
                        ParamaterTextbox.IsEnabled = false;
                        SendCommandButton.IsEnabled = false;
                    }));
                    LogToConsole("Connection lost.");
                }
                if (state == RemoteConClient.ConnectionStateChange.ConnectionTimeout)
                {
                    Dispatcher.Invoke(new Action(() =>
                    {
                        DisconnectButton.IsEnabled = false;
                        ConnectButton.IsEnabled = true;
                        ParamaterTextbox.IsEnabled = false;
                        SendCommandButton.IsEnabled = false;
                    }));
                    LogToConsole("Connection timeout.");
                }
                if (state == RemoteConClient.ConnectionStateChange.NoConnection)
                {
                    Dispatcher.Invoke(new Action(() =>
                    {
                        DisconnectButton.IsEnabled = false;
                        ConnectButton.IsEnabled = true;
                        ParamaterTextbox.IsEnabled = false;
                        SendCommandButton.IsEnabled = false;                        
                    }));
                    LogToConsole($"Could not connect to {server.RconServerSettings.IPAddress}:{server.RconServerSettings.Port}.");
                }
            };            
        }

        private async void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await Task.Run(Connect);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            await Task.Run(() =>
            {
                rClient.Connect(server.RconServerSettings.IPAddress, int.Parse(server.RconServerSettings.Port));
                {
                    while (!rClient.Connected)
                    {
                        Thread.Sleep(10);
                    }
                }
            });
        }

        private void CommandList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (CommandList.SelectedIndex)
            {
                case 0:
                    {
                        CommandInfoTextbox.Text = "Sends a message to all players connected to the server.\n\nExample parameter: hello world";
                    }
                    break;
                case 1:
                    {
                        CommandInfoTextbox.Text = "Sends a pre-configured message that announces server restart in x minutes to all players connected to the server. Less flexible than announce but has the benefit of being localized to each users language.\n\nExample parameter: 5";
                    }
                    break;
                default:
                    {
                        CommandInfoTextbox.Text = "Select a command.";
                    }
                    break;
            }
        }

        private void DisconnectButton_Click(object sender, RoutedEventArgs e)
        {
            if (rClient.Connected)
            {
                rClient.Disconnect();
            }
        }

        private void SendCommandButton_Click(object sender, RoutedEventArgs e)
        {
            if (CommandList.SelectedIndex != -1 && rClient.Connected == true)
            {
                rClient.SendCommand(String.Format("{0} {1}", (CommandList.SelectedItem as ListBoxItem).Content.ToString(), ParamaterTextbox.Text), result => { LogToConsole(result); });
                LogToConsole(String.Format("Sent command '{0}' with parameter '{1}'.", (CommandList.SelectedItem as ListBoxItem).Content.ToString(), ParamaterTextbox.Text));
            }
            else
            {
                LogToConsole("Unable to send command.\rIs RCON connected and did you select a command?");
            }
        }
    }
}
