using System.Globalization;
using static System.Math;

namespace CLMath;

/// <summary>
/// For math concerning files
/// </summary>
public class CLFileMath
{
    #region Public Methods

    public static string AdjustedFileSize(double bytes)
    {
        if (Round(double.Parse("" + bytes, NumberStyles.Any, CultureInfo.InvariantCulture), 2) < 1024)
        {
            return Round(double.Parse("" + bytes, NumberStyles.Any, CultureInfo.InvariantCulture), 2) + "b";
        }
        else if (Round(FileSizeKB(bytes), 2) < 1024)
        {
            return Round(FileSizeKB(bytes), 2) + "Kb";
        }
        else if (Round(FileSizeMB(bytes), 2) < 1024)
        {
            return Round(FileSizeMB(bytes), 2) + "Mb";
        }
        else if (Round(FileSizeGB(bytes), 2) < 1024)
        {
            return Round(FileSizeGB(bytes), 2) + "Gb";
        }
        else if (Round(FileSizeTB(bytes), 2) < 1024)
        {
            return Round(FileSizeTB(bytes), 2) + "Tb";
        }
        else if (Round(FileSizePB(bytes), 2) < 1024)
        {
            return Round(FileSizePB(bytes), 2) + "Pb";
        }
        else if (Round(FileSizeEB(bytes), 2) < 1024)
        {
            return Round(FileSizeEB(bytes), 2) + "Eb";
        }
        else
        {
            return Round(FileSizeZB(bytes), 2) + "Zb";
        }
    }

    public static double FileSizeEB(double bytes)
    {
        double num = FileSizePB(bytes) / 1024;
        double.TryParse("" + num, NumberStyles.Any, CultureInfo.InvariantCulture, out num);
        num = Round(num, 2);
        return num;
    }

    public static double FileSizeGB(double bytes)
    {
        double num = FileSizeMB(bytes) / 1024;
        double.TryParse("" + num, NumberStyles.Any, CultureInfo.InvariantCulture, out num);
        num = Round(num, 2);
        return num;
    }

    public static double FileSizeKB(double bytes)
    {
        double num = bytes / 1024;
        double.TryParse("" + num, NumberStyles.Any, CultureInfo.InvariantCulture, out num);
        num = Round(num, 2);
        return num;
    }

    public static double FileSizeMB(double bytes)
    {
        double num = FileSizeKB(bytes) / 1024;
        double.TryParse("" + num, NumberStyles.Any, CultureInfo.InvariantCulture, out num);
        num = Round(num, 2);
        return num;
    }

    public static double FileSizePB(double bytes)
    {
        double num = FileSizeTB(bytes) / 1024;
        double.TryParse("" + num, NumberStyles.Any, CultureInfo.InvariantCulture, out num);
        num = Round(num, 2);
        return num;
    }

    public static double FileSizeTB(double bytes)
    {
        double num = FileSizeGB(bytes) / 1024;
        double.TryParse("" + num, NumberStyles.Any, CultureInfo.InvariantCulture, out num);
        num = Round(num, 2);
        return num;
    }

    public static double FileSizeZB(double bytes)
    {
        double num = FileSizeZB(bytes) / 1024;
        double.TryParse("" + num, NumberStyles.Any, CultureInfo.InvariantCulture, out num);
        num = Round(num, 2);
        return num;
    }

    #endregion Public Methods
}