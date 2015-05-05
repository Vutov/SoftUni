using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class LegoBlocks
{
    private static void Main(string[] args)
    {
        double size = double.Parse(Console.ReadLine());
        List<List<double>> matrix = new List<List<double>>();

        for (int i = 0; i < size; i++)
        {
            matrix.Add(Regex.Split(Console.ReadLine().Trim(), "\\s+").Select(double.Parse).ToList());
        }
        for (int i = 0; i < size; i++)
        {
            matrix[i].AddRange(Regex.Split(Console.ReadLine().Trim(), "\\s+").Select(double.Parse).Reverse().ToList());
        }
        int totalCells = 0;
        int firstRow = matrix[0].Count;
        bool currly = false;
        foreach (List<double> row in matrix)
        {
            int currLen = row.Count;
            if (currLen != firstRow)
            {
                currly = true;
            }
            totalCells += currLen;
        }
        if (currly)
        {
            Console.WriteLine("The total number of cells is: {0}", totalCells);
        }
        else
        {
            foreach (List<double> row in matrix)
            {
                Console.WriteLine("[{0}]", string.Join(", ", row));
            }
        }
    }

}


