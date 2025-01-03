namespace DsAlRankToGlory.DataStructures;

public class Stack
{
    public LinkedListNode Top { get; set; }

    public int Pop()
    {
        if (Top != null)
        {
            int item = Top.Data;
            Top = Top.NextNode;
            return item;
        }
        return 0;
    }

    public void Push(int data)
    {
        LinkedListNode newNode = new LinkedListNode(data);
        newNode.NextNode = Top;
        Top = newNode;
    }

    public int Peek()
    {
        return this.Top.Data;
    }
}