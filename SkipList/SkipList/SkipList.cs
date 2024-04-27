using System.Collections;

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

    public bool IsReadOnly => throw new NotImplementedException();

    public void Add(T item)
    {
        if (currentLevel == null)
        {
            currentLevel = new Level();
            currentLevel.AddLast(item, null);
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
        throw new NotImplementedException();
    }

    public bool Contains(T item)
    {
        throw new NotImplementedException();
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    public int IndexOf(T item)
    {
        throw new NotImplementedException();
    }

    public void Insert(int index, T item)
    {
        throw new NotSupportedException();
    }

    public bool Remove(T item)
    {
        throw new NotImplementedException();
    }

    public void RemoveAt(int index)
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }

    private ListNode? AddNode(Level currentLevel, ListNode currentNode, T item)
    {
        if (currentLevel.List.Value.GetHashCode() > item.GetHashCode())
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
        public Level()
        {
        }

        public Level(ListNode head, Level downLevel)
        {
            List = new ListNode(null, head, head.Value);
            lastNode = List;
            Count++;
            DownLevel = downLevel;
        }

        public int Count { get; private set; }

        public ListNode? List { get; private set; }

        public Level DownLevel { get; }

        private ListNode? lastNode;

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
