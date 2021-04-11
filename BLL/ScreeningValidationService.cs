using DAL;
using IBL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ScreeningValidationService : IScreeningValidationService
    {
        readonly DatabaseContext dbContext;
       public ScreeningValidationService(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool IsRoomUnavailable(DateTime startDateTime, int roomId, int movieLength)
        {
            DateTime roomUnavailableStart = startDateTime.Add(new TimeSpan(0, -15, 0));
            DateTime roomUnavailableEnd = startDateTime.Add(new TimeSpan(0, (15 + movieLength), 0));
            var queryResult = (from s in dbContext.Screenings
                               where ((s.RoomId == roomId) && (s.Start >= roomUnavailableEnd))
                               || (((DbFunctions.AddMinutes(s.Start, s.Movie.DurationMin)) >= roomUnavailableStart) && (s.RoomId == roomId))
                               select s).Any();
            return queryResult;

        }
    }
}