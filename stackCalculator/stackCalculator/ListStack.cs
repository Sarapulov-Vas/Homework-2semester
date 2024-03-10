/// <summary>
/// A stack class implemented through a list.
/// </summary>
public class ListStack : IStack
{
    /// <summary>
    /// A list for the implementation of the stack.
    /// </summary>
    private readonly List<double> stack = new List<double>();

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
        this.stack.Add(value);
        this.length = this.stack.Count;
    }

    /// <summary>
    /// A method for removing an element from the stack.
    /// </summary>
    /// <returns>Removed element from the stack.</returns>
    public double Pop()
    {
        double value = this.stack[^1];
        this.stack.RemoveAt(this.stack.Count - 1);
        this.length = this.stack.Count;
        return value;
    }
}