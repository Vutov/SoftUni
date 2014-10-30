using System;

class CrossingSequences
{
    static void Main(string[] args)
    {
        long firstTribo = long.Parse(Console.ReadLine());
        long secondTribo = long.Parse(Console.ReadLine());
        long thirdTribo = long.Parse(Console.ReadLine());
        long startSpiral = long.Parse(Console.ReadLine());
        long stepSpiral = long.Parse(Console.ReadLine());
        const int MAX = 1000000;
        //long firstTribo = 1;
        //long secondTribo = 2;
        //long thirdTribo = 3;
        //long startSpiral = 5;
        //long stepSpiral = 2;
        long nextTribo = new long();
        bool[] tribonacciSeq = new bool[MAX + 1];
        tribonacciSeq[firstTribo] = true; // true == there is a value.
        tribonacciSeq[secondTribo] = true;// false == there is none.
        tribonacciSeq[thirdTribo] = true;//default value for bool is false.
        int count = 2;

        while (true)
        {
            count++;
            nextTribo = firstTribo + secondTribo + thirdTribo;
            firstTribo = secondTribo;
            secondTribo = thirdTribo;
            thirdTribo = nextTribo;
            if (nextTribo > MAX)
            {
                break;
            }
            tribonacciSeq[nextTribo] = true;
            
        }
        int rise = 0;
        bool oddCorner = true;
        bool[] spiralSeq = new bool[MAX + 1];
        while (startSpiral <= MAX)
        {
            spiralSeq[startSpiral] = true;
            if (oddCorner)
            {
                rise += 1;
            }
            startSpiral += rise * stepSpiral;
            oddCorner = !oddCorner;
        }
        int successCount = 0;
        for (int i = 0; i < MAX + 1; i++)
        {
            if (tribonacciSeq[i] && spiralSeq[i])
            {
                Console.WriteLine(i);
                successCount++;
                return;
            }
        }
        if (successCount == 0)
        {
            Console.WriteLine("No");
        }
    }
}
