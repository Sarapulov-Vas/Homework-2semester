/// <summary>
/// The class realizing the addition operator.
/// </summary>
internal class AdditionOperator : Operator
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AdditionOperator"/> class.
    /// </summary>
    /// <param name="leftOperand">Reference to left operand.</param>
    /// <param name="rightOperand">Reference to right operand.</param>
    public AdditionOperator(Node leftOperand, Node rightOperand)
        : base(leftOperand, rightOperand)
    {
    }

    /// <summary>
    /// Method of calculating operand addition.
    /// </summary>
    /// <returns>Result of operand addition.</returns>
    public override int Calculate()
    {
        Value = LeftOperand.Value + RightOperand.Value;
        return Value;
    }

    /// <inheritdoc/>
    public override void Print()
    {
        Console.Write("(+ ");
        LeftOperand.Print();
        Console.Write(" ");
        RightOperand.Print();
        Console.Write(")");
    }
}