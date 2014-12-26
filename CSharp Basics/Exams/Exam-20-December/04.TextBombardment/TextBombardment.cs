using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TextBombardment
{
    static void Main(string[] args)
    {
        string text = Console.ReadLine();
        int width = int.Parse(Console.ReadLine());
        string bombardments = Console.ReadLine();

        //Set the matrix;
        int colSize = width;
        int rowSize = (int)Math.Ceiling(text.Length / (double)width);
        int index = 0;
        int textLen = text.Length;
        char[,] textMatrix = new char[rowSize, colSize];
        for (int row = 0; row < rowSize; row++)
        {
            for (int col = 0; col < colSize; col++)
            {
                if (index < textLen)
                {
                    textMatrix[row, col] = text[index];
                    index++;
                }
                else
                {
                    break;
                }
                //Console.Write(textMatrix[row, col] + " ");
            }
            //Console.WriteLine();
        }

        //Bombard the matrix;
        string[] commands = bombardments.Split(' ');
        int len = commands.Length;
        for (int i = 0; i < len; i++)
        {
            int targetedCol = int.Parse(commands[i]);
            bool spaceAbove = true;
            for (int row = 0; row < rowSize; row++)
            {
                if (textMatrix[row, targetedCol] == ' ' && spaceAbove)
                {
                    continue;
                }
                else if (textMatrix[row, targetedCol] != ' ')
                {
                    textMatrix[row, targetedCol] = ' ';
                    spaceAbove = false;
                }
                else
                {
                    break;
                }
            }
        }

        //Print the result;
        for (int row = 0; row < rowSize; row++)
        {
            for (int col = 0; col < colSize; col++)
            {
                Console.Write(textMatrix[row, col]);
            }
        }
        Console.WriteLine();
        //Console.WriteLine("W l  th s p o lem i   o na be a r de.");
    }
}
