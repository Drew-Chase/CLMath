namespace CLMath;

/// <summary>
/// Class for converting one type to another
/// </summary>
public static class Convert
{
    /// <summary>
    /// Converts String to a 32bit Interger<br />
    /// Returns -1 if it failed to convert
    /// </summary>
    /// <param name="value"></param>
    /// <returns>the int or -1</returns>
    public static int ToInt32(string value)
    {
        if (string.IsNullOrEmpty(value) || !int.TryParse(value, out int result))
        {
            return -1;
        }
        return result;
    }


    /// <summary>
    /// Converts String to a 64bit Interger<br />
    /// Returns -1 if it failed to convert
    /// </summary>
    /// <param name="value"></param>
    /// <returns>the int or -1</returns>
    public static long ToInt64(string value)
    {
        if (string.IsNullOrEmpty(value) || !long.TryParse(value, out long result))
        {
            return -1;
        }
        return result;
    }

    /// <summary>
    /// Converts String to a 32bit Real<br />
    /// Returns -1 if it failed to convert
    /// </summary>
    /// <param name="value"></param>
    /// <returns>the int or -1</returns>
    public static float ToReal32(string value)
    {
        if (string.IsNullOrEmpty(value) || !float.TryParse(value, out float result))
        {
            return -1;
        }
        return result;
    }

    /// <summary>
    /// Converts String to a 64bit Real<br />
    /// Returns -1 if it failed to convert
    /// </summary>
    /// <param name="value"></param>
    /// <returns>the int or -1</returns>
    public static double ToReal64(string value)
    {
        if (string.IsNullOrEmpty(value) || !double.TryParse(value, out double result))
        {
            return -1;
        }
        return result;
    }
}