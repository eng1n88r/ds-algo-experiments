namespace DsAlRankToGlory.DataStructures;

public class GraphNode<T> : Node<T>
{
    #region Private Members

    private List<int> costs;

    #endregion Private Members

    #region Constructors

    public GraphNode() : base() { this.DistanceToRoot = -1; }

    public GraphNode(T value) : base(value) { }

    public GraphNode(T value, NodeList<T> neighbors) : base(value, neighbors) { }

    #endregion Conostructors

    #region Public Interface 

    public bool Visited { get; set; }

    public int DistanceToRoot { get; set; }

    new public NodeList<T> Neighbors
    {
        get
        {
            if (base.Neighbors == null)
            {
                base.Neighbors = new NodeList<T>();
            }

            return base.Neighbors;
        }
    }

    public List<int> Costs
    {
        get
        {
            if (costs == null)
            {
                costs = new List<int>();
            }

            return this.costs;
        }
    }

    #endregion Public Interface
}