using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class TerroristsWin
{
    static void Main(string[] args)
    {
        string field = Console.ReadLine();
        string regex = "\\|([\\s\\S]*?)\\|";
        foreach (Match m in Regex.Matches(field, regex))
        {
            string bomb = m.Groups[1].ToString();
            int blast = 0;
            foreach (var ch in bomb)
            {
                blast += ch;
            }

            blast = blast%10;
            int bombIndex = m.Index;
            int leftBlast = bombIndex - blast;
            if (leftBlast < 0)
            {
                leftBlast = 0;
            }

            int rightBlast = bombIndex + bomb.Length + 2 + blast;
            if (rightBlast > field.Length)
            {
                rightBlast = field.Length;
            }

            string left = field.Substring(0, leftBlast);
            string right = field.Substring(rightBlast, field.Length - rightBlast);
            string bombSide = new string('.', rightBlast - leftBlast);
            field = left + bombSide + right;
        }

         Console.WriteLine(field);
    }
}

