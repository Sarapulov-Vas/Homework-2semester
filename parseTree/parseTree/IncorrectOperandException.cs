class IncorrectOperandException : Exception
{
    public IncorrectOperandException()
    {
    }

    public IncorrectOperandException(string message)
        : base(message)
    {
    }
}