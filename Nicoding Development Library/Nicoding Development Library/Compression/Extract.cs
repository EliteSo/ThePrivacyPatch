// Type: NiCoding_Development_Library.Compression.Extract
// Assembly: NDL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D03E96A6-C992-4E9A-BE57-D6DDB9E706CB
// Assembly location: C:\Users\Gigawiz\Desktop\NDL.dll

using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;

namespace NiCoding_Development_Library.Compression
{
  public class Extract
  {
    private static void Decompress(FileInfo fi)
    {
      using (FileStream fileStream1 = fi.OpenRead())
      {
        string fullName = fi.FullName;
        using (FileStream fileStream2 = File.Create(fullName.Remove(fullName.Length - fi.Extension.Length)))
        {
          using (GZipStream gzipStream = new GZipStream((Stream) fileStream1, CompressionMode.Decompress))
            gzipStream.CopyTo((Stream) fileStream2);
        }
      }
    }

    private void DecryptFile(string inputFile, string outputFile, string password)
    {
      UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
      byte[] key = Extract.CreateKey(password);
      FileStream fileStream1 = new FileStream(inputFile, FileMode.Open);
      RijndaelManaged rijndaelManaged = new RijndaelManaged();
      byte[] iv = this.CreateIV(password);
      CryptoStream cryptoStream = new CryptoStream((Stream) fileStream1, rijndaelManaged.CreateDecryptor(key, iv), CryptoStreamMode.Read);
      FileStream fileStream2 = new FileStream(outputFile.Remove(outputFile.Length - 4), FileMode.Create);
      int num;
      while ((num = cryptoStream.ReadByte()) != -1)
        fileStream2.WriteByte((byte) num);
      fileStream2.Close();
      cryptoStream.Close();
      fileStream1.Close();
    }

    public static byte[] CreateKey(string password)
    {
      byte[] salt = new byte[10]
      {
        (byte) 1,
        (byte) 2,
        (byte) 23,
        (byte) 234,
        (byte) 37,
        (byte) 48,
        (byte) 134,
        (byte) 63,
        (byte) 248,
        (byte) 4
      };
      using (Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, salt, 9872))
        return rfc2898DeriveBytes.GetBytes(16);
    }

    public byte[] CreateIV(string password)
    {
      byte[] salt = new byte[10]
      {
        (byte) 4,
        (byte) 7,
        (byte) 21,
        (byte) 199,
        (byte) 45,
        (byte) 63,
        (byte) 138,
        (byte) 12,
        (byte) 213,
        (byte) 1
      };
      using (Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, salt, 325))
        return rfc2898DeriveBytes.GetBytes(16);
    }
  }
}
