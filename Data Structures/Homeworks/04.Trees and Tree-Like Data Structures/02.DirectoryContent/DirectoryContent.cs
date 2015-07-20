namespace _02.DirectoryContent
{
    using System;
    using System.IO;

    public class DirectoryContent
    {
        public static void Main(string[] args)
        {
            // Feel free to change to C:\\Windows\ , but it might be restricted.
            var rootFolderInfo = new DirectoryInfo(@"..\..\..\");
            Console.WriteLine(rootFolderInfo.FullName);
            var directoryTree = new DirectoryTree(rootFolderInfo);
            Console.WriteLine("{0} KB", directoryTree.GetSummedUpSize() / 1024);
        }
    }
}