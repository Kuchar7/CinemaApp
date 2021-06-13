using CinemaApp.DTO;
using CinemaApp.DTO.HelperClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IReservationManageService
    {
        int AddReservation(AddReservationDTO reservationDTO);
        int ChangeStatusToPaid(int reservationId);
    }
}
