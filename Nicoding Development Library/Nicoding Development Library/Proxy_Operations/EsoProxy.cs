// Type: NiCoding_Development_Library.Proxy_Operations.EsoProxy
// Assembly: NDL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D03E96A6-C992-4E9A-BE57-D6DDB9E706CB
// Assembly location: C:\Users\Gigawiz\Desktop\NDL.dll

using System;
using System.Net;

namespace NiCoding_Development_Library.Proxy_Operations
{
  public class EsoProxy
  {
    public static string genVhost(string site, string subdomain, string ip, bool isSub)
    {
      site = site.Replace("www.", "");
      site = site.Replace("http://", "");
      subdomain = subdomain.Replace("http://", "");
      subdomain = subdomain.Replace("www.", "");
      string path = !isSub ? site : subdomain;
      System.IO.File.AppendAllText(path, "server {" + Environment.NewLine);
      System.IO.File.AppendAllText(path, "listen " + ip + ":80;" + Environment.NewLine);
      if (!string.IsNullOrEmpty(subdomain))
        System.IO.File.AppendAllText(path, "server_name " + subdomain + " www." + subdomain + " " + site + " www." + site + ";" + Environment.NewLine);
      else
        System.IO.File.AppendAllText(path, "server_name  " + site + " www." + site + ";" + Environment.NewLine);
      System.IO.File.AppendAllText(path, "location / {" + Environment.NewLine);
      System.IO.File.AppendAllText(path, "proxy_pass             http://" + site + "/;" + Environment.NewLine);
      System.IO.File.AppendAllText(path, "proxy_set_header       Host " + site + ";" + Environment.NewLine);
      System.IO.File.AppendAllText(path, "}" + Environment.NewLine);
      System.IO.File.AppendAllText(path, "}" + Environment.NewLine);
      return "Generated file: " + path;
    }

    public static bool checkTpb()
    {
      try
      {
        string html = "";
        Uri address = new Uri("http://thepiratebay.elite.so");
        WebClient webClient = new WebClient();
        webClient.DownloadStringCompleted += (DownloadStringCompletedEventHandler) ((s, e) => html = e.Result);
        webClient.DownloadStringAsync(address);
        return html.Contains("Search The Pirate Bay");
      }
      catch
      {
        return false;
      }
    }

    public static bool checkTzeu()
    {
      try
      {
        string html = "";
        Uri address = new Uri("http://torrentz.elite.so");
        WebClient webClient = new WebClient();
        webClient.DownloadStringCompleted += (DownloadStringCompletedEventHandler) ((s, e) => html = e.Result);
        webClient.DownloadStringAsync(address);
        return html.Contains("Torrentz Search");
      }
      catch
      {
        return false;
      }
    }

    public static bool checkFenopy()
    {
      try
      {
        string html = "";
        Uri address = new Uri("http://fenopy.elite.so");
        WebClient webClient = new WebClient();
        webClient.DownloadStringCompleted += (DownloadStringCompletedEventHandler) ((s, e) => html = e.Result);
        webClient.DownloadStringAsync(address);
        return html.Contains("Fenopy Top Torrents");
      }
      catch
      {
        return false;
      }
    }

    public static bool checkHeet()
    {
      try
      {
        Uri address = new Uri("http://h33t.elite.so");
        string html = "";
        WebClient webClient = new WebClient();
        webClient.DownloadStringCompleted += (DownloadStringCompletedEventHandler) ((s, e) => html = e.Result);
        webClient.DownloadStringAsync(address);
        return html.Contains("Torrent search");
      }
      catch
      {
        return false;
      }
    }

    public static bool checkLeetx()
    {
      try
      {
        Uri address = new Uri("http://1337x.elite.so");
        string html = "";
        WebClient webClient = new WebClient();
        webClient.DownloadStringCompleted += (DownloadStringCompletedEventHandler) ((s, e) => html = e.Result);
        webClient.DownloadStringAsync(address);
        return html.Contains("search for torrents");
      }
      catch
      {
        return false;
      }
    }

    public static bool checkMinnova()
    {
      try
      {
        Uri address = new Uri("http://mininova.elite.so");
        string html = "";
        WebClient webClient = new WebClient();
        webClient.DownloadStringCompleted += (DownloadStringCompletedEventHandler) ((s, e) => html = e.Result);
        webClient.DownloadStringAsync(address);
        return html.Contains("search for torrents");
      }
      catch
      {
        return false;
      }
    }

    public static bool checkMonova()
    {
      try
      {
        Uri address = new Uri("http://monova.elite.so");
        string str = "";
        using (WebClient webClient = new WebClient())
          str = webClient.DownloadString(address);
        return str.Contains("monova.org NEWEST TORRENTS");
      }
      catch
      {
        return false;
      }
    }

    public static bool checkTorrentcrazy()
    {
      try
      {
        Uri address = new Uri("http://torrentcrazy.elite.so");
        string str = "";
        using (WebClient webClient = new WebClient())
          str = webClient.DownloadString(address);
        return str.Contains("Torrent Crazy - the simplest torrent site");
      }
      catch
      {
        return false;
      }
    }

