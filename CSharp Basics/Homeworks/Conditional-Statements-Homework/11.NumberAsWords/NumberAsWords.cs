using System;

class NumberAsWords
{   

    private static string oneToNine(int number)
    {
        string result = "";
        switch (number)
        {
            case 1:
                result = "one"; break;
            case 2:
                result = "two"; break;
            case 3:
                result = "three"; break;
            case 4:
                result = "four"; break;
            case 5:
                result = "five"; break;
            case 6:
                result = "six"; break;
            case 7:
                result = "seven"; break;
            case 8:
                result = "eight"; break;
            case 9:
                result = "nine"; break;
            //no default needed, the number is filtered to be 1-9.
        }
        return result;
    }

    private static string twentyToNinetyNine(int number)
    {
        string result = "";
        int digit = number - (number / 10) * 10;//25 / 10 = 2, 2 * 10 = 20,
        if (number >= 20 && number < 30)//25 - 20 = 5, the needed digit.
	    {
            result = "twenty " + oneToNine(digit);
	    }
        else if (number >= 30 && number < 40)
        {
            result = "thirty " + oneToNine(digit);   
        }
        else if (number >= 40 && number < 50)
        {
            result = "fourty " + oneToNine(digit);
        }
        else if (number >= 50 && number < 60)
        {
            result = "fifty " + oneToNine(digit);
        }
        else if (number >= 60 && number < 70)
        {
            result = "sixty " + oneToNine(digit);
        }
        else if (number >= 70 && number < 80)
        {
            result = "seventy " + oneToNine(digit);
        }
        else if (number >= 80 && number < 90)
        {
            result = "eighty " + oneToNine(digit);
        }
        else if (number >= 90 && number < 100)
        {
            result = "ninety " + oneToNine(digit);
        }
        return result;
    }

    private static string oneToTwelve(int number)
    {
        string result = "";
        if (number == 12)
        {
            result += "twelve";
        }
        else if (number == 11)
        {
            result += "eleven";
        }
        else if (number == 10)
        {
            result += "ten";
        }
        else
        {
            result += oneToNine(number);
        }
        return result;
    }

    private static string oneToNinetynine(int number)
    {
        string result = "";
        int hundreds = number / 100;
        //951 / 100 = 9; 951 - 9 * 100 = 51. 
        int tens = number - hundreds * 100;
        if (tens < 13)
        {
            result += oneToTwelve(tens);
        }
        else if (tens >= 13 && tens <= 19)
        {
            tens -= 10; //method is made to work with 1 - 9.
            if (tens == 8)
            {//eighteen, not eightteen.
                result += oneToNine(tens) + "een"; 
            }
            else
            {
                result += oneToNine(tens) + "teen";
            }
            
        }
        else if (tens > 19)
        {
            result += twentyToNinetyNine(tens);
        }
        return result;
    }

    static void Main(string[] args)
    {
        //int num = int.Parse(Console.ReadLine());
        int num;
        string outOfRange = "Range is [0…999]";
        if (!int.TryParse(Console.ReadLine(), out num))
        {
            Console.WriteLine(outOfRange);
            return;
        }
        int hundreds = num / 100;
        string word = "";
        //Starting from left to rigth.
        if (num >= 100 && num < 1000)
        {
            word += oneToNine(hundreds) + " hundred";
        }
        if (num >= 0 && num < 100)
        {
            if (num == 0)
            {
            word += "zero";
            }
            word += oneToNinetynine(num);
        }
        else if (num - hundreds * 100 > 0 && num < 1000)
        {
            word += " and ";
            word += oneToNinetynine(num);
        }
        //Out of range
        else
        {
            Console.WriteLine(outOfRange);
            return;
        }
        //Make first letter uppercase.
        if (word.Length > 1)//to avoid out of bounds exception.
        {
            word = char.ToUpper(word[0]) + word.Substring(1);
        }  
        Console.WriteLine(word);
    }
}
/*
Write a program that converts a number in the range [0…999] to words,
 * corresponding to the English pronunciation. Examples:
 
numbers	number as words	   
0	Zero	   
9	Nine	   
10	Ten	   
12	Twelve	   
19	Nineteen	   
25	Twenty five	   
98	Ninety eight	   
273	Two hundred and seventy three	   
400	Four hundred	   
501	Five hundred and one	   
617	Six hundred and seventeen	   
711	Seven hundred and eleven	   
999	Nine hundred and ninety nine	 
*/