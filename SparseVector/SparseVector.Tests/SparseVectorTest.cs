namespace SparseVector.Tests;

public class Tests
{
    [Test]
    public void TestGetVector()
    {
        int[] expectedVector = [0, 0, 3, 0, 5];
        var vector = new SparseVector([(2, 3), (4, 5)]);
        Assert.That(vector.Size, Is.EqualTo(5));
        for (int i = 0; i < vector.Size; i++)
        {
            Assert.That(vector[i], Is.EqualTo(expectedVector[i]));
        }
    }

    [Test]
    public void TestGetOriginalVector()
    {
        int[] expectedVector = [0, 0, 3, 0, 5];
        var vector = new SparseVector([(2, 3), (4, 5)]);
        var index = 0;
        foreach (var element in vector.GetOriginalVector())
        {
            Assert.That(element, Is.EqualTo(expectedVector[index]));
            index++;
        }
        Assert.That(vector.Size, Is.EqualTo(5));
    }

    [Test]
    public void TestAddition()
    {
        int[] expectedVector = [0, 2, 3, 0, 10];
        var vector1 = new SparseVector([(2, 3), (4, 5)]);
        var vector2 = new SparseVector([(1, 2), (4, 5)]);
        var result = SparseVector.Add(vector1, vector2);
        Assert.That(result.Size, Is.EqualTo(5));
        for (int i = 0; i < result.Size; i++)
        {
            Assert.That(result[i], Is.EqualTo(expectedVector[i]));
        }
    }

    [Test]
    public void TestSubtraction()
    {
        int[] expectedVector = [0, -2, 3, 0, 5];
        var vector1 = new SparseVector([(2, 3), (4, 10)]);
        var vector2 = new SparseVector([(1, 2), (4, 5)]);
        var result = SparseVector.Subtraction(vector1, vector2);
        Assert.That(result.Size, Is.EqualTo(5));
        for (int i = 0; i < result.Size; i++)
        {
            Assert.That(result[i], Is.EqualTo(expectedVector[i]));
        }
    }

    [Test]
    public void TestMultiplication()
    {
        var vector1 = new SparseVector([(2, 3), (4, 5)]);
        var vector2 = new SparseVector([(1, 2), (4, 5)]);
        var result = SparseVector.Multiplication(vector1, vector2);
        Assert.That(result, Is.EqualTo(25));
    }

    [Test]
    public void TestVectorIndexer()
    {
        int[] expectedVector = [1, 0, 3, 0, 5, 0, 0, 8];
        var vector = new SparseVector([(2, 3), (4, 5)]);
        vector[0] = 1;
        vector[7] = 8;
        Assert.That(vector.Size, Is.EqualTo(8));
        for (int i = 0; i < vector.Size; i++)
        {
            Assert.That(vector[i], Is.EqualTo(expectedVector[i]));
        }
    }
}