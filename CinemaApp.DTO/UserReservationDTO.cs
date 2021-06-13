using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.DTO
{
    public class UserReservationDTO
    {
        public UserReservationDTO(int reservationId, string movieTitle, DateTime startDateTime,
            decimal fullPrice, string seatNumbers, int statusId, int roomNumber)
        {
            this.ReservationId = reservationId;
            this.MovieTitle = movieTitle;
            this.StartDateTime = startDateTime;
            this.FullPrice = fullPrice;
            this.SeatNumbers = seatNumbers;
            this.StatusId = statusId;
            this.RoomNumber = roomNumber;
            this.FullPriceCents = (fullPrice * 100);
        }
        public int ReservationId { get; set; }
        public string MovieTitle { get; set; }
        public DateTime StartDateTime { get; set; }
        public int RoomNumber { get; set; }
        public decimal FullPrice { get; set; }
        public string SeatNumbers { get; set; }
        public int StatusId { get; set; }
        public decimal FullPriceCents { get; }



    }
}
