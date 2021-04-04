using CinemaApp.MVC.ViewModels.CompositeClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CinemaApp.MVC.ViewModels
{
    public class AddScreeningVM
    {
        [Required(ErrorMessage = "Wymagane wybranie filmu!")]
        public int MovieId { get; set; }
        [Required(ErrorMessage = "Wymagane wybranie sali!")]
        public int RoomId { get; set; }
        [Required(ErrorMessage = "Wymagane podanie daty rozpoczęcia seansu!")]
        [DataType(DataType.DateTime)]
        public DateTime Start { get; set; }
        [Required(ErrorMessage = "Wymagane podanie ceny biletu")]
        [DataType(DataType.Currency)]
        [Range(0.01, 99999999, ErrorMessage ="Cena musi być większa od 0!")]
        public decimal Price { get; set; }
        public List<AddScreeningRoom> listOfRooms { get; set; }
        public List<AddScreeningMovie> listOfMovies { get; set; }

    }
}