interface IStack
{   
    void Push(double value);
    double Pop();
    int Length { get; set; }
}
class ListStack : IStack
{
    public int Length { get; set; }
    private List<double> stack = new List<double>();
    public void Push(double value)
    {   
        stack.Add(value);
        Length = stack.Count;
    }
    public double Pop()
    {
        double value = stack[^1];
        stack.RemoveAt(stack.Count - 1);
        Length = stack.Count;
        return value;
    }
}
class ArrayStack : IStack
{
    public int Length { get; set; }
    private double[] stack = Array.Empty<double>() ;
    public void Push(double value)
    {   
        Length = stack.Length + 1;
        Array.Resize(ref stack, Length);
        stack[^1] = value;
    }
    public double Pop()
    {
        double value = stack[^1];
        Array.Resize(ref stack, Length - 1);
        Length = stack.Length;
        return value;
    }
}
class StackCalculator
{
    public double Calculate(string Expression)
    {
        IStack stack = new ListStack();
        string[] arrayExpression = Expression.Split(' ');
        double firstNumbre, secondNumber;
        double epsilon = 0.00001;
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
class Test
{
    private static double epsilon = 0.000001;
    private static List<bool> TestsList = new List<bool>();
    public void AddTest(string inputExpression, double expectedResult)
    {   
        StackCalculator result = new StackCalculator();
        if (Math.Abs(result.Calculate(inputExpression) - expectedResult) < epsilon)
        {
            TestsList.Add(true);
        }
        else
        {
            TestsList.Add(false);
        }
    }
    public static bool StartTest()
    {
        for (int i = 0; i < TestsList.Count; ++i)
        {
            if (TestsList[i] == true)
            {
                Console.WriteLine($"Test {i + 1} complit.");
            }
            else
            {
                Console.WriteLine($"Test {i + 1} failed!");
                return false;
            }
        }
        return true;
    }
}
class MainClass
{
    static void Main()
    {   
        Test tests = new Test();
        tests.AddTest("1 2 3 + *", 5);
        tests.AddTest("1 2 3 * +", 7);
        tests.AddTest("2 2 5 / 1 + 7 * / -10 -", -22.25);
        if (!Test.StartTest())
        {
            return;
        }
        Console.WriteLine("Input expression ");
        string? inputString = Console.ReadLine();
        if (inputString != null)
        {
            StackCalculator result = new StackCalculator();
            Console.WriteLine(result.Calculate(inputString));
        }
    }
}