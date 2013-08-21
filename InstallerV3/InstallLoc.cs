using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace InstallerV3
{
    public partial class InstallLoc : Form
    {
        public InstallLoc()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox1.Text))
            {
                InstallerV3.Properties.Settings.Default.installdir = textBox1.Text;
            }
            else
            {
                InstallerV3.Properties.Settings.Default.installdir = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\Elite.So\The Elite Patch\";
                if (!Directory.Exists(InstallerV3.Properties.Settings.Default.installdir))
                {
                    Directory.CreateDirectory(InstallerV3.Properties.Settings.Default.installdir);
                }
            }
            InstallerV3.Properties.Settings.Default.curstep += 1;
            InstallerV3.Properties.Settings.Default.Save();
            this.Dispose();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD1 = new FolderBrowserDialog();
            FBD1.Description = "Choose a location to install The Elite Patch to.";
            if (FBD1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = FBD1.SelectedPath;
            }
        }
    }
}
