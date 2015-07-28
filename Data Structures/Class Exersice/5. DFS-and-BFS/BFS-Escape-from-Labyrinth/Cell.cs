using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escape_from_Labyrinth
{
    public class Cell
    {
        public int X { get; set; }

        public int Y { get; set; }

        public string Direction { get; set; }

        public Cell PreviusCell { get; set; }
    }
}
