using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class BitKiller
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int step = int.Parse(Console.ReadLine());
        int index = 0;
        int newNum = 0;
        int postion = 7;//bit position in new number;

        for (int numbers = 0; numbers < n; numbers++)
        {
            int number = int.Parse(Console.ReadLine());
            for (int bits = 7; bits >= 0; bits--) //8 bits;
            {
                if ((index % step != 1) && !(step == 1 && index > 0))//add every digit, except the "killed";
                {
                    int bit = (number >> bits) & 1;
                    newNum = newNum | (bit << postion);
                    postion--;
                    if (postion == -1) //0 is valid position for bits;
                    {//one number is ready;
                        Console.WriteLine(newNum);
                        newNum = 0;
                        postion = 7;
                    }
                }
                index++;
            }
        }
        if (postion != 7)//no padding needed, digits at empty positions are 0 already;
        {
            Console.WriteLine(newNum);
        }
    }
}
