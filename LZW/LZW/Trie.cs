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
    /// Counter of elemens.
    /// </summary>
    private ulong currentNumber = 1;

    /// <summary>
    /// Initializes a new instance of the <see cref="Trie"/> class.
    /// </summary>
    public Trie()
    {
        this.Size = 0;
        this.root = new TrieNode();
        this.root.Number = 0;
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
    public bool Add(List<byte> element)
    {
        TrieNode currentNode = this.root;
        for (int i = 0; i < element.Count; ++i)
        {
            if (!currentNode.NextNode.ContainsKey(element[i]))
            {
                currentNode.NextNode.Add(element[i], new TrieNode());
                ++this.Size;
            }

            currentNode = currentNode.NextNode[element[i]];
        }

        if (currentNode.IsTerminal == false)
        {
            currentNode.IsTerminal = true;
            currentNode.Number = this.currentNumber;
            this.currentNumber++;
            return true;
        }

        return false;
    }

    /// <summary>
    /// Method that checks if the element exists in trie.
    /// </summary>
    /// <param name="element">Element to be checked.</param>
    /// <returns>Whether the element is in trie.</returns>
    public ulong Contains(List<byte> element)
    {
        TrieNode currentNode = this.root;
        foreach (var symbol in element)
        {
            if (!currentNode.NextNode.ContainsKey(symbol))
            {
                return 0;
            }

            currentNode = currentNode.NextNode[symbol];
        }

        return currentNode.Number;
    }

    /// <summary>
    /// A method for removing an element from a trie.
    /// </summary>
    /// <param name="element">The element to be deleted.</param>
    /// <returns>Whether the element has been removed.</returns>
    public bool Remove(List<byte> element)
    {
        if (this.Contains(element) == 0)
        {
            return false;
        }

        this.RemoveElement(element, this.root);
        return true;
    }

    /// <summary>
    /// A recursive method for removing an element.
    /// </summary>
    /// <param name="element">Removal Element.</param>
    /// <param name="currentNode">Pointer to the current trie element.</param>
    /// <returns>Whether an item can be deleted.</returns>
    private bool RemoveElement(List<byte> element, TrieNode currentNode)
    {
        if (element.Count > 0)
        {
            if (this.RemoveElement(element[1..], currentNode.NextNode[element[0]]))
            {
                currentNode.NextNode.Remove(element[0]);
                if (currentNode.NextNode.Count == 0)
                {
                    --this.Size;
                    return true;
                }
            }

            return false;
        }
        else
        {
            currentNode.IsTerminal = false;
            if (currentNode.NextNode.Count == 0)
            {
                --this.Size;
                return true;
            }

            return false;
        }
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
            this.NextNode = new Dictionary<byte, TrieNode>();
        }

        /// <summary>
        /// Gets or sets a dictionary of pointers to the following items.
        /// </summary>
        public Dictionary<byte, TrieNode> NextNode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a variable indicating the end of a line.
        /// </summary>
        public bool IsTerminal { get; set; }

        /// <summary>
        /// Gets or sets number.
        /// </summary>
        public ulong Number { get; set; }
    }
}