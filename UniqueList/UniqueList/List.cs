/// <summary>
/// A class that implements a linked list.
/// </summary>
internal class List
{
    /// <summary>
    /// Pointer to the beginning of the list.
    /// </summary>
    private Node? head = null;

    /// <summary>
    /// Gets number of items in the list.
    /// </summary>
    public int Count { get; private set; }

    /// <summary>
    /// A method for adding an item to a linked list.
    /// </summary>
    /// <param name="value">The value to be added to the list.</param>
    public void Add(int value)
    {
        ++this.Count;
        var tmp = new Node(value, this.head);
        this.head = tmp;
    }

    /// <summary>
    /// Pop method.
    /// </summary>
    /// <returns>Pop element value.</returns>
    /// <exception cref="EmptyListException">Error in case of deleting an item from an empty list.</exception>
    public int Pop()
    {
        if (this.Count == 0)
        {
            throw new EmptyListException("Cannot pop an item from an empty list.");
        }

        --this.Count;
        var prev = this.head;
        this.head = prev.Next;
        return prev.Value;
    }

    /// <summary>
    /// Method for deleting an element by index.
    /// </summary>
    /// <param name="index">Element index.</param>
    public void Delate(int index)
    {
        this.IndexIsCorrect(index);

        --this.Count;
        if (index == 0)
        {
            this.Pop();
            return;
        }

        var prev = this.GetElementByIndex(index - 1);
        prev.Next = prev.Next.Next;
    }

    /// <summary>
    /// Changing the value of a list item by index.
    /// </summary>
    /// <param name="index">The index of the element to be modified.</param>
    /// <param name="newValue">The new value of the element.</param>
    public void ChangeElement(int index, int newValue)
    {
        this.IndexIsCorrect(index);
        this.GetElementByIndex(index).Value = newValue;
    }

    /// <summary>
    /// Method of getting element value by index.
    /// </summary>
    /// <param name="index">Element index.</param>
    /// <returns>Element value.</returns>
    public int GetValue(int index)
    {
        return this.GetElementByIndex(index).Value;
    }

    private void IndexIsCorrect(int index)
    {
        if (index >= this.Count || index < 0)
        {
            throw new IndexOutOfRangeException();
        }
    }

    private Node GetElementByIndex(int index)
    {
        this.IndexIsCorrect(index);
        var currentElement = this.head;
        for (int i = 0; i < index; ++i)
        {
            currentElement = currentElement.Next;
        }

        return currentElement;
    }

    /// <summary>
    /// A class that implements an element of a linked list.
    /// </summary>
    protected class Node
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Node"/> class.
        /// </summary>
        /// <param name="value">Node value.</param>
        /// <param name="next">Pointer to next element.</param>
        public Node(int value, Node? next)
        {
            this.Value = value;
            this.Next = next;
        }

        /// <summary>
        /// Gets or sets the value stored in the element.
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Gets or sets pointer to the next element.
        /// </summary>
        public Node? Next { get; set; }
    }
}