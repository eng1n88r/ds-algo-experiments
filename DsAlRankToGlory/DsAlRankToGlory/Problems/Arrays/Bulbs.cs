namespace DsAlRankToGlory.Problems.Arrays;

public class Bulbs
{
    /// <summary>
    /// Class containing methods to solve the Bulbs problem.
    /// </summary>
    /// <remarks>
    /// The time complexity of the Solve method is O(n^2), where n is the number of elements in the input list.
    /// </remarks>
    public static int Solve(List<int> input)
    {
        var counter = 0;

        for (var i = 0; i < input.Count; i++)
        {
            if (input[i] == 1)
            {
                continue;
            }

            counter++;
            input[i] = 1;

            var visit = true;
            var isAllOnes = true;

            for (var j = i + 1; j < input.Count; j++)
            {
                input[j] ^= 1;

                if (input[j] != 0 || !visit) continue;

                isAllOnes = false;
                i = j - 1;
                visit = false;
            }

            if (isAllOnes)
            {
                break;
            }
        }

        return counter;
    }

    /// <summary>
    /// Solves the Bulbs problem in linear time complexity.
    /// </summary>
    /// <param name="input">List of integers representing the state of bulbs.</param>
    /// <returns>The minimum number of switches needed to turn all bulbs on.</returns>
    /// <remarks>
    /// The time complexity of this method is O(n), where n is the number of elements in the input list.
    /// </remarks>
    public static int SolveInLinearComplexity(List<int> input)
    {
        var counter = 0;
        var flip = false;

        foreach (var item in input)
        {
            if (item == 0 && !flip || item == 1 && flip)
            {
                counter++;
                flip = !flip;
            }
        }

        return counter;
    }
}