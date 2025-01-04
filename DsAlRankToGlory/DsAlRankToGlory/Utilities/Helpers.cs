namespace DsAlRankToGlory.Utilities;

public static class Helpers
{
    public static void Swap(ref int left, ref int right) =>
        (left, right) = (right, left);
    
    public static void Swap(ref int[] left, ref int[] right) =>
        (left, right) = (right, left);
}