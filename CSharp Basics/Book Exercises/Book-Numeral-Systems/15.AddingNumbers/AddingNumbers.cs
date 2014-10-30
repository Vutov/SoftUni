using System;

class AddingNumbers
{
    static void Main(string[] args)
    {
        float sumFloats = 0;
        DateTime before = DateTime.Now;
        for (ulong i = 0; i < 50000000; i++)
        {
            sumFloats += 0.000001f;
        }
        DateTime after = DateTime.Now;
        TimeSpan diff = after - before;
        Console.WriteLine(diff.TotalSeconds);
        Console.WriteLine("{0:F15}", sumFloats);
        double sumDouble = 0;
        DateTime beforeDouble = DateTime.Now;
        for (ulong i = 0; i < 50000000; i++)
        {
            sumDouble += 0.000001d;
        }
        DateTime afterDouble = DateTime.Now;
        TimeSpan diffDouble = afterDouble - beforeDouble;
        Console.WriteLine(diffDouble.TotalSeconds);
        Console.WriteLine("{0:F15}", sumDouble);
        decimal sumDecimal = 0;
        DateTime beforeDecimal = DateTime.Now;
        for (ulong i = 0; i < 50000000; i++)
        {
            sumDecimal += 0.000001M;
        }
        DateTime afterDecimal = DateTime.Now;
        TimeSpan diffDecimal = afterDecimal - beforeDecimal;
        Console.WriteLine(diffDecimal.TotalSeconds);
        Console.WriteLine("{0:F15}", sumDecimal);
    }
}
/*Опитайте да сумирате 50 000 000 пъти числото 0.000001.
 * Използвайте цикъл и събиране (не директно умножение).
 * Опитайте с типовете float и double и след това с decimal.
 * Забелязвате ли разликата в резултатите и в скоростта?*/