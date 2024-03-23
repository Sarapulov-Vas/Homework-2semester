/// <summary>
/// Main class.
/// </summary>
internal static class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Input path of parse tree file: ");
        string path = Console.ReadLine();
        try
        {
            var parseTree = new ParseTree(path);
            parseTree.PrintParseTree();
            Console.WriteLine(parseTree.Calculate());
        }
        catch (IncorrectInputException)
        {
            Console.WriteLine("Incorrect input file!");
        }
        catch (IncorrectOperandException)
        {
            Console.WriteLine("Invalid operand of the parse tree!");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("The expression cannot be calculated because of division by zero!");
        }
    }
}