namespace ImportLeaguesAndTeamsFromXml
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Xml.Linq;
    using DatabaseFirstMapping;

    class ImportXml
    {
        static void Main(string[] args)
        {
            var context = new FootballEntities();
            var doc = XDocument.Load("../../../leagues-and-teams.xml");
            var leagues = doc.Root.Elements();
            var leagueCounter = 1;

            try
            {
                foreach (var league in leagues)
                {
                    Console.WriteLine("Processing league #{0} ...", leagueCounter);
                    //League newLeague = new League();
                    var newLeague = ProcessLeague(context, league);

                    var teamsNode = league.Element("teams");
                    if (teamsNode != null)
                    {
                        foreach (var team in teamsNode.Elements())
                        {
                            ProcessTeam(context, team, newLeague);
                        }
                    }

                    leagueCounter++;
                    Console.WriteLine();
                }
            }
            catch (ArgumentException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }

        private static void ProcessTeam(FootballEntities context, XElement team, League league)
        {
            var newTeam = new Team();
            var name = team.Attribute("name");
            if (name != null)
            {
                newTeam.TeamName = name.Value;
            }
            else
            {
                throw new ArgumentException("Team name is mandatory when team tag exists");
            }

            var countryName = team.Attribute("country");
            if (countryName != null)
            {
                var countryByName = context.Countries.FirstOrDefault(c => c.CountryName == countryName.Value);
                if (countryByName == null)
                {
                    var message = string.Format("The given country does not exit in the database. {0}",
                        countryName);
                    throw new ArgumentException(message);
                }

                newTeam.Country = countryByName;
            }

            Team teamInDb = null;
            if (newTeam.Country != null)
            {
                teamInDb =
                    context.Teams.FirstOrDefault(t => t.TeamName == newTeam.TeamName &&
                                                      t.Country.CountryName == newTeam.Country.CountryName);
            }

            if (teamInDb == null)
            {
                if (newTeam.Country != null)
                {
                    Console.WriteLine("Created team: {0} ({1})", newTeam.TeamName, newTeam.Country.CountryName);
                }
                else
                {
                    Console.WriteLine("Created team: {0} (no country)", newTeam.TeamName);
                }

                if (league != null)
                {
                    newTeam.Leagues.Add(league);
                    Console.WriteLine("Added team to league: {0} to league {1}",
                        newTeam.TeamName,
                        league.LeagueName);
                }

                context.Teams.AddOrUpdate(newTeam);
                context.SaveChanges();
            }
            else
            {
                if (newTeam.Country != null)
                {
                    Console.WriteLine("Existing team: {0} ({1})", newTeam.TeamName, newTeam.Country.CountryName);
                }
                else
                {
                    Console.WriteLine("Existing team: {0} (no country)", newTeam.TeamName);
                }

                if (league != null)
                {
                    if (teamInDb.Leagues.Any(l => l.LeagueName == league.LeagueName))
                    {
                        teamInDb.Leagues.Add(league);
                        Console.WriteLine("Existing team in league: {0} belongs to {1}",
                            teamInDb.TeamName,
                            teamInDb.Leagues.First().LeagueName);
                    }
                    else
                    {
                        teamInDb.Leagues.Add(league);
                        context.SaveChanges();
                        Console.WriteLine("Added team to league: {0} to league {1}",
                            newTeam.TeamName,
                            league.LeagueName);
                    }
                }
            }
        }

        private static League ProcessLeague(FootballEntities context, XElement league)
        {
            League newLeague = null;
            var leagueNode = league.Element("league-name");
            if (leagueNode != null)
            {
                newLeague = context.Leagues.FirstOrDefault(l => l.LeagueName == leagueNode.Value);
                if (newLeague == null)
                {
                    newLeague = new League() { LeagueName = leagueNode.Value };
                    context.Leagues.AddOrUpdate(newLeague);
                    context.SaveChanges();
                    Console.WriteLine("Created league: {0}", newLeague.LeagueName);
                }
                else
                {
                    Console.WriteLine("Existing league: {0}", newLeague.LeagueName);
                }
            }

            return newLeague;
        }
    }
}
