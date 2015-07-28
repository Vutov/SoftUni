namespace ImportJson
{
    using System;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Web.Script.Serialization;
    using CodeFirstPhonebook;
    using CodeFirstPhonebook.Models;

    public class ImportJson
    {
        public static void Main(string[] args)
        {
            var context = new PhonebookEntities();

            var serializer = new JavaScriptSerializer();
            var json = File.ReadAllText("../../../messages.json");
            var messeges = serializer.Deserialize<JsonMessage[]>(json);
            foreach (var messege in messeges)
            {
                try
                {
                    ProcessMessage(context, messege);
                }
                catch (ArgumentException ex)
                {
                    Console.Error.WriteLine("Error: {0}", ex.Message);
                }
            }
        }

        private static void ProcessMessage(PhonebookEntities context, JsonMessage messege)
        {
            if (messege.Content == null)
            {
                throw new ArgumentException("Content is required!");
            }

            if (messege.DateTime == null)
            {
                throw new ArgumentException("DateTime is required!");
            }

            if (messege.Recipient == null)
            {
                throw new ArgumentException("Recipient is required!");
            }

            if (messege.Sender == null)
            {
                throw new ArgumentException("Sender is required!");
            }

            var userMessage = new UserMessage()
            {
                Content = messege.Content,
                DateTime = (DateTime)messege.DateTime,
                Sender = context.Users.FirstOrDefault(u => u.Username == messege.Sender),
                Recipiant = context.Users.FirstOrDefault(u => u.Username == messege.Recipient),
            };

            context.UserMessages.AddOrUpdate(userMessage);
            context.SaveChanges();
            Console.WriteLine("Message \"{0}\" Imported", userMessage.Content);
        }
    }
}
