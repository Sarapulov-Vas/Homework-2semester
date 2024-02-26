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
    private  TrieNode root;
    public int Size;
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
    }
}