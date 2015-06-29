using System.IO;
using ArmyOfCreatures.Extended;

namespace ArmyOfCreatures.Console
{
    using System;
    using System.Globalization;
    using System.Threading;
    using Commands;
    using Logic;
    using Logic.Battles;

    public static class ArmyOfCreaturesMain
    {
        public static void Main()
        {
            //FileStream ostrm;
            //StreamWriter writer;
            //TextWriter oldOut = Console.Out;
            //try
            //{
            //    ostrm = new FileStream("../../Redirect.txt", FileMode.OpenOrCreate, FileAccess.Write);
            //    writer = new StreamWriter(ostrm);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("Cannot open Redirect.txt for writing");
            //    Console.WriteLine(e.Message);
            //    return;
            //}
            //Console.SetOut(writer);

            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            ICreaturesFactory creaturesFactory = GetCreaturesFactory();
            ILogger logger = new ConsoleLogger();
            IBattleManager battleManager = GetBattleManager(creaturesFactory, logger);

            ICommandManager commandManager = new CommandManager();

            while (true)
            {
                var commandLine = Console.ReadLine();
                commandManager.ProcessCommand(commandLine, battleManager);
            }

            //Console.SetOut(oldOut);
            //writer.Close();
            //ostrm.Close();
            //Console.WriteLine("Done");
            
        }

        private static IBattleManager GetBattleManager(ICreaturesFactory creaturesFactory, ILogger logger)
        {
            // You are allowed to add, change and remove code here
            return new ExtendedBattleManager(creaturesFactory, logger);
        }

        private static ICreaturesFactory GetCreaturesFactory()
        {
            // You are allowed to add, change and remove code here
            return new ExtendedCreaturesFactory();
        }
    }
}
