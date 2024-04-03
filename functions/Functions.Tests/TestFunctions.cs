using System.Text;

namespace Functions.Tests;
public class Tests
{
    [Test]
    public void TestMapWithSameTypes()
    {
        var originalList = new List<int>() {1, 2, 3};
        var expectedResult = new List<int>() {1, 4, 9};
        var list = Functions.Map(originalList, x => x * x);
        Assert.That(list, Is.EqualTo(expectedResult));
    }

    [Test]
    public void TestMapWithDifferentTypes()
    {
        var originalList = new List<int>() {1, 2, 3};
        var expectedResult = new List<bool>() {false, true, false};
        var list = Functions.Map(originalList, x => x % 2 == 0);
        Assert.That(list, Is.EqualTo(expectedResult));
    }

    [Test]
    public void TestMapEmptyList()
    {
        var originalList = new List<int>();
        var list = Functions.Map(originalList, x => x % 2 == 0);
        Assert.That(list, Is.EqualTo(new List<bool>()));
    }

    [Test]
    public void TestFilterInt()
    {
        var originalList = new List<int>() {1, 2, 3, 4, 5};
        var expectedResult = new List<int>() {2, 4};
        var list = Functions.Filter(originalList, x => x % 2 == 0);
        Assert.That(list, Is.EqualTo(expectedResult));
    }    

    [Test]
    public void TestFilterString()
    {
        var originalList = new List<string>() {"abcdef", "def", "c", "c++"};
        var expectedResult = new List<string>() {"abcdef", "c", "c++"};
        var list = Functions.Filter(originalList, x => x.Contains('c'));
        Assert.That(list, Is.EqualTo(expectedResult));
    }

    [Test]
    public void TestFoldWithSameTypes()
    {
        var originalList = new List<int>() {1, 2, 3};
        var list = Functions.Fold(originalList, 2, (acc, x) => acc * x);
        Assert.That(list, Is.EqualTo(12));
    }

    [Test]
    public void TestFoldWithDifferentTypes()
    {
        var originalList = new List<int>() {65, 66, 67};
        var list = Functions.Fold(originalList, new StringBuilder(), (acc, x) => acc.Append((char)x));
        Assert.That(list.ToString(), Is.EqualTo("ABC"));
    } 
}