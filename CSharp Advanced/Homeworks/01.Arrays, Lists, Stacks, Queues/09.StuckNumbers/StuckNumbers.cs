using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class StuckNumbers
{
    static void Main(string[] args)
    {
        int num = int.Parse(Console.ReadLine());
        List<int> nums = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();
        bool found = false;
        int len = nums.Count;
        for (int i = 0; i < len; i++)
        {
            for (int j = 0; j < len; j++)
            {
                for (int k = 0; k < len; k++)
                {
                    for (int l = 0; l < len; l++)
                    {
                        if (
                            i != j && i != k && i != l &&
                            j != k && j != l && k != l)
                        {
                            string left = "" + nums[i] + nums[j];
                            string right = "" + nums[k] + nums[l];
                            if (left.CompareTo(right) == 0)
                            {
                                Console.WriteLine("{0}|{1}=={2}|{3}", nums[i], nums[j], nums[k], nums[l]);
                                found = true;
                            }
                        }
                    }
                }
            }
        }
        if (!found)
        {
            Console.WriteLine("No");
        }
    }
}
