public class Tests
{
    [TestCase("../../../TestFiles/test.txt")]
    [TestCase("../../../TestFiles/logo.png")]
    [TestCase("../../../TestFiles/test.pdf")]
    public void TestLZWCompressionAndDecompressionWithBWT(string path)
    {
        var originalText = File.ReadAllBytes(path);
        LZW.Compression(path, true);
        LZW.Decompression(path + ".zipped");
        var currentText = File.ReadAllBytes(path);
        Assert.That(originalText.SequenceEqual(currentText));
    }

    [TestCase("../../../TestFiles/test.txt")]
    [TestCase("../../../TestFiles/logo.png")]
    [TestCase("../../../TestFiles/test.pdf")]
    public void TestLZWCompressionAndDecompressionWithoutBWT(string path)
    {
        var originalText = File.ReadAllBytes(path);
        LZW.Compression(path);
        LZW.Decompression(path + ".zipped");
        var currentText = File.ReadAllBytes(path);
        Assert.That(originalText.SequenceEqual(currentText));
    }

    [TestCase("../../../TestFiles/empty.txt")]
    public void TestLZWCompressionAndDecompressionWithEmptyfile(string path)
    {
        Assert.Throws<Exception>(() => LZW.Compression(path));
        Assert.Throws<Exception>(() => LZW.Compression(path, true));
    }
}