using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL
{
    public interface IUserAuthenticationService
    {

       
        bool IsRegister(string userEmailAddress, string userPassword);
    }
}
