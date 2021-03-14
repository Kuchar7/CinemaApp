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
        public HomeController(IMovieService movieService)
        {
            this.movieService = movieService;
        }
        public ActionResult Index()
        {
            var moviesListDesc = movieService.GetMoviesDesc(6);
            return View(moviesListDesc);
        }

    }
}