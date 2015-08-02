using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.CodeFirstMovies.Models
{
    class JsonUsersFavMovies
    {
        public string username { get; set; }

        public string[] FavouriteMovies { get; set; }
    }
}
