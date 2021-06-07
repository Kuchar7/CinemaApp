using CinemaApp.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL
{
    public interface IUserManageService
    {
        bool IsAvailableEmailAdress(string emailAdress);
        int AddUser(CreateUserDTO createUserDTO);
        int EditUserData(EditUserDataDTO editUserDataDTO);
    }
}
