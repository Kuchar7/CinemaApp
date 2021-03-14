using DAL;
using IBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RoleAuthenticationService : IRoleAuthenticationService
    {
        private readonly DatabaseContext dbContext;


        public RoleAuthenticationService()
        {
            dbContext = new DatabaseContext();
        }

        public int GetUserIdByIdentityName(string identityName)
        {
            int id = dbContext.Users.Where(x => x.EmailAddress == identityName).Select(x => x.Id).FirstOrDefault();
            return id;
           
        }

        public string[] GetUserRolesById(int id)
        {
            string[] roles = dbContext.Roles.Where(x => x.Id == id).Select(x => x.Name).ToArray();
            return roles;
        }
    }
}
