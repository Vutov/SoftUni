using System;

class RomanToDec
{

    private static int decValue(string romanNumber, int position)
    {
        int value = new int();
        switch (romanNumber[position])
        {
            case 'I':
                value = 1; break;
            case 'V':
                value = 5; break;
            case 'X':
                value = 10; break;
            case 'L':
                value = 50; break;
            case 'C':
                value = 100; break;
            case 'D':
                value = 500; break;
            case 'M':
                value = 1000; break;
            default:
                break;
        }
        return value;
    }

    private static int sumValue(string romanNum, int position)
    {
        int len = romanNum.Length - 1;
        int result = 0;
        int currentNum = decValue(romanNum, position);
        bool notFirstTwo = position != 0 && position != 1;

        if (position != len && currentNum >= decValue(romanNum, position + 1))
        {
            result += currentNum;         
        }
        else if (position == len)
        {
            result += currentNum;  
        }
        else if (notFirstTwo && currentNum < decValue(romanNum, position - 1) &&
            decValue(romanNum, position - 1) < decValue(romanNum, position - 2))
        {
            result -= currentNum;
        }
        else if (position != len && currentNum < decValue(romanNum, position + 1))
        {
            result -= currentNum;
        }
        return result;
    }
    
    static void Main(string[] args)
    {
        //string romanNumber = "LXXXV";
        string romanNumber = Console.ReadLine();
        romanNumber = romanNumber.ToUpper();
        int decNumber = 0;
        int len = romanNumber.Length;
        for (int i = 0; i < len; i++)
        {
            decNumber += sumValue(romanNumber, i);   
        }
        Console.WriteLine(decNumber);
    }
}