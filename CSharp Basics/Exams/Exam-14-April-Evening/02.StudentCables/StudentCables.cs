using System;

class StudentCables
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()); //number of cables.
        int totalCableLength = new int(); //in centimeters.
        int jointCm = 3; //cm needed to join two cables.
        int joins = -1; // for cutting.
        for (int i = 0; i < n; i++)
        {
            int cableLength = int.Parse(Console.ReadLine());
            string cableMeasure = Console.ReadLine(); //meters or centimeters.
            if (cableMeasure == "meters")
            {
                // Convert meters to centimeters
                cableLength = cableLength * 100;
            }
            if (cableLength >= 20)
            {
                totalCableLength += cableLength;
                joins++;
            }
        }
        totalCableLength -= joins * jointCm;
        int cmPerStudentCable = 504;
        int doneCables = totalCableLength / cmPerStudentCable;
        int remainder = totalCableLength % cmPerStudentCable;
        Console.WriteLine(doneCables);
        Console.WriteLine(remainder);
    }
}
