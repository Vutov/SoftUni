using System;

class BulgarianLetter
{
    static void Main(string[] args)
    {
        int number = int.Parse(Console.ReadLine());
        switch (number)
        {
            case 0: 
                Console.WriteLine("А"); break;
            case 1: 
                Console.WriteLine("Б"); break;
            case 2: 
                Console.WriteLine("В"); break;
            case 3: 
                Console.WriteLine("Г"); break;
            case 4: 
                Console.WriteLine("Д"); break;
            case 5: 
                Console.WriteLine("Е"); break;
            case 6: 
                Console.WriteLine("Ж"); break;
            case 7: 
                Console.WriteLine("З"); break;
            case 8: 
                Console.WriteLine("И"); break;
            case 9: 
                Console.WriteLine("К"); break;
            default: 
                Console.WriteLine("Number is not in range 0 to 9"); break;
        }
    }
}