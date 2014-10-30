using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Trianble
{
    static void Main(string[] args)
    {
        //int.Parse(Console.ReadLine());
        int aX = int.Parse(Console.ReadLine());
        int aY = int.Parse(Console.ReadLine());
        int bX = int.Parse(Console.ReadLine());
        int bY = int.Parse(Console.ReadLine());
        int cX = int.Parse(Console.ReadLine());
        int cY = int.Parse(Console.ReadLine());
        double a = Math.Sqrt(Math.Pow((bX - aX), 2) + Math.Pow((bY - aY), 2));
        double b = Math.Sqrt(Math.Pow((cX - aX), 2) + Math.Pow((cY - aY), 2));
        double c = Math.Sqrt(Math.Pow((bX - cX), 2) + Math.Pow((bY - cY), 2));
        double semiPerimether = (a + b + c) / 2;
        double area = Math.Sqrt(semiPerimether * (semiPerimether - a) *
            (semiPerimether - b) * (semiPerimether - c));
        //Console.WriteLine(area);

        bool canFormTriangle = false;
        if (a + b > c && b + c > a && a + c > b)
        {
            canFormTriangle = true;
        }
        //Console.WriteLine(canFormTriangle);
        double distance = Math.Sqrt(Math.Pow((bX - aX), 2) + Math.Pow((bY - aY), 2));
        if (canFormTriangle)
        {
            Console.WriteLine("Yes\n{0:f2}", area);
        }
        else
        {
            Console.WriteLine("No\n{0:f2}", distance);
        }
        
    }
}