namespace _03.SummerTime
{
    using System;

    public class SummerTime
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int topWidth = n + 1;
            int totalWidth = n * 2;
            char space = ' ';
            char star = '*';
            char at = '@';
            char dot = '.';

            int outerSpaces = (totalWidth - topWidth) / 2;
            Console.WriteLine("{0}{1}{0}", new string(space, outerSpaces), new string(star, topWidth));

            int innerSpaces = totalWidth - outerSpaces * 2 - 2;
            for (int i = 0; i < n / 2; i++)
            {
                Console.WriteLine("{0}{1}{2}{1}{0}", new string(space, outerSpaces),
                    star, new string(space, innerSpaces));
            }

            for (int i = 0; i < n / 2; i++)
            {
                Console.WriteLine("{0}{1}{2}{1}{0}", new string(space, outerSpaces),
                    star, new string(space, innerSpaces));
                outerSpaces--;
                innerSpaces += 2;
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("{0}{1}{0}", star, new string(dot, totalWidth - 2));
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("{0}{1}{0}", star, new string(at, totalWidth - 2));

            }

            Console.WriteLine("{0}", new string(star, totalWidth));
        }
    }
}
