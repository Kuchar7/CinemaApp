using DAL;
using IBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        private readonly DatabaseContext dbContext;
        public UserAuthenticationService(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool IsRegister(string userEmailAddress, string userPassword)
        {
            if (dbContext.Users.Any(x => x.EmailAddress.Equals(userEmailAddress)
                 && x.Password.Equals(userPassword)))
                return true;
            else
                return false;
        }
    }
}
