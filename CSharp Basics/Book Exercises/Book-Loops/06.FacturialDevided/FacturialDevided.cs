using System;

class FacturialDevided
{
    static void Main(string[] args)
    {
        Console.WriteLine("First facturial:");
        int firstFacturial = int.Parse(Console.ReadLine());
        Console.WriteLine("Second facturial:");
        int SecondFacturial = int.Parse(Console.ReadLine());
        int n = 1;
        int k = 1;
        for (int i = 1; i <= firstFacturial; i++)
        {
            n *= i;
        }
        for (int i = 1; i <= SecondFacturial; i++)
        {
            k *= i;
        }
        Console.WriteLine(n / k);
    }
}