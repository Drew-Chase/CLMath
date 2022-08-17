using System.Globalization;
using static System.Math;

namespace CLMath;

/// <summary>
/// For math concerning files
/// </summary>
public class CLFileMath
{
    public static (string[] added, string[] removed, string[] changed) FileDiffChecker(string older, string newer)
    {
        if (Directory.Exists(older) && Directory.Exists(newer))
        {
            List<string> added, removed, changed;
            added = removed = changed = new();

            string[] files_in_older = Directory.GetFiles(older, "*.*", SearchOption.AllDirectories);
            string[] files_in_newer = Directory.GetFiles(newer, "*.*", SearchOption.AllDirectories);
            Parallel.ForEach(files_in_older, file =>
            {
                string relative = Path.GetRelativePath(older, file);

            });

            return (added.ToArray(), removed.ToArray(), changed.ToArray());
        }

        return (Array.Empty<string>(), Array.Empty<string>(), Array.Empty<string>());
    }

    #region Public Methods

    public static string AdjustedFileSize(double bytes)
    {
        if (Round(double.Parse("" + bytes, NumberStyles.Any, CultureInfo.InvariantCulture), 2) < 1024)
        {
            return Round(double.Parse("" + bytes, NumberStyles.Any, CultureInfo.InvariantCulture), 2) + "B";
        }
        else if (Round(FileSizeKB(bytes), 2) < 1024)
        {
            return Round(FileSizeKB(bytes), 2) + "KB";
        }
        else if (Round(FileSizeMB(bytes), 2) < 1024)
        {
            return Round(FileSizeMB(bytes), 2) + "MB";
        }
        else if (Round(FileSizeGB(bytes), 2) < 1024)
        {
            return Round(FileSizeGB(bytes), 2) + "GB";
        }
        else if (Round(FileSizeTB(bytes), 2) < 1024)
        {
            return Round(FileSizeTB(bytes), 2) + "TB";
        }
        else if (Round(FileSizePB(bytes), 2) < 1024)
        {
            return Round(FileSizePB(bytes), 2) + "PB";
        }
        else if (Round(FileSizeEB(bytes), 2) < 1024)
        {
            return Round(FileSizeEB(bytes), 2) + "EB";
        }
        else
        {
            return Round(FileSizeZB(bytes), 2) + "ZB";
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