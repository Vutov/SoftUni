using System;

class SandGlass
{
    static void Main(string[] args)
    {
        int height = int.Parse(Console.ReadLine());
        int width = height;
        int upperGlass = width / 2;
        char dot = '.';
        char star = '*';

        for (int row = 0; row < height; row++)
        {
            for (int i = 0; i < width; i++)
            {
                if (row <= upperGlass)
                {
                    if (i >= width - row || i < row)
                    {
                        Console.Write(dot);
                    }
                    else
                    {
                        Console.Write(star);
                    }
                }
                else//after the middle;
                {
                    if (i < width - row - 1 || i >= row + 1)
                    {
                        Console.Write(dot);
                    }
                    else
                    {
                        Console.Write(star);
                    }
                }
            }
            Console.WriteLine();
        }
    }
}