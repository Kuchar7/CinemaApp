using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.DTO
{
    public class AddGenreDTO
    {
        public AddGenreDTO(string genreName)
        {
            this.GenreName = genreName;
        }
        public string GenreName { get; set; }
    }
}
