namespace BubbleSort.Tests;

public class Tests
{
    [TestCaseSource(typeof(TestData), nameof(TestData.TestCasesInt))]
    public void TestSortInt(List<int> list, List<int> expectedResult)
    {
        var comparer = new ComparerInt();
        var result = BubbleSort.Sort(list, comparer);
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.TestCasesIntRevers))]
    public void TestSortIntReversOrder(List<int> list, List<int> expectedResult)
    {
        var comparer = new ComparerIntRevers();
        var result = BubbleSort.Sort(list, comparer);
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.TestCasesString))]
    public void TestSortString(List<string> list, List<string> expectedResult)
    {
        var comparer = new ComparerString();
        var result = BubbleSort.Sort(list, comparer);
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [TestCaseSource(typeof(TestData), nameof(TestData.TestCasesArray))]
    public void TestSortString(List<int[]> list, List<int[]> expectedResult)
    {
        var comparer = new ComparerIntArray();
        var result = BubbleSort.Sort(list, comparer);
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    public void TestExceptions()
    {
        var comparer = new ComparerInt();
        int[] list = [1, 2, 3];
        Assert.Throws<ArgumentNullException>(() => BubbleSort.Sort(list, null));
        Assert.Throws<ArgumentNullException>(() => BubbleSort.Sort(null, comparer));
    }

    public class ComparerInt : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if (x > y)
            {
                return 1;
            }
            else if (x == y)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
    }

    public class ComparerIntRevers : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if (x > y)
            {
                return -1;
            }
            else if (x == y)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }

    public class ComparerString : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return string.Compare(x, y);
        }
    }

    public class ComparerIntArray : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            if (x.Length > y.Length)
            {
                return 1;
            }
            else if (x == y)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
    }

    public static class TestData
    {
        public static IEnumerable<TestCaseData> TestCasesInt()
        {
            (List<int>, List<int>)[] DataCase = 
            [
                ([1, 2, 3], [1, 2, 3]), ([-1, 100, 20, 30, 1, 5], [-1, 1, 5, 20, 30, 100]),
                ([100, 30, 20, 5, 1, -1], [-1, 1, 5, 20, 30, 100])
            ];

            foreach (var element in DataCase)
            {
                yield return new TestCaseData(element.Item1, element.Item2);
            }
        }

        public static IEnumerable<TestCaseData> TestCasesIntRevers()
        {
            (List<int>, List<int>)[] DataCase = 
            [
                ([1, 2, 3], [3, 2, 1]), ([-1, 100, 20, 30, 1, 5], [100, 30, 20, 5, 1, -1]),
                ([100, 20, 30, 1, -1, 5], [100, 30, 20, 5, 1, -1])
            ];

            foreach (var element in DataCase)
            {
                yield return new TestCaseData(element.Item1, element.Item2);
            }
        }

        public static IEnumerable<TestCaseData> TestCasesString()
        {
            (List<string>, List<string>)[] DataCase = 
            [
                (["abc", "bca", "cab"], ["abc", "bca", "cab"]), (["cab", "bca", "abc"], ["abc", "bca", "cab"]),
                (["MATMEX", "MAT", "MEX", "PM-PU"], ["MAT", "MATMEX", "MEX", "PM-PU"])
            ];

            foreach (var element in DataCase)
            {
                yield return new TestCaseData(element.Item1, element.Item2);
            }
        }

        public static IEnumerable<TestCaseData> TestCasesArray()
        {
            (List<int[]>, List<int[]>)[] DataCase = 
            [
                ([[1, 2], [3, 4, 5], [1]], [[1], [1, 2], [3, 4, 5]]), ([[10000]], [[10000]]),
                ([[1, 2, 3, 4], [1], [1, 2, 3], [1000]], [[1], [1000], [1, 2, 3], [1, 2, 3, 4]])
            ];

            foreach (var element in DataCase)
            {
                yield return new TestCaseData(element.Item1, element.Item2);
            }
        }
    }
}