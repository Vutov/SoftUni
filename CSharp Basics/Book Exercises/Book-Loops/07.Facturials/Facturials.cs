using System;

class Facturials
{
        static void Main(string[] args)
    {
        Console.WriteLine("First facturial:");
        int firstFacturial = int.Parse(Console.ReadLine());
        Console.WriteLine("Second facturial:");
        int SecondFacturial = int.Parse(Console.ReadLine());
        int n = 1;
        int k = 1;
        int l = 1;
        for (int i = 1; i <= firstFacturial; i++)
        {
            n *= i;
        }
        for (int j = 1; j <= SecondFacturial; j++)
        {
            k *= j;
        }
        int devider = firstFacturial - SecondFacturial;
        for (int r = 1; r < devider; r++)
        {
            l *= r;
        }
        Console.WriteLine((n * k) / l);
    }   
}