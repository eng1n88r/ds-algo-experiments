using DsAlRankToGlory.DataStructures;

namespace DsAlRankToGlory.Problems.LinkedListProblems;

public class MergeLinkedLists
{
    public LinkedListNode MergeNLists(List<LinkedListNode> collection)
    {
        LinkedListNode result = null;

        for (int i = 0; i < collection.Count; i++)
        {
            result = MergeIteratively(collection[i], result);
        }

        return result;
    }

    private LinkedListNode MergeIteratively (LinkedListNode one, LinkedListNode two)
    {
        if(one == null)
        {
            return two;
        }

        if (two == null)
        {
            return one;
        }

        LinkedListNode head;

        if(one.Data < two.Data)
        {
            head = one;
        }
        else
        {
            head = two;
            two = one;
            one = head;
        }

        while (one.NextNode != null)
        {
            if(one.NextNode.Data > two.Data)
            {
                LinkedListNode tmp = one.NextNode;
                one.NextNode = two;
                two = tmp;
            }

            one = one.NextNode;
        }

        if (one.NextNode == null)
        {
            one.NextNode = two;
        }

        return head;
    }

    private LinkedListNode MergeRecursion(LinkedListNode one, LinkedListNode two)
    {
        if (one == null)
        {
            return two;
        }

        if (two == null)
        {
            return one;
        }
			
        if(one.Data < two.Data)
        {
            one.NextNode = MergeRecursion(one.NextNode, two);

            return one;
        }
        else
        {
            two.NextNode = MergeRecursion(two.NextNode, one);

            return two;
        }
    }
}