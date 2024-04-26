/// <summary>
/// A class that implements a graph representing the network topology.
/// </summary>
public class Net
{
    private readonly Dictionary<int, List<(int vertex, int weight)>> graph = new Dictionary<int, List<(int vetrex, int weight)>>();

    /// <summary>
    /// Gets the number of vertices in a graph.
    /// </summary>
    public int CountOfVertex { get; private set; }

    /// <summary>
    /// Gets the number of edges in the graph.
    /// </summary>
    public int CountOfEdges { get; private set; }

    /// <summary>
    /// A method for adding an edge to a graph.
    /// </summary>
    /// <param name="firstVertex">First vertex.</param>
    /// <param name="secondVertex">Second vertex.</param>
    /// <param name="weight">Weight of edge.</param>
    public void AddEdge(int firstVertex, int secondVertex, int weight)
    {
        AddPareOfVertices(firstVertex, secondVertex, weight);
        AddPareOfVertices(secondVertex, firstVertex, weight);
        ++CountOfEdges;
    }

    /// <summary>
    /// A method for obtaining adjacent vertices to the current vertex.
    /// </summary>
    /// <param name="vertex">Current vertrx.</param>
    /// <returns>A list of adjacent vertices.</returns>
    public List<(int vertex, int weight)> GetListOfAdjacentVertices(int vertex) => return graph[vertex];


    /// <summary>
    /// A method for verifying a vertex in a graph.
    /// </summary>
    /// <param name="vertex">Vertex.</param>
    /// <returns>Whether the vertex is contained in the graph.</returns>
    public bool ContainsVertex(int vertex) => return graph.ContainsKey(vertex);

    private void AddPareOfVertices(int Vertex1, int Vertex2, int weight)
    {
        if (!graph.ContainsKey(Vertex1))
        {
            graph.Add(Vertex1, new List<(int vertex, int weight)>());
            ++CountOfVertex;
        }

        graph[Vertex1].Add((Vertex2, weight));
    }
}