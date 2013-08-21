using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace InstallerV3
{
    public partial class Exit : Form
    {
        public Exit()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                Process.Start(InstallerV3.Properties.Settings.Default.installdir+@"\The Elite Patcher.exe");
            }
            Environment.Exit(0);
        }
    }
}
