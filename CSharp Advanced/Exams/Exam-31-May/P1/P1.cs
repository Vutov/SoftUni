using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace P1
{
    internal class P1
    {
        private static void Main(string[] args)
        {
            var numbers = Regex.Split(Console.ReadLine(), @"\s+").ToList();

            var command = Console.ReadLine();

            while (!command.Equals("end"))
            {
                var data = Regex.Split(command, @"\s+").ToList();
                if (command.StartsWith("reverse"))
                {
                    var start = int.Parse(data[2]);
                    var count = int.Parse(data[4]);
                    numbers = Reverse(start, count, numbers);
                }
                else if (command.StartsWith("sort"))
                {
                    var start = int.Parse(data[2]);
                    var count = int.Parse(data[4]);
                    numbers = Sort(start, count, numbers);
                }
                else if (command.StartsWith("rollLeft"))
                {
                    var rolls = int.Parse(data[1]);

                    var totalRolls = rolls % numbers.Count;
                    if (rolls < 0)
                    {
                        Console.WriteLine("Invalid input parameters.");
                    }

                    for (long i = 0; i < totalRolls; i++)
                    {
                        var mostLeft = numbers[0];
                        numbers.RemoveAt(0);
                        numbers.Add(mostLeft);
                    }
                }
                else if (command.StartsWith("rollRight"))
                {
                    var rolls = int.Parse(data[1]);

                    var totalRolls = rolls % numbers.Count;
                    if (rolls < 0)
                    {
                        Console.WriteLine("Invalid input parameters.");
                    }

                    for (long i = 0; i < totalRolls; i++)
                    {
                        var mostRight = numbers[numbers.Count - 1];
                        numbers.RemoveAt(numbers.Count - 1);
                        numbers.Insert(0, mostRight);
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine("[{0}]", string.Join(", ", numbers));
        }

        private static List<string> Reverse(int start, int count, List<string> numbers)
        {
            var end = start + count;
            if (count < 0 ||
                start < 0 || 
                start > numbers.Count - 1 || 
                end > numbers.Count)
            {
                Console.WriteLine("Invalid input parameters.");
                return numbers;
            }

            var result = new List<string>();
            for (int i = 0; i < start; i++)
            {
                result.Add(numbers[i]);
            }

            for (int i = end - 1; i >= start; i--)
            {
                result.Add(numbers[i]);
            }

            for (int i = end; i < numbers.Count; i++)
            {
                result.Add(numbers[i]);
            }

            return result;
        }

        private static List<string> Sort(int start, int count, List<string> numbers)
        {
            var end = start + count;
            if (count < 0 ||
               start < 0 ||
               start > numbers.Count - 1 ||
               end > numbers.Count)
            {
                Console.WriteLine("Invalid input parameters.");
                return numbers;
            }

            var result = new List<string>();
            for (int i = 0; i < start; i++)
            {
                result.Add(numbers[i]);
            }

            var sortedNumbers = new List<string>();
            for (int i = end - 1; i >= start; i--)
            {
                sortedNumbers.Add(numbers[i]);
            }

            sortedNumbers.Sort();

            for (int i = 0; i < sortedNumbers.Count; i++)
            {
                result.Add(sortedNumbers[i]);
            }

            for (int i = end; i < numbers.Count; i++)
            {
                result.Add(numbers[i]);
            }

            return result;
        }
    }
}