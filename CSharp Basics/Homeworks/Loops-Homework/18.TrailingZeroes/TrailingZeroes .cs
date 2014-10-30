using System;
using System.Numerics;

class TrailingZeroes
{

    private static void Zeroes(ulong number)
    {
        
    }

    static void Main(string[] args)
    {
        ulong n = ulong.Parse(Console.ReadLine());
        ulong count = 0;
        for (ulong i = 5; i <= n; i *= 5)
        {
            count += (n / i);
        }
        Console.WriteLine(count);

        /*Slow calculating way;
        BigInteger facturial = 1;
        long count = 0;
        for (ulong i = 1; i <= number; i++)
        {
            facturial *= i;
            if (facturial % 10 == 0)
            {
                count++;
                facturial /= 10;
            }
        }
        Console.WriteLine(count);*/
    }
}
/*Броят на нулите в края на n! зависи от това, колко пъти числото 10 е делител на
факториела. Понеже произведението 1*2*3…*n има повече на брой делители 2, отколкото 5,
а 10 = 2 * 5, то броят нули в n! е точно толкова, колкото са множителите със стойност 5
в произведението 1*2*3….*n. Понеже всяко пето число се дели на 5, а всяко 25-то число се
дели на 5 двукратно и т.н., то броя нули в n! е сумата: n/5 + n/25 + n/125 + …*/