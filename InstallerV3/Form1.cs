using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace InstallerV3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InstallerV3.Properties.Settings.Default.curstep = 0;
            InstallerV3.Properties.Settings.Default.laststep = 0;
            InstallerV3.Properties.Settings.Default.Save();
            startNext(InstallerV3.Properties.Settings.Default.curstep);
            timer1.Start();
            timer2.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (InstallerV3.Properties.Settings.Default.curstep > InstallerV3.Properties.Settings.Default.laststep)
            {
                InstallerV3.Properties.Settings.Default.laststep += 1;
                InstallerV3.Properties.Settings.Default.Save();
                startNext(InstallerV3.Properties.Settings.Default.curstep);
            }
            else if (InstallerV3.Properties.Settings.Default.dlerr == true)
            {
                InstallerV3.Properties.Settings.Default.dlerr = false;
                InstallerV3.Properties.Settings.Default.Save();
                startNext(InstallerV3.Properties.Settings.Default.curstep);
            }
        }

        private void startNext(int next)
        {
            if (next == 0)
            {
                Start st = new Start();
                st.MdiParent = this;
                st.Show();
            }
            else if (next == 1)
            {
                InstallTyp ist = new InstallTyp();
                ist.MdiParent = this;
                ist.Show();
            }
            else if (next == 2)
            {
                InstallLoc instloc = new InstallLoc();
                instloc.MdiParent = this;
                instloc.Show();
            }
            else if (next == 3)
            {
                License lic = new License();
                lic.MdiParent = this;
                lic.Show();
            }
            else if (next == 4)
            {
                if (InstallerV3.Properties.Settings.Default.offline == false)
                {
                    Download dl = new Download();
                    dl.MdiParent = this;
                    dl.Show();
                }
                else
                {
                    Install ins = new Install();
                    ins.MdiParent = this;
                    ins.Show();
                }

            }
            else if (next == 5)
            {
                if (InstallerV3.Properties.Settings.Default.offline == true)
                {
                    Install ins = new Install();
                    ins.MdiParent = this;
                    ins.Show();
                }
                else
                {
                    startNext(6);
                }
            }
            else if (next == 6)
            {
                Exit ex = new Exit();
                ex.MdiParent = this;
                ex.Show();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (InstallerV3.Properties.Settings.Default.curstep < 5)
            {
                if (InstallerV3.Properties.Settings.Default.curstep > 0)
                {
                    progressBar1.Value = InstallerV3.Properties.Settings.Default.curstep * 10;
                }
            }
            else
            {
                progressBar1.Value = 100;
                timer2.Stop();
            }
        }
    }
}
