using System;
using System.Threading;

namespace _03.Asynchronous_Timer
{
    class AsyncTimer
    {
        public AsyncTimer(Action t, int tick, int tickInterval)
        {
            this.Tick = tick;
            this.TickInterval = tickInterval;
            this.T = t;
        }

        public Action T { get; set; }
        public int Tick { get; set; }
        public int TickInterval { get; set; }

        public void StartTimer()
        {
            for (int i = 0; i < this.Tick; i++)
            {
                Thread.Sleep(this.TickInterval);
                T.Invoke();
            }
        }
    }
}
