namespace DsAlRankToGlory.Problems.SortingAndSearching;

public class TomAndJerryFirst
{
    public static void Run()
    {
        var fieldDimension = Console.ReadLine();

        var jerryPosition = Console.ReadLine();

        int xLimit = Convert.ToInt32(fieldDimension?.Split(' ')[0]);
        int yLimit = Convert.ToInt32(fieldDimension?.Split(' ')[1]);

        int jerryXPosition = Convert.ToInt32(jerryPosition?.Split(' ')[0]) - 1;
        int jerryYPosition = Convert.ToInt32(jerryPosition?.Split(' ')[1]) - 1;

        var fieldMatrix = new bool[xLimit, yLimit];

        for (var i = 0; i < yLimit; i++)
        {
            var line = Console.ReadLine() ?? throw new ArgumentNullException();

            var lineArray = line.Split(' ');

            var x = 0;

            foreach (var item in lineArray)
            {
                fieldMatrix[x, i] = Convert.ToBoolean(Convert.ToInt32(item));
                x += 1;
            }
        }

        var tomXPosition = 0;
        var tomYPosition = 0;
        var prevX = 0;
        var prevY = 0;

        while (fieldMatrix[tomXPosition, tomYPosition] == false)
        {
            var moveCounter = 0;

            while (true)
            {
                var nextMove = MoveForwardCoordinates(fieldMatrix, tomXPosition, tomYPosition, prevX, prevY);

                if (nextMove == null)
                {
                    fieldMatrix[tomXPosition, tomYPosition] = true;

                    tomXPosition = 0;
                    tomYPosition = 0;

                    prevX = 0;
                    prevY = 0;

                    break;
                }

                prevX = tomXPosition;
                prevY = tomYPosition;
                tomXPosition = nextMove.Item1;
                tomYPosition = nextMove.Item2;

                moveCounter += 1;

                if (tomXPosition != jerryXPosition || tomYPosition != jerryYPosition) continue;
                
                Console.WriteLine(moveCounter);

                return;
            }
        }

        Console.WriteLine(-1);
    }

    public static Tuple<int, int>? MoveForwardCoordinates(bool[,] matrix, int x, int y, int previousX, int previousY)
    {
        var xMax = matrix.GetUpperBound(0);
        var yMax = matrix.GetUpperBound(1);

        if (x < xMax && x + 1 != previousX && matrix[x + 1, y] == false)
        {
            return Tuple.Create(x + 1, y);
        }

        if (y < yMax && y + 1 != previousY && matrix[x, y + 1] == false)
        {
            return Tuple.Create(x, y + 1);
        }

        if (x > 0 && x - 1 != previousX && matrix[x - 1, y] == false)
        {
            return Tuple.Create(x - 1, y);
        }

        if (y > 0 && y - 1 != previousY && matrix[x, y - 1] == false)
        {
            return Tuple.Create(x, y - 1);
        }

        return null;
    }
}