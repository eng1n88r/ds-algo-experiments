namespace DsAlRankToGlory.Problems.Arrays;

public class RotateCircularArray(int[] source)
{
    private int[] Results { get; set; } = source;

    public void Display(int[] indexes)
    {
        foreach (var t in indexes)
        {
            Console.WriteLine(this.Results[t]);
        }
    }

    public void Rotate(int position)
    {
        var center = Results.Length - position;

        var left = new int[center];
        var right = new int[Results.Length - center];

        Array.Copy(Results, left, center);
        Array.Copy(Results, center, right, 0, Results.Length - center);
        Array.Reverse(right);
        var result = right.Concat(left).ToArray();

        Results = result;
    }
}