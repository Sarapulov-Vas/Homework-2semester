/// <summary>
/// A class that implements operand division.
/// </summary>
internal class DivisionOperator : Operator
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DivisionOperator"/> class.
    /// </summary>
    /// <param name="leftOperand">Reference to left operand.</param>
    /// <param name="rightOperand">Reference to right operand.</param>
    public DivisionOperator(Node leftOperand, Node rightOperand)
        : base(leftOperand, rightOperand)
    {
    }

    /// <summary>
    /// A method for calculating the division of operands.
    /// </summary>
    /// <returns>Result of operand division.</returns>
    public override int Calculate()
    {
        if (this.RightOperand.Value == 0)
        {
            throw new DivideByZeroException();
        }

        this.Value = this.LeftOperand.Value / this.RightOperand.Value;
        return this.Value;
    }

    /// <inheritdoc/>
    public override string Print()
    {
        Console.Write("(/ ");
        var leftexpression = this.LeftOperand.Print();
        Console.Write(" ");
        var rightexpression = this.RightOperand.Print();
        Console.Write(")");
        var printexpression = "(/ " + leftexpression + " " + rightexpression + ")";
        return printexpression;
    }
}