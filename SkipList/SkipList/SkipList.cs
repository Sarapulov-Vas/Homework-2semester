using System.Collections;
using System.ComponentModel;
using System.Security.Principal;

namespace SkipList;

public class SkipList<T> : IList<T>
    where T : IComparable<T>
{
    private readonly Random rnd = new ();

    private Level? currentLevel;

    private int count;

    public SkipList()
    {
    }

    public SkipList(List<T> orginList)
    {
        foreach (var element in orginList)
        {
            Add(element);
        }
    }

    public T this[int index]
    {
        get
        {
            if (index >= count)
            {
                throw new IndexOutOfRangeException("Index out of range.");
            }

            var level = currentLevel;
            while (level.DownLevel != null)
            {
                level = level.DownLevel;
            }

            var node = currentLevel.List;
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

    public int Count => count;

    public bool IsReadOnly => true;

    public void Add(T item)
    {
        if (currentLevel == null)
        {
            currentLevel = new Level(item);
        }
        else
        {
            AddNode(currentLevel, currentLevel.List, item);
            while (currentLevel.Count > 1)
            {
                currentLevel = BuildLevel(currentLevel);
            }
        }

        count++;
    }

    public void Clear()
    {
        count = 0;
        currentLevel = null;
    }

    public bool Contains(T item)
    {
        if (currentLevel == null)
        {
            return false;
        }

        if (FindItem(currentLevel.List, item) != null)
        {
            return true;
        }

        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        if (array == null)
        {
            throw new ArgumentException("Null array");
        }

        if (this.currentLevel == null || arrayIndex < 0 || arrayIndex >= count)
        {
            throw new ArgumentOutOfRangeException("Index out of range.");
        }

        if (array.Length < count - arrayIndex)
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

        for (int i = 0; i < count - arrayIndex; i++)
        {
            array[i] = currentNode.Value;
            currentNode = currentNode.Next;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

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

    public void Insert(int index, T item)
    {
        throw new NotSupportedException();
    }

    public bool Remove(T item)
    {
        if (currentLevel == null)
        {
            return false;
        }

        count--;
        return RemoveElement(currentLevel, item);
    }

    public void RemoveAt(int index)
    {
        Remove(this[index]);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }

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
        while (currentNode != null && item.CompareTo(currentNode.Value) > 0)
        {
            currentNode = currentNode.Next;
        }

        if (currentNode == null)
        {
            return null;
        }

        if (item.Equals(currentNode.Value))
        {
            return currentNode;
        }

        if (currentNode.Down != null)
        {
            return FindItem(currentNode.Down, item);
        }

        return null;
    }

    private ListNode? AddNode(Level currentLevel, ListNode currentNode, T item)
    {
        if (item.CompareTo(currentNode.Value) < 0)
        {
            if (currentLevel.DownLevel != null)
            {
                return currentLevel.AddFirst(AddNode(currentLevel.DownLevel, currentNode, item), item);
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
        if (currentLevel.DownLevel != null)
        {
            downNode = AddNode(currentLevel.DownLevel, currentNode.Down, item);
        }

        if (downNode != null || currentLevel.DownLevel == null)
        {
            var newNode = currentLevel.AddAfter(currentNode, downNode, item);
            if (rnd.NextDouble() < 0.5)
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
            if (rnd.NextDouble() < 0.5)
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
            Next = next;
            Down = down;
            Value = value;
        }

        public T Value { get; set; }

        public ListNode? Next { get; set; }

        public ListNode? Down { get; }
    }

    private class Level
    {
        public Level(T item)
        {
            List = new ListNode(null, null, item);
            lastNode = List;
            Count++;
        }

        public Level(ListNode head, Level downLevel)
        {
            List = new ListNode(null, head, head.Value);
            lastNode = List;
            Count++;
            DownLevel = downLevel;
        }

        public int Count { get; set; }

        public ListNode? List { get; private set; }

        public Level? DownLevel { get; }

        private ListNode? lastNode;

        public ListNode RemoveFirst(Level currentLevel)
        {
            if (currentLevel.DownLevel != null)
            {
                var downNode = RemoveFirst(currentLevel.DownLevel);
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
            var currentNode = List;
            while (currentNode.Next != null && item.CompareTo(currentNode.Next.Value) > 0)
            {
                currentNode = currentNode.Next;
            }

            if (currentNode.Next != null)
            {
                currentNode.Next = currentNode.Next.Next;
                Count--;
                return true;
            }

            return false;
        }

        public ListNode AddAfter(ListNode? node, ListNode? down, T value)
        {
            Count++;
            var tmp = node.Next;
            node.Next = new ListNode(tmp, down, value);
            if (tmp == null)
            {
                lastNode = node.Next;
            }

            return node.Next;
        }

        public ListNode AddFirst(ListNode? down, T value)
        {
            var tmp = new ListNode(List, down, value);
            List = tmp;
            Count++;
            return tmp;
        }

        public void AddLast(T value, ListNode? down)
        {
            Count++;
            if (List == null)
            {
                List = new ListNode(null, down, value);
                lastNode = List;
            }
            else
            {
                lastNode.Next = new ListNode(null, down, value);
                lastNode = lastNode.Next;
            }
        }
    }
}
