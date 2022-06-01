using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace ServerManager
{
    public partial class AdminManager : Form
    {
        public AdminManager()
        {
            InitializeComponent();
            Icon = Properties.Resources.logo;
            PopulateList(Properties.Settings.Default.Server_Path + "\\VRisingServer_Data\\StreamingAssets\\Settings\\adminlist.txt");
        }

        private void PopulateList(string filePath)
        {
            if (File.Exists(Properties.Settings.Default.Server_Path + "\\VRisingServer_Data\\StreamingAssets\\Settings\\adminlist.txt"))
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
                MessageBox.Show("Unable to find adminlist.txt\nPlease make sure server path is correctly configured.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddButton_Click(object sender, System.EventArgs e)
        {
            if (AdminToAddTextBox.Text != "")
            {
                AdminList.Items.Add(AdminToAddTextBox.Text);
            }
            else
            {
                MessageBox.Show("ID to add is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RemoveButton_Click(object sender, System.EventArgs e)
        {
            if (AdminList.SelectedIndex != -1)
            {
                AdminList.Items.RemoveAt(AdminList.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Please select an ID to remove.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveButton_Click(object sender, System.EventArgs e)
        {
            if (File.Exists(Properties.Settings.Default.Server_Path + "\\VRisingServer_Data\\StreamingAssets\\Settings\\adminlist.txt"))
            {
                string sPath = string.Format("{0}\\VRisingServer_Data\\StreamingAssets\\Settings\\adminlist.txt", Properties.Settings.Default.Server_Path);
                StreamWriter SaveFile = new StreamWriter(sPath);
                foreach (var item in AdminList.Items)
                {
                    SaveFile.WriteLine(item);
                }
                SaveFile.Close();
            }
            else
            {
                MessageBox.Show("Unable to find adminlist.txt\nPlease make sure server path is correctly configured.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void ReloadButton_Click(object sender, System.EventArgs e)
        {
            PopulateList(Properties.Settings.Default.Server_Path + "\\VRisingServer_Data\\StreamingAssets\\Settings\\adminlist.txt");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("explorer.exe", "https://steamid.io/lookup");
        }
    }
}
