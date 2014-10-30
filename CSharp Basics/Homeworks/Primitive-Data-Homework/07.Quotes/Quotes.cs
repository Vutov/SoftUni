using System;

class Quotes
{
    static void Main(string[] args)
    {
        string notQuotedStr = "The \"use\" of quotations causes difficulties.";
        string quotedStr = @"The ""use"" of quotations causes difficulties." ;
        Console.WriteLine(notQuotedStr + "\n" + quotedStr);
    }
}