using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Sunglasses
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine()); // height, odd number.
        int frames = 2 * N; // number of *'s.
        int numLenses = N - 2; //rows of the glass.
        int lenses = frames - 2; // number of /'s.
        int bridge = N; // len of the bridge.
        for (int makeFrame = 0; makeFrame < frames * 2; makeFrame++) // the first row.
        {
            if (makeFrame == frames) // middle of the row is empty space.
            {
                for (int makeBridge = 0; makeBridge < bridge; makeBridge++) // the empty space depends
                {                                                         // on N, if N is 3 the space is 3
                    Console.Write(" ");                                   // if N is 5, space is 5 and ect.
                }
            }
            Console.Write("*");
        } // end of the first row
        for (int rowLense = 0; rowLense < numLenses; rowLense++)
		{
            Console.WriteLine(); // every next row start on new line.
            Console.Write("*"); // frame.
            for (int makeLenses = 0; makeLenses < lenses; makeLenses++) // lenses inside the frame.
            {
                Console.Write("/");
            }
            Console.Write("*"); // frame.
            if (rowLense == (N - 3) / 2) // the bridge, it is aways in the middle.
            {
                for (int makeBridge = 0; makeBridge < bridge; makeBridge++)
                {
                    Console.Write("|");
                }
            }
            else // when not the middle row it must be empty space.
            {
                for (int makeBridge = 0; makeBridge < bridge; makeBridge++)
                {
                    Console.Write(" ");
                }
            }

            Console.Write("*"); // mirror code to match the bottom half of the sunglasses.
            for (int makeLenses = 0; makeLenses < lenses; makeLenses++)
            {
                Console.Write("/");
            }
            Console.Write("*");
		}
        Console.WriteLine();
        for (int makeFrame = 0; makeFrame < frames * 2; makeFrame++)
        {
            if (makeFrame == frames)
            {
                for (int makeBridge = 0; makeBridge < bridge; makeBridge++)
                {
                    Console.Write(" ");
                }
            }
            Console.Write("*");
        }
        Console.WriteLine(); // not needed the glasses are done.
    }
}
// it would of looked way clearer if I used methods to define the parts of the sunglasses.