using System;

class Arrow
{
    static void Main(string[] args)
    {
        int width = int.Parse(Console.ReadLine());
        //int width = 9;

        //arrow base;
        int arrowBasewidth = width * 2 - 1;
        int bodyLenght = width - 2;
        int arrowHeadLen = width - 1;

        for (int i = 0; i < arrowBasewidth; i++)
        {
            if (i >= width / 2 && i <= width / 2 + width - 1)
            {
                Console.Write('#');
            }
            else
            {
                Console.Write('.');
            }
        }
        Console.WriteLine();
        //arrow body;
        for (int row = 0; row < bodyLenght; row++)
        {
            for (int i = 0; i < arrowBasewidth; i++)
            {
                if (i == width / 2 || i == width / 2 + width - 1)
                {
                    Console.Write('#');
                }
                else
                {
                    Console.Write('.');
                }
            }
            Console.WriteLine();
        }
        //arrow midbase;
        for (int i = 0; i < arrowBasewidth; i++)
        {
            if (i <= width / 2 || i >= width / 2 + width - 1)
            {
                Console.Write('#');
            }
            else
            {
                Console.Write('.');
            }
        }
        Console.WriteLine();
        //arrow head;
        for (int row = 0; row < arrowHeadLen; row++)
        {
            for (int i = 0; i < arrowBasewidth; i++)
            {
                if (i == 1 + row || i == arrowBasewidth - 2 - row)
                {
                    Console.Write('#');
                }
                else
                {
                    Console.Write('.');
                }
            }
            Console.WriteLine();
        }
    }
}