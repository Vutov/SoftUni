using System;

class DecAndHex
{
    static void Main(string[] args)
    {
        string number = "1111010110011110";
        int numberDec = Convert.ToInt32(number, 2);
        string numberHex = Convert.ToString(numberDec, 16);
        numberHex.ToUpper();
        Console.WriteLine("To DEC: {0}, to HEX : {1}", numberDec, numberHex.ToUpper());
    }
}
 
