namespace UniqueList.Tests;

using System.Security.Cryptography.X509Certificates;
using UniqueList;
public class Tests
{
    private List list;
    [SetUp]
    public void Init()
    {
        list = new List();
        list.Add(1);
        list.Add(2);
        list.Add(3);
    }

    [Test]
    public void TestAddElements()
    {
        Assert.That(list.GetValue(0), Is.EqualTo(3));
        Assert.That(list.GetValue(1), Is.EqualTo(2));
        Assert.That(list.GetValue(2), Is.EqualTo(1));
        Assert.That(list.Pop(), Is.EqualTo(3));
        Assert.That(list.Pop(), Is.EqualTo(2));
        Assert.That(list.Pop(), Is.EqualTo(1));
    }

    [Test]
    public void TestChangeElements()
    {
        
        list.ChangeElement(0, 1);
        list.ChangeElement(2, 3);
        Assert.That(list.Pop(), Is.EqualTo(1));
        Assert.That(list.Pop(), Is.EqualTo(2));
        Assert.That(list.Pop(), Is.EqualTo(3));
    }

    [Test]
    public void TestDelateElements()
    {
        
        list.Delate(1);
        Assert.That(list.Pop(), Is.EqualTo(3));
        Assert.That(list.Pop(), Is.EqualTo(1));
        Assert.Throws<EmptyListException>(() => list.Pop());
    }

    [Test]
    public void TestPopFromEmptyList()
    {
        var emptyList = new List();
        Assert.Throws<EmptyListException>(() => emptyList.Pop());
    }

    [Test]
    public void TestIndexOutOfRange()
    {
        Assert.Throws<IndexOutOfRangeException>(() => list.ChangeElement(10, 10));
        Assert.Throws<IndexOutOfRangeException>(() => list.GetValue(10));
        Assert.Throws<IndexOutOfRangeException>(() => list.Delate(10));
    }
}