namespace _04.Salaries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Salaries
    {
        private static readonly Dictionary<int, long> salaries = new Dictionary<int, long>();

        static void Main(string[] args)
        {
            var employeesCount = int.Parse(Console.ReadLine());
            var employeesGraph = new Dictionary<int, List<int>>();
            for (int i = 0; i < employeesCount; i++)
            {
                var employee = Console.ReadLine();
                employeesGraph.Add(i, new List<int>());
                for (int j = 0; j < employee.Length; j++)
                {
                    if (employee[j] == 'Y')
                    {
                        employeesGraph[i].Add(j);
                    }
                }
            }

            var orderedEmployees = employeesGraph.OrderBy(e => e.Value.Count).ToDictionary(e => e.Key, e => e.Value);

            foreach (var employee in orderedEmployees)
            {
                DFS(orderedEmployees, employee.Key, new bool[employeesGraph.Count]);
            }

            var sum = 0L;
            foreach (var salary in salaries)
            {
                sum += salary.Value;
            }

            Console.WriteLine(sum);
        }

        private static void DFS(Dictionary<int, List<int>> employeesGraph, int manager, bool[] visited)
        {
            if (salaries.ContainsKey(manager) && salaries[manager] != 0)
            {
                return;
            }

            if (visited[manager] == false)
            {
                visited[manager] = true;

                if (employeesGraph[manager].Count == 0)
                {
                    salaries.Add(manager, 1);
                    return;
                }

                if (!salaries.ContainsKey(manager))
                {
                    salaries.Add(manager, 0);
                }

                foreach (var employee in employeesGraph[manager])
                {
                    if (visited[employee] == false)
                    {
                        DFS(employeesGraph, employee, visited);
                    }

                    salaries[manager] += salaries[employee];
                }
            }
        }
    }
}