using System;

class PrintName
{

    private static void PrintYourName(string name)
    {
        Console.WriteLine("Hello, {0}!", name);
    }
    
    
    
    static void Main(string[] args)
    {
        PrintYourName("spas");
        PrintYourName("ivan");
    }
}