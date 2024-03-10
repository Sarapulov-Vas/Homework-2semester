namespace stackCalculator.Tests;

public class CalculateorTests
{
    double epsilon = 1e-10;
    private static IEnumerable<TestCaseData> Calculator()
    {
        yield return new TestCaseData(new StackCalculator(new ListStack()));
        yield return new TestCaseData(new StackCalculator(new ArrayStack()));
    }

    [TestCaseSource(nameof(Calculator))]
    public void TestCorrectInput (StackCalculator calculator)
    {
        Assert.That(Math.Abs(calculator.Calculate("1 2 2 4 5 * / + -") - 11) < epsilon);
    }

    [TestCaseSource(nameof(Calculator))]
    public void TestDivisionByZero (StackCalculator calculator)
    {
        Assert.Throws<DivideByZeroException>(() => calculator.Calculate("0 2 /"));
    }

    [TestCaseSource(nameof(Calculator))]
    public void TestIncorrectInput (StackCalculator calculator)
    {
        Assert.Throws<ArgumentException>(() => calculator.Calculate("0b1 -10e +"));

        Assert.Throws<ArgumentException>(() => calculator.Calculate("5 10 ="));

        Assert.Throws<ArgumentException>(() => calculator.Calculate(""));
    }

    [TestCaseSource(nameof(Calculator))]
    public void TestMoreArgumentsThanOperations (StackCalculator calculator)
    {
        Assert.Throws<Exception>(() => calculator.Calculate("1 2 3 +"));
    }

    [TestCaseSource(nameof(Calculator))]
    public void TestMoreOperationsThanArguments (StackCalculator calculator)
    {
        Assert.Throws<Exception>(() => calculator.Calculate("1 2 + +"));
    }

    [TestCaseSource(nameof(Calculator))]
    public void TestAddition (StackCalculator calculator)
    {
        Assert.That(Math.Abs(calculator.Calculate("15 19 +") - 34) < epsilon);

        Assert.That(Math.Abs(calculator.Calculate("2147483647 2147483647 +") - 4294967294) < epsilon);

        Assert.That(Math.Abs(calculator.Calculate("-2147483648 -2147483648 +") - -4294967296) < epsilon);

        Assert.That(Math.Abs(calculator.Calculate("-2147483648 2 +") - -2147483646) < epsilon);

        Assert.That(Math.Abs(calculator.Calculate("0 0 +")) < epsilon);

        Assert.That(Math.Abs(calculator.Calculate("-1 0 +") - -1) < epsilon);
    }
    [TestCaseSource(nameof(Calculator))]
    public void TestSubtraction (StackCalculator calculator)
    {
        Assert.That(Math.Abs(calculator.Calculate("15 19 -") - 4) < epsilon);

        Assert.That(Math.Abs(calculator.Calculate("2147483647 2147483647 -")) < epsilon);

        Assert.That(Math.Abs(calculator.Calculate("-2147483648 -2147483648 -")) < epsilon);

        Assert.That(Math.Abs(calculator.Calculate("-2147483648 2 -") - 2147483650) < epsilon);

        Assert.That(Math.Abs(calculator.Calculate("0 0 -")) < epsilon);

        Assert.That(Math.Abs(calculator.Calculate("-1 0 -") - 1) < epsilon);
    }

    [TestCaseSource(nameof(Calculator))]
    public void TestMultiplication (StackCalculator calculator)
    {
        Assert.That(Math.Abs(calculator.Calculate("15 19 *") - 285) < epsilon);

        Assert.That(Math.Abs(calculator.Calculate("111111 -111111 *") - -12345654321) < epsilon);

        Assert.That(Math.Abs(calculator.Calculate("-111111 -111111 *") - 12345654321) < epsilon);

        Assert.That(Math.Abs(calculator.Calculate("0 0 *")) < epsilon);

        Assert.That(Math.Abs(calculator.Calculate("-1 0 *")) < epsilon);
    }

    [TestCaseSource(nameof(Calculator))]
    public void TestDivision (StackCalculator calculator)
    {
        Assert.That(Math.Abs(calculator.Calculate("5 15 /") - 3) < epsilon);

        Assert.That(Math.Abs(calculator.Calculate("111111 -111111 /") - -1) < epsilon);

        Assert.That(Math.Abs(calculator.Calculate("-111111 -111111 /") - 1) < epsilon);

        Assert.That(Math.Abs(calculator.Calculate("-1 0 *")) < epsilon);
    }
}