using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using NiCoding_Development_Library.File_Operations;
using DevComponents.DotNetBar;
using System.Net;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Management;
using System.Drawing.Drawing2D;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Reflection;

namespace The_Elite_Patcher
{
    public partial class Form1 : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public Form1()
        {
            InitializeComponent();
        }
        string usrfile = Directory.GetCurrentDirectory();
        string hosts = Environment.GetFolderPath(Environment.SpecialFolder.Windows) + @"\System32\Drivers\etc\hosts";
        string addondir = Directory.GetCurrentDirectory() + @"\addons\";
        #region proxies
        #region main proxies
        string[] all = new string[] { "91.121.192.111 thepiratebay.org", "91.121.192.111 www.thepiratebay.org", 
        "91.121.192.111 thepiratebay.se", "91.121.192.111 www.thepiratebay.se", "91.121.192.111 thepiratebay.com", 
        "91.121.192.111 www.thepiratebay.com", "91.121.192.111 depiraatbaai.be", "91.121.192.111 www.depiraatbaai.be", 
        "91.121.192.111 baiedespirates.be", "91.121.192.111 www.baiedespirates.be", "91.121.192.111 torrentz.eu", "91.121.192.111 www.torrentz.eu", 
        "91.121.192.111 torrenthound.com", "91.121.192.111 www.torrenthound.com", "91.121.192.111 1337x.org", "91.121.192.111 www.1337x.org", 
        "91.121.192.111 torlock.com", "91.121.192.111 www.torlock.com", "91.121.192.111 vertor.com", "91.121.192.111 www.vertor.com", 
        "91.121.192.111 fenopy.se", "91.121.192.111 www.fenopy.se", "91.121.192.111 yourbittorrent.com", "91.121.192.111 www.yourbittorrent.com", 
        "91.121.192.111 monova.org", "91.121.192.111 www.monova.org", "91.121.192.111 h33t.com", "91.121.192.111 www.h33t.com",
        "91.121.192.111 torrentreactor.net", "91.121.192.111 www.torrentreactor.net", "91.121.192.111 torrentcrazy.com", 
        "91.121.192.111 www.torrentcrazy.com", "91.121.192.111 www.torrents.thepiratebay.se", "91.121.192.111 torrents.thepiratebay.se", 
        "91.121.192.111 mininova.org", "91.121.192.111 www.mininova.org", "91.121.192.111 kat.ph", "91.121.192.111 www.kat.ph", 
        "91.121.192.111 vimeo.com", "91.121.192.111 www.vimeo.com", "91.121.192.111 dailymotion.com", "91.121.192.111 www.dailymotion.com",
        "91.121.192.111 xmarks.com", "91.121.192.111 www.xmarks.com", "91.121.192.111 pastebin.com", "91.121.192.111 www.pastebin.com",
        "91.121.192.111 isohunt.com", "91.121.192.111 www.isohunt.com", "91.121.192.111 torrentfunk.com", "91.121.192.111 www.torrentfunk.com", 
        "91.121.192.111 extratorrent.com", "91.121.192.111 www.extratorrent.com", "91.121.192.111 torrent.net", "91.121.192.111 www.torrent.net", 
        "91.121.192.111 torrentroom.com", "91.121.192.111 www.torrentroom.com", "91.121.192.111 torrentroot.com", "91.121.192.111 www.torrentroot.com", 
        "91.121.192.111 kickasstorrents.com", "91.121.192.111 www.kickasstorrents.com" , "91.121.192.111 kastatic.com", "91.121.192.111 www.kastatic.com"};
        string[] TPB = new string[] { "91.121.192.111 torrents.thepiratebay.se", "91.121.192.111 www.torrents.thepiratebay.se", "91.121.192.111 thepiratebay", "91.121.192.111 thepiratebay.org", "91.121.192.111 www.thepiratebay.org", "91.121.192.111 thepiratebay.se", "91.121.192.111 www.thepiratebay.se", "91.121.192.111 thepiratebay.com", "91.121.192.111 www.thepiratebay.com", "91.121.192.111 depiraatbaai.be", "91.121.192.111 www.depiraatbaai.be", "91.121.192.111 baiedespirates.be", "91.121.192.111 www.baiedespirates.be" };
        string[] TORRENTZEU = new string[] { "91.121.192.111 torrentz.eu", "91.121.192.111 www.torrentz.eu" };
        string[] TORRENTHND = new string[] { "91.121.192.111 torrenthound.com", "91.121.192.111 www.torrenthound.com" };
        string[] LEETX = new string[] { "91.121.192.111 1337x.org", "91.121.192.111 www.1337x.org" };
        string[] TORLOCK = new string[] { "91.121.192.111 torlock.com", "91.121.192.111 www.torlock.com" };
        string[] VERTOR = new string[] { "91.121.192.111 vertor.com", "91.121.192.111 www.vertor.com" };
        string[] FENOPY = new string[] { "91.121.192.111 fenopy.se", "91.121.192.111 www.fenopy.se" };
        string[] YBT = new string[] { "91.121.192.111 yourbittorrent.com", "91.121.192.111 www.yourbittorrent.com" };
        string[] MONOVA = new string[] { "91.121.192.111 monova.org", "91.121.192.111 www.monova.org" };
        string[] HEET = new string[] { "91.121.192.111 h33t.com", "91.121.192.111 www.h33t.com" };
        string[] TORRENTREACTOR = new string[] { "91.121.192.111 torrentreactor.net", "91.121.192.111 www.torrentreactor.net" };
        string[] TORRENTCRAZY = new string[] { "91.121.192.111 torrentcrazy.com", "91.121.192.111 www.torrentcrazy.com" };
        string[] MINNOVA = new string[] { "91.121.192.111 mininova.org", "91.121.192.111 www.mininova.org" };
        string[] KATPH = new string[] { "91.121.192.111 kickasstorrents.com", "91.121.192.111 www.kickasstorrents.com", "91.121.192.111 kat.ph", "91.121.192.111 www.kat.ph", "91.121.192.111 kastatic.com", "91.121.192.111 www.kastatic.com" };
        string[] VIMEO = new string[] { "91.121.192.111 vimeo.com", "91.121.192.111 www.vimeo.com" };
        string[] DAILYMOTION = new string[] { "91.121.192.111 dailymotion.com", "91.121.192.111 www.dailymotion.com" };
        string[] XMARKS = new string[] { "91.121.192.111 xmarks.com", "91.121.192.111 www.xmarks.com" };
        string[] PASTEBIN = new string[] { "91.121.192.111 pastebin.com", "91.121.192.111 www.pastebin.com" };
        string[] ISOHUNT = new string[] { "91.121.192.111 isohunt.com", "91.121.192.111 www.isohunt.com" };
        string[] TORFUNK = new string[] { "91.121.192.111 torrentfunk.com", "91.121.192.111 www.torrentfunk.com" };
        string[] EXTRATOR = new string[] { "91.121.192.111 extratorrent.com", "91.121.192.111 www.extratorrent.com" };
        string[] TORDOTNET = new string[] { "91.121.192.111 torrent.net", "91.121.192.111 www.torrent.net" };
        string[] TORROOM = new string[] { "91.121.192.111 torrentroom.com", "91.121.192.111 www.torrentroom.com" };
        string[] TORROOT = new string[] { "91.121.192.111 torrentroot.com", "91.121.192.111 www.torrentroot.com" };
        #endregion
        #region alt proxies 1
        string[] all2 = new string[] { "87.98.138.49 thepiratebay.org", "87.98.138.49 www.thepiratebay.org", 
        "87.98.138.49 thepiratebay.se", "87.98.138.49 www.thepiratebay.se", "87.98.138.49 thepiratebay.com", 
        "87.98.138.49 www.thepiratebay.com", "87.98.138.49 depiraatbaai.be", "87.98.138.49 www.depiraatbaai.be", 
        "87.98.138.49 baiedespirates.be", "87.98.138.49 www.baiedespirates.be", "87.98.138.49 torrentz.eu", "87.98.138.49 www.torrentz.eu", 
        "87.98.138.49 torrenthound.com", "87.98.138.49 www.torrenthound.com", "87.98.138.49 1337x.org", "87.98.138.49 www.1337x.org", 
        "87.98.138.49 torlock.com", "87.98.138.49 www.torlock.com", "87.98.138.49 vertor.com", "87.98.138.49 www.vertor.com", 
        "87.98.138.49 fenopy.se", "87.98.138.49 www.fenopy.se", "87.98.138.49 yourbittorrent.com", "87.98.138.49 www.yourbittorrent.com", 
        "87.98.138.49 monova.org", "87.98.138.49 www.monova.org", "87.98.138.49 h33t.com", "87.98.138.49 www.h33t.com",
        "87.98.138.49 torrentreactor.net", "87.98.138.49 www.torrentreactor.net", "87.98.138.49 torrentcrazy.com", 
        "87.98.138.49 www.torrentcrazy.com", "87.98.138.49 www.torrents.thepiratebay.se", "87.98.138.49 torrents.thepiratebay.se", 
        "87.98.138.49 mininova.org", "87.98.138.49 www.mininova.org", "87.98.138.49 kat.ph", "87.98.138.49 www.kat.ph", 
        "87.98.138.49 vimeo.com", "87.98.138.49 www.vimeo.com", "87.98.138.49 dailymotion.com", "87.98.138.49 www.dailymotion.com",
        "87.98.138.49 xmarks.com", "87.98.138.49 www.xmarks.com", "87.98.138.49 pastebin.com", "87.98.138.49 www.pastebin.com",
        "87.98.138.49 isohunt.com", "87.98.138.49 www.isohunt.com", "87.98.138.49 torrentfunk.com", "87.98.138.49 www.torrentfunk.com", 
        "87.98.138.49 extratorrent.com", "87.98.138.49 www.extratorrent.com", "87.98.138.49 torrent.net", "87.98.138.49 www.torrent.net", 
        "87.98.138.49 torrentroom.com", "87.98.138.49 www.torrentroom.com", "87.98.138.49 torrentroot.com", "87.98.138.49 www.torrentroot.com", 
        "87.98.138.49 kickasstorrents.com", "87.98.138.49 www.kickasstorrents.com" , "87.98.138.49 kastatic.com", "87.98.138.49 www.kastatic.com"};
        string[] TPB2 = new string[] { "87.98.138.49 torrents.thepiratebay.se", "87.98.138.49 www.torrents.thepiratebay.se", "87.98.138.49 thepiratebay", "87.98.138.49 thepiratebay.org", "87.98.138.49 www.thepiratebay.org", "87.98.138.49 thepiratebay.se", "87.98.138.49 www.thepiratebay.se", "87.98.138.49 thepiratebay.com", "87.98.138.49 www.thepiratebay.com", "87.98.138.49 depiraatbaai.be", "87.98.138.49 www.depiraatbaai.be", "87.98.138.49 baiedespirates.be", "87.98.138.49 www.baiedespirates.be" };
        string[] TORRENTZEU2 = new string[] { "87.98.138.49 torrentz.eu", "87.98.138.49 www.torrentz.eu" };
        string[] TORRENTHND2 = new string[] { "87.98.138.49 torrenthound.com", "87.98.138.49 www.torrenthound.com" };
        string[] LEETX2 = new string[] { "87.98.138.49 1337x.org", "87.98.138.49 www.1337x.org" };
        string[] TORLOCK2 = new string[] { "87.98.138.49 torlock.com", "87.98.138.49 www.torlock.com" };
        string[] VERTOR2 = new string[] { "87.98.138.49 vertor.com", "87.98.138.49 www.vertor.com" };
        string[] FENOPY2 = new string[] { "87.98.138.49 fenopy.se", "87.98.138.49 www.fenopy.se" };
        string[] YBT2 = new string[] { "87.98.138.49 yourbittorrent.com", "87.98.138.49 www.yourbittorrent.com" };
        string[] MONOVA2 = new string[] { "87.98.138.49 monova.org", "87.98.138.49 www.monova.org" };
        string[] HEET2 = new string[] { "87.98.138.49 h33t.com", "87.98.138.49 www.h33t.com" };
        string[] TORRENTREACTOR2 = new string[] { "87.98.138.49 torrentreactor.net", "87.98.138.49 www.torrentreactor.net" };
        string[] TORRENTCRAZY2 = new string[] { "87.98.138.49 torrentcrazy.com", "87.98.138.49 www.torrentcrazy.com" };
        string[] MINNOVA2 = new string[] { "87.98.138.49 mininova.org", "87.98.138.49 www.mininova.org" };
        string[] KATPH2 = new string[] { "87.98.138.49 kickasstorrents.com", "87.98.138.49 www.kickasstorrents.com", "87.98.138.49 kat.ph", "87.98.138.49 www.kat.ph", "87.98.138.49 kastatic.com", "87.98.138.49 www.kastatic.com" };
        string[] VIMEO2 = new string[] { "87.98.138.49 vimeo.com", "87.98.138.49 www.vimeo.com" };
        string[] DAILYMOTION2 = new string[] { "87.98.138.49 dailymotion.com", "87.98.138.49 www.dailymotion.com" };
        string[] XMARKS2 = new string[] { "87.98.138.49 xmarks.com", "87.98.138.49 www.xmarks.com" };
        string[] PASTEBIN2 = new string[] { "87.98.138.49 pastebin.com", "87.98.138.49 www.pastebin.com" };
        string[] ISOHUNT2 = new string[] { "87.98.138.49 isohunt.com", "87.98.138.49 www.isohunt.com" };
        string[] TORFUNK2 = new string[] { "87.98.138.49 torrentfunk.com", "87.98.138.49 www.torrentfunk.com" };
        string[] EXTRATOR2 = new string[] { "87.98.138.49 extratorrent.com", "87.98.138.49 www.extratorrent.com" };
        string[] TORDOTNET2 = new string[] { "87.98.138.49 torrent.net", "87.98.138.49 www.torrent.net" };
        string[] TORROOM2 = new string[] { "87.98.138.49 torrentroom.com", "87.98.138.49 www.torrentroom.com" };
        string[] TORROOT2 = new string[] { "87.98.138.49 torrentroot.com", "87.98.138.49 www.torrentroot.com" };
        #endregion
        #region alt proxies 2
        string[] all3 = new string[] { "94.23.121.104 thepiratebay.org", "94.23.121.104 www.thepiratebay.org", 
        "94.23.121.104 thepiratebay.se", "94.23.121.104 www.thepiratebay.se", "94.23.121.104 thepiratebay.com", 
        "94.23.121.104 www.thepiratebay.com", "94.23.121.104 depiraatbaai.be", "94.23.121.104 www.depiraatbaai.be", 
        "94.23.121.104 baiedespirates.be", "94.23.121.104 www.baiedespirates.be", "94.23.121.104 torrentz.eu", "94.23.121.104 www.torrentz.eu", 
        "94.23.121.104 torrenthound.com", "94.23.121.104 www.torrenthound.com", "94.23.121.104 1337x.org", "94.23.121.104 www.1337x.org", 
        "94.23.121.104 torlock.com", "94.23.121.104 www.torlock.com", "94.23.121.104 vertor.com", "94.23.121.104 www.vertor.com", 
        "94.23.121.104 fenopy.se", "94.23.121.104 www.fenopy.se", "94.23.121.104 yourbittorrent.com", "94.23.121.104 www.yourbittorrent.com", 
        "94.23.121.104 monova.org", "94.23.121.104 www.monova.org", "94.23.121.104 h33t.com", "94.23.121.104 www.h33t.com",
        "94.23.121.104 torrentreactor.net", "94.23.121.104 www.torrentreactor.net", "94.23.121.104 torrentcrazy.com", 
        "94.23.121.104 www.torrentcrazy.com", "94.23.121.104 www.torrents.thepiratebay.se", "94.23.121.104 torrents.thepiratebay.se", 
        "94.23.121.104 mininova.org", "94.23.121.104 www.mininova.org", "94.23.121.104 kat.ph", "94.23.121.104 www.kat.ph", 
        "94.23.121.104 vimeo.com", "94.23.121.104 www.vimeo.com", "94.23.121.104 dailymotion.com", "94.23.121.104 www.dailymotion.com",
        "94.23.121.104 xmarks.com", "94.23.121.104 www.xmarks.com", "94.23.121.104 pastebin.com", "94.23.121.104 www.pastebin.com",
        "94.23.121.104 isohunt.com", "94.23.121.104 www.isohunt.com", "94.23.121.104 torrentfunk.com", "94.23.121.104 www.torrentfunk.com", 
        "94.23.121.104 extratorrent.com", "94.23.121.104 www.extratorrent.com", "94.23.121.104 torrent.net", "94.23.121.104 www.torrent.net", 
        "94.23.121.104 torrentroom.com", "94.23.121.104 www.torrentroom.com", "94.23.121.104 torrentroot.com", "94.23.121.104 www.torrentroot.com", 
        "94.23.121.104 kickasstorrents.com", "94.23.121.104 www.kickasstorrents.com" , "94.23.121.104 kastatic.com", "94.23.121.104 www.kastatic.com"};
        string[] TPB3 = new string[] { "94.23.121.104 torrents.thepiratebay.se", "94.23.121.104 www.torrents.thepiratebay.se", "94.23.121.104 thepiratebay", "94.23.121.104 thepiratebay.org", "94.23.121.104 www.thepiratebay.org", "94.23.121.104 thepiratebay.se", "94.23.121.104 www.thepiratebay.se", "94.23.121.104 thepiratebay.com", "94.23.121.104 www.thepiratebay.com", "94.23.121.104 depiraatbaai.be", "94.23.121.104 www.depiraatbaai.be", "94.23.121.104 baiedespirates.be", "94.23.121.104 www.baiedespirates.be" };
        string[] TORRENTZEU3 = new string[] { "94.23.121.104 torrentz.eu", "94.23.121.104 www.torrentz.eu" };
        string[] TORRENTHND3 = new string[] { "94.23.121.104 torrenthound.com", "94.23.121.104 www.torrenthound.com" };
        string[] LEETX3 = new string[] { "94.23.121.104 1337x.org", "94.23.121.104 www.1337x.org" };
        string[] TORLOCK3 = new string[] { "94.23.121.104 torlock.com", "94.23.121.104 www.torlock.com" };
        string[] VERTOR3 = new string[] { "94.23.121.104 vertor.com", "94.23.121.104 www.vertor.com" };
        string[] FENOPY3 = new string[] { "94.23.121.104 fenopy.se", "94.23.121.104 www.fenopy.se" };
        string[] YBT3 = new string[] { "94.23.121.104 yourbittorrent.com", "94.23.121.104 www.yourbittorrent.com" };
        string[] MONOVA3 = new string[] { "94.23.121.104 monova.org", "94.23.121.104 www.monova.org" };
        string[] HEET3 = new string[] { "94.23.121.104 h33t.com", "94.23.121.104 www.h33t.com" };
        string[] TORRENTREACTOR3 = new string[] { "94.23.121.104 torrentreactor.net", "94.23.121.104 www.torrentreactor.net" };
        string[] TORRENTCRAZY3 = new string[] { "94.23.121.104 torrentcrazy.com", "94.23.121.104 www.torrentcrazy.com" };
        string[] MINNOVA3 = new string[] { "94.23.121.104 mininova.org", "94.23.121.104 www.mininova.org" };
        string[] KATPH3 = new string[] { "94.23.121.104 kickasstorrents.com", "94.23.121.104 www.kickasstorrents.com", "94.23.121.104 kat.ph", "94.23.121.104 www.kat.ph", "94.23.121.104 kastatic.com", "94.23.121.104 www.kastatic.com" };
        string[] VIMEO3 = new string[] { "94.23.121.104 vimeo.com", "94.23.121.104 www.vimeo.com" };
        string[] DAILYMOTION3 = new string[] { "94.23.121.104 dailymotion.com", "94.23.121.104 www.dailymotion.com" };
        string[] XMARKS3 = new string[] { "94.23.121.104 xmarks.com", "94.23.121.104 www.xmarks.com" };
        string[] PASTEBIN3 = new string[] { "94.23.121.104 pastebin.com", "94.23.121.104 www.pastebin.com" };
        string[] ISOHUNT3 = new string[] { "94.23.121.104 isohunt.com", "94.23.121.104 www.isohunt.com" };
        string[] TORFUNK3 = new string[] { "94.23.121.104 torrentfunk.com", "94.23.121.104 www.torrentfunk.com" };
        string[] EXTRATOR3 = new string[] { "94.23.121.104 extratorrent.com", "94.23.121.104 www.extratorrent.com" };
        string[] TORDOTNET3 = new string[] { "94.23.121.104 torrent.net", "94.23.121.104 www.torrent.net" };
        string[] TORROOM3 = new string[] { "94.23.121.104 torrentroom.com", "94.23.121.104 www.torrentroom.com" };
        string[] TORROOT3 = new string[] { "94.23.121.104 torrentroot.com", "94.23.121.104 www.torrentroot.com" };
        #endregion
        #region alt proxies 3
        string[] all4 = new string[] { "5.135.162.74  thepiratebay.org", "5.135.162.74  www.thepiratebay.org", 
        "5.135.162.74  thepiratebay.se", "5.135.162.74  www.thepiratebay.se", "5.135.162.74  thepiratebay.com", 
        "5.135.162.74  www.thepiratebay.com", "5.135.162.74  depiraatbaai.be", "5.135.162.74  www.depiraatbaai.be", 
        "5.135.162.74  baiedespirates.be", "5.135.162.74  www.baiedespirates.be", "5.135.162.74  torrentz.eu", "5.135.162.74  www.torrentz.eu", 
        "5.135.162.74  torrenthound.com", "5.135.162.74  www.torrenthound.com", "5.135.162.74  1337x.org", "5.135.162.74  www.1337x.org", 
        "5.135.162.74  torlock.com", "5.135.162.74  www.torlock.com", "5.135.162.74  vertor.com", "5.135.162.74  www.vertor.com", 
        "5.135.162.74  fenopy.se", "5.135.162.74  www.fenopy.se", "5.135.162.74  yourbittorrent.com", "5.135.162.74  www.yourbittorrent.com", 
        "5.135.162.74  monova.org", "5.135.162.74  www.monova.org", "5.135.162.74  h33t.com", "5.135.162.74  www.h33t.com",
        "5.135.162.74  torrentreactor.net", "5.135.162.74  www.torrentreactor.net", "5.135.162.74  torrentcrazy.com", 
        "5.135.162.74  www.torrentcrazy.com", "5.135.162.74  www.torrents.thepiratebay.se", "5.135.162.74  torrents.thepiratebay.se", 
        "5.135.162.74  mininova.org", "5.135.162.74  www.mininova.org", "5.135.162.74  kat.ph", "5.135.162.74  www.kat.ph", 
        "5.135.162.74  vimeo.com", "5.135.162.74  www.vimeo.com", "5.135.162.74  dailymotion.com", "5.135.162.74  www.dailymotion.com",
        "5.135.162.74  xmarks.com", "5.135.162.74  www.xmarks.com", "5.135.162.74  pastebin.com", "5.135.162.74  www.pastebin.com",
        "5.135.162.74  isohunt.com", "5.135.162.74  www.isohunt.com", "5.135.162.74  torrentfunk.com", "5.135.162.74  www.torrentfunk.com", 
        "5.135.162.74  extratorrent.com", "5.135.162.74  www.extratorrent.com", "5.135.162.74  torrent.net", "5.135.162.74  www.torrent.net", 
        "5.135.162.74  torrentroom.com", "5.135.162.74  www.torrentroom.com", "5.135.162.74  torrentroot.com", "5.135.162.74  www.torrentroot.com", 
        "5.135.162.74  kickasstorrents.com", "5.135.162.74  www.kickasstorrents.com" , "5.135.162.74  kastatic.com", "5.135.162.74  www.kastatic.com"};
        string[] TPB4 = new string[] { "5.135.162.74  torrents.thepiratebay.se", "5.135.162.74  www.torrents.thepiratebay.se", "5.135.162.74  thepiratebay", "5.135.162.74  thepiratebay.org", "5.135.162.74  www.thepiratebay.org", "5.135.162.74  thepiratebay.se", "5.135.162.74  www.thepiratebay.se", "5.135.162.74  thepiratebay.com", "5.135.162.74  www.thepiratebay.com", "5.135.162.74  depiraatbaai.be", "5.135.162.74  www.depiraatbaai.be", "5.135.162.74  baiedespirates.be", "5.135.162.74  www.baiedespirates.be" };
        string[] TORRENTZEU4 = new string[] { "5.135.162.74  torrentz.eu", "5.135.162.74  www.torrentz.eu" };
        string[] TORRENTHND4 = new string[] { "5.135.162.74  torrenthound.com", "5.135.162.74  www.torrenthound.com" };
        string[] LEETX4 = new string[] { "5.135.162.74  1337x.org", "5.135.162.74  www.1337x.org" };
        string[] TORLOCK4 = new string[] { "5.135.162.74  torlock.com", "5.135.162.74  www.torlock.com" };
        string[] VERTOR4 = new string[] { "5.135.162.74  vertor.com", "5.135.162.74  www.vertor.com" };
        string[] FENOPY4 = new string[] { "5.135.162.74  fenopy.se", "5.135.162.74  www.fenopy.se" };
        string[] YBT4 = new string[] { "5.135.162.74  yourbittorrent.com", "5.135.162.74  www.yourbittorrent.com" };
        string[] MONOVA4 = new string[] { "5.135.162.74  monova.org", "5.135.162.74  www.monova.org" };
        string[] HEET4 = new string[] { "5.135.162.74  h33t.com", "5.135.162.74  www.h33t.com" };
        string[] TORRENTREACTOR4 = new string[] { "5.135.162.74  torrentreactor.net", "5.135.162.74  www.torrentreactor.net" };
        string[] TORRENTCRAZY4 = new string[] { "5.135.162.74  torrentcrazy.com", "5.135.162.74  www.torrentcrazy.com" };
        string[] MINNOVA4 = new string[] { "5.135.162.74  mininova.org", "5.135.162.74  www.mininova.org" };
        string[] KATPH4 = new string[] { "5.135.162.74  kickasstorrents.com", "5.135.162.74  www.kickasstorrents.com", "5.135.162.74  kat.ph", "5.135.162.74  www.kat.ph", "5.135.162.74  kastatic.com", "5.135.162.74  www.kastatic.com" };
        string[] VIMEO4 = new string[] { "5.135.162.74  vimeo.com", "5.135.162.74  www.vimeo.com" };
        string[] DAILYMOTION4 = new string[] { "5.135.162.74  dailymotion.com", "5.135.162.74  www.dailymotion.com" };
        string[] XMARKS4 = new string[] { "5.135.162.74  xmarks.com", "5.135.162.74  www.xmarks.com" };
        string[] PASTEBIN4 = new string[] { "5.135.162.74  pastebin.com", "5.135.162.74  www.pastebin.com" };
        string[] ISOHUNT4 = new string[] { "5.135.162.74  isohunt.com", "5.135.162.74  www.isohunt.com" };
        string[] TORFUNK4 = new string[] { "5.135.162.74  torrentfunk.com", "5.135.162.74  www.torrentfunk.com" };
        string[] EXTRATOR4 = new string[] { "5.135.162.74  extratorrent.com", "5.135.162.74  www.extratorrent.com" };
        string[] TORDOTNET4 = new string[] { "5.135.162.74  torrent.net", "5.135.162.74  www.torrent.net" };
        string[] TORROOM4 = new string[] { "5.135.162.74  torrentroom.com", "5.135.162.74  www.torrentroom.com" };
        string[] TORROOT4 = new string[] { "5.135.162.74  torrentroot.com", "5.135.162.74  www.torrentroot.com" };
        #endregion
        #endregion
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (The_Elite_Patcher.Properties.Settings.Default.rememberme == false)
            {
                The_Elite_Patcher.Properties.Settings.Default.user = "";
                The_Elite_Patcher.Properties.Settings.Default.pass = "";
            }
            The_Elite_Patcher.Properties.Settings.Default.hash = "";
            The_Elite_Patcher.Properties.Settings.Default.Save();
            Environment.Exit(0);
        }
        string plugindir = Directory.GetCurrentDirectory() + @"\plugins\";
        string assembly = "";
        private void Form1_Load(object sender, EventArgs e)
        {
            if (!File.Exists(hosts))
            {
                if (MessageBox.Show("It Seems that your hosts file is missing. Would you like to create a fresh one now? (Please note that the hosts file must exist for The Elite Patch to work)", "Hosts File Missing!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.cleanHosts(hosts);
                }
            }
            #region md5 check
            try
            {
                HttpWebRequest md5req = (HttpWebRequest)WebRequest.Create("http://files.theelitepatch.com/md5-" + The_Elite_Patcher.Properties.Settings.Default.ProgVers.ToString() + ".txt");
                WebResponse md5res = md5req.GetResponse();
                System.IO.StreamReader md5sr = new System.IO.StreamReader(md5res.GetResponseStream(), System.Text.Encoding.GetEncoding("windows-1252"));
                string goodMd5 = md5sr.ReadToEnd();
                string thisMd52 = NiCoding_Development_Library.File_Operations.FileChecking.AltGetMd5HashFromFile("The Elite Patcher.exe");
                HttpWebRequest md5reqndl = (HttpWebRequest)WebRequest.Create("http://files.theelitepatch.com/md5-ndl-" + The_Elite_Patcher.Properties.Settings.Default.ndlvers.ToString() + ".txt");
                WebResponse md5resndl = md5reqndl.GetResponse();
                System.IO.StreamReader md5srndl = new System.IO.StreamReader(md5resndl.GetResponseStream(), System.Text.Encoding.GetEncoding("windows-1252"));
                string goodMd5ndl = md5srndl.ReadToEnd();
                string thisMd52ndl = NiCoding_Development_Library.File_Operations.FileChecking.AltGetMd5HashFromFile("ndl.dll");
                if (thisMd52ndl == goodMd5ndl && thisMd52 == goodMd5)
                {
                    //good color
                    pictureBox1.Image = The_Elite_Patcher.Properties.Resources.green_circle;
                }
                else
                {
                    //bad color
                    pictureBox1.Image = The_Elite_Patcher.Properties.Resources.red_circle;
                }
            }
            catch
            { }
            #endregion
            #region news
            try
            {

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://files.theelitepatch.com/news.txt");
                WebResponse response = request.GetResponse();
                System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream(), System.Text.Encoding.GetEncoding("windows-1252"));
                textBox1.Text = sr.ReadToEnd();
                label8.Text = The_Elite_Patcher.Properties.Settings.Default.news_dl.ToString();
            }
            catch (Exception ex)
            {
                textBox1.Text = ex.Message;
            }
            #endregion
            #region version label
            try
            {

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://files.theelitepatch.com/displayvers.txt");
                WebResponse response = request.GetResponse();
                System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream(), System.Text.Encoding.GetEncoding("windows-1252"));
                string verz = sr.ReadToEnd();
                double curverz = Convert.ToDouble(label3.Text);
                double newverz = Convert.ToDouble(verz);
                if (curverz < newverz)
                {
                    linkLabel1.Text = verz;
                    linkLabel1.Visible = true;
                    label71.Visible = false;
                }

            }
            catch { }
            #endregion
            if (The_Elite_Patcher.Properties.Settings.Default.usrcachset == true)
            {
                if (DateTime.Now.Subtract(The_Elite_Patcher.Properties.Settings.Default.usrcachdate).Days >= 10)
                {
                    loadUsr();
                    if (The_Elite_Patcher.Properties.Settings.Default.usrcachsaved == false)
                    {
                        genCacheFile(usrfile);
                    }
                }
                else
                {
                    try
                    {
                        getCacheInfo(usrfile);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                loadUsr();
            }
            #region directory checks
            if (!Directory.Exists(Directory.GetCurrentDirectory() + @"\plugins"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\plugins");
            }
            if (!String.IsNullOrEmpty(The_Elite_Patcher.Properties.Settings.Default.hosts))
            {
                hosts = The_Elite_Patcher.Properties.Settings.Default.hosts;
            }
            if (!Directory.Exists(Directory.GetCurrentDirectory() + @"\Temp"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\Temp");
            }
            if (File.Exists(Directory.GetCurrentDirectory() + @"\Temp\updater.exe"))
            {
                File.Delete(Directory.GetCurrentDirectory() + @"\updater.exe");
                File.Copy(Directory.GetCurrentDirectory() + @"\Temp\updater.exe", Directory.GetCurrentDirectory() + @"\updater.exe");
                File.Delete(Directory.GetCurrentDirectory() + @"\Temp\updater.exe");
            }
            #endregion
            #region labels
            label9.Text = The_Elite_Patcher.Properties.Settings.Default.custom_hosts.ToString();
            label11.Text = The_Elite_Patcher.Properties.Settings.Default.alt_proxy.ToString();
            label13.Text = The_Elite_Patcher.Properties.Settings.Default.ProgVers.ToString();
            textBox3.Text = The_Elite_Patcher.Properties.Settings.Default.hosts;
            if (The_Elite_Patcher.Properties.Settings.Default.is_developer == true)
            {
                superTabItem2.Visible = true;
                buttonItem12.Text = "Revoke Developer Mode";
            }
            else
            {
                superTabItem2.Visible = false;
            }
            if (System.Environment.Is64BitOperatingSystem)
            {
                label23.Text = "64-Bit";
            }
            label22.Text = osVers();
            #endregion
            betacheckupdateontime();
            updchk.Start();
            label79.Text = UsrPnl2.Text;
            label85.Text = UsrEmailLbl2.Text;
            The_Elite_Patcher.Properties.Settings.Default.removeme = "";
            pluginCheck();
            addonCheck();
            getPlugins();
            getHosts();
            loadHostsFile();
            string[] removeMe = The_Elite_Patcher.Properties.Settings.Default.removeme.Split('=');
            try
            {
                foreach (string str in removeMe)
                {
                    listBox1.Items.Add(str);
                }
            }
            catch{}
            NiCoding_Development_Library.File_Operations.WriteFile.removeLine(hosts, removeMe);
        }
        private void pluginCheck()
        {
            int plgcnt = 0;
            itemContainer2.SubItems.Clear();
            #region checkforaddons
            try
            {
                string[] fileEntries = Directory.GetFiles(plugindir, "*.dll");
                DirectoryInfo addonnfo = new DirectoryInfo(plugindir);
                if (addonnfo.Exists)
                {
                    if (IsDirectoryEmpty(plugindir) == false)
                    {
                        int i = 0;
                        foreach (string fileName in fileEntries)
                        {
                            assembly = fileName;
                            string totalfilename = Path.GetFileNameWithoutExtension(fileName);
                            try
                            {
                                string startchar = "";
                                if (Regex.IsMatch(totalfilename.Substring(0,1), @"\d"))
                                {
                                    startchar = "_";
                                }
                                string fileopenloc = plugindir + totalfilename + ".dll";
                                System.Reflection.Assembly extAssembly = System.Reflection.Assembly.LoadFrom(fileopenloc);
                                Type t = extAssembly.GetType(startchar + totalfilename + ".Class1");
                                MethodInfo n = t.GetMethod("name");
                                string name = n.Invoke(null, new object[] { }).ToString();
                                name = name.Replace(" ", "");
                                if (!String.IsNullOrEmpty(The_Elite_Patcher.Properties.Settings.Default.removeme))
                                {
                                    The_Elite_Patcher.Properties.Settings.Default.removeme = The_Elite_Patcher.Properties.Settings.Default.removeme + "=" + name.ToLower();
                                }
                                else
                                {
                                    The_Elite_Patcher.Properties.Settings.Default.removeme = name.ToLower();
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            DevComponents.DotNetBar.Metro.MetroTileItem itemplug = new DevComponents.DotNetBar.Metro.MetroTileItem();
                            itemplug.Name = totalfilename;
                            try
                            {
                                Resources _r = new Resources(Assembly.LoadFile(assembly));
                                System.Drawing.Bitmap s = _r.Bitmaps["MetroIcon"];
                                if (s != null)
                                {
                                    itemplug.TileStyle.BackgroundImage = _r.Bitmaps["MetroIcon"];
                                    itemplug.TileStyle.BackgroundImagePosition = eStyleBackgroundImage.Stretch;
                                    itemplug.Refresh();
                                }
                                else
                                {
                                    itemplug.Text = itemplug.Name.ToString();
                                }
                            }
                            catch (Exception ex) { }
                            itemplug.Click += new EventHandler(itemplug_Click);
                            itemContainer2.SubItems.Add(itemplug);
                            plgcnt++;
                            i++;
                        }
                    }
                }
                if (plgcnt > 0)
                {
                    //label20.Text = plgcnt.ToString();
                }
                else
                {
                    //label20.Text = "0";
                }
                itemContainer1.Refresh();
                The_Elite_Patcher.Properties.Settings.Default.Save();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            The_Elite_Patcher.Properties.Settings.Default.removeme = The_Elite_Patcher.Properties.Settings.Default.removeme + "=baiedespirates";
            The_Elite_Patcher.Properties.Settings.Default.removeme = The_Elite_Patcher.Properties.Settings.Default.removeme + "=depiraatbaai";
            The_Elite_Patcher.Properties.Settings.Default.removeme = The_Elite_Patcher.Properties.Settings.Default.removeme + "=kastatic";
            The_Elite_Patcher.Properties.Settings.Default.removeme = The_Elite_Patcher.Properties.Settings.Default.removeme + "=kat";
            #endregion.
        }
        private void addonCheck()
        {
            itemContainer6.SubItems.Clear();
            try
            {
                string[] fileEntries = Directory.GetFiles(addondir, "*.dll");
                DirectoryInfo addonnfo = new DirectoryInfo(addondir);
                if (addonnfo.Exists)
                {
                    if (IsDirectoryEmpty(addondir) == false)
                    {
                        int i = 0;
                        foreach (string fileName in fileEntries)
                        {
                            assembly = fileName;
                            string totalfilename = Path.GetFileNameWithoutExtension(fileName);
                            try
                            {
                                string fileopenloc = addondir + totalfilename + ".dll";
                                System.Reflection.Assembly extAssembly = System.Reflection.Assembly.LoadFrom(fileopenloc);
                                Type t = extAssembly.GetType(totalfilename + ".Class1");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            DevComponents.DotNetBar.Metro.MetroTileItem itemadd = new DevComponents.DotNetBar.Metro.MetroTileItem(); 
                            itemadd.Name = totalfilename;
                            itemadd.Text = totalfilename;
                            itemadd.Click += new EventHandler(itemadd_Click);
                            itemContainer6.SubItems.Add(itemadd);
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        void itemadd_Click(object sender, EventArgs e)
        {
            DevComponents.DotNetBar.Metro.MetroTileItem clickedItem = (DevComponents.DotNetBar.Metro.MetroTileItem)sender;
            string fileopenloc = addondir + clickedItem.Name + ".dll";
            string formname = clickedItem.Name + ".Form1";
            System.Reflection.Assembly extAssembly = System.Reflection.Assembly.LoadFrom(fileopenloc);
            Form extForm = (Form)extAssembly.CreateInstance(formname, true);
            this.AddOwnedForm(extForm);
            extForm.Show();
        }
        string[] plgste;
        void itemplug_Click(object sender, EventArgs e)
        {
            DevComponents.DotNetBar.Metro.MetroTileItem clickedItem = (DevComponents.DotNetBar.Metro.MetroTileItem)sender;
            string fileopenloc = plugindir + clickedItem.Name + ".dll";
            System.Reflection.Assembly extAssembly = System.Reflection.Assembly.LoadFrom(fileopenloc);
            string startchar = "";
            if (Regex.IsMatch(clickedItem.Name.Substring(0,1), @"\d"))
            {
                startchar = "_";
            }
            Type t = extAssembly.GetType(startchar + clickedItem.Name + ".Class1");
            int prxnum = The_Elite_Patcher.Properties.Settings.Default.prxylst;
            try
            {
                MethodInfo o = t.GetMethod("isOfic");
                MethodInfo u = t.GetMethod("website" + prxnum.ToString());
                string url = u.Invoke(null, new object[] { }).ToString();
                string[] urli = url.Split('=');
                MethodInfo n = t.GetMethod("name");
                string name = n.Invoke(null, new object[] { }).ToString();
                //create the array for that plugin
                List<string> list = new List<string>();
                foreach (string ste in urli)
                {
                    list.Add(ste);
                }
                plgste = list.ToArray();
                NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromDll(hosts, plgste);
                MessageBox.Show("Successfully patched " + name + "!");
            }
            catch
            {
                try
                {
                    MethodInfo u = t.GetMethod("website");
                    string url = u.Invoke(null, new object[] { }).ToString();
                    string[] urli = url.Split('=');
                    MethodInfo n = t.GetMethod("name");
                    string name = n.Invoke(null, new object[] { }).ToString();
                    //create the array for that plugin
                    List<string> list = new List<string>();
                    foreach (string ste in urli)
                    {
                        list.Add(ste);
                    }
                    plgste = list.ToArray();
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromDll(hosts, plgste);
                    MessageBox.Show("Successfully patched " + name + "!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Oops! It seems the plugin you downloaded is either corrupt or invalid! Please try to download the plugin again and report a bug if this message persists!" + Environment.NewLine + "Exact error: " + Environment.NewLine + ex.Message);
                }
            }
        }

        public void loadUsr()
        {
            #region load User Info
            string user = The_Elite_Patcher.Properties.Settings.Default.user;
            string pass = The_Elite_Patcher.Properties.Settings.Default.pass;
            string hash = The_Elite_Patcher.Properties.Settings.Default.hash;
            if (The_Elite_Patcher.Properties.Settings.Default.isRhAcc == false)
            {
                if (The_Elite_Patcher.Properties.Settings.Default.isAsAcc == false)
                {
                    if (!String.IsNullOrEmpty(user) && !String.IsNullOrEmpty(pass) && !String.IsNullOrEmpty(hash))
                    {
                        #region basic
                        #region avatar pics
                        //avi on account
                        UsrAvitarPic.ImageLocation = NiCoding_Development_Library.Forum_Tools.Xenforo.getAvatar(user, hash);
                        UsrAvitarPic2.ImageLocation = UsrAvitarPic.ImageLocation;
                        UsrAvitarPic4.ImageLocation = UsrAvitarPic.ImageLocation;
                        UsrAvitarPic6.ImageLocation = UsrAvitarPic.ImageLocation;
                        UsrAvitarPic7.ImageLocation = UsrAvitarPic.ImageLocation;
                        UsrAvitarPic8.ImageLocation = UsrAvitarPic.ImageLocation;
                        GraphicsPath gp = new GraphicsPath();
                        gp.AddEllipse(UsrAvitarPic.DisplayRectangle);
                        UsrAvitarPic.Region = new Region(gp);
                        UsrAvitarPic2.Region = new Region(gp);
                        UsrAvitarPic4.Region = new Region(gp);
                        UsrAvitarPic6.Region = new Region(gp);
                        UsrAvitarPic7.Region = new Region(gp);
                        UsrAvitarPic8.Region = new Region(gp);
                        #endregion
                        #region panels
                        UserNfoPanel.Text = user;
                        UsrPnl2.Text = user;
                        UsrPnl4.Text = user;
                        UsrPnl6.Text = user;
                        UsrPnl7.Text = user;
                        UsrPnl8.Text = user;
                        #endregion
                        #region usrtitle
                        UserTitleLbl.Text = NiCoding_Development_Library.Forum_Tools.Xenforo.getUserCustomTitle(user);
                        UsrTitleLbl2.Text = UserTitleLbl.Text;
                        UsrTitleLbl4.Text = UserTitleLbl.Text;
                        UsrTitleLbl6.Text = UserTitleLbl.Text;
                        UsrTitleLbl7.Text = UserTitleLbl.Text;
                        UsrTitleLbl8.Text = UserTitleLbl.Text;
                        #endregion
                        #region email
                        UsrEmailLbl.Text = NiCoding_Development_Library.Forum_Tools.Xenforo.getUserEmail(user);
                        UsrEmailLbl2.Text = UsrEmailLbl.Text;
                        UsrEmailLbl4.Text = UsrEmailLbl.Text;
                        UsrEmailLbl6.Text = UsrEmailLbl.Text;
                        UsrEmailLbl7.Text = UsrEmailLbl.Text;
                        UsrEmailLbl8.Text = UsrEmailLbl.Text;
                        #endregion
                        #region warning points
                        UsrWrningPntsLbl.Text = NiCoding_Development_Library.Forum_Tools.Xenforo.getUserWarningPoints(user).ToString();
                        UsrWrningPntsLbl2.Text = UsrWrningPntsLbl.Text;
                        UsrWrningPntsLbl4.Text = UsrWrningPntsLbl.Text;
                        UsrWrningPntsLbl6.Text = UsrWrningPntsLbl.Text;
                        UsrWrningPntsLbl7.Text = UsrWrningPntsLbl.Text;
                        UsrWrningPntsLbl8.Text = UsrWrningPntsLbl.Text;
                        #endregion
                        #region time zone
                        UsrTimeZoneLbl.Text = NiCoding_Development_Library.Forum_Tools.Xenforo.getUserTimeZone(user);
                        UsrTimeZoneLbl2.Text = UsrTimeZoneLbl.Text;
                        UsrTimeZoneLbl4.Text = UsrTimeZoneLbl.Text;
                        UsrTimeZoneLbl6.Text = UsrTimeZoneLbl.Text;
                        UsrTimeZoneLbl7.Text = UsrTimeZoneLbl.Text;
                        UsrTimeZoneLbl8.Text = UsrTimeZoneLbl.Text;
                        #endregion
                        #region msg count
                        UsrMsgCntLbl.Text = NiCoding_Development_Library.Forum_Tools.Xenforo.getUserMsgCount(user);
                        UsrMsgCntLbl2.Text = UsrMsgCntLbl.Text;
                        UsrMsgCntLbl4.Text = UsrMsgCntLbl.Text;
                        UsrMsgCntLbl6.Text = UsrMsgCntLbl.Text;
                        UsrMsgCntLbl7.Text = UsrMsgCntLbl.Text;
                        UsrMsgCntLbl8.Text = UsrMsgCntLbl.Text;
                        #endregion
                        #region unreadconvos
                        UsrUnreadConvoLbl.Text = NiCoding_Development_Library.Forum_Tools.Xenforo.getUserUnreadConvos(user);
                        UsrUnreadConvoLbl2.Text = UsrUnreadConvoLbl.Text;
                        UsrUnreadConvoLbl4.Text = UsrUnreadConvoLbl.Text;
                        UsrUnreadConvoLbl6.Text = UsrUnreadConvoLbl.Text;
                        UsrUnreadConvoLbl7.Text = UsrUnreadConvoLbl.Text;
                        UsrUnreadConvoLbl8.Text = UsrUnreadConvoLbl.Text;
                        #endregion
                        #region regdate
                        UsrRegDateLbl.Text = NiCoding_Development_Library.Forum_Tools.Xenforo.getUserRegDate(user);
                        UsrRegDateLbl2.Text = UsrRegDateLbl.Text;
                        UsrRegDateLbl4.Text = UsrRegDateLbl.Text;
                        UsrRegDateLbl6.Text = UsrRegDateLbl.Text;
                        UsrRegDateLbl7.Text = UsrRegDateLbl.Text;
                        UsrRegDateLbl8.Text = UsrRegDateLbl.Text;
                        #endregion
                        #region unread alerts
                        UsrUnreadAlertsLbl.Text = NiCoding_Development_Library.Forum_Tools.Xenforo.getUserUnreadAlerts(user).ToString();
                        UsrUnreadAlertsLbl2.Text = UsrUnreadAlertsLbl.Text;
                        UsrUnreadAlertsLbl4.Text = UsrUnreadAlertsLbl.Text;
                        UsrUnreadAlertsLbl6.Text = UsrUnreadAlertsLbl.Text;
                        UsrUnreadAlertsLbl7.Text = UsrUnreadAlertsLbl.Text;
                        UsrUnreadAlertsLbl8.Text = UsrUnreadAlertsLbl.Text;
                        #endregion
                        #endregion
                        #region detailed
                        DtlUsrNfoPnl.Text = "Detailed User Info For " + user;
                        UsrIdLbl.Text = NiCoding_Development_Library.Forum_Tools.Xenforo.getUserId(user);
                        UsrGenderLbl.Text = NiCoding_Development_Library.Forum_Tools.Xenforo.getUserGender(user);
                        UserVisibilityLbl.Text = NiCoding_Development_Library.Forum_Tools.Xenforo.getUserVisibility(user);
                        UsrFreeInvitesLbl.Text = NiCoding_Development_Library.Forum_Tools.Xenforo.getUserFreeInvites(user).ToString();
                        UsrBnkAmtLbl.Text = NiCoding_Development_Library.Forum_Tools.Xenforo.getUserBankMoney(user).ToString();
                        UsrFriendCntLbl.Text = NiCoding_Development_Library.Forum_Tools.Xenforo.getUserFriendCount(user).ToString();
                        UsrLikeCntLbl.Text = NiCoding_Development_Library.Forum_Tools.Xenforo.getUserLikeCount(user).ToString();
                        UsrBanStatLbl.Text = NiCoding_Development_Library.Forum_Tools.Xenforo.isBanned(user).ToString();
                        UsrAdminStatLbl.Text = NiCoding_Development_Library.Forum_Tools.Xenforo.isAdmin(user).ToString();
                        if (UsrAdminStatLbl.Text == "true" || UsrAdminStatLbl.Text == "True")
                        {
                            superTabItem4.Visible = true;
                        }
                        UsrModStatLbl.Text = NiCoding_Development_Library.Forum_Tools.Xenforo.isMod(user).ToString();
                        UsrValidStatLbl.Text = NiCoding_Development_Library.Forum_Tools.Xenforo.getUserState(user).ToString();
                        UsrAviDateLbl.Text = NiCoding_Development_Library.Forum_Tools.Xenforo.getUserAvitarDate(user);
                        UsrTrophyPntsLbl.Text = NiCoding_Development_Library.Forum_Tools.Xenforo.getUserTrophyPoints(user).ToString();
                        UsrLastActiveDate.Text = NiCoding_Development_Library.Forum_Tools.Xenforo.getUserLastActiveDate(user);
                        #endregion
                    }
                }
                else
                {
                    UsrPnl2.Visible = false;
                    UsrPnl4.Visible = false;
                    UsrPnl6.Visible = false;
                    UsrPnl7.Visible = false;
                    Account.Visible = false;
                    textBox1.Location = new Point(3, 57);
                    textBox1.Size = new Size(965, 354);
                    groupPanel3.Location = new Point(3, 3);
                    listBox8.Size = new Size(681, 199);
                    listBox8.Location = new Point(3, 34);
                    label29.Location = new Point(3, 15);
                    label1.Location = new Point(3, 3);
                    label3.Location = new Point(179, 3);
                    label2.Location = new Point(3, 19);
                    linkLabel1.Location = new Point(179, 19);
                }
            }
            else
            {
                if (!String.IsNullOrEmpty(user) && !String.IsNullOrEmpty(pass) && !String.IsNullOrEmpty(hash))
                {
                    #region basic
                    #region avatar pics
                    //avi on account
                    UsrAvitarPic.ImageLocation = NiCoding_Development_Library.Forum_Tools.XenforoRoyalhood.getAvatar(user, hash);
                    UsrAvitarPic2.ImageLocation = UsrAvitarPic.ImageLocation;
                    UsrAvitarPic4.ImageLocation = UsrAvitarPic.ImageLocation;
                    UsrAvitarPic6.ImageLocation = UsrAvitarPic.ImageLocation;
                    UsrAvitarPic7.ImageLocation = UsrAvitarPic.ImageLocation;
                    GraphicsPath gp = new GraphicsPath();
                    gp.AddEllipse(UsrAvitarPic.DisplayRectangle);
                    UsrAvitarPic.Region = new Region(gp);
                    UsrAvitarPic2.Region = new Region(gp);
                    UsrAvitarPic4.Region = new Region(gp);
                    UsrAvitarPic6.Region = new Region(gp);
                    UsrAvitarPic7.Region = new Region(gp);
                    #endregion
                    #region panels
                    UserNfoPanel.Text = user;
                    UsrPnl2.Text = user;
                    UsrPnl4.Text = user;
                    UsrPnl6.Text = user;
                    UsrPnl7.Text = user;
                    #endregion
                    #region usrtitle
                    UserTitleLbl.Text = NiCoding_Development_Library.Forum_Tools.XenforoRoyalhood.getUserCustomTitle(user);
                    UsrTitleLbl2.Text = UserTitleLbl.Text;
                    UsrTitleLbl4.Text = UserTitleLbl.Text;
                    UsrTitleLbl6.Text = UserTitleLbl.Text;
                    UsrTitleLbl7.Text = UserTitleLbl.Text;
                    #endregion
                    #region email
                    UsrEmailLbl.Text = NiCoding_Development_Library.Forum_Tools.XenforoRoyalhood.getUserEmail(user);
                    UsrEmailLbl2.Text = UsrEmailLbl.Text;
                    UsrEmailLbl4.Text = UsrEmailLbl.Text;
                    UsrEmailLbl6.Text = UsrEmailLbl.Text;
                    UsrEmailLbl7.Text = UsrEmailLbl.Text;
                    #endregion
                    #region warning points
                    UsrWrningPntsLbl.Text = NiCoding_Development_Library.Forum_Tools.XenforoRoyalhood.getUserWarningPoints(user).ToString();
                    UsrWrningPntsLbl2.Text = UsrWrningPntsLbl.Text;
                    UsrWrningPntsLbl4.Text = UsrWrningPntsLbl.Text;
                    UsrWrningPntsLbl6.Text = UsrWrningPntsLbl.Text;
                    UsrWrningPntsLbl7.Text = UsrWrningPntsLbl.Text;
                    #endregion
                    #region time zone
                    UsrTimeZoneLbl.Text = NiCoding_Development_Library.Forum_Tools.XenforoRoyalhood.getUserTimeZone(user);
                    UsrTimeZoneLbl2.Text = UsrTimeZoneLbl.Text;
                    UsrTimeZoneLbl4.Text = UsrTimeZoneLbl.Text;
                    UsrTimeZoneLbl6.Text = UsrTimeZoneLbl.Text;
                    UsrTimeZoneLbl7.Text = UsrTimeZoneLbl.Text;
                    #endregion
                    #region msg count
                    UsrMsgCntLbl.Text = NiCoding_Development_Library.Forum_Tools.XenforoRoyalhood.getUserMsgCount(user);
                    UsrMsgCntLbl2.Text = UsrMsgCntLbl.Text;
                    UsrMsgCntLbl4.Text = UsrMsgCntLbl.Text;
                    UsrMsgCntLbl6.Text = UsrMsgCntLbl.Text;
                    UsrMsgCntLbl7.Text = UsrMsgCntLbl.Text;
                    #endregion
                    #region unreadconvos
                    UsrUnreadConvoLbl.Text = NiCoding_Development_Library.Forum_Tools.XenforoRoyalhood.getUserUnreadConvos(user);
                    UsrUnreadConvoLbl2.Text = UsrUnreadConvoLbl.Text;
                    UsrUnreadConvoLbl4.Text = UsrUnreadConvoLbl.Text;
                    UsrUnreadConvoLbl6.Text = UsrUnreadConvoLbl.Text;
                    UsrUnreadConvoLbl7.Text = UsrUnreadConvoLbl.Text;
                    #endregion
                    #region regdate
                    UsrRegDateLbl.Text = NiCoding_Development_Library.Forum_Tools.XenforoRoyalhood.getUserRegDate(user);
                    UsrRegDateLbl2.Text = UsrRegDateLbl.Text;
                    UsrRegDateLbl4.Text = UsrRegDateLbl.Text;
                    UsrRegDateLbl6.Text = UsrRegDateLbl.Text;
                    UsrRegDateLbl7.Text = UsrRegDateLbl.Text;
                    #endregion
                    #region unread alerts
                    UsrUnreadAlertsLbl.Text = NiCoding_Development_Library.Forum_Tools.XenforoRoyalhood.getUserUnreadAlerts(user).ToString();
                    UsrUnreadAlertsLbl2.Text = UsrUnreadAlertsLbl.Text;
                    UsrUnreadAlertsLbl4.Text = UsrUnreadAlertsLbl.Text;
                    UsrUnreadAlertsLbl6.Text = UsrUnreadAlertsLbl.Text;
                    UsrUnreadAlertsLbl7.Text = UsrUnreadAlertsLbl.Text;
                    #endregion
                    #endregion
                    #region detailed
                    DtlUsrNfoPnl.Text = "Detailed User Info For " + user;
                    UsrIdLbl.Text = NiCoding_Development_Library.Forum_Tools.XenforoRoyalhood.getUserId(user);
                    UsrGenderLbl.Text = NiCoding_Development_Library.Forum_Tools.XenforoRoyalhood.getUserGender(user);
                    UserVisibilityLbl.Text = NiCoding_Development_Library.Forum_Tools.XenforoRoyalhood.getUserVisibility(user);
                    UsrFreeInvitesLbl.Text = NiCoding_Development_Library.Forum_Tools.XenforoRoyalhood.getUserFreeInvites(user).ToString();
                    UsrBnkAmtLbl.Text = NiCoding_Development_Library.Forum_Tools.XenforoRoyalhood.getUserBankMoney(user).ToString();
                    UsrFriendCntLbl.Text = NiCoding_Development_Library.Forum_Tools.XenforoRoyalhood.getUserFriendCount(user).ToString();
                    UsrLikeCntLbl.Text = NiCoding_Development_Library.Forum_Tools.XenforoRoyalhood.getUserLikeCount(user).ToString();
                    UsrBanStatLbl.Text = NiCoding_Development_Library.Forum_Tools.XenforoRoyalhood.isBanned(user).ToString();
                    UsrAdminStatLbl.Text = NiCoding_Development_Library.Forum_Tools.XenforoRoyalhood.isAdmin(user).ToString();
                    if (UsrAdminStatLbl.Text == "true" || UsrAdminStatLbl.Text == "True")
                    {
                        superTabItem4.Visible = true;
                    }
                    UsrModStatLbl.Text = NiCoding_Development_Library.Forum_Tools.XenforoRoyalhood.isMod(user).ToString();
                    UsrValidStatLbl.Text = NiCoding_Development_Library.Forum_Tools.XenforoRoyalhood.getUserState(user).ToString();
                    UsrAviDateLbl.Text = NiCoding_Development_Library.Forum_Tools.XenforoRoyalhood.getUserAvitarDate(user);
                    UsrTrophyPntsLbl.Text = NiCoding_Development_Library.Forum_Tools.XenforoRoyalhood.getUserTrophyPoints(user).ToString();
                    UsrLastActiveDate.Text = NiCoding_Development_Library.Forum_Tools.XenforoRoyalhood.getUserLastActiveDate(user);
                    #endregion
                }
            }
            #endregion
        }
        public void getCacheInfo(string path)
        {
            string fil = @"\usrnfo.cnf";
            path = path + fil;
            NiCoding_Development_Library.Encryption.EncFuncs.encryptFile(path);
            string[] settings = File.ReadAllLines(path);
            string user = "";
            foreach (string line in settings)
            {
                string[] set = line.Split(';');
                if (set.Contains("username"))
                {
                    The_Elite_Patcher.Properties.Settings.Default.user = set[1];
                    UserNfoPanel.Text = set[1];
                    user = set[1];
                    UsrPnl2.Text = UserNfoPanel.Text;
                    UsrPnl4.Text = UserNfoPanel.Text;
                    UsrPnl6.Text = UserNfoPanel.Text;
                    UsrPnl7.Text = UserNfoPanel.Text;
                    UsrPnl8.Text = UserNfoPanel.Text;
                    DtlUsrNfoPnl.Text = "Detailed User Info For " + set[1];
                }
                else if (set.Contains("pass"))
                {
                    The_Elite_Patcher.Properties.Settings.Default.pass = CryptorEngine.Decrypt(set[1]);
                }
                else if (set.Contains("avatarlocation"))
                {
                    UsrAvitarPic.ImageLocation = set[1];
                    UsrAvitarPic2.ImageLocation = UsrAvitarPic.ImageLocation;
                    UsrAvitarPic4.ImageLocation = UsrAvitarPic.ImageLocation;
                    UsrAvitarPic6.ImageLocation = UsrAvitarPic.ImageLocation;
                    UsrAvitarPic7.ImageLocation = UsrAvitarPic.ImageLocation;
                    UsrAvitarPic8.ImageLocation = UsrAvitarPic.ImageLocation;
                    GraphicsPath gp = new GraphicsPath();
                    gp.AddEllipse(UsrAvitarPic.DisplayRectangle);
                    UsrAvitarPic.Region = new Region(gp);
                    UsrAvitarPic2.Region = new Region(gp);
                    UsrAvitarPic4.Region = new Region(gp);
                    UsrAvitarPic6.Region = new Region(gp);
                    UsrAvitarPic7.Region = new Region(gp);
                    UsrAvitarPic8.Region = new Region(gp);
                }
                else if (set.Contains("usertitle"))
                {
                    UserTitleLbl.Text = set[1];
                    UsrTitleLbl2.Text = UserTitleLbl.Text;
                    UsrTitleLbl4.Text = UserTitleLbl.Text;
                    UsrTitleLbl6.Text = UserTitleLbl.Text;
                    UsrTitleLbl7.Text = UserTitleLbl.Text;
                    UsrTitleLbl8.Text = UserTitleLbl.Text;
                }
                else if (set.Contains("email"))
                {
                    UsrEmailLbl.Text = set[1];
                    UsrEmailLbl2.Text = UsrEmailLbl.Text;
                    UsrEmailLbl4.Text = UsrEmailLbl.Text;
                    UsrEmailLbl6.Text = UsrEmailLbl.Text;
                    UsrEmailLbl7.Text = UsrEmailLbl.Text;
                    UsrEmailLbl8.Text = UsrEmailLbl.Text;
                }
                else if (set.Contains("warningpoints"))
                {
                    UsrWrningPntsLbl.Text = set[1];
                    UsrWrningPntsLbl2.Text = UsrWrningPntsLbl.Text;
                    UsrWrningPntsLbl4.Text = UsrWrningPntsLbl.Text;
                    UsrWrningPntsLbl6.Text = UsrWrningPntsLbl.Text;
                    UsrWrningPntsLbl7.Text = UsrWrningPntsLbl.Text;
                    UsrWrningPntsLbl8.Text = UsrWrningPntsLbl.Text;
                }
                else if (set.Contains("timezone"))
                {
                    UsrTimeZoneLbl.Text = set[1];
                    UsrTimeZoneLbl2.Text = UsrTimeZoneLbl.Text;
                    UsrTimeZoneLbl4.Text = UsrTimeZoneLbl.Text;
                    UsrTimeZoneLbl6.Text = UsrTimeZoneLbl.Text;
                    UsrTimeZoneLbl7.Text = UsrTimeZoneLbl.Text;
                    UsrTimeZoneLbl8.Text = UsrTimeZoneLbl.Text;
                }
                else if (set.Contains("messagecount"))
                {
                    UsrMsgCntLbl.Text = set[1];
                    UsrMsgCntLbl2.Text = UsrMsgCntLbl.Text;
                    UsrMsgCntLbl4.Text = UsrMsgCntLbl.Text;
                    UsrMsgCntLbl6.Text = UsrMsgCntLbl.Text;
                    UsrMsgCntLbl7.Text = UsrMsgCntLbl.Text;
                    UsrMsgCntLbl8.Text = UsrMsgCntLbl.Text;
                }
                else if (set.Contains("unreadconvos"))
                {
                    UsrUnreadConvoLbl.Text = set[1];
                    UsrUnreadConvoLbl2.Text = UsrUnreadConvoLbl.Text;
                    UsrUnreadConvoLbl4.Text = UsrUnreadConvoLbl.Text;
                    UsrUnreadConvoLbl6.Text = UsrUnreadConvoLbl.Text;
                    UsrUnreadConvoLbl7.Text = UsrUnreadConvoLbl.Text;
                    UsrUnreadConvoLbl8.Text = UsrUnreadConvoLbl.Text;
                }
                else if (set.Contains("registrationdate"))
                {
                    UsrRegDateLbl.Text = set[1];
                    UsrRegDateLbl2.Text = UsrRegDateLbl.Text;
                    UsrRegDateLbl4.Text = UsrRegDateLbl.Text;
                    UsrRegDateLbl6.Text = UsrRegDateLbl.Text;
                    UsrRegDateLbl7.Text = UsrRegDateLbl.Text;
                    UsrRegDateLbl8.Text = UsrRegDateLbl.Text;
                }
                else if (set.Contains("unreadalerts"))
                {
                    UsrUnreadAlertsLbl.Text = set[1];
                    UsrUnreadAlertsLbl2.Text = UsrUnreadAlertsLbl.Text;
                    UsrUnreadAlertsLbl4.Text = UsrUnreadAlertsLbl.Text;
                    UsrUnreadAlertsLbl6.Text = UsrUnreadAlertsLbl.Text;
                    UsrUnreadAlertsLbl7.Text = UsrUnreadAlertsLbl.Text;
                    UsrUnreadAlertsLbl8.Text = UsrUnreadAlertsLbl.Text;
                }
                else if (set.Contains("userid"))
                {
                    UsrIdLbl.Text = set[1];
                }
                else if (set.Contains("gender"))
                {
                    UsrGenderLbl.Text = set[1];
                }
                else if (set.Contains("visibility"))
                {
                    UserVisibilityLbl.Text = set[1];
                }
                else if (set.Contains("unusedinvites"))
                {
                    UsrFreeInvitesLbl.Text = set[1];
                }
                else if (set.Contains("bank"))
                {
                    UsrBnkAmtLbl.Text = set[1];
                }
                else if (set.Contains("friendcount"))
                {
                    UsrFriendCntLbl.Text = set[1];
                }
                else if (set.Contains("likecount"))
                {
                    UsrLikeCntLbl.Text = set[1];
                }
                else if (set.Contains("banned"))
                {
                    UsrBanStatLbl.Text = set[1];
                }
                else if (set.Contains("admin"))
                {
                    UsrAdminStatLbl.Text = set[1];
                    if (UsrAdminStatLbl.Text == "true" || UsrAdminStatLbl.Text == "True")
                    {
                        superTabItem4.Visible = true;
                    }
                }
                else if (set.Contains("mod"))
                {
                    UsrModStatLbl.Text = set[1];
                }
                else if (set.Contains("valid"))
                {
                    UsrValidStatLbl.Text = set[1];
                }
                else if (set.Contains("avitarchangedate"))
                {
                    UsrAviDateLbl.Text = set[1];
                }
                else if (set.Contains("trophypoints"))
                {
                    UsrTrophyPntsLbl.Text = set[1];
                }
                else if (set.Contains("lastactive"))
                {
                    UsrLastActiveDate.Text = set[1];
                }
                else if (set.Contains("referrerid"))
                {
                    UsrReferridLbl.Text = set[1];
                }
            }
        }
        public void genCacheFile(string path)
        {
            string fil = @"\usrnfo.cnf";
            string localFilename = path + @"\avi.png";
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(UsrAvitarPic.ImageLocation, localFilename);
                }
            }
            catch { }
            path = path + fil;
            File.WriteAllText(path, "[userinfo]" + Environment.NewLine);
            File.AppendAllText(path, "username;" + The_Elite_Patcher.Properties.Settings.Default.user + Environment.NewLine);
            string encpass = CryptorEngine.Encrypt(The_Elite_Patcher.Properties.Settings.Default.pass + Environment.NewLine);
            File.AppendAllText(path, "pass;" + encpass + Environment.NewLine);
            File.AppendAllText(path, "avatarlocation;" + localFilename + Environment.NewLine);
            File.AppendAllText(path, "usertitle;" + UsrTitleLbl2.Text + Environment.NewLine);
            File.AppendAllText(path, "email;" + UsrEmailLbl.Text + Environment.NewLine);
            File.AppendAllText(path, "warningpoints;" + UsrWrningPntsLbl.Text + Environment.NewLine);
            File.AppendAllText(path, "timezone;" + UsrTimeZoneLbl.Text + Environment.NewLine);
            File.AppendAllText(path, "messagecount;" + UsrMsgCntLbl.Text + Environment.NewLine);
            File.AppendAllText(path, "unreadconvos;" + UsrUnreadConvoLbl.Text + Environment.NewLine);
            File.AppendAllText(path, "registrationdate;" + UsrRegDateLbl.Text + Environment.NewLine);
            File.AppendAllText(path, "unreadalerts;" + UsrUnreadAlertsLbl.Text + Environment.NewLine);
            File.AppendAllText(path, "userid;" + UsrIdLbl.Text + Environment.NewLine);
            File.AppendAllText(path, "referrerid;" + UsrReferridLbl.Text + Environment.NewLine);
            File.AppendAllText(path, "gender;" + UsrGenderLbl.Text + Environment.NewLine);
            File.AppendAllText(path, "visibility;" + UserVisibilityLbl.Text + Environment.NewLine);
            File.AppendAllText(path, "unusedinvites;" + UsrFreeInvitesLbl.Text + Environment.NewLine);
            File.AppendAllText(path, "bank;" + UsrBnkAmtLbl.Text + Environment.NewLine);
            File.AppendAllText(path, "friendcount;" + UsrFriendCntLbl.Text + Environment.NewLine);
            File.AppendAllText(path, "likecount;" + UsrLikeCntLbl.Text + Environment.NewLine);
            File.AppendAllText(path, "avitarchangedate;" + UsrAviDateLbl.Text + Environment.NewLine);
            File.AppendAllText(path, "trophypoints;" + UsrTrophyPntsLbl.Text + Environment.NewLine);
            File.AppendAllText(path, "lastactive;" + UsrLastActiveDate.Text + Environment.NewLine);
            File.AppendAllText(path, "banned;" + UsrBanStatLbl.Text + Environment.NewLine);
            File.AppendAllText(path, "admin;" + UsrAdminStatLbl.Text + Environment.NewLine);
            File.AppendAllText(path, "mod;" + UsrModStatLbl.Text + Environment.NewLine);
            File.AppendAllText(path, "valid;" + UsrValidStatLbl.Text + Environment.NewLine);
            The_Elite_Patcher.Properties.Settings.Default.usrcachdate = DateTime.Now;
            The_Elite_Patcher.Properties.Settings.Default.usrcachsaved = true;
            The_Elite_Patcher.Properties.Settings.Default.usrcachset = true;
            The_Elite_Patcher.Properties.Settings.Default.Save();
            NiCoding_Development_Library.Encryption.EncFuncs.encryptFile(path);
        }
        #region hosts tools
        private void backupHosts()
        {
            SaveFileDialog SFD = new SaveFileDialog();
            SFD.Title = "Choose a location to backup your hosts file to.";
            SFD.OverwritePrompt = true;
            SFD.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Windows) + @"\System32\Drivers\etc\";
            if (SFD.ShowDialog() == DialogResult.OK)
            {
                File.Copy(hosts, SFD.FileName);
                MessageBox.Show("Successfully Backed Up Hosts File to " + SFD.FileName);
            }
        }

        private void writeNewHosts()
        {
            NiCoding_Development_Library.File_Operations.WriteFile.cleanHosts(hosts);
        }

        private void restoreOldHosts()
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Title = "Choose your backed up hosts file.";
            OFD.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Windows) + @"\System32\Drivers\etc\";
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                File.Delete(hosts);
                File.Copy(OFD.FileName, hosts);
                MessageBox.Show("Successfully Restored Hosts File to " + OFD.FileName);
            }
        }
        #endregion
        #region globals
        Timer tim1 = new Timer();
        string getplugins = "";
        string gethosts = "";
        #endregion
        #region get plugin list async
        private void getPlugins()
        {

            try
            {
                WebClient wc = new WebClient();
                Uri url = new Uri("http://files.theelitepatch.com/pluginlist.txt");
                string output = "";
                wc.DownloadStringCompleted +=
                delegate(object s, DownloadStringCompletedEventArgs e)
                {
                    output = (string)e.Result;
                    if (output.Contains("Plugin List"))
                    {
                        getplugins = output;
                        loadPlugins();
                    }
                };
                wc.DownloadStringAsync(url);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public void loadPlugins()
        {
            foreach (string plugin in getplugins.Split('='))
            {
                if (plugin.Contains("~"))
                {
                    DevComponents.DotNetBar.Metro.MetroTileItem itemplug2 = new DevComponents.DotNetBar.Metro.MetroTileItem();
                    itemplug2.Name = plugin.Split('~')[0];
                    if (!String.IsNullOrEmpty(plugin.Split('~')[1]))
                    {
                        //itemplug2.TileStyle.BackgroundImage = (Bitmap)downloadImage(plugin.Split('~')[1];
                    }
                    else
                    {
                        itemplug2.Text = itemplug2.Name.ToString();
                    }
                    itemplug2.Text = itemplug2.Name.ToString();
                    itemplug2.TileStyle.BackgroundImagePosition = eStyleBackgroundImage.Stretch;
                    itemplug2.Click += new EventHandler(itemplug2_Click);
                    itemContainer4.SubItems.Add(itemplug2);
                }
            }
            itemContainer4.Refresh();
        }

        void itemplug2_Click(object sender, EventArgs e)
        {
            DevComponents.DotNetBar.Metro.MetroTileItem clickedItem = (DevComponents.DotNetBar.Metro.MetroTileItem)sender;
            foreach (string plugin in getplugins.Split('='))
            {
                if (plugin.Contains(clickedItem.Name))
                {
                    try
                    {
                        WebClient wc = new WebClient();
                        string url = plugin.Split('~')[2];
                        string FileName = url.Substring(url.LastIndexOf("/") + 1,
                           (url.Length - url.LastIndexOf("/") - 1));
                        string dlfolder = addondir;
                        wc.DownloadFileCompleted +=
                        delegate(object s, AsyncCompletedEventArgs de)
                        {
                            addonCheck();
                        };
                        wc.DownloadFileAsync(new Uri(url), dlfolder + @"\" + FileName);
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }
            }
        }

        #endregion
        #region get hosts list async
        private void getHosts()
        {

            try
            {
                WebClient wc = new WebClient();
                Uri url = new Uri("http://files.theelitepatch.com/hostslist.txt");
                string output = "";
                wc.DownloadStringCompleted +=
                delegate(object s, DownloadStringCompletedEventArgs e)
                {
                    output = (string)e.Result;
                    if (output.Contains("Hosts List"))
                    {
                        gethosts = output;
                        loadHosts();
                    }
                };
                wc.DownloadStringAsync(url);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public void loadHosts()
        {
            foreach (string plugin in gethosts.Split('='))
            {
                if (plugin.Contains("~"))
                {
                    DevComponents.DotNetBar.Metro.MetroTileItem itemhost = new DevComponents.DotNetBar.Metro.MetroTileItem();
                    itemhost.Name = plugin.Split('~')[0];
                    if (!String.IsNullOrEmpty(plugin.Split('~')[1]))
                    {
                        //itemplug.TileStyle.BackgroundImage = plugin.Split('~')[1];
                    }
                    else
                    {
                        itemhost.Text = itemhost.Name.ToString();
                    }
                    itemhost.Text = itemhost.Name.ToString();
                    itemhost.TileStyle.BackgroundImagePosition = eStyleBackgroundImage.Stretch;
                    itemhost.Click += new EventHandler(itemhost_Click);
                    itemContainer5.SubItems.Add(itemhost);
                }
            }
            itemContainer5.Refresh();
        }
        
        void itemhost_Click(object sender, EventArgs e)
        {
            DevComponents.DotNetBar.Metro.MetroTileItem clickedItem = (DevComponents.DotNetBar.Metro.MetroTileItem)sender;
            foreach (string plugin in gethosts.Split('='))
            {
                if (plugin.Contains(clickedItem.Name))
                {
                    try
                    {
                        WebClient wc = new WebClient();
                        string url = plugin.Split('~')[2];
                        string FileName = url.Substring(url.LastIndexOf("/") + 1,
                           (url.Length - url.LastIndexOf("/") - 1));
                        string dlfolder = plugindir;
                        wc.DownloadFileCompleted +=
                        delegate(object s, AsyncCompletedEventArgs de)
                        {
                            pluginCheck();
                        };
                        wc.DownloadFileAsync(new Uri(url), dlfolder + @"\" + FileName);
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }
            }
        }
        #endregion
        #region loadhostsfiletolistbox
        private void loadHostsFile()
        {
            foreach (string line in File.ReadAllLines(The_Elite_Patcher.Properties.Settings.Default.hosts))
            {
                listBox2.Items.Add(line);
            }
        }
        #endregion
        public bool IsDirectoryEmpty(string path)
        {
            return !Directory.EnumerateFileSystemEntries(path).Any();
        }

        private string osVers()
        {
            var name = (from x in new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem").Get().OfType<ManagementObject>()
                        select x.GetPropertyValue("Caption")).First();
            return name != null ? name.ToString() : "Unknown";
        }

        private void buttonItem7_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            betacheckupdate();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            betagetupdate();
        }

        private void betacheckupdate()
        {
            try
            {
                string updateurl = "http://files.theelitepatch.com/version.txt";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(updateurl);
                WebResponse response = request.GetResponse();
                System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream(), System.Text.Encoding.GetEncoding("windows-1252"));
                string update = sr.ReadToEnd();
                int build = Convert.ToInt32(update);
                int thisbuild = The_Elite_Patcher.Properties.Settings.Default.ProgVers;
                if (build > thisbuild)
                {
                    betagetupdate();
                }
                else
                {
                    MessageBox.Show("You have the latest version of The Elite Patcher!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Error connecting to the Elite.So servers! Please try again later. If the problem persists, contact Gigawiz at www.elite.so");
            }
        }
        string installdir = Directory.GetCurrentDirectory() + @"\";
        private Queue<string> _updateUrls = new Queue<string>();
        string filedling2 = null;
        int count2 = 0;
        int done2 = 0;
        private void betagetupdate()
        {
            string newsurl = "http://files.theelitepatch.com/update_news.txt";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(newsurl);
                WebResponse response = request.GetResponse();
                System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream(), System.Text.Encoding.GetEncoding("windows-1252"));
                textBox4.Text = sr.ReadToEnd();
                string updateurl = null;
                if (System.IO.File.Exists(installdir + "update.lock"))
                {
                    updateurl = "http://files.theelitepatch.com/update_filelist.txt";
                }
                else
                {
                    updateurl = "http://files.theelitepatch.com/filelist.txt";
                }
                HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create(updateurl);
                WebResponse response2 = request2.GetResponse();
                System.IO.StreamReader sr2 = new System.IO.StreamReader(response2.GetResponseStream(), System.Text.Encoding.GetEncoding("windows-1252"));
                string test = sr2.ReadToEnd();
                string[] parts = test.Split('\r');
                IEnumerable<string> urls = parts;
                foreach (string url in urls)
                {
                    Match match = Regex.Match(url, @"([A-Za-z0-9\-]+)\.([A-Za-z0-9\-]+)$",
                    RegexOptions.IgnoreCase);

                    // Here we check the Match instance.
                    if (match.Success)
                    {
                        listBox8.Items.Add(url);
                        _updateUrls.Enqueue(url);
                        count2++;
                    }
                }
                //download updates.
                DownloadUpdate(false);

            }
            catch
            {
                textBox4.Text = "Unable to get update news at this time.";
                DownloadUpdate(false);

            }
        }
        string installfolder2 = Directory.GetCurrentDirectory() + @"\Temp\";
        private void DownloadUpdate(bool isPlugin)
        {
            if (!Directory.Exists(Directory.GetCurrentDirectory() + @"\Temp\"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\Temp\");
            }
            if (_updateUrls.Any())
            {
                RepoveDuplicateUpdates();
                WebClient client3 = new WebClient();
                client3.DownloadProgressChanged += client3_DownloadProgressChanged;
                client3.DownloadFileCompleted += client3_DownloadFileCompleted;

                var url = _updateUrls.Dequeue();
                string FileName = url.Substring(url.LastIndexOf("/") + 1,
                            (url.Length - url.LastIndexOf("/") - 1));
                curntupd = url;
                filedling2 = FileName;
                client3.DownloadFileAsync(new Uri(url), Directory.GetCurrentDirectory() + @"\Temp\" + FileName);
                return;
            }
            done2 = count2;
            progressBarX3.Value = 100;
            listBox8.Items.Clear();
            // End of the download
            Process.Start(installdir + @"updater.exe");
            Environment.Exit(0);
        }
        string curntupd = null;
        private void client3_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null) { throw e.Error; }
            if (e.Cancelled) { MessageBox.Show(e.Cancelled.ToString());}
            bool found = false;
            foreach (string LVI1 in listBox7.Items)
            {
                if (LVI1 == curntupd)
                { found = true; }
            }

            if (!found)
            {
                listBox7.Items.Add(curntupd);
            }
            done2++;
            DownloadUpdate(false);
        }

        void client3_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBarX4.Value = e.ProgressPercentage;
            double bytesIn = double.Parse(e.BytesReceived.ToString());
            string stripped = bytesIn.ToString().Split('.')[0];
            label34.Text = filedling2;
            label33.Text = stripped + " Bytes";
            double percentage = ((double)done2 / (double)count2) * (double)100;
            progressBarX3.Value = int.Parse(Math.Truncate(percentage).ToString());
        }
        private void RepoveDuplicateUpdates()
        {
            for (Int16 Row = 0; Row <= listBox8.Items.Count - 2; Row++)
            {
                for (int RowAgain = listBox8.Items.Count - 1; RowAgain >= Row + 1; RowAgain += -1)
                {
                    if (listBox8.Items[Row].ToString() == listBox8.Items[RowAgain].ToString())
                    {
                        listBox8.Items.RemoveAt(RowAgain);
                    }
                }
            }
        }
        static string GetParentUriString(Uri uri)
        {
            return uri.AbsoluteUri.Remove(uri.AbsoluteUri.Length - uri.Segments.Last().Length);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            if (OFD.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ribbonTabItem2.Select();
        }

        private void buttonItem8_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.elite.so/threads/the-elite-patch-beta.193/");
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            OpenFileDialog OHF = new OpenFileDialog();
            OHF.Title = "Select your Hosts File.";
            if (OHF.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    The_Elite_Patcher.Properties.Settings.Default.hosts = OHF.FileName;
                    The_Elite_Patcher.Properties.Settings.Default.custom_hosts = true;
                    The_Elite_Patcher.Properties.Settings.Default.Save();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Try running The Elite Patch as Administrator. " + Environment.NewLine + "Original error: " + ex.Message);
                }
            }
        }

        private void buttonItem10_Click(object sender, EventArgs e)
        {
            The_Elite_Patcher.Properties.Settings.Default.last_news = "";
            The_Elite_Patcher.Properties.Settings.Default.news_dl = true;
            The_Elite_Patcher.Properties.Settings.Default.Save();
        }

        private void buttonItem11_Click(object sender, EventArgs e)
        {
            The_Elite_Patcher.Properties.Settings.Default.last_news = textBox1.Text;
            The_Elite_Patcher.Properties.Settings.Default.news_dl = false;
            The_Elite_Patcher.Properties.Settings.Default.Save();
        }

        private void buttonItem12_Click(object sender, EventArgs e)
        {
            if (buttonItem12.Text == "Revoke Developer Mode")
            {
                The_Elite_Patcher.Properties.Settings.Default.is_developer = false;
                The_Elite_Patcher.Properties.Settings.Default.Save();
                superTabItem2.Visible = false;
                buttonItem12.Text = "Developer Mode";
                ribbonControl1.Refresh();
                MessageBox.Show("Your Access to the developer menu has been revoked!", "Developer Access Revoked!");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to enter developer mode? In most cases this is only used for debugging and should generally not be used. Press 'Yes' to set yourself to developer mode, or press 'No' to return to the main program.", "Are you sure?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    The_Elite_Patcher.Properties.Settings.Default.is_developer = true;
                    The_Elite_Patcher.Properties.Settings.Default.Save();
                    superTabItem2.Visible = true;
                    buttonItem12.Text = "Revoke Developer Mode";
                    ribbonControl1.Refresh();
                    MessageBox.Show("You now have access to The Elite Patch Developer Features!");
                }
                else if (dialogResult == DialogResult.No)
                {
                    The_Elite_Patcher.Properties.Settings.Default.is_developer = false;
                    The_Elite_Patcher.Properties.Settings.Default.Save();
                }
            }
        }

        private void buttonItem13_Click(object sender, EventArgs e)
        {
            MessageBox.Show(NiCoding_Development_Library.File_Operations.Permissions.setPerms(hosts, false));
        }

        private void button34_Click(object sender, EventArgs e)
        {
            File.WriteAllText("md5-" + The_Elite_Patcher.Properties.Settings.Default.ProgVers.ToString() + ".txt", NiCoding_Development_Library.File_Operations.FileChecking.AltGetMd5HashFromFile("The Elite Patcher.exe"));
        }

        private void buttonItem14_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.elite.so/threads/the-elite-patch-beta.193/");
        }
        private void button36_Click(object sender, EventArgs e)
        {
            if (DtlUsrNfoPnl.Visible == true)
            {
                DtlUsrNfoPnl.Visible = false;
                button36.Text = "Detailed Info >>";
            }
            else
            {
                DtlUsrNfoPnl.Visible = true;
                button36.Text = "Detailed Info <<";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NiCoding_Development_Library.Voice_Operations.Text2Speech.Text2SpeechFemale.speakTextAsyncAdultFemale("Welcome to The Elite Patch!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            File.WriteAllText("md5-ndl-" + The_Elite_Patcher.Properties.Settings.Default.ndlvers.ToString() + ".txt", NiCoding_Development_Library.File_Operations.FileChecking.AltGetMd5HashFromFile("ndl.dll"));
        }

        private void updchk_Tick(object sender, EventArgs e)
        {
            betacheckupdateontime();
        }
        private void betacheckupdateontime()
        {
            try
            {
                string updateurl = "http://files.theelitepatch.com/version.txt";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(updateurl);
                WebResponse response = request.GetResponse();
                System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream(), System.Text.Encoding.GetEncoding("windows-1252"));
                string update = sr.ReadToEnd();
                int build = Convert.ToInt32(update);
                int thisbuild = The_Elite_Patcher.Properties.Settings.Default.ProgVers;
                if (build > thisbuild)
                {
                    if (MessageBox.Show("An update was found for your version of The Elite Patch! Would you like to update now?", "Update Available", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        ribbonTabItem2.Select();
                        ribbonControl1.Refresh();
                        if (updchk.Enabled == true)
                        {
                            updchk.Stop();
                        }
                        betagetupdate();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Error connecting to the Elite.So servers! Please try again later. If the problem persists, contact Gigawiz at www.elite.so");
            }
        }
        
        #region switches
        /*
        private void tpbSwitch_ValueChanged(object sender, EventArgs e)
        {
            if (tpbSwitch.Value == true)
            {
                if (proxSrv1.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, TPB);
                }
                else if (proxSrv2.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, TPB2);
                }
                else if (proxSrv3.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, TPB3);
                }
                else if (proxSrv4.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, TPB4);
                }
                timer1.Start();
            }
            else
            {
                NiCoding_Development_Library.File_Operations.WriteFile.removeLine(hosts, removeMe);
                timer2.Start();
            }
        }

        private void switchButton1_ValueChanged(object sender, EventArgs e)
        {
            if (tzeuSw.Value == true)
            {
                if (proxSrv1.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, TORRENTZEU);

                }
                else if (proxSrv2.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, TORRENTZEU2);
                }
                else if (proxSrv3.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, TORRENTZEU3);
                }
                else if (proxSrv4.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, TORRENTZEU4);
                }
                timer1.Start();
            }
            else
            {
                NiCoding_Development_Library.File_Operations.WriteFile.removeLine(hosts, removeMe);
                timer2.Start();
            }
        }

        private void TorrentHoundSw_ValueChanged(object sender, EventArgs e)
        {

            if (TorrentHoundSw.Value == true)
            {
                if (proxSrv1.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, TORRENTHND);
                }
                else if (proxSrv2.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, TORRENTHND2);
                }
                else if (proxSrv3.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, TORRENTHND3);
                }
                else if (proxSrv4.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, TORRENTHND4);
                }
                timer1.Start();
            }
            else
            {
                NiCoding_Development_Library.File_Operations.WriteFile.removeLine(hosts, removeMe);
                timer2.Start();
            }
        }

        private void leetxsw_ValueChanged(object sender, EventArgs e)
        {

            if (leetxsw.Value == true)
            {
                if (proxSrv1.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, LEETX);
                }
                else if (proxSrv2.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, LEETX2);
                }
                else if (proxSrv3.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, LEETX3);
                }
                else if (proxSrv4.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, LEETX4);
                }
                timer1.Start();
            }
            else
            {
                NiCoding_Development_Library.File_Operations.WriteFile.removeLine(hosts, removeMe);
                timer2.Start();
            }
        }

        private void torlocksw_ValueChanged(object sender, EventArgs e)
        {

            if (torlocksw.Value == true)
            {
                if (proxSrv1.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, TORLOCK);
                }
                else if (proxSrv2.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, TORLOCK2);
                }
                else if (proxSrv3.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, TORLOCK3);
                }
                else if (proxSrv4.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, TORLOCK4);
                }
                timer1.Start();
            }
            else
            {
                NiCoding_Development_Library.File_Operations.WriteFile.removeLine(hosts, removeMe);
                timer2.Start();
            }
        }

        private void vertorSw_ValueChanged(object sender, EventArgs e)
        {

            if (vertorSw.Value == true)
            {
                if (proxSrv1.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, VERTOR);
                }
                else if (proxSrv2.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, VERTOR2);
                }
                else if (proxSrv3.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, VERTOR3);
                }
                else if (proxSrv4.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, VERTOR4);
                }
                timer1.Start();
            }
            else
            {
                NiCoding_Development_Library.File_Operations.WriteFile.removeLine(hosts, removeMe);
                timer2.Start();
            }
        }

        private void FenopySw_ValueChanged(object sender, EventArgs e)
        {

            if (FenopySw.Value == true)
            {
                if (proxSrv1.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, FENOPY);
                }
                else if (proxSrv2.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, FENOPY2);
                }
                else if (proxSrv3.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, FENOPY3);
                }
                else if (proxSrv4.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, FENOPY4);
                }
                timer1.Start();
            }
            else
            {
                NiCoding_Development_Library.File_Operations.WriteFile.removeLine(hosts, removeMe);
                timer2.Start();
            }
        }

        private void YBTSw_ValueChanged(object sender, EventArgs e)
        {

            if (YBTSw.Value == true)
            {
                if (proxSrv1.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, YBT);
                }
                else if (proxSrv2.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, YBT2);
                }
                else if (proxSrv3.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, YBT3);
                }
                else if (proxSrv4.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, YBT4);
                }
                timer1.Start();
            }
            else
            {
                NiCoding_Development_Library.File_Operations.WriteFile.removeLine(hosts, removeMe);
                timer2.Start();
            }
        }

        private void MonovaSw_ValueChanged(object sender, EventArgs e)
        {

            if (MonovaSw.Value == true)
            {
                if (proxSrv1.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, MONOVA);
                }
                else if (proxSrv2.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, MONOVA2);
                }
                else if (proxSrv3.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, MONOVA3);
                }
                else if (proxSrv4.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, MONOVA4);
                }
                timer1.Start();
            }
            else
            {
                NiCoding_Development_Library.File_Operations.WriteFile.removeLine(hosts, removeMe);
                timer2.Start();
            }
        }

        private void heetSw_ValueChanged(object sender, EventArgs e)
        {

            if (heetSw.Value == true)
            {
                if (proxSrv1.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, HEET);

                }
                else if (proxSrv2.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, HEET2);
                }
                else if (proxSrv3.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, HEET3);
                }
                else if (proxSrv4.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, HEET4);
                }
                timer1.Start();
            }
            else
            {
                NiCoding_Development_Library.File_Operations.WriteFile.removeLine(hosts, removeMe);
                timer2.Start();
            }
        }

        private void TorReacSw_ValueChanged(object sender, EventArgs e)
        {

            if (TorReacSw.Value == true)
            {
                if (proxSrv1.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, TORRENTREACTOR);
                }
                else if (proxSrv2.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, TORRENTREACTOR2);
                }
                else if (proxSrv3.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, TORRENTREACTOR3);
                }
                else if (proxSrv4.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, TORRENTREACTOR4);
                }
                timer1.Start();
            }
            else
            {
                NiCoding_Development_Library.File_Operations.WriteFile.removeLine(hosts, removeMe);
                timer2.Start();
            }
        }

        private void TorCrzySw_ValueChanged(object sender, EventArgs e)
        {

            if (TorCrzySw.Value == true)
            {
                if (proxSrv1.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, TORRENTCRAZY);
                }
                else if (proxSrv2.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, TORRENTCRAZY2);
                }
                else if (proxSrv3.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, TORRENTCRAZY3);
                }
                else if (proxSrv4.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, TORRENTCRAZY4);
                }
                timer1.Start();
            }
            else
            {
                NiCoding_Development_Library.File_Operations.WriteFile.removeLine(hosts, removeMe);
                timer2.Start();
            }
        }

        private void MinnovaSw_ValueChanged(object sender, EventArgs e)
        {
            if (MinnovaSw.Value == true)
            {
                if (proxSrv1.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, MINNOVA);
                }
                else if (proxSrv2.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, MINNOVA2);
                }
                else if (proxSrv3.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, MINNOVA3);
                }
                else if (proxSrv4.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, MINNOVA4);
                }
                timer1.Start();
            }
            else
            {
                NiCoding_Development_Library.File_Operations.WriteFile.removeLine(hosts, removeMe);
                timer2.Start();
            }
        }

        private void allSw_ValueChanged(object sender, EventArgs e)
        {
            if (allSw.Value == true)
            {
                if (proxSrv1.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, all);
                }
                else if (proxSrv2.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, all2);
                }
                else if (proxSrv3.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, all3);
                }
                else if (proxSrv4.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, all4);
                }
                timer1.Start();
            }
            else
            {
                NiCoding_Development_Library.File_Operations.WriteFile.removeLine(hosts, removeMe);
                timer2.Start();
            }
        }

        private void katPhSw_ValueChanged(object sender, EventArgs e)
        {
            if (katPhSw.Value == true)
            {
                if (proxSrv1.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, KATPH);
                }
                else if (proxSrv2.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, KATPH2);
                }
                else if (proxSrv3.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, KATPH3);
                }
                else if (proxSrv4.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, KATPH4);
                }
                timer1.Start();
            }
            else
            {
                NiCoding_Development_Library.File_Operations.WriteFile.removeLine(hosts, removeMe);
                timer2.Start();
            }
        }

        private void vimeoSw_ValueChanged(object sender, EventArgs e)
        {
            if (vimeoSw.Value == true)
            {
                if (proxSrv1.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, VIMEO);
                }
                else if (proxSrv2.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, VIMEO2);
                }
                else if (proxSrv3.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, VIMEO3);
                }
                else if (proxSrv4.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, VIMEO4);
                }
                timer1.Start();
            }
            else
            {
                NiCoding_Development_Library.File_Operations.WriteFile.removeLine(hosts, removeMe);
                timer2.Start();
            }
        }

        private void dailymotionSw_ValueChanged(object sender, EventArgs e)
        {
            if (dailymotionSw.Value == true)
            {
                if (proxSrv1.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, DAILYMOTION);
                }
                else if (proxSrv2.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, DAILYMOTION2);
                }
                else if (proxSrv3.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, DAILYMOTION3);
                }
                else if (proxSrv4.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, DAILYMOTION4);
                }
                timer1.Start();
            }
            else
            {
                NiCoding_Development_Library.File_Operations.WriteFile.removeLine(hosts, removeMe);
                timer2.Start();
            }
        }

        private void xmarksSw_ValueChanged(object sender, EventArgs e)
        {
            if (xmarksSw.Value == true)
            {
                if (proxSrv1.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, XMARKS);
                }
                else if (proxSrv2.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, XMARKS2);
                }
                else if (proxSrv3.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, XMARKS3);
                }
                else if (proxSrv4.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, XMARKS4);
                }
                timer1.Start();
            }
            else
            {
                NiCoding_Development_Library.File_Operations.WriteFile.removeLine(hosts, removeMe);
                timer2.Start();
            }
        }

        private void pastebinSw_ValueChanged(object sender, EventArgs e)
        {
            if (pastebinSw.Value == true)
            {
                if (proxSrv1.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, PASTEBIN);
                }
                else if (proxSrv2.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, PASTEBIN2);
                }
                else if (proxSrv3.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, PASTEBIN3);
                }
                else if (proxSrv4.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, PASTEBIN4);
                }
                timer1.Start();
            }
            else
            {
                NiCoding_Development_Library.File_Operations.WriteFile.removeLine(hosts, removeMe);
                timer2.Start();
            }
        }

        private void isohntSw_ValueChanged(object sender, EventArgs e)
        {
            if (isohntSw.Value == true)
            {
                if (proxSrv1.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, ISOHUNT);
                }
                else if (proxSrv2.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, ISOHUNT2);
                }
                else if (proxSrv3.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, ISOHUNT3);
                }
                else if (proxSrv4.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, ISOHUNT4);
                }
                timer1.Start();
            }
            else
            {
                NiCoding_Development_Library.File_Operations.WriteFile.removeLine(hosts, removeMe);
                timer2.Start();
            }
        }

        private void torfunkSw_ValueChanged(object sender, EventArgs e)
        {
            if (torfunkSw.Value == true)
            {
                if (proxSrv1.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, TORFUNK);
                }
                else if (proxSrv2.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, TORFUNK2);
                }
                else if (proxSrv3.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, TORFUNK3);
                }
                else if (proxSrv4.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, TORFUNK4);
                }
                timer1.Start();
            }
            else
            {
                NiCoding_Development_Library.File_Operations.WriteFile.removeLine(hosts, removeMe);
                timer2.Start();
            }
        }

        private void extratorSw_ValueChanged(object sender, EventArgs e)
        {
            if (extratorSw.Value == true)
            {
                if (proxSrv1.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, EXTRATOR);
                }
                else if (proxSrv2.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, EXTRATOR2);
                }
                else if (proxSrv3.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, EXTRATOR3);
                }
                else if (proxSrv4.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, EXTRATOR4);
                }
                timer1.Start();
            }
            else
            {
                NiCoding_Development_Library.File_Operations.WriteFile.removeLine(hosts, removeMe);
                timer2.Start();
            }
        }

        private void torrentsnetSw_ValueChanged(object sender, EventArgs e)
        {
            if (torrentsnetSw.Value == true)
            {
                if (proxSrv1.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, TORDOTNET);
                }
                else if (proxSrv2.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, TORDOTNET2);
                }
                else if (proxSrv3.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, TORDOTNET3);
                }
                else if (proxSrv4.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, TORDOTNET4);
                }
                timer1.Start();
            }
            else
            {
                NiCoding_Development_Library.File_Operations.WriteFile.removeLine(hosts, removeMe);
                timer2.Start();
            }
        }

        private void torroomSw_ValueChanged(object sender, EventArgs e)
        {
            if (torroomSw.Value == true)
            {
                if (proxSrv1.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, TORROOM);
                }
                else if (proxSrv2.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, TORROOM2);
                }
                else if (proxSrv3.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, TORROOM3);
                }
                else if (proxSrv4.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, TORROOM4);
                }
                timer1.Start();
            }
            else
            {
                NiCoding_Development_Library.File_Operations.WriteFile.removeLine(hosts, removeMe);
                timer2.Start();
            }
        }

        private void torrootSw_ValueChanged(object sender, EventArgs e)
        {
            if (torrootSw.Value == true)
            {
                if (proxSrv1.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, TORROOT);
                }
                else if (proxSrv2.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, TORROOT2);
                }
                else if (proxSrv3.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, TORROOT3);
                }
                else if (proxSrv4.Checked == true)
                {
                    NiCoding_Development_Library.File_Operations.WriteFile.writeFileFromUrl(hosts, "", true, TORROOT4);
                }
                timer1.Start();
            }
            else
            {
                NiCoding_Development_Library.File_Operations.WriteFile.removeLine(hosts, removeMe);
                timer2.Start();
            }
        }
        */
        #endregion

        private void button3_Click(object sender, EventArgs e)
        {
            genVhostStat.Text = NiCoding_Development_Library.Proxy_Operations.EsoProxy.genVhost(site.Text, subdomain.Text, ip.Value.ToString(), checkBox1.Checked);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                subdomain.Visible = true;
                label37.Visible = true;
            }
            else
            {
                subdomain.Visible = false;
                label37.Visible = false;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.cashwhore.net/whoops-they-never-learn/");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string subj = "";
            string body = "";
            if (radioButton1.Checked == true)
            {
                subj = "Bug Report From " + label79.Text;
                body = "Bug Report From " + label79.Text + Environment.NewLine + "Notes: " + Environment.NewLine + textBox8.Text;
            }
            else if (radioButton2.Checked == true)
            {
                subj = "Suggestion/Feedback From " + label79.Text;
                body = "Suggestion/Feedback From " + label79.Text + Environment.NewLine + "Notes: " + Environment.NewLine + textBox8.Text;
            }
            else if (radioButton3.Checked == true)
            {
                subj = "Proxy Failure Report From " + label79.Text;
                body = "Proxy Failure Report From " + label79.Text + Environment.NewLine + "Notes: " + Environment.NewLine + textBox8.Text;
            }
            else
            {
                subj = "Something from TEP was submitted by " + label79.Text;
                body = "Something from TEP was submitted by " + label79.Text + Environment.NewLine + "Notes: " + Environment.NewLine + textBox8.Text;
            }
            try
            {
                var fromAddress = new MailAddress("proxies.elite.so@gmail.com", textBox4.Text);
                var toAddress = new MailAddress("harmfulmonk@gmail.com", "Gigawiz");
                string fromPassword = CryptorEngine.Decrypt("G4DGJpNcp7A2H0bXen+Ug37zi47ZX622FcFHHRwy7WjVcJTjN6Gm20xurTGMgnQXrrdgSM0BBll+GFYeZcB8fNzfwvNiqWIRkuXSc779Vgs/3U/MaCGKYnUswg2zP1DuMrR+ACogeKE=");
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subj,
                    Body = body
                })
                {
                    smtp.Send(message);
                }
                MessageBox.Show("Submitted Successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Submission Failed! Extended Error: " + ex.Message, "Submission Failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonItem15_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to enable user info caching? Please note that this is in Beta, and could be a little buggy. This will also force update info every 10 days after you enable this!", "Enable User Info Caching?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                genCacheFile(usrfile);
                MessageBox.Show("Enabled!");
            }
        }

        private void buttonItem16_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to disable user info caching? Please note that this will increase the load time of The Elite Patch.", "Disable User Info Caching?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (File.Exists(usrfile))
                {
                    File.Delete(usrfile);
                }
                The_Elite_Patcher.Properties.Settings.Default.usrcachsaved = false;
                The_Elite_Patcher.Properties.Settings.Default.usrcachset = false;
                The_Elite_Patcher.Properties.Settings.Default.usrcachdate = DateTime.Now;
                The_Elite_Patcher.Properties.Settings.Default.Save();
                MessageBox.Show("Disabled!");
            }
        }

        private void buttonItem18_Click(object sender, EventArgs e)
        {
            MessageBox.Show("What is User Info Caching?" + Environment.NewLine + "User Info Caching is an attempt to make The Elite Patch load faster by caching the information about the logged in user. Basically, The Elite Patch will download a copy of your user information, then load from that file instead of downloading from the internet at each boot." + Environment.NewLine + Environment.NewLine + "Is my Information safe?" + Environment.NewLine + "Yes. While the information is downloaded into a text file, we have a custom encryption algorithm that encrypts the file after writing your information. This way, no one can steal your information from The Elite Patch.");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!suggstSiteTxt.Text.Contains("www.") || !suggstSiteTxt.Text.Contains("http://"))
            {
                if (!suggstSiteTxt.Text.Contains("www.") && !suggstSiteTxt.Text.Contains("http://"))
                {
                    suggstSiteTxt.Text = "http://www." + suggstSiteTxt.Text;
                }
                if (!suggstSiteTxt.Text.Contains("http://"))
                {
                    suggstSiteTxt.Text = "http://" + suggstSiteTxt.Text;
                }
                if (!suggstSiteTxt.Text.Contains("www.") && suggstSiteTxt.Text.Contains("http://"))
                {
                    string tmptxt = suggstSiteTxt.Text.Replace("http://","");
                    suggstSiteTxt.Text = "http://www." + suggstSiteTxt.Text;
                }
            }
            if (IsValidHttpUri(suggstSiteTxt.Text))
            {
                suggstSiteTxt.Text = suggstSiteTxt.Text.Replace("http://", "");
                suggstSiteTxt.Text = suggstSiteTxt.Text.Replace("https://", "");
                suggstSiteTxt.Text = suggstSiteTxt.Text.Replace("www.", "");
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://theelitepatch.com/api/siteadder/add.php?url=" + suggstSiteTxt.Text + "&submitter=" + UserNfoPanel.Text + "&ip=" + GetIP());
                WebResponse response = request.GetResponse();
                System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream(), System.Text.Encoding.GetEncoding("windows-1252"));
                string res = sr.ReadToEnd();
                if (res.Contains("1"))
                {
                    MessageBox.Show("Successfully Submitted!");
                }
                else
                {
                    MessageBox.Show("There was an error with your submission!");
                }
            }
        }

        public static bool IsValidHttpUri(string uriString)
        {
            Uri test = null;
            return Uri.TryCreate(uriString, UriKind.Absolute, out test) && test.Scheme == "http";
        }

        private string GetIP()
        {
            WebClient wc = new WebClient();
            string strIP = wc.DownloadString("http://checkip.dyndns.org");
            strIP = (new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b")).Match(strIP).Value;
            wc.Dispose();
            return strIP;
        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            The_Elite_Patcher.Properties.Settings.Default.prxylst = 0;
            The_Elite_Patcher.Properties.Settings.Default.Save();
            MessageBox.Show("The Elite Patch will now use the Default Proxy List!");
        }

        private void buttonItem5_Click(object sender, EventArgs e)
        {
            The_Elite_Patcher.Properties.Settings.Default.prxylst = 1;
            The_Elite_Patcher.Properties.Settings.Default.Save();
            MessageBox.Show("The Elite Patch will now use the First Alt Proxy List!");
        }

        private void buttonItem6_Click(object sender, EventArgs e)
        {
            The_Elite_Patcher.Properties.Settings.Default.prxylst = 2;
            The_Elite_Patcher.Properties.Settings.Default.Save();
            MessageBox.Show("The Elite Patch will now use the Second Alt Proxy List!");
        }

        private void buttonItem19_Click(object sender, EventArgs e)
        {
            The_Elite_Patcher.Properties.Settings.Default.prxylst = 3;
            The_Elite_Patcher.Properties.Settings.Default.Save();
            MessageBox.Show("The Elite Patch will now use the Third Alt Proxy List!");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            updatePlugins();
        }

        private void updatePlugins()
        {
            try
            {
                string updateurl = "http://files.theelitepatch.com/plugin_updates.txt";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(updateurl);
                WebResponse response = request.GetResponse();
                System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream(), System.Text.Encoding.GetEncoding("windows-1252"));
                string update = sr.ReadToEnd();
                if (!String.IsNullOrEmpty(update))
                {
                    betaGetPlgUpd();
                }
                else
                {
                    MessageBox.Show("You have the latest version of all plugins!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Error connecting to the Elite.So servers! Please try again later. If the problem persists, contact Gigawiz at www.elite.so");
            }
        }

        private void betaGetPlgUpd()
        {
            string newsurl = "http://files.theelitepatch.com/update_plugin_news.txt";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(newsurl);
                WebResponse response = request.GetResponse();
                System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream(), System.Text.Encoding.GetEncoding("windows-1252"));
                textBox4.Text = sr.ReadToEnd();
                string updateurl = null;
                if (System.IO.File.Exists(installdir + "update.lock"))
                {
                    updateurl = "http://files.theelitepatch.com/update_plugin_filelist.txt";
                }
                else
                {
                    updateurl = "http://files.theelitepatch.com/plugin_filelist.txt";
                }
                HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create(updateurl);
                WebResponse response2 = request2.GetResponse();
                System.IO.StreamReader sr2 = new System.IO.StreamReader(response2.GetResponseStream(), System.Text.Encoding.GetEncoding("windows-1252"));
                string test = sr2.ReadToEnd();
                MessageBox.Show(test);
                string[] parts = test.Split('\r');
                IEnumerable<string> urls = parts;
                foreach (string url in urls)
                {
                    Match match = Regex.Match(url, @"([A-Za-z0-9\-]+)\.([A-Za-z0-9\-]+)$",
                    RegexOptions.IgnoreCase);

                    // Here we check the Match instance.
                    if (match.Success)
                    {
                        listBox8.Items.Add(url);
                        _updateUrls.Enqueue(url);
                        count2++;
                    }
                }
                //download updates.
                DownloadUpdate(true);

            }
            catch
            {
                textBox4.Text = "Unable to get update news at this time.";
                DownloadUpdate(true);

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            backupHosts();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            restoreOldHosts();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            writeNewHosts();
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Get the currently selected item in the ListBox. 
                string curItem = listBox3.SelectedItem.ToString();
                curItem = curItem.Replace(" ", "_");
                if (curItem != "Click a video to view in the player")
                {
                    string streamPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\";
                    Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("The_Elite_Patcher.Resources." + curItem.ToLower() + ".avi");
                    using (Stream output = new FileStream(streamPath + curItem.ToLower() + ".avi", FileMode.Create))
                    {
                        byte[] buffer = new byte[32 * 1024];
                        int read;

                        while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            output.Write(buffer, 0, read);
                        }
                    }
                    axWindowsMediaPlayer1.URL = streamPath + curItem.ToLower() + ".avi";
                    axWindowsMediaPlayer1.Ctlcontrols.play();
                    if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsMediaEnded)
                    {
                        File.Delete(streamPath + curItem.ToLower() + ".avi");
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
    }
}