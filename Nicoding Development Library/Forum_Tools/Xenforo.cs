// Type: NiCoding_Development_Library.Forum_Tools.Xenforo
// Assembly: NDL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D03E96A6-C992-4E9A-BE57-D6DDB9E706CB
// Assembly location: C:\Users\Gigawiz\Desktop\NDL.dll

using System;
using System.IO;
using System.Net;
using System.Text;

namespace NiCoding_Development_Library.Forum_Tools
{
  public class Xenforo
  {

      public static string register(string site, string username, string password, string email)
      {
          string registerurl = "http://"+site+"/api.php?action=register&hash=b8e7ae12510bdfb110bd&username="+username+"&password="+password+"&email="+email;
          try
          {
              string ret = "";
              HttpWebRequest request = (HttpWebRequest)WebRequest.Create(registerurl);
              WebResponse response = request.GetResponse();
              System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream(), System.Text.Encoding.GetEncoding("windows-1252"));
              string res = sr.ReadToEnd();
              if (res.Contains("Argument: \"password\", is empty\\/missing a value"))
              {
                  ret = "Password empty!";
              }
              else if (res.Contains("Argument: \"email\", is empty\\/missing a value"))
              {
                  ret = "Email Empty!";
              }
              else if (res.Contains("Argument: \"username\", is empty\\/missing a value"))
              {
                  ret = "Username Empty!";
              }
              else if (res.Contains("User already exists\""))
              {
                  ret = "User Exists!";
              }
              else
              {
                  ret = "Success!";
              }
              return ret;
          }
          catch (Exception ex)
          {
              return ex.Message;
          }
      }
    public static string login(string site, string username, string password)
    {
      try
      {
        string str1 = new StreamReader(WebRequest.Create("http://"+site+"/api.php?action=authenticate&username=" + username + "&password=" + password).GetResponse().GetResponseStream(), Encoding.GetEncoding("windows-1252")).ReadToEnd();
        string str2;
        if (str1.Contains("\"hash\":\""))
        {
          string str3 = str1.Remove(0, 9);
          str2 = str3.Substring(0, str3.Length - 2);
        }
        else
          str2 = !str1.Contains("Authentication error:") ? (!str1.Contains("Argument: 'password', is empty") ? "Unable to login at this time" : "Please enter your password!") : "Invalid username or password!";
        return str2;
      }
      catch (Exception ex)
      {
        return ex.Message;
      }
    }

    public static string getAvatar(string site, string username, string hash)
    {
      try
      {
        string str = new StreamReader(WebRequest.Create("http://"+site+"/api.php?action=getAvatar&value=" + username + "&hash=" + hash).GetResponse().GetResponseStream(), Encoding.GetEncoding("windows-1252")).ReadToEnd().Replace("\\", "").Remove(0, 11);
        return str.Substring(0, str.Length - 2);
      }
      catch (Exception ex)
      {
        return ex.Message;
      }
    }

    public static string getUserId(string site, string user)
    {
      try
      {
        string str = new StreamReader(WebRequest.Create("http://"+site+"/api.php?action=getUser&value=" + user + "&hash=b8e7ae12510bdfb110bd").GetResponse().GetResponseStream(), Encoding.GetEncoding("windows-1252")).ReadToEnd().Remove(0, 11);
        int length = str.IndexOf(",");
        if (length > 0)
          str = str.Substring(0, length);
        return str;
      }
      catch (Exception ex)
      {
        return ex.Message;
      }
    }

    public static string getUserEmail(string site, string user)
    {
      try
      {
        string[] strArray = new StreamReader(WebRequest.Create("http://"+site+"/api.php?action=getUser&value=" + user + "&hash=b8e7ae12510bdfb110bd").GetResponse().GetResponseStream(), Encoding.GetEncoding("windows-1252")).ReadToEnd().Split(new char[1]
        {
          ','
        });
        string str1 = "";
        foreach (string str2 in strArray)
        {
          if (str2.Contains("email"))
            str1 = str2;
        }
        string str3 = str1.Remove(0, 9);
        return str3.Substring(0, str3.Length - 1);
      }
      catch (Exception ex)
      {
        return ex.Message;
      }
    }

