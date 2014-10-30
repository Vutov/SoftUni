using System;

class BonusScore
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter the points:");
        int points = int.Parse(Console.ReadLine());
        if (points <= 0 || points > 9)
        {
            Console.WriteLine("invalid score");
            return;
        }
        else if (points >= 1 && points <= 3)
        {
            points *= 10;
        }
        else if (points >= 4 && points <= 6)
        {
            points *= 100;
        }
        else // 7, 8, 9
        {
            points *= 1000;
        }
        Console.WriteLine("{0}", points);
    }
}
/*
Write a program that applies bonus score to given score in the range [1…9] by the following rules:
If the score is between 1 and 3, the program multiplies it by 10.
If the score is between 4 and 6, the program multiplies it by 100.
If the score is between 7 and 9, the program multiplies it by 1000.
If the score is 0 or more than 9, the program prints “invalid score”.
Examples:
 
score	result	   
2	20	   
4	400	   
9	9000	   
-1	invalid score	   
10	invalid score	 
*/