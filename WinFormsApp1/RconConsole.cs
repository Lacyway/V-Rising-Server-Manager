using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RconSharp;

namespace ServerManager
{
    public partial class RconConsole : Form
    {
        public RconConsole()
        {
            InitializeComponent();
            RconConsoleMain.AppendText("Ready to connect.");
            if (Properties.Settings.Default.Last_RCON_Address != "notset")
            {
                AddressValue.Text = Properties.Settings.Default.Last_RCON_Address;
            }
            if (Properties.Settings.Default.Last_RCON_Pass != "notset")
            {
                PasswordValue.Text = Properties.Settings.Default.Last_RCON_Pass;
            }
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Last_RCON_Address = AddressValue.Text;
            Properties.Settings.Default.Last_RCON_Port = Convert.ToInt16(PortNumber.Value);
            Properties.Settings.Default.Last_RCON_Pass = PasswordValue.Text;
            Properties.Settings.Default.Save();
        }

        private void Client_ConnectionClosed()
        {
            RconConsoleMain.AppendText(Environment.NewLine + "Connection closed.");
            ConnectButton.Enabled = true;
            DisconnectButton.Enabled = false;            
        }

        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            
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

        private async void SendCommandButton_Click(object sender, EventArgs e)
        {
            if (CommandList.SelectedIndex == -1)
            {
                RconConsoleMain.AppendText(Environment.NewLine + "Please select a command.");
                return;
            }
            var client = RconClient.Create(AddressValue.Text, Convert.ToInt16(PortNumber.Value));

            client.ConnectionClosed += Client_ConnectionClosed;

            try
            {
                RconConsoleMain.AppendText(Environment.NewLine + "Attempting to connect...");
                await client.ConnectAsync();
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                RconConsoleMain.AppendText(Environment.NewLine + String.Format("There was an error connecting:\n{0}", ex.Message));
                return;
            }

            var authenticated = await client.AuthenticateAsync(PasswordValue.Text);
            if (authenticated)
            {                
                //ConnectButton.Enabled = false;
                //DisconnectButton.Enabled = true;
                RconConsoleMain.AppendText(Environment.NewLine + "Connected to RCON succesfully.");
                RconConsoleMain.AppendText(Environment.NewLine + "Sending command: " + CommandList.Items[CommandList.SelectedIndex].ToString() + "\nWith parameter: " + ParameterBox.Text);                
                var status = await client.ExecuteCommandAsync(String.Format("{0} {1}", CommandList.Items[CommandList.SelectedIndex].ToString(), ParameterBox.Text, true));
                client.Disconnect();
            }
        }
    }
}
