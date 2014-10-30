using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class StudentCables
{
    static void Main(string[] args)
    {
        int len = int.Parse(Console.ReadLine());
        int totalCableLenght = 0;
        int joints = -1;
        for (int i = 0; i < len; i++)
        {
            int cableSize = int.Parse(Console.ReadLine());
            string cableMeasure = Console.ReadLine();
            if (cableMeasure == "meters")
            {
                cableSize *= 100;//Working in cm;
            }
            if (cableSize < 20)//Throw away;
            {
                continue;
            }
            else
            {
                totalCableLenght += cableSize;
                joints++;
            }
        }
        totalCableLenght -= 3 * joints;
        int numCables = totalCableLenght / 504;
        int remainder = totalCableLenght % 504;
        Console.WriteLine(numCables);
        Console.WriteLine(remainder);
    }
}
