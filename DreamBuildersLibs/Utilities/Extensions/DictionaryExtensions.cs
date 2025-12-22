namespace DreamBuildersLibs;

public static class DictionaryExtensions
{
    /// <summary>
    /// Is Keys in dictionary the same as some sequence.
    /// </summary>
    /// <param name="inOrder">Set true if the sequences must be in the same order.</param>
    public static bool ContentsMatchKeys<T1, T2>(
        this IDictionary<T1, T2> dictionary,
        IEnumerable<T1> sequence,
        bool inOrder = false
    )
    {
        var sequenceArray = sequence.ToArray();

        if (dictionary.IsNullOrEmpty() && sequenceArray.IsNullOrEmpty()) return true;
        if (dictionary.IsNullOrEmpty() || sequenceArray.IsNullOrEmpty()) return false;

        return dictionary.Keys.ContentsMatch(sequenceArray, inOrder);
    }

    /// <summary>
    /// Is Values in dictionary the same as some sequence.
    /// </summary>
    /// <param name="inOrder">Set true if the sequences must be in the same order.</param>
    public static bool ContentsMatchValues<T1, T2>(
        this IDictionary<T1, T2> dictionary,
        IEnumerable<T2> sequence,
        bool inOrder = false
    )
    {
        var sequenceArray = sequence.ToArray();

        return dictionary.Count == 0
               && sequenceArray.Length == 0
               ||
               !dictionary.IsNullOrEmpty()
               && !sequenceArray.IsNullOrEmpty()
               && dictionary.Values.ContentsMatch(sequenceArray, inOrder);
    }
}