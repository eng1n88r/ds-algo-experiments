namespace DsAlRankToGlory.DataStructures;

public class Node<T>
{
    #region Constructors

    public Node()
    {
    }
    
    public Node(T value): this(value, null)
    {
    }

    public Node(T value, NodeList<T> neighbors)
    {
        this.Value = value;
        this.Neighbors = neighbors;
    }

    #endregion Constructors

    #region Public Interface

    public T Value { get; set; }

    protected NodeList<T> Neighbors { get; set; } = null;

    #endregion Public Interface
}