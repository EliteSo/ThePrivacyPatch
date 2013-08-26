using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace The_Elite_Patcher
{
    public partial class NewSplash : Form
    {
        public NewSplash()
        {
            InitializeComponent();
        }

        private void NewSplash_Load(object sender, EventArgs e)
        {
            if (The_Elite_Patcher.Properties.Settings.Default.rememberme == true)
            {
                textBox5.Text = The_Elite_Patcher.Properties.Settings.Default.user;
                textBox8.Text = The_Elite_Patcher.Properties.Settings.Default.pass;
                checkBox1.Checked = true;
            }
            groupPanel2.Visible = false;
            groupPanel1.Visible = false;
            groupPanel2.Left = (this.ClientSize.Width - groupPanel2.Width) / 2;
            groupPanel2.Top = (this.ClientSize.Height - groupPanel2.Height) / 2;
            groupPanel3.Left = (this.ClientSize.Width - groupPanel3.Width) / 2;
            groupPanel3.Top = (this.ClientSize.Height - groupPanel3.Height) / 2;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Process.Start("http://adminspot.net");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Process.Start("http://elite.so");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
            {
                progressBar1.Value += 2;
                if (progressBar1.Value > 99)
                {
                    progressBar1.Text = "                Please Wait...";
                }
                else if (progressBar1.Value == 50)
                {
                    /*timer1.Stop(); // Stop the timer if you press Enter
                    moduleBar.Visible = true;
                    progressBar1.Text = "                Checking Proxy Status...";
                    loadProxies();*/
                }
                else
                {
                    progressBar1.Text = "                Loading... " + progressBar1.Value.ToString() + "%...";
                }
            }
            else
            {
                timer1.Stop();
                #region load proxies
                /*The_Elite_Patcher.Properties.Settings.Default.dailymotion = NiCoding_Development_Library.Proxy_Operations.EsoProxy.checkDailyMotion();
                The_Elite_Patcher.Properties.Settings.Default.extrator = NiCoding_Development_Library.Proxy_Operations.EsoProxy.checkExtrator();
                The_Elite_Patcher.Properties.Settings.Default.fenopy = NiCoding_Development_Library.Proxy_Operations.EsoProxy.checkFenopy();
                The_Elite_Patcher.Properties.Settings.Default.heet = NiCoding_Development_Library.Proxy_Operations.EsoProxy.checkHeet();
                The_Elite_Patcher.Properties.Settings.Default.isohunt = NiCoding_Development_Library.Proxy_Operations.EsoProxy.checkIsohunt();
                The_Elite_Patcher.Properties.Settings.Default.katph = NiCoding_Development_Library.Proxy_Operations.EsoProxy.checkKat();
                The_Elite_Patcher.Properties.Settings.Default.leetx = NiCoding_Development_Library.Proxy_Operations.EsoProxy.checkLeetx();
                The_Elite_Patcher.Properties.Settings.Default.minnova = NiCoding_Development_Library.Proxy_Operations.EsoProxy.checkMinnova();
                The_Elite_Patcher.Properties.Settings.Default.monova = NiCoding_Development_Library.Proxy_Operations.EsoProxy.checkMonova();
                The_Elite_Patcher.Properties.Settings.Default.pastebin = NiCoding_Development_Library.Proxy_Operations.EsoProxy.checkPastebin();
                The_Elite_Patcher.Properties.Settings.Default.torcrazy = NiCoding_Development_Library.Proxy_Operations.EsoProxy.checkTorrentcrazy();
                The_Elite_Patcher.Properties.Settings.Default.torfunk = NiCoding_Development_Library.Proxy_Operations.EsoProxy.checkTorfunk();
                The_Elite_Patcher.Properties.Settings.Default.torlock = NiCoding_Development_Library.Proxy_Operations.EsoProxy.checkTorrentLock();
                The_Elite_Patcher.Properties.Settings.Default.torreact = NiCoding_Development_Library.Proxy_Operations.EsoProxy.checkTorrentReactor();
                The_Elite_Patcher.Properties.Settings.Default.torrenthnd = NiCoding_Development_Library.Proxy_Operations.EsoProxy.checkTorrentHound();
                The_Elite_Patcher.Properties.Settings.Default.torrentsdotnet = NiCoding_Development_Library.Proxy_Operations.EsoProxy.checkTordotnet();
                The_Elite_Patcher.Properties.Settings.Default.torroom = NiCoding_Development_Library.Proxy_Operations.EsoProxy.checkTorroom();
                The_Elite_Patcher.Properties.Settings.Default.torroot = NiCoding_Development_Library.Proxy_Operations.EsoProxy.checkTorroot();
                The_Elite_Patcher.Properties.Settings.Default.tpb = NiCoding_Development_Library.Proxy_Operations.EsoProxy.checkTpb();
                The_Elite_Patcher.Properties.Settings.Default.tzeu = NiCoding_Development_Library.Proxy_Operations.EsoProxy.checkTzeu();
                The_Elite_Patcher.Properties.Settings.Default.vertor = NiCoding_Development_Library.Proxy_Operations.EsoProxy.checkVertor();
                The_Elite_Patcher.Properties.Settings.Default.vimeo = NiCoding_Development_Library.Proxy_Operations.EsoProxy.checkVimeo();
                The_Elite_Patcher.Properties.Settings.Default.xmarks = NiCoding_Development_Library.Proxy_Operations.EsoProxy.checkXmarks();
                The_Elite_Patcher.Properties.Settings.Default.ybt = NiCoding_Development_Library.Proxy_Operations.EsoProxy.checkYbt();
                */
                #endregion
                Form1 home = new Form1();
                home.Show();
                this.Dispose(false);
            }
        }

        private void loadProxies()
        {
            moduleBar.Value = The_Elite_Patcher.Properties.Settings.Default.sitecnt;
            moduleBar.Text = "        Checking TPB Proxy...";
            The_Elite_Patcher.Properties.Settings.Default.tpb = NiCoding_Development_Library.Proxy_Operations.EsoProxy.checkTpb();
            moduleBar.Value += 1;
            moduleBar.Text = "        Checking Fenopy Proxy...";
            The_Elite_Patcher.Properties.Settings.Default.fenopy = NiCoding_Development_Library.Proxy_Operations.EsoProxy.checkFenopy();
            moduleBar.Value += 1;
            moduleBar.Text = "        Checking Torrentz.eu Proxy...";
            The_Elite_Patcher.Properties.Settings.Default.tzeu = NiCoding_Development_Library.Proxy_Operations.EsoProxy.checkTzeu();
            moduleBar.Value += 1;
            moduleBar.Text = "        Checking H33T Proxy...";
            The_Elite_Patcher.Properties.Settings.Default.heet = NiCoding_Development_Library.Proxy_Operations.EsoProxy.checkHeet();
            moduleBar.Value += 1;
            moduleBar.Text = "        Checking 1337x Proxy...";
            The_Elite_Patcher.Properties.Settings.Default.leetx = NiCoding_Development_Library.Proxy_Operations.EsoProxy.checkLeetx();
            moduleBar.Value += 1;
            moduleBar.Text = "        Checking Mininova Proxy...";
            The_Elite_Patcher.Properties.Settings.Default.minnova = NiCoding_Development_Library.Proxy_Operations.EsoProxy.checkMinnova();
            moduleBar.Value += 1;
            moduleBar.Text = "        Checking Monova Proxy...";
            The_Elite_Patcher.Properties.Settings.Default.monova = NiCoding_Development_Library.Proxy_Operations.EsoProxy.checkMonova();
            moduleBar.Value += 1;
            moduleBar.Text = "        Checking Torrent Crazy Proxy...";
            The_Elite_Patcher.Properties.Settings.Default.torcrazy = NiCoding_Development_Library.Proxy_Operations.EsoProxy.checkTorrentcrazy();
            moduleBar.Value += 1;
            moduleBar.Text = "        Checking Torrent Reactor Proxy...";
            The_Elite_Patcher.Properties.Settings.Default.torreact = NiCoding_Development_Library.Proxy_Operations.EsoProxy.checkTorrentReactor();
            moduleBar.Value += 1;
            moduleBar.Text = "        Checking Torrent Hound Proxy...";
            The_Elite_Patcher.Properties.Settings.Default.torrenthnd = NiCoding_Development_Library.Proxy_Operations.EsoProxy.checkTorrentHound();
            moduleBar.Value += 1;
            moduleBar.Text = "        Checking Torlock Proxy...";
            The_Elite_Patcher.Properties.Settings.Default.torlock = NiCoding_Development_Library.Proxy_Operations.EsoProxy.checkTorrentLock();
            moduleBar.Value += 1;
            moduleBar.Text = "        Checking Proxy...";
            The_Elite_Patcher.Properties.Settings.Default.katph = NiCoding_Development_Library.Proxy_Operations.EsoProxy.checkKat();
            timer1.Start();
        }

        private void button35_Click(object sender, EventArgs e)
        {
            string hash3 = NiCoding_Development_Library.Forum_Tools.Xenforo.login("crazy-coderz.com", textBox5.Text, textBox8.Text);
            if (!hash3.Contains("Invalid") && !hash3.Contains("Please enter") && !hash3.Contains("Unable to login"))
            {
                if (checkBox1.Checked == true)
                {
                    The_Elite_Patcher.Properties.Settings.Default.rememberme = true;
                }
                The_Elite_Patcher.Properties.Settings.Default.user = textBox5.Text;
                The_Elite_Patcher.Properties.Settings.Default.pass = textBox8.Text;
                The_Elite_Patcher.Properties.Settings.Default.hash = hash3;
                The_Elite_Patcher.Properties.Settings.Default.isAsAcc = false;
                The_Elite_Patcher.Properties.Settings.Default.isRhAcc = false;
                The_Elite_Patcher.Properties.Settings.Default.isCCAcc = true;
                The_Elite_Patcher.Properties.Settings.Default.site = "crazy-coderz.com";
                The_Elite_Patcher.Properties.Settings.Default.Save();
                groupPanel1.Visible = true;
                groupPanel2.Visible = true;
                groupPanel3.Visible = false;
                timer1.Start();
            }

            else
            {
                string mdpass = textBox8.Text;
                mdpass = mdpass.Replace("#", "gigahash");
                if (NiCoding_Development_Library.Forum_Tools.IPB.login(textBox5.Text, mdpass) == true)
                {
                    The_Elite_Patcher.Properties.Settings.Default.isAsAcc = true;
                    The_Elite_Patcher.Properties.Settings.Default.isRhAcc = false;
                    The_Elite_Patcher.Properties.Settings.Default.Save();
                    groupPanel2.Visible = true;
                    groupPanel3.Visible = false;
                    groupPanel1.Visible = true;
                    timer1.Start();
                }
                else
                {
                    string hash2 = NiCoding_Development_Library.Forum_Tools.Xenforo.login("royalhood.net", textBox5.Text, textBox8.Text);
                    if (!hash2.Contains("Invalid") && !hash2.Contains("Please enter") && !hash2.Contains("Unable to login"))
                    {
                        if (checkBox1.Checked == true)
                        {
                            The_Elite_Patcher.Properties.Settings.Default.rememberme = true;
                        }
                        The_Elite_Patcher.Properties.Settings.Default.user = textBox5.Text;
                        The_Elite_Patcher.Properties.Settings.Default.pass = textBox8.Text;
                        The_Elite_Patcher.Properties.Settings.Default.hash = hash2;
                        The_Elite_Patcher.Properties.Settings.Default.isAsAcc = false;
                        The_Elite_Patcher.Properties.Settings.Default.isRhAcc = true;
                        The_Elite_Patcher.Properties.Settings.Default.site = "royalhood.net";
                        The_Elite_Patcher.Properties.Settings.Default.Save();
                        groupPanel1.Visible = true;
                        groupPanel2.Visible = true;
                        groupPanel3.Visible = false;
                        timer1.Start();
                    }
                    else
                    {
                        string hash = NiCoding_Development_Library.Forum_Tools.Xenforo.login("elite.so", textBox5.Text, textBox8.Text);
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
                            The_Elite_Patcher.Properties.Settings.Default.isRhAcc = false;
                            The_Elite_Patcher.Properties.Settings.Default.site = "elite.so";
                            The_Elite_Patcher.Properties.Settings.Default.Save();
                            if (!checkUser("crazy-coderz.com", textBox5.Text))
                            {
                                string reg = NiCoding_Development_Library.Forum_Tools.Xenforo.register("crazy-coderz.com", textBox5.Text, textBox8.Text, NiCoding_Development_Library.Forum_Tools.Xenforo.getUserEmail("elite.so", textBox5.Text));
                                if (reg == "Success!")
                                {
                                    MessageBox.Show("Hello " + textBox5.Text + "!" + Environment.NewLine + "As Elite.So has merged with Crazy-Coderz.com, your account has been converted! Please check your email for an activation link! Your elite.so account will be deactivated after you close The Elite Patch.");
                                }
                            }
                            groupPanel1.Visible = true;
                            groupPanel2.Visible = true;
                            groupPanel3.Visible = false;
                            timer1.Start();
                        }
                        else
                        {
                            MessageBox.Show(hash);
                        }
                    }
                }
            }
        }

        private bool checkUser(string site, string user)
        {
            string hash = NiCoding_Development_Library.Forum_Tools.Xenforo.login("crazy-coderz.com", textBox5.Text, textBox8.Text);
            if (!hash.Contains("Invalid") || !hash.Contains("Please enter") || !hash.Contains("Unable to login"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("http://adminspot.net/index.php?app=core&module=global&section=register");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.crazy-coderz.com/register");
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button35_Click((object)sender, (EventArgs)e);
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Process.Start("http://crazy-coderz.com");
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
