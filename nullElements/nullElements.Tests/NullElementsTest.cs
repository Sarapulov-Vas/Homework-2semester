// <copyright file="NullElementsTest.cs" company="Sarapulov Vasiliy">
// Copyright (c) Sarapuliv Vasiliy. All rights reserved.
// </copyright>

namespace nullElements.Tests;
using NullElements;

public class Tests
{
    [Test]
    public void TestIntList()
    {
        var isNull = new NullInt();
        List<int> testList = [1, 2, 3, 4, 0, 10, 0];
        Assert.That(NullElements.Count(testList, isNull), Is.EqualTo(2));
    }

    [Test]
    public void TestStringList()
    {
        var isNull = new NullString();
        List<string> testList = ["abc", "bac", "", "123", "", "1abc", ""];
        Assert.That(NullElements.Count(testList, isNull), Is.EqualTo(3));
    }

    [Test]
    public void TestNullElement()
    {
        var isNull = new NullInt();
        List<int?> testList = [1, 2, 3, 4, 0, null];
        Assert.Throws<ArgumentNullException>(() => NullElements.Count(testList, isNull));
    }

    [Test]
    public void TestNullListAndNullChecker()
    {
        NullInt? nullIsNull = null;
        List<int?>? nullTestList = null;
        var isNull = new NullInt();
        List<int?> testList = [1, 2, 3, 4, 0, 10];
        Assert.Throws<ArgumentNullException>(() => NullElements.Count(testList, nullIsNull));
        Assert.Throws<ArgumentNullException>(() => NullElements.Count(nullTestList, isNull));
    }

    public class NullInt : IIsNull
    {
        public bool IsNull(object? element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }
            return (int)element == 0;
        }
    }

    public class NullString : IIsNull
    {
        public bool IsNull(object? element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }
            return (string)element == String.Empty;
        }
    }
}