namespace _05.Lined_Stack
{
    using System;

    public class LinkedStackTests
    {
        public static void Main(string[] args)
        {
            var testStack = new LinkedStack<int>();

            testStack.Push(1);
            testStack.Push(2);
            testStack.Push(3);
            testStack.Push(4);

            var stackArr = testStack.ToArray();
            foreach (var i in stackArr)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine(testStack.Pop());
            testStack.Pop();
            testStack.Pop();
            testStack.Pop();
            testStack.Pop();
        } 
    }
}