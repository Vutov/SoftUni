using System;

class BiggerOrSmaller
{
    private static string Evaluate(int[] array, int possition)
    {
        string result = "";
        int len = array.Length;
        if (possition >= len)
        {
            return "Invalid possition";
        }
        if (possition == 0)
        {
            if (array[possition] > array[possition + 1])
            {
                result = "bigger";
            }
            else
            {
                result = "smaller";
            }
        }
        else if(possition == len - 1)
        {
            if (array[possition] > array[possition - 1])
            {
                result = "bigger";
            }
            else
            {
                result = "smaller";
            }
        }
        else
        {
            if (array[possition] > array[possition - 1] && array[possition] > array[possition + 1])
            {
                result = "bigger";
            }
            else if (array[possition] < array[possition - 1] && array[possition] < array[possition + 1])
            {
                result = "smaller";
            }
            else
	        {
                result = "between";
	        }
        }
        return result;
    }

    private static int indexBiggerOfNeighbors(int[] array)
    {
        int len = array.Length;
        int index = -1;
        for (int i = 0; i < len; i++)
        {
            if (i == 0)
            {
                if (array[i] > array[i + 1])
                {
                    index = i;
                }
            }
            else if (i == len - 1)
            {
                if (array[i] > array[i - 1])
                {
                    index = i;
                }
            }
            else
            {
                if (array[i] > array[i - 1] && array[i] > array[i + 1])
                {
                    index = i;
                }
            }
        }
        return index;
    }
    
    static void Main(string[] args)
    {
        int[] array = { 1, 2, 2, 2, 2 };

        Console.WriteLine(indexBiggerOfNeighbors(array));
    }
}

/*Напишете метод, който проверява дали елемент, намиращ се на дадена
 * позиция от масив, е по-голям, или съответно по-малък от двата му съседа. 
 * Тествайте метода дали работи коректно*/