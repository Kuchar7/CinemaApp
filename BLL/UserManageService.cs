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
    public class UserManageService : IUserManageService
    {
        private readonly DatabaseContext dbContext;

        public UserManageService()
        {
            dbContext = new DatabaseContext();
        }
        public int AddUser(CreateUserDTO createUserDTO)
        {
            User user = new User
            {
                FirstName = createUserDTO.FirstName,
                LastName = createUserDTO.LastName,
                EmailAddress = createUserDTO.EmailAddress,
                Password = createUserDTO.Password
            };
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
            UserRole userRole = new UserRole
            {
                UserId = user.Id,
                RoleId = 2
            };
            return dbContext.SaveChanges();
        }

        public int EditUserData(EditUserDataDTO editUserDataDTO)
        {
            var user = dbContext.Users.First(x => x.Id == editUserDataDTO.UserId);
            user.FirstName = editUserDataDTO.UserFirstName;
            user.LastName = editUserDataDTO.UserLastName;
            return dbContext.SaveChanges();
        }

        public bool IsAvailableEmailAdress(string emailAdress)
        {
            if (dbContext.Users.Any(x => x.EmailAddress.Equals(emailAdress)))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
