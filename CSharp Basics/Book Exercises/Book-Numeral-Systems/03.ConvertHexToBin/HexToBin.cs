using System;

class HexToBin
{
    static void Main(string[] args)
    {
        string number = "2A3E";
        int numberDec = Convert.ToInt32(number, 16);
        string binary = Convert.ToString(numberDec, 2);
        //Console.WriteLine(numberDec);
        Console.WriteLine(binary);
    }
}

//Превърнете шестнайсетичните числа 2A3E, FA, FFFF, 5A0E9 в двоична и десетична бройна система.