namespace UniqueList.Tests;

public class Tests
{
    [TestCaseSource(nameof(List))]
    public void TestAddElements(List list)
    {
        list.Add(1);
        list.Add(2);
        list.Add(3);
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
        var list = new List();
        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.ChangeElement(0, 1);
        list.ChangeElement(2, 3);
        Assert.That(list.Pop(), Is.EqualTo(1));
        Assert.That(list.Pop(), Is.EqualTo(2));
        Assert.That(list.Pop(), Is.EqualTo(3));
    }

    [Test]
    public void TestChangeElementsInUniqueList()
    {
        var list = new UniqueList();
        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.ChangeElement(0, 10);
        Assert.That(list.Pop(), Is.EqualTo(10));
        Assert.Throws<ListValueChangeException>(() => list.ChangeElement(0, 1));
    }

    [TestCaseSource(nameof(List))]
    public void TestDelateElements(List list)
    {
        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Delate(1);
        list.Delate(0);
        Assert.That(list.Pop(), Is.EqualTo(1));
    }

    [TestCaseSource(nameof(List))]
    public void TestPopFromEmptyList(List list)
    {
        var emptyList = new List();
        Assert.Throws<EmptyListException>(() => emptyList.Pop());
    }

    [TestCaseSource(nameof(List))]
    public void TestIndexOutOfRange(List list)
    {
        Assert.Throws<IndexOutOfRangeException>(() => list.ChangeElement(10, 10));
        Assert.Throws<IndexOutOfRangeException>(() => list.GetValue(10));
        Assert.Throws<IndexOutOfRangeException>(() => list.Delate(10));
    }

    [Test]
    public void InsertExistElementInUniqueListTest()
    {
        var list = new UniqueList();
        list.Add(1);
        list.Add(2);
        list.Add(3);
        Assert.Throws<InsertException>(() => list.Add(1));
    }

    [Test]
    public void ContainUniqueListTest()
    {
        var list = new UniqueList();
        list.Add(1);
        list.Add(2);
        list.Add(3);
        Assert.That(list.Contain(1), Is.EqualTo(true));
        Assert.That(list.Contain(2), Is.EqualTo(true));
        Assert.That(list.Contain(3), Is.EqualTo(true));
        Assert.That(list.Contain(10), Is.EqualTo(false));
    }

    private static IEnumerable<TestCaseData> List()
    {
        yield return new TestCaseData(new List());
        yield return new TestCaseData(new UniqueList());
    }
}