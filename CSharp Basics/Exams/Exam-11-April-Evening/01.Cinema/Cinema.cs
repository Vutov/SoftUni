using System;

class Cinema
{
    static void Main(string[] args)
    {
        string project = Console.ReadLine();
        decimal ticketPrice = new decimal();
        switch (project)
        {
            case "Premiere":
                ticketPrice = 12; break;
            case "Normal":
                ticketPrice = 7.5M; break;
            case "Discount":
                ticketPrice = 5; break;
            default:
                break;
        }
        int row = int.Parse(Console.ReadLine());
        int col = int.Parse(Console.ReadLine());
        int totalSeats = row * col;
        decimal totalIncome = totalSeats * ticketPrice;
        Console.WriteLine("{0:F} leva", totalIncome);
    }
}