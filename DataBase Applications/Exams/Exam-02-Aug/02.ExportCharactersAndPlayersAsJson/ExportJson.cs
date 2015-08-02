namespace _02.ExportCharactersAndPlayersAsJson
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Web.Script.Serialization;
    using _01.DatabaseFirstMapping;

    public class ExportJson
    {
        public static void Main(string[] args)
        {
            var directory = new FileInfo("../../../characters.json");
            var context = new DiabloEntities();
            var characters = context.Characters
                .Select(c => new
                {
                    name = c.Name,
                    playedBy = c.UsersGames.Select(ug => ug.User.Username)
                })
                .OrderBy(c => c.name)
                .ToList();

            var serializaer = new JavaScriptSerializer();
            var json = serializaer.Serialize(characters);
            File.WriteAllText(directory.FullName, json);
            Console.WriteLine("Json saved: " + directory.FullName);
        }
    }
}
