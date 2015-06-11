using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSlum.Characters;
using TheSlum.GameEngine;
using TheSlum.Items;

namespace TheSlum
{
    class ExtendedEngine : Engine
    {
        protected override void ExecuteCommand(string[] inputParams)
        {
            switch (inputParams[0])
            {
                case "status":
                    this.PrintCharactersStatus(this.characterList);
                    break;
                case "create":
                    this.CreateCharacter(inputParams);
                    break;
                case "add":
                    this.AddNewItem(inputParams);
                    break;
            }
        }

        protected override void CreateCharacter(string[] inputParams)
        {
            var type = inputParams[1];
            var name = inputParams[2];
            var x = int.Parse(inputParams[3]);
            var y = int.Parse(inputParams[4]);
            var team = (Team)Enum.Parse(typeof(Team), inputParams[5], true);

            Character cha;
            switch (type)
            {
                case "warrior":
                    cha = new Warrior(name, x, y, team);
                    break;
                case "mage":
                    cha = new Mage(name, x, y, team);
                    break;
                case "healer":
                    cha = new Healer(name, x, y, team);
                    break;
                default: return;
            }

            this.characterList.Add(cha);
        }

        protected void AddNewItem(string[] inputParams)
        {
            var character = inputParams[1];
            var type = inputParams[2];
            var name = inputParams[2];

            var currChar = this.characterList.Find(c => c.Id == character);
            switch (type)
            {
                case "axe":
                    currChar.AddToInventory(new Axe(name));
                    break;
                case "shield":
                    currChar.AddToInventory(new Shield(name));
                    break;
                case "injection":
                    currChar.AddToInventory(new Injection(name));
                    break;
                case "pill":
                    currChar.AddToInventory(new Pill(name));
                    break;
            }
        }
    }
}
