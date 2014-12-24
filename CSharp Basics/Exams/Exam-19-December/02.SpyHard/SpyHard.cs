using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SpyHard
{
    static void Main(string[] args)
    {
        int key = int.Parse(Console.ReadLine());
        string message = Console.ReadLine();
        message = message.ToLower();
        int codeWeight = 0;

        foreach (char letter in message)
        {
            if (letter >= 'a' && letter <= 'z')
            {
                codeWeight += letter - 'a' + 1; // a is 1;
            }
            else
            {
                codeWeight += letter;
            }
        }
        string code = "" + key + message.Length;

        switch (key)
        {
            case 2: code += Convert.ToString(codeWeight, 2); break;
            case 3: code += ConvertToSystemN(codeWeight, new char[] { '0', '1', '2' }); break;
            case 4: code += ConvertToSystemN(codeWeight, new char[] { '0', '1', '2', '3' }); break;
            case 5: code += ConvertToSystemN(codeWeight, new char[] { '0', '1', '2', '3', '4' }); break;
            case 6: code += ConvertToSystemN(codeWeight, new char[] { '0', '1', '2', '3', '4', '5' }); break;
            case 7: code += ConvertToSystemN(codeWeight, new char[] { '0', '1', '2', '3', '4', '5', '6' }); break;
            case 8: code += Convert.ToString(codeWeight, 8); break;
            case 9: code += ConvertToSystemN(codeWeight, new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8' }); break;
            case 10: code += codeWeight; break;
        }

        Console.WriteLine(code);
    }

    //Method from http://stackoverflow.com/questions/923771/quickest-way-to-convert-a-base-10-number-to-any-base-in-net
    public static string ConvertToSystemN(int value, char[] baseChars)
    {
        string result = string.Empty;
        int targetBase = baseChars.Length;

        do
        {
            result = baseChars[value % targetBase] + result;
            value = value / targetBase;
        }
        while (value > 0);

        return result;
    }
}