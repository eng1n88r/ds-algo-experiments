namespace DsAlRankToGlory.Utilities;

public static class Bitwise
{
    public static int Add(int x, int y)
    {
        while (y > 0)
        {
            var carrier = x & y;

            x ^= y;

            y = carrier << 1;
        }

        return x;
    }
}