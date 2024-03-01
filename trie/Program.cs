/// <summary>
/// Main class.
/// </summary>
internal class Program
{
    private static void Main()
    {
        var trie = new Trie();
        Test.StartTest();
        trie.Add("abc");
        Console.WriteLine(trie.Size);
    }
}