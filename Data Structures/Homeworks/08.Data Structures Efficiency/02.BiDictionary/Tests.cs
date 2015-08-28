namespace _02.BiDictionary
{
    using System;

    public class Tests
    {
        static void Main(string[] args)
        {
            var collection = new BiDictionary<string,int,double>();
            collection.Add("as", 1, 10);
            collection.Add("as", 2, 11);
            collection.Add("a", 13, 100);
            collection.Add("ab", 15, 1);
            collection.Add("a", 15, 100);

            var f = collection.Find("as");
            foreach (var d in f)
            {
                Console.WriteLine(d);
            }

            f = collection.Find("as", 1);
            foreach (var d in f)
            {
                Console.WriteLine(d);
            }

            f = collection.Find(15);
            foreach (var d in f)
            {
                Console.WriteLine(d);
            }
        }
    }
}
