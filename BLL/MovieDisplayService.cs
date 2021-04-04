using CinemaApp.DTO;
using CinemaApp.DTO.HelperClass;
using DAL;
using IBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MovieDisplayService : IMovieDisplayService
    {
        private readonly DatabaseContext dbContext;

        public MovieDisplayService()
        {
            dbContext = new DatabaseContext();
        }

        public IEnumerable<AddScreaningMovieDTO> GetAllMovie()
        {
            List<AddScreaningMovieDTO> listOfMovie = new List<AddScreaningMovieDTO>();
            foreach(var m in dbContext.Movies)
            {
                listOfMovie.Add(new AddScreaningMovieDTO(m.Id, m.Title));
            }
            var sortedListOfMovie = listOfMovie.OrderBy(x => x.Title);
            return sortedListOfMovie;
        }

        public IEnumerable<RecentMovieDTO> GetMovieDesc(int n)
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

        public MovieDetailsDTO GetMovieDetails(int movieId)
        {
            var queryMovies = from m in dbContext.Movies
                              
                              join mG in dbContext.MoviesGenres on m.Id equals mG.MovieId
                              join g in dbContext.Genres on mG.GenreId equals g.Id
                              where (m.Id == movieId)
                              select new { m.Id, m.Title, m.DurationMin, m.Description, m.ImgPath, g.Name};
            var queryScreenings = from s in dbContext.Screenings
                                  where (s.MovieId == movieId) && (s.Start > DateTime.Now)
                                  select new { s.Id, s.Start };


            List<UpcomingScreening> upcomingScreenings = new List<UpcomingScreening>();
            foreach (var s in queryScreenings)
            {
                upcomingScreenings.Add(new UpcomingScreening(s.Id, s.Start));
            }


            MovieDetailsDTO movieDetailsDTO = new MovieDetailsDTO()
            {
                Id = queryMovies.Select(x => x.Id).FirstOrDefault(),
                Description = queryMovies.Select(x => x.Description).FirstOrDefault(),
                DurationMin = queryMovies.Select(x => x.DurationMin).FirstOrDefault(),
                ImgPath = queryMovies.Select(x => x.ImgPath).FirstOrDefault(),
                Title = queryMovies.Select(x => x.Title).FirstOrDefault(),
                Genres = string.Join(", ", queryMovies.Select(x => x.Name).ToList()),
                ListOfUpcomingScreenings = upcomingScreenings.OrderBy(x => x.StartDateTime).ToList()

            };
            return movieDetailsDTO;
            

        }

        public IEnumerable<string> GetMovieTitleByParam(string name)
        {
            var query = from s in dbContext.Screenings
                        where (s.Start >= DateTime.Now)
                        && (s.Movie.Title.StartsWith(name)) 
                        select s.Movie.Title;


            List<string> listOfMovieTitles = new List<string>(query);
            return listOfMovieTitles;
        }




    }
}
