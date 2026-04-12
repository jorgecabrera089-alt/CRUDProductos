using CRUDProductos.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDProductos.Controllers
{
    public class AccountController : Controller
    {
        private readonly SampleDbContext _context;

        public AccountController(SampleDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _context.Users
                .FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user != null)
            {
                HttpContext.Session.SetString("User", user.Username);
                HttpContext.Session.SetString("Role", user.RoleId.ToString());

                // 🔥 REDIRECCIÓN POR ROL
                if (user.RoleId == 1)
                {
                    return RedirectToAction("AdminPanel", "Admin");
                }
                else if (user.RoleId == 2)
                {
                    return RedirectToAction("Index", "Orders");
                }
                else
                {
                    return RedirectToAction("Index", "Products");
                }
            }

            ViewBag.Error = "Usuario o contraseña incorrectos";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
