/// <summary>
/// Conversion class BW.
/// </summary>
internal class BWT
{
    /// <summary>
    /// Suffix array.
    /// </summary>
    private int[] suffixArray;

    /// <summary>
    /// Retrieving an element by index.
    /// </summary>
    /// <param name="byteSequence">The original byte sequence.</param>
    /// <param name="index">Element Index.</param>
    /// <returns>Byte after application of BWT.</returns>
    public byte GetElement(byte[] byteSequence, int index)
    {
        if (suffixArray[index] == 0)
        {
            return byteSequence[^1];
        }
        else
        {
            return byteSequence[suffixArray[index] - 1];
        }
    }

    /// <summary>
    /// BWT direct conversion function.
    /// </summary>
    /// <param name="byteSequence">Converted byteSequence.</param>
    /// <returns>The converted byteSequenceing and the position of the end of the byteSequence.</returns>
    public int DirectConversion(byte[] byteSequence)
    {
        suffixArray = new int[byteSequence.Length];
        var resultbyteSequence = new byte[byteSequence.Length];
        for (int i = 0; i < byteSequence.Length; ++i)
        {
            suffixArray[i] = i;
        }

        Array.Sort(suffixArray, (x, y) => Compare(byteSequence, x, y));
        int endIndex = Array.IndexOf(suffixArray, 0);
        for (int i = 0; i < byteSequence.Length; ++i)
        {
            if (suffixArray[i] == 0)
            {
                resultbyteSequence[i] = byteSequence[^1];
            }
            else
            {
                resultbyteSequence[i] = byteSequence[suffixArray[i] - 1];
            }
        }

        return endIndex;
    }

    /// <summary>
    /// Inverse BWT transformation.
    /// </summary>
    /// <param name="byteSequenceingBWT">Converted byteSequenceing.</param>
    /// <param name="endIndex">End of line position.</param>
    /// <returns>Original byteSequenceing.</returns>
    public static byte[] InverseBWT(List<byte> byteSequenceingBWT, int endIndex)
    {
        if (byteSequenceingBWT.Count == 0)
        {
            return [];
        }

        byte[] bytes = byteSequenceingBWT.Distinct().ToArray();
        var characterIndex = new int[bytes.Length];
        var sortedIndexes = new int[byteSequenceingBWT.Count];
        var originalbyteSequenceing = new byte[byteSequenceingBWT.Count];
        Array.Sort(bytes);
        for (int i = 1; i < bytes.Length; ++i)
        {
            characterIndex[i] = byteSequenceingBWT.Where(sign => sign == bytes[i - 1]).Count() + characterIndex[i - 1];
        }

        for (int i = 0; i < byteSequenceingBWT.Count; ++i)
        {
            sortedIndexes[i] = characterIndex[Array.IndexOf(bytes, byteSequenceingBWT[i])];
            characterIndex[Array.IndexOf(bytes, byteSequenceingBWT[i])]++;
        }

        originalbyteSequenceing[^1] = byteSequenceingBWT[endIndex];
        for (int i = 1; i < byteSequenceingBWT.Count; ++i)
        {
            endIndex = sortedIndexes[endIndex];
            originalbyteSequenceing[^(i + 1)] = byteSequenceingBWT[endIndex];
        }

        return originalbyteSequenceing;
    }

    /// <summary>
    /// Comparator for sorting suffixes.
    /// </summary>
    /// <param name="byteSequence">Input byteSequenceing.</param>
    /// <param name="firstIndex">Index of first compare element.</param>
    /// <param name="secondIndex">Index of second compaere element.</param>
    /// <returns>A comparison of two suffixes.</returns>
    private static int Compare(byte[] byteSequence, int firstIndex, int secondIndex)
    {
        for (int i = 0; i < byteSequence.Length; ++i)
        {
            if (byteSequence[firstIndex] > byteSequence[secondIndex])
            {
                return 1;
            }

            if (byteSequence[firstIndex] < byteSequence[secondIndex])
            {
                return -1;
            }

            firstIndex = firstIndex == byteSequence.Length - 1 ? 0 : ++firstIndex;
            secondIndex = secondIndex == byteSequence.Length - 1 ? 0 : ++secondIndex;
        }

        return 0;
    }
}