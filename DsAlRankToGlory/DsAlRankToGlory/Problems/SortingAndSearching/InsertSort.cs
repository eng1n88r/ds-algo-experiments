namespace DsAlRankToGlory.Problems.SortingAndSearching;

public class InsertSort
{
    static void Sort(int[] array)
    {
        for (var i = array.Length - 1; i >= 0; i--)
        {
            /* select value to be inserted */
            var valueToInsert = array[i];

            var holePosition = i;

            /*locate hole position for the element to be inserted */

            while (holePosition > 0 && array[holePosition - 1] > valueToInsert)
            {
                array[holePosition] = array[holePosition - 1];

                holePosition -= 1;
            }

            /* insert the number at hole position */
            array[holePosition] = valueToInsert;

            foreach (var item in array)
            {
                Console.Write("{0} ", item);
            }

            Console.WriteLine();
        }
    }

    static void Sort2(int[] ar)
    {
        var valueToInsert = ar[^1];

        for (var i = ar.Length - 1; i >= 0; i--)
        {
            if (ar[i] > valueToInsert)
            {
                ar[i + 1] = ar[i];
                PrintResult(ar);

                if (i != 0) continue;

                ar[i] = valueToInsert;
                PrintResult(ar);
            }
            else if (ar[i] < valueToInsert)
            {
                ar[i + 1] = valueToInsert;
                PrintResult(ar);
                return;
            }
            else
            {
                ar[i + 1] = valueToInsert;
                PrintResult(ar);
            }
        }
    }

    private static void PrintResult(int[] array)
    {
        foreach (var t in array)
        {
            Console.Write("{0} ", t);
        }

        Console.WriteLine();
    }
}