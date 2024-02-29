/// <summary>
/// A stack class implemented through an array.
/// </summary>
internal class ArrayStack : IStack
{
    /// <summary>
    /// Array implementing the stack.
    /// </summary>
    private double[] stack = Array.Empty<double>();

    /// <summary>
    /// Stack length field.
    /// </summary>
    private int length = 0;

    /// <summary>
    /// Gets stack length property.
    /// </summary>
    public int Length
    {
        get { return this.length; }
    }

    /// <summary>
    /// Method for adding an element to the stack.
    /// </summary>
    /// <param name="value">Adding a value to the stack.</param>
    public void Push(double value)
    {
        this.length = this.stack.Length + 1;
        Array.Resize(ref this.stack, this.Length);
        this.stack[^1] = value;
    }

    /// <summary>
    /// A method for removing an element from the stack.
    /// </summary>
    /// <returns>Removed element from the stack.</returns>
    public double Pop()
    {
        double value = this.stack[^1];
        Array.Resize(ref this.stack, this.Length - 1);
        this.length = this.stack.Length;
        return value;
    }
}