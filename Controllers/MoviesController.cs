using E_Tickets.Data;
using E_Tickets.Data.Services;
using E_Tickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace E_Tickets.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _service;

        public MoviesController(IMoviesService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allMovies = await _service.GetAllAsync(n=>n.Cinema);
            return View(allMovies);
        }
        public async Task<IActionResult> Details(int id)
        {
            var movieDetail = await _service.GetMovieByIdAsync(id);
            return View(movieDetail);
        }

        public async Task<IActionResult> Create()
        {
            var movieDropDowndata = await _service.GetNewMovieDropDownValues();

            ViewBag.Cinemas = new SelectList(movieDropDowndata.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropDowndata.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropDowndata.Actors, "Id", "FullName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVM movie)
        {
            if(!ModelState.IsValid)
            {
                var movieDropDowndata = await _service.GetNewMovieDropDownValues();

                ViewBag.Cinemas = new SelectList(movieDropDowndata.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropDowndata.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropDowndata.Actors, "Id", "FullName");

                return View(movie);
            }
            await _service.AddNewMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Edit(int id)
        {
            var movieDetails = await _service.GetMovieByIdAsync(id);
            if (movieDetails == null)
                return View("NotFound");
            var movieDropDowndata = await _service.GetNewMovieDropDownValues();

            ViewBag.Cinemas = new SelectList(movieDropDowndata.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropDowndata.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropDowndata.Actors, "Id", "FullName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewMovieVM movie)
        {
            if (id != movie.Id)
                return View("NotFound");
            if (!ModelState.IsValid)
            {
                var movieDropDowndata = await _service.GetNewMovieDropDownValues();

                ViewBag.Cinemas = new SelectList(movieDropDowndata.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropDowndata.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropDowndata.Actors, "Id", "FullName");

                return View(movie);
            }
            await _service.UpdateMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }




    }
}
