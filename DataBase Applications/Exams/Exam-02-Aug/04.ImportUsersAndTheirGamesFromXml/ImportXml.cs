namespace _04.ImportUsersAndTheirGamesFromXml
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Xml.Linq;
    using _01.DatabaseFirstMapping;

    public class ImportXml
    {
        private const string DateTimeFormat = "dd/mm/yyyy";

        static void Main(string[] args)
        {
            var context = new DiabloEntities();
            var doc = XDocument.Load("../../../data/users-and-games.xml");
            var users = doc.Root.Elements();
            foreach (var user in users)
            {
                try
                {
                    ProcessUserBatch(context, user);
                }
                catch (ArgumentException ex)
                {
                    Console.Error.WriteLine(ex.Message);
                }
            }
        }

        private static void ProcessUserBatch(DiabloEntities context, XElement user)
        {
            // Optional
            string firstName = null;
            string lastName = null;
            string email = null;
            if (user.Attribute("first-name") != null)
            {
                firstName = user.Attribute("first-name").Value;
            }

            if (user.Attribute("last-name") != null)
            {
                lastName = user.Attribute("last-name").Value;
            }

            if (user.Attribute("email") != null)
            {
                email = user.Attribute("email").Value;
            }

            // Required
            ValidateRequired(user);

            var username = user.Attribute("username").Value;
            var ip = user.Attribute("ip-address").Value;
            var deleted = int.Parse(user.Attribute("is-deleted").Value);
            var isDeleted = true;
            if (deleted == 0)
            {
                isDeleted = false;
            }

            var registrationDate = DateTime.ParseExact(user.Attribute("registration-date").Value, DateTimeFormat,
                CultureInfo.InvariantCulture);

            var dbUser = context.Users.FirstOrDefault(u => u.Username == username);
            if (dbUser != null)
            {
                var message = string.Format("User {0} already exists", username);
                throw new ArgumentException(message);
            }

            var xmlUser = new User()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Username = username,
                IpAddress = ip,
                IsDeleted = isDeleted,
                RegistrationDate = registrationDate
            };

            var gameMessages = new List<string>();
            var games = user.Elements();
            foreach (var game in games.Elements())
            {
                var userGame = ProcessGame(context, game);

                xmlUser.UsersGames.Add(userGame);
                var gameMessage = string.Format("User {0} successfully added to game {1}", xmlUser.Username, userGame.Game.Name);
                gameMessages.Add(gameMessage);
            }

            context.Users.Add(xmlUser);
            context.SaveChanges();
            Console.WriteLine("Successfully added user {0}", xmlUser.Username);
            Console.WriteLine(string.Join("\n", gameMessages));
        }
        private static UsersGame ProcessGame(DiabloEntities context, XElement game)
        {
            if (game.Element("game-name") == null)
            {
                throw new ArgumentException("game-name is required!");
            }

            var gameName = game.Element("game-name").Value;
            var dbGame = context.Games.FirstOrDefault(g => g.Name == gameName);
            if (dbGame == null)
            {
                var message = string.Format("{0} game not existing!", gameName);
                throw new ArgumentException(message);
            }

            var characterNode = game.Element("character");
            if (characterNode == null)
            {
                throw new ArgumentException("character is required!");
            }

            var charName = characterNode.Attribute("name").Value;
            var cash = decimal.Parse(characterNode.Attribute("cash").Value);
            var dbChar = context.Characters.FirstOrDefault(c => c.Name == charName);
            if (dbChar == null)
            {
                dbChar = new Character() { Name = charName };
            }

            var level = int.Parse(characterNode.Attribute("level").Value);
            var joinedNode = game.Element("joined-on");
            if (joinedNode == null)
            {
                throw new ArgumentException("joined-on is required!");
            }

            var joinedOn = DateTime.ParseExact(joinedNode.Value, DateTimeFormat,
                CultureInfo.InvariantCulture);

            var userGame = new UsersGame()
            {
                Cash = cash,
                Game = dbGame,
                JoinedOn = joinedOn,
                Level = level,
                Items = new List<Item>(),
                Character = dbChar
            };

            return userGame;
        }

        private static void ValidateRequired(XElement user)
        {
            if (user.Attribute("username") == null)
            {
                throw new ArgumentException("Username is required!");
            }

            if (user.Attribute("ip-address") == null)
            {
                throw new ArgumentException("ip-address is required!");
            }

            if (user.Attribute("is-deleted") == null)
            {
                throw new ArgumentException("is-deleted is required!");
            }

            if (user.Attribute("registration-date") == null)
            {
                throw new ArgumentException("registration-date is required!");
            }
        }
    }
}