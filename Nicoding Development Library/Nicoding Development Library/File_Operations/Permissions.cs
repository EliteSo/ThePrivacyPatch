// Type: NiCoding_Development_Library.File_Operations.Permissions
// Assembly: NDL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D03E96A6-C992-4E9A-BE57-D6DDB9E706CB
// Assembly location: C:\Users\Gigawiz\Desktop\NDL.dll

using NiCoding_Development_Library.OSOperations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.NetworkInformation;
using System.Security.AccessControl;
using System.Security.Principal;

namespace NiCoding_Development_Library.File_Operations
{
  public class Permissions
  {
    public static Array readPerms(string file)
    {
      List<string> list = new List<string>();
      FileSecurity fileSecurity = new FileSecurity();
      foreach (FileSystemAccessRule systemAccessRule in (ReadOnlyCollectionBase) File.GetAccessControl(file).GetAccessRules(true, true, typeof (NTAccount)))
      {
        list.Add(systemAccessRule.IdentityReference.Value);
        list.Add(((object) systemAccessRule.FileSystemRights).ToString());
      }
      return (Array) list.ToArray();
    }

    public static string setPerms(string file, bool remove)
    {
      string str1 = "";
      string domainName = IPGlobalProperties.GetIPGlobalProperties().DomainName;
      string Account = !OSCheck.IsWinXPOrHigher() ? IPGlobalProperties.GetIPGlobalProperties().DomainName + "\\\\Everyone" : WindowsIdentity.GetCurrent().Name;
      string FileName = file;
      string str2;
      try
      {
        if (remove)
        {
          Console.WriteLine("Removing access control entry from " + FileName);
          Permissions.RemoveFileSecurity(FileName, Account, FileSystemRights.ReadAndExecute, AccessControlType.Allow);
          str2 = "Successfully removed access control entry to " + FileName;
        }
        else
        {
          str1 = "Adding access control entry for " + FileName;
          Permissions.AddFileSecurity(FileName, Account, FileSystemRights.FullControl, AccessControlType.Allow);
          str2 = "Successfully added access control entry to " + FileName;
        }
      }
      catch (Exception ex)
      {
        str2 = ex.Message;
      }
      return str2;
    }

    public static void AddFileSecurity(string FileName, string Account, FileSystemRights Rights, AccessControlType ControlType)
    {
      FileInfo fileInfo = new FileInfo(FileName);
      FileSecurity accessControl = fileInfo.GetAccessControl();
      accessControl.AddAccessRule(new FileSystemAccessRule(Account, Rights, ControlType));
      fileInfo.SetAccessControl(accessControl);
    }

    public static void RemoveFileSecurity(string FileName, string Account, FileSystemRights Rights, AccessControlType ControlType)
    {
      FileInfo fileInfo = new FileInfo(FileName);
      FileSecurity accessControl = fileInfo.GetAccessControl();
      accessControl.RemoveAccessRule(new FileSystemAccessRule(Account, Rights, ControlType));
      fileInfo.SetAccessControl(accessControl);
    }
  }
}
