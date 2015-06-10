using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassEffect.Exceptions;
using MassEffect.Interfaces;

namespace MassEffect.Engine
{
    public static class Validator
    {
        public static IList<string> shipNames = new List<string>();

        public static bool ValidName(string name)
        {
            if (shipNames.Contains(name))
            {
                throw new ShipException(Messages.DuplicateShipName);
            }

            shipNames.Add(name);

            return true;
        }
    }
}
