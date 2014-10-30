using System;

class ExamSchedule
{
    static void Main(string[] args)
    {
        int examHour = int.Parse(Console.ReadLine());
        int examMin = int.Parse(Console.ReadLine());
        string partOfDay = Console.ReadLine();
        int durationHour = int.Parse(Console.ReadLine());
        int durationMin = int.Parse(Console.ReadLine()); ;

        int additionalHour = 0;
        int examEndMin = durationMin + examMin;
        if (examEndMin >= 60)
        {
            examEndMin -= 60;
            additionalHour = 1;

        }
        int examEndHour = examHour + durationHour + additionalHour;
        string endPart = "";
        if (partOfDay == "AM" && examEndHour >= 12)
        {
            endPart = "PM";
            if (examEndHour > 12)
            {
                examEndHour -= 12;
            }
        }
        else if (partOfDay == "PM" && examEndHour >= 12)
        {
            endPart = "AM";
            if (examEndHour > 12)
            {
                examEndHour -= 12;
            }
        }
        else
        {
            endPart = partOfDay;
        }
        if (examEndHour > 12)
        {
            examEndHour -= 12;
            endPart = partOfDay;
        }
        Console.WriteLine("{0:00}:{1:00}:{2}", examEndHour, examEndMin, endPart);

    }
}