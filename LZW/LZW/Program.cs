internal class Program
{
    private static void Main(string[] args)
    {
        LZW.Compression("/home/sarapulov-vasilii/work/Homework-2semester/LZW/test.txt");
        LZW.Decompression("/home/sarapulov-vasilii/work/Homework-2semester/LZW/test.txt.zipped");
    }
}