/// <summary>
/// The trie data structure class.
/// </summary>
internal class Trie
{
    /// <summary>
    /// Root trie.
    /// </summary>
    private TrieNode root;

    /// <summary>
    /// Initializes a new instance of the <see cref="Trie"/> class.
    /// </summary>
    public Trie()
    {
        this.Size = 0;
        this.root = new TrieNode();
    }

    /// <summary>
    /// Gets the number of elements in the trie.
    /// </summary>
    public int Size { get; private set; }

    /// <summary>
    /// Adding an item to trie.
    /// </summary>
    /// <param name="element">Added string.</param>
    /// <returns>Whether the item was successfully added.</returns>
    public bool Add(string element)
    {
        TrieNode currentNode = this.root;
        for (int i = 0; i < element.Length; ++i)
        {
            if (!currentNode.NextNode.ContainsKey(element[i]))
            {
                currentNode.NextNode.Add(element[i], new TrieNode());
                ++this.Size;
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

    /// <summary>
    /// Method that checks if the element exists in trie.
    /// </summary>
    /// <param name="element">Element to be checked.</param>
    /// <returns>Whether the element is in trie.</returns>
    public bool Contains(string element)
    {
        TrieNode currentNode = this.root;
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

    /// <summary>
    /// A method for removing an element from a trie.
    /// </summary>
    /// <param name="element">The element to be deleted.</param>
    /// <returns>Whether the element has been removed.</returns>
    public bool Remove(string element)
    {
        TrieNode currentNode = root;
        if (!this.Contains(element))
        {
            return false;
        }

        // this.RemoveElement(element, this.root);
        for (int i = 0; i < element.Length; ++i)
        {
            TrieNode nextNode = currentNode.NextNode[element[i]];
            --currentNode.WordCount;
            if (currentNode.WordCount == 0)
            {
                currentNode.NextNode.Remove(element[i]);
            }

            currentNode = nextNode;
        }

        currentNode.IsTerminal = false;
        return true;
    }

    /// <summary>
    /// A method to get the number of rows starting with a prefix.
    /// </summary>
    /// <param name="prefix">The prefix with which the string begins.</param>
    /// <returns>The number of lines starting with the prefix.</returns>
    public int HowManyStartsWithPrefix(string prefix)
    {
        TrieNode currentNode = this.root;
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

    /// <summary>
    /// The class of the trie element.
    /// </summary>
    private class TrieNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TrieNode"/> class.
        /// </summary>
        public TrieNode()
        {
            this.IsTerminal = false;
            this.WordCount = 0;
            this.NextNode = new Dictionary<char, TrieNode>();
        }

        /// <summary>
        /// Gets or sets a dictionary of pointers to the following items.
        /// </summary>
        public Dictionary<char, TrieNode> NextNode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a variable indicating the end of a line.
        /// </summary>
        public bool IsTerminal { get; set; }

        /// <summary>
        /// Gets or sets the number of lines containing this element.
        /// </summary>
        public int WordCount { get; set; }
    }
}