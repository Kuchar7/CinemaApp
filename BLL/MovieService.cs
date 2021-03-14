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
    public class MovieService : IMovieService
    {
        private readonly DatabaseContext dbContext;

        public MovieService()
        {
            dbContext = new DatabaseContext();
        }

        public IEnumerable<RecentMovieDTO> GetMoviesDesc(int n)
        {
            IEnumerable<RecentMovieDTO> listOfMovie = dbContext.Movies.OrderByDescending(x => x.AddDateTime).ToArray().Select(x => new RecentMovieDTO
            {
                Id = x.Id,
                Title = x.Title,
                AddDateTime = x.AddDateTime,
                ImgPath = x.ImgPath
            }).Take(n).ToList();
            return (listOfMovie);

        }
    }
}
