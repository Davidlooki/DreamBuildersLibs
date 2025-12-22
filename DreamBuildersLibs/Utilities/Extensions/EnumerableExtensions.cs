namespace DreamBuildersLibs;

public static class EnumerableExtensions
{
    /// <summary>
    /// Check if elements in two collections match.
    /// </summary>
    /// <param name="inOrder">Set true if the sequences must be in the same order.</param>
    public static bool ContentsMatch<T>(
        this IEnumerable<T> firstSequence,
        IEnumerable<T> secondSequence,
        bool inOrder = false
    )
    {
        var firstArray = firstSequence.ToArray();
        var secondArray = secondSequence.ToArray();

        return
            firstArray.Length == 0
            && secondArray.Length == 0
            ||
            firstArray.Length == secondArray.Length
            && (!inOrder
                ? firstArray.All(x1 => secondArray.Contains(x1))
                : !firstArray.Where((t, i) => t.Equals(secondArray[i])).Any());
    }

    /// <summary>
    /// Performs an action on each element in the sequence.
    /// </summary>
    /// <param name="action">The action to perform on each element.</param>    
    public static IEnumerable<T> ForEachDo<T>(this IEnumerable<T> sequence, Action<T> action)
    {
        var sequenceArray = sequence.ToArray();

        foreach (var item in sequenceArray) 
        { action(item); }

        return sequenceArray;
    }

    /// <summary>
    /// Performs a function on each element in the sequence.
    /// </summary>
    public static IEnumerable<T> ForEachDo<T, R>(this IEnumerable<T> sequence, Func<T, R> func)
    {
        var sequenceArray = sequence.ToArray();

        foreach (T element in sequenceArray) func(element);

        return sequenceArray;
    }

    /// <summary>
    /// Get a random element from <paramref name="sequence"/>.
    /// </summary>
    public static T GetRandom<T>(this IEnumerable<T> sequence)
    {
        var sequenceArray = sequence.ToArray();

        return sequenceArray.ToArray()[Random.Shared.Next(0, sequenceArray.Length)];
    }

    /// <returns>
    /// Returns -1 if none found.
    /// </returns>
    public static int IndexOf<T>(this IEnumerable<T> sequence, T item)
    {
        var sequenceArray = sequence.ToArray();
            
        var index = 0;
        foreach (var i in sequenceArray)
        {
            if (Equals(i, item)) return index;
            ++index;
        }

        return -1;
    }

    /// <summary>
    /// Determines whether a collection is null or has no elements.
    /// </summary>
    public static bool IsNullOrEmpty<T>(this IEnumerable<T>? sequence) => sequence == null || !sequence.Any();

    /// <summary>
    /// Removes a random item from the sequence, returning the sequence without that item.
    /// </summary>
    public static IEnumerable<T> RemoveRandom<T>(this IEnumerable<T> sequence, out T removedElement)
    {
        var newSequence = sequence.ToList();
        removedElement = GetRandom(newSequence);
        newSequence.Remove(removedElement);

        return newSequence;
    }

    /// <summary>
    /// Replace a value in sequence with a new value.
    /// </summary>
    public static IEnumerable<T> Replace<T>(this IEnumerable<T> sequence, T oldValue, T newValue)
    {
        var comparer = EqualityComparer<T>.Default;

        foreach (var item in sequence)
        {
            yield return
                comparer.Equals(item, oldValue)
                    ? newValue
                    : item;
        }
    }

    /// <summary>
    /// Based on the Fisher-Yates shuffle.
    /// </summary>
    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> sequence)
    {
        var buffer = sequence.ToList();
        for (int i = buffer.Count; i > 1; i--)
        {
            byte[] box = new byte[1];

            do Random.Shared.NextBytes(box);
            while (!(box[0] < i * (byte.MaxValue / i)));

            int k = (box[0] % i);
            i--;

            yield return buffer[i];
            buffer[k] = buffer[i];
        }
    }
}