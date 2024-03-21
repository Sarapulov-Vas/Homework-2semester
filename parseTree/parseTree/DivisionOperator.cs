/// <summary>
/// A class that implements operand division.
/// </summary>
internal class DivisionOperator : Operator
{
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
        if (Math.Abs(RightOperand.Value) < 1e-8)
        {
            throw new DivideByZeroException();
        }

        Value = LeftOperand.Value / RightOperand.Value;
        return Value;
    }

    public override void Print()
    {
        Console.Write("(/ ");
        LeftOperand.Print();
        Console.Write(" ");
        RightOperand.Print();
        Console.Write(")");
    }
}