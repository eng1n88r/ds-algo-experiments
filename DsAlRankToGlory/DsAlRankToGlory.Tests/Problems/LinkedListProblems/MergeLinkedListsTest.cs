using System.Collections.Generic;
using DsAlRankToGlory.DataStructures;
using DsAlRankToGlory.Problems.LinkedListProblems;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DsAlRankToGlory.Tests.Problems.LinkedListProblems;

[TestClass]
[TestSubject(typeof(MergeLinkedLists))]
public class MergeLinkedListsTest
{
    private readonly MergeLinkedLists merger = new MergeLinkedLists();

    [TestMethod()]
    public void MergeTest()
    {
        var one = CreateLinkedList(new int[] { 1, 2, 4, 8 });
        var two = CreateLinkedList(new int[] { 0, 3, 5, 7 });
        var three = CreateLinkedList(new int[] { 6, 9, 11, 45 });
        var four = CreateLinkedList(new int[] { 12, 13, 15, 17 });

        List<LinkedListNode> collection = new List<LinkedListNode>();

        collection.Add(one);
        collection.Add(two);
        collection.Add(three);
        collection.Add(four);

        var result = merger.MergeNLists(collection);

        var isSorted = true;

        while (result.NextNode != null)
        {
            if (result.Data > result.NextNode.Data)
            {
                isSorted = false;
            }

            result = result.NextNode;
        }

        Assert.IsTrue(isSorted);
    }

    private LinkedListNode CreateLinkedList(int[] input)
    {
        LinkedListNode result = new LinkedListNode(input[0]);
        LinkedListNode head = result;

        for (int i = 1; i < input.Length; i++)
        {
            result.NextNode = new LinkedListNode(input[i]);
            result = result.NextNode;
        }

        return head;
    }
}