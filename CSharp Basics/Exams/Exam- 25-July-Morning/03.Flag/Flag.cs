using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Flag
{
    private static char GetNextLetter()
    {
        if (letter > 'Z')
        {
            letter = 'A';
        }
        return letter++;
    }

    public static char letter = 'A'; //Start letter;

    static void Main(string[] args)
    {
        int size = int.Parse(Console.ReadLine());
        int halfSize = size / 2;
        char wave = '~';
        char hash = '#';
        char dash = '-';
        
        //Upper part of the flag;
        for (int i = 0; i < halfSize; i++)
        {
            Console.WriteLine("{0}{1}{2}{3}{0}", new string(wave, i), GetNextLetter(),
                new string(hash, size - 2 - 2 * i), GetNextLetter());
        }
        //Middle part of the flag;
        Console.WriteLine("{0}{1}{0}", new string(dash, halfSize), GetNextLetter());
        //Lower part of the flag;
        for (int i = 0; i < halfSize; i++)
        {
            Console.WriteLine("{0}{1}{2}{3}{0}", new string(wave, halfSize - i - 1),
                GetNextLetter(), new string(hash, 1 + 2 * i), GetNextLetter());
        }
    }
}