using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CinemaApp.MVC.ViewModels
{
    public class AddGenreVM
    {
        [Required(ErrorMessage = "Wymagane podanie nazwy gatunku filmowego!")]
        [StringLength(50, ErrorMessage = "Maksmalna długość nazwy gatunku filmowego wynosi {0}")]
        public string Name { get; set; }
    }
}