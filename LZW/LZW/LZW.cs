using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
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
            Console.WriteLine(element);
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
                // Console.WriteLine(dictionary.Contains(substring));
                // Console.WriteLine(element);
                compressionFile.Write(bytes, 0, currentNumberOfBytes);
                compressionFile.WriteByte(element);
                substring.Add(element);
                dictionary.Add(substring);
                substring.Clear();
            }
        }
        if (substring.Count != 0)
        {
            byte[] bytes = BitConverter.GetBytes(dictionary.Contains(substring));
            compressionFile.Write(bytes, 0, currentNumberOfBytes);
        }

        compressionFile.Close();
        Console.WriteLine();
        // var compressedFile = new FileStream("/home/sarapulov-vasilii/work/Homework-2semester/LZW/test.zipped", FileMode.Open);
        // foreach (var element in countOfBytes)
        // {
        //     compressedFile.Write(BitConverter.GetBytes(element), 0, (int)Math.Ceiling(Math.Ceiling(Math.Log2(element)) / 8));
        //     compressedFile.WriteByte(32);
        // }

        // compressedFile.WriteByte(10);
        // compressedFile.Close();
    }

    public static void Decompression()
    {
        var originalFile = new FileStream("/home/sarapulov-vasilii/work/Homework-2semester/LZW/original.txt", FileMode.Create);
        var compressedFile = new FileStream("/home/sarapulov-vasilii/work/Homework-2semester/LZW/test.zipped", FileMode.Open);
        var countOfBytes = new List<ulong>() { 262, 557 };
        var substrings = new List<byte[]>();
        substrings.Add([]);
        var value = new byte[8];
        int counter = 0;
        // while (true)
        // {
        //     byte buffer = (byte)compressedFile.ReadByte();
        //     if (buffer == 10)
        //     {
        //         break;
        //     }

        //     if (buffer == 32)
        //     {
        //         counter = 0;
        //         countOfBytes.Add(BitConverter.ToUInt64(value));
        //         Array.Clear(value);
        //         continue;
        //     }

        //     value[counter] = buffer;
        //     counter++;
        // }

        while (true)
        {
            countOfBytes[counter]--;

            byte buffer = (byte)compressedFile.ReadByte();
            if (buffer == 255)
            {
                break;
            }
            Console.WriteLine(buffer);
        //     value[0] = buffer;
        //     for (int i = 0; i < counter; ++i)
        //     {
        //         buffer = (byte)compressedFile.ReadByte();
        //         value[i + 1] = buffer;
        //     }

        //     originalFile.Write(substrings[(int)BitConverter.ToUInt64(value)]);
        //     buffer = (byte)compressedFile.ReadByte();
        //     originalFile.WriteByte(buffer);
        //     var currentSubstring = new byte[substrings[BitConverter.ToInt32(value)].Length + 1];
        //     currentSubstring[^1] = buffer;
        //     substrings.Add(currentSubstring);
        //     Array.Clear(value);
        //     if (countOfBytes[counter] == 0)
        //     {
        //         counter++;
        //     }
        }

        // compressedFile.Close();
        // originalFile.Close();
    }
}