    public static bool checkTorrentReactor()
    {
      try
      {
        Uri address = new Uri("http://torrentreactor.elite.so");
        string str = "";
        using (WebClient webClient = new WebClient())
          str = webClient.DownloadString(address);
        return str.Contains("Torrent Downloads");
      }
      catch
      {
        return false;
      }
    }

    public static bool checkTorrentHound()
    {
      try
      {
        Uri address = new Uri("http://torrenthound.elite.so");
        string str = "";
        using (WebClient webClient = new WebClient())
          str = webClient.DownloadString(address);
        return str.Contains("upload a torrent");
      }
      catch
      {
        return false;
      }
    }

    public static bool checkTorrentLock()
    {
      try
      {
        Uri address = new Uri("http://torlock.elite.so");
        string str = "";
        using (WebClient webClient = new WebClient())
          str = webClient.DownloadString(address);
        return str.Contains("TorLock is a fast BitTorrent search engine");
      }
      catch
      {
        return false;
      }
    }

    public static bool checkVertor()
    {
      try
      {
        Uri address = new Uri("http://vertor.elite.so");
        string str = "";
        using (WebClient webClient = new WebClient())
          str = webClient.DownloadString(address);
        return str.Contains("Vertor.com. Verified torrents.");
      }
      catch
      {
        return false;
      }
    }

    public static bool checkYbt()
    {
      try
      {
        Uri address = new Uri("http://yourbittorrent.elite.so");
        string str = "";
        using (WebClient webClient = new WebClient())
          str = webClient.DownloadString(address);
        return str.Contains("Share your Torrents");
      }
      catch
      {
        return false;
      }
    }

    public static bool checkKat()
    {
      try
      {
        Uri address = new Uri("http://kat.elite.so");
        string str = "";
        using (WebClient webClient = new WebClient())
          str = webClient.DownloadString(address);
        return str.Contains("KickassTorrents Torrent Search");
      }
      catch
      {
        return false;
      }
    }

    public static bool checkVimeo()
    {
      try
      {
        Uri address = new Uri("http://vimeo.elite.so");
        string str = "";
        using (WebClient webClient = new WebClient())
          str = webClient.DownloadString(address);
        return str.Contains("Copyright");
      }
      catch
      {
        return false;
      }
    }

    public static bool checkDailymotion()
    {
      try
      {
        Uri address = new Uri("http://dailymotion.elite.so");
        string str = "";
        using (WebClient webClient = new WebClient())
          str = webClient.DownloadString(address);
        return str.Contains("Copyright");
      }
      catch
      {
        return false;
      }
    }

    public static bool checkXmarks()
    {
      try
      {
        Uri address = new Uri("http://xmarks.elite.so");
        string str = "";
        using (WebClient webClient = new WebClient())
          str = webClient.DownloadString(address);
        return str.Contains("Copyright");
      }
      catch
      {
        return false;
      }
    }

    public static bool checkPastebin()
    {
      try
      {
        Uri address = new Uri("http://pastebin.elite.so");
        string str = "";
        using (WebClient webClient = new WebClient())
          str = webClient.DownloadString(address);
        return str.Contains("Copyright");
      }
      catch
      {
        return false;
      }
    }

    public static bool checkIsohunt()
    {
      try
      {
        Uri address = new Uri("http://isohunt.elite.so");
        string str = "";
        using (WebClient webClient = new WebClient())
          str = webClient.DownloadString(address);
        return str.Contains("Bit Torrent search engine");
      }
      catch
      {
        return false;
      }
    }

    public static bool checkTorrentFunk()
    {
      try
      {
        Uri address = new Uri("http://torrentfunk.elite.so");
        string str = "";
        using (WebClient webClient = new WebClient())
          str = webClient.DownloadString(address);
        return str.Contains("Bit Torrent search engine");
      }
      catch
      {
        return false;
      }
    }

    public static bool checkExtratorrent()
    {
      try
      {
        Uri address = new Uri("http://extratorrent.elite.so");
        string str = "";
        using (WebClient webClient = new WebClient())
          str = webClient.DownloadString(address);
        return str.Contains("Bit Torrent search engine");
      }
      catch
      {
        return false;
      }
    }

    public static bool checkTorrentsdotnet()
    {
      try
      {
        Uri address = new Uri("http://torrents.elite.so");
        string str = "";
        using (WebClient webClient = new WebClient())
          str = webClient.DownloadString(address);
        return str.Contains("Bit Torrent search engine");
      }
      catch
      {
        return false;
      }
    }

    public static bool checkTorrentroom()
    {
      try
      {
        Uri address = new Uri("http://torrentroom.elite.so");
        string str = "";
        using (WebClient webClient = new WebClient())
          str = webClient.DownloadString(address);
        return str.Contains("Bit Torrent search engine");
      }
      catch
      {
        return false;
      }
    }

    public static bool checkTorrentroot()
    {
      try
      {
        Uri address = new Uri("http://torrentroot.elite.so");
        string str = "";
        using (WebClient webClient = new WebClient())
          str = webClient.DownloadString(address);
        return str.Contains("Bit Torrent search engine");
      }
      catch
      {
        return false;
      }
    }
  }
}
