namespace Theatre.Models
{
    using System;

    public class Performance : IComparable<Performance>
    {
        public Performance(string teatreName, string performanceTitle, DateTime startDateTime, TimeSpan duration, decimal price)
        {
            this.TeatreName = teatreName;
            this.PerformanceTitle = performanceTitle;
            this.StartDateTime = startDateTime;
            this.Duration = duration;
            this.Price = price;
        }

        public string TeatreName { get; private set; }

        public string PerformanceTitle { get; private set; }

        public DateTime StartDateTime { get; set; }

        public TimeSpan Duration { get; private set; }

        protected internal decimal Price { get; private set; }

        int IComparable<Performance>.CompareTo(Performance otherPerformance)
        {
            return this.StartDateTime.CompareTo(otherPerformance.StartDateTime);
        }

        public override string ToString()
        {
            var result = string.Format(
                "Performance(Theatre Name: {0}; Performance Title: {1}; StartDateTime: {2}, Duration: {3}, Price: {4})",
                this.TeatreName,
                this.PerformanceTitle,
                this.StartDateTime.ToString("dd.MM.yyyy HH:mm"),
                this.Duration.ToString("hh':'mm"),
                this.Price.ToString("f2"));

            return result;
        }
    }
}
