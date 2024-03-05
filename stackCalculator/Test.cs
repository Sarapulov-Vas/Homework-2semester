/// <summary>
/// Test сlass.
/// </summary>
internal class Test
{
    /// <summary>
    /// Test Stack.
    /// </summary>
    private static readonly List<bool> TestsList = new List<bool>();

    /// <summary>
    /// Epsilon for comparing real numbers.
    /// </summary>
    private static double epsilon = 1e-10;

    /// <summary>
    /// A method for creating tests for a calculator.
    /// </summary>
    /// <param name="inputExpression">Test expression.</param>
    /// <param name="expectedResult">Expected result of the calculation.</param>
    public static void AddTest(string inputExpression, double expectedResult)
    {
        StackCalculator result = new StackCalculator(new ListStack());
        if (Math.Abs(result.Calculate(inputExpression) - expectedResult) < epsilon)
        {
            TestsList.Add(true);
        }
        else
        {
            TestsList.Add(false);
        }
    }

    /// <summary>
    /// Test run method.
    /// </summary>
    /// <returns>Test result.</returns>
    public static bool StartTest()
    {
        for (int i = 0; i < TestsList.Count; ++i)
        {
            if (TestsList[i] == true)
            {
                Console.WriteLine($"Test {i + 1} complit.");
            }
            else
            {
                Console.WriteLine($"Test {i + 1} failed!");
                return false;
            }
        }

        return true;
    }
}