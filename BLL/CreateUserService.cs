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
    public class CreateUserService : ICreateUserService
    {
        private readonly DatabaseContext dbContext;

        public CreateUserService()
        {
            dbContext = new DatabaseContext();
        }
        public int CreateUser(CreateUserDTO createUserDTO)
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
