using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MusicLib.BLL.DTO;
using MusicLib.BLL.Interfaces;
using MusicLib.BLL.Infrastructure;

namespace MusicLib.Controllers
{
    public class SongsController : Controller
    {
        private readonly ISongService songService;
        private readonly IGenreService genreService;
        public SongsController(ISongService songserv, IGenreService genreserv)
        {
            songService = songserv;
            genreService = genreserv;
        }

        // GET: Songs
        public async Task<IActionResult> Index()
        {
            return View(await songService.GetSongs());
        }

        // GET: Songs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                SongDTO song = await songService.GetSong((int)id);
                return View(song);
            }
            catch (ValidationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET: Songs/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Listgenres = new SelectList(await genreService.GetGenres(), "Id", "Name");
            return View();
        }

        // POST: Songs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SongDTO song)
        {
            if (ModelState.IsValid)
            {
                await songService.CreateSong(song);
                return View("~/Views/Songs/Index.cshtml", await songService.GetSongs());
            }
            ViewBag.ListGenres = new SelectList(await genreService.GetGenres(), "Id", "Name", song.GenreId);
            return View(song);
        }

        // GET: Songs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                SongDTO song = await songService.GetSong((int)id);
                ViewBag.ListGenres = new SelectList(await genreService.GetGenres(), "Id", "Name", song.GenreId);
                return View(song);
            }
            catch (ValidationException ex)
            {
                return NotFound(ex.Message);
            }
        }


        // POST: Songs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SongDTO song)
        {
            if (ModelState.IsValid)
            {
                await songService.UpdateSong(song);
                return View("~/Views/Songs/Index.cshtml", await songService.GetSongs());
            }
            ViewBag.ListGenres = new SelectList(await genreService.GetGenres(), "Id", "Name", song.GenreId);
            return View(song);
        }


        // GET: Songs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                SongDTO song = await songService.GetSong((int)id);
                return View(song);
            }
            catch (ValidationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: Songs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await songService.DeleteSong(id);
            return View("~/Views/Songs/Index.cshtml", await songService.GetSongs());
        }

    }
}