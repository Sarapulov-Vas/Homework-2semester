internal class Net
{
    private readonly Dictionary<int, List<(int vertex, int scale)>> graph = new Dictionary<int, List<(int vetrex, int scale)>>();

    public int CountOfVertex { get; private set; }

    public int CountOfEdges { get; private set; }

    public void AddEdge(int firstVertex, int secondVertex, int scale)
    {
        AddPareOfVertices(firstVertex, secondVertex, scale);
        AddPareOfVertices(secondVertex, firstVertex, scale);
        ++CountOfEdges;
    }

    public List<(int vertex, int scale)> GetListOfAdjacentVertices(int vertex)
    {
        return graph[vertex];
    }

    public bool ContainsVertex(int vertex)
    {
        return graph.ContainsKey(vertex);
    }

    private void AddPareOfVertices(int firstVertex, int secondVertex, int scale)
    {
        if (!graph.ContainsKey(firstVertex))
        {
            graph.Add(firstVertex, new List<(int vertex, int scale)>());
            ++CountOfVertex;
        }

        graph[firstVertex].Add((secondVertex, scale));
    }
}