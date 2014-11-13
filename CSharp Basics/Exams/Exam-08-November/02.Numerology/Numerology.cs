using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Numerology
{
    static void Main(string[] args)
    {
        //string input = "01.01.1914 g0g0";
        string input = Console.ReadLine();
        string[] data = input.Split(' ');
        int[] date = Array.ConvertAll(data[0].Split('.'), int.Parse);

        int day = date[0];
        int month = date[1];
        int year = date[2];
        ulong celestialNumber = (ulong)(day * year * month);
        //Console.WriteLine(celestialNumber);
        if (month % 2 == 1)
        {
            celestialNumber = (ulong)Math.Pow(celestialNumber, 2);
        }
        //Console.WriteLine(celestialNumber);
        string username = data[1];
        foreach (char ch in username)
        {
            if (ch >= 'a' && ch <= 'z')
            {
                celestialNumber += (ulong)(ch - 'a' + 1);
            }
            else if (ch >= 'A' && ch <= 'Z')
            {
                celestialNumber += (ulong)((ch - 'A' + 1) * 2);
            }
            else //Only digits left;
            {
                celestialNumber += (ulong)(ch - '0');
            }
        }
        //Console.WriteLine(celestialNumber);
        while (celestialNumber > 13)
        {
            ulong digitsSum = 0;
            //Sum digits and test again;
            while (celestialNumber != 0)
            {
                digitsSum += celestialNumber % 10;
                celestialNumber /= 10;
            }
            celestialNumber = digitsSum;
        }
        Console.WriteLine(celestialNumber);
    }
}
