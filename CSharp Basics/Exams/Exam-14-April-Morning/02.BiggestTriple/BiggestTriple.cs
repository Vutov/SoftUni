using System;

class BiggestTriple
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        string[] digits = input.Split(' ');
        int max = int.MinValue;
        int sum = 0;
        string maxString = "";
        int len = digits.Length;
        int index = 0;

        for (int i = 0; i < len - 2; i += 3)//all triple numbers
        {
            sum += (Convert.ToInt32(digits[i]) + Convert.ToInt32(digits[i + 1]) + Convert.ToInt32(digits[i + 2]));
            if (sum > max)
	        {
                max = sum;
                maxString = "" + digits[i] + " " + digits[i + 1] + " " + digits[i + 2];
	        }
            sum = 0;
            index += 3;
        }
        int remainder = 0;
        //leftovers
        if (len % 3 == 1 && len != 1 && len != 2)
        {
            remainder = Convert.ToInt32(digits[index]);
            if (remainder > max)
            {
                maxString = "" + digits[index];
            }
        }
        else if (len % 3 == 2 && len != 1 && len != 2)
        {
            remainder = (Convert.ToInt32(digits[index]) + Convert.ToInt32(digits[index + 1]));
            if (remainder > max)
            {
                maxString = "" + digits[index] + " " + Convert.ToInt32(digits[index + 1]);
            }
        }
        if (len == 1)
        {
            maxString = "" + digits[0];
        }
        else if (len == 2)
        {
            maxString = "" + digits[0] + " " + digits[1];
        }
        Console.WriteLine(maxString);
    }
}
