using CinemaApp.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL
{
    public interface IReservationDisplayService
    {
        IEnumerable<UserReservationDTO> GetAllUserReservations(int userId);
        AddReservationDTO GetReservationByScreeningId(int screeningId);
    }
}
