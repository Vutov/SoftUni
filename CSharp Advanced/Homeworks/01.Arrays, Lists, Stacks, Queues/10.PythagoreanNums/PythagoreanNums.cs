using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class PythagoreanNums
{
    static void Main(string[] args)
    {
        int len = int.Parse(Console.ReadLine());
        int[] nums = new int[len];
        bool found = false;
        for (int i = 0; i < len; i++)
        {
            nums[i] = int.Parse(Console.ReadLine());
        }
        for (int i = 0; i < len; i++)
        {
            for (int j = 0; j < len; j++)
            {
                if (nums[i] <= nums[j])
                {
                    for (int k = 0; k < len; k++)
                    {
                        double left = Math.Pow(nums[i], 2) + Math.Pow(nums[j], 2);
                        double right = Math.Pow(nums[k], 2);
                        if (left == right)
                        {
                            Console.WriteLine("{0}*{0} + {1}*{1} = {2}*{2}",
                                nums[i], nums[j], nums[k]);
                            found = true;
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