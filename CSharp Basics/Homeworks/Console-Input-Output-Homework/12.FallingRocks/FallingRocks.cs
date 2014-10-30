using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

class FallingRocks
{

    private static bool IsGameOver(int rockX, int rockY, int dwarfX, int dwarfY)
    {
        bool isOver = false;
        if (rockY == dwarfY - 1 && (rockX == dwarfX || rockX == dwarfX + 1 || rockX == dwarfX + 2))
        {
            Console.WriteLine("GAME OVER");
            isOver = true;
        }
        return isOver;
    }

    private static void PrintFigures(int dwarfX, int dwarfY, int rockX, int rockY, int rockStyle,
        char[] rocks, string dwarf, long score)
    {
        Console.SetCursorPosition(dwarfX, dwarfY);
        Console.WriteLine(dwarf);
        Console.SetCursorPosition(rockX, rockY);
        Console.WriteLine(rocks[rockStyle]);
        Console.SetCursorPosition(0, 0);
        Console.WriteLine("Your score is: " + score);
    }

    static void Main(string[] args)
    {
        const int PLAYGROUNG_HEIGHT = 20;
        const int PLAYGROUND_WIDTH = 40;
        string dwarf = "(O)";
        int dwarfLen = dwarf.Length;
        char[] rocks = { '^', '@', '*', '&', '+', '%', '$', '#', '!', '.', ';', '-' };
        int dwarfX = PLAYGROUND_WIDTH / 2;
        int dwarfY = PLAYGROUNG_HEIGHT - 1;
        int len = rocks.Length;
        long score = -1;

        Random rng = new Random();
        Console.CursorVisible = false;
        Console.WindowHeight = PLAYGROUNG_HEIGHT;
        Console.WindowWidth = PLAYGROUND_WIDTH;
        Console.BufferHeight = Console.WindowHeight;

        //Start possition for the dwarf.
        Console.SetCursorPosition(dwarfX, dwarfY);
        Console.WriteLine(dwarf);

        while (true)
        {
            //Falling stuff.
            int rockX = rng.Next(0, (PLAYGROUND_WIDTH));
            int rockY = 0;
            int rockStyle = rng.Next(0, len);
            //int numRocks = rng.Next(3, PLAYGROUND_WIDTH / 3);
            
            score++;
            for (int y = 0; y < dwarfY - 1; y++)
            {
                Thread.Sleep(150);//Set the speed.
                rockY++;
                Console.Clear();
                PrintFigures(dwarfX, dwarfY, rockX, rockY, rockStyle, rocks, dwarf, score);
                if (IsGameOver(rockX, rockY, dwarfX, dwarfY))
                {
                    return;
                }
                //Movement of the dwarf.
                if (Console.KeyAvailable)
                {
                    Console.Clear();
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.LeftArrow)
                    {
                        dwarfX -= 2;
                        if (dwarfX < 0)
                        {
                            dwarfX = 0;
                        }
                        PrintFigures(dwarfX, dwarfY, rockX, rockY, rockStyle, rocks, dwarf, score);
                        if (IsGameOver(rockX, rockY, dwarfX, dwarfY))
                        {
                            return;
                        }
                    }
                    else if (key.Key == ConsoleKey.RightArrow)
                    {
                        dwarfX += 2;
                        if (dwarfX > PLAYGROUND_WIDTH - dwarfLen)
                        {
                            dwarfX = PLAYGROUND_WIDTH - dwarfLen;
                        }
                        PrintFigures(dwarfX, dwarfY, rockX, rockY, rockStyle, rocks, dwarf, score);
                        if (IsGameOver(rockX, rockY, dwarfX, dwarfY))
                        {
                            return;
                        }
                    }
                }
            }
        }
    }
}