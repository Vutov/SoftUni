using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoreboard
{
    using System.IO;

    class ProgramMain
    {
        static void Main(string[] args)
        {
            FileStream ostrm;
            StreamWriter writer;
            TextWriter oldOut = Console.Out;
            try
            {
                ostrm = new FileStream("../../Redirect.txt", FileMode.OpenOrCreate, FileAccess.Write);
                writer = new StreamWriter(ostrm);
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot open Redirect.txt for writing");
                Console.WriteLine(e.Message);
                return;
            }
            Console.SetOut(writer);





            var game = new GameCollection();
            var line = Console.ReadLine();

            while (line != "End")
            {
                var tokens = line.Split(' ');
                if (tokens.Length == 0)
                {
                    continue;
                }

                var command = tokens[0];
                try
                {
                    switch (command)
                    {
                        case "RegisterUser":
                            game.RegisterUser(tokens[1], tokens[2]);
                            Console.WriteLine("User registered");
                            break;
                        case "RegisterGame":
                            game.RegisterGame(tokens[1], tokens[2]);
                            Console.WriteLine("Game registered");
                            break;
                        case "AddScore":
                            game.AddScore(tokens[1], tokens[2], tokens[3], tokens[4], int.Parse(tokens[5]));
                            Console.WriteLine("Score added");
                            break;
                        case "ShowScoreboard":
                            game.ShowScoreboard(tokens[1]);
                            break;
                        case "DeleteGame":
                            game.DeleteGame(tokens[1], tokens[2]);
                            Console.WriteLine("Game deleted");
                            break;
                        case "ListGamesByPrefix":
                            game.GameByPrefix(tokens[1]);
                            break;
                    }
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                line = Console.ReadLine();
            }







            Console.SetOut(oldOut);
            writer.Close();
            ostrm.Close();
            Console.WriteLine("Done");
        }
    }
}
