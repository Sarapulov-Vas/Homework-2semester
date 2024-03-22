/// <summary>
/// The class of the vertex of the parse tree.
/// </summary>
internal abstract class Node
{
    /// <summary>
    /// Gets or sets value of the vertex.
    /// </summary>
    public int Value { get; protected set; }

    /// <summary>
    /// Value output.
    /// </summary>
    public abstract void Print();
}