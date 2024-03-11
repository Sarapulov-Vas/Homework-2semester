using System.Text;


/// <summary>
/// Class realizing file compression and decompression by LZW algorithm.
/// </summary>
internal class LZW
{
    /// <summary>
    /// Compression method.
    /// </summary>
    /// <param name="path">Input string.</param>
    public static void Compression()
    {
        var originalText = File.ReadAllBytes("/home/sarapulov-vasilii/work/Homework-2semester/LZW/test.txt");
        var compressionFile = new FileStream("/home/sarapulov-vasilii/work/Homework-2semester/LZW/test.zipped", FileMode.Create);
        var dictionary = new Trie();
        var substring = new List<byte>();
        var countOfBytes = new List<ulong> { 0 };
        int currentNumberOfBytes = 1;
        ulong index;
        //compressionFile.WriteByte(10);
        foreach (var element in originalText)
        {
            substring.Add(element);
            if (dictionary.Contains(substring) == 0)
            {
                substring.RemoveAt(substring.Count - 1);
                index = dictionary.Contains(substring);
                if (Math.Pow(2, currentNumberOfBytes * 8) <= index)
                {
                    currentNumberOfBytes++;
                    countOfBytes.Add(0);
                }

                countOfBytes[countOfBytes.Count - 1]++;
                byte[] bytes = BitConverter.GetBytes(dictionary.Contains(substring));
                compressionFile.Write(bytes, 0, currentNumberOfBytes);
                compressionFile.WriteByte(element);
                substring.Add(element);
                dictionary.Add(substring);
                substring.Clear();
            }
        }

        compressionFile.Close();
        var compressedFile = new FileStream("/home/sarapulov-vasilii/work/Homework-2semester/LZW/test.zipped", FileMode.Open);
        foreach (var element in countOfBytes)
        {
            compressedFile.Write(BitConverter.GetBytes(element), 0, (int)Math.Ceiling(Math.Ceiling(Math.Log2(element)) / 8));
            compressedFile.WriteByte(32);
        }

        compressedFile.WriteByte(10);
        compressedFile.Close();
    }

    // public static byte[] Decompression()
    // {

    // }
}