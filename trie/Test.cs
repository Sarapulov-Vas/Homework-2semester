/// <summary>
/// Class for tests.
/// </summary>
internal static class Test
{
    /// <summary>
    /// Test run method.
    /// </summary>
    /// <returns>Test status.</returns>
    public static bool StartTest()
    {
        bool result = true;
        if (TestAdd(["ab", "abcd", "df", string.Empty, "ab"], [true, true, true, true, false], 6))
        {
            Console.WriteLine("Addition test passed");
        }
        else
        {
            Console.WriteLine("Addition test fails");
            result = false;
        }

        if (TestContains(["ab", "abcd", "df", string.Empty, "abef"], ["df", "abc", string.Empty, "ab", "abe", "dfe"], [true, false, true, true, false, false]))
        {
            Console.WriteLine("Contains test passed");
        }
        else
        {
            Console.WriteLine("Contains test fails");
            result = false;
        }

        if (TestRemove(["ab", "abcd", "df", string.Empty, "abef", "abcf", "abc"], ["ab", string.Empty, "abc"], [false, true, true, false, true, true, false], 9))
        {
            Console.WriteLine("Remove test passed");
        }
        else
        {
            Console.WriteLine("Remove test fails");
            result = false;
        }

        if (TestHowManyStartsWithPrefix(["ab", "abcd", "df", "dfabc", "acd", "abcf", "abc"], ["ab", "dfa", string.Empty], [4, 1, 7]))
        {
            Console.WriteLine("HowManyStartsWithPrefix test passed");
        }
        else
        {
            Console.WriteLine("HowManyStartsWithPrefix test fails");
            result = false;
        }

        return result;
    }

    /// <summary>
    /// A method for testing the addition of items.
    /// </summary>
    /// <param name="inputElements">An array of input strings.</param>
    /// <param name="expectedOut">Expected result of test.</param>
    /// <param name="expectedCount">Expected number of elements in the trie.</param>
    /// <returns>Result of test.</returns>
    private static bool TestAdd(string[] inputElements, bool[] expectedOut, int expectedCount)
    {
        var testTrie = new Trie();
        for (int i = 0; i < inputElements.Length; ++i)
        {
            if (testTrie.Add(inputElements[i]) != expectedOut[i])
            {
                Console.WriteLine($"error when adding an item '{inputElements[i]}'!");
                return false;
            }
        }

        if (expectedCount != testTrie.Size)
        {
            Console.WriteLine("Wrong number of items!");
            return false;
        }

        return true;
    }

    /// <summary>
    /// A test of searching for elements in trie.
    /// </summary>
    /// <param name="inputElements">Input array of strings.</param>
    /// <param name="findElements">Input array of strings for search.</param>
    /// <param name="expectedOut">Expecteed result of test.</param>
    /// <returns>Result of test.</returns>
    private static bool TestContains(string[] inputElements, string[] findElements, bool[] expectedOut)
    {
        var testTrie = new Trie();
        foreach (var element in inputElements)
        {
            testTrie.Add(element);
        }

        for (int i = 0; i < inputElements.Length; ++i)
        {
            if (testTrie.Contains(findElements[i]) != expectedOut[i])
            {
                Console.WriteLine($"element '{inputElements[i]}' - wrong result!");
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// The test of removing elements from trie.
    /// </summary>
    /// <param name="inputElements">Input array of strings.</param>
    /// <param name="removeElements">An array of elements to be deleted.</param>
    /// <param name="expectedOut">Expected result of test.</param>
    /// <param name="expectedCount">Expected number of elements in trie after deletion.</param>
    /// <returns>Result of test.</returns>
    private static bool TestRemove(string[] inputElements, string[] removeElements, bool[] expectedOut, int expectedCount)
    {
        var testTrie = new Trie();
        foreach (var element in inputElements)
        {
            testTrie.Add(element);
        }

        foreach (var element in removeElements)
        {
            testTrie.Remove(element);
        }

        for (int i = 0; i < inputElements.Length; i++)
        {
            if (testTrie.Contains(inputElements[i]) != expectedOut[i])
            {
                Console.WriteLine($"element '{inputElements[i]}' - wrong result!");
                return false;
            }
        }

        if (expectedCount != testTrie.Size)
        {
            Console.WriteLine("Wrong number of items!");
            return false;
        }

        return true;
    }

    /// <summary>
    /// Test to check the number of lines starting with the entered prefix.
    /// </summary>
    /// <param name="inputString">Input array of strings.</param>
    /// <param name="inputPrefix">Search prefix.</param>
    /// <param name="expectedOut">expected number of lines starting with the entered prefix.</param>
    /// <returns>Result of test.</returns>
    private static bool TestHowManyStartsWithPrefix(string[] inputString, string[] inputPrefix, int[] expectedOut)
    {
        Trie testTrie = new Trie();
        foreach (var element in inputString)
        {
            testTrie.Add(element);
        }

        for (int i = 0; i < inputPrefix.Length; ++i)
        {
            if (testTrie.HowManyStartsWithPrefix(inputPrefix[i]) != expectedOut[i])
            {
                Console.WriteLine($"'{inputPrefix[i]}' - wrong result");
                return false;
            }
        }

        return true;
    }
}