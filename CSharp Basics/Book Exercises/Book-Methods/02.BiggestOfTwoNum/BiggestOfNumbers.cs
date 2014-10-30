using System;

class BiggestOfThoNum
{
    private static int GetMax(int firstNum, int secondNum)
    {
        int biggest = new int();
        biggest = Math.Max(firstNum, secondNum);
        return biggest;
    }
    
    static void Main(string[] args)
    {
        int first = int.Parse(Console.ReadLine());
        int second = int.Parse(Console.ReadLine());
        int third = int.Parse(Console.ReadLine());
        int biggest = GetMax(GetMax(first, second), third);
        Console.WriteLine(biggest);
    }
}