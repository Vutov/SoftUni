using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3
{
    class P3
    {
        private static int messageLevels = 0;
        private static SortedSet<string> recievedMessage = new SortedSet<string>();
        private static SortedDictionary<string, SortedSet<string>> graph = new SortedDictionary<string, SortedSet<string>>();
        //private static Queue<string> startQuequ = new Queue<string>();

        static void Main(string[] args)
        {
            //var peopleInput = "People: Kiril, Stefan, Ivan, Mridul, Arif, Sahil, Steve, Prakash, Misho, Didi, Maria, Diana, Petya, Katya";
            //var connectionsInput = "Connections: Mridul - Arif, Steve - Prakash, Steve - Kiril, Kiril - Stefan, Stefan - Ivan, Misho - Ivan, Didi - Misho, Stefan - Didi, Maria - Didi, Petya - Katya, Katya - Didi, Petya - Didi, Diana - Petya, Diana - Maria, Maria - Stefan, Diana - Didi";
            //var startInput = "Start: Petya, Arif, Sahil, Steve";
            //var peopleInput = "People: Pesho, Maria, Ivan, Gosho";
            //var connectionsInput =
            //    "Connections: Pesho - Gosho, Maria - Ivan, Ivan - Gosho, Pesho - Maria, Maria - Gosho";
            //var startInput = "Start: Maria";
            var peopleInput = Console.ReadLine();
            var connectionsInput = Console.ReadLine();
            var startInput = Console.ReadLine();

            var people =
                peopleInput.Replace("People:", "")
                    .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

            var connections =
                connectionsInput.Replace("Connections:", "")
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(p => p.Trim())
                    .ToList();

            var start = startInput.Replace("Start: ", "")
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            //foreach (var person in start)
            //{
            //    startQuequ.Enqueue(person);
            //}



            foreach (var connection in connections)
            {
                var data = connection.Split(new char[] { ' ', ',', '-' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                if (!graph.ContainsKey(data[0]))
                {
                    graph.Add(data[0], new SortedSet<string>());
                }

                graph[data[0]].Add(data[1]);

                if (!graph.ContainsKey(data[1]))
                {
                    graph.Add(data[1], new SortedSet<string>());
                }

                graph[data[1]].Add(data[0]);
            }

            SortedSet<string> toldFriends = new SortedSet<string>();
            foreach (var startDude in start)
            {
                toldFriends.Add(startDude);
                recievedMessage.Add(startDude);
            }

            var notFound = false;
            while (recievedMessage.Count < people.Count)
            {
                toldFriends = BadgeTold(toldFriends);
                if (messageLevels > 10000)
                {
                    notFound = true;
                    break;
                }
            }

            //while (startQuequ.Count != 0)
            //{
            //    var nextToTell = startQuequ.Dequeue();
            //    lastToRecieve = TellFriend(nextToTell, graph);
            //}

            if (notFound)
            {
                var unreachable = people.Except(recievedMessage).ToList();
                unreachable.Sort();
                Console.WriteLine("Cannot reach: {0}", string.Join(", ", unreachable));
            }
            else
            {
                Console.WriteLine("All people reached in {0} steps", messageLevels);
                Console.WriteLine("People at last step: {0}", string.Join(", ", toldFriends));
            }
        }

        private static SortedSet<string> BadgeTold(SortedSet<string> start)
        {
            SortedSet<string> toldFriends = new SortedSet<string>();
            foreach (var person in start)
            {
                var result = TellFriend(person);
                foreach (var friend in result)
                {
                    toldFriends.Add(friend);
                }
            }
            messageLevels++;

            return toldFriends;
        }

        private static SortedSet<string> TellFriend(string person)
        {
            recievedMessage.Add(person);
            var toldFriends = new SortedSet<string>();
            if (graph.ContainsKey(person))
            {
                var startPerson = graph[person];

                foreach (var friend in startPerson)
                {
                    if (!recievedMessage.Contains(friend))
                    {
                        recievedMessage.Add(friend);
                        //startQuequ.Enqueue(friend);
                        toldFriends.Add(friend);
                    }

                }
            }

            //Console.WriteLine(person + " told: " + string.Join(", ", toldFriends));
            return toldFriends;
        }
    }
}
