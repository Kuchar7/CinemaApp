using CinemaApp.DTO;
using CinemaApp.MVC.ViewModels;
using CinemaApp.MVC.ViewModels.CompositeClass;
using CinemaApp.MVC.ViewModels.CompositeClasses;
using IBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaApp.MVC.Controllers
{

    //[Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        readonly IScreeningManageService screeningManageService;
        readonly IRoomDisplayService roomDisplayService;
        readonly IMovieDisplayService movieDisplayService;
        readonly IScreeningValidationService screeningValidationService;
        readonly IGenreDisplayService genreDisplayService;
        readonly IMovieManageService movieManageService;
        readonly IUploadImage uploadImage;
        public AdminController(IScreeningManageService screeningManageService, IRoomDisplayService roomDisplayService,
            IMovieDisplayService movieDisplayService, IScreeningValidationService screeningValidationService,
            IGenreDisplayService genreDisplayService, IMovieManageService movieManageService, IUploadImage uploadImage)
        {
            this.screeningManageService = screeningManageService;
            this.roomDisplayService = roomDisplayService;
            this.movieDisplayService = movieDisplayService;
            this.screeningValidationService = screeningValidationService;
            this.genreDisplayService = genreDisplayService;
            this.movieManageService = movieManageService;
            this.uploadImage = uploadImage;
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddMovie()
        {
            AddMovieVM addMovieVM = new AddMovieVM
            {
                ListOfGenres = genreDisplayService.GetAllGenres().ToList().ConvertAll(x => new Genre(x.Id, x.Name))
            };
            return View(addMovieVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddMovie(AddMovieVM addMovieVM)
        {
            addMovieVM.ListOfGenres = genreDisplayService.GetAllGenres().ToList().ConvertAll(x => new Genre(x.Id, x.Name));
            if (!ModelState.IsValid)
            {
                return View(addMovieVM);
            }
            addMovieVM.Image.SaveAs(uploadImage.GetImageAbsolutePath(addMovieVM.Image.FileName));
            addMovieVM.ImgPath = uploadImage.GetImageRelativePath(addMovieVM.Image.FileName);
            AddMovieDTO addMovieDTO = new AddMovieDTO(addMovieVM.Title, addMovieVM.Length,
                addMovieVM.ImgPath, addMovieVM.Description, addMovieVM.SelectedGenresId);
            movieManageService.AddMovie(addMovieDTO);
            return RedirectToAction("AddMovie");
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
        [ValidateAntiForgeryToken]
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