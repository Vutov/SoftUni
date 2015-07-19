using System;
using System.Collections.Generic;
using System.Linq;

public class BunkerBuster
{
    public static void Main(string[] args)
    {
        var fieldDimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
        var field = new List<List<long>>();
        for (int row = 0; row < fieldDimensions[0]; row++)
        {
            field.Add(Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToList());
        }

        const int SplashZone = 1;

        var command = Console.ReadLine().Trim();
        while (!command.Equals("cease fire!"))
        {
            var commandInput = command.Split(' ');
            var bombX = int.Parse(commandInput[0]);
            var bombY = int.Parse(commandInput[1]);
            var bombDamage = (int)commandInput[2].ToCharArray()[0];

            for (int row = bombX - SplashZone; row <= bombX + SplashZone; row++)
            {
                for (int col = bombY - SplashZone; col <= bombY + SplashZone; col++)
                {
                    try
                    {
                        if (row == bombX && col == bombY)
                        {
                            field[row][col] -= bombDamage;
                        }
                        else
                        {
                            field[row][col] -= (int)Math.Ceiling(bombDamage / 2d);
                        }
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        continue;
                    }
                }
            }

            command = Console.ReadLine().Trim();
        }

        var destroyedCells = 0;
        for (int row = 0; row < fieldDimensions[0]; row++)
        {
            for (int col = 0; col < fieldDimensions[1]; col++)
            {
                if (field[row][col] <= 0)
                {
                    destroyedCells++;
                }
            }
        }

        var totalCells = fieldDimensions[0] * fieldDimensions[1];
        Console.WriteLine("Destroyed bunkers: {0}", destroyedCells);
        Console.WriteLine("Damage done: {0:F1} %", (double)destroyedCells / totalCells * 100);
    }
}
