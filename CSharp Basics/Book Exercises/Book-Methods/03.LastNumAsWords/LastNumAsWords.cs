using System;

class LastNumAsWords
{

    private static string GetLast(int number)
    {
        string digits = number.ToString();
        int len = digits.Length;
        char lastNum = digits[len - 1];//get last digit.

        switch (lastNum)
        {
            case '0': return "zero"; 
            case '1': return "one";
            case '2': return "two";
            case '3': return "three";
            case '4': return "four";
            case '5': return "five";
            case '6': return "six";
            case '7': return "seven";
            case '8': return "eight";
            case '9': return "nine";
            default:
                return "Error! " + lastNum +  "is not in 0 to 9 range";
        }
    }
    
    static void Main(string[] args)
    {
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine(GetLast(number));
    }
}