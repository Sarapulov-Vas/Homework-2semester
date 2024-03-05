/// <summary>
/// Stack interface.
/// </summary>
internal interface IStack
{
    /// <summary>
    /// Gets stack length field.
    /// </summary>
    int Length { get; }

    /// <summary>
    /// Method for adding an element to the stack.
    /// </summary>
    /// <param name="value">Adding a value to the stack.</param>
    void Push(double value);

    /// <summary>
    /// A method for removing an element from the stack.
    /// </summary>
    /// <returns>Removed element from the stack.</returns>
    double Pop();
}