    public static string getUserGender(string site, string user)
    {
      try
      {
        string[] strArray = new StreamReader(WebRequest.Create("http://"+site+"/api.php?action=getUser&value=" + user + "&hash=b8e7ae12510bdfb110bd").GetResponse().GetResponseStream(), Encoding.GetEncoding("windows-1252")).ReadToEnd().Split(new char[1]
        {
          ','
        });
        string str1 = "";
        foreach (string str2 in strArray)
        {
          if (str2.Contains("gender"))
            str1 = str2;
        }
        string str3 = str1.Remove(0, 10);
        return str3.Substring(0, str3.Length - 1);
      }
      catch (Exception ex)
      {
        return ex.Message;
      }
    }

    public static string getUserCustomTitle(string site, string user)
    {
      try
      {
        string[] strArray = new StreamReader(WebRequest.Create("http://"+site+"/api.php?action=getUser&value=" + user + "&hash=b8e7ae12510bdfb110bd").GetResponse().GetResponseStream(), Encoding.GetEncoding("windows-1252")).ReadToEnd().Split(new char[1]
        {
          ','
        });
        string str1 = "";
        foreach (string str2 in strArray)
        {
          if (str2.Contains("custom_title"))
            str1 = str2;
        }
        string str3 = str1.Remove(0, 16);
        return str3.Substring(0, str3.Length - 1);
      }
      catch (Exception ex)
      {
        return ex.Message;
      }
    }

    public static string getUserTimeZone(string site, string user)
    {
      try
      {
        string[] strArray = new StreamReader(WebRequest.Create("http://"+site+"/api.php?action=getUser&value=" + user + "&hash=b8e7ae12510bdfb110bd").GetResponse().GetResponseStream(), Encoding.GetEncoding("windows-1252")).ReadToEnd().Split(new char[1]
        {
          ','
        });
        string str1 = "";
        foreach (string str2 in strArray)
        {
          if (str2.Contains("timezone"))
            str1 = str2;
        }
        string str3 = str1.Remove(0, 12).Replace("\\", "").Replace("_", " ");
        return str3.Substring(0, str3.Length - 1);
      }
      catch (Exception ex)
      {
        return ex.Message;
      }
    }

    public static string getUserVisibility(string site, string user)
    {
      try
      {
        string[] strArray = new StreamReader(WebRequest.Create("http://"+site+"/api.php?action=getUser&value=" + user + "&hash=b8e7ae12510bdfb110bd").GetResponse().GetResponseStream(), Encoding.GetEncoding("windows-1252")).ReadToEnd().Split(new char[1]
        {
          ','
        });
        string str1 = "";
        foreach (string str2 in strArray)
        {
          if (str2.Contains("visible"))
            str1 = str2;
        }
        return !(str1.Remove(0, 2) == "1") ? "No" : "Yes";
      }
      catch (Exception ex)
      {
        return ex.Message;
      }
    }

    public static string getUserGroup(string site, string user)
    {
      try
      {
        string[] strArray = new StreamReader(WebRequest.Create("http://"+site+"/api.php?action=getUser&value=" + user + "&hash=b8e7ae12510bdfb110bd").GetResponse().GetResponseStream(), Encoding.GetEncoding("windows-1252")).ReadToEnd().Split(new char[1]
        {
          ','
        });
        string str1 = "";
        foreach (string str2 in strArray)
        {
          if (str2.Contains("custom_title"))
            str1 = str2;
        }
        string str3 = str1.Remove(0, 16);
        return str3.Substring(0, str3.Length - 1);
      }
      catch (Exception ex)
      {
        return ex.Message;
      }
    }

    public static string getUserSecGroup(string site, string user)
    {
      try
      {
        string[] strArray = new StreamReader(WebRequest.Create("http://"+site+"/api.php?action=getUser&value=" + user + "&hash=b8e7ae12510bdfb110bd").GetResponse().GetResponseStream(), Encoding.GetEncoding("windows-1252")).ReadToEnd().Split(new char[1]
        {
          ','
        });
        string str1 = "";
        foreach (string str2 in strArray)
        {
          if (str2.Contains("custom_title"))
            str1 = str2;
        }
        string str3 = str1.Remove(0, 16);
        return str3.Substring(0, str3.Length - 1);
      }
      catch (Exception ex)
      {
        return ex.Message;
      }
    }

    public static string getUserMsgCount(string site, string user)
    {
      try
      {
        string[] strArray = new StreamReader(WebRequest.Create("http://"+site+"/api.php?action=getUser&value=" + user + "&hash=b8e7ae12510bdfb110bd").GetResponse().GetResponseStream(), Encoding.GetEncoding("windows-1252")).ReadToEnd().Split(new char[1]
        {
          ','
        });
        string str1 = "";
        foreach (string str2 in strArray)
        {
          if (str2.Contains("message_count"))
            str1 = str2;
        }
        return str1.Remove(0, 16);
      }
      catch (Exception ex)
      {
        return ex.Message;
      }
    }

