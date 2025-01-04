namespace DsAlRankToGlory.Problems.SortingAndSearching;

public class MergeSort
{
    public void SortArray(int[] array)
    {
        int[] copy = new int[array.Length];

        Sort(array, copy, 0, array.Length - 1);
    }

    private void Sort(int[] array, int[] helper, int low, int high)
    {
        if(low < high)
        {
            int mid = (low + high) / 2;

            Sort(array, helper, low, mid);
            Sort(array, helper, mid + 1, high);

            Merge(array, helper, low, mid, high);
        }
    }

    private void Merge(int[] array, int[] helper, int low, int mid, int high)
    {
        for (int i = low; i <= high; i++)
        {
            helper[i] = array[i];
        }

        int helperLeft = low;
        int helperRight = mid + 1;

        int current = low;

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

        int remaining = mid - helperLeft;

        for (int i = 0; i <= remaining; i++)
        {
            array[current + i] = helper[helperLeft + i];
        }
    }
}