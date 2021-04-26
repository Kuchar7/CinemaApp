using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.DTO
{
    public class AddMovieDTO
    {
        public AddMovieDTO(string title, int length, string imgPath, string desc, List<int> listOfGenresId)
        {
            this.Title = title;
            this.Length = length;
            this.ImgPath = imgPath;
            this.Description = desc;
            this.ListOfGenresId = listOfGenresId;
        }

        public string Title { get; set; }
        public int Length { get; set; }
        public string ImgPath { get; set; }
        public string Description { get; set; }
        public List<int> ListOfGenresId { get; set; }
    }
}
