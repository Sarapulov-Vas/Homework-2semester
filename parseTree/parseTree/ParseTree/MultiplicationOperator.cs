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
        this.Value = this.LeftOperand.Value * this.RightOperand.Value;
        return this.Value;
    }

    /// <inheritdoc/>
    public override string Print()
    {
        Console.Write("(* ");
        var leftexpression = this.LeftOperand.Print();
        Console.Write(" ");
        var rightexpression = this.RightOperand.Print();
        Console.Write(")");
        var printexpression = "(* " + leftexpression + " " + rightexpression + ")";
        return printexpression;
    }
}