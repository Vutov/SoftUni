namespace _01.EventsInGivenRange
{
    using System;
    using System.Globalization;
    using System.Threading;
    using Wintellect.PowerCollections;

    public class EventsInGivenRange
    {
        public static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var eventCount = int.Parse(Console.ReadLine());
            var datesAndEvents = new OrderedMultiDictionary<DateTime, string>(true);
            for (int i = 0; i < eventCount; i++)
            {
                var currentEvent = Console.ReadLine();
                var token = currentEvent.Split('|');
                var date = DateTime.Parse(token[1].Trim());
                var name = token[0].Trim();
                datesAndEvents.Add(date, name);
            }

            var queryNumber = int.Parse(Console.ReadLine());
            for (int i = 0; i < queryNumber; i++)
            {
                var query = Console.ReadLine().Split('|');
                var startDate = DateTime.Parse(query[0].Trim());
                var endDate = DateTime.Parse(query[1].Trim());
                var queryData = datesAndEvents.Range(startDate, true, endDate, true);
                Console.WriteLine(queryData.KeyValuePairs.Count);
                foreach (var e in queryData)
                {
                    foreach (var name in e.Value)
                    {
                        Console.WriteLine("{0} | {1:dd-MMM-yyyy}", name, e.Key);
                    }
                }
            }
        }
    }
}
