using Microsoft.AspNetCore.Mvc;
using MusicLib.BLL.DTO;
using MusicLib.BLL.Interfaces;
using MusicLib.BLL.Infrastructure;

namespace MusicLib.Controllers
{
    public class ArtistsController : Controller
    {
        private readonly IArtistService artistService;

        public ArtistsController(IArtistService serv)
        {
            artistService = serv;
        }

        // GET: Artists
        public async Task<IActionResult> Index()
        {
            return View(await artistService.GetArtists());
        }

        // GET: Artists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                ArtistDTO artist = await artistService.GetArtist((int)id);
                return View(artist);
            }
            catch (ValidationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        //
        // GET: /Artists/Create

        public IActionResult Create()
        {
            return View();
        }

        // POST: Artists/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ArtistDTO artist)
        {
            if (ModelState.IsValid)
            {
                await artistService.CreateArtist(artist);
                return View("~/Views/Artists/Index.cshtml", await artistService.GetArtists());
            }
            return View(artist);
        }

        // GET: Artists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                ArtistDTO artist = await artistService.GetArtist((int)id);
                return View(artist);
            }
            catch (ValidationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: Artists/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ArtistDTO artist)
        {
            if (ModelState.IsValid)
            {
                await artistService.UpdateArtist(artist);
                return View("~/Views/Artists/Index.cshtml", await artistService.GetArtists());
            }
            return View(artist);
        }

        // GET: Artists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                ArtistDTO artist = await artistService.GetArtist((int)id);
                return View(artist);
            }
            catch (ValidationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: Artists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await artistService.DeleteArtist(id);
            return View("~/Views/Artists/Index.cshtml", await artistService.GetArtists());
        }

    }
}
