/// <summary>
/// A class that implements operand multiplication.
/// </summary>
internal class MultiplicationOperator : Operator
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MultiplicationOperator"/> class.
    /// </summary>
    /// <param name="leftOperand">Reference to left operand.</param>
    /// <param name="rightOperand">Reference to right operand.</param>
    public MultiplicationOperator(Node leftOperand, Node rightOperand)
        : base(leftOperand, rightOperand)
    {
    }

    /// <summary>
    /// A method for calculating the multiplication of operands.
    /// </summary>
    /// <returns>Result of operand multiplication.</returns>
    public override int Calculate()
    {
        Value = LeftOperand.Value * RightOperand.Value;
        return Value;
    }

    /// <inheritdoc/>
    public override void Print()
    {
        Console.Write("(* ");
        LeftOperand.Print();
        Console.Write(" ");
        RightOperand.Print();
        Console.Write(")");
    }
}