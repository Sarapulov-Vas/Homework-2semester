/// <summary>
/// A stack class implemented through an array.
/// </summary>
public class ArrayStack : IStack
{
        /// <summary>
    /// Current size of stack.
    /// </summary>
    private static int size = 10;

    /// <summary>
    /// Array implementing the stack.
    /// </summary>
    private double[] stack = new double[size];

    /// <summary>
    /// Stack length field.
    /// </summary>
    private int length;

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
        if (this.length + 1 == size)
        {
            this.Resize();
        }

        this.stack[this.length] = value;
        this.length++;
    }

    /// <summary>
    /// A method for removing an element from the stack.
    /// </summary>
    /// <returns>Removed element from the stack.</returns>
    public double Pop()
    {
        this.length--;
        double value = this.stack[this.length];
        return value;
    }

    /// <summary>
    /// A method for increasing the size of an array.
    /// </summary>
    private void Resize()
    {
        size += 10;
        Array.Resize(ref this.stack, size);
    }
}