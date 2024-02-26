using System.Drawing;

class TrieNode
{
    public bool IsTerminal;
    public Dictionary<char, TrieNode> NextNode;
    public TrieNode()
    {   
        IsTerminal = false;
        NextNode = new Dictionary<char, TrieNode>();
    }
}
class Trie
{
    private TrieNode root;
    public static int Size;
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
            currentNode = currentNode.NextNode[element[i]];
        }
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
        if (currentNode.IsTerminal)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool Remove(string element)
    {
        TrieNode currentNode = root;
        if (!Contains(element))
        {
            return false;
        }
        RemoveElement(element, root);
        return true;
    }
    private static bool RemoveElement(string element, TrieNode currentNode)
    {
        if (element.Length > 0)
        {
            if (RemoveElement(element[1..], currentNode.NextNode[element[0]]))
            {
                currentNode.NextNode.Remove(element[0]);
                if (currentNode.NextNode.Count == 0)
                {
                    --Size;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        else
        {
            currentNode.IsTerminal = false;
            if (currentNode.NextNode.Count == 0)
            {
                --Size;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
class MainClass
{
    static void Main()
    {
        Trie trie = new Trie();
        Console.WriteLine(trie.Add("март"));
        Console.WriteLine(trie.Add("маcло"));
        Console.WriteLine(trie.Add("маcлонасос"));

        Console.WriteLine(trie.Contains("март"));
        Console.WriteLine(trie.Contains("маcло"));
        Console.WriteLine(trie.Contains("мар"));
        Console.WriteLine(trie.Contains("масса"));

        Console.WriteLine(trie.Remove("маcло"));
        Console.WriteLine();

        Console.WriteLine(trie.Contains("март"));
        Console.WriteLine(trie.Contains("маcло"));
        Console.WriteLine(trie.Contains("мар"));
        Console.WriteLine(trie.Contains("масса"));
    }
}