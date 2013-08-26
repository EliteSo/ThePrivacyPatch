// Type: NiCoding_Development_Library.File_Operations.FileChecking
// Assembly: NDL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D03E96A6-C992-4E9A-BE57-D6DDB9E706CB
// Assembly location: C:\Users\Gigawiz\Desktop\NDL.dll

using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace NiCoding_Development_Library.File_Operations
{
  public class FileChecking
  {
    public static string GetMD5HashFromFile(string filename)
    {
      using (MD5CryptoServiceProvider cryptoServiceProvider = new MD5CryptoServiceProvider())
      {
        byte[] hash = cryptoServiceProvider.ComputeHash(File.ReadAllBytes(filename));
        StringBuilder stringBuilder = new StringBuilder();
        for (int index = 0; index < hash.Length; ++index)
          stringBuilder.Append(hash[index].ToString("x2"));
        return ((object) stringBuilder).ToString();
      }
    }

    public static string AltGetMd5HashFromFile(string fileName)
    {
      FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
      byte[] hash = new MD5CryptoServiceProvider().ComputeHash((Stream) fileStream);
      fileStream.Close();
      StringBuilder stringBuilder = new StringBuilder();
      for (int index = 0; index < hash.Length; ++index)
        stringBuilder.Append(hash[index].ToString("x2"));
      return ((object) stringBuilder).ToString();
    }
  }
}