    public static string getUserUnreadConvos(string site, string user)
    {
      try
      {
        string[] strArray = new StreamReader(WebRequest.Create("http://"+site+"/api.php?action=getUser&value=" + user + "&hash=b8e7ae12510bdfb110bd").GetResponse().GetResponseStream(), Encoding.GetEncoding("windows-1252")).ReadToEnd().Split(new char[1]
        {
          ','
        });
        string str1 = "";
        foreach (string str2 in strArray)
        {
          if (str2.Contains("conversations_unread"))
            str1 = str2;
        }
        return str1.Remove(0, 23);
      }
      catch (Exception ex)
      {
        return ex.Message;
      }
    }

    public static string getUserRegDate(string site, string user)
    {
      try
      {
        string[] strArray = new StreamReader(WebRequest.Create("http://"+site+"/api.php?action=getUser&value=" + user + "&hash=b8e7ae12510bdfb110bd").GetResponse().GetResponseStream(), Encoding.GetEncoding("windows-1252")).ReadToEnd().Split(new char[1]
        {
          ','
        });
        string str1 = "";
        foreach (string str2 in strArray)
        {
          if (str2.Contains("register_date"))
            str1 = str2;
        }
        DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(Convert.ToDouble(str1.Remove(0, 16)));
        dateTime = dateTime.ToLocalTime();
        string str3 = dateTime.ToString();
        return str3.Substring(0, str3.Length - 11);
      }
      catch (Exception ex)
      {
        return ex.Message;
      }
    }

    public static string getUserLastActiveDate(string site, string user)
    {
      try
      {
        string[] strArray = new StreamReader(WebRequest.Create("http://"+site+"/api.php?action=getUser&value=" + user + "&hash=b8e7ae12510bdfb110bd").GetResponse().GetResponseStream(), Encoding.GetEncoding("windows-1252")).ReadToEnd().Split(new char[1]
        {
          ','
        });
        string str1 = "";
        foreach (string str2 in strArray)
        {
          if (str2.Contains("last_activity"))
            str1 = str2;
        }
        DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(Convert.ToDouble(str1.Remove(0, 16)));
        dateTime = dateTime.ToLocalTime();
        return dateTime.ToString();
      }
      catch (Exception ex)
      {
        return ex.Message;
      }
    }

    public static string getUserTrophyPoints(string site, string user)
    {
      try
      {
        string[] strArray = new StreamReader(WebRequest.Create("http://"+site+"/api.php?action=getUser&value=" + user + "&hash=b8e7ae12510bdfb110bd").GetResponse().GetResponseStream(), Encoding.GetEncoding("windows-1252")).ReadToEnd().Split(new char[1]
        {
          ','
        });
        string str1 = "";
        foreach (string str2 in strArray)
        {
          if (str2.Contains("trophy_points"))
            str1 = str2;
        }
        return str1.Remove(0, 16);
      }
      catch (Exception ex)
      {
        return ex.Message;
      }
    }

    public static string getUserUnreadAlerts(string site, string user)
    {
      try
      {
        string[] strArray = new StreamReader(WebRequest.Create("http://"+site+"/api.php?action=getUser&value=" + user + "&hash=b8e7ae12510bdfb110bd").GetResponse().GetResponseStream(), Encoding.GetEncoding("windows-1252")).ReadToEnd().Split(new char[1]
        {
          ','
        });
        string str1 = "";
        foreach (string str2 in strArray)
        {
          if (str2.Contains("alerts_unread"))
            str1 = str2;
        }
        return str1.Remove(0, 16);
      }
      catch (Exception ex)
      {
        return ex.Message;
      }
    }

    public static string getUserAvitarDate(string site, string user)
    {
      try
      {
        string[] strArray = new StreamReader(WebRequest.Create("http://"+site+"/api.php?action=getUser&value=" + user + "&hash=b8e7ae12510bdfb110bd").GetResponse().GetResponseStream(), Encoding.GetEncoding("windows-1252")).ReadToEnd().Split(new char[1]
        {
          ','
        });
        string str1 = "";
        foreach (string str2 in strArray)
        {
          if (str2.Contains("avatar_date"))
            str1 = str2;
        }
        DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(Convert.ToDouble(str1.Remove(0, 14)));
        dateTime = dateTime.ToLocalTime();
        return dateTime.ToString();
      }
      catch (Exception ex)
      {
        return ex.Message;
      }
    }

