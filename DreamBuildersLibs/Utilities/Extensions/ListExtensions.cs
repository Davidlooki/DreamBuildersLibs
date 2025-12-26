namespace DreamBuildersLibs;

public static class ListExtensions
{
    [ThreadStatic]
    private static Random? _localRandom;
    private static Random Random => _localRandom ??= new Random();
    
    /// <summary>
    /// Removes a random item from the sequence, returning the sequence without that item.
    /// </summary>
    public static IList<T> RemoveRandom<T>(this IList<T> sequence, out T removedElement)
    {
        removedElement = sequence.GetRandom();
        sequence.Remove(removedElement);

        return sequence;
    }

    /// <summary>
    /// Based on the Fisher-Yates shuffle.
    /// </summary>
    public static IList<T> Shuffle<T>(this IList<T> sequence)
    {
        for (int i = sequence.Count; i > 1; i--)
        {
            byte[] box = new byte[1];

            //do Random.Shared.NextBytes(box);
            do Random.NextBytes(box);
            while (!(box[0] < i * (byte.MaxValue / i)));

            int k = (box[0] % i);
            i--;

            sequence.Swap(i, k);
        }

        return sequence;
    }

    /// <summary>
    /// Swaps two elements in the given sequence by indexes.
    /// </summary>
    public static IList<T> Swap<T>(this IList<T> sequence, int indexA, int indexB)
    {
        if (sequence.Count <= indexA && sequence.Count <= indexB)
            throw new Exception("One of indexes are greater than given sequence.");

        (sequence[indexA], sequence[indexB]) = (sequence[indexB], sequence[indexA]);

        return sequence;
    }
}