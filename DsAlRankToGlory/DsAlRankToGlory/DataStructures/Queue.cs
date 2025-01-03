namespace DsAlRankToGlory.DataStructures;

public class Queue
{
    public LinkedListNode First { get; set; }
    public LinkedListNode Last { get; set; }

    public void Enqueue(int data)
    {
        if (First == null)
        {
            Last = new LinkedListNode(data);
            First = Last;
        }
        else
        {
            Last.NextNode = new LinkedListNode(data);
            Last = Last.NextNode;
        }
    }

    public int Dequeue()
    {
        if (this.First != null)
        {
            int item = this.First.Data;
            this.First = First.NextNode;
            return item;
        }

        return 0;
    }
}