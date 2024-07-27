using Microsoft.AspNetCore.Mvc;
using MusicLib.BLL.DTO;
using MusicLib.BLL.Interfaces;
using MusicLib.BLL.Infrastructure;

namespace MusicLib.Controllers
{
    public class GenresController : Controller
    {
        private readonly IGenreService genreService;

        public GenresController(IGenreService serv)
        {
            genreService = serv;
        }

        // GET: Genres
        public async Task<IActionResult> Index()
        {
            return View(await genreService.GetGenres());
        }

        // GET: Genres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                GenreDTO genre = await genreService.GetGenre((int)id);
                return View(genre);
            }
            catch (ValidationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        //
        // GET: /Genres/Create

        public IActionResult Create()
        {
            return View();
        }

        // POST: Genres/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GenreDTO genre)
        {
            if (ModelState.IsValid)
            {
                await genreService.CreateGenre(genre);
                return View("~/Views/Genres/Index.cshtml", await genreService.GetGenres());
            }
            return View(genre);
        }

        // GET: Genres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                GenreDTO genre = await genreService.GetGenre((int)id);
                return View(genre);
            }
            catch (ValidationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: Genres/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(GenreDTO genre)
        {
            if (ModelState.IsValid)
            {
                await genreService.UpdateGenre(genre);
                return View("~/Views/Genres/Index.cshtml", await genreService.GetGenres());
            }
            return View(genre);
        }

        // GET: Genres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                GenreDTO genre = await genreService.GetGenre((int)id);
                return View(genre);
            }
            catch (ValidationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: Genres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await genreService.DeleteGenre(id);
            return View("~/Views/Genres/Index.cshtml", await genreService.GetGenres());
        }

    }
}