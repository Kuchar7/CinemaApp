using BLL;
using CinemaApp.DTO;
using CinemaApp.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaApp.MVC.Controllers
{
    [Authorize]
    public class ReservationController : Controller
    {
        private readonly IReservationService reservationService;
        public ReservationController(IReservationService reservationService)
        {
            this.reservationService = reservationService;
        }
        // GET: AddReservation
        public ActionResult AddReservation(int id)
        {
            ReservationVM reservationVM = new ReservationVM(reservationService.GetReservationByScreeningId(id));
            reservationVM.UserEmail = User.Identity.Name;
            return View(reservationVM);
        }

        // POST: AddReservation
        [HttpPost]
        public ActionResult AddReservation(int id, int[] selectedSeats)
        {
            ReservationVM reservationVM = new ReservationVM(reservationService.GetReservationByScreeningId(id));
            reservationVM.UserEmail = User.Identity.Name;
            reservationVM.ReservedSeats = reservationService.GetSelectedSeat(selectedSeats, reservationVM.ScreeningId, reservationVM.RoomId);
            ReservationDTO reservationDTO = new ReservationDTO
            {
                UserEmail = reservationVM.UserEmail,
                RoomId = reservationVM.RoomId,
                ReservedSeats = reservationVM.ReservedSeats
            };
            reservationService.AddReservation(reservationDTO);
            
            return Json(Url.Action("Index", "Home"));


        }
    }
}