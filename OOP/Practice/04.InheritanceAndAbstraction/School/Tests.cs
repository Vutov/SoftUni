using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    class Tests
    {
        public static void Main()
        {
            Student me = new Student("Az", "1234");
            Person test = new Student("tih", "sdfas");

            Console.WriteLine(me);
            Console.WriteLine(test);
        }
    }
}
