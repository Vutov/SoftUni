using System;

class Lexicograf
{
    static void Main(string[] args)
    {
        //char[] arrayOne = { 'a', 'c', 'd', 'e' };
        //char[] arrayTwo = { 'a', 'g', };
        //first array
        int sizeOne = int.Parse(Console.ReadLine());
        char[] arrayOne = new char[sizeOne];
        for (int i = 0; i < sizeOne; i++)
        {
            arrayOne[i] = char.Parse(Console.ReadLine());
        }
        //second array
        int sizeTwo = int.Parse(Console.ReadLine());
        char[] arrayTwo = new char[sizeOne];
        for (int i = 0; i < sizeTwo; i++)
        {
            arrayTwo[i] = char.Parse(Console.ReadLine());
        }
        //comparison
        int shortest = new int();
        int index = 0;// in case it has be to decided by shortest;
        if (arrayOne.Length < arrayTwo.Length)
	    {
		     shortest = arrayOne.Length;
	    }
        else
	    {
            shortest = arrayTwo.Length;
	    }

        for (int i = 0; i < shortest; i++)
		{
			if (arrayOne[i] == arrayTwo[i])
	        {
		        continue;
	        }
            else//letter earlier in the alphabet has lower unicode number;
            {
                index++;
                if ((int) arrayOne[i] < (int) arrayTwo[i])
                {
                    Console.WriteLine("First array.");
                    break;
                }
                else
                {
                    Console.WriteLine("Second array.");
                    break;
                }
            }
		}
        if (index == 0)
        {
            if (arrayOne.Length < arrayTwo.Length)
            {
                Console.WriteLine("First array.");
            }
            else if (arrayOne.Length > arrayTwo.Length)
            {
                Console.WriteLine("Second array.");
            }
            else //same length, same chars inside.
            {
            Console.WriteLine("Array are the same!");
            }
        }
    }
}

/*Да се напише програма, която сравнява два масива от тип char лексикографски
(буква по буква) и проверява кой от двата е по-рано в лексикографската подредба. 
 * При лексикографската наредба символите се сравняват един по един
като се започва от най-левия. При несъвпадащи символи по-рано е
масивът, чийто текущ символ е по-рано в азбуката. При съвпадение
се продължава със следващия символ вдясно. Ако се стигне до края
на единия масив, по-краткият е лексикографски по-рано. Ако всички
съответни символи от двата масива съвпаднат, то масивите са
еднакви и никой о тях не е по-рано в лексикографската наредба.
*/