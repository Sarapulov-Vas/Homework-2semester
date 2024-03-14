internal class Program
{
    private static void Main(string[] args)
    {
        LZW.Compression("/home/sarapulov-vasilii/work/Homework-2semester/BubbleSort/bin/Debug/net8.0/BubbleSort", false);
        LZW.Decompression("/home/sarapulov-vasilii/work/Homework-2semester/BubbleSort/bin/Debug/net8.0/BubbleSort.zipped");
    }
}