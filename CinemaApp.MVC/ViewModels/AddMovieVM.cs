using CinemaApp.MVC.ViewModels.CompositeClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CinemaApp.MVC.ViewModels
{
    public class AddMovieVM
    {
        [Required(ErrorMessage = "Wymaagane podanie tytułu!")]
        [MaxLength(60, ErrorMessage = "Tytuł może mieć maksymalnie {1} znaków!")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Wymaagane podanie długości filmu!")]
        public int Length { get; set; }
        public string ImgPath { get; set; }
        [Required(ErrorMessage = "Wymagane podanie opisu filmu!")]
        [MaxLength(250, ErrorMessage = "Opis filmu może mieć maksymalnie {1} znaków!")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Wymagane podanie conajmniej jednego gatunku filmowego!")]
        public List<int> SelectedGenresId { get; set; }

        public List<Genre> ListOfGenres { get; set; }
        [Required(ErrorMessage ="Wymagane dodanie zdjęcia!")]
        public HttpPostedFileBase Image { get; set; }
    }
}