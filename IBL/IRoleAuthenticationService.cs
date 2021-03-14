using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL
{
    public interface IRoleAuthenticationService
    {
        int GetUserIdByIdentityName(string identityName);
        string[] GetUserRolesById(int id);
    }
}
