using Microsoft.AspNetCore.Mvc;
using CRUDProductos.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDProductos.Controllers
{
    public class AdminController : Controller
    {
        private readonly SampleDbContext _context;

        public AdminController(SampleDbContext context)
        {
            _context = context;
        }

        public IActionResult AdminPanel()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("User")))
                return RedirectToAction("Login", "Account");

            if (HttpContext.Session.GetString("Role") != "1")
                return RedirectToAction("Login", "Account");

            return View();
        }

        [HttpGet]
        public IActionResult GetVentas()
        {
            var ventas = _context.Orders
                .Where(o => o.Total != null)
                .GroupBy(o => new { o.CreatedAt.Year, o.CreatedAt.Month })
                .Select(g => new {
                    mes = g.Key.Month,
                    anio = g.Key.Year,
                    total = g.Sum(o => o.Total)
                })
                .OrderBy(x => x.anio)
                .ThenBy(x => x.mes)
                .ToList();

            return Json(ventas);
        }
    }
}