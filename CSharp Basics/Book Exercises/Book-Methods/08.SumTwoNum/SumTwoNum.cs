using System;

class SumTwoNum
{
    private static int Sum(int[] firstArray, int[] secondArray)
    {
        int lenFirst = firstArray.Length;
        double firstNumber = new int();
        for (int i = 0; i < lenFirst; i++)
        {
            firstNumber += (firstArray[i] * (Math.Pow(10, i)));
        }
        int lenSecond = firstArray.Length;
        double secondNumber = new int();
        for (int i = 0; i < lenSecond; i++)
        {
            secondNumber += (secondArray[i] * (Math.Pow(10, i)));
        }
        double sum = firstNumber + secondNumber;
        return (int)sum;
    }
    
    static void Main(string[] args)
    {
        int[] arrayOne = { 4, 5, 2 };//254
        int[] arrayTwo = { 0, 0, 1 };//100
        Console.WriteLine(Sum(arrayOne, arrayTwo)); 
    }
}
