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
        if (Math.Abs(this.RightOperand.Value) < 1e-8)
        {
            throw new DivideByZeroException();
        }

        this.Value = this.LeftOperand.Value / this.RightOperand.Value;
        return this.Value;
    }

    /// <inheritdoc/>
    public override void Print()
    {
        Console.Write("(/ ");
        this.LeftOperand.Print();
        Console.Write(" ");
        this.RightOperand.Print();
        Console.Write(")");
    }
}