    public static int getUserAvatarWid(string site, string user)
    {
      try
      {
        string[] strArray = new StreamReader(WebRequest.Create("http://"+site+"/api.php?action=getUser&value=" + user + "&hash=b8e7ae12510bdfb110bd").GetResponse().GetResponseStream(), Encoding.GetEncoding("windows-1252")).ReadToEnd().Split(new char[1]
        {
          ','
        });
        string str1 = "";
        foreach (string str2 in strArray)
        {
          if (str2.Contains("avatar_width"))
            str1 = str2;
        }
        return Convert.ToInt32(str1.Remove(0, 15));
      }
      catch
      {
        return 0;
      }
    }

    public static int getUserAvatarHei(string site, string user)
    {
      try
      {
        string[] strArray = new StreamReader(WebRequest.Create("http://"+site+"/api.php?action=getUser&value=" + user + "&hash=b8e7ae12510bdfb110bd").GetResponse().GetResponseStream(), Encoding.GetEncoding("windows-1252")).ReadToEnd().Split(new char[1]
        {
          ','
        });
        string str1 = "";
        foreach (string str2 in strArray)
        {
          if (str2.Contains("avatar_height"))
            str1 = str2;
        }
        return Convert.ToInt32(str1.Remove(0, 16));
      }
      catch
      {
        return 0;
      }
    }

    public static bool getUserState(string site, string user)
    {
      try
      {
        string[] strArray = new StreamReader(WebRequest.Create("http://"+site+"/api.php?action=getUser&value=" + user + "&hash=b8e7ae12510bdfb110bd").GetResponse().GetResponseStream(), Encoding.GetEncoding("windows-1252")).ReadToEnd().Split(new char[1]
        {
          ','
        });
        string str1 = "";
        foreach (string str2 in strArray)
        {
          if (str2.Contains("user_state"))
            str1 = str2;
        }
        string str3 = str1.Remove(0, 14);
        return str3.Substring(0, str3.Length - 1) == "valid";
      }
      catch
      {
        return false;
      }
    }

    public static bool isMod(string site, string user)
    {
      try
      {
        string[] strArray = new StreamReader(WebRequest.Create("http://"+site+"/api.php?action=getUser&value=" + user + "&hash=b8e7ae12510bdfb110bd").GetResponse().GetResponseStream(), Encoding.GetEncoding("windows-1252")).ReadToEnd().Split(new char[1]
        {
          ','
        });
        string str1 = "";
        foreach (string str2 in strArray)
        {
          if (str2.Contains("is_moderator"))
            str1 = str2;
        }
        return str1.Remove(0, 15) == "1";
      }
      catch
      {
        return false;
      }
    }

    public static bool isAdmin(string site, string user)
    {
      try
      {
        string[] strArray = new StreamReader(WebRequest.Create("http://"+site+"/api.php?action=getUser&value=" + user + "&hash=b8e7ae12510bdfb110bd").GetResponse().GetResponseStream(), Encoding.GetEncoding("windows-1252")).ReadToEnd().Split(new char[1]
        {
          ','
        });
        string str1 = "";
        foreach (string str2 in strArray)
        {
          if (str2.Contains("is_admin"))
            str1 = str2;
        }
        return str1.Remove(0, 11) == "1";
      }
      catch
      {
        return false;
      }
    }

    public static bool isBanned(string site, string user)
    {
      try
      {
        string[] strArray = new StreamReader(WebRequest.Create("http://"+site+"/api.php?action=getUser&value=" + user + "&hash=b8e7ae12510bdfb110bd").GetResponse().GetResponseStream(), Encoding.GetEncoding("windows-1252")).ReadToEnd().Split(new char[1]
        {
          ','
        });
        string str1 = "";
        foreach (string str2 in strArray)
        {
          if (str2.Contains("is_banned"))
            str1 = str2;
        }
        return str1.Remove(0, 12) == "1";
      }
      catch
      {
        return false;
      }
    }

