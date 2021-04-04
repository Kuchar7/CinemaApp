using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.DTO
{
    public class AddScreeningDTO
    {
        public AddScreeningDTO(DateTime start, decimal price, int movieId, int roomId)
        {
            this.Start = start;
            this.Price = price;
            this.MovieId = movieId;
            this.RoomId = roomId;
        }
        public DateTime Start { get; set; }
        public decimal Price { get; set; }
        public int MovieId { get; set; }
        public int RoomId { get; set; }
    }
}
