using CinemaApp.DTO;
using CinemaApp.MVC.ViewModels;
using CinemaApp.MVC.ViewModels.CompositeClass;
using IBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaApp.MVC.Controllers
{
    public class AdminController : Controller
    {
        readonly IScreeningManageService screeningManageService;
        readonly IRoomDisplayService roomDisplayService;
        readonly IMovieDisplayService movieDisplayService;
        public AdminController(IScreeningManageService screeningManageService, IRoomDisplayService roomManageService,
            IMovieDisplayService movieDisplayService)
        {
            this.screeningManageService = screeningManageService;
            this.roomDisplayService = roomManageService;
            this.movieDisplayService = movieDisplayService;
        }

        [Authorize(Roles = "Admin")]
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddScreening()
        {
            AddScreeningVM addScreeningVM = new AddScreeningVM
            {
                listOfMovies = movieDisplayService.GetAllMovie().ToList().ConvertAll(x => new AddScreeningMovie (x.Id, x.Title)),
                listOfRooms = roomDisplayService.GetAllRooms().ToList().ConvertAll(x => new AddScreeningRoom (x.Id, x.Number))
            };
            return View(addScreeningVM);
        }

        [HttpPost]
        public ActionResult AddScreening(AddScreeningVM addScreeningVM)
        {
            if (ModelState.IsValid)
            {
                AddScreeningDTO addScreeningDTO = new AddScreeningDTO(addScreeningVM.Start, addScreeningVM.Price,
                    addScreeningVM.MovieId, addScreeningVM.RoomId);
                screeningManageService.AddScreening(addScreeningDTO);
                RedirectToAction("AddScreening");
            }
            addScreeningVM.listOfMovies = movieDisplayService.GetAllMovie().ToList().ConvertAll(x => new AddScreeningMovie(x.Id, x.Title));
            addScreeningVM.listOfRooms = roomDisplayService.GetAllRooms().ToList().ConvertAll(x => new AddScreeningRoom(x.Id, x.Number));
            return View(addScreeningVM);
        }
    }
}