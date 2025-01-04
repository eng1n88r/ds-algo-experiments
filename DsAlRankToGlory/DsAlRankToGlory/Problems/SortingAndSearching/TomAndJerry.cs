namespace DsAlRankToGlory.Problems.SortingAndSearching;

public class TomAndJerry
{
    private const string WallTexture = "██";

    public static void Run(string[] args)
    {
        // 1 = Wall
        // 2 = Tom
        // 3 = Jerry
        var mazeData =
            new[]
            {
                "0 0 0 0 0 0 0 0 0",
                "0 1 0 1 1 1 1 1 0",
                "0 1 0 0 0 1 0 1 0",
                "0 1 3 1 0 0 0 1 0",
                "0 1 1 1 0 1 1 1 0",
                "0 1 2 0 0 1 0 0 0",
                "0 0 0 1 0 1 1 0 1",
                "1 1 0 1 0 0 0 0 0",
                "1 0 0 0 1 1 0 0 0",
            };

        var mazeWidth = mazeData[0].Split([' '], StringSplitOptions.RemoveEmptyEntries).Length;
        var mazeHeight = mazeData.GetUpperBound(0) + 1;

        MazeCell? tomCell = null;
        MazeCell? jerryCell = null;

        var maze = new MazeCell[mazeHeight, mazeWidth];

        for (var i = 0; i < mazeHeight; i++)
        {
            var cellTypes = mazeData[i].Split(' ').Select(x => (MazeCellTypes)Convert.ToInt32(x)).ToArray();

            for (var j = 0; j < mazeWidth; j++)
            {
                var currentCell = new MazeCell()
                {
                    Type = cellTypes[j],
                    X = j,
                    Y = i
                };

                maze[i, j] = currentCell;

                switch (currentCell.Type)
                {
                    case MazeCellTypes.Tom:
                        tomCell = currentCell;
                        break;
                    case MazeCellTypes.Jerry:
                        jerryCell = currentCell;
                        break;
                }
            }
        }

        PrintMaze(maze);

        var cellQueue = new Queue<MazeCell>();

        if (tomCell != null) cellQueue.Enqueue(tomCell);

        while (cellQueue.Count > 0)
        {
            var currentCell = cellQueue.Dequeue();

            // Uncomment to stop processing on Jerry.
            //if (currentCell.Type == MazeCellTypes.Jerry)
            //{
            //	break;
            //}

            EnqueueNextCells(cellQueue, currentCell, maze);

            //Uncomment to watch step-by-step.
            PrintMaze(maze);
            Console.ReadKey();
        }

        PrintMaze(maze);

        Console.WriteLine("Path to Jerry: " + (jerryCell?.Distance > 0 ? jerryCell.Distance : -1));
        Console.WriteLine();
    }

    public static void EnqueueNextCells(Queue<MazeCell> cellQueue, MazeCell currentCell, MazeCell[,] maze)
    {
        var mazeWidth = maze.GetUpperBound(1) + 1;
        var mazeHeght = maze.GetUpperBound(0) + 1;

        if (currentCell.X + 1 < mazeWidth)
        {
            var nextCell = maze[currentCell.Y, currentCell.X + 1];

            EnqueueNextCell(cellQueue, currentCell, nextCell);
        }

        if (currentCell.Y + 1 < mazeHeght)
        {
            var nextCell = maze[currentCell.Y + 1, currentCell.X];

            EnqueueNextCell(cellQueue, currentCell, nextCell);
        }

        if (currentCell.X - 1 >= 0)
        {
            var nextCell = maze[currentCell.Y, currentCell.X - 1];

            EnqueueNextCell(cellQueue, currentCell, nextCell);
        }

        if (currentCell.Y - 1 >= 0)
        {
            var nextCell = maze[currentCell.Y - 1, currentCell.X];

            EnqueueNextCell(cellQueue, currentCell, nextCell);
        }
    }

    public static void EnqueueNextCell(Queue<MazeCell> cellQueue, MazeCell currentCell, MazeCell nextCell)
    {
        if (nextCell is not { Distance: 0, Type: MazeCellTypes.Road or MazeCellTypes.Jerry }) return;
        
        nextCell.Distance = currentCell.Distance + 1;
        cellQueue.Enqueue(nextCell);
    }

    public static void PrintMaze(MazeCell[,] maze)
    {
        var mazeWidth = maze.GetUpperBound(1) + 1;
        var mazeHeight = maze.GetUpperBound(0) + 1;

        var wallCell = new MazeCell()
        {
            Type = MazeCellTypes.Wall
        };

        for (var i = 0; i < mazeWidth + 2; i++)
        {
            if (i > 0)
            {
                Console.Write(WallTexture[0]);
            }

            Console.Write(GetCellTexture(wallCell));
        }

        Console.WriteLine();

        for (var i = 0; i < mazeHeight; i++)
        {
            Console.Write(GetCellTexture(wallCell));

            for (var j = 0; j < mazeWidth; j++)
            {
                var cell = maze[i, j];

                if (cell.Type == MazeCellTypes.Wall && (j == 0 || maze[i, j - 1].Type == MazeCellTypes.Wall))
                {
                    Console.Write(WallTexture[0]);
                }
                else
                {
                    Console.Write(" ");
                }

                Console.Write(GetCellTexture(cell));
            }

            Console.Write(" ");
            Console.Write(GetCellTexture(wallCell));

            Console.WriteLine();
        }

        for (var i = 0; i < mazeWidth + 2; i++)
        {
            if (i > 0)
            {
                Console.Write(WallTexture[0]);
            }

            Console.Write(GetCellTexture(wallCell));
        }

        Console.WriteLine();
        Console.WriteLine();
    }

    static string GetCellTexture(MazeCell cell) =>
        cell.Type switch
        {
            MazeCellTypes.Jerry => "JJ",
            MazeCellTypes.Wall => WallTexture,
            MazeCellTypes.Tom => "TT",
            _ => cell.Distance > 0 ? cell.Distance.ToString("00") : "  "
        };


    public class MazeCell
    {
        public MazeCellTypes Type { get; set; }

        public int Distance { get; set; }

        public MazeCell CameFrom { get; set; }

        public int X { get; set; }

        public int Y { get; set; }
    }

    public enum MazeCellTypes
    {
        Road,
        Wall,
        Tom,
        Jerry
    }
}