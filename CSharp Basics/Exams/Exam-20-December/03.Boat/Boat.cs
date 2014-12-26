using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Boat
{
    static void Main(string[] args)
    {
        int input = int.Parse(Console.ReadLine());
        int body = (input - 1) / 2;

        char dot = '.';
        char star = '*';
        int leftOuterDots = input - 1;
        int innerStars = 1;
        int rightOuterDots = input;

        //Sail;
        for (int i = 0; i < input; i++)
        {
            Console.WriteLine("{0}{1}{2}", new string(dot, leftOuterDots),
                new string(star, innerStars), new string(dot, rightOuterDots));
            if (i < input / 2)
            {
                leftOuterDots -= 2;
                innerStars += 2;
            }
            else
            {
                leftOuterDots += 2;
                innerStars -= 2;
            }
        }
        //Body;
        leftOuterDots = 0;
        innerStars = 2 * input;
        for (int i = 0; i < body; i++)
        {
            Console.WriteLine("{0}{1}{0}", new string(dot, leftOuterDots),
                new string(star, innerStars));
            leftOuterDots ++;
            innerStars -= 2;
        }
    }
}
