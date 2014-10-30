using System;

class DeclareVar
{
    static void Main(string[] args)
    {
        //52130, -115, 4825932, 97, -10000. 
        ushort var1 = 52130;
        sbyte var2 = -115;
        int var3 = 4825932;
        byte var4 = 97;
        short var5 = -10000;
        Console.WriteLine("Desired result: 52130, -115, 4825932, 97, -10000");
        Console.WriteLine("Actual result: {0}, {1}, {2}, {3}, {4}", var1, var2, var3, var4, var5);
    }
}
