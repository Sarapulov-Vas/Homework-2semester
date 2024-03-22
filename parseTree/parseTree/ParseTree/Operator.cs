/// <summary>
/// The class of the node storing the operation, of the parse tree.
/// </summary>
internal abstract class Operator : Node
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Operator"/> class.
    /// </summary>
    /// <param name="leftOperand">Reference to left operand.</param>
    /// <param name="rightOperand">Reference to right operand.</param>
    public Operator(Node leftOperand, Node rightOperand)
    {
        LeftOperand = leftOperand;
        RightOperand = rightOperand;
    }

    /// <summary>
    /// Gets left operand reference.
    /// </summary>s
    public Node LeftOperand { get; private set; }

    /// <summary>
    /// Gets right operand reference.
    /// </summary>
    public Node RightOperand { get; private set; }

    /// <summary>
    /// Method for calculating the value of a vertex.
    /// </summary>
    /// <returns>Current value.</returns>
    public abstract int Calculate();
}