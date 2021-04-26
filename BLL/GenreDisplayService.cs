using CinemaApp.DTO;
using DAL;
using IBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class GenreDisplayService : IGenreDisplayService
    {
        readonly DatabaseContext dbContext;
        public GenreDisplayService(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IEnumerable<GenreDTO> GetAllGenres()
        {
            List<GenreDTO> listOfGenres = new List<GenreDTO>();
            foreach(var g in dbContext.Genres)
            {
                listOfGenres.Add(new GenreDTO(g.Id, g.Name));
            }
            return listOfGenres;
        }
    }
}
