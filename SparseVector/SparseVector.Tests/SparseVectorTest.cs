namespace SparseVector.Tests;

public class Tests
{
    [Test]
    public void TestGetVector()
    {
        (int, int)[] expectedVector = [(2, 3), (4, 5)];
        var vector = new SparseVector([(2, 3), (4, 5)]);
        for (int i = 0; i < expectedVector.Length; i++)
        {
            Assert.That(vector.Vector[i].number, Is.EqualTo(expectedVector[i].Item1));
            Assert.That(vector.Vector[i].value, Is.EqualTo(expectedVector[i].Item2));
        }
        Assert.That(vector.Size, Is.EqualTo(5));
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
        (int, int)[] expectedVector = [(1, 2), (2, 3), (4, 10)];
        var vector1 = new SparseVector([(2, 3), (4, 5)]);
        var vector2 = new SparseVector([(1, 2), (4, 5)]);
        var result = SparseVector.Addition(vector1, vector2);
        for (int i = 0; i < expectedVector.Length; i++)
        {
            Assert.That(result.Vector[i].number, Is.EqualTo(expectedVector[i].Item1));
            Assert.That(result.Vector[i].value, Is.EqualTo(expectedVector[i].Item2));
        }
        Assert.That(result.Size, Is.EqualTo(5));
    }

    [Test]
    public void TestSubtraction()
    {
        (int, int)[] expectedVector = [(1, -2), (2, 3), (4, 5)];
        var vector1 = new SparseVector([(2, 3), (4, 10)]);
        var vector2 = new SparseVector([(1, 2), (4, 5)]);
        var result = SparseVector.Subtraction(vector1, vector2);
        for (int i = 0; i < expectedVector.Length; i++)
        {
            Assert.That(result.Vector[i].number, Is.EqualTo(expectedVector[i].Item1));
            Assert.That(result.Vector[i].value, Is.EqualTo(expectedVector[i].Item2));
        }
        Assert.That(result.Size, Is.EqualTo(5));
    }

    [Test]
    public void TestMultiplication()
    {
        (int, int)[] expectedVector = [(1, 4), (4, 10)];
        var vector = new SparseVector([(1, 2), (4, 5)]);
        var result = SparseVector.Multiplication(vector, 2);
        for (int i = 0; i < expectedVector.Length; i++)
        {
            Assert.That(result.Vector[i].number, Is.EqualTo(expectedVector[i].Item1));
            Assert.That(result.Vector[i].value, Is.EqualTo(expectedVector[i].Item2));
        }
        Assert.That(result.Size, Is.EqualTo(5));
    }
}