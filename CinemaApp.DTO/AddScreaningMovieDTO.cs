using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.DTO
{
    public class AddScreaningMovieDTO
    {
        public AddScreaningMovieDTO(int id, string title)
        {
            this.Id = id;
            this.Title = title;
        }

        public int Id { get; set; }
        public string Title { get; set; }
    }
}
