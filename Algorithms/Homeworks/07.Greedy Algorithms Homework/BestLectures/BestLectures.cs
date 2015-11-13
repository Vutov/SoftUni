using System;

namespace BestLectures
{
    using System.Text.RegularExpressions;

    class BestLectures
    {
        static void Main()
        {
            var n = int.Parse(Regex.Match(Console.ReadLine(), @".+?(\d+)").Groups[1].Value);
            var activities = new Lecture[n];
            for (int i = 0; i < n; i++)
            {
                var data = Regex.Match(Console.ReadLine(), @"(\w+).+?(\d+).+?(\d+)").Groups;
                var activity = new Lecture();
                activity.Name = data[1].Value;
                activity.Start = int.Parse(data[2].Value);
                activity.Finish = int.Parse(data[3].Value);
                activities[i] = activity;
            }

            Array.Sort(activities, (a, b) => a.Finish.CompareTo(b.Finish));

            var lastSelectedActivity = activities[0];
            Print(lastSelectedActivity);

            foreach (var activity in activities)
            {
                if (activity.Start >= lastSelectedActivity.Finish)
                {
                    Print(activity);
                    lastSelectedActivity = activity;
                }
            }
        }

        private static void Print(Lecture activity)
        {
            Console.WriteLine("{0}-{1} -> {2}", activity.Start, activity.Finish, activity.Name);
        }
    }
}
