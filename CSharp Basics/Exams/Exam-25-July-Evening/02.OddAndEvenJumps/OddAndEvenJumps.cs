using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class OddAndEvenJumps
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        int oddJump = int.Parse(Console.ReadLine());
        int evenJump = int.Parse(Console.ReadLine());

        ulong oddSum = 0;
        ulong evenSum = 0;
        int oddCount = 0;
        int evenCount = 0;
        input = input.Replace(" ", string.Empty).ToLower();
        int len = input.Length;
        //string oddLetters = "";
        //string evenLetters = "";
        for (int i = 1; i <= len; i++)
        {
            if (i % 2 == 1)//Odd;
            {
                //oddLetters += input[i - 1];
                oddCount++;
                if (oddCount == oddJump)
                {
                    oddSum *= input[i - 1];
                    oddCount = 0;
                }
                else
                {
                    oddSum += input[i - 1];
                }
            }
            else//Even;
            {
                //evenLetters += input[i - 1];
                evenCount++;
                if (evenCount == evenJump)
                {
                    evenSum *= input[i - 1];
                    evenCount = 0;
                }
                else
                {
                    evenSum += input[i - 1];
                }
            }
        }
        Console.WriteLine("Odd: {0:X}\nEven: {1:X}", oddSum, evenSum);
        
    }
}
