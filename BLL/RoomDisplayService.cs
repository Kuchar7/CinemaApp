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
    public class RoomDisplayService : IRoomDisplayService
    {
        readonly DatabaseContext dbContext;

        public RoomDisplayService(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IEnumerable<AddScreaningRoomDTO> GetAllRooms()
        {
            List<AddScreaningRoomDTO> listOfRooms = new List<AddScreaningRoomDTO>();
            foreach(var r in dbContext.Rooms)
            {
                listOfRooms.Add(new AddScreaningRoomDTO(r.Id, r.Number));
            }
            return listOfRooms;
        }
    }
}
