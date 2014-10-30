using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ProgramerDNA
{
    static void Main(string[] args)
    {
        int hight = int.Parse(Console.ReadLine());
        char startLetter = char.Parse(Console.ReadLine());
        int width = 7;
        int halfWidth = width / 2;
        int index = 0;
        for (int row = 0; row < hight; row++)
        {
            for (int i = 0; i < width; i++)
            {
                if (index < halfWidth)
                {
                    if (i > halfWidth + index || i < halfWidth - index)
                    {
                        Console.Write(".");
                    }
                    else
                    {
                        Console.Write(startLetter);
                        startLetter = (char)(startLetter + 1);
                        if (startLetter == 'H')
                        {
                            startLetter = 'A';
                        }
                    }
                }
                else
                {
                    if (i < index - halfWidth || i > width - index + 2)
                    {
                        Console.Write(".");
                    }
                    else
                    {
                        Console.Write(startLetter);
                        startLetter = (char)(startLetter + 1);
                        if (startLetter == 'H')
                        {
                            startLetter = 'A';
                        }
                    }
                }
            }
            index++;
            if (index > width - 1)
            {
                index = 0;
            }
            Console.WriteLine();
        }
    }
}