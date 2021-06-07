using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.DTO
{
    public class AddRoomDTO
    {
        public AddRoomDTO(int roomNumber, int capacity)
        {
            this.RoomNumber = roomNumber;
            this.Capacity = capacity;
        }
        public int RoomNumber { get; set; }
        public int Capacity { get; set; }
    }
}
