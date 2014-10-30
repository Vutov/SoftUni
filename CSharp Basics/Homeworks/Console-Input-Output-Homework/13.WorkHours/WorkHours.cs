using System;

class WorkHours
{
    static void Main(string[] args)
    {
        long h = long.Parse(Console.ReadLine()); //project hours
        long d = long.Parse(Console.ReadLine()); //days before deadline
        int p = int.Parse(Console.ReadLine()); //productivity as %
        int workHours = 12;
        decimal daysBiking = d * 0.1M; //10% biking
        decimal daysWorking = d - daysBiking;
        decimal totalWorkHours = workHours * daysWorking * p;
        totalWorkHours = (long)totalWorkHours / 100;
        if (totalWorkHours >= h)
        {
            Console.WriteLine("Yes");
        }
        else
        {
            Console.WriteLine("No");
        }
        decimal diff = totalWorkHours - h;
        Console.WriteLine((long)diff);
    }
}