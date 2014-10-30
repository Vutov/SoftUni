using System;

class PrintSeq
{
    static void Main(string[] args)
    {
        int seqLen = 10;
        int startNum = 2;
        for (int i = 1; i <= seqLen; i++)
        {
            if (i == seqLen) // so the end of the sequence will be with "."
            {
                if (seqLen % 2 == 0) // if the last of the seq has to be negative
                {
                    startNum *= -1;
                    Console.Write(startNum + ".\n");
                }
                else
                {
                    Console.WriteLine(startNum + ".\n");
                }
                break;
            }
            if (i % 2 == 0) // gets every second number in the sequence
            {
                startNum *= -1;
                Console.Write(startNum + ", ");
                startNum *= -1; // returns the value of StartNum to possitive
            }
            else
            {
                Console.Write(startNum + ", ");
            }
            startNum += 1;
        }
    }
}