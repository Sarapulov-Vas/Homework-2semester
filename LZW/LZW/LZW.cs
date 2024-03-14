using System.ComponentModel;
using System.Text;

/// <summary>
/// Class realizing file compression and decompression by LZW algorithm.
/// </summary>
public class LZW
{
    private static byte currentByte = 0;
    private static int counterBits = 0;

    /// <summary>
    /// Compression method.
    /// </summary>
    /// <param name="path">File path.</param>
    public static void Compression(string path, bool BWT = false)
    {
        var originalText = File.ReadAllBytes(path);
        if (originalText.Length == 0)
        {
            Console.WriteLine("Empty file cannot be compressed!");
            return;
        }

        var compressionFile = new FileStream(path + ".zipped", FileMode.Create);
        var dictionary = new Trie();
        var entryPhrase = new List<byte>();
        var numberOfBits = new List<int> { 0 };
        int currentNumberOfBits = 1;
        int index;
        int endIndex = 0;
        var BWTText = new BWT();
        currentByte = 0;
        counterBits = 0;
        if (BWT == true)
        {
            BWTText.DirectConversion(originalText);
        }
        for (int i = 0; i < 256; ++i)
        {
            dictionary.Add([(byte)i]);
        }

        for (int i = 0; i < originalText.Length; ++i)
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
                var bitArray = ConvertIntToBitArray(index);
                if (Math.Pow(2, currentNumberOfBits) <= index)
                {
                    for (int j = currentNumberOfBits; j < bitArray.Count; ++j)
                    {
                        numberOfBits.Add(0);
                    }

                    currentNumberOfBits = bitArray.Count();
                }

                numberOfBits[numberOfBits.Count - 1]++;
                WriteValueInFile(bitArray, compressionFile, currentNumberOfBits);
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
            var bitArray = ConvertIntToBitArray(dictionary.Contains(entryPhrase));
            WriteValueInFile(bitArray, compressionFile, currentNumberOfBits);
            numberOfBits[numberOfBits.Count - 1]++;
        }

        if (counterBits != 0)
        {
            while (counterBits != 8)
            {
                currentByte = (byte)((currentByte << 1) + 0);
                counterBits++;
            }

            compressionFile.WriteByte(currentByte);
        }

        compressionFile.WriteByte((byte)'\n');
        foreach (var element in numberOfBits)
        {
            compressionFile.Write(Encoding.Default.GetBytes(element.ToString()));
            compressionFile.WriteByte((byte)' ');
        }

        if (BWT == true)
        {
            compressionFile.WriteByte((byte)';');
            compressionFile.Write(Encoding.Default.GetBytes(endIndex.ToString()));
        }

        Console.WriteLine($"Compression ratio: {(double)originalText.Length / compressionFile.Length}");
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
        var numberOfBits = new List<int>();
        var dictionary = new List<byte[]>();
        var value = new StringBuilder();
        int counterBytes = 0;
        int currentNumberOfBits = 0;
        int endOfText = -1;
        currentByte = 0;
        counterBits = 0;
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
                numberOfBits.Add(int.Parse(value.ToString()));
                value.Clear();
                continue;
            }

            value.Append((char)buffer);
            counterBytes++;
        }

        while (numberOfBits[currentNumberOfBits] == 0)
        {
            currentNumberOfBits++;
        }

        compressedFile.Position = 0;
        var numberOfCodeSequences = numberOfBits.Sum();
        currentByte = (byte)compressedFile.ReadByte();
        numberOfBits[currentNumberOfBits]--;
        counterBits = 0;
        int prevCode = GetCodeFromCompressedFile(compressedFile, currentNumberOfBits);
        while (numberOfBits[currentNumberOfBits] == 0)
        {
            currentNumberOfBits++;
        }

        foreach (var element in dictionary[prevCode])
        {
            originalText.Add(element);
        }

        for (int i = 1; i < numberOfCodeSequences; ++i)
        {
            numberOfBits[currentNumberOfBits]--;
            int currCode = GetCodeFromCompressedFile(compressedFile, currentNumberOfBits);
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
            currCode = 0;
            while (numberOfBits[currentNumberOfBits] == 0)
            {
                currentNumberOfBits++;
                if (currentNumberOfBits == numberOfBits.Count)
                {
                    break;
                }
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

    private static List<byte> ConvertIntToBitArray(int value)
    {
        var bitArray = new List<byte>();
        while (value != 0)
        {
            bitArray.Add((byte)(value % 2));
            value /= 2;
        }

        return bitArray;
    }

    private static void WriteValueInFile(List<byte> bitArray, FileStream compressionFile, int currentNumberOfBits)
    {
        for (int j = 0; j < currentNumberOfBits - bitArray.Count; ++j)
        {
            currentByte <<= 1;
            counterBits++;
            if (counterBits == 8)
            {
                compressionFile.WriteByte(currentByte);
                currentByte = 0;
                counterBits = 0;
            }
        }

        for (int j = 0; j < bitArray.Count; ++j)
        {
            currentByte = (byte)((currentByte << 1) + bitArray[^(j + 1)]);
            counterBits++;
            if (counterBits == 8)
            {
                compressionFile.WriteByte(currentByte);
                currentByte = 0;
                counterBits = 0;
            }
        }
    }

    private static int GetCodeFromCompressedFile(FileStream compressedFile, int currentNumberOfBits)
    {
        int code = 0;
        for (int j = 0; j < currentNumberOfBits + 1; ++j)
        {
            if (((1 << (7 - counterBits)) & currentByte) != 0)
            {
                code += (int)Math.Pow(2, currentNumberOfBits - j);
            }

            counterBits++;
            if (counterBits == 8)
            {
                currentByte = (byte)compressedFile.ReadByte();
                counterBits = 0;
            }
        }

        return code;
    }
}