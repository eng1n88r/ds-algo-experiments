using DsAlRankToGlory.DataStructures;

namespace DsAlRankToGlory.Problems.TreeProblems;

public class Traversals
{
    public void InOrderTraverse(TreeNode root)
    {
        if(root != null)
        {
            InOrderTraverse(root.Left);
            Console.WriteLine($"{root.Data} in {root.Position.ToString()} position");
            InOrderTraverse(root.Right);
        }
    }

    public void PreOrderTraverse(TreeNode root)
    {
        if(root != null)
        {
            Console.WriteLine($"{root.Data} in {root.Position.ToString()} position");
            PreOrderTraverse(root.Left);
            PreOrderTraverse(root.Right);
        }
    }

    public void PostOrderTraverse(TreeNode root)
    {
        if (root != null)
        {
            PostOrderTraverse(root.Left);
            PostOrderTraverse(root.Right);
            Console.WriteLine($"{root.Data} in {root.Position.ToString()} position");
        }
    }
}