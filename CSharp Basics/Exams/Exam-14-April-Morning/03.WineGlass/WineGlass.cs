using System;

class WineGlass
{
    static void Main(string[] args)
    {
        int height  = int.Parse(Console.ReadLine());
        //int height = 12;
        int countRows = 0;
        char dot = '.';
        char backlash = '\\';
        char slash = '/';
        char star = '*';
        char verticalLine = '|';
        char dash = '-';

        for (int f = 0; f < height / 2; f++)
        {
            for (int i = 0; i < f; i++)
            {
                Console.Write(dot); 
            }
            Console.Write(backlash);
            for (int j = 0; j < height - 2 - 2 * f; j++)
            {
                Console.Write(star);
            }
            Console.Write(slash);
            for (int i = 0; i < f; i++)
            {
                Console.Write(dot);
            }
            countRows++;
            Console.WriteLine();
        }
        if (height >= 12)
        {
            for (int i = 0; i < (height / 2) - 2; i++)
            {
                for (int k = 0; k < (height / 2) - 1; k++)
                {
                    Console.Write(dot);
                }
                Console.Write(verticalLine);
                Console.Write(verticalLine);
                for (int k = 0; k < (height / 2) - 1; k++)
                {
                    Console.Write(dot);
                }
                countRows++;
                Console.WriteLine();
            }
        }
        else
        {
            for (int i = 0; i < (height / 2) - 1; i++)
            {
                for (int k = 0; k < (height / 2) - 1; k++)
                {
                    Console.Write(dot);
                }
                Console.Write(verticalLine);
                Console.Write(verticalLine);
                for (int k = 0; k < (height / 2) - 1; k++)
                {
                    Console.Write(dot);
                }
                countRows++;
                Console.WriteLine();
            }
        }
        for (int i = 0; i < height - countRows; i++)
        {
            for (int k = 0; k < height; k++)
                {
                    Console.Write(dash);
                }
            Console.WriteLine();
        }
    }
}
// kvadrat h na h
/*The glass has exactly N rows, each of which contains exactly N symbols. 
The first row should contain the backslash (“\”) symbol, a total of (N-2) 
 * asterisks (“*”) and the slash (“/”) symbol.
The second row should contain exactly one dot (”.”) before the backslash, 
 * one after the slash and two less (compared to the row above) asterisks 
 * between the slash and backslash.
The third row should contain one more dot at each side and two less asteri
 * sks and so on, until the (N /2) row, where there should be no asterisks 
 * between the slashes.
On the next (N/2)-2 rows, if N >= 12 or (N/2)-1 rows, if N < 12, you should 
 * print the stem that should look like the following: a count of (N/2)-1 dots
 * (“.”), followed by two vertical lines (“|”) and (N/2)-1 dots after the lines.
 * The remaining one or two rows (up to a total count of N) should be filled with
 * exactly N dashes (“-”) on each row.
\***p/
.\*p/.
..\/..
..||..
..||..
------*/