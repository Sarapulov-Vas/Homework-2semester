/// <summary>
/// Main class.
/// </summary>
internal class Program
{
    private static void Main()
    {
        Test tests = new Test();
        Test.AddTest("1 2 3 + *", 5);
        Test.AddTest("1 2 3 * +", 7);
        Test.AddTest("2 2 5 / 1 + 7 * / -10 -", -22.25);
        if (!Test.StartTest())
        {
            return;
        }

        Console.WriteLine("Input expression ");
        string? inputString = Console.ReadLine();
        if (inputString != null)
        {
            StackCalculator result = new StackCalculator(new ArrayStack());
            Console.WriteLine(result.Calculate(inputString));
        }
    }
}