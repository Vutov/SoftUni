using System;

class InsideBuilding
{
    static void Main(string[] args)
    {
        //int h = 2; //hight of buildig
        int h = int.Parse(Console.ReadLine());
        //int pointX = 3;
        //int pointY = 10; //coordinats of point.
        int farX = 3 * h;
        int farMidX = 2 * h;
        int upperY = 4 * h;
        for (int i = 0; i < 5; i++)
        {
            bool isInside = false;
            int pointX = int.Parse(Console.ReadLine());
            int pointY = int.Parse(Console.ReadLine());
            if (pointX >= 0 && pointX <= farX && pointY >= 0 && pointY <= h)
            {
                isInside = true;
            }
            else if (pointX >= h && pointX <= farMidX && pointY >= h && pointY <= upperY)
            {
                isInside = true;
            }
            if (isInside)
            {
                Console.WriteLine("inside");
            }
            else
            {
                Console.WriteLine("outside");
            }
        }
    }
}