/// <summary>
/// Conversion class BW.
/// </summary>
internal class BWT
{
    /// <summary>
    /// BWT direct conversion function.
    /// </summary>
    /// <param name="inputString">Converted string.</param>
    /// <returns>The converted string and the position of the end of the string.</returns>
    public (string, int) DirectConversion(string inputString)
    {
        var suffixArray = new int[inputString.Length];
        var resultString = new char[inputString.Length];
        for (int i = 0; i < inputString.Length; ++i)
        {
            suffixArray[i] = i;
        }

        Array.Sort(suffixArray, (x, y) => Compare(inputString, x, y));
        int endIndex = Array.IndexOf(suffixArray, 0);
        for (int i = 0; i < inputString.Length; ++i)
        {
            if (suffixArray[i] == 0)
            {
                resultString[i] = inputString[^1];
            }
            else
            {
                resultString[i] = inputString[suffixArray[i] - 1];
            }
        }

        return (new string(resultString), endIndex);
    }

    /// <summary>
    /// Inverse BWT transformation.
    /// </summary>
    /// <param name="stringBWT">Converted string.</param>
    /// <param name="endIndex">End of line position.</param>
    /// <returns>Original string.</returns>
    public string InverseBWT(string stringBWT, int endIndex)
    {
        if (stringBWT.Length == 0)
        {
            return string.Empty;
        }

        char[] characters = stringBWT.Distinct().ToArray();
        var characterIndex = new int[characters.Length];
        var sortedIndexes = new int[stringBWT.Length];
        var originalString = new char[stringBWT.Length];
        Array.Sort(characters);
        for (int i = 1; i < characters.Length; ++i)
        {
            characterIndex[i] = stringBWT.Where(sign => sign == characters[i - 1]).Count() + characterIndex[i - 1];
        }

        for (int i = 0; i < stringBWT.Length; ++i)
        {
            sortedIndexes[i] = characterIndex[Array.IndexOf(characters, stringBWT[i])];
            characterIndex[Array.IndexOf(characters, stringBWT[i])]++;
        }

        originalString[^1] = stringBWT[endIndex];
        for (int i = 1; i < stringBWT.Length; ++i)
        {
            endIndex = sortedIndexes[endIndex];
            originalString[^(i + 1)] = stringBWT[endIndex];
        }

        return new string(originalString);
    }

    /// <summary>
    /// Comparator for sorting suffixes.
    /// </summary>
    /// <param name="str">Input string.</param>
    /// <param name="firstIndex">Index of first compare element.</param>
    /// <param name="secondIndex">Index of second compaere element.</param>
    /// <returns>A comparison of two suffixes.</returns>
    private int Compare(string str, int firstIndex, int secondIndex)
    {
        for (int i = 0; i < str.Length; ++i)
        {
            if (!Equals(str[firstIndex], str[secondIndex]))
            {
                return str[firstIndex].CompareTo(str[secondIndex]);
            }

            firstIndex = firstIndex == str.Length - 1 ? firstIndex = 0 : ++firstIndex;
            secondIndex = secondIndex == str.Length - 1 ? secondIndex = 0 : ++secondIndex;
        }

        return 0;
    }
}