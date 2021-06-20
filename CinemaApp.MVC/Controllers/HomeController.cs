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
    public class HomeController : Controller
    {
        private readonly IMovieDisplayService movieDisplayService;
        private readonly IScreeningDisplayService screeningDisplayService;
        public HomeController(IMovieDisplayService movieDisplayService, IScreeningDisplayService screeningDisplayService)
        {
            this.movieDisplayService = movieDisplayService;
            this.screeningDisplayService = screeningDisplayService;
        }
        public HomeController() { }

        //GET Home/Index
        public ActionResult Index()
        {
            var moviesListDesc = movieDisplayService.GetMovieDesc(6);
            return View(moviesListDesc);
        }

        public ActionResult GetMovieDetails(int id)
        {

            return View(movieDisplayService.GetMovieDetails(id));
        }

  
        public JsonResult GetMovieTitle(string term)
        {
            IEnumerable<string> listOfMovieTitles = movieDisplayService.GetMovieTitleByParam(term);
            return Json(listOfMovieTitles, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetScreenings()
        {
            List<ScreeningDisplayDTO> screeningsList = new List<ScreeningDisplayDTO>(screeningDisplayService.GetScreening(DateTime.Now, DateTime.Now.AddHours(24)));


            return View(screeningsList);
        }


        [HttpPost]
        public ActionResult GetScreenings(string starteDateTime, string endDateTime, string movieTitle)
        {
            List<ScreeningDisplayDTO> screeningsList = new List<ScreeningDisplayDTO>();
            if (String.IsNullOrEmpty(movieTitle))
            {
                screeningsList = screeningDisplayService.GetScreening(starteDateTime, endDateTime).ToList();
            }
            else
            {
                screeningsList = screeningDisplayService.GetScreening(starteDateTime, endDateTime, movieTitle).ToList();

            }
            return PartialView("_ScreeningListPartial", screeningsList);

        }
        public ActionResult AboutUs()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contact(ContactVM contactVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            TempData["Success"] = "Wiadomość została wysłana";
            return RedirectToAction("Contact");
        }

    }
}