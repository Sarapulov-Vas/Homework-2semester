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
        var compressionFile = new FileStream("/home/sarapulov-vasilii/work/Homework-2semester/LZW/test.txt.zipped", FileMode.Create);
        var dictionary = new Trie();
        var substring = new List<byte>();
        var countOfBytes = new List<int> { 0 };
        int currentNumberOfBytes = 1;
        int index;
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

        if (substring.Count != 0)
        {
            byte[] bytes = BitConverter.GetBytes(dictionary.Contains(substring));
            compressionFile.Write(bytes, 0, currentNumberOfBytes);
            countOfBytes[countOfBytes.Count - 1]++;
        }

        compressionFile.WriteByte((byte)'\n');
        foreach (var element in countOfBytes)
        {
            compressionFile.Write(BitConverter.GetBytes(element), 0, (int)Math.Ceiling(Math.Ceiling(Math.Log2(element)) / 8));
            compressionFile.WriteByte((byte)' ');
        }

        compressionFile.Close();
    }

    public static void Decompression()
    {
        var compressedFile = new FileStream("/home/sarapulov-vasilii/work/Homework-2semester/LZW/test.txt.zipped", FileMode.Open);
        var originalFile = new FileStream("/home/sarapulov-vasilii/work/Homework-2semester/LZW/test1.txt", FileMode.Create);
        var countOfBytes = new List<int>();
        var substrings = new List<byte[]>();
        substrings.Add([]);
        var value = new byte[4];
        int counter = 0;
        compressedFile.Position = compressedFile.Length - 1;
        byte buffer = (byte)compressedFile.ReadByte();
        compressedFile.Position--;
        while (buffer != (byte)'\n')
        {
            compressedFile.Position--;
            buffer = (byte)compressedFile.ReadByte();
            compressedFile.Position--;
        }

        var endOfText = compressedFile.Position;
        compressedFile.Position++;
        while (compressedFile.Position != compressedFile.Length)
        {
            buffer = (byte)compressedFile.ReadByte();

            if (buffer == 32)
            {
                counter = 0;
                countOfBytes.Add(BitConverter.ToInt32(value));
                Array.Clear(value);
                continue;
            }

            value[counter] = buffer;
            counter++;
        }

        compressedFile.Position = 0;
        var numberOfCodeSequences = countOfBytes.Sum();
        for (int j = 0; j < numberOfCodeSequences; ++j)
        {
            buffer = (byte)compressedFile.ReadByte();
            value[0] = buffer;
            for (int i = 0; i < counter; ++i)
            {
                buffer = (byte)compressedFile.ReadByte();
                value[i + 1] = buffer;
            }

            var substringIndex = BitConverter.ToInt32(value);
            originalFile.Write(substrings[substringIndex]);
            if (endOfText == compressedFile.Position)
            {
                 break;
            }
            buffer = (byte)compressedFile.ReadByte();
            originalFile.WriteByte(buffer);
            substrings.Add(new byte[substrings[substringIndex].Length + 1]);
            Array.Copy(substrings[substringIndex], substrings[^1], substrings[substringIndex].Length);
            substrings[^1][^1] = buffer;
            Array.Clear(value);
            countOfBytes[counter]--;
            if (countOfBytes[counter] == 0)
            {
                counter++;
            }
        }

        compressedFile.Close();
        originalFile.Close();
    }
}