    public static int getUserLikeCount(string site, string user)
    {
      try
      {
        string[] strArray = new StreamReader(WebRequest.Create("http://"+site+"/api.php?action=getUser&value=" + user + "&hash=b8e7ae12510bdfb110bd").GetResponse().GetResponseStream(), Encoding.GetEncoding("windows-1252")).ReadToEnd().Split(new char[1]
        {
          ','
        });
        string str1 = "";
        foreach (string str2 in strArray)
        {
          if (str2.Contains("like_count"))
            str1 = str2;
        }
        return Convert.ToInt32(str1.Remove(0, 13));
      }
      catch
      {
        return 0;
      }
    }

    public static int getUserWarningPoints(string site, string user)
    {
      try
      {
        string[] strArray = new StreamReader(WebRequest.Create("http://"+site+"/api.php?action=getUser&value=" + user + "&hash=b8e7ae12510bdfb110bd").GetResponse().GetResponseStream(), Encoding.GetEncoding("windows-1252")).ReadToEnd().Split(new char[1]
        {
          ','
        });
        string str1 = "";
        foreach (string str2 in strArray)
        {
          if (str2.Contains("warning_points"))
            str1 = str2;
        }
        return Convert.ToInt32(str1.Remove(0, 17));
      }
      catch
      {
        return 0;
      }
    }

    public static int getUserFriendCount(string site, string user)
    {
      try
      {
        string[] strArray = new StreamReader(WebRequest.Create("http://"+site+"/api.php?action=getUser&value=" + user + "&hash=b8e7ae12510bdfb110bd").GetResponse().GetResponseStream(), Encoding.GetEncoding("windows-1252")).ReadToEnd().Split(new char[1]
        {
          ','
        });
        string str1 = "";
        foreach (string str2 in strArray)
        {
          if (str2.Contains("friend_count"))
            str1 = str2;
        }
        return Convert.ToInt32(str1.Remove(0, 15));
      }
      catch
      {
        return 0;
      }
    }

    public static int getUserPersonalFriendCount(string site, string user)
    {
      try
      {
        string[] strArray = new StreamReader(WebRequest.Create("http://"+site+"/api.php?action=getUser&value=" + user + "&hash=b8e7ae12510bdfb110bd").GetResponse().GetResponseStream(), Encoding.GetEncoding("windows-1252")).ReadToEnd().Split(new char[1]
        {
          ','
        });
        string str1 = "";
        foreach (string str2 in strArray)
        {
          if (str2.Contains("personal_friend_count"))
            str1 = str2;
        }
        return Convert.ToInt32(str1.Remove(0, 24));
      }
      catch
      {
        return 0;
      }
    }

    public static string getUserMood(string site, string user)
    {
      return "1";
    }

    public static int getUserBankMoney(string site, string user)
    {
      try
      {
        string[] strArray = new StreamReader(WebRequest.Create("http://"+site+"/api.php?action=getUser&value=" + user + "&hash=b8e7ae12510bdfb110bd").GetResponse().GetResponseStream(), Encoding.GetEncoding("windows-1252")).ReadToEnd().Split(new char[1]
        {
          ','
        });
        string str1 = "";
        foreach (string str2 in strArray)
        {
          if (str2.Contains("bdbank_money"))
            str1 = str2;
        }
        return Convert.ToInt32(str1.Remove(0, 15));
      }
      catch
      {
        return 0;
      }
    }

    public static int getUserFreeInvites(string site, string user)
    {
      try
      {
        string[] strArray = new StreamReader(WebRequest.Create("http://"+site+"/api.php?action=getUser&value=" + user + "&hash=b8e7ae12510bdfb110bd").GetResponse().GetResponseStream(), Encoding.GetEncoding("windows-1252")).ReadToEnd().Split(new char[1]
        {
          ','
        });
        string str1 = "";
        foreach (string str2 in strArray)
        {
          if (str2.Contains("ragtek_free_invites"))
            str1 = str2;
        }
        return Convert.ToInt32(str1.Remove(0, 22));
      }
      catch
      {
        return 0;
      }
    }

    public static int getUserReferrerId(string site, string user)
    {
      try
      {
        string[] strArray = new StreamReader(WebRequest.Create("http://"+site+"/api.php?action=getUser&value=" + user + "&hash=b8e7ae12510bdfb110bd").GetResponse().GetResponseStream(), Encoding.GetEncoding("windows-1252")).ReadToEnd().Split(new char[1]
        {
          ','
        });
        string str1 = "";
        foreach (string str2 in strArray)
        {
          if (str2.Contains("ragtek_referrer_userid"))
            str1 = str2;
        }
        return Convert.ToInt32(str1.Remove(0, 25));
      }
      catch
      {
        return 0;
      }
    }
  }
}
