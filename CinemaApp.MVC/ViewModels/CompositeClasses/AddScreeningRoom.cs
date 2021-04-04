using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaApp.MVC.ViewModels.CompositeClass
{
    public class AddScreeningRoom
    {
        public AddScreeningRoom(int id, int number)
        {
            this.Id = id;
            this.Number = number;
        }
        public int Id { get; set; }
        public int Number { get; set; }
    }
}