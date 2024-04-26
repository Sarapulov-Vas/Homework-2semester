using System.Collections;

namespace SkipList;

public class SkipList<T> : IList<T>
{
    private Level? currentLevel;
    private readonly Random rnd = new ();

    private int count;

    public SkipList()
    {
    }

    public SkipList(List<T> orginList)
    {
        currentLevel = new Level();
        var currentArray = orginList.ToArray();
        Array.Sort(currentArray);
        foreach (var element in currentArray)
        {
            currentLevel.AddLast(element, null);
            count++;
        }

        while (currentLevel.Count > 1)
        {
            currentLevel = BuildLevel(currentLevel);
        }
    }

    public T this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
        throw new NotImplementedException();
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
        while (currentNode.Next != null && currentNode.Next.Value.GetHashCode() < item.GetHashCode())
        {
            currentNode = currentNode.Next;
        }

        if (currentLevel.DownLevel != null)
        {
            if (rnd.NextDouble() < 0.5)
            {
                return currentLevel.AddAfter(currentNode, AddNode(currentLevel.DownLevel, currentNode, item), item);
            }

            return null;
        }
        else
        {
            return currentLevel.AddAfter(currentNode, null, item);
        }
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

        public ListNode? Down { get; set; }
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
