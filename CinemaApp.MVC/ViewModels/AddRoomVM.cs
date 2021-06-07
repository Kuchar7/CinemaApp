using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CinemaApp.MVC.ViewModels
{
    public class AddRoomVM
    {
        [Required(ErrorMessage = "Wymagane podanie numeru sali!")]
        [Range(1, int.MaxValue, ErrorMessage ="Minimalna wartość dla numeru sali kinowej to {1}")]
        public int RoomNumber { get; set; }
        [Required(ErrorMessage = "Wymagane podanie pojemności sali!")]
        [Range(1, int.MaxValue, ErrorMessage = "Minimalna wartość dla pojemności sali kinowej to {1}")]
        public int Capacity { get; set; }
    }
}