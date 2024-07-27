using Microsoft.AspNetCore.Mvc;
using MusicLib.BLL.DTO;
using MusicLib.BLL.Interfaces;
using MusicLib.BLL.Infrastructure;


namespace MusicLib.Controllers
{
    public class VideosController : Controller
    {
        private readonly IVideoService videoService;

        // IWebHostEnvironment предоставляет информацию об окружении, в котором запущено приложение
        IWebHostEnvironment _appEnvironment;

        public VideosController(IVideoService serv, IWebHostEnvironment appEnvironment)
        {
            videoService = serv;
            _appEnvironment = appEnvironment;
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
            TempData["Message"] = "Model is empty!";
            return View();
        }

        /*
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
        */
        [HttpPost]
        [ValidateAntiForgeryToken]
        [RequestSizeLimit(10000000000)]
        public async Task<IActionResult> Create(IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                TempData["Message"] = "File was not uploaded!";

                // Путь к папке Files
                string path = "/Files/" + uploadedFile.FileName; // имя файла

                // Сохраняем файл в папку Files в каталоге wwwroot
                // Для получения полного пути к каталогу wwwroot
                // применяется свойство WebRootPath объекта IWebHostEnvironment
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream); // копируем файл в поток
                }
                VideoDTO file = new VideoDTO { FileName = uploadedFile.FileName, Path = path };

                //_context.Video.Add(file);
                //_context.SaveChanges();

                await videoService.CreateVideo(file);

                return View("~/Views/Videos/Index.cshtml", await videoService.GetVideos());

            } else {
                TempData["Message"] = "File uploaded successfully!";

            }

            return RedirectToAction("Index");
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
