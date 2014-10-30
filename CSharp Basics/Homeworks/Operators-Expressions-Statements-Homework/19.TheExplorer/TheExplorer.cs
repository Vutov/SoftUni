using System;

class TheExplorer
{
    static void Main(string[] args)
    {
        int width = int.Parse(Console.ReadLine());
        int height = width;
        int lower = width / 2;
        int upper = width / 2;

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (i == 0 && j == width / 2)
                {
                    Console.Write("*");
                }
                else if (i > 0 && j == lower)
                {
                    Console.Write("*");
                }
                else if (i > 0 && j == upper)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write("-");
                }
            }

            if (i < width / 2) // the middle will be passed at i == width / 2.
            {
                lower--;
                upper++;
            }
            else
            {
                lower++;
                upper--;
            }

            Console.WriteLine();
        }
    }
}
