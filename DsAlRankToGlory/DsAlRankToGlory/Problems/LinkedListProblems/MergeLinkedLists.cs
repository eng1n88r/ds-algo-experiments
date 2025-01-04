using DsAlRankToGlory.DataStructures;

namespace DsAlRankToGlory.Problems.LinkedListProblems;

public class MergeLinkedLists
{
    public LinkedListNode? MergeNLists(List<LinkedListNode> collection)
    {
        LinkedListNode? result = null;

        foreach (var item in collection)
        {
            result = MergeIteratively(item, result);
        }

        return result;
    }

    private LinkedListNode? MergeIteratively(LinkedListNode? one, LinkedListNode? two)
    {
        if (one == null) return two;
        if (two == null) return one;
        
        LinkedListNode head;

        if (one.Data < two.Data)
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
            if (one.NextNode.Data > two.Data)
            {
                (one.NextNode, two) = (two, one.NextNode);
            }

            one = one.NextNode;
        }

        one.NextNode ??= two;

        return head;
    }

    private LinkedListNode? MergeRecursion(LinkedListNode? one, LinkedListNode? two)
    {
        if (one == null) return two;
        if (two == null) return one;
        
        if (one.Data < two.Data)
        {
            one.NextNode = MergeRecursion(one.NextNode, two);

            return one;
        }

        two.NextNode = MergeRecursion(two.NextNode, one);

        return two;
    }
}