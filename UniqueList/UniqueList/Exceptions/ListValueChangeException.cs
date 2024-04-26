/// <summary>
/// Exception when the value of a list item changes.
/// </summary>
public class ListValueChangeException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ListValueChangeException "/> class.
    /// </summary>
    public ListValueChangeException()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ListValueChangeException "/> class.
    /// </summary>
    /// <param name="message">Exception message.</param>
    public ListValueChangeException(string message)
    : base(message)
    {
    }
}