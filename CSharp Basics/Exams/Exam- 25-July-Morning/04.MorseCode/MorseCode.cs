using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MorseCode
{
    static void Main(string[] args)
    {
        int input = int.Parse(Console.ReadLine());
        int inputSum = 0;
        bool hasSolution = false;
        //Get digits;
        while(input > 0)
        {
            int digit = input % 10;
            inputSum += digit;
            input /= 10;
        }
        string[] code = { "-----", ".----", "..---", "...--", "....-", "....." };
        for (int d1 = 0; d1 < 6; d1++)
        {
            for (int d2 = 0; d2 < 6; d2++)
            {
                for (int d3 = 0; d3 < 6; d3++)
                {
                    for (int d4 = 0; d4 < 6; d4++)
                    {
                        for (int d5 = 0; d5 < 6; d5++)
                        {
                            for (int d6 = 0; d6 < 6; d6++)
                            {
                                if (d1 * d2 * d3 * d4 * d5 * d6 == inputSum)
                                {
                                    Console.WriteLine("{0}|{1}|{2}|{3}|{4}|{5}|",
                                        code[d1], code[d2], code[d3], code[d4], code[d5], code[d6]);
                                    hasSolution = true;
                                }
                            }
                            
                        }
                    }
                }   
            }
        }
        if (!hasSolution)
        {
            Console.WriteLine("No");
        }
    }
}