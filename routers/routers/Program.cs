internal static class Program
{
    private static void Main(string[] args)
    {
        if (args.Length == 2 && File.Exists(args[0]))
        {
            try
            {
                Prima.Start(args[0], args[1]);
            }
            catch (UnboundGraphException)
            {
                Console.Error.WriteLine("The network is not connected!");
                Environment.Exit(-1);
            }
            catch (IncorrectFileException)
            {
                Console.Error.WriteLine("Incorrect input file!");
                Environment.Exit(-2);
            }
        }
        else
        {
            Console.WriteLine("Wrong arguments!");
        }
    }
}