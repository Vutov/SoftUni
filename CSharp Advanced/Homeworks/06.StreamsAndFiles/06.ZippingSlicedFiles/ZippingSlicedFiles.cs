using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.ZippingSlicedFiles
{
    class ZippingSlicedFiles
    {
        private static void Slice(string sourceFile, string destinationDirectory, int parts)
        {
            using (var source = new FileStream(sourceFile, FileMode.Open))
            {
                byte[] buffer = new byte[4096];
                var allData = new List<byte>();
                while (true)
                {
                    int readBytes = source.Read(buffer, 0, buffer.Length);
                    if (readBytes == 0)
                    {
                        break;
                    }

                    for (int i = 0; i < readBytes; i++)
                    {
                        allData.Add(buffer[i]);
                    }
                }

                int partSize = allData.Count / parts;
                int leftOver = allData.Count - partSize * parts;
                for (int i = 0; i < parts; i++)
                {
                    var newFile = destinationDirectory + "part-" + i + ".zip";
                    using (var copy = new FileStream(newFile, FileMode.Create))
                    {
                        using (var zip = new GZipStream(copy, CompressionMode.Compress))
                        {
                            if (i == parts - 1)
                            {
                                zip.Write(allData.ToArray(), i * partSize, partSize + leftOver);
                            }
                            else
                            {
                                zip.Write(allData.ToArray(), i * partSize, partSize);
                            }
                        }
                    }
                }
            }
        }

        private static void Assemble(List<string> files, string destinationDirectory)
        {
            var allData = new List<byte>();
            for (int i = 0; i < files.Count; i++)
            {
                var sourceFile = files[i];
                using (var source = new FileStream(sourceFile, FileMode.Open))
                {
                    using (var zip = new GZipStream(source, CompressionMode.Decompress))
                    {
                        byte[] buffer = new byte[4096];
                        while (true)
                        {
                            int readBytes = zip.Read(buffer, 0, buffer.Length);
                            if (readBytes == 0)
                            {
                                break;
                            }

                            for (int j = 0; j < readBytes; j++)
                            {
                                allData.Add(buffer[j]);
                            }
                        }
                    }
                }
            }

            using (var copy = new FileStream(destinationDirectory, FileMode.Create))
            {
                copy.Write(allData.ToArray(), 0, allData.Count);
            }
        }
        static void Main(string[] args)
        {
            string sourceFile = "../../ZippingSlicedFiles.cs";
            string destinationDirectory = "../../";
            int parts = 5;
            Slice(sourceFile, destinationDirectory, parts);
            Assemble(new List<string>()
            {
                "../../part-0.zip",
                "../../part-1.zip",
                "../../part-2.zip",
                "../../part-3.zip",
                "../../part-4.zip",
            }, "../../Constructed.txt");

            Console.WriteLine("DONE");
        }
    }
}
