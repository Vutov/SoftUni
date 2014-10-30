using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TicTacToePower
{
    static void Main(string[] args)
    {
        int pointX = int.Parse(Console.ReadLine());
        int pointY = int.Parse(Console.ReadLine());
        int value = int.Parse(Console.ReadLine());
        int size = 3;
        int[,] indexMatrix = new int[size, size];
        int[,] valueMatrix = new int[size, size];
        int countIndex = 1;
        int countValue = 0;
        for (int y = 0; y < size; y++)
        {
            for (int x = 0; x < size; x++)
            {
                indexMatrix[x, y] = countIndex;
                valueMatrix[x, y] = value + countValue;
                countValue++;
                countIndex++;
            }
        }
        long pointSum = (long)Math.Pow(valueMatrix[pointX, pointY], indexMatrix[pointX, pointY]);
        Console.WriteLine(pointSum);
    }
}
