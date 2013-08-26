// Type: NiCoding_Development_Library.Forum_Tools.IPB
// Assembly: NDL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D03E96A6-C992-4E9A-BE57-D6DDB9E706CB
// Assembly location: C:\Users\Gigawiz\Desktop\NDL.dll

using System;
using System.IO;
using System.Net;
using System.Text;

namespace NiCoding_Development_Library.Forum_Tools
{
  public class IPB
  {
    public static bool login(string username, string pass)
    {
      try
      {
        return new StreamReader(WebRequest.Create("http://adminspot.net/api.php?name=" + username + "&password=" + pass).GetResponse().GetResponseStream(), Encoding.GetEncoding("windows-1252")).ReadToEnd().Contains("success");
      }
      catch (Exception ex)
      {
        return false;
      }
    }
  }
}
