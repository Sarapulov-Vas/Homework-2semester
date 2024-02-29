/// <summary>
/// Stack Calculator Class.
/// </summary>
internal class StackCalculator
{
    /// <summary>
    /// Method implementing stack calculator.
    /// </summary>
    /// <param name="expression">An expression in reverse Polish notation.</param>
    /// <returns>The result of calculating the expression.</returns>
    public double Calculate(string expression)
    {
        IStack stack = new ListStack();
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
                    return 0;
                }

                stack.Push(number);
            }
            else if (stack.Length >= 2)
            {
                firstNumbre = stack.Pop();
                secondNumber = stack.Pop();
                switch (element)
                {
                    case "+":
                        stack.Push(firstNumbre + secondNumber);
                        break;
                    case "-":
                        stack.Push(firstNumbre - secondNumber);
                        break;
                    case "*":
                        stack.Push(firstNumbre * secondNumber);
                        break;
                    case "/":
                        if (Math.Abs(secondNumber) <= epsilon)
                        {
                            Console.WriteLine("Division by zero!");
                            return 0;
                        }

                        stack.Push(firstNumbre / secondNumber);
                        break;
                    default:
                        Console.WriteLine("Wrong input!");
                        return 0;
                }
            }
            else
            {
                Console.WriteLine("Too many operations");
                return 0;
            }
        }

        if (stack.Length != 1)
        {
            Console.WriteLine("Too much argument!");
            return 0;
        }

        return stack.Pop();
    }
}