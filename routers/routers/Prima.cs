using System.Text;


/// <summary>
/// A class that implements the prim algorithm.
/// </summary>
public static class Prima
{
    /// <summary>
    /// A method to run the prima algorithm.
    /// </summary>
    /// <param name="currentNet">Initial graph.</param>
    /// <returns>Graph after applying the prim algorithm.</returns>
    public static void Start(string NetPath, string resultPath)
    {
        var currentNet = ParseFile(NetPath);
        var result = new Net();
        var queue = new BinaryHeap();
        foreach (var element in currentNet.GetListOfAdjacentVertices(1))
        {
            queue.Insert(1, element.vertex, element.weight);
        }

        while (currentNet.CountOfVertex != result.CountOfVertex && !queue.IsEmpty())
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

        if (currentNet.CountOfVertex != result.CountOfVertex)
        {
            throw new UnboundGraphException();
        }

        WriteResult(result, resultPath);
    }

    private static Net ParseFile(string path)
    {
        var net = new Net();
        var FileText = File.ReadAllLines(path);
        foreach (var line in FileText)
        {
            var splitLine = line.Split(':');
            if (int.TryParse(splitLine[0], out int firstVertex) && splitLine.Length == 2)
            {
                foreach (var vertexWithWeight in splitLine[1].Split(','))
                {
                    var splitVertexWeight = vertexWithWeight.Split(' ');
                    if (int.TryParse(splitVertexWeight[1], out int secondVertex) && splitVertexWeight[2][0] == '('
                        && splitVertexWeight[2][^1] == ')' && int.TryParse(splitVertexWeight[2][1..^1], out int weight))
                    {
                        net.AddEdge(firstVertex, secondVertex, weight);
                    }
                    else
                    {
                        throw new IncorrectFileException();
                    }
                }
            }
            else
            {
                throw new IncorrectFileException();
            }
        }

        return net;
    }

    private static void WriteResult(Net result, string resultPath)
    {
        var resultString = new List<string>();
        var currentString = new StringBuilder();
        var listOfVertexPairs = new List<(int, int)>();
        for (int i = 1; i < result.CountOfVertex + 1; ++i)
        {
            var adjacentVertices = result.GetListOfAdjacentVertices(i);
            currentString.Append($"{i}:");
            foreach (var element in adjacentVertices)
            {
                if (!listOfVertexPairs.Contains((element.vertex, i)))
                {
                    listOfVertexPairs.Add((i, element.vertex));
                    currentString.Append($" {element.vertex} ({element.weight}),");
                }
            }

            if (currentString.Length > 2)
            {
                resultString.Add(currentString.ToString()[..^1]);
            }

            currentString.Clear();
        }

        File.WriteAllLines(resultPath, resultString);
    }
}