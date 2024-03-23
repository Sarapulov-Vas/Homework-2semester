/// <summary>
/// Main class.
/// </summary>
internal static class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Input path of parse tree file: ");
        string path = Console.ReadLine();
        var parseTree = new ParseTree(path);
        parseTree.PrintParseTree();
        Console.WriteLine(parseTree.Calculate());
    }
}