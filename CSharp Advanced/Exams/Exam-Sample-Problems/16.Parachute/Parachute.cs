using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16.Parachute
{
    class Parachute
    {
        static void Main(string[] args)
        {
            var field = new List<string>();

            var line = Console.ReadLine();
            while (!line.Equals("END"))
            {
                field.Add(line);
                line = Console.ReadLine();
            }

            var foundParachutist = false;
            var parachutistX = 0;
            var parachutistY = 0;
            for (int row = 0; row < field.Count; row++)
            {
                for (int col = 0; col < field[row].Length; col++)
                {
                    if (field[row][col].Equals('o'))
                    {
                        parachutistX = row - 1; // It gets ++ down in the code.
                        parachutistY = col;
                        foundParachutist = true;
                        break;
                    }

                    if (foundParachutist)
                    {
                        char currPlace = field[row][col];
                        switch (currPlace)
                        {
                            case '>':
                                parachutistY++;
                                break;
                            case '<':
                                parachutistY--;
                                break;
                        }
                    }
                }

                parachutistX++;

                char nextPlace = field[parachutistX][parachutistY];
                if (nextPlace.Equals('_'))
                {
                    Console.WriteLine("Landed on the ground like a boss!");
                    Console.WriteLine("{0} {1}", parachutistX, parachutistY);
                    break;
                }

                if (nextPlace.Equals('~'))
                {
                    Console.WriteLine("Drowned in the water like a cat!");
                    Console.WriteLine("{0} {1}", parachutistX, parachutistY);
                    break;
                }

                if (nextPlace.Equals('/') ||
                    nextPlace.Equals('\\') ||
                    nextPlace.Equals('|'))
                {
                    Console.WriteLine("Got smacked on the rock like a dog!");
                    Console.WriteLine("{0} {1}", parachutistX, parachutistY);
                    break;
                }
            }
        }
    }
}
