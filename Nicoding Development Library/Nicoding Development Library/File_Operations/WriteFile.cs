// Type: NiCoding_Development_Library.File_Operations.WriteFile
// Assembly: NDL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D03E96A6-C992-4E9A-BE57-D6DDB9E706CB
// Assembly location: C:\Users\Gigawiz\Desktop\NDL.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace NiCoding_Development_Library.File_Operations
{
  public class WriteFile
  {
    public static void cleanHosts(string file)
    {
      System.IO.File.WriteAllText(file, "# Copyright (c) 1993-2009 Microsoft Corp." + Environment.NewLine + "#" + Environment.NewLine + "# This is a sample HOSTS file used by Microsoft TCP/IP for Windows." + Environment.NewLine + "#" + Environment.NewLine + "# This file contains the mappings of IP addresses to host names. Each" + Environment.NewLine + "# entry should be kept on an individual line. The IP address should" + Environment.NewLine + "# be placed in the first column followed by the corresponding host name." + Environment.NewLine + "# The IP address and the host name should be separated by at least one" + Environment.NewLine + "# space." + Environment.NewLine + "#" + Environment.NewLine + "# Additionally, comments (such as these) may be inserted on individual" + Environment.NewLine + "# lines or following the machine name denoted by a '#' symbol." + Environment.NewLine + "#" + Environment.NewLine + "# For example:" + Environment.NewLine + "#" + Environment.NewLine + "#      102.54.94.97     rhino.acme.com          # source server" + Environment.NewLine + "#       38.25.63.10     x.acme.com              # x client host" + Environment.NewLine + "# localhost name resolution is handled within DNS itself." + Environment.NewLine + "#\t127.0.0.1       localhost" + Environment.NewLine + "#\t::1             localhost");
    }

    public static void appendFile(string file, string text)
    {
      System.IO.File.AppendAllText(file, text);
    }

    public static void newFile1Line(string file, string text)
    {
      StreamWriter streamWriter = new StreamWriter(file);
      streamWriter.WriteLine(text);
      streamWriter.Close();
    }

    public static int newFileMLine(string file, Array text, bool newline)
    {
      int num = 0;
      StreamWriter streamWriter = new StreamWriter(file);
      foreach (string str in text)
      {
        ++num;
        if (newline)
          streamWriter.WriteLine(Environment.NewLine);
        streamWriter.WriteLine(str);
      }
      return num;
    }

    public static string writeFileFromUrl(string file, string location, bool newline, Array AltTxt)
    {
      int num = 0;
      try
      {
        string str = new StreamReader(WebRequest.Create(location).GetResponse().GetResponseStream(), Encoding.GetEncoding("windows-1252")).ReadToEnd();
        char[] chArray = new char[1]
        {
          '/'
        };
        foreach (string contents in str.Split(chArray))
        {
          if (newline)
            System.IO.File.AppendAllText(file, Environment.NewLine);
          System.IO.File.AppendAllText(file, contents);
          ++num;
        }
        return num.ToString();
      }
      catch
      {
        foreach (string contents in AltTxt)
        {
          ++num;
          if (newline)
            System.IO.File.AppendAllText(file, Environment.NewLine);
          System.IO.File.AppendAllText(file, contents);
        }
        return num.ToString();
      }
    }

    public static void removeLines(string file, string[] lines)
    {
      string[] strArray = System.IO.File.ReadAllText(file).Split(new string[1]
      {
        Environment.NewLine
      }, StringSplitOptions.RemoveEmptyEntries);
      ArrayList arrayList = new ArrayList();
      foreach (string str in strArray)
      {
        if (!Enumerable.Contains<string>((IEnumerable<string>) lines, str))
          System.IO.File.AppendAllText(file + "tmp", str + Environment.NewLine);
      }
    }

    public static void removeLine(string file, string[] line)
    {
      try
      {
        if (!System.IO.File.Exists(file) && System.IO.File.Exists(file + "bak"))
          System.IO.File.Copy(file + "bak", file);
        string[] strArray = System.IO.File.ReadAllLines(file);
        System.IO.File.WriteAllText(file + "tmp", "");
        if (System.IO.File.Exists(file + "new"))
          System.IO.File.Delete(file + "new");
        if (System.IO.File.Exists(file + "bak"))
          System.IO.File.Delete(file + "bak");
        else
          System.IO.File.Copy(file, file + "bak");
        foreach (string str in strArray)
        {
          string lines = str;
          if (!Enumerable.Any<string>((IEnumerable<string>) line, (Func<string, bool>) (s => lines.Contains(s))))
            System.IO.File.AppendAllText(file + "tmp", lines + Environment.NewLine);
        }
        System.IO.File.Delete(file);
        System.IO.File.Copy(file + "tmp", file);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("There has been an error cleaning your hosts file! this will not effect the operation of The Elite Patch, however it may effect your ability to access certain hosts. It is reccommended that you clear anything that was added by the elite patch before continuing." + Environment.NewLine + "Exact Error Message:" + Environment.NewLine + ex.Message);
      }
    }

    public static string removeLinesUrl(string file, string url, string[] lines, bool newline)
    {
      string[] strArray1 = System.IO.File.ReadAllText(file).Split(new string[1]
      {
        Environment.NewLine
      }, StringSplitOptions.RemoveEmptyEntries);
      ArrayList arrayList = new ArrayList();
      string str1;
      try
      {
        string[] strArray2 = new StreamReader(WebRequest.Create(url).GetResponse().GetResponseStream(), Encoding.GetEncoding("windows-1252")).ReadToEnd().Split(new string[1]
        {
          Environment.NewLine
        }, StringSplitOptions.RemoveEmptyEntries);
        if (newline)
        {
          foreach (string str2 in strArray1)
          {
            if (!Enumerable.Contains<string>((IEnumerable<string>) strArray2, str2))
              System.IO.File.AppendAllText(file + "tmp", str2 + Environment.NewLine);
          }
          System.IO.File.WriteAllText(file, System.IO.File.ReadAllText(file + "tmp"));
          System.IO.File.WriteAllText(file + "tmp", Environment.NewLine);
        }
        else
        {
          foreach (string contents in strArray1)
          {
            if (!Enumerable.Contains<string>((IEnumerable<string>) strArray2, contents))
              System.IO.File.AppendAllText(file + "tmp", contents);
          }
          System.IO.File.WriteAllText(file, System.IO.File.ReadAllText(file + "tmp"));
          System.IO.File.WriteAllText(file + "tmp", Environment.NewLine);
        }
        str1 = "Removed!";
      }
      catch
      {
        if (newline)
        {
          foreach (string str2 in strArray1)
          {
            if (!Enumerable.Contains<string>((IEnumerable<string>) lines, str2))
              System.IO.File.AppendAllText(file + "tmp", str2 + Environment.NewLine);
          }
          System.IO.File.WriteAllText(file, System.IO.File.ReadAllText(file + "tmp"));
          System.IO.File.WriteAllText(file + "tmp", Environment.NewLine);
        }
        else
        {
          foreach (string contents in strArray1)
          {
            if (!Enumerable.Contains<string>((IEnumerable<string>) lines, contents))
              System.IO.File.AppendAllText(file + "tmp", contents);
          }
          System.IO.File.WriteAllText(file, System.IO.File.ReadAllText(file + "tmp"));
          System.IO.File.WriteAllText(file + "tmp", Environment.NewLine);
        }
        str1 = "Removed!";
      }
      return str1;
    }

    public static string repairLinesUrl(string file, string url, string[] lines, bool newline)
    {
      string[] strArray1 = System.IO.File.ReadAllText(file).Split(new string[1]
      {
        Environment.NewLine
      }, StringSplitOptions.RemoveEmptyEntries);
      string str1;
      try
      {
        string str2 = new StreamReader(WebRequest.Create(url).GetResponse().GetResponseStream(), Encoding.GetEncoding("windows-1252")).ReadToEnd();
        string[] strArray2 = str2.Split(new string[1]
        {
          Environment.NewLine
        }, StringSplitOptions.RemoveEmptyEntries);
        if (newline)
        {
          foreach (string str3 in strArray1)
          {
            if (!Enumerable.Contains<string>((IEnumerable<string>) strArray2, str3))
              System.IO.File.AppendAllText(file + "tmp", str3 + Environment.NewLine);
          }
          System.IO.File.WriteAllText(file, Environment.NewLine);
          System.IO.File.WriteAllText(file, System.IO.File.ReadAllText(file + "tmp"));
          System.IO.File.WriteAllText(file + "tmp", Environment.NewLine);
          string str4 = str2;
          string[] separator = new string[1]
          {
            Environment.NewLine
          };
          int num = 1;
          foreach (string contents in str4.Split(separator, (StringSplitOptions) num))
          {
            System.IO.File.AppendAllText(file, Environment.NewLine);
            System.IO.File.AppendAllText(file, contents);
          }
        }
        else
        {
          foreach (string contents in strArray1)
          {
            if (!Enumerable.Contains<string>((IEnumerable<string>) strArray2, contents))
              System.IO.File.AppendAllText(file + "tmp", contents);
          }
          System.IO.File.WriteAllText(file, Environment.NewLine);
          System.IO.File.WriteAllText(file, System.IO.File.ReadAllText(file + "tmp"));
          System.IO.File.WriteAllText(file + "tmp", Environment.NewLine);
          string str3 = str2;
          string[] separator = new string[1]
          {
            Environment.NewLine
          };
          int num = 1;
          foreach (string contents in str3.Split(separator, (StringSplitOptions) num))
            System.IO.File.AppendAllText(file, contents);
        }
        str1 = "Repaired!";
      }
      catch
      {
        if (newline)
        {
          foreach (string str2 in strArray1)
          {
            if (!Enumerable.Contains<string>((IEnumerable<string>) lines, str2))
              System.IO.File.AppendAllText(file + "tmp", str2 + Environment.NewLine);
          }
          System.IO.File.WriteAllText(file, Environment.NewLine);
          System.IO.File.WriteAllText(file, System.IO.File.ReadAllText(file + "tmp"));
          System.IO.File.WriteAllText(file + "tmp", Environment.NewLine);
          foreach (string contents in lines)
          {
            System.IO.File.AppendAllText(file, Environment.NewLine);
            System.IO.File.AppendAllText(file, contents);
          }
        }
        else
        {
          foreach (string contents in strArray1)
          {
            if (!Enumerable.Contains<string>((IEnumerable<string>) lines, contents))
              System.IO.File.AppendAllText(file + "tmp", contents);
          }
          System.IO.File.WriteAllText(file, Environment.NewLine);
          System.IO.File.WriteAllText(file, System.IO.File.ReadAllText(file + "tmp"));
          System.IO.File.WriteAllText(file + "tmp", Environment.NewLine);
          foreach (string contents in lines)
            System.IO.File.AppendAllText(file, contents);
        }
        str1 = "Repaired!";
      }
      return str1;
    }
  }
}
