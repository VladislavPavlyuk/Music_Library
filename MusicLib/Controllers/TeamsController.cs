using Microsoft.AspNetCore.Mvc;
using MusicLib.BLL.DTO;
using MusicLib.BLL.Interfaces;
using MusicLib.BLL.Infrastructure;

namespace MusicLib.Controllers
{
    public class TeamsController : Controller
    {
        private readonly ITeamService teamService;

        public TeamsController(ITeamService serv)
        {
            teamService = serv;
        }

        // GET: Teams
        public async Task<IActionResult> Index()
        {
            return View(await teamService.GetTeams());
        }

        // GET: Teams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                TeamDTO team = await teamService.GetTeam((int)id);
                return View(team);
            }
            catch (ValidationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        //
        // GET: /Teams/Create

        public IActionResult Create()
        {
            return View();
        }

        // POST: Teams/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TeamDTO team)
        {
            if (ModelState.IsValid)
            {
                await teamService.CreateTeam(team);
                return View("~/Views/Teams/Index.cshtml", await teamService.GetTeams());
            }
            return View(team);
        }

        // GET: Teams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                TeamDTO team = await teamService.GetTeam((int)id);
                return View(team);
            }
            catch (ValidationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: Teams/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TeamDTO team)
        {
            if (ModelState.IsValid)
            {
                await teamService.UpdateTeam(team);
                return View("~/Views/Teams/Index.cshtml", await teamService.GetTeams());
            }
            return View(team);
        }

        // GET: Teams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                TeamDTO team = await teamService.GetTeam((int)id);
                return View(team);
            }
            catch (ValidationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await teamService.DeleteTeam(id);
            return View("~/Views/Teams/Index.cshtml", await teamService.GetTeams());
        }

    }
}