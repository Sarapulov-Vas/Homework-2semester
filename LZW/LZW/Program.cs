internal static class Program
{
    private static void Main(string[] args)
    {
        if (args.Length > 3)
        {
            Console.WriteLine("Wrong input!");
            return;
        }
        else if (args.Length == 1 && args[0].CompareTo("--help") == 0)
        {
            Console.WriteLine("Enter the path to the file.");
            Console.WriteLine("\t-c, The key to compress the file.");
            Console.WriteLine("\t-u, The key to unzip the file.");
            Console.WriteLine("\t-b, Key to use BWT when compressing a file.");
        }
        else if (args.Length >= 2)
        {
            if (File.Exists(args[0]))
            {
                if (args[1] == "-c")
                {
                    if (args.Length == 3 && args[2] == "-b")
                    {
                        try
                        {
                        LZW.Compression(args[0], true);
                        }
                        catch
                        {
                            Console.WriteLine("Compression failed!");
                            return;
                        }
                    }
                    else if (args.Length == 2)
                    {
                        try
                        {
                        LZW.Compression(args[0]);
                        }
                        catch
                        {
                            Console.WriteLine("Compression failed!");
                            return;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Wrong input!");
                        return;
                    }

                    Console.WriteLine("File successfully compressed.");
                }
                else if (args[1] == "-u")
                {
                    if (string.Compare(args[0][^7..], ".zipped") == 0)
                    {
                        LZW.Decompression(args[0]);
                        Console.WriteLine("The file has been successfully unzipped.");
                    }
                    else
                    {
                        Console.WriteLine("The file cannot be uncompressed.");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Wrong input!");
                    return;
                }
            }
            else
            {
                Console.WriteLine("File not found!");
                return;
            }
        }
        else
        {
            Console.WriteLine("Wrong input!");
            return;
        }
    }
}