internal class BinaryHeap
{
    private List<(int currentVertex, int adjacentVertex, int scale)> heap =
        new List<(int currentVertex, int adjacentVertex, int scale)>();

    public void Insert(int firstVertex, int secondVertex, int scale)
    {
        heap.Add((firstVertex, secondVertex, scale));
        var i = heap.Count - 1;
        while (i > 0 && heap[i].scale > heap[(i - 1) / 2].scale)
        {
            (heap[i], heap[(i - 1) / 2]) = (heap[(i - 1) / 2], heap[i]);
            i = (i - 1) / 2;
        }
    }

    public (int currentVertex, int adjacentVertex, int scale) GetMax()
    {
        var max = heap[0];
        heap[0] = heap[^1];
        heap.RemoveAt(heap.Count - 1);
        var i = 0;
        while ((2 * i) + 1 < heap.Count)
        {
            var j = (2 * i) + 1;
            if ((2 * i) + 2 < heap.Count && heap[(2 * i) + 2].scale > heap[j].scale)
            {
                j = (2 * i) + 2;
            }

            if (heap[i].scale >= heap[j].scale)
            {
                break;
            }
            else
            {
                (heap[i], heap[j]) = (heap[j], heap[i]);
                i = j;
            }
        }

        return max;
    }
}