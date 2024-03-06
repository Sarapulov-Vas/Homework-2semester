/// <summary>
/// Stack Calculator Class.
/// </summary>
internal class StackCalculator
{
    /// <summary>
    /// Stack for storing numbers.
    /// </summary>
    private readonly IStack stack;

    /// <summary>
    /// Initializes a new instance of the <see cref="StackCalculator"/> class.
    /// </summary>
    /// <param name="stack">The type of stack.</param>
    public StackCalculator(IStack stack)
    {
        this.stack = stack;
    }

    /// <summary>
    /// Method implementing stack calculator.
    /// </summary>
    /// <param name="expression">An expression in reverse Polish notation.</param>
    /// <returns>The result of calculating the expression.</returns>
    public double Calculate(string expression)
    {
        string[] arrayExpression = expression.Split(' ');
        double firstNumbre, secondNumber;
        double epsilon = 1e-10;
        foreach (var element in arrayExpression)
        {
            if (element != "+" && element != "*" && element != "/" && element != "-")
            {
                int number;
                if (!int.TryParse(element, out number))
                {
                    Console.WriteLine("Wrong input!");
                    while (this.stack.Length != 0)
                    {
                        this.stack.Pop();
                    }

                    return 0;
                }

                this.stack.Push(number);
            }
            else if (this.stack.Length >= 2)
            {
                firstNumbre = this.stack.Pop();
                secondNumber = this.stack.Pop();
                switch (element)
                {
                    case "+":
                        this.stack.Push(firstNumbre + secondNumber);
                        break;
                    case "-":
                        this.stack.Push(firstNumbre - secondNumber);
                        break;
                    case "*":
                        this.stack.Push(firstNumbre * secondNumber);
                        break;
                    case "/":
                        if (Math.Abs(secondNumber) <= epsilon)
                        {
                            Console.WriteLine("Division by zero!");
                            while (this.stack.Length != 0)
                            {
                                this.stack.Pop();
                            }

                            return 0;
                        }

                        this.stack.Push(firstNumbre / secondNumber);
                        break;
                    default:
                        Console.WriteLine("Wrong input!");
                        while (this.stack.Length != 0)
                        {
                            this.stack.Pop();
                        }

                        return 0;
                }
            }
            else
            {
                Console.WriteLine("Too many operations");
                while (this.stack.Length != 0)
                {
                    this.stack.Pop();
                }

                return 0;
            }
        }

        if (this.stack.Length != 1)
        {
            Console.WriteLine("Too much argument!");
            while (this.stack.Length != 0)
            {
                this.stack.Pop();
            }

            return 0;
        }

        return this.stack.Pop();
    }
}