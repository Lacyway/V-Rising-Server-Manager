using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServerManager.RCON;

namespace ServerManager
{
    public partial class RconConsole : Form
    {
        public RconConsole()
        {
            InitializeComponent();
            Icon = Properties.Resources.logo;
            RconConsoleMain.AppendText("Ready to connect.");
            if (Properties.Settings.Default.RCON_Address != "notset")
            {
                AddressValue.Text = Properties.Settings.Default.RCON_Address;
            }
            if (Properties.Settings.Default.RCON_Port != -1)
            {
                PortNumber.Value = Properties.Settings.Default.RCON_Port;
            }
            if (Properties.Settings.Default.RCON_Pass != "notset")
            {
                PasswordValue.Text = Properties.Settings.Default.RCON_Pass;
            }            
        }

        public RemoteConClient rClient = new RemoteConClient();
        private async Task AttemptConnect()
        {
            await Task.Run(() =>
            {
                    rClient.Connect(AddressValue.Text, Convert.ToInt16(PortNumber.Value));
                {
                    while (!rClient.Connected)
                    {
                        Thread.Sleep(10);
                    }
                }
            });

        }

        private async void ConnectButton_Click(object sender, EventArgs e)
        {            
            rClient = new RemoteConClient();
            rClient.UseUtf8 = true;
            ConnectButton.Enabled = false;
            rClient.OnLog += message => 
            {
                RconConsoleMain.AppendText(Environment.NewLine + message);
            };
            rClient.OnConnectionStateChange += state =>
            {
                if (state == RemoteConClient.ConnectionStateChange.Connected)
                {
                    rClient.Authenticate(PasswordValue.Text);
                    DisconnectButton.Enabled = true;
                    ParameterBox.Enabled = true;
                    SendCommandButton.Enabled = true;
                    RconConsoleMain.AppendText(Environment.NewLine + "Authenticating.");                    
                }
                if (state == RemoteConClient.ConnectionStateChange.Disconnected)
                {
                    DisconnectButton.Enabled = false;
                    ConnectButton.Enabled = true;
                    ParameterBox.Enabled = false;
                    SendCommandButton.Enabled = false;
                    RconConsoleMain.AppendText(Environment.NewLine + "Disconnected.");
                }
                if (state == RemoteConClient.ConnectionStateChange.ConnectionLost)
                {
                    DisconnectButton.Enabled = false;
                    ConnectButton.Enabled = true;
                    ParameterBox.Enabled = false;
                    SendCommandButton.Enabled = false;
                    RconConsoleMain.AppendText(Environment.NewLine + "Connection lost.");
                }
                if (state == RemoteConClient.ConnectionStateChange.ConnectionTimeout)
                {
                    DisconnectButton.Enabled = false;
                    ConnectButton.Enabled = true;
                    ParameterBox.Enabled = false;
                    SendCommandButton.Enabled = false;
                    RconConsoleMain.AppendText(Environment.NewLine + "Connection timeout.");
                }
                if (state == RemoteConClient.ConnectionStateChange.NoConnection)
                {
                    DisconnectButton.Enabled = false;
                    ConnectButton.Enabled = true;
                    ParameterBox.Enabled = false;
                    SendCommandButton.Enabled = false;
                    RconConsoleMain.AppendText(Environment.NewLine + "No connection.");
                }
            };
            await AttemptConnect();

        }

        private void RconConsoleMain_TextChanged(object sender, EventArgs e)
        {
            if (RconConsoleMain.TextLength > 10000)
            {
                RconConsoleMain.ResetText();
            }
            RconConsoleMain.ScrollToCaret();
        }

        private void CommandList_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (CommandList.SelectedIndex)
            {
                case 0:
                    {
                        CommandInfoBox.Text = "Sends a message to all players connected to the server.\n\nExample parameter: hello world";
                    }
                break;
                case 1:
                    {
                        CommandInfoBox.Text = "Sends a pre-configured message that announces server restart in x minutes to all players connected to the server. Less flexible than announce but has the benefit of being localized to each users language.\n\nExample parameter: 5";
                    }
                    break;
                default:
                    {
                        CommandInfoBox.Text = "Select a command.";
                    }
                break;
            }
        }

        private void SendCommandButton_Click(object sender, EventArgs e)
        {
            if (CommandList.SelectedIndex != -1 && rClient.Connected == true)
            {
                rClient.SendCommand(String.Format("{0} {1}", CommandList.SelectedItem.ToString(), ParameterBox.Text), result => { RconConsoleMain.AppendText(Environment.NewLine + result); });
                RconConsoleMain.AppendText(String.Format("\nSent command '{0}' with parameter '{1}'.", CommandList.SelectedItem.ToString(), ParameterBox.Text));
            }
            else
            {
                RconConsoleMain.AppendText(Environment.NewLine + "Unable to send command.\nIs RCON connected and did you select a command?");
            }
        }

        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            if (rClient.Connected)
            {
                rClient.Disconnect();
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.RCON_Address = AddressValue.Text;
            Properties.Settings.Default.RCON_Port = Convert.ToInt16(PortNumber.Value);
            Properties.Settings.Default.RCON_Pass = PasswordValue.Text;
            Properties.Settings.Default.Save();
            RconConsoleMain.AppendText(Environment.NewLine + "Settings saved.");
        }
    }
}
