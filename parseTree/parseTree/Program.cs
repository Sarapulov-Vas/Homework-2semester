internal class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Input path of parse tree file: ");
        string path = Console.ReadLine();
        var ParseTree = new ParseTree(path);
        ParseTree.PrintParseTree();
        Console.WriteLine(ParseTree.Calculate());
    }
}