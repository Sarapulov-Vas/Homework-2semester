/// <summary>
/// The class realizing the addition operator.
/// </summary>
internal class AdditionOperator : Operator
{
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

    public override void Print()
    {
        Console.Write("(+ ");
        LeftOperand.Print();
        Console.Write(" ");
        RightOperand.Print();
        Console.Write(")");
    }
}