﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InstallerV3
{
    public partial class InstallTyp : Form
    {
        public InstallTyp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InstallerV3.Properties.Settings.Default.offline = false;
            InstallerV3.Properties.Settings.Default.curstep += 1;
            InstallerV3.Properties.Settings.Default.Save();
            this.Dispose();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InstallerV3.Properties.Settings.Default.offline = true;
            InstallerV3.Properties.Settings.Default.curstep += 1;
            InstallerV3.Properties.Settings.Default.Save();
            this.Dispose();
            this.Close();
        }
    }
}
