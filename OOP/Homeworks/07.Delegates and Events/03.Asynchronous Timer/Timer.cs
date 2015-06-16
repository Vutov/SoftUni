using System;

namespace _03.Asynchronous_Timer
{
    internal class Timer
    {
        public static void Main(string[] args)
        {
            Action getTime = GetTime;

            var timer = new AsyncTimer(getTime, 10, 1000);
            timer.StartTimer();
        }

        public static void GetTime()
        {
            var timeNow = DateTime.Now;
            Console.WriteLine("{0}", timeNow.ToString("HH:mm:ss"));
        }
    }
}
