using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MagicCarNumbers
{
    static void Main(string[] args)
    {
        int desiredWeight = int.Parse(Console.ReadLine());
        //'A'  10, 'B'  20, 'C'  30, 'E'  50, 'H'  80, 'K'  110, 'M'  130, 'P'  160, 'T'  200, 'X'  240. 
        int[] letters = { 10, 20, 30, 50, 80, 110, 130, 160, 200, 240 };
        int weight = 40; // CA
        int count = 0;
        for (int a = 0; a < 10; a++)
        {
            foreach (int letter1 in letters)
            {
                foreach (int letter2 in letters)
                {
                    if (weight + a + a + a + a + letter1 + letter2 == desiredWeight)
                    {
                        count++;
                    }
                    for (int b = 0; b < 10; b++)
                    {
                        if (b != a)
                        {
                            if (weight + a + b + b + b + letter1 + letter2 == desiredWeight)
                            {
                                count++;
                            }
                            if (weight + a + a + a + b + letter1 + letter2 == desiredWeight)
                            {
                                count++;
                            }
                            if (weight + a + a + b + b + letter1 + letter2 == desiredWeight)
                            {
                                count++;
                            }
                            if (weight + a + b + a + b + letter1 + letter2 == desiredWeight)
                            {
                                count++;
                            }
                            if (weight + a + b + b + a + letter1 + letter2 == desiredWeight)
                            {
                                count++;
                            }
                        }
                    }
                }
            }
        }
        Console.WriteLine(count);
    }
}