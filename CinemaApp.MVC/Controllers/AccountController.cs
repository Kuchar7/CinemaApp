using CinemaApp.DTO;
using CinemaApp.MVC.ViewModels;
using IBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CinemaApp.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserAuthenticationService userAuthentiactionService;
        private readonly ICreateUserService createUserService;

        public AccountController(IUserAuthenticationService userAuthentiactionService, ICreateUserService createUserService)
        {
            this.userAuthentiactionService = userAuthentiactionService;
            this.createUserService = createUserService;
        }


        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        // GET: Account/CreateAccount
        public ActionResult CreateAccount()
        {
            return View();
        }

        // POST: Account/CreateAccount
        [HttpPost]
        public ActionResult CreateAccount(CreateUserVM createUserVM)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateAccount", createUserVM);
            }
            else if (!createUserVM.Password.Equals(createUserVM.ConfirmPassword))
            {
                ModelState.AddModelError("", "Hasła się różnią!");
                return View("CreateAccount", createUserVM);
            }
            else
            {
                CreateUserDTO createUserDTO = new CreateUserDTO
                {
                    FirstName = createUserVM.FirstName,
                    LastName = createUserVM.LastName,
                    EmailAddress = createUserVM.EmailAddress,
                    Password = createUserVM.Password
                };

                createUserService.CreateUser(createUserDTO);
            }
            return View();
        }




        // GET: Account/Login
        public ActionResult Login()
        {
            string userEmailAddress = User.Identity.Name;
            if (!string.IsNullOrEmpty(userEmailAddress))
                return RedirectToAction("Index", "Home");
            return View();
        }
        // POST: Account/Login
        [HttpPost]
        public ActionResult Login (UserLoginVM userLoginVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else if (userAuthentiactionService.IsRegister(userLoginVM.EmailAddress, userLoginVM.Password))
            {
                FormsAuthentication.SetAuthCookie(userLoginVM.EmailAddress, userLoginVM.RememberMe);
                TempData["SM"] = "Witaj!";
                return Redirect(FormsAuthentication.GetRedirectUrl(userLoginVM.EmailAddress, userLoginVM.RememberMe));
            }
            else
            {
                ModelState.AddModelError("", "Nieprawidłowy adres E-mail lub hasło");
                return View();
            }
        }
        // GET: Account/Logout
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}