using CinemaApp.DTO;
using CinemaApp.DTO.HelperClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaApp.MVC.ViewModels
{
    public class ReservationVM
    {
        public ReservationVM(ReservationDTO reservationDTO)
        {
            this.Title = reservationDTO.Title;
            this.ImgPath = reservationDTO.ImgPath;
            this.SeatsCount = reservationDTO.SeatsCount;
            this.ScreeningId = reservationDTO.ScreeningId;
            this.Start = reservationDTO.Start;
            this.BasicPrice = reservationDTO.BasicPrice;
            this.ReservedSeatsList = reservationDTO.ReservedSeatsList;
            this.RoomNumber = reservationDTO.RoomNumber;
            this.RoomId = reservationDTO.RoomId;
            this.ReservedSeats = reservationDTO.ReservedSeats;
        }

        public string UserEmail { get; set; }
        public string Title { get; set; }
        public string ImgPath { get; set; }
        public int SeatsCount { get; set; }
        public int ScreeningId { get; set; }
        public DateTime Start { get; set; }
        public decimal BasicPrice { get; set; }
        public IEnumerable<int> ReservedSeatsList { get; set; }
        public int RoomNumber { get; set; }
        public int RoomId { get; set; }
        public IEnumerable<SelectedSeat> ReservedSeats { get; set; }
    }
}