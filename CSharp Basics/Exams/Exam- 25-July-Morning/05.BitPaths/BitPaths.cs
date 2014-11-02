using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class BitPaths
{
    static void Main(string[] args)
    {
        int numDirections = int.Parse(Console.ReadLine());
        int[] board = new int[8];

        for (int i = 0; i < numDirections; i++)
        {
            string directions = Console.ReadLine();
            //string directions = "2,-1,-1,+1,-1,+1,+1,-1";
            int[] direction = Array.ConvertAll(directions.Split(','), int.Parse);
            int firstPosition = 3 - direction[0];
            //First number;
            board[0] ^= (1 << firstPosition);
            //Rest of the numbers;
            int position = firstPosition;
            for (int number = 1; number < 8; number++)
            {
                position -= direction[number];
                board[number] ^= (1 << position);
            }
        }
        int sum = board.Sum();
        string binary = Convert.ToString(sum, 2);
        Console.WriteLine("{0}\n{1:X}", binary, sum);
    }
}
