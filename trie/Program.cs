/// <summary>
/// Main class.
/// </summary>
internal static class Program
{
    private static void Main()
    {
        if (Test.StartTest())
        {
            Console.WriteLine("Tests complited.");
        }
        else
        {
            Console.WriteLine("Test failed!");
        }
    }
}