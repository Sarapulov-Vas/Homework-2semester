/// <summary>
/// A class that implements the subtraction operator.
/// </summary>
internal class SubtractionOperator : Operator
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SubtractionOperator"/> class.
    /// </summary>
    /// <param name="leftOperand">Reference to left operand.</param>
    /// <param name="rightOperand">Reference to right operand.</param>
    public SubtractionOperator(Node leftOperand, Node rightOperand)
        : base(leftOperand, rightOperand)
    {
    }

    /// <summary>
    /// method of calculating the operand subtraction.
    /// </summary>
    /// <returns>The result of operand subtraction.</returns>
    public override int Calculate()
    {
        Value = LeftOperand.Value - RightOperand.Value;
        return Value;
    }

    /// <inheritdoc/>
    public override void Print()
    {
        Console.Write("(- ");
        LeftOperand.Print();
        Console.Write(" ");
        RightOperand.Print();
        Console.Write(")");
    }
}