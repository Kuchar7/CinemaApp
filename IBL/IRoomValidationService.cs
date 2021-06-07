using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL
{
    public interface IRoomValidationService
    {
        bool IsRoomNumberExist(int roomNumber);
    }
}
