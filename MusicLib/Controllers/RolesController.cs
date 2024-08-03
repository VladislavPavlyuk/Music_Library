using Microsoft.AspNetCore.Mvc;
using MusicLib.BLL.DTO;
using MusicLib.BLL.Interfaces;
using MusicLib.BLL.Infrastructure;

namespace MusicLib.Controllers
{
    public class RolesController : Controller
    {
        private readonly IRoleService roleService;

        public RolesController(IRoleService serv)
        {
            roleService = serv;
        }

        // GET: Roles
        public async Task<IActionResult> Index()
        {
            return View(await roleService.GetRoles());
        }

        // GET: Roles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                RoleDTO role = await roleService.GetRole((int)id);
                return View(role);
            }
            catch (ValidationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        //
        // GET: /Roles/Create

        public IActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoleDTO role)
        {
            if (ModelState.IsValid)
            {
                await roleService.CreateRole(role);
                return View("~/Views/Roles/Index.cshtml", await roleService.GetRoles());
            }
            return View(role);
        }

        // GET: Roles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                RoleDTO role = await roleService.GetRole((int)id);
                return View(role);
            }
            catch (ValidationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: Roles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RoleDTO role)
        {
            if (ModelState.IsValid)
            {
                await roleService.UpdateRole(role);
                return View("~/Views/Roles/Index.cshtml", await roleService.GetRoles());
            }
            return View(role);
        }

        // GET: Roles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                RoleDTO role = await roleService.GetRole((int)id);
                return View(role);
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

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await roleService.DeleteRole(id);
            return View("~/Views/Roles/Index.cshtml", await roleService.GetRoles());
        }

    }
}