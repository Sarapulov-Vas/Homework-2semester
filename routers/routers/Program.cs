internal class Program
{
    private static void Main(string[] args)
    {
        var net = new Net();
        net.AddEdge(1, 2, 10);
        net.AddEdge(1, 3, 5);
        net.AddEdge(2, 3, 1);
        net.AddEdge(3, 4, 7);
        net.AddEdge(4, 5, 12);
        net.AddEdge(3, 5, 15);
        net.AddEdge(1, 5, 20);
        net.AddEdge(2, 4, 2);
        var result = new Net();
        var queue = new BinaryHeap();
        foreach (var element in net.GetListOfAdjacentVertices(1))
        {
            queue.Insert(1, element.vertex, element.scale);
        }

        while (net.CountOfVertex != result.CountOfVertex)
        {
            var edgeToAdd = queue.GetMax();
            if (!result.ContainsVertex(edgeToAdd.adjacentVertex))
            {
                result.AddEdge(edgeToAdd.currentVertex, edgeToAdd.adjacentVertex, edgeToAdd.scale);
                foreach (var element in net.GetListOfAdjacentVertices(edgeToAdd.adjacentVertex))
                {
                    if (!result.ContainsVertex(element.vertex))
                    {
                        queue.Insert(edgeToAdd.adjacentVertex, element.vertex, element.scale);
                    }
                }
            }
        }
    }
}