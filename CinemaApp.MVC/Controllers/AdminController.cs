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
        readonly IScreeningValidationService screeningValidationService;
        public AdminController(IScreeningManageService screeningManageService, IRoomDisplayService roomDisplayService,
            IMovieDisplayService movieDisplayService, IScreeningValidationService screeningValidationService)
        {
            this.screeningManageService = screeningManageService;
            this.roomDisplayService = roomDisplayService;
            this.movieDisplayService = movieDisplayService;
            this.screeningValidationService = screeningValidationService;
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
                listOfMovies = movieDisplayService.GetAllMovie().ToList().ConvertAll(x => new AddScreeningMovie (x.Id, x.Title, x.Length)),
                listOfRooms = roomDisplayService.GetAllRooms().ToList().ConvertAll(x => new AddScreeningRoom (x.Id, x.Number))
            };
            return View(addScreeningVM);
        }

        [HttpPost]
        public ActionResult AddScreening(AddScreeningVM addScreeningVM)
        {
            addScreeningVM.listOfMovies = movieDisplayService.GetAllMovie().ToList().ConvertAll(x => new AddScreeningMovie(x.Id, x.Title, x.Length));
            addScreeningVM.listOfRooms = roomDisplayService.GetAllRooms().ToList().ConvertAll(x => new AddScreeningRoom(x.Id, x.Number));
            addScreeningVM.MovieLength = movieDisplayService.GetMovieLengthById(addScreeningVM.MovieId);
            if (!ModelState.IsValid)
            {       
                return View(addScreeningVM);          
            }
            if (screeningValidationService.IsRoomUnavailable(addScreeningVM.Start, addScreeningVM.RoomId, addScreeningVM.MovieLength)){
                ModelState.AddModelError("", "Nieprawidłowa data rozpoczęcia seansu. Zachowana musi zostać 15 minutowa przerwa między seansami!");
                return View(addScreeningVM);
            }
            AddScreeningDTO addScreeningDTO = new AddScreeningDTO(addScreeningVM.Start, addScreeningVM.Price,
                addScreeningVM.MovieId, addScreeningVM.RoomId);
            screeningManageService.AddScreening(addScreeningDTO);
            return RedirectToAction("AddScreening");


        }
    }
}