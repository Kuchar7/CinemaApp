using DAL;
using IBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ReservationValidationService : IReservationValidationService
    {
        readonly DatabaseContext dbContext;
        public ReservationValidationService(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool IsScreeningAvailable(int screeningId)
        {
            bool screeningAvailability = dbContext.Screenings.Where(x => x.Id == screeningId).Any(x => x.Start > DateTime.Now);

            return screeningAvailability;
        }

        public bool IsSeatsAvailable(IEnumerable<int> selectedSeats, int screeningId)
        {
            List<int> reservedSeats = dbContext.ReservedSeats.Where(x => x.Reservation.ScreeningId == screeningId).Select(x => x.Number).ToList();

            foreach (var s in selectedSeats)
            {
                if (reservedSeats.Contains(s))
                {
                    return false;
                }

            }
            return true;
        }
    }
}
