using System;

class Illuminati
{
    static void Main(string[] args)
    {
        string message = Console.ReadLine();
        message = message.ToLower();
        int countVowels = new int();
        int sum = new int();
        foreach (char letter in message)
        {
            switch (letter)
            {
                case 'a':
                    sum += 65;
                    countVowels++;
                    break;
                case 'e':
                    sum += 69;
                    countVowels++;
                    break;
                case 'i':
                    sum += 73;
                    countVowels++;
                    break;
                case 'o':
                    sum += 79;
                    countVowels++;
                    break;
                case 'u':
                    sum += 85;
                    countVowels++;
                    break;
                default:
                    break;
            }
        }
        Console.WriteLine("{0}\n{1}", countVowels, sum);
    }
}

//A = 65, E = 69, I = 73, O = 79, U = 85
//On the first output line you must print the number of vowels in the message.
