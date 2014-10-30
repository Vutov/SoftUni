using System;
// float and double's are entered with "," in the console
class SumOfFiveNumbers
{
    static void Main(string[] args)
    {
        string numbers = Console.ReadLine();
        string[] splitedNumbers = numbers.Split(' ');
        double sum = new double();
        int len = splitedNumbers.Length;
        //Will work with less than 5 or more than 5 numbers.
        for (int i = 0; i < len; i++)
        {
            sum += Convert.ToDouble(splitedNumbers[i]);
        }
        Console.WriteLine("{0:#.##}", sum);
    }
}