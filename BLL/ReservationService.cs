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
    public class ReservationService : IReservationService
    {
        private readonly DatabaseContext dbContext;

        public ReservationService()
        {
            dbContext = new DatabaseContext();
        }



        public ReservationDTO GetReservationByScreeningId(int screeningId)
        {
            var queryResult = from s in dbContext.Screenings
                              where s.Id == screeningId
                              select new
                              {
                                  title = s.Movie.Title,
                                  roomNumber = s.Room.Number,
                                  seatsCount = s.Room.Capacity,
                                  imgPath = s.Movie.ImgPath,
                                  startDataTime = s.Start,
                                  basicPrice = s.Price,
                                  roomId = s.RoomId
                                  

                              };
            ReservationDTO reservationDTO = new ReservationDTO
            {
                ScreeningId = screeningId,
                Title = queryResult.Select(x => x.title).FirstOrDefault(),
                RoomNumber = queryResult.Select(x => x.roomNumber).FirstOrDefault(),
                SeatsCount = queryResult.Select(x => x.seatsCount).FirstOrDefault(),
                ImgPath = queryResult.Select(x => x.imgPath).FirstOrDefault(),
                Start = queryResult.Select(x => x.startDataTime).FirstOrDefault(),
                BasicPrice = queryResult.Select(x => x.basicPrice).FirstOrDefault(),
                ReservedSeatsList = dbContext.ReservedSeats.Where(x => x.ScreeningId == screeningId).Select(x => x.Number).ToArray(),
                RoomId = queryResult.Select(x => x.roomId).FirstOrDefault()
                
            };

            return (reservationDTO);
        }


        public int AddReservation(ReservationDTO reservationDTO)
        {
            List<ReservedSeat> reservedSeats = new List<ReservedSeat>();
            foreach (var seat in reservationDTO.ReservedSeats)
            {
                reservedSeats.Add(new ReservedSeat{ Number = seat.Number, RoomId = seat.RooomId, ScreeningId = seat.ScreeningId });
            }

            Reservation reservation = new Reservation()
            {
                UserId = dbContext.Users.Where(x => x.EmailAddress == reservationDTO.UserEmail).Select(x => x.Id).FirstOrDefault(),
                ReservedSeats = reservedSeats

            };
            return dbContext.SaveChanges();
        }

        public IEnumerable<SelectedSeat> GetSelectedSeat(int[] selectedSeats, int screeningId, int roomID)
        {
            List<SelectedSeat> seatsList = new List<SelectedSeat>();
            foreach (var seat in selectedSeats)
            {
                seatsList.Add(new SelectedSeat(seat, roomID, screeningId));
            }
            return seatsList;
        }
    }
}
