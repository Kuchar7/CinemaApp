using CinemaApp.DTO;
using DAL;
using Entities;
using IBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{ 
    public class GenreManageService : IGenreManageService
    {
        readonly DatabaseContext dbContext;

        public GenreManageService(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int AddGenre(AddGenreDTO addGenreDTO)
        {
            Genre genre = new Genre { Name = addGenreDTO.GenreName };
            dbContext.Genres.Add(genre);
            return dbContext.SaveChanges();
        }
    }
}
