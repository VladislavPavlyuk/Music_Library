using Microsoft.AspNetCore.Mvc;
using MusicLib.BLL.DTO;
using MusicLib.BLL.Interfaces;
using MusicLib.BLL.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using MusicLib.BLL.Services;
using MusicLib.DAL.Entities;

namespace MusicLib.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;
        private readonly IRoleService roleService;

        public UsersController(IUserService serv, IRoleService roleService)
        {
            userService = serv;
            this.roleService = roleService;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await userService.GetUsers());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                UserDTO user = await userService.GetUser((int)id);
                return View(user);
            }
            catch (ValidationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        //
        // GET: /Users/Create

        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserDTO user)
        {
            if (ModelState.IsValid)
            {
                await userService.CreateUser(user);
                return View("~/Views/Users/Index.cshtml", await userService.GetUsers());
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                UserDTO user = await userService.GetUser((int)id);                                

                ViewBag.ListRoles = new SelectList(await roleService.GetRoles(), "Id", "Name", user.RoleId);

                return View(user);
            }
            catch (ValidationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserDTO user)
        {
            if (ModelState.IsValid)
            {
                await userService.UpdateUser(user);               
                return View("~/Views/Users/Index.cshtml", await userService.GetUsers());
            }
            ViewBag.ListRoles = new SelectList(await roleService.GetRoles(), "Id", "Name", user.RoleId);
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                UserDTO user = await userService.GetUser((int)id);
                return View(user);
            }
            catch (ValidationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await userService.DeleteUser(id);
            return View("~/Views/Users/Index.cshtml", await userService.GetUsers());
        }

    }
}
