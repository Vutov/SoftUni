using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class NumberCalculations
{
    private static int GetMin(int[] arr)
    {
        int min = int.MaxValue;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] < min)
            {
                min = arr[i];
            }
        }

        return min;
    }

    private static double GetMin(double[] arr)
    {
        double min = double.MaxValue;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] < min)
            {
                min = arr[i];
            }
        }

        return min;
    }

    private static int GetMax(int[] arr)
    {
        int max = int.MinValue;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] > max)
            {
                max = arr[i];
            }
        }

        return max;
    }

    private static double GetMax(double[] arr)
    {
        double max = int.MinValue;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] > max)
            {
                max = arr[i];
            }
        }

        return max;
    }

    private static int GetSum(int[] arr)
    {
        int sum = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }

        return sum;
    }
    private static double GetSum(double[] arr)
    {
        double sum = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }

        return sum;
    }

    private static int GetAverage(int[] arr)
    {
        int sum = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }

        return sum / arr.Length;
    }
    private static double GetAverage(double[] arr)
    {
        double sum = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }

        return sum / arr.Length;
    }

    private static int GetProduct(int[] arr)
    {
        int product = 1;
        for (int i = 0; i < arr.Length; i++)
        {
            product *= arr[i];
        }

        return product;
    }
    private static double GetProduct(double[] arr)
    {
        double product = 1;
        for (int i = 0; i < arr.Length; i++)
        {
            product *= arr[i];
        }

        return product;
    }
    static void Main(string[] args)
    {
        int[] nums = { 1, 2, 3, 4, 5 };
        double[] doubleNums = {1.1, 2.1, 3.1, 4.1, 5.1};
        Console.WriteLine(GetAverage(nums));
        Console.WriteLine(GetMax(nums));
        Console.WriteLine(GetMin(doubleNums));
        Console.WriteLine(GetProduct(nums));
        Console.WriteLine(GetSum(doubleNums));
    }
}
