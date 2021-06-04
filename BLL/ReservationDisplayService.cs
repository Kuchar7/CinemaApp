using CinemaApp.DTO;
using DAL;
using IBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ReservationDisplayService : IReservationDisplayService
    {
        readonly DatabaseContext dbContext;
        public ReservationDisplayService(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IEnumerable<UserReservationDTO> GetAllUserReservations(int userId)
        {
            var queryResult = from r in dbContext.Reservations
                              where r.UserId == userId
                              //from m in dbContext.
                              select new
                              {
                                  r.Id,
                                  ReservationStatusId = r.ReservationStatus.Id,
                                  ReservationStatusName = r.ReservationStatus.Name,
                                  Price = r.Price,
                                  RoomNumber = r.Screening.Room.Number,
                                  MovieTitle = r.Screening.Movie.Title,
                                  r.Screening.Start
                              };
            List<UserReservationDTO> userReservationDTOs = new List<UserReservationDTO>();
            foreach (var r in queryResult)
            {
                userReservationDTOs.Add(new UserReservationDTO(r.Id, r.Price, r.ReservationStatusId,
                    r.ReservationStatusName));
            }
            return userReservationDTOs;

        }

        public AddReservationDTO GetReservationByScreeningId(int screeningId)
        {
            var reservationQueryResult = from s in dbContext.Screenings
                              where s.Id == screeningId
                              select new
                              {
                                  title = s.Movie.Title,
                                  roomNumber = s.Room.Number,
                                  seatAmount = s.Room.Capacity,
                                  imgPath = s.Movie.ImgPath,
                                  startDataTime = s.Start,
                                  basicPrice = s.BasicPrice,
                                  roomId = s.RoomId,
                              };

            AddReservationDTO reservationDTO = new AddReservationDTO
            {
                ScreeningId = screeningId,
                Title = reservationQueryResult.Select(x => x.title).FirstOrDefault(),
                RoomNumber = reservationQueryResult.Select(x => x.roomNumber).FirstOrDefault(),
                SeatsAmount = reservationQueryResult.Select(x => x.seatAmount).FirstOrDefault(),
                ImgPath = reservationQueryResult.Select(x => x.imgPath).FirstOrDefault(),
                Start = reservationQueryResult.Select(x => x.startDataTime).FirstOrDefault(),
                BasicPrice = reservationQueryResult.Select(x => x.basicPrice).FirstOrDefault(),
                ReservedSeatsList = dbContext.ReservedSeats.Where(x => x.Reservation.ScreeningId == screeningId).Select(x => x.Number).ToList(),
                RoomId = reservationQueryResult.Select(x => x.roomId).FirstOrDefault(),
               
            };

            return (reservationDTO);
        }
    }
}
