using CinemaApp.DTO.HelperClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.DTO
{
    public class MovieDetailsDTO
    {
        public MovieDetailsDTO()
        {
        }

        public MovieDetailsDTO(int id, string title, int durationTime, string description, string imgPath, string genres, List<UpcomingScreening> listOfUpcomingScreenings)
        {
            this.Id = id;
            this.Title = title;
            this.DurationMin = durationTime;
            this.Description = description;
            this.ImgPath = imgPath;
            this.Genres = genres;
            this.ListOfUpcomingScreenings = listOfUpcomingScreenings;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public int DurationMin { get; set; }
        public string Description { get; set; }
        public string ImgPath { get; set; }
        public string Genres { get; set; }
        public List<UpcomingScreening> ListOfUpcomingScreenings { get; set; }
    }
}
