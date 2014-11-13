using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class BabaTincheAirlines
{
    static void Main(string[] args)
    {
        double totalFlightIncome = 0;
        double[] ticketsPrice = { 7000d, 3500d, 1000d };
        for (int i = 0; i < 3; i++) //0 is firstclass and etc;
        {
            string flightData = Console.ReadLine();
            double[] currentClass = Array.ConvertAll(flightData.Split(' '), double.Parse);
            double ticketPrice = ticketsPrice[i];
            double normalSeats = (currentClass[0] - currentClass[1]) * ticketPrice;
            double frequentFlayers = currentClass[1] * (ticketPrice - ticketPrice * 0.7d);
            double meals = currentClass[2] * (ticketPrice * 0.005d);
            totalFlightIncome += normalSeats + frequentFlayers + meals;
        }
        double[] maxPassangersPerClass = { 12, 28, 50 };
        double maxIncome = 0;
        for (int i = 0; i < 3; i++)
        {
            maxIncome += maxPassangersPerClass[i] * ticketsPrice[i] +
                maxPassangersPerClass[i] * (ticketsPrice[i] * 0.005d);
        }
        Console.WriteLine((int)totalFlightIncome);
        Console.WriteLine(Math.Abs((int)totalFlightIncome - (int)maxIncome));
    }
}