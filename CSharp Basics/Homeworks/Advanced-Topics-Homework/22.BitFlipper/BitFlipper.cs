using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class BitFlipper
{
    static void Main(string[] args)
    {
        ulong number = ulong.Parse(Console.ReadLine());
        /*ulong number = 594226797558350599;
        string b = Convert.ToString((long)number, 2);
        Console.WriteLine(b.PadLeft(64, '0'));
        Console.WriteLine();*/
        for (int bit = 61; bit >= 0; bit--)//64 bits = 61 + 3;
        {
            ulong bits = number & (7Lu << bit);//7 is 111 in binary;
            bits = bits >> bit;
            if (bits == 7 || bits == 0)
            {
                number = number ^ (7Lu << bit);
                bit -= 2;
            }
            /*string binary = Convert.ToString((long)number, 2);
            Console.WriteLine(binary.PadLeft(64, '0'));*/
        }
        Console.WriteLine(number);
    }
}