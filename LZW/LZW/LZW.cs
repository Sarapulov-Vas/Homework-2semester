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
        var originalFile = new FileStream("/home/sarapulov-vasilii/work/Homework-2semester/LZW/test.txt", FileMode.Open);
        var compressionFile = new StreamWriter("/home/sarapulov-vasilii/work/Homework-2semester/LZW/test.txt.zipped", false);
        byte element;
        var dictionary = new Trie();
        var substring = new List<byte>();
        while (true)
        {
            element = (byte)originalFile.ReadByte();
            if (element == 255)
            {
                break;
            }

            substring.Add(element);
            if (dictionary.Contains(substring) == 0)
            {
                substring.RemoveAt(substring.Count - 1);
                compressionFile.Write($"{dictionary.Contains(substring)}{Convert.ToChar(element)}");
                substring.Add(element);
                dictionary.Add(substring);
                substring.Clear();
            }
        }

        originalFile.Close();
        compressionFile.Close();
    }
}