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
    public class UserDisplayService : IUserDisplayService
    {
        readonly DatabaseContext dbContext;
        public UserDisplayService(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public UserDetailsDTO GetUserDetails(int userId)
        {
            //var userDetails = from u in dbContext.Users
            //                  where u.
            UserDetailsDTO userDetailsDTO = dbContext.Users.Where(x => x.Id == userId).
                Select(x => new UserDetailsDTO {EmailAddress = x.EmailAddress, FirstName = x.FirstName, LastName = x.LastName}).FirstOrDefault();

            return userDetailsDTO;
        }

        public int GetUserId(string emailAdress)
        {
            int userId = dbContext.Users.Where(x => x.EmailAddress == emailAdress).Select(x => x.Id).FirstOrDefault();
            return userId;
        }
    }
}
