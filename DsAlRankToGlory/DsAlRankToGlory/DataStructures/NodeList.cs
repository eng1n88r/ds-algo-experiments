using System.Collections.ObjectModel;

namespace DsAlRankToGlory.DataStructures;

public class NodeList<T>: Collection<Node<T>>
{
    #region Constructors

    public NodeList() : base() { }

    public NodeList(int initialSize)
    {
        for (var i = 0; i < initialSize; i++)
        {
            base.Items.Add(default(Node<T>));
        }
    }

    #endregion Constructors

    #region Public Interface

    public Node<T>? FindByValue(T value)
    {
        foreach (Node<T> node in Items)
        {
            if (node.Value != null && node.Value.Equals(value))
            {
                return node;
            }
        }

        return null;
    }

    #endregion Public Interface
}