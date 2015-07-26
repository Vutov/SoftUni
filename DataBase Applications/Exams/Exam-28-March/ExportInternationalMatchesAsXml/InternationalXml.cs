namespace ExportInternationalMatchesAsXml
{
    using System;
    using System.Linq;
    using System.Xml.Linq;
    using DatabaseFirstMapping;

    class InternationalXml
    {
        static void Main(string[] args)
        {
            var context = new FootballEntities();
            var matches = context.InternationalMatches
                .Select(m => new Match()
                {
                    HomeCountryName = m.HomeTeamCountry.CountryName,
                    HomeCountryCode = m.HomeCountryCode,
                    AwayCountryName = m.AwayTeamCountry.CountryName,
                    AwayCountryCode = m.AwayCountryCode,
                    Date = m.MatchDate,
                    LeagueName = m.League.LeagueName,
                    Score = m.HomeGoals + "-" + m.AwayGoals
                })
                .OrderBy(m => m.Date)
                .ThenBy(m => m.HomeCountryName)
                .ThenBy(m => m.AwayCountryName)
                .ToList();

            var xml = new XDocument();
            var root = new XElement("matches");
            xml.Add(root);
            foreach (var match in matches)
            {
                var matchNode = new XElement("match");
                if (match.Date != null)
                {
                    var date = match.Date.Value;
                    if (date.Hour == 0 && date.Minute == 0)
                    {
                        matchNode.SetAttributeValue("date", date.ToString("dd-MMM-yyyy"));
                    }
                    else
                    {
                        matchNode.SetAttributeValue("date-time", date.ToString("dd-MMM-yyyy hh:mm"));
                    }
                }

                var homeCountryNode = new XElement("home-country");
                homeCountryNode.SetAttributeValue("code", match.HomeCountryCode);
                homeCountryNode.Value = match.HomeCountryName;
                matchNode.Add(homeCountryNode);
                var awayCountryNode = new XElement("away-country");
                awayCountryNode.SetAttributeValue("code", match.AwayCountryCode);
                awayCountryNode.Value = match.AwayCountryName;
                matchNode.Add(awayCountryNode);
                if (match.Score != "-")
                {
                    var scoreNode = new XElement("score", match.Score);
                    matchNode.Add(scoreNode);
                }

                if (match.LeagueName != null)
                {
                    var scoreNode = new XElement("league", match.LeagueName);
                    matchNode.Add(scoreNode);
                }

                root.Add(matchNode);
            }

            xml.Save("../../../international-matches.xml");
        }
    }
}
