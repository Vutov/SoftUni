using System;

class ThreeNumbersInCol
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter first number");
        int firstNum = int.Parse(Console.ReadLine());
        Console.WriteLine("Please enter second number");
        double secondNum = double.Parse(Console.ReadLine());
        Console.WriteLine("Please enter third number");
        double thirdNum = double.Parse(Console.ReadLine());
        thirdNum = - thirdNum;
        Console.WriteLine("{0,10:X}{1,10:F}{2,10:F}",firstNum, secondNum, thirdNum);
    }
}
//4. Напишете програма, която отпечатва три числа в три виртуални колони на конзолата. Всяка колона трябва да е с широчина 10 символа, а числата трябва да са ляво подравнени.
//Първото число трябва да е цяло число в шестнадесетична бройна система, второто да е дробно положително, а третото – да е дробно отрицателно.
//Глава 4. Вход и изход от конзолата 195
//Последните две числа да се закръглят до втория знак след десетичната запетая.