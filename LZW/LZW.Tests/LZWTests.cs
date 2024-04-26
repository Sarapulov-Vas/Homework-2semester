public class Tests
{
    [TestCase("../../../TestFiles/test.txt")]
    [TestCase("../../../TestFiles/test.png")]
    [TestCase("../../../TestFiles/test.pdf")]
    public void TestLZWCompressionAndDecompressionWithBWT(string path)
    {
        Console.WriteLine("Compression with BWT");
        var originalText = File.ReadAllBytes(path);
        LZW.Compression(path, true);
        LZW.Decompression(path + ".zipped");
        var currentText = File.ReadAllBytes(path);
        Assert.That(originalText.SequenceEqual(currentText));
    }

    [TestCase("../../../TestFiles/test.txt")]
    [TestCase("../../../TestFiles/test.png")]
    [TestCase("../../../TestFiles/test.pdf")]
    public void TestLZWCompressionAndDecompressionWithoutBWT(string path)
    {
        Console.WriteLine("Compression without BWT");
        var originalText = File.ReadAllBytes(path);
        LZW.Compression(path);
        LZW.Decompression(path + ".zipped");
        var currentText = File.ReadAllBytes(path);
        Assert.That(originalText.SequenceEqual(currentText));
    }
}