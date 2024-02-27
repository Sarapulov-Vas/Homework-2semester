using System.ComponentModel;

class TrieNode
{
    public bool IsTerminal;
    public int WordCount;
    public Dictionary<char, TrieNode> NextNode;
    public TrieNode()
    {   
        IsTerminal = false;
        WordCount = 0;
        NextNode = new Dictionary<char, TrieNode>();
    }
}
class Trie
{
    private TrieNode root;
    public int Size{ get; private set; }
    public Trie()
    {
        Size = 0;
        root = new TrieNode();
    }
    public bool Add(string element)
    {
        TrieNode currentNode = root;
        for (int i = 0; i<element.Length; ++i)
        {
            if (!currentNode.NextNode.ContainsKey(element[i]))
            {
                currentNode.NextNode.Add(element[i], new TrieNode());
                ++Size;
            }
            ++currentNode.WordCount;
            currentNode = currentNode.NextNode[element[i]];
        }
        ++currentNode.WordCount;
        if (currentNode.IsTerminal == false)
        {
            currentNode.IsTerminal = true;
            return true;
        }
        return false;
    }
    public bool Contains(string element)
    {
        TrieNode currentNode = root;
        foreach (var symbol in element)
        {
            if (!currentNode.NextNode.ContainsKey(symbol))
            {
                return false;
            }
            currentNode = currentNode.NextNode[symbol];
        }
        return currentNode.IsTerminal;
    }
    public bool Remove(string element)
    {
        if (!Contains(element))
        {
            return false;
        }
        RemoveElement(element, root);
        return true;
    }
    private bool RemoveElement(string element, TrieNode currentNode)
    {
        if (element.Length > 0)
        {
            --currentNode.WordCount;
            if (RemoveElement(element[1..], currentNode.NextNode[element[0]]))
            {
                currentNode.NextNode.Remove(element[0]);
                if (currentNode.NextNode.Count == 0)
                {
                    --Size;
                    return true;
                }
            }
            return false;
        }
        else
        {
            currentNode.IsTerminal = false;
            --currentNode.WordCount;
            if (currentNode.NextNode.Count == 0)
            {
                --Size;
                return true;
            }
            return false;

        }
    }
    public int HowManyStartsWithPrefix(String prefix)
    {
        TrieNode currentNode = root;
        foreach (var symbol in prefix)
        {
            if (currentNode.NextNode.ContainsKey(symbol))
            {
                currentNode = currentNode.NextNode[symbol];   
            }
            else
            {
                Console.WriteLine("Prefix not found!");
                return 0;
            }
        }
        return currentNode.WordCount;
    }
}
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
class MainClass
{
    static void Main()
    {
        Trie trie = new Trie();
        Test.StartTest();
        trie.Add("abc");
        Console.WriteLine(trie.Size);
    }
}