namespace CLMath;

public static class Convert
{
    public static int ConvertToInt32(string value)
    {
        if (string.IsNullOrEmpty(value) || !int.TryParse(value, out int result))
        {
            return 0;
        }
        return result;
    }

    public static long ConvertToInt64(string value)
    {
        if (string.IsNullOrEmpty(value) || !long.TryParse(value, out long result))
        {
            return 0;
        }
        return result;
    }

    public static float ConvertToReal32(string value)
    {
        if (string.IsNullOrEmpty(value) || !float.TryParse(value, out float result))
        {
            return 0;
        }
        return result;
    }

    public static double ConvertToReal64(string value)
    {
        if (string.IsNullOrEmpty(value) || !double.TryParse(value, out double result))
        {
            return 0;
        }
        return result;
    }
}