namespace Logger.Models.Appenders
{
    using System;

    public abstract class Appender : IAppender
    {
        protected Appender(ILayout layout)
        {
            this.Layout = layout;
            this.ReportLevel = ReportLevel.Info;
        }

        public ILayout Layout { get; private set; }

        public ReportLevel ReportLevel { get; set; }

        public abstract void Append(DateTime date, ReportLevel reportLevel, string message);

        protected string GetFormattedLogEntry(DateTime date, ReportLevel reportLevel, string message)
        {
            return this.Layout.FormatLog(date, reportLevel, message);
        }
    }
}
