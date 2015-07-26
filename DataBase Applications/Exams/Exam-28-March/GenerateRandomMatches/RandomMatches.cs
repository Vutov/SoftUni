namespace GenerateRandomMatches
{
    using System;
    using System.Linq;
    using System.Xml.Linq;
    using DatabaseFirstMapping;

    class RandomMatches
    {
        static void Main(string[] args)
        {
            var rng = new Random();

            var context = new FootballEntities();
            var teams = context.Teams.Select(t => t.Id).ToList();

            var doc = XDocument.Load("../../../generate-matches.xml");
            var matches = doc.Root.Elements();

            var requestsCount = 0;
            foreach (var match in matches)
            {
                Console.WriteLine("Processing request #{0}", ++requestsCount);
                var generateCount = 10;
                if (match.Attribute("generate-count") != null)
                {
                    generateCount = int.Parse(match.Attribute("generate-count").Value);
                }

                var maxGoals = 5;
                if (match.Attribute("max-goals") != null)
                {
                    maxGoals = int.Parse(match.Attribute("max-goals").Value);
                }

                var startDate = new DateTime(2000, 01, 01);
                if (match.Element("start-date") != null)
                {
                    startDate = Convert.ToDateTime(match.Element("start-date").Value);
                }

                var endDate = new DateTime(2015, 12, 31);
                if (match.Element("end-date") != null)
                {
                    endDate = Convert.ToDateTime(match.Element("end-date").Value);
                }

                string leagueName = null;
                if (match.Element("league") != null)
                {
                    leagueName = match.Element("league").Value;
                }

                for (int i = 0; i < generateCount; i++)
                {
                    var homeTeamId = teams[rng.Next(0, teams.Count())];
                    var awayTeamId = teams[rng.Next(0, teams.Count())];
                    var newMatch = new TeamMatch()
                    {
                        AwayGoals = rng.Next(0, maxGoals + 1),
                        HomeGoals = rng.Next(0, maxGoals + 1),
                        MatchDate = GetRandomDate(rng, startDate, endDate),
                        HomeTeam = context.Teams.Find(homeTeamId),
                        AwayTeam = context.Teams.Find(awayTeamId)
                    };

                    if (leagueName != null)
                    {
                        var leagueInDb = context.Leagues.FirstOrDefault(l => l.LeagueName == leagueName);
                        if (leagueInDb == null)
                        {
                            newMatch.League = new League() {LeagueName = leagueName};
                        }
                        else
                        {
                            leagueName = leagueInDb.LeagueName;
                            newMatch.League = leagueInDb;
                        }
                    }
                    else
                    {
                        leagueName = "no league";
                    }

                    context.TeamMatches.Add(newMatch);
                    context.SaveChanges();
                    Console.WriteLine("{0:dd-MMM-yyyy}: {1} - {2}: {3}-{4} ({5})",
                        newMatch.MatchDate,
                        newMatch.HomeTeam.TeamName,
                        newMatch.AwayTeam.TeamName,
                        newMatch.HomeGoals,
                        newMatch.AwayGoals,
                        leagueName);
                }

                Console.WriteLine();
            }
        }

        public static DateTime GetRandomDate(Random rng, DateTime from, DateTime to)
        {
            var range = to - from;

            var randTimeSpan = new TimeSpan((long)(rng.NextDouble() * range.Ticks));

            return from + randTimeSpan;
        }
    }
}
