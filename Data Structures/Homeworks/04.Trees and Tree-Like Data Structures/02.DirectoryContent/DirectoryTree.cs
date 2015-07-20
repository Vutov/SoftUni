namespace _02.DirectoryContent
{
    using System.IO;
    using System.Linq;
    using System.Numerics;

    public class DirectoryTree
    {
        private readonly DirectoryInfo rootFolder;

        public DirectoryTree(DirectoryInfo rootFolder)
        {
            this.rootFolder = rootFolder;
        }

        public BigInteger GetSummedUpSize()
        {
            var size = this.GetSizeOfFolder(this.rootFolder, 0);

            return size;
        }

        /// <summary>
        /// Gets the full size of given folder using recursion.
        /// </summary>
        /// <param name="folder">Folder as DirectoryInfo</param>
        /// <param name="currentSize">Current size in bytes</param>
        /// <returns>All size in bytes</returns>
        private BigInteger GetSizeOfFolder(DirectoryInfo folder, BigInteger currentSize)
        {
            currentSize += folder.GetFiles().Sum(f => f.Length);
            foreach (var child in folder.GetDirectories())
            {
                currentSize = this.GetSizeOfFolder(child, currentSize);
            }

            return currentSize;
        }
    }
}
