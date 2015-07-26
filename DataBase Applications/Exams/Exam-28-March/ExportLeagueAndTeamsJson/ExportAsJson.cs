namespace ExportLeagueAndTeamsJson
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Web.Script.Serialization;
    using DatabaseFirstMapping;

    class ExportAsJson
    {
        static void Main(string[] args)
        {
            var context = new FootballEntities();
            var leagues = context.Leagues
                .Select(l => new
                {
                    leagueName = l.LeagueName,
                    teams = l.Teams.Select(t => t.TeamName).OrderBy(t => t)
                })
                .OrderBy(l => l.leagueName)
                .ToList();

            var serializer = new JavaScriptSerializer();
            var json = serializer.Serialize(leagues);
            File.WriteAllText("../../../leagues-and-teams.json", json);
        }
    }
}
