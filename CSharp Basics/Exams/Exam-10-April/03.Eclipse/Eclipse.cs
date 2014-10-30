/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Eclipse
{

    private static void frame(int width)
    {
        for (int i = 0; i < width; i++)
        {
            if (i == 0 || i == width - 1)
            {
                Console.Write(' ');
            }
            else
            {
                Console.Write('*');
            }
        }
    }
    
    private static void bothFrames(int width, int bridge)
    {
        frame(width);
        for (int i = 0; i < bridge; i++)
        {
            Console.Write(' ');
        }
        frame(width);
        Console.WriteLine();
    }

    private static void glasses(int hight, int width, int bridge)
    {
        int totalWidht = 2 * width + bridge;
        for (int row = 0; row < hight; row++)
        {
            for (int i = 1; i <= totalWidht; i++)
            {
                if (i == 1 || i == width || i == width + bridge + 1 || i == 2 * width + bridge)
                {
                    Console.Write('*');
                }
                else if (i >= width && i <= width + bridge)
                {
                    if (row == hight / 2)
                    {
                        Console.Write('-');
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }
                else
                {
                    Console.Write('/');
                }
            }
            Console.WriteLine();
        }
    }
    
    static void Main(string[] args)
    {
        int hight = int.Parse(Console.ReadLine());
        int width = 2 * hight;
        int bridge = hight - 1;

        bothFrames(width, bridge);
        glasses(hight, width, bridge);
        bothFrames(width, bridge);
    }
}
*/
using System;

class Eclipse
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine()); // Sunglasses height        

        for (int i = 0; i < n; i++)
        {
            if (i == 0 || i == n - 1)
            {
                PrintTopBottomPart(n);
            }
            else
            {
                PrintMiddlePart(n, i);
            }
        }
    }

    private static void PrintMiddlePart(int n, int i)
    {
        string lens = new string('/', n * 2 - 2);
        string middleFrame = string.Format("{0}{1}{0}", '*', lens);
        string connection = new string(' ', n-1); // Default empty space between the two frames
        // Checking if the row we're currently at is the one that the bridge should be on
        if (i == n / 2)
        {
            connection = new string('-', n-1); // Bridge
        }
        Console.WriteLine("{0}{1}{0}", middleFrame, connection);
    }

    private static void PrintTopBottomPart(int n)
    {
        string frame = new string('*', 2 * n-2);
        string emptySpace = new string(' ', n+1);
        Console.WriteLine(" {0}{1}{0} ", frame, emptySpace, frame);
    }
}