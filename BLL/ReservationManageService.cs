using CinemaApp.DTO;
using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaApp.DTO.HelperClass;

namespace BLL
{
    public class ReservationManageService : IReservationManageService
    {
        private readonly DatabaseContext dbContext;

        public ReservationManageService()
        {
            dbContext = new DatabaseContext();
        }


        public int AddReservation(AddReservationDTO addReservationDTO)
        {
            List<ReservedSeat> selectedSeats = new List<ReservedSeat>();
            foreach (var s in addReservationDTO.SelectedSeats)
            {
                selectedSeats.Add(new ReservedSeat { Number = s});
            }

            Reservation reservation = new Reservation()
            {
                UserId = dbContext.Users.Where(x => x.EmailAddress == addReservationDTO.UserEmail).Select(x => x.Id).FirstOrDefault(),
                ReservedSeats = selectedSeats,
                StatusId = 2,
                ScreeningId = addReservationDTO.ScreeningId,
                Price = selectedSeats.Count * addReservationDTO.BasicPrice

            };
            dbContext.Reservations.Add(reservation);
            return dbContext.SaveChanges();
        }

        //public IEnumerable<SelectedSeat> GetSelectedSeat(int[] selectedSeats, int screeningId, int roomID)
        //{
        //    List<SelectedSeat> seatsList = new List<SelectedSeat>();
        //    foreach (var seat in selectedSeats)
        //    {
        //        seatsList.Add(new SelectedSeat(seat, roomID, screeningId));
        //    }
        //    return seatsList;
        //}
    }
}
