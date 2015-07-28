using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Escape_from_Labyrinth;

public class EscapeFromLabyrinth
{
    private static char[,] labyrint;

    private static int width;
    private static int height;

    public static void Main()
    {
        ReadLabyrinth();
        var startingPoint = FindStartingPoint();
        var lastPoint = FindFirstExit(startingPoint);
        var pathTrace = TracePath(lastPoint);
        if (pathTrace == null)
        {
            Console.WriteLine("No exit!");
        }
        else if (pathTrace == "")
        {
            Console.WriteLine("Start is at the exit.");
        }
        else
        {
            Console.WriteLine("Shortest exit: {0}", pathTrace);
        }
    }

    private static void ReadLabyrinth()
    {
        width = int.Parse(Console.ReadLine());
        height = int.Parse(Console.ReadLine());
        labyrint = new char[height, width];
        for (int row = 0; row < height; row++)
        {
            var line = Console.ReadLine().ToCharArray();
            for (int col = 0; col < width; col++)
            {
                labyrint[row, col] = line[col];
            }
        }
    }

    private static Cell FindStartingPoint()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (labyrint[y, x] == 's')
                {
                    return new Cell()
                    {
                        X = x,
                        Y = y
                    };
                }
            }
        }

        return null;
    }

    private static Cell FindFirstExit(Cell startingPoint)
    {
        var path = new Queue<Cell>();
        if (startingPoint != null)
        {
            path.Enqueue(startingPoint);
        }

        while (path.Count > 0)
        {
            var curretnCell = path.Dequeue();

            if (IsExit(curretnCell))
            {
                return curretnCell;
            }

            TryDirection(path, curretnCell, "U", 0, -1);
            TryDirection(path, curretnCell, "R", 1, 0);
            TryDirection(path, curretnCell, "D", 0, 1);
            TryDirection(path, curretnCell, "L", -1, 0);
        }

        return null;
    }

    private static bool IsExit(Cell curretnCell)
    {
        if (curretnCell.X == 0 ||
            curretnCell.X == width - 1 ||
            curretnCell.Y == 0 ||
            curretnCell.Y == height - 1)
        {
            return true;
        }

        return false;
    }

    private static void TryDirection(Queue<Cell> path, Cell currentCell, string direction, int x, int y)
    {
        int newX = currentCell.X + x;
        int newY = currentCell.Y + y;
        if (newX >= 0 &&
            newX < width &&
            newY >= 0 &&
            newY < height &&
            labyrint[newY, newX] == '-')
        {
            labyrint[newY, newX] = 's';
            path.Enqueue(new Cell() { X = newX, Y = newY, Direction = direction, PreviusCell = currentCell });
        }
    }

    private static string TracePath(Cell lastPoint)
    {
        if (lastPoint != null)
        {
            var path = new StringBuilder();
            while (lastPoint.PreviusCell != null)
            {
                path.Append(lastPoint.Direction);
                lastPoint = lastPoint.PreviusCell;
            }

            var reversedPath = string.Join("", path.ToString().ToCharArray().Reverse());

            return reversedPath;
        }

        return null;
    }
}
