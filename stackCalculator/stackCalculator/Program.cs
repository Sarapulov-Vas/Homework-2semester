/// <summary>
/// Main class.
/// </summary>
internal class Program
{
    private static void Main()
    {

        Console.WriteLine("Input expression ");
        string? inputString = Console.ReadLine();
        if (inputString != null)
        {
            StackCalculator result = new StackCalculator(new ArrayStack());
            Console.WriteLine(result.Calculate(inputString));
        }
    }
}