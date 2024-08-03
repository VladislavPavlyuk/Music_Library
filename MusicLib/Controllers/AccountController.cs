using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MusicLib.BLL.DTO;
using MusicLib.BLL.Interfaces;
using MusicLib.BLL.Services;
using MusicLib.DAL.EF;
using MusicLib.DAL.Entities;
using MusicLib.Models;
using System.Security.Cryptography;
using System.Text;

namespace MusicLib.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService userService;

        public AccountController(IUserService userServ)
        {
            userService = userServ;
        }
        public IActionResult Register()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel reg)
        {
            if (ModelState.IsValid)
            {
                //UserDTO user = new UserDTO();
                /*if (reg.Login == "admin")
                {
                    ModelState.AddModelError("Login", "admin - запрещенное имя");
                    return View(reg);
                }
               
                UserDTO userLogin = await _userService.GetUserByLogin(reg.Login);
                if (reg.Login == userLogin.Login)
                {
                    ModelState.AddModelError("Login", "Пользователь с таким логином существует");
                    return View(reg);
                } */

                UserDTO user = await userService.GetUserByEmail(reg.Email);

                if (reg.Email == user.Email)
                {
                    ModelState.AddModelError("Email", "Email is exist already!");
                    return View(reg);
                }
                if (reg.Password.Length < 4 )
                {
                    ModelState.AddModelError("Password", "Password should have 4 or more digits");
                    return View(reg);
                }
                else if (!reg.Password.Any(char.IsDigit))
                {
                    ModelState.AddModelError("Password", "Password should have even one or more numbers");
                    return View(reg);
                }
                user.Email = reg.Email;

                byte[] saltbuf = new byte[16];

                RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();
                randomNumberGenerator.GetBytes(saltbuf);

                StringBuilder sb = new StringBuilder(16);
                for (int i = 0; i < 16; i++)
                    sb.Append(string.Format("{0:X2}", saltbuf[i]));
                string salt = sb.ToString();

                //переводим пароль в байт-массив  
                byte[] password = Encoding.Unicode.GetBytes(salt + reg.Password);

                //вычисляем хеш-представление в байтах  
                byte[] byteHash = SHA256.HashData(password);

                StringBuilder hash = new StringBuilder(byteHash.Length);
                for (int i = 0; i < byteHash.Length; i++)
                    hash.Append(string.Format("{0:X2}", byteHash[i]));

                user.Password = hash.ToString();
                user.Salt = salt;
                user.RoleId = 3; //Candidate Role

                await userService.CreateUser(user);

                return RedirectToAction("Login");
            }

            return View(reg);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel logon)
        {
            if (ModelState.IsValid)
            {
                UserDTO user = await userService.GetUserByEmail(logon.Email);

                if (user.Id == 0)
                {
                    ModelState.AddModelError("Email", "Email is not exist");
                    return View(logon);
                }

                string? salt = user.Salt;

                byte[] password = Encoding.Unicode.GetBytes(salt + logon.Password);

                byte[] byteHash = SHA256.HashData(password);

                StringBuilder hash = new StringBuilder(byteHash.Length);

                for (int i = 0; i < byteHash.Length; i++)
                    hash.Append(string.Format("{0:X2}", byteHash[i]));

                if (user.Password != hash.ToString())
                {
                    ModelState.AddModelError("Password", "Password is not exist");
                    return View(logon);
                }
                HttpContext.Session.SetString("Email", user.Email);
                HttpContext.Session.SetInt32("Role", (int)user.RoleId);
                HttpContext.Session.SetInt32("Id", user.Id);

                return RedirectToAction("Index", "Home");
            }
            return View(logon);
        }
    }
}