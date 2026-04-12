using CRUDProductos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CRUDProductos.Controllers
{
    public class ProductsController : Controller
    {
        private readonly SampleDbContext _context;

        public ProductsController(SampleDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var role = HttpContext.Session.GetString("Role");

            // 🔥 BLOQUEAR ADMIN Y VENDEDOR
            if (role == "1")
            {
                return RedirectToAction("AdminPanel", "Admin");
            }

            if (role == "2")
            {
                return RedirectToAction("Index", "Orders");
            }

            return View(_context.Products.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public IActionResult Edit(int id)
        {
            var producto = _context.Products.Find(id);
            if (producto == null) return NotFound();

            return View(producto);
        }

       
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Update(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        public IActionResult Delete(int id)
        {
            var producto = _context.Products.Find(id);
            if (producto == null) return NotFound();

            _context.Products.Remove(producto);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var product = _context.Products.Find(id);

            if (product == null) return NotFound();

            return View(product);
        }
    }
}
