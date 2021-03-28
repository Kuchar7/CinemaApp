using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.DTO
{
    public class ScreeningDisplayDTO
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public string MovieTitle { get; set; }
        public int RoomNumber { get; set; }
        public string ImgPath { get; set; }
    }
}
