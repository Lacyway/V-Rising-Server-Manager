using System;
using System.Windows.Forms;

namespace ServerManager
{
    public partial class AppSettings : Form
    {
        public AppSettings()
        {
            InitializeComponent();
            ServerFolderValue.Text = Properties.Settings.Default.Server_Path;
            SaveFolderValue.Text = Properties.Settings.Default.Save_Path;
            LogFolderValue.Text = Properties.Settings.Default.Log_Path;
        }

        private void SelectServerFolderButton_Click(object sender, EventArgs e)
        {
            if (OpenFolderDialog.ShowDialog() == DialogResult.OK)
            {
                ServerFolderValue.Text = OpenFolderDialog.SelectedPath;
            }
        }
        private void SelectSaveFolderButton_Click(object sender, EventArgs e)
        {
            if (OpenFolderDialog.ShowDialog() == DialogResult.OK)
            {
                SaveFolderValue.Text = OpenFolderDialog.SelectedPath;
            }
        }

        private void SelectLogFolderButton_Click(object sender, EventArgs e)
        {
            if (OpenFolderDialog.ShowDialog() == DialogResult.OK)
            {
                LogFolderValue.Text = OpenFolderDialog.SelectedPath;
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?\nUnsaved changes will be lost.", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Server_Path = ServerFolderValue.Text;
            Properties.Settings.Default.Save_Path = SaveFolderValue.Text;
            Properties.Settings.Default.Log_Path = LogFolderValue.Text;
            Properties.Settings.Default.Save();
            this.Close();
        }
    }
}
