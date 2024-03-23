/// <summary>
/// Digital operand class.
/// </summary>
internal class NumberOperand : Node
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NumberOperand"/> class.
    /// </summary>
    /// <param name="value">Operand value.</param>
    public NumberOperand(int value)
    {
        this.Value = value;
    }

    /// <summary>
    /// Output the value of the operand.
    /// </summary>
    /// <returns>Output expression.</returns>
    public override string Print()
    {
        Console.Write(this.Value);
        return this.Value.ToString();
    }
}