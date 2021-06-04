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
    public class MovieManageService : IMovieManageService
    {
        readonly DatabaseContext dbContext;
        public MovieManageService(DatabaseContext databaseContext)
        {
            this.dbContext = databaseContext;
        }

        public AddMovieDTO AddMovieDTO
        {
            get => default;
            set
            {
            }
        }

        public int AddMovie(AddMovieDTO addMovieDTO)
        {
            Movie movie = new Movie
            {
                Title = addMovieDTO.Title,
                LengthMin = addMovieDTO.Length,
                Description = addMovieDTO.Description,
                ImgPath = addMovieDTO.ImgPath,
                AddDateTime = DateTime.Now
            };
            dbContext.Movies.Add(movie);

            foreach (var g in addMovieDTO.ListOfGenresId)
            {
                dbContext.MoviesGenres.Add(new MovieGenre { Movie = movie, GenreId = g });
            }
            return dbContext.SaveChanges();
        }
    }
}
