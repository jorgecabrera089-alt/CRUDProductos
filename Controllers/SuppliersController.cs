using Microsoft.AspNetCore.Mvc;
using CRUDProductos.Models;

namespace CRUDProductos.Controllers  // ← ¡Esto faltaba!
{
    public class SuppliersController : Controller
    {
        private readonly SampleDbContext _context;

        public SuppliersController(SampleDbContext context)
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

            var suppliers = _context.Suppliers.ToList();
            return View(suppliers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}