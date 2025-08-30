using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class MissingNumberFinderTests
{
    [TestMethod]
    public void TestFindMissingNumberV1()
    {
        var numbers = new List<int> { 2, 5, 1, 4, 9, 3, 7, 10, 8 };
        int expected = 6;
        int actual = MissingNumberFinder.FindMissingNumberV1(numbers, 10);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestFindMissingNumber()
    {
        var numbers = new List<int> { 2, 5, 1, 4, 9, 3, 7, 10, 8 };
        int expected = 6;
        int? actual = MissingNumberFinder.FindMissingNumber(numbers, 10);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestFindMissingNumberNone()
    {
        var numbers = new List<int> { 2, 5, 1, 4, 9, 3, 7, 10, 8, 6 };
        int? expected = null;
        int? actual = MissingNumberFinder.FindMissingNumber(numbers, 10);
        Assert.AreEqual(expected, actual);
    }
}
