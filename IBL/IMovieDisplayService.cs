using CinemaApp.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL
{
    public interface IMovieDisplayService
    {
        IEnumerable<RecentMovieDTO> GetMovieDesc(int n);
        IEnumerable<string> GetMovieTitleByParam(string name);
        MovieDetailsDTO GetMovieDetails(int movieId);
        IEnumerable<AddScreaningMovieDTO> GetAllMovie();
        int GetMovieLengthById(int movieId);
        
    }
}
