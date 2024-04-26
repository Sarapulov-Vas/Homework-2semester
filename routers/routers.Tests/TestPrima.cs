namespace routers.Tests;

public class Tests
{
    [TestCase("../../../testFiles/test1.txt", "../../../testFiles/result1.txt", "../../../testFiles/expectedResultTest1.txt")]
    [TestCase("../../../testFiles/test2.txt", "../../../testFiles/result2.txt", "../../../testFiles/expectedResultTest2.txt")]
    [TestCase("../../../testFiles/test3.txt", "../../../testFiles/result3.txt", "../../../testFiles/expectedResultTest3.txt")]
    public void TestCorrectWork(string inputFilePath, string resultFilePath, string expectedResultFilePath)
    {
        Prima.Start(inputFilePath, resultFilePath);
        Assert.That(AreGraphsIsEqual(Prima.ParseFile(resultFilePath), Prima.ParseFile(expectedResultFilePath)));
    }

    [TestCase("../../../testFiles/emptyFile.txt")]
    [TestCase("../../../testFiles/incorrectFile1.txt")]
    [TestCase("../../../testFiles/incorrectFile2.txt")]
    public void TestIncorrectFile(string inputFilePath)
    {
        Assert.Throws<IncorrectFileException>(() => Prima.ParseFile(inputFilePath));
    }

    [TestCase("../../../testFiles/unboundGraph1.txt")]
    [TestCase("../../../testFiles/unboundGraph2.txt")]
    public void TestUnboundGraph(string inputFilePath)
    {
        Assert.Throws<UnboundGraphException>(() => Prima.Start(inputFilePath, ""));
    }

    private static bool AreGraphsIsEqual(Net firstGraph, Net secondGraph)
    {
        if (firstGraph.CountOfVertex != secondGraph.CountOfVertex || firstGraph.CountOfEdges != secondGraph.CountOfEdges)
        {
            return false;
        }

        for (int i = 1; i < firstGraph.CountOfVertex + 1; ++i)
        {
            var ListOfAdjacentVerticesFirst = firstGraph.GetListOfAdjacentVertices(i);
            var ListOfAdjacentVerticesSecond = secondGraph.GetListOfAdjacentVertices(i);
            if (ListOfAdjacentVerticesSecond.Count != ListOfAdjacentVerticesFirst.Count)
            {
                return false;
            }
            for (int j = 0; j < ListOfAdjacentVerticesFirst.Count; ++j)
            {
                if (!ListOfAdjacentVerticesFirst.Contains(ListOfAdjacentVerticesSecond[j]))
                {
                    return false;
                }
            }
        }
        return true;
    }
}