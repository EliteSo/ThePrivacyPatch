using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace The_Elite_Patcher
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            timer1.Start();
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
    }
}
