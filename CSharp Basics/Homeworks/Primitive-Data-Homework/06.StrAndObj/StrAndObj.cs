using System;

class StrAndObj
{
    static void Main(string[] args)
    {
        string hello = "Hello";
        string world = "World";
        object helloWorld = hello + " " + world;
        string strHelloWorld = (string)helloWorld;
        Console.WriteLine(strHelloWorld);
    }
}