using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.DTO.HelperClass
{
    public class UpcomingScreening
    {
        public UpcomingScreening(int id, DateTime startDateTime)
        {
            this.ScreeningId = id;
            this.StartDateTime = startDateTime;
        }
        public int ScreeningId { get; set; }
        public DateTime StartDateTime { get; set; }
    }
}
