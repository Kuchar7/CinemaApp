﻿using CinemaApp.DTO;
using CinemaApp.DTO.HelperClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IReservationService
    {
        ReservationDTO GetReservationByScreeningId(int screeningId);
        int AddReservation(ReservationDTO reservationDTO);
        IEnumerable<SelectedSeat> GetSelectedSeat(int[] selectedSeats, int screeningId, int roomID);
    }
}
