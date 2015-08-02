namespace _03.ExportFinishedGamesAsXml
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    using _01.DatabaseFirstMapping;

    public class ExportXml
    {
        public static void Main(string[] args)
        {
            var directory = new FileInfo("../../../finished-games.xml");
            var context = new DiabloEntities();
            var finishedGames = context.Games
                .Where(g => g.IsFinished == true)
                .Select(g => new
                {
                    gameName = g.Name,
                    gameDuration = g.Duration,
                    users = g.UsersGames.Select(u => new
                    {
                        u.User.Username,
                        u.User.IpAddress
                    })
                })
                .OrderBy(g => g.gameName)
                .ThenBy(g => g.gameDuration)
                .ToList();

            var xml = new XDocument();
            var root = new XElement("games");
            xml.Add(root);

            finishedGames.ForEach(g =>
            {
                var gameNode = new XElement("game");
                gameNode.SetAttributeValue("name", g.gameName);
                if (g.gameDuration != null)
                {
                    gameNode.SetAttributeValue("duration", g.gameDuration);
                }

                var usersNode = new XElement("users");
                foreach (var user in g.users)
                {
                    var userNode = new XElement("user");
                    userNode.SetAttributeValue("username", user.Username);
                    userNode.SetAttributeValue("ip-address", user.IpAddress);
                    usersNode.Add(userNode);
                }

                gameNode.Add(usersNode);
                root.Add(gameNode);
            });

            xml.Save(directory.FullName);
            Console.WriteLine("XML saved : " + directory.FullName);
        }
    }
}
