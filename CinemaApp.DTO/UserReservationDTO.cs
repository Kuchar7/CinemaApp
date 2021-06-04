using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.DTO
{
    public class UserReservationDTO
    {
        public UserReservationDTO(int id, decimal price, int reservationStatusId,
            string reservationStatusName)
        {
            this.ReservationId = id;
            this.Price = price;
            this.ReservationStatusId = reservationStatusId;
            this.ReservationStatusName = reservationStatusName;
        }
        public int ReservationId { get; set; }
        public decimal Price { get; set; }
        public int ReservationStatusId { get; set;}
        public string ReservationStatusName { get; set; }

    }
}
