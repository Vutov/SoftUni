using System;

class AgeAfterTen
{
    static void Main(string[] args)
    {
        Console.WriteLine("When you were born?");
        DateTime born = DateTime.Parse(Console.ReadLine());
        DateTime now = DateTime.Now;
        TimeSpan time = now - born;
        double age = time.TotalDays / 365.25; // to convert to years
        int ageAfter = (int)age + 10;
        Console.WriteLine("Your age now is: " + (int)age);
        Console.WriteLine("Your age after 10 years will be: " + ageAfter);
    }
}