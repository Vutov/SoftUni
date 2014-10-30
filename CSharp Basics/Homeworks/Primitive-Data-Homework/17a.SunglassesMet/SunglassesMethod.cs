using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Same code as 17.Sunglasess, only this time I used Methods :)
class SunglassesMet
{

    private static void frame(int frames, int bridge)
    {
        int bothFrames = frames * 2;
        for (int makeFrames = 0; makeFrames < bothFrames; makeFrames++) 
        {
            if (makeFrames == frames) // middle of the row is empty space.
            {
                for (int makeBridge = 0; makeBridge < bridge; makeBridge++) // the empty space depends
                {                                                         // on N, if N is 3 the space is 3
                    Console.Write(" ");                                   // if N is 5, space is 5 and ect.
                }
            }
            Console.Write("*");
        }
    }

    private static void glasses(int lenses)
    {
        Console.Write("*"); // frame.
        for (int makeLenses = 0; makeLenses < lenses; makeLenses++) // lenses inside the frame.
        {
            Console.Write("/"); // inside the frame.
        }
        Console.Write("*"); // frame.
    }

    private static void betweenFrame(int lenses, int bridge) 
    {
        int midRow = (bridge - 3) / 2; // bridge == N
        int numLenses = bridge - 2; //rows of the glass.
        for (int rowLense = 0; rowLense < numLenses; rowLense++)
        {
            Console.WriteLine(); // every next row start on new line.
            glasses(lenses);
            for (int makeBridge = 0; makeBridge < bridge; makeBridge++)
            {
                if (rowLense == midRow) // the bridge, it is aways in the middle.
                {
                    Console.Write("|");
                }
                else // when not the middle row it must be empty space.
                {
                    Console.Write(" ");
                }
            }
            glasses(lenses);
        }
        Console.WriteLine();
    }
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine()); // height, odd number.
        int frames = N * 2; // number of *'s.
        int lenses = frames - 2; // number of /'s.
        int bridge = N; // lenth of the bridge.
        frame(frames, bridge); //first row.
        betweenFrame(lenses, bridge);
        frame(frames, bridge); //last row.
        Console.WriteLine(); // not needed the glasses are done.
    }
}