using System;

class ConvertToAny
{
    static void Main(string[] args)
    {
        string n = Console.ReadLine();
        int numberBase = int.Parse(Console.ReadLine());
        int numeric = int.Parse(Console.ReadLine());
        int numberDec = Convert.ToInt32(n, numberBase);
        string desiredNumeral = Convert.ToString(numberDec, numeric);
        Console.WriteLine(desiredNumeral.ToUpper());
    }
}
//Да се напише програма, която по зададени N, S, D (2 ≤ S, D ≥ 16)
//преобразува числото N от бройна система с основа S към бройна система с основа D.