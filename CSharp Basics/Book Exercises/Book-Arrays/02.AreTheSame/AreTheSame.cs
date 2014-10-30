using System;

class AreTheSame
{
    static void Main(string[] args)
    {
        bool areSame = true;
        int sizeOne = int.Parse(Console.ReadLine());
        int[] arrayOne = new int[sizeOne];
        for (int i = 0; i < sizeOne; i++)
        {
            int number = int.Parse(Console.ReadLine());
            arrayOne[i] = number;
        }
        int sizeTwo = int.Parse(Console.ReadLine());
        if (sizeOne != sizeTwo)
        {
            areSame = false;
            Console.WriteLine(areSame);
            return;
        }
        for (int i = 0; i < sizeOne; i++)
        {
            int number = int.Parse(Console.ReadLine());
            if (number != arrayOne[i])
            {
                areSame = false;
                break;
            }
        }
        Console.WriteLine(areSame);
    }
}
