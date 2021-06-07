using CinemaApp.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL
{
    public interface IUserDisplayService
    {
        int GetUserId(string emailAdress);
        UserDetailsDTO GetUserDetails(int serId);
    }
}
