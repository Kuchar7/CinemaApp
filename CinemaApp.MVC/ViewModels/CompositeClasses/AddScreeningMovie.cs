using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaApp.MVC.ViewModels.CompositeClass
{
    public class AddScreeningMovie
    {
        public AddScreeningMovie(int id, string title)
        {
            this.Id = id;
            this.Title = title;
        }

        public int Id { get; set; }
        public string Title { get; set; }
    }
}
