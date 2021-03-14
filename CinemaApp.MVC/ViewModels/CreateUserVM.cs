using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CinemaApp.MVC.ViewModels
{
    public class CreateUserVM
    {
        [Required(ErrorMessage = "Wymagane podanie adresu E-mail!")]
        [DisplayName("Adres E-mail")]
        [MaxLength(255, ErrorMessage = "Maksymalna długość adresu e-mail to 255 znaków!")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        [DisplayName("Imię")]
        [Required(ErrorMessage = "Wymagane podanie imienia!")]
        [MaxLength(100, ErrorMessage = "Maksymalna długość imienia to 100 znaków!")]
        public string FirstName { get; set; }
        [DisplayName("Nazwisko")]
        [Required(ErrorMessage = "Wymagane podanie nazwiska!")]
        [MaxLength(100, ErrorMessage = "Maksymalna długość nazwiska to 100 znaków!")]
        public string LastName { get; set; }
        [DisplayName("Hasło")]
        [Required(ErrorMessage = "Wymagane podanie hasła!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DisplayName("Potwierdzenie hasła")]
        [Required(ErrorMessage = "Wymagane potwierdzenie hasła!")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
