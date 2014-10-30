using System;

class MagicStrings
{

    public static int Weight(string numbers)
    {
        int weight = 0;

        foreach (char number in numbers)
	    {
		    switch (number)
	        {
                case 'k':
                    weight += 1; break;
                case 'n':
                    weight += 4; break;
                case 'p':
                    weight += 5; break;
                case 's':
                    weight += 3; break;
                default:
                    Console.WriteLine("Error, character not recognized"); break;
	        }
	    }

        return weight;
    }

    static void Main(string[] args)
    {
        int diff = int.Parse(Console.ReadLine());
        //int diff = 16;
        if (diff > 16) // max is 20, min is 4 => max diff is 16.
        {
            Console.WriteLine("No");
        }

        char[] letters = { 'k', 'n', 'p', 's' }; //alphabetical order.
        int leftWeigth;
        int rightWeigth;
        int len = letters.Length;

        for (int letter1 = 0; letter1 < len; letter1++)
        {
            for (int letter2 = 0; letter2 < len; letter2++)
            {
                for (int letter3 = 0; letter3 < len; letter3++)
                {
                    for (int letter4 = 0; letter4 < len; letter4++)
                    {
                        string leftNum = "" + letters[letter1] + letters[letter2] + letters[letter3] + letters[letter4];
                        leftWeigth = Weight(leftNum);

                        for (int letter5 = 0; letter5 < len; letter5++)
                        {
                            for (int letter6 = 0; letter6 < len; letter6++)
                            {
                                for (int letter7 = 0; letter7 < len; letter7++)
                                {
                                    for (int letter8 = 0; letter8 < len; letter8++)
                                    {
                                         string rightNum = "" + letters[letter5] + letters[letter6] + letters[letter7] + letters[letter8];
                                         rightWeigth = Weight(rightNum);

                                         if (Math.Abs(leftWeigth - rightWeigth) == diff)
                                         {
                                             Console.WriteLine(leftNum + rightNum);
                                         }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}