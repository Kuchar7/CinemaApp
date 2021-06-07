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
    public class UserController : Controller
    {
        readonly IReservationDisplayService reservationDisplayService;
        readonly IUserDisplayService userDisplayService;
        readonly IUserManageService userManageService;
        public UserController(IReservationDisplayService reservationDisplayService, IUserDisplayService userDisplayService,
            IUserManageService userManageService)
        {
            this.reservationDisplayService = reservationDisplayService;
            this.userDisplayService = userDisplayService;
            this.userManageService = userManageService;
        }
        // GET: UserReservations
        public ActionResult UserReservations()
        {
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


    }
}