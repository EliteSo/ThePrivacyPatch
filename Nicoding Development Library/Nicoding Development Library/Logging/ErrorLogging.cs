// Type: NiCoding_Development_Library.Logging.ErrorLogging
// Assembly: NDL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D03E96A6-C992-4E9A-BE57-D6DDB9E706CB
// Assembly location: C:\Users\Gigawiz\Desktop\NDL.dll

using System;
using System.Collections;
using System.IO;

namespace NiCoding_Development_Library.Logging
{
  public class ErrorLogging
  {
    public static string writeSingleLineLog(string text, string location)
    {
      string str;
      try
      {
        File.AppendAllText(location, text);
        str = text + " - Written to log";
      }
      catch (Exception ex)
      {
        str = ex.Message;
      }
      return str;
    }

    public static string writeMultiLineLog(Array text, string location)
    {
      string str;
      try
      {
        IEnumerator enumerator = text.GetEnumerator();
        try
        {
          if (enumerator.MoveNext())
          {
            string contents = (string) enumerator.Current;
            File.AppendAllText(location, contents);
            return contents + " - Written to log";
          }
        }
        finally
        {
          IDisposable disposable = enumerator as IDisposable;
          if (disposable != null)
            disposable.Dispose();
        }
        str = "Successfully wrote to log";
      }
      catch (Exception ex)
      {
        str = ex.Message;
      }
      return str;
    }
  }
}
