/// <summary>
/// A class that implements the subtraction operator.
/// </summary>
internal class SubtractionOperator : Operator
{
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

    public override void Print()
    {
        Console.Write("(- ");
        LeftOperand.Print();
        Console.Write(" ");
        RightOperand.Print();
        Console.Write(")");
    }
}