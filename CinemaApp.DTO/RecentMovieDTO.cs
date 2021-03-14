using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.DTO
{
    public class RecentMovieDTO
    {
        public RecentMovieDTO()
        {

        }
        public RecentMovieDTO(int id, string title, DateTime addDateTime, string imgPath)
        {
            this.Id = id;
            this.Title = title;
            this.AddDateTime = addDateTime;
            this.ImgPath = imgPath;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime AddDateTime { get; set; }
        public string ImgPath { get; set; }

    }
}

