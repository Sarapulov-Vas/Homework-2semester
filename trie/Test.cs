class Test
{
    private static bool TestAdd(string[] inputElements, bool[] expectedOut, int expectedCount)
    {
        Trie testTrie = new Trie();
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
    private static bool TestContains(string[] inputElements, string[] findElements, bool[] expectedOut)
    {
        Trie testTrie = new Trie();
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
    private static bool TestRemove(string[] inputElements, string[] removeElements, bool[] expectedOut, int expectedCount)
    {
        Trie testTrie = new Trie();
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
    public static void StartTest()
    {
        if(!TestAdd(["ab", "abcd", "df", "", "ab"], [true, true, true, true, false], 6))
        {   
            Console.WriteLine("Addition test fails");
        }
        else
        {
            Console.WriteLine("Addition test passed");
        }
        if(!TestContains(["ab", "abcd", "df", "", "abef"], ["df", "abc", "", "ab", "abe", "dfe"], [true, false, true, true, false, false]))
        {   
            Console.WriteLine("Contains test fails");
        }
        else
        {
            Console.WriteLine("Contains test passed");
        }
        if(!TestRemove(["ab", "abcd", "df", "", "abef", "abcf", "abc"], ["ab", "", "abc"], [false, true, true, false, true, true, false], 9))
        {   
            Console.WriteLine("Remove test fails");
        }
        else
        {
            Console.WriteLine("Remove test passed");
        }

        if(!TestHowManyStartsWithPrefix(["ab", "abcd", "df", "dfabc", "acd", "abcf", "abc"], ["ab", "dfa", ""], [4, 1, 7]))
        {   
            Console.WriteLine("HowManyStartsWithPrefix test fails");
        }
        else
        {
            Console.WriteLine("HowManyStartsWithPrefix test passed");
        }
    }
}