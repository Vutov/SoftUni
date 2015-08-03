using System;
using System.Linq;

namespace _03.Phonebook
{
    class Phonebook
    {
        static void Main(string[] args)
        {
            var contactInfo = new HashTable<string, string>();
            var inSeachMode = false;
            var line = Console.ReadLine();
            while (!string.IsNullOrEmpty(line))
            {
                try
                {
                    if (line == "search")
                    {
                        var name = Console.ReadLine();
                        var phoneNumber = FindUserInfo(name, contactInfo);
                        Console.WriteLine("{0} -> {1}", name, phoneNumber);

                        inSeachMode = true;
                    }

                    if (!inSeachMode)
                    {
                        ProcessContactInfo(line, contactInfo);
                    }

                    line = Console.ReadLine();
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static string FindUserInfo(string contactName, HashTable<string, string> contactInfo)
        {
            string phoneNumber;
            if (!contactInfo.TryGetValue(contactName, out phoneNumber))
            {
                var message = string.Format("{0} is not in the dictionary!", contactName);
                throw new ArgumentException(message);
            }

            return phoneNumber;
        }

        private static void ProcessContactInfo(string line, HashTable<string, string> contactInfo)
        {
            var info = line.Split('-').Select(i => i.Trim()).ToList();
            if (!contactInfo.ContainsKey(info[0]))
            {
                contactInfo[info[0]] = info[1];
            }
            else
            {
                var message = string.Format("{0} allready exist in the dictionary!", info[0]);
                throw new ArgumentException(message);
            }
        }
    }
}
