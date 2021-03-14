using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CinemaApp.MVC.ViewModels
{
    public class UserLoginVM
    {
        [Required(ErrorMessage = "Wymagane podanie adresu E-mail!")]
        [DisplayName("Adres E-mail")]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "Wymagane podanie hasła!")]
        [DisplayName("Hasło")]
        public string Password { get; set; }
        [DisplayName("Zapamiętaj")]
        public bool RememberMe { get; set; }
    }
}