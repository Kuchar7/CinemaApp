using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CinemaApp.MVC.ViewModels
{
    public class EditUserDataVM
    {
        public EditUserDataVM() { }
        public EditUserDataVM(string emailAddress, string firstName, string lastName)
        {
            this.EmailAddress = emailAddress;
            this.FirstName = firstName;
            this.LastName = lastName;
        }
        public string EmailAddress { get; private set; }
        [DisplayName("Imię")]
        [Required(ErrorMessage = "Wymagane podanie imienia!")]
        [MaxLength(100, ErrorMessage = "Maksymalna długość imienia to 100 znaków!")]
        public string FirstName { get; set; }
        [DisplayName("Nazwisko")]
        [Required(ErrorMessage = "Wymagane podanie nazwiska!")]
        [MaxLength(100, ErrorMessage = "Maksymalna długość nazwiska to 100 znaków!")]
        public string LastName { get; set; }
    }
}