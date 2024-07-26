using Microsoft.AspNetCore.Mvc;
using MusicLib.BLL.DTO;
using MusicLib.BLL.Interfaces;
using MusicLib.BLL.Infrastructure;

namespace MusicLib.Controllers
{
    public class VideosController : Controller
    {
        private readonly IVideoService videoService;

        public VideosController(IVideoService serv)
        {
            videoService = serv;
        }

        // GET: Videos
        public async Task<IActionResult> Index()
        {
            return View(await videoService.GetVideos());
        }

        // GET: Videos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                VideoDTO video = await videoService.GetVideo((int)id);

                return View(video);
            }
            catch (ValidationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        //
        // GET: /Videos/Create

        public IActionResult Create()
        {
            return View();
        }

        // POST: Videos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VideoDTO video)
        {
            if (ModelState.IsValid)
            {
                await videoService.CreateVideo(video);
                return View("~/Views/Videos/Index.cshtml", await videoService.GetVideos());
            }
            return View(video);
        }

        // GET: Videos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                VideoDTO video = await videoService.GetVideo((int)id);
                return View(video);
            }
            catch (ValidationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: Videos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(VideoDTO video)
        {
            if (ModelState.IsValid)
            {
                await videoService.UpdateVideo(video);
                return View("~/Views/Videos/Index.cshtml", await videoService.GetVideos());
            }
            return View(video);
        }

        // GET: Videos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                VideoDTO video = await videoService.GetVideo((int)id);
                return View(video);
            }
            catch (ValidationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: Videos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await videoService.DeleteVideo(id);
            return View("~/Views/Videos/Index.cshtml", await videoService.GetVideos());
        }

    }
}
