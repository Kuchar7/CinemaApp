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
    public class ScreeningDisplayService : IScreeningDisplayService
    {
        private readonly DatabaseContext dbContext;
        public ScreeningDisplayService(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<ScreeningDisplayDTO> GetScreening(string startDT, string endDT)
        {
            DateTime starteDateTime = Convert.ToDateTime(startDT);
            DateTime endDateTime = Convert.ToDateTime(endDT);

            var query = from s in dbContext.Screenings
                        where s.Start >= starteDateTime && s.Start <= endDateTime
                        orderby s.Start
                        select new
                        {
                            screeningId = s.Id,
                            start = s.Start,
                            roomNumber = s.Room.Number,
                            movieTitle = s.Movie.Title,
                            imgPath = s.Movie.ImgPath
                        };
            List<ScreeningDisplayDTO> listScreeningDisplayDTO = new List<ScreeningDisplayDTO>();
            foreach(var s in query)
            {
                listScreeningDisplayDTO.Add(new ScreeningDisplayDTO
                {
                    Id = s.screeningId,
                    ImgPath = s.imgPath,
                    MovieTitle = s.movieTitle,
                    Start = s.start,
                    RoomNumber = s.roomNumber
                });
            }
            return listScreeningDisplayDTO;
        }

        public IEnumerable<ScreeningDisplayDTO> GetScreening(string startDT, string endDT, string movieTitle)
        {
            DateTime starteDateTime = Convert.ToDateTime(startDT);
            DateTime endDateTime = Convert.ToDateTime(endDT);

            var query = from s in dbContext.Screenings
                        where s.Movie.Title == movieTitle && s.Start >= starteDateTime && s.Start <= endDateTime
                        orderby s.Start
                        select new
                        {
                            screeningId = s.Id,
                            start = s.Start,
                            roomNumber = s.Room.Number,
                            movieTitle = s.Movie.Title,
                            imgPath = s.Movie.ImgPath
                        };
            List<ScreeningDisplayDTO> listScreeningDisplayDTO = new List<ScreeningDisplayDTO>();
            foreach (var s in query)
            {
                listScreeningDisplayDTO.Add(new ScreeningDisplayDTO
                {
                    Id = s.screeningId,
                    ImgPath = s.imgPath,
                    MovieTitle = s.movieTitle,
                    Start = s.start,
                    RoomNumber = s.roomNumber
                });
            }
            return listScreeningDisplayDTO;
        }

        public IEnumerable<ScreeningDisplayDTO> GetScreening(DateTime starteDateTime, DateTime endDateTime)
        {
            var query = from s in dbContext.Screenings
                        where s.Start >= starteDateTime && s.Start <= endDateTime
                        orderby s.Start
                        select new
                        {
                            screeningId = s.Id,
                            start = s.Start,
                            roomNumber = s.Room.Number,
                            movieTitle = s.Movie.Title,
                            imgPath = s.Movie.ImgPath
                        };
            List<ScreeningDisplayDTO> listScreeningDisplayDTO = new List<ScreeningDisplayDTO>();
            foreach (var s in query)
            {
                listScreeningDisplayDTO.Add(new ScreeningDisplayDTO
                {
                    Id = s.screeningId,
                    ImgPath = s.imgPath,
                    MovieTitle = s.movieTitle,
                    Start = s.start,
                    RoomNumber = s.roomNumber
                });
            }
            return listScreeningDisplayDTO;
        }
    }
}
