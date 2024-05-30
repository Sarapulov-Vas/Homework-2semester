// <copyright file="NullElementsTest.cs" company="Sarapulov Vasiliy">
// Copyright (c) Sarapuliv Vasiliy. All rights reserved.
// </copyright>

namespace NullElements.Tests;
public class Tests
{
    /// <summary>
    /// Test of counting zeros in int.
    /// </summary>
    [Test]
    public void TestIntList()
    {
        var isNull = new NullInt();
        List<int> testList = [1, 2, 3, 4, 0, 10, 0];
        Assert.That(NullElements.Count(testList, isNull), Is.EqualTo(2));
    }

    /// <summary>
    /// Test of counting zeros in strings.
    /// </summary>
    [Test]
    public void TestStringList()
    {
        var isNull = new NullString();
        List<string> testList = ["abc", "bac", "", "123", "", "1abc", ""];
        Assert.That(NullElements.Count(testList, isNull), Is.EqualTo(3));
    }

    /// <summary>
    /// Test Null elements in list.
    /// </summary>
    [Test]
    public void TestNullElement()
    {
        var isNull = new NullInt();
        List<int?> testList = [1, 2, 3, 4, 0, null];
        Assert.Throws<ArgumentNullException>(() => NullElements.Count(testList, isNull));
    }

    /// <summary>
    /// Test null list.
    /// </summary>
    [Test]
    public void TestNullListAndNullChecker()
    {
        NullInt? nullIsNull = null;
        List<int?>? nullTestList = null;
        var isNull = new NullInt();
        List<int?> testList = [1, 2, 3, 4, 0, 10];
        Assert.Throws<ArgumentNullException>(() => NullElements.Count(testList, nullIsNull!));
        Assert.Throws<ArgumentNullException>(() => NullElements.Count(nullTestList!, isNull));
    }

    /// <summary>
    /// Class checking int for null.
    /// </summary>
    public class NullInt : IIsNull
    {
        public bool IsNull(object? element)
        {
            ArgumentNullException.ThrowIfNull(element);
            return (int)element == 0;
        }
    }

    /// <summary>
    /// Class checking strings for null.
    /// </summary>
    public class NullString : IIsNull
    {
        public bool IsNull(object? element)
        {
            ArgumentNullException.ThrowIfNull(element);
            return (string)element == String.Empty;
        }
    }
}