namespace DreamBuildersLibs;

public static class StringExtensions
{
    public static string Reverse(this string str)
    {
        char[] array = str.ToCharArray();
        Array.Reverse(array);

        return new string(array);
    }

    public static int WordCount(this string str) =>
        str.Split([ ' ', '.', '?' ], StringSplitOptions.RemoveEmptyEntries).Length;

    public static bool IsValidString(this string str, char[] prohibitedChars, short maxChar = 0) =>
        (maxChar <= 0 || str.Length <= maxChar) && !string.IsNullOrEmpty(str) &&
        str.All(inputChar => prohibitedChars.All(prohibitedChar => inputChar != prohibitedChar));

    public static bool TryToInt(this string str, out int result) =>
        int.TryParse(str, out result);

    public static bool TryToFloat(this string str, out float result) =>
        float.TryParse(str, out result);

    public static T ToEnum<T>(this string str, bool ignoreCase = true) where T : Enum =>
        str.Trim()
            .IsBlank()
            ? throw new ArgumentException("Must specify valid information for parsing in the string.", "value")
            : (T)Enum.Parse(typeof(T), str, ignoreCase);

    /// <summary>Checks if a string contains null, empty or white space.</summary>
    public static bool IsBlank(this string? str) => string.IsNullOrWhiteSpace(str) || string.IsNullOrEmpty(str);

    /// <summary>Checks if a string is null and returns an empty string if it is.</summary>
    public static string OrEmpty(this string? val) => val ?? string.Empty;

    /// <summary>
    /// Shortens a string to the specified maximum length. If the string's length
    /// is less than the maxLength, the original string is returned.
    /// </summary>
    public static string Shorten(this string str, int maxLength) =>
        str.IsBlank() ? str : str.Length <= maxLength ? str : str[..maxLength];

    /// <summary>Slices a string from the start index to the end index.</summary>
    public static string Slice(this string str, int startIndex, int endIndex)
    {
        if (startIndex < 0 || startIndex > str.Length - 1)
            throw new ArgumentOutOfRangeException(nameof(startIndex));

        // If the end index is negative, it will be counted from the end of the string.
        endIndex = endIndex < 0 ? str.Length + endIndex : endIndex;

        return endIndex < 0 || endIndex < startIndex || endIndex > str.Length
            ? throw new ArgumentOutOfRangeException(nameof(endIndex))
            : str.Substring(startIndex, endIndex - startIndex);
    }
}