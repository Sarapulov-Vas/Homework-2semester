namespace SkipList;
using System.Collections;

/// <summary>
/// Class implementing skip list.
/// </summary>
/// <typeparam name="T">Type of elemnts.</typeparam>
public class SkipList<T> : IList<T>
    where T : IComparable<T>
{
    private readonly Random rnd = new ();

    private Level? currentLevel;

    private int count;

    /// <summary>
    /// Initializes a new instance of the <see cref="SkipList"/> class.
    /// </summary>
    public SkipList()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SkipList"/> class.
    /// </summary>
    /// <param name="orginList">A list to convert to a skip list.</param>
    public SkipList(List<T> orginList)
    {
        foreach (var element in orginList)
        {
            this.Add(element);
        }
    }

    /// <summary>
    /// Gets the number of items at the bottom level of the skip list.
    /// </summary>
    public int Count => this.count;

    /// <summary>
    /// Gets a value indicating whether this collection is read-only.
    /// </summary>
    public bool IsReadOnly => false;

    /// <summary>
    /// Skip list indexer.
    /// </summary>
    /// <param name="index">Index.</param>
    /// <returns>Element of skip list.</returns>
    /// <exception cref="IndexOutOfRangeException">Exception when the index exceeds the skip list boundary.</exception>
    /// <exception cref="NotSupportedException">Exception when attempting to modify existing elements.</exception>
    public T this[int index]
    {
        get
        {
            if (index >= this.count)
            {
                throw new IndexOutOfRangeException("Index out of range.");
            }

            var level = this.currentLevel;
            while (level.DownLevel != null)
            {
                level = level.DownLevel;
            }

            var node = this.currentLevel.List;
            for (int i = 0; i < index; ++i)
            {
                node = node.Next;
            }

            return node.Value;
        }

        set
        {
            throw new NotSupportedException("Non-modifiable elements.");
        }
    }

    /// <summary>
    /// A method for adding items to a skip list.
    /// </summary>
    /// <param name="item">Element to add.</param>
    public void Add(T item)
    {
        if (this.currentLevel == null)
        {
            this.currentLevel = new Level(item);
        }
        else
        {
            this.AddNode(this.currentLevel, this.currentLevel.List, item);
            while (this.currentLevel.Count > 1)
            {
                this.currentLevel = this.BuildLevel(this.currentLevel);
            }
        }

        this.count++;
    }

    /// <summary>
    /// A method to remove all items from the skip list.
    /// </summary>
    public void Clear()
    {
        this.count = 0;
        this.currentLevel = null;
    }

    /// <summary>
    /// Method that checks if an item is contained in the skip list.
    /// </summary>
    /// <param name="item">Element to check.</param>
    /// <returns>Whether the skip list contains an element.</returns>
    public bool Contains(T item)
    {
        if (this.currentLevel == null)
        {
            return false;
        }

        if (this.FindItem(this.currentLevel.List, item) != null)
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// Method that copies the specified range of elements into an array.
    /// </summary>
    /// <param name="array">Array into which the copied elements will be copied.</param>
    /// <param name="arrayIndex">The index from which the items will be copied.</param>
    /// <exception cref="ArgumentException">Exception when it is impossible to copy elements into an array.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Exception in case the index goes beyond the skip list boundaries.</exception>
    public void CopyTo(T[] array, int arrayIndex)
    {
        if (array == null)
        {
            throw new ArgumentException("Null array");
        }

        if (this.currentLevel == null || arrayIndex < 0 || arrayIndex >= this.count)
        {
            throw new ArgumentOutOfRangeException("Index out of range.");
        }

        if (array.Length < this.count - arrayIndex)
        {
            throw new ArgumentException("Insufficient array size.");
        }

        var currentLevel = this.currentLevel;
        while (currentLevel.DownLevel != null)
        {
            currentLevel = currentLevel.DownLevel;
        }

        var currentNode = currentLevel.List;
        for (int i = 0; i < arrayIndex - 1; ++i)
        {
            currentNode = currentNode.Next;
        }

        for (int i = 0; i < this.count - arrayIndex; i++)
        {
            array[i] = currentNode.Value;
            currentNode = currentNode.Next;
        }
    }

    /// <summary>
    /// Method for obtaining an enumerator.
    /// </summary>
    /// <returns>Enumerator.</returns>
    public IEnumerator<T> GetEnumerator() => new Enumerator(this.currentLevel);

    /// <summary>
    /// A method for finding the index of an item in a skip list.
    /// </summary>
    /// <param name="item">Item.</param>
    /// <returns>Index of element.</returns>
    public int IndexOf(T item)
    {
        if (this.currentLevel == null)
        {
            return -1;
        }

        var currentLevel = this.currentLevel;
        while (currentLevel.DownLevel != null)
        {
            currentLevel = currentLevel.DownLevel;
        }

        var index = 0;
        var currentNode = currentLevel.List;
        while (currentNode.Next != null)
        {
            if (currentNode.Equals(item))
            {
                return index;
            }

            index++;
            currentNode = currentNode.Next;
        }

        return -1;
    }

    /// <summary>
    /// Method of insertion into skip list (Not implemented because it doesn't make sense).
    /// </summary>
    /// <param name="index">Index.</param>
    /// <param name="item">Item.</param>
    /// <exception cref="NotSupportedException">Exception when there is no implementation of the method :(.</exception>
    public void Insert(int index, T item)
    {
        throw new NotSupportedException();
    }

    /// <summary>
    /// Method to remove an item from the skip list.
    /// </summary>
    /// <param name="item">Element.</param>
    /// <returns>Whether the element has been removed.</returns>
    public bool Remove(T item)
    {
        if (this.currentLevel == null)
        {
            return false;
        }

        this.count--;
        return this.RemoveElement(this.currentLevel, item);
    }

    /// <summary>
    /// Method for deleting an element by index.
    /// </summary>
    /// <param name="index">Index.</param>
    public void RemoveAt(int index)
    {
        this.Remove(this[index]);
    }

    /// <summary>
    /// Method for obtaining an enumerator.
    /// </summary>
    /// <returns>Enumerator.</returns>
    IEnumerator IEnumerable.GetEnumerator() => new Enumerator(this.currentLevel);

    private bool RemoveElement(Level currentLevel, T item)
    {
        if (currentLevel.List.Value.Equals(item))
        {
            currentLevel.RemoveFirst(currentLevel);
            return true;
        }

        var isDelaet = false;
        while (currentLevel != null)
        {
            currentLevel.Remove(item);
            currentLevel = currentLevel.DownLevel;
        }

        return isDelaet;
    }

    private ListNode? FindItem(ListNode currentNode, T item)
    {
        var node = currentNode;
        while (node != null && item.CompareTo(node.Value) > 0)
        {
            node = node.Next;
        }

        if (node == null)
        {
            return null;
        }

        if (item.Equals(node.Value))
        {
            return node;
        }

        if (node.Down != null)
        {
            return this.FindItem(node.Down, item);
        }

        return null;
    }

    private ListNode? AddNode(Level currentLevel, ListNode currentNode, T item)
    {
        if (item.CompareTo(currentNode.Value) < 0)
        {
            if (currentLevel.DownLevel != null)
            {
                return currentLevel.AddFirst(this.AddNode(currentLevel.DownLevel, currentNode, item), item);
            }
            else
            {
                return currentLevel.AddFirst(null, item);
            }
        }

        while (currentNode.Next != null && item.CompareTo(currentNode.Next.Value) > 0)
        {
            currentNode = currentNode.Next;
        }

        ListNode? downNode = null;
        if (currentNode.Down != null && currentLevel.DownLevel != null)
        {
            downNode = this.AddNode(currentLevel.DownLevel, currentNode.Down, item);
        }

        if (downNode != null || currentLevel.DownLevel == null)
        {
            var newNode = currentLevel.AddAfter(currentNode, downNode, item);
            if (this.rnd.NextDouble() < 0.5)
            {
                return newNode;
            }

            return null;
        }

        return null;
    }

    private Level BuildLevel(Level downLevel)
    {
        var currentLevel = new Level(downLevel.List, downLevel);
        var currentNode = downLevel.List.Next;
        while (currentNode != null)
        {
            if (this.rnd.NextDouble() < 0.5)
            {
                currentLevel.AddLast(currentNode.Value, currentNode);
            }

            currentNode = currentNode.Next;
        }

        return currentLevel;
    }

    private class ListNode
    {
        public ListNode(ListNode? next, ListNode? down, T value)
        {
            this.Next = next;
            this.Down = down;
            this.Value = value;
        }

        public T Value { get; set; }

        public ListNode? Next { get; set; }

        public ListNode? Down { get; }
    }

    private class Level
    {
        private ListNode? lastNode;

        public Level(T item)
        {
            this.List = new ListNode(null, null, item);
            this.lastNode = this.List;
            this.Count++;
        }

        public Level(ListNode head, Level downLevel)
        {
            this.List = new ListNode(null, head, head.Value);
            this.lastNode = this.List;
            this.Count++;
            this.DownLevel = downLevel;
        }

        public int Count { get; set; }

        public ListNode? List { get; private set; }

        public Level? DownLevel { get; }

        public ListNode RemoveFirst(Level currentLevel)
        {
            if (currentLevel.DownLevel != null)
            {
                var downNode = this.RemoveFirst(currentLevel.DownLevel);
                if (currentLevel.List.Next == null)
                {
                    currentLevel.List = new ListNode(null, downNode.Down, downNode.Value);
                    return currentLevel.List;
                }

                if (!downNode.Value.Equals(currentLevel.List.Next.Value))
                {
                    var tmp = new ListNode(currentLevel.List.Next, downNode.Down, downNode.Value);
                    currentLevel.List = tmp;
                }
                else
                {
                    currentLevel.List = currentLevel.List.Next;
                }
            }
            else
            {
                currentLevel.List = currentLevel.List.Next;
                currentLevel.Count--;
            }

            return currentLevel.List;
        }

        public bool Remove(T item)
        {
            var currentNode = this.List;
            while (currentNode.Next != null && item.CompareTo(currentNode.Next.Value) > 0)
            {
                currentNode = currentNode.Next;
            }

            if (currentNode.Next != null)
            {
                currentNode.Next = currentNode.Next.Next;
                this.Count--;
                return true;
            }

            return false;
        }

        public ListNode AddAfter(ListNode? node, ListNode? down, T value)
        {
            this.Count++;
            var tmp = node.Next;
            node.Next = new ListNode(tmp, down, value);
            if (tmp == null)
            {
                this.lastNode = node.Next;
            }

            return node.Next;
        }

        public ListNode AddFirst(ListNode? down, T value)
        {
            var tmp = new ListNode(this.List, down, value);
            this.List = tmp;
            this.Count++;
            return tmp;
        }

        public void AddLast(T value, ListNode? down)
        {
            this.Count++;
            if (this.List == null)
            {
                this.List = new ListNode(null, down, value);
                this.lastNode = this.List;
            }
            else
            {
                this.lastNode.Next = new ListNode(null, down, value);
                this.lastNode = this.lastNode.Next;
            }
        }
    }

    private class Enumerator : IEnumerator<T>
    {
        private readonly ListNode? head;

        private ListNode? current;

        public Enumerator(Level level)
        {
            if (level == null)
            {
                this.head = null;
                this.current = null;
            }
            else
            {
                var currentLevel = level;
                while (currentLevel.DownLevel != null)
                {
                    currentLevel = currentLevel.DownLevel;
                }

                this.head = currentLevel.List;
                this.current = this.head;
            }
        }

        public object Current
        {
            get
            {
                if (this.current == null)
                {
                    throw new InvalidOperationException("Skip list is empty.");
                }
                else
                {
                    return this.current;
                }
            }
        }

        T IEnumerator<T>.Current
        {
            get
            {
                if (this.current == null)
                {
                    throw new InvalidOperationException("Skip list is empty.");
                }
                else
                {
                    return this.current.Value;
                }
            }
        }

        public bool MoveNext()
        {
            if (this.current == null || this.head == null)
            {
                throw new InvalidOperationException("Skip list is empty.");
            }

            if (!this.current.Value.Equals(this.head.Value))
            {
                this.current = this.current.Next;
            }

            return this.current != null;
        }

        public void Reset()
        {
            this.current = this.head;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
