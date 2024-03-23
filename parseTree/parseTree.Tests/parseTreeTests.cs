namespace parseTree.Tests;

public class Tests
{
    [TestCase("../../../TestFiles/TestCorrect_1.txt", 31)]
    [TestCase("../../../TestFiles/TestCorrect_2.txt", 50)]
    [TestCase("../../../TestFiles/TestCorrect_3.txt", -75)]
    public void TestCorrect(string path, int expectedResult)
    {
        var parseTree = new ParseTree(path);
        Assert.That(parseTree.Calculate(), Is.EqualTo(expectedResult));
        Assert.That(File.ReadAllText(path), Is.EqualTo(parseTree.PrintParseTree())) ;
    }

    [Test]
    public void TestIncorrectOperand()
    {
        Assert.Throws<IncorrectOperandException>(() => new ParseTree("../../../TestFiles/TestIncorrect_1.txt"));
    }

    [Test]
    public void TestDivisionByZero()
    {
        var parseTree = new ParseTree("../../../TestFiles/TestIncorrect_2.txt");
        Assert.Throws<DivideByZeroException>(() => parseTree.Calculate());
    }

    [TestCase("../../../TestFiles/TestIncorrect_3.txt")]
    [TestCase("../../../TestFiles/TestIncorrect_4.txt")]
    [TestCase("../../../TestFiles/TestIncorrect_5.txt")]
    [TestCase("../../../TestFiles/EmptyFile.txt")]
    public void TestIncorrectExpression(string path)
    {
        Assert.Throws<IncorrectInputException>(() => new ParseTree(path));
    }
}