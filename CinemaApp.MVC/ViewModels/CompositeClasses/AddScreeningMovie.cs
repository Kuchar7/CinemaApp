using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaApp.MVC.ViewModels.CompositeClass
{
    public class AddScreeningMovie
    {
        public AddScreeningMovie(int id, string title, int length)
        {
            this.Id = id;
            this.Title = title;
            this.Length = length;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int Length { get; set; }
        public string TitleMovieLength
        {
            get { return this.Title + " (" + this.Length.ToString() + " min.)"; }
        }
    }
}
