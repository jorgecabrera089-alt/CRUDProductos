using Microsoft.AspNetCore.Mvc;
using CRUDProductos.Models;

namespace CRUDProductos.Controllers
{
    public class DiscountsController : Controller
    {
        private readonly SampleDbContext _context;

        public DiscountsController(SampleDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // 🔐 Validación de sesión
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("User")))
                return RedirectToAction("Login", "Account");

            if (HttpContext.Session.GetString("Role") != "1")
                return RedirectToAction("Login", "Account");

            var discounts = _context.Discounts.ToList();
            return View(discounts);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Discount discount)
        {
            _context.Discounts.Add(discount);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}