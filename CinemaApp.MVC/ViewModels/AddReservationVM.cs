using CinemaApp.DTO;
using CinemaApp.DTO.HelperClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaApp.MVC.ViewModels
{
    public class AddReservationVM
    {
        public AddReservationVM() { }
        public AddReservationVM(AddReservationDTO addReservationDTO)
        {
            this.Title = addReservationDTO.Title;
            this.ImgPath = addReservationDTO.ImgPath;
            this.SeatsAmount = addReservationDTO.SeatsAmount;
            this.Start = addReservationDTO.Start;
            this.BasicPrice = addReservationDTO.BasicPrice;
            this.ReservedSeatsList = addReservationDTO.ReservedSeatsList;
            this.RoomNumber = addReservationDTO.RoomNumber;
            this.ScreeningId = addReservationDTO.ScreeningId;
        }
        public int Id { get; set; }
        public string UserEmail { get; set; }
        public string Title { get; set; }
        public string ImgPath { get; set; }
        public int SeatsAmount { get; set; }
        public int ScreeningId { get; set; }
        public DateTime Start { get; set; }
        public decimal BasicPrice { get; set; }
        public List<int> ReservedSeatsList { get; set; }
        public int RoomNumber { get; set; }
        //public int RoomId { get; set; }
        public int[] SelectedSeats { get; set; }
    }
}