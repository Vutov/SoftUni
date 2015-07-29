namespace Theatre.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Exceptions;
    using Interfaces;
    using Models;

    public class Engine : IPerformanceDatabase
    {
        private readonly SortedDictionary<string, SortedSet<Performance>> allTeaters;

        public Engine()
        {
            this.allTeaters = new SortedDictionary<string, SortedSet<Performance>>();
        }

        public string ExecuteAddTheatreCommand(string tearter)
        {
            this.AddTheatre(tearter);
            return "Theatre added";
        }

        public string ExecutePrintAllTheatresCommand()
        {
            var theatres = this.ListTheatres().ToList();
            if (theatres.Count > 0)
            {
                return string.Join(", ", theatres);
            }

            return "No theatres";
        }

        public string ExecuteAddPerformance(string theatreName, string performanceTitle, DateTime startDateTime, TimeSpan duration, decimal price)
        {
            this.AddPerformance(theatreName, performanceTitle, startDateTime, duration, price);
            return "Performance added";
        }

        public string ExecutePrintAllPerformancesCommand()
        {
            var performances = this.ListAllPerformances().ToList();
            var result = new StringBuilder();
            if (performances.Any())
            {
                for (int i = 0; i < performances.Count; i++)
                {
                    if (i > 0)
                    {
                        result.Append(", ");
                    }

                    var currentPerfomance = performances[i].StartDateTime.ToString("dd.MM.yyyy HH:mm");
                    result.AppendFormat("({0}, {1}, {2})", performances[i].PerformanceTitle, performances[i].TeatreName, currentPerfomance);
                }

                return result.ToString();
            }

            return "No performances";
        }

        public string ExecutePrintPerformances(string theatre)
        {
            var performances = this.ListPerformances(theatre)
                .Select(p =>
                {
                    var performance = p.StartDateTime.ToString("dd.MM.yyyy HH:mm");
                    return string.Format("({0}, {1})", p.PerformanceTitle, performance);
                })
                .ToList();

            var commandMessage = string.Empty;
            if (performances.Any())
            {
                commandMessage = string.Join(", ", performances);
            }
            else
            {
                commandMessage = "No performances";
            }

            return commandMessage;
        }

        public void AddTheatre(string teater)
        {
            if (this.allTeaters.ContainsKey(teater))
            {
                throw new DuplicateTheatreException("Duplicate theatre");
            }

            this.allTeaters[teater] = new SortedSet<Performance>();
        }

        public IEnumerable<string> ListTheatres()
        {
            var teatres = this.allTeaters.Keys;
            return teatres;
        }

        public void AddPerformance(string theatreName, string performanceTitle, DateTime startDateTime, TimeSpan duration, decimal price)
        {
            if (!this.allTeaters.ContainsKey(theatreName))
            {
                throw new TheatreNotFoundException("Theatre does not exist");
            }

            var performances = this.allTeaters[theatreName];
            var endDateTime = startDateTime + duration;
            if (this.IsAvailableSlot(performances, startDateTime, endDateTime))
            {
                throw new TimeDurationOverlapException("Time/duration overlap");
            }

            var performance = new Performance(theatreName, performanceTitle, startDateTime, duration, price);
            performances.Add(performance);
        }

        public IEnumerable<Performance> ListAllPerformances()
        {
            var theatres = this.allTeaters.Keys;

            var allPerformances = new List<Performance>();
            foreach (var teatre in theatres)
            {
                var performances = this.allTeaters[teatre];
                allPerformances.AddRange(performances);
            }

            return allPerformances;
        }

        public IEnumerable<Performance> ListPerformances(string theatreName)
        {
            if (!this.allTeaters.ContainsKey(theatreName))
            {
                throw new TheatreNotFoundException("Theatre does not exist");
            }

            var performances = this.allTeaters[theatreName];
            return performances;
        }

        private bool IsAvailableSlot(IEnumerable<Performance> performances, DateTime startTime, DateTime endTime)
        {
            foreach (var performance in performances)
            {
                var performanceStartTime = performance.StartDateTime;
                var performanceEndTime = performance.StartDateTime + performance.Duration;

                if ((performanceStartTime <= startTime && startTime <= performanceEndTime) ||
                    (performanceStartTime <= endTime && endTime <= performanceEndTime) ||
                    (startTime <= performanceStartTime && performanceStartTime <= endTime) ||
                    (startTime <= performanceEndTime && performanceEndTime <= endTime))
                {
                    return true;
                }
            }

            return false;
        }
    }
}