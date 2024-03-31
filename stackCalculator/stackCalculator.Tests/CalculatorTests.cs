using Microsoft.VisualBasic;

namespace stackCalculator.Tests;

public class CalculateorTests
{
    private readonly double epsilon = 1e-10;

    [TestCaseSource(typeof(TestData), nameof(TestData.Calculator))]
    public void TestCorrectInput (StackCalculator calculator)
    {
        Assert.That(Math.Abs(calculator.Calculate("1 2 2 4 5 * / + -") - 11) < epsilon);
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.Calculator))]
    public void TestDivisionByZero (StackCalculator calculator)
    {
        Assert.Throws<DivideByZeroException>(() => calculator.Calculate("0 2 /"));
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.TestCasesIncorrectInput))]
    public void TestIncorrectInput (StackCalculator calculator, string inputString)
    {
        Assert.Throws<ArgumentException>(() => calculator.Calculate(inputString));
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.Calculator))]
    public void TestMoreArgumentsThanOperations (StackCalculator calculator)
    {
        Assert.Throws<Exception>(() => calculator.Calculate("1 2 3 +"));
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.Calculator))]
    public void TestMoreOperationsThanArguments (StackCalculator calculator)
    {
        Assert.Throws<Exception>(() => calculator.Calculate("1 2 + +"));
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.TestCasesOperations))]
    public void TestOperations (StackCalculator calculator, string inputString, double result)
    {
        Assert.That(Math.Abs(calculator.Calculate(inputString) - result) < epsilon);
    }

    public static class TestData
    {
        private static readonly List<StackCalculator> ListOfCalculators = 
            [new StackCalculator(new ListStack()), new StackCalculator(new ArrayStack())];

        public static IEnumerable<TestCaseData> Calculator()
        {
            foreach (var element in ListOfCalculators)
            {
                yield return new TestCaseData(element);
            }
        }

        public static IEnumerable<TestCaseData> TestCasesIncorrectInput()
        {
            string[] DataCase = {"0b1 -10e +", "5 10 =", ""};
            foreach (var element in ListOfCalculators)
            {
                foreach (var input in DataCase)
                {
                    yield return new TestCaseData(element, input);
                }
            }
        }

        public static IEnumerable<TestCaseData> TestCasesOperations()
        {
            (string, double)[] DataCase = 
                [
                    ("15 19 +", 34), ("2147483647 2147483647 +", 4294967294), ("-2147483648 -2147483648 +", -4294967296),
                    ("-2147483648 2 +", -2147483646), ("0 0 +", 0), ("-1 0 +", -1),
                    ("15 19 -", 4), ("2147483647 2147483647 -", 0), ("-2147483648 -2147483648 -", 0),
                    ("-2147483648 2 -", 2147483650), ("0 0 -", 0), ("-1 0 -", 1),
                    ("15 19 *", 285), ("111111 -111111 *", -12345654321), ("-111111 -111111 *", 12345654321),
                    ("0 0 *", 0), ("-1 0 *", 0), ("5 15 /", 3), 
                    ("111111 -111111 /", -1), ("-111111 -111111 /", 1)
                ];
            foreach (var element in ListOfCalculators)
            {
                foreach (var input in DataCase)
                {
                    yield return new TestCaseData(element, input.Item1, input.Item2);
                }
            }
        }
    }
}