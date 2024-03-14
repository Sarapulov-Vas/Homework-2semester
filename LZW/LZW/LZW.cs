using System.Text;

/// <summary>
/// Class realizing file compression and decompression by LZW algorithm.
/// </summary>
public class LZW
{
    /// <summary>
    /// Compression method.
    /// </summary>
    /// <param name="path">File path.</param>
    public static void Compression(string path, bool BWT = false)
    {
        var originalText = File.ReadAllBytes(path);
        if (originalText.Length == 0)
        {
            throw new Exception("Empty file cannot be compressed!");
        }

        var compressionFile = new FileStream(path + ".zipped", FileMode.Create);
        var dictionary = new Trie();
        var entryPhrase = new List<byte>();
        var numberOfBytes = new List<int> { 0 };
        int currentNumberOfBytes = 1;
        int index;
        int endIndex = 0;
        var BWTText = new BWT();
        for (int i = 0; i < 256; ++i)
        {
            dictionary.Add([(byte)i]);
        }

        if (BWT == true)
        {
            endIndex = BWTText.DirectConversion(originalText);
            entryPhrase.Add(BWTText.GetElement(originalText, 0));
        }
        else
        {
            entryPhrase.Add(originalText[0]);
        }

        for (int i = 1; i < originalText.Length; ++i)
        {
            if (BWT == true)
            {
                entryPhrase.Add(BWTText.GetElement(originalText, i));
            }
            else
            {
                entryPhrase.Add(originalText[i]);
            }

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
                if (BWT == true)
                {
                    entryPhrase.Add(BWTText.GetElement(originalText, i));
                }
                else
                {
                    entryPhrase.Add(originalText[i]);
                }
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
            compressionFile.Write(Encoding.Default.GetBytes(element.ToString()));
            compressionFile.WriteByte((byte)' ');
        }

        if (BWT == true)
        {
            compressionFile.WriteByte((byte)';');
            compressionFile.Write(Encoding.Default.GetBytes(endIndex.ToString()));
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
        var originalText = new List<byte>();
        var numberOfBytes = new List<int>();
        var dictionary = new List<byte[]>();
        var value = new StringBuilder();
        int counterBytes = 0;
        int endOfText = -1;
        byte buffer = (byte)compressedFile.ReadByte();
        for (int i = 0; i < 256; ++i)
        {
            dictionary.Add([(byte)i]);
        }

        compressedFile.Position = compressedFile.Length - 2;
        while (buffer != (byte)'\n')
        {
            compressedFile.Position--;
            buffer = (byte)compressedFile.ReadByte();
            compressedFile.Position--;
        }

        compressedFile.Position++;
        while (compressedFile.Position != compressedFile.Length)
        {
            buffer = (byte)compressedFile.ReadByte();
            if (buffer == (byte)';')
            {
                while (compressedFile.Position != compressedFile.Length)
                {
                    buffer = (byte)compressedFile.ReadByte();
                    value.Append((char)buffer);
                    counterBytes = 0;
                }

                endOfText = int.Parse(value.ToString());
                break;
            }

            if (buffer == 32)
            {
                counterBytes = 0;
                numberOfBytes.Add(int.Parse(value.ToString()));
                value.Clear();
                continue;
            }

            value.Append((char)buffer);
            counterBytes++;
        }

        compressedFile.Position = 0;
        int prevCode, currCode;
        var numberOfCodeSequences = numberOfBytes.Sum();
        var byteCode = new byte[4];
        byteCode[0] = (byte)compressedFile.ReadByte();
        prevCode = BitConverter.ToInt32(byteCode);
        foreach (var element in dictionary[prevCode])
        {
            originalText.Add(element);
        }

        numberOfBytes[counterBytes]--;
        if (numberOfBytes[counterBytes] == 0)
        {
            counterBytes++;
        }

        for (int i = 1; i < numberOfCodeSequences; ++i)
        {
            byteCode[0] = (byte)compressedFile.ReadByte();
            for (int j = 0; j < counterBytes; ++j)
            {
                byteCode[j + 1] = (byte)compressedFile.ReadByte();
            }

            currCode = BitConverter.ToInt32(byteCode);
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
                originalText.Add(element);
            }

            prevCode = currCode;
            if (numberOfBytes[counterBytes] == 0)
            {
                counterBytes++;
            }
        }

        compressedFile.Close();
        if (endOfText != -1)
        {
            File.WriteAllBytes(path[..^7], BWT.InverseBWT(originalText, endOfText));
        }
        else
        {
            File.WriteAllBytes(path[..^7], originalText.ToArray());
        }
    }
}