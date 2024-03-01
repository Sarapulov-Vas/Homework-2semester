/// <summary>
/// Main class.
/// </summary>
internal class Program
{
    private static void Main()
    {
        var trie = new Trie();
        if (Test.StartTest())
        {
            Console.WriteLine("Tests complit.");
        }
        else
        {
            Console.WriteLine("test failed!");
        }
    }
}