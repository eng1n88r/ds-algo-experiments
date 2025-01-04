namespace DsAlRankToGlory.DataStructures;

public class TreeNode
{
    private TreeNode left;
    private TreeNode right;
    public Position Position { get; set; } = Position.Root;

    public TreeNode Right
    {
        get { return right; }
        set
        {
            right = value;
            right.Position = Position.Right;
        }
    }

    public TreeNode Left
    {
        get { return left; }
        set
        {
            left = value;
            left.Position = Position.Left;
        }
    }

    public TreeNode(int data)
    {
        this.Data = data;
    }

    public int Data { get; set; }

    public List<TreeNode> LinkedLeft { get; set; }
}

public enum Position
{
    Root,
    Left,
    Right
}