namespace DsAlRankToGlory.Problems.SortingAndSearching;

public class MergeSort
{
    public void SortArray(int[] array)
    {
        var copy = new int[array.Length];

        Sort(array, copy, 0, array.Length - 1);
    }

    private void Sort(int[] array, int[] helper, int low, int high)
    {
        if (low >= high) return;
        
        var mid = (low + high) / 2;

        Sort(array, helper, low, mid);
        Sort(array, helper, mid + 1, high);
        Merge(array, helper, low, mid, high);
    }

    private void Merge(int[] array, int[] helper, int low, int mid, int high)
    {
        for (var i = low; i <= high; i++)
        {
            helper[i] = array[i];
        }

        var helperLeft = low;
        var helperRight = mid + 1;

        var current = low;

        while (helperLeft <= mid && helperRight <= high)
        {
            if (helper[helperLeft] <= helper[helperRight])
            {
                array[current] = helper[helperLeft];
                helperLeft++;
            }
            else
            {
                array[current] = helper[helperRight];
                helperRight++;
            }

            current++;
        }

        var remaining = mid - helperLeft;

        for (var i = 0; i <= remaining; i++)
        {
            array[current + i] = helper[helperLeft + i];
        }
    }
}