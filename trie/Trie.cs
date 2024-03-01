class Trie
{
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