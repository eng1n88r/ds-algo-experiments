using System.Collections.Generic;
using DsAlRankToGlory.DataStructures;
using DsAlRankToGlory.Problems.TreeProblems;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DsAlRankToGlory.Tests.Problems.TreeProblems;

[TestClass]
[TestSubject(typeof(DepthFirstSearch))]
public class DepthFirstSearchTest
{
    private readonly DepthFirstSearch dfsEngine = new DepthFirstSearch();

    [TestMethod()]
    public void SearchLevelsTest()
    {
        var tree = CreateTree();
        Dictionary<int, IList<TreeNode>> map = new Dictionary<int, IList<TreeNode>>();
        dfsEngine.Search(tree, 0, map);

        Assert.IsTrue(map.ContainsKey(4));
    }

    private TreeNode CreateTree()
    {
        var root = new TreeNode(8);

        root.Left = new TreeNode(6);
        root.Left.Left = new TreeNode(12);
        root.Left.Left.Left = new TreeNode(4);
        root.Left.Left.Right = new TreeNode(7);

        root.Right = new TreeNode(5);
        root.Right.Left = new TreeNode(3);
        root.Right.Left.Left = new TreeNode(18);
        root.Right.Left.Right = new TreeNode(15);

        root.Right.Right = new TreeNode(1);
        root.Right.Right.Right = new TreeNode(2);
        root.Right.Right.Right.Left = new TreeNode(13);

        return root;
    }
}