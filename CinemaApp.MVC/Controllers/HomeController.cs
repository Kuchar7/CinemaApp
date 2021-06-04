using CinemaApp.DTO;
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

        public ActionResult GetScreenings()
        {
            return View();
        }

        public JsonResult GetMovieTitle(string term)
        {
            IEnumerable<string> listOfMovieTitles = movieDisplayService.GetMovieTitleByParam(term);
            return Json(listOfMovieTitles, JsonRequestBehavior.AllowGet);
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

    }
}