using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Processor
{
    using System.Text.RegularExpressions;

    class Processor
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Regex.Match(Console.ReadLine(), @".+?(\d+)").Groups[1].Value);
            var tasks = new List<ProcessorTask>(n);
            var id = 0;

            for (int i = 0; i < n; i++)
            {
                var data = Regex.Match(Console.ReadLine(), @"(\d+)\s-\s(\d+)").Groups;
                var processorTask = new ProcessorTask();
                processorTask.Value = int.Parse(data[1].Value);
                processorTask.Deadline = int.Parse(data[2].Value);
                processorTask.ValuePerTurns = (double)processorTask.Value / processorTask.Deadline;
                processorTask.Id = ++id;
                tasks.Add(processorTask);
            }

            var sortedTasks = tasks.OrderByDescending(t => t.ValuePerTurns).ThenBy(t => t.Deadline).ThenByDescending(t => t.Value).ToList();

            var totalValue = 0;
            var turn = 0;
            var schedule = new List<int>();
            while (sortedTasks.Any())
            {
                sortedTasks.RemoveAll(t => t.Deadline == turn);
                if (!sortedTasks.Any())
                {
                    break;
                }

                var task = sortedTasks.First();
                schedule.Add(task.Id);
                sortedTasks.Remove(task);
                totalValue += task.Value;
                Console.WriteLine(task.Id);
                foreach (var processorTask in sortedTasks)
                {
                    processorTask.ValuePerTurns = (double)processorTask.Value / (processorTask.Deadline - turn);
                }

                sortedTasks = sortedTasks.OrderByDescending(t => t.ValuePerTurns).ThenBy(t => t.Deadline).ThenByDescending(t => t.Value).ToList();

                turn++;
            }

            Console.WriteLine("Optimal schedule:  {0}", string.Join(" -> ", schedule));
            Console.WriteLine("Total value: " + totalValue);
        }
    }
}
