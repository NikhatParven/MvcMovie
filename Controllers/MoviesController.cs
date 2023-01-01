using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcMovie.Data;
using MvcMovie.Models;
using System.Linq;

namespace MvcMovie.Controllers
{
    public class MoviesController : Controller
    {
        FakeContext _context;
        public MoviesController() => 
            _context = new FakeContext();

        // GET: MoviesController
        public ActionResult Index()
        {          
            return _context.Movie != null ?
                View(_context.Movie) :
                Problem("Movie list is null.");
        }

        // GET: MoviesController/Details/5
        public ActionResult Details(int? id)
        {          
            if (id == null || _context.Movie == null)
                return NotFound();

            var movie =  _context.Movie.Single(m => m.Id == id);

            if (movie == null)
                return NotFound();

            return View(movie);
        }

        // GET: MoviesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MoviesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                await _context.AddAsync(movie);
                return RedirectToAction(nameof(Index));
            }
            //send back what the user entered and don't present a blank form again!
            return View(movie);
        }

        // GET: MoviesController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null || _context.Movie == null)
            {
                return NotFound();
            }

            var movie = _context.Movie.Single(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: MoviesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price")] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(movie);
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: MoviesController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null || _context.Movie == null)
            {
                return NotFound();
            }

            var movie =  _context.Movie.Single(m => m.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (_context.Movie == null)
            {
                return Problem("Movie data is null!");
            }
            var movie =  _context.Movie.Single(m=>m.Id == id);

            if (movie != null)
            {
                _context.Movie.Remove(movie);
            }            
            return RedirectToAction(nameof(Index));
        }
    }
}
