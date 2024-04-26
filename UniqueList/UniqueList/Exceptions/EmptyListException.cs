/// <summary>
/// Exception class when accessing an empty list.
/// </summary>
public class EmptyListException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EmptyListException"/> class.
    /// </summary>
    public EmptyListException()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="EmptyListException"/> class.
    /// </summary>
    /// <param name="message">Exception message.</param>
    public EmptyListException(string message)
    : base(message)
    {
    }
}