/// <summary>
/// A class that implements a priority queue.
/// </summary>
internal class BinaryHeap
{
    private readonly List<(int currentVertex, int adjacentVertex, int weight)> heap =
        new List<(int currentVertex, int adjacentVertex, int weight)>();

    /// <summary>
    /// A method for adding a graph edge to a queue.
    /// </summary>
    /// <param name="firstVertex">First vertex.</param>
    /// <param name="secondVertex">Second vertex.</param>
    /// <param name="weight">weight of edge.</param>
    public void Insert(int firstVertex, int secondVertex, int weight)
    {
        heap.Add((firstVertex, secondVertex, weight));
        var i = heap.Count - 1;
        while (i > 0 && heap[i].weight > heap[(i - 1) / 2].weight)
        {
            (heap[i], heap[(i - 1) / 2]) = (heap[(i - 1) / 2], heap[i]);
            i = (i - 1) / 2;
        }
    }

    /// <summary>
    /// A method for obtaining the maximum element from a queue.
    /// </summary>
    /// <returns>The element with the maximum weight.</returns>
    public (int currentVertex, int adjacentVertex, int weight) GetMax()
    {
        var max = heap[0];
        heap[0] = heap[^1];
        heap.RemoveAt(heap.Count - 1);
        var i = 0;
        while ((2 * i) + 1 < heap.Count)
        {
            var j = (2 * i) + 1;
            if ((2 * i) + 2 < heap.Count && heap[(2 * i) + 2].weight > heap[j].weight)
            {
                j = (2 * i) + 2;
            }

            if (heap[i].weight >= heap[j].weight)
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