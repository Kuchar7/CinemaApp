using BLL;
using CinemaApp.DTO;
using CinemaApp.MVC.ViewModels;
using IBL;
using Stripe;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaApp.MVC.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        readonly IReservationDisplayService reservationDisplayService;
        readonly IReservationManageService reservationManageService;
        readonly IUserDisplayService userDisplayService;
        readonly IUserManageService userManageService;
        readonly IStripePayment stripePayment;
        readonly IStripePaymentValidation stripePaymentValidation;
        public UserController(IReservationDisplayService reservationDisplayService, IUserDisplayService userDisplayService,
            IUserManageService userManageService, IStripePayment stripePayment, IStripePaymentValidation stripePaymentValidation,
            IReservationManageService reservationManageService)
        {
            this.reservationDisplayService = reservationDisplayService;
            this.userDisplayService = userDisplayService;
            this.userManageService = userManageService;
            this.stripePayment = stripePayment;
            this.stripePaymentValidation = stripePaymentValidation;
            this.reservationManageService = reservationManageService;
        }
        // GET: UserReservations
        public ActionResult UserReservations()
        {
            ViewBag.StripePublishKey = ConfigurationManager.AppSettings["stripePublishableKey"];
            List<UserReservationDTO> userReservationDTOs = reservationDisplayService.
                GetAllUserReservations(userDisplayService.GetUserId(User.Identity.Name)).ToList();
            return View(userReservationDTOs);
        }
        // GET: UserDetails
        public ActionResult UserDetails()
        {
            UserDetailsDTO userDetailsDTO = userDisplayService.
                GetUserDetails(userDisplayService.GetUserId(User.Identity.Name));
            return View(userDetailsDTO);
        }

        public ActionResult EditUserData()
        {
            UserDetailsDTO userDetailsDTO = userDisplayService.
                GetUserDetails(userDisplayService.GetUserId(User.Identity.Name));
            EditUserDataVM editUserDataVM = new EditUserDataVM(userDetailsDTO.EmailAddress,
                userDetailsDTO.FirstName, userDetailsDTO.LastName);
            return View(editUserDataVM);
        }

        [HttpPost]
        public ActionResult EditUserData(EditUserDataVM editUserDataVM)
        {
            if (!ModelState.IsValid)
            {
                return View(editUserDataVM);
            }
            else
            {
                userManageService.EditUserData(new EditUserDataDTO(userDisplayService.GetUserId(User.Identity.Name),
                    editUserDataVM.FirstName, editUserDataVM.LastName));
                return RedirectToAction("UserDetails", "User");
            }
           
        }

        [HttpPost]
       
        public ActionResult StripeCharge(string stripeToken, int reservationId)
        {
            Charge charge = stripePayment.CreateCharge(stripeToken, reservationId);
            if (!stripePaymentValidation.IsApproved(charge))
            {
                TempData["Failed"] = "Płatność nie powiodła się!";

            }
            else
            {
                reservationManageService.ChangeStatusToPaid(reservationId);
                TempData["Success"] = "Płatność powiodła się";
                
            }
            return RedirectToAction("UserReservations", "User");
        }
    }
}