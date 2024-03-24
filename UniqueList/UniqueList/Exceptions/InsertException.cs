/// <summary>
/// Insertion Exception.
/// </summary>
public class InsertException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InsertException"/> class.
    /// </summary>
    public InsertException()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="InsertException"/> class.
    /// </summary>
    /// <param name="message">Exception message.</param>
    public InsertException(string message)
    : base(message)
    {
    }
}