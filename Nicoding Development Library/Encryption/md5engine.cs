// Type: NiCoding_Development_Library.Encryption.md5engine
// Assembly: NDL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D03E96A6-C992-4E9A-BE57-D6DDB9E706CB
// Assembly location: C:\Users\Gigawiz\Desktop\NDL.dll

using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace NiCoding_Development_Library.Encryption
{
  public class md5engine
  {
    public string EncodePassword(string originalPassword)
    {
      return md5engine.CleanInput(BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(Encoding.Default.GetBytes(originalPassword))));
    }

    private static string CleanInput(string strIn)
    {
      return Regex.Replace(strIn, "[^\\w\\.@]", "");
    }
  }
}
