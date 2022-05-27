using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Windows.Forms;

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

        public SourceRcon rClient = new SourceRcon();

        private async Task AttemptConnect(string ip, int port, string password)
        {
            await Task.Run(() =>
            {
                if (rClient.Connect(new IPEndPoint(IPAddress.Parse(ip), port), password))
                {
                    while (!rClient.Connected)
                    {
                        Thread.Sleep(10);
                    }

                    if (rClient.Connected)
                    {
                        ConnectButton.Enabled = false;
                    }
                }
            });
            
        }

        private async void ConnectButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Last_RCON_Address = AddressValue.Text;
            Properties.Settings.Default.Last_RCON_Port = Convert.ToInt16(PortNumber.Value);
            Properties.Settings.Default.Last_RCON_Pass = PasswordValue.Text;
            Properties.Settings.Default.Save();
            rClient = new SourceRcon();
            rClient.Errors += new StringOutput(ErrorOutput);
            await AttemptConnect(AddressValue.Text, Convert.ToInt16(PortNumber.Value), PasswordValue.Text);
        }

        private void RconConsoleMain_TextChanged(object sender, EventArgs e)
        {
            if (RconConsoleMain.TextLength > 10000)
            {
                RconConsoleMain.ResetText();
            }
            RconConsoleMain.ScrollToCaret();
        }

        private void ErrorOutput(string input)
        {
            RconConsoleMain.AppendText(Environment.NewLine + input);
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
            if (CommandList.SelectedIndex != -1 && rClient.Connected)
            {
                rClient.ServerCommand(String.Format("{0} {1}", CommandList.SelectedItem.ToString(), ParameterBox.Text));
                RconConsoleMain.AppendText(String.Format("\nSent command '{0}' with parameter '{1}'.", CommandList.SelectedItem.ToString(), ParameterBox.Text));
            }
            else
            {
                RconConsoleMain.AppendText(Environment.NewLine + "Unable to send command.\nIs RCON connected and did you select a command?");
            }
        }
    }
}
