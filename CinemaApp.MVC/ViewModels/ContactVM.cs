using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CinemaApp.MVC.ViewModels
{
    public class ContactVM
    {
        [Required(ErrorMessage = "Wymagane podanie adresu e-mail!")]
        [EmailAddress(ErrorMessage ="Nieprawidłowy adres e-mail!")]
        public string UserEmail { get; set; }
        [Required(ErrorMessage = "Treść wiadomości nie może być pusta!")]
        public string Message { get; set; }
    }
}