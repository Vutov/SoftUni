using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class DoubleDown
{
    static void Main(string[] args)
    {
        int len = int.Parse(Console.ReadLine());
        //int firstNum = 19;
        int firstNum = int.Parse(Console.ReadLine());
        int rightDiagonalCouples = 0;
        int leftDiagonalCouples = 0; 
        int verticalCouples = 0;

        for (int i = 1; i < len; i++)
        {
            int secondNum = int.Parse(Console.ReadLine());
            //int secondNum = 18;
            //Right diagonal;
            for (int bitL = 31; bitL > 0; bitL--)//32 bit int numbers;
            {
                int firstNumBit = firstNum & (1 << bitL);
                firstNumBit = firstNumBit >> bitL;
                int secondNumBit = secondNum & (1 << bitL - 1);
                secondNumBit = secondNumBit >> (bitL - 1);
                if (firstNumBit == secondNumBit && firstNumBit == 1)
                {
                    rightDiagonalCouples++;
                }
            }
            //Console.WriteLine(rightDiagonalCouples);
            //Left diagonal;
            for (int bitR = 0; bitR < 31; bitR++)
            {
                int firstNumBit = firstNum & (1 << bitR);
                firstNumBit = firstNumBit >> bitR;
                int secondNumBit = secondNum & (1 << bitR + 1);
                secondNumBit = secondNumBit >> (bitR + 1);
                if (firstNumBit == secondNumBit && firstNumBit == 1)
                {
                    leftDiagonalCouples++;
                }
            }
            //Console.WriteLine(leftDiagonalCouples);
            //Vertical couples;
            for (int bitV = 31; bitV >= 0; bitV--)
            {
                int firstNumBit = firstNum & (1 << bitV);
                firstNumBit = firstNumBit >> bitV;
                int secondNumBit = secondNum & 1 << bitV;
                secondNumBit = secondNumBit >> bitV;
                if (firstNumBit == secondNumBit && firstNumBit == 1)
                {
                    verticalCouples++;
                }
            }
            //Console.WriteLine(verticalCouples);
            firstNum = secondNum;
        }
        Console.WriteLine(rightDiagonalCouples);
        Console.WriteLine(leftDiagonalCouples);
        Console.WriteLine(verticalCouples);
    }
}