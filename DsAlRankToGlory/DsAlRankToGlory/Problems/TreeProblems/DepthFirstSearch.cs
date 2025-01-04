using DsAlRankToGlory.DataStructures;

namespace DsAlRankToGlory.Problems.TreeProblems;

public class DepthFirstSearch
{
    public void Search(TreeNode root, int level, IDictionary<int, IList<TreeNode>> levelMap)
    {
        if (root == null)
        {
            return;
        }

        if (levelMap.ContainsKey(level))
        {
            if (root.Position == Position.Left)
            {
                levelMap[level].Add(root);
            }
        }
        else
        {
            List<TreeNode> nodes = new List<TreeNode>();

            if (root.Position == Position.Left)
            {
                nodes.Add(root);
            }

            levelMap.Add(level, nodes);
        }

        Search(root.Left, level + 1, levelMap);
        Search(root.Right, level + 1, levelMap);
    }
}