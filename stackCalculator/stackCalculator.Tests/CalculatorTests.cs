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
        Assert.That(ListStackCalculator.Calculate("1 2 2 4 5 * / + -"), Is.EqualTo(11));
        Assert.That(ArrayStackCalculator.Calculate("1 2 2 4 5 * / + -"), Is.EqualTo(11));
    }

    [Test]
    public void TestDivisionByZero ()
    {
        Assert.Throws<DivideByZeroException>(() => ListStackCalculator.Calculate("0 2 /"));
        Assert.Throws<DivideByZeroException>(() => ArrayStackCalculator.Calculate("0 2 /"));
    }

    [Test]
    public void TestIncorrectInput ()
    {
        Assert.Throws<ArgumentException>(() => ListStackCalculator.Calculate("0b1 -10e +"));
        Assert.Throws<ArgumentException>(() => ArrayStackCalculator.Calculate("0b1 -10e +"));

        Assert.Throws<ArgumentException>(() => ListStackCalculator.Calculate("5 10 ="));
        Assert.Throws<ArgumentException>(() => ArrayStackCalculator.Calculate("5 10 ="));

        Assert.Throws<ArgumentException>(() => ListStackCalculator.Calculate(""));
        Assert.Throws<ArgumentException>(() => ArrayStackCalculator.Calculate(""));
    }

    [Test]
    public void TestMoreArgumentsThanOperations ()
    {
        Assert.Throws<Exception>(() => ListStackCalculator.Calculate("1 2 3 +"));
        Assert.Throws<Exception>(() => ArrayStackCalculator.Calculate("1 2 3 +"));
    }

    [Test]
    public void TestMoreOperationsThanArguments ()
    {
        Assert.Throws<Exception>(() => ListStackCalculator.Calculate("1 2 + +"));
        Assert.Throws<Exception>(() => ArrayStackCalculator.Calculate("1 2 + +"));
    }

    [Test]
    public void TestAddition ()
    {
        Assert.That(ListStackCalculator.Calculate("15 19 +"), Is.EqualTo(34));
        Assert.That(ArrayStackCalculator.Calculate("15 19 +"), Is.EqualTo(34));

        Assert.That(ListStackCalculator.Calculate("2147483647 2147483647 +"), Is.EqualTo(4294967294));
        Assert.That(ArrayStackCalculator.Calculate("2147483647 2147483647 +"), Is.EqualTo(4294967294));

        Assert.That(ListStackCalculator.Calculate("-2147483648 -2147483648 +"), Is.EqualTo(-4294967296));
        Assert.That(ArrayStackCalculator.Calculate("-2147483648 -2147483648 +"), Is.EqualTo(-4294967296));

        Assert.That(ListStackCalculator.Calculate("-2147483648 2 +"), Is.EqualTo(-2147483646));
        Assert.That(ArrayStackCalculator.Calculate("-2147483648 2 +"), Is.EqualTo(-2147483646));

        Assert.That(ListStackCalculator.Calculate("0 0 +"), Is.EqualTo(0));
        Assert.That(ArrayStackCalculator.Calculate("0 0 +"), Is.EqualTo(0));

        Assert.That(ListStackCalculator.Calculate("-1 0 +"), Is.EqualTo(-1));
        Assert.That(ArrayStackCalculator.Calculate("-1 0 +"), Is.EqualTo(-1));
    }
    [Test]
    public void TestDivision ()
    {
        Assert.That(ListStackCalculator.Calculate("15 19 -"), Is.EqualTo(4));
        Assert.That(ArrayStackCalculator.Calculate("15 19 -"), Is.EqualTo(4));

        Assert.That(ListStackCalculator.Calculate("2147483647 2147483647 -"), Is.EqualTo(0));
        Assert.That(ArrayStackCalculator.Calculate("2147483647 2147483647 -"), Is.EqualTo(0));

        Assert.That(ListStackCalculator.Calculate("-2147483648 -2147483648 -"), Is.EqualTo(0));
        Assert.That(ArrayStackCalculator.Calculate("-2147483648 -2147483648 -"), Is.EqualTo(0));

        Assert.That(ListStackCalculator.Calculate("-2147483648 2 -"), Is.EqualTo(2147483650));
        Assert.That(ArrayStackCalculator.Calculate("-2147483648 2 -"), Is.EqualTo(2147483650));

        Assert.That(ListStackCalculator.Calculate("0 0 -"), Is.EqualTo(0));
        Assert.That(ArrayStackCalculator.Calculate("0 0 -"), Is.EqualTo(0));

        Assert.That(ListStackCalculator.Calculate("-1 0 -"), Is.EqualTo(1));
        Assert.That(ArrayStackCalculator.Calculate("-1 0 -"), Is.EqualTo(1));
    }
}