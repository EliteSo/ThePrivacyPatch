// Type: NiCoding_Development_Library.OSOperations.OSCheck
// Assembly: NDL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D03E96A6-C992-4E9A-BE57-D6DDB9E706CB
// Assembly location: C:\Users\Gigawiz\Desktop\NDL.dll

using System;

namespace NiCoding_Development_Library.OSOperations
{
  public class OSCheck
  {
    public static bool IsWinXPOrHigher()
    {
      OperatingSystem osVersion = Environment.OSVersion;
      return osVersion.Platform == PlatformID.Win32NT && (osVersion.Version.Major > 5 || osVersion.Version.Major == 5 && osVersion.Version.Minor >= 1);
    }

    public static bool IsWinVistaOrHigher()
    {
      OperatingSystem osVersion = Environment.OSVersion;
      return osVersion.Platform == PlatformID.Win32NT && osVersion.Version.Major >= 6;
    }

    public static bool IsWinSevenOrHigher()
    {
      OperatingSystem osVersion = Environment.OSVersion;
      return osVersion.Platform == PlatformID.Win32NT && osVersion.Version.Major >= 6 && osVersion.Version.Minor >= 1;
    }
  }
}
