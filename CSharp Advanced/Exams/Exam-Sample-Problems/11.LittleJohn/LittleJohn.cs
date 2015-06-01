using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _11.LittleJohn
{
    class LittleJohn
    {
        static void Main(string[] args)
        {
            var allText = "";
            for (int i = 0; i < 4; i++)
            {
                allText += " " + Console.ReadLine();
            }

            var arroys = new Dictionary<string, int>
            {
                {"small", 0},
                {"medium", 0},
                {"large", 0},
            };

            var foundArroys = Regex.Matches(allText, @"(>----->)|(>>----->)|(>>>----->>)");
            foreach (Match foundArroy in foundArroys)
            {
                if (foundArroy.Groups[1].ToString() != "")
                {
                    arroys["small"]++;
                } 
                if (foundArroy.Groups[2].ToString() != "")
                {
                    arroys["medium"]++;
                } 
                if (foundArroy.Groups[3].ToString() != "")
                {
                    arroys["large"]++;
                }
            }

            var result = int.Parse("" + arroys["small"] + arroys["medium"] + arroys["large"]);
            var binary = Convert.ToString(result, 2);
            var revBinary = string.Join("", binary.ToArray().Reverse());
            result = Convert.ToInt32(binary + revBinary, 2);
            Console.WriteLine(result);
        }
    }
}
