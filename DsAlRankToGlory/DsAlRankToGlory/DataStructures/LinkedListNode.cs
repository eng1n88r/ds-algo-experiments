namespace DsAlRankToGlory.DataStructures;

public class LinkedListNode
{
    public int Data { get; set; }

    public LinkedListNode NextNode { get; set; }

    public LinkedListNode()
    {
    }

    public LinkedListNode(int data)
    {
        this.Data = data;
    }

    public void AppendToTheEnd(int value)
    {
        LinkedListNode end = new LinkedListNode(value);

        LinkedListNode current = this;

        while (current.NextNode != null)
        {
            current = current.NextNode;
        }

        current.NextNode = end;
    }

    public LinkedListNode FindNode(int data)
    {
        LinkedListNode result = this;

        while (result.Data != data)
        {
            if (result.NextNode == null)
            {
                return null;
            }

            result = result.NextNode;
        }

        return result;
    }
}