using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.DTO
{
    public class EditUserDataDTO
    {
        public EditUserDataDTO(int userId, string userFirstName, string userLastName)
        {
            this.UserId = userId;
            this.UserFirstName = userFirstName;
            this.UserLastName = userLastName;
        }
        public int UserId { get; private set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
    }
}
