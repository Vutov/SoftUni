using System;
using System.IO;

namespace ConsoleForum
{
    using ConsoleForum.Contracts;

    public class ConsoleForumMain
    {
        public static void Main()
        {
            IForum forum = new ExtendedForum();
            forum.Run();
        }
    }
}
