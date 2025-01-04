namespace DsAlRankToGlory.Problems.SortingAndSearching;

public class MergeSortedArrays
{
    public void Start(int[] arrayA, int[] arrayB, int lastElementInA)
    {
        if(arrayA == null || arrayB == null)
        {
            throw new ArgumentNullException("arrayA and arrayB", "Null input");
        }

        if(arrayA.Length <= arrayB.Length)
        {
            throw new ArgumentException("arrayA should be able to store arrayB");
        }

        var lastAIndex = lastElementInA - 1;
        var lastBIndex = arrayB.Length - 1;

        var indexToInsert = lastElementInA + lastBIndex;

        while(lastBIndex >= 0)
        {
            if (lastAIndex >= 0 && arrayA[lastAIndex] > arrayB[lastBIndex])
            {
                arrayA[indexToInsert] = arrayA[lastAIndex];
                lastAIndex--;
            }
            else
            {
                arrayA[indexToInsert] = arrayB[lastBIndex];
                lastBIndex--;
            }

            indexToInsert--;
        }
    }
}