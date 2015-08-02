namespace _01.DatabaseFirstMapping
{
    using System;
    using System.Linq;

    public  class DatabaseFirst
    {
        public static void Main(string[] args)
        {
            var context = new DiabloEntities();
            var characterNames = context.Characters.Select(c => c.Name).ToList();
            characterNames.ForEach(Console.WriteLine);
        }
    }
}
