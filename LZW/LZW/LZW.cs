using System.ComponentModel;


/// <summary>
/// Class realizing file compression and decompression by LZW algorithm.
/// </summary>
internal class LZW
{
    /// <summary>
    /// Compression method.
    /// </summary>
    /// <param name="path">File path.</param>
    public static void Compression(string path)
    {
        var originalText = File.ReadAllBytes(path);
        var compressionFile = new FileStream(path + ".zipped", FileMode.Create);
        var dictionary = new Trie();
        var entryPhrase = new List<byte>();
        var numberOfBytes = new List<int> { 0 };
        int currentNumberOfBytes = 1;
        int index;
        for (int i = 0; i < 256; ++i)
        {
            dictionary.Add([(byte)i]);
        }
        entryPhrase.Add(originalText[0]);
        for (int i = 1; i < originalText.Length; ++i)
        {
            entryPhrase.Add(originalText[i]);
            if (dictionary.Contains(entryPhrase) == -1)
            {
                index = dictionary.Contains(entryPhrase[..^1]);
                if (Math.Pow(2, currentNumberOfBytes * 8) <= index)
                {
                    currentNumberOfBytes++;
                    numberOfBytes.Add(0);
                }

                numberOfBytes[numberOfBytes.Count - 1]++;
                byte[] bytes = BitConverter.GetBytes(index);
                compressionFile.Write(bytes, 0, currentNumberOfBytes);
                dictionary.Add(entryPhrase);
                entryPhrase.Clear();
                entryPhrase.Add(originalText[i]);
            }
        }

        if (entryPhrase.Count != 0)
        {
            byte[] bytes = BitConverter.GetBytes(dictionary.Contains(entryPhrase));
            compressionFile.Write(bytes, 0, currentNumberOfBytes);
            numberOfBytes[numberOfBytes.Count - 1]++;
        }

        compressionFile.WriteByte((byte)'\n');
        foreach (var element in numberOfBytes)
        {
            compressionFile.Write(BitConverter.GetBytes(element), 0, (int)Math.Ceiling(Math.Ceiling(Math.Log2(element)) / 8));
            compressionFile.WriteByte((byte)' ');
        }

        Console.WriteLine($"Compression ratio: {(double)compressionFile.Length / originalText.Length * 100}");
        compressionFile.Close();
    }

    /// <summary>
    /// Decompression method.
    /// </summary>
    /// <param name="path">File path.</param>
    public static void Decompression(string path)
    {
        var compressedFile = new FileStream(path, FileMode.Open);
        var originalFile = new FileStream(path[..^7] + '1', FileMode.Create);
        var numberOfBytes = new List<int>();
        var dictionary = new List<byte[]>();
        var value = new byte[4];
        int counterBytes = 0;
        compressedFile.Position = compressedFile.Length - 1;
        byte buffer = (byte)compressedFile.ReadByte();
        for (int i = 0; i < 256; ++i)
        {
            dictionary.Add([(byte)i]);
        }

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
                counterBytes = 0;
                numberOfBytes.Add(BitConverter.ToInt32(value));
                Array.Clear(value);
                continue;
            }

            value[counterBytes] = buffer;
            counterBytes++;
        }

        compressedFile.Position = 0;
        int prevCode, currCode;
        var numberOfCodeSequences = numberOfBytes.Sum();
        value[0] = (byte)compressedFile.ReadByte();

        prevCode = BitConverter.ToInt32(value);
        originalFile.Write(dictionary[prevCode].ToArray());
        numberOfBytes[counterBytes]--;
        for (int i = 1; i < numberOfCodeSequences; ++i)
        {
            value[0] = (byte)compressedFile.ReadByte();
            for (int j = 0; j < counterBytes; ++j)
            {
                value[j + 1] = (byte)compressedFile.ReadByte();
            }

            currCode = BitConverter.ToInt32(value);
            numberOfBytes[counterBytes]--;
            if (currCode == dictionary.Count)
            {
                var code = new byte[dictionary[prevCode].Length + 1];
                Array.Copy(dictionary[prevCode], code, dictionary[prevCode].Length);
                code[^1] = dictionary[prevCode][0];
                dictionary.Add(code);
            }
            else
            {
                var newCode = new byte[dictionary[prevCode].Length + 1];
                Array.Copy(dictionary[prevCode], newCode, dictionary[prevCode].Length);
                newCode[^1] = dictionary[currCode][0];
                dictionary.Add(newCode);
            }

            foreach (var element in dictionary[currCode])
            {
                originalFile.WriteByte(element);
            }

            prevCode = currCode;
            if (numberOfBytes[counterBytes] == 0)
            {
                counterBytes++;
            }
        }

        compressedFile.Close();
        originalFile.Close();
    }
}