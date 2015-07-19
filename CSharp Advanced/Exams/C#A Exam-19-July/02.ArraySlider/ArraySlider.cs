namespace _02.ArraySlider
{
    using System;
    using System.Linq;
    using System.Numerics;
    using System.Text.RegularExpressions;

    public class ArraySlider
    {
        public static void Main(string[] args)
        {
            var numbers = Regex.Split(Console.ReadLine().Trim(), "\\s+").Select(BigInteger.Parse).ToArray();
            var command = Console.ReadLine();
            var currentIndex = 0;
            while (!command.Equals("stop"))
            {
                var commandInfo = Regex.Split(command.Trim(), "\\s+");
                var offset = int.Parse(commandInfo[0]);

                if (currentIndex + offset < 0)
                {
                    currentIndex = (currentIndex + offset) % numbers.Length;
                    currentIndex = numbers.Length + currentIndex;
                }
                else if (currentIndex + offset > 0)
                {
                    currentIndex = (currentIndex + offset) % numbers.Length;
                }
                else
                {
                    currentIndex += offset;
                }

                if (currentIndex == numbers.Length)
                {
                    currentIndex = 0;
                }

                var operation = commandInfo[1];
                var operand = BigInteger.Parse(commandInfo[2]);

                switch (operation)
                {
                    case "&":
                        numbers[currentIndex] &= operand;
                        break;
                    case "|":
                        numbers[currentIndex] |= operand;
                        break;
                    case "^":
                        numbers[currentIndex] ^= operand;
                        break;
                    case "+":
                        numbers[currentIndex] += operand;
                        break;
                    case "-":
                        numbers[currentIndex] -= operand;
                        break;
                    case "*":
                        numbers[currentIndex] *= operand;
                        break;
                    case "/":
                        numbers[currentIndex] /= operand;
                        break;
                }

                if (numbers[currentIndex] < 0)
                {
                    numbers[currentIndex] = 0;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine("[{0}]", string.Join(", ", numbers));
        }
    }
}