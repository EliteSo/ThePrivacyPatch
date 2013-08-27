using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using NiCoding_Development_Library.Encryption;
using System.Web;
using System.Net;

namespace The_Elite_Patcher
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            if (The_Elite_Patcher.Properties.Settings.Default.rememberme == true)
            {
                textBox5.Text = The_Elite_Patcher.Properties.Settings.Default.user;
                textBox8.Text = The_Elite_Patcher.Properties.Settings.Default.pass;
                checkBox1.Checked = true;
            }
        }

        private void button35_Click(object sender, EventArgs e)
        {
            string hash = NiCoding_Development_Library.Forum_Tools.Xenforo.login("elite.so", textBox5.Text, textBox8.Text, false);
            if (!hash.Contains("Invalid") && !hash.Contains("Please enter") && !hash.Contains("Unable to login"))
            {
                if (checkBox1.Checked == true)
                {
                    The_Elite_Patcher.Properties.Settings.Default.rememberme = true;
                }
                The_Elite_Patcher.Properties.Settings.Default.user = textBox5.Text;
                The_Elite_Patcher.Properties.Settings.Default.pass = textBox8.Text;
                The_Elite_Patcher.Properties.Settings.Default.hash = hash;
                The_Elite_Patcher.Properties.Settings.Default.isAsAcc = false;
                The_Elite_Patcher.Properties.Settings.Default.Save();
                NewSplash strt = new NewSplash();
                strt.Show();
                this.Dispose(false);
            }
            else
            {
                NiCoding_Development_Library.Encryption.md5engine eng = new md5engine();
                string mdpass = textBox8.Text;
                mdpass = mdpass.Replace("#", "gigahash");
               if (NiCoding_Development_Library.Forum_Tools.IPB.login(textBox5.Text, mdpass) == true)
                {
                    The_Elite_Patcher.Properties.Settings.Default.isAsAcc = true;
                    The_Elite_Patcher.Properties.Settings.Default.Save();
                    NewSplash strt = new NewSplash();
                    strt.Show();
                    this.Dispose(false);
                }
                else
                {
                    MessageBox.Show(hash);
                }
            }
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button35_Click((object)sender, (EventArgs)e);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.elite.so/register");
        }
    }
}
