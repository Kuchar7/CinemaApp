using CinemaApp.DTO.HelperClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.DTO
{
    public class AddReservationDTO
    {
        public string UserEmail { get; set; }
        public string Title { get; set; }
        public string ImgPath { get; set; }
        public int SeatsAmount { get; set; }
        public int ScreeningId { get; set; }
        public DateTime Start { get; set; }
        public decimal BasicPrice { get; set; }
        public List<int> ReservedSeatsList { get; set; }
        public int RoomNumber { get; set; }
        public int RoomId { get; set; }
        public List<int> SelectedSeats { get; set; }

    }
}
