using stackCalculator;
namespace stackCalculator.Tests;

public class Tests
{
    private StackCalculator ListStackCalculator = new StackCalculator(new ListStack());
    private StackCalculator ArrayStackCalculator = new StackCalculator(new ArrayStack());

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestCorrectInput ()
    {
        Assert.That(ListStackCalculator.Calculate("1 2 3 * +"), Is.EqualTo(7));
        Assert.That(ArrayStackCalculator.Calculate("1 2 3 * +"), Is.EqualTo(7));
    }
}