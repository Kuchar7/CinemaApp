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
        private readonly IMovieService movieService;
        private readonly IScreeningDisplayService screeningDisplayService;
        public HomeController(IMovieService movieService, IScreeningDisplayService screeningDisplayService)
        {
            this.movieService = movieService;
            this.screeningDisplayService = screeningDisplayService;
        }

        //GET Home/Index
        public ActionResult Index()
        {
            var moviesListDesc = movieService.GetMovieDesc(6);
            return View(moviesListDesc);
        }

        public ActionResult GetMovieDetails(int id)
        {

            return View(movieService.GetMovieDetails(id));
        }

        public ActionResult GetScreenings()
        {
            return View();
        }

        public JsonResult GetMovieTitle(string term)
        {
            IEnumerable<string> listOfMovieTitles = movieService.GetMovieTitleByParam(term);
            return Json(listOfMovieTitles, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetScreenings(string starteDateTime, string endDateTime, string movieTitle)
        {
            List<ScreeningDisplayDTO> screeningsList = new List<ScreeningDisplayDTO>();
            if (String.IsNullOrEmpty(movieTitle))
            {
                screeningsList = screeningDisplayService.GetScreeningByParametr(starteDateTime, endDateTime).ToList();
            }
            else
            {
                screeningsList = screeningDisplayService.GetScreeningByParametr(starteDateTime, endDateTime, movieTitle).ToList();

            }
            return PartialView("_ScreeningListPartial", screeningsList);

        }

    }
}