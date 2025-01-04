using System;
using DsAlRankToGlory.Problems.SortingAndSearching;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DsAlRankToGlory.Tests.Problems.SortingAndSearching;

[TestClass]
[TestSubject(typeof(MergeSortedArrays))]
public class MergeSortedArraysTest
{
    private readonly MergeSortedArrays merger = new MergeSortedArrays();

    [TestMethod()]
    public void SuccessStartTest()
    {
        int[] arrayA = new int[10] { 2, 5, 8, 9, 11, 0, 0, 0, 0, 0 };
        int[] arrayB = new int[5] { 1, 3, 4, 6, 12 };

        merger.Start(arrayA, arrayB, 5);

        var result = new int[10] { 1, 2, 3, 4, 5, 6, 8, 9, 11, 12 };
        bool areTheSame = true;

        for (int i = 0; i < arrayA.Length; i++)
        {
            if (arrayA[i] != result[i])
            {
                areTheSame = false;
                break;
            }
        }

        Assert.IsTrue(areTheSame);
    }

    [TestMethod()]
    [ExpectedException(typeof(ArgumentException))]
    public void ArgumentExceptionStartTest()
    {
        int[] a = new int[5] { 2, 5, 8, 9, 11 };
        int[] b = new int[5] { 1, 3, 4, 6, 12 };

        merger.Start(a, b, 0);

        Assert.Fail();
    }

    [TestMethod()]
    [ExpectedException(typeof(ArgumentNullException))]
    public void ArgumentNullExceptionStartTest()
    {
        int[] a = null;
        int[] b = null;

        merger.Start(a, b, 0);

        Assert.Fail();
    }
}