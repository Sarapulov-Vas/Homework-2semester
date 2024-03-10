namespace stackCalculator.Tests;

public class StackTests
{
    double epsilon = 1e-10;
    private static IEnumerable<TestCaseData> Stack()
    {
        yield return new TestCaseData(new ListStack());
        yield return new TestCaseData(new ArrayStack());
    }

    [TestCaseSource(nameof(Stack))]
    public void TestsSackSize (IStack stack)
    {
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        Assert.That(stack.Length, Is.EqualTo(3));
        stack.Pop();
        Assert.That(stack.Length, Is.EqualTo(2));
        stack.Pop();
        Assert.That(stack.Length, Is.EqualTo(1));
        stack.Pop();
        Assert.That(stack.Length, Is.EqualTo(0));
    }

    [TestCaseSource(nameof(Stack))]
    public void TestsStackorrectness (IStack stack)
    {
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        Assert.That(Math.Abs(stack.Pop() - 3) < epsilon);
        Assert.That(Math.Abs(stack.Pop() - 2) < epsilon);
        Assert.That(Math.Abs(stack.Pop() - 1) < epsilon);
    }
}