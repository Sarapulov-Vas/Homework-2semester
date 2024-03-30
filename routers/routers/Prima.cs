/// <summary>
/// A class that implements the prim algorithm.
/// </summary>
public class Prima
{
    /// <summary>
    /// A method to run the prima algorithm.
    /// </summary>
    /// <param name="currentNet">Initial graph.</param>
    /// <returns>Graph after applying the prim algorithm.</returns>
    public static Net Start(Net currentNet)
    {
        var result = new Net();
        var queue = new BinaryHeap();
        foreach (var element in currentNet.GetListOfAdjacentVertices(1))
        {
            queue.Insert(1, element.vertex, element.weight);
        }

        while (currentNet.CountOfVertex != result.CountOfVertex)
        {
            var edgeToAdd = queue.GetMax();
            if (!result.ContainsVertex(edgeToAdd.adjacentVertex))
            {
                result.AddEdge(edgeToAdd.currentVertex, edgeToAdd.adjacentVertex, edgeToAdd.weight);
                foreach (var element in currentNet.GetListOfAdjacentVertices(edgeToAdd.adjacentVertex))
                {
                    if (!result.ContainsVertex(element.vertex))
                    {
                        queue.Insert(edgeToAdd.adjacentVertex, element.vertex, element.weight);
                    }
                }
            }
        }

        return result;
    }
}