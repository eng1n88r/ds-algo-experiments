using DsAlRankToGlory.Problems.SortingAndSearching;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DsAlRankToGlory.Tests.Problems.SortingAndSearching;

[TestClass]
[TestSubject(typeof(MergeSort))]
public class MergeSortTest
{
    private readonly MergeSort sorter = new MergeSort();

    [TestMethod()]
    public void SortArrayTest()
    {
        int[] array = new int[10] { 7, 5, 3, 1, 9, 2, 6, 8, 4, 12};

        sorter.SortArray(array);

        bool isSorted = true;

        for (int i = 0; i < array.Length - 1; i++)
        {
            if(array[i] > array[i+1])
            {
                isSorted = false;
            }
        }

        Assert.IsTrue(isSorted);
    }
}