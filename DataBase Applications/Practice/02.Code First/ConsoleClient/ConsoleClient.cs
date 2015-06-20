using System;
using System.Linq;
using Data;
using Models;

namespace ConsoleClient
{
    class ConsoleClient
    {
        static void Main(string[] args)
        {
            var context = new SystemDBContext();
            var students = context.Students.ToList();
            students.ForEach(s =>
            {
                Console.WriteLine("Name: {0} Birthday: {1:dd-MM-yy}", s.Name, s.Birthday);
            });
        }
    }
}
