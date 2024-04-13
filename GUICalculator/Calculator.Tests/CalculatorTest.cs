using static Calculator.Calculator;

namespace Calculator.Tests
{
    public class Tests
    {
        private readonly double epsilon = 1e-10;

        [TestCaseSource(typeof(TestData), nameof(TestData.TestCasesOperations))]
        public void TestOperations(Calculator calculator, string inputExpression, double[] expectedResult)
        {
            var expression = inputExpression.Split(' ');
            double num = 0;
            for (int i = 0; i < expression.Length; i += 2)
            {
                foreach (var digit in expression[i])
                {
                    if (digit == '.')
                    {
                        calculator.AddPoint();
                    }
                    else
                    {
                        num = double.Parse(calculator.AddDigit(int.Parse(Convert.ToString(digit))));
                    }
                }

                Assert.That(Math.Abs(expectedResult[i] - num) < epsilon);
                if (expression[i + 1] != '='.ToString())
                {
                    switch (expression[i + 1][0])
                    {
                        case '+':
                            Assert.That(Math.Abs(expectedResult[i + 1] - calculator.UseOperation(Operations.Addition)) < epsilon);
                            break;
                        case '-':
                            Assert.That(Math.Abs(expectedResult[i + 1] - calculator.UseOperation(Operations.Subtraction)) < epsilon);
                            break;
                        case '*':
                            Assert.That(Math.Abs(expectedResult[i + 1] - calculator.UseOperation(Operations.Multiplication)) < epsilon);
                            break;
                        case '/':
                            Assert.That(Math.Abs(expectedResult[i + 1] - calculator.UseOperation(Operations.Division)) < epsilon);
                            break;
                    }
                }
                else
                {
                    Assert.That(Math.Abs(expectedResult[i + 1] - calculator.GetResult()) < epsilon);
                }
            }
        }

        [Test]
        public void TestDivisionByZero()
        {
            var calculator = new Calculator();
            calculator.AddDigit(1);
            calculator.UseOperation(Operations.Division);
            calculator.AddDigit(0);
            Assert.Throws<DivideByZeroException>(() => calculator.GetResult());
        }

        [Test]
        public void TestDelateCurrentNumber()
        {
            var calculator = new Calculator();
            calculator.AddDigit(1);
            calculator.DelateCurrentNumber();
            Assert.That(Math.Abs(double.Parse(calculator.AddDigit(2)) - 2) < epsilon);
        }

        [Test]
        public void TestUseOPerationAfterGetResult()
        {
            var calculator = new Calculator();
            calculator.AddDigit(1);
            calculator.UseOperation(Operations.Addition);
            calculator.AddDigit(2);
            Assert.That(Math.Abs(calculator.GetResult() - 3) < epsilon);
            calculator.UseOperation(Operations.Multiplication);
            calculator.AddDigit(3);
            Assert.That(Math.Abs(calculator.GetResult() - 9) < epsilon);
            calculator.UseOperation(Operations.Subtraction);
            calculator.AddDigit(3);
            Assert.That(Math.Abs(calculator.GetResult() - 6) < epsilon);
            calculator.UseOperation(Operations.Division);
            calculator.AddDigit(3);
            Assert.That(Math.Abs(calculator.GetResult() - 2) < epsilon);
        }

        [TestCase("123", 12)]
        [TestCase("12.3", 12)]
        [TestCase("1.23", 1.2)]
        public void TestBackSpace(string testValue, double expectedResult)
        {
            var calculator = new Calculator();
            foreach (var digit in testValue)
            {
                if (digit == '.')
                {
                    calculator.AddPoint();
                }
                else
                {
                    double.Parse(calculator.AddDigit(int.Parse(Convert.ToString(digit))));
                }
            }

            Assert.That(Math.Abs(double.Parse(calculator.BackSpace()) - expectedResult) < epsilon);
        }

        public static class TestData
        {
            public static IEnumerable<TestCaseData> TestCasesOperations()
            {
                (string expression, double[] expectedResult)[] DataCase =
                    [
                        ("15 + 19 =", [15, 15, 19, 34]), ("100 - 5 =", [100, 100, 5, 95]),
                        ("123 * 2 =", [123, 123, 2, 246]), ("121 / 11 =", [121, 121, 11, 11]),
                        ("10.2 + 1 =", [10.2, 10.2, 1, 11.2]), ("10.123 / 4 =", [10.123, 10.123, 4, 2.53075]),
                        ("2.5 * 2.5 =", [2.5, 2.5, 2.5, 6.25]), ("1 + 2 * 3.5 - 0.2 =", [1, 1, 2, 3, 3.5, 10.5, 0.2, 10.3]),
                        ("0.1 * 0.1 + 0.99 / 2 - 0.5 =", [0.1, 0.1, 0.1, 0.01, 0.99, 1, 2, 0.5, 0.5, 0])
                    ];
                foreach (var input in DataCase)
                {
                    yield return new TestCaseData(new Calculator(), input.Item1, input.Item2);
                }
            }
        }
    }
}