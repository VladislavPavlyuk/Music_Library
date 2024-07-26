using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MusicLib.BLL.DTO;
using MusicLib.BLL.Interfaces;
using MusicLib.BLL.Infrastructure;

namespace MusicLib.Controllers
{
    public class PlayersController : Controller
    {
        private readonly IPlayerService playerService;
        private readonly IGenreService genreService;
        public PlayersController(IPlayerService playerserv, IGenreService genreserv)
        {
            playerService = playerserv;
            genreService = genreserv;
        }

        // GET: Players
        public async Task<IActionResult> Index()
        {
            return View(await playerService.GetPlayers());
        }

        // GET: Players/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                PlayerDTO player = await playerService.GetPlayer((int)id);
                return View(player);
            }
            catch (ValidationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET: Players/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Listgenres = new SelectList(await genreService.GetGenres(), "Id", "Name");
            return View();
        }

        // POST: Players/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PlayerDTO player)
        {
            if (ModelState.IsValid)
            {
                await playerService.CreatePlayer(player);
                return View("~/Views/Players/Index.cshtml", await playerService.GetPlayers());
            }
            ViewBag.ListGenres = new SelectList(await genreService.GetGenres(), "Id", "Name", player.GenreId);
            return View(player);
        }

        // GET: Players/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                PlayerDTO player = await playerService.GetPlayer((int)id);
                ViewBag.ListGenres = new SelectList(await genreService.GetGenres(), "Id", "Name", player.GenreId);
                return View(player);
            }
            catch (ValidationException ex)
            {
                return NotFound(ex.Message);
            }
        }


        // POST: Players/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PlayerDTO player)
        {
            if (ModelState.IsValid)
            {
                await playerService.UpdatePlayer(player);
                return View("~/Views/Players/Index.cshtml", await playerService.GetPlayers());
            }
            ViewBag.ListGenres = new SelectList(await genreService.GetGenres(), "Id", "Name", player.GenreId);
            return View(player);
        }


        // GET: Players/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                PlayerDTO player = await playerService.GetPlayer((int)id);
                return View(player);
            }
            catch (ValidationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: Players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await playerService.DeletePlayer(id);
            return View("~/Views/Players/Index.cshtml", await playerService.GetPlayers());
        }

    }
}