using BLL;
using CinemaApp.DTO;
using CinemaApp.MVC.ViewModels;
using IBL;
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
        readonly IReservationManageService reservationManageService;
        readonly IReservationDisplayService reservationDisplayService;
        readonly IReservationValidationService reservationValidationService;
        public ReservationController(IReservationManageService reservationManageService,
            IReservationDisplayService reservationDisplayService, IReservationValidationService reservationValidationService)
        {
            this.reservationManageService = reservationManageService;
            this.reservationDisplayService = reservationDisplayService;
            this.reservationValidationService = reservationValidationService;
        }
        public ReservationController() { }
        // GET: AddReservation
        public ActionResult AddReservation(int id)
        {
            AddReservationVM addReservationVM = new AddReservationVM(reservationDisplayService.GetReservationByScreeningId(id));
            return View(addReservationVM);
        }

        // POST: AddReservation
        [HttpPost]
        public ActionResult AddReservation(AddReservationVM addReservationVM, int id)
        {
            AddReservationDTO reservationInfo = reservationDisplayService.GetReservationByScreeningId(id);
            addReservationVM.UserEmail = User.Identity.Name;
            addReservationVM.Title = reservationInfo.Title;
            addReservationVM.BasicPrice = reservationInfo.BasicPrice;
            addReservationVM.RoomNumber = reservationInfo.RoomNumber;
            addReservationVM.SeatsAmount = reservationInfo.SeatsAmount;
            addReservationVM.Start = reservationInfo.Start;
            addReservationVM.ScreeningId = reservationInfo.ScreeningId;
            addReservationVM.ReservedSeatsList = reservationInfo.ReservedSeatsList;
            addReservationVM.ImgPath = reservationInfo.ImgPath;
            if (!reservationValidationService.IsAvailable(addReservationVM.SelectedSeats, addReservationVM.ScreeningId))
            {
                ModelState.AddModelError("", "Wybrane miejsca są już zajęte!");
                return View(addReservationVM);
            }
            AddReservationDTO addReservationDTO = new AddReservationDTO
            {
                SelectedSeats = addReservationVM.SelectedSeats.ToList(),
                UserEmail = addReservationVM.UserEmail,
                ScreeningId = addReservationVM.ScreeningId,
                BasicPrice = addReservationVM.BasicPrice
            };
            reservationManageService.AddReservation(addReservationDTO);

            return RedirectToAction("Index", "Home");
        }
    }
}