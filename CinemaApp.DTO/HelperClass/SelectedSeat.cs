using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.DTO.HelperClass
{
    public class SelectedSeat
    {
        public SelectedSeat(int number, int roomId, int screeningId)
        {
            this.Number = number;
            this.RooomId = roomId;
            this.ScreeningId = screeningId;
        }
        public int Number { get; set; }
        public int RooomId { get; set; }
        public int ScreeningId { get; set; }
    }
}
