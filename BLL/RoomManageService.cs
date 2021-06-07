using CinemaApp.DTO;
using DAL;
using Entities;
using IBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RoomManageService : IRoomManageService
    {
        readonly DatabaseContext dbContext;

        public RoomManageService(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int AddRoom(AddRoomDTO addRoomDTO)
        {
            Room room = new Room { Number = addRoomDTO.RoomNumber, Capacity = addRoomDTO.Capacity };
            dbContext.Rooms.Add(room);
            return dbContext.SaveChanges();
        }
    }
}
