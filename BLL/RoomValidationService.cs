using DAL;
using IBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RoomValidationService : IRoomValidationService
    {
        DatabaseContext dbContext;

        public RoomValidationService(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool IsRoomNumberExist(int roomNumber)
        {
            bool isRoomNumberExist = dbContext.Rooms.Any(x => x.Number == roomNumber);
            return isRoomNumberExist;
        }
    }
}
