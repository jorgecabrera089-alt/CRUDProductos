using Microsoft.AspNetCore.Mvc;
using CRUDProductos.Models;
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
            var productos = _context.Products.ToList();
            return View(productos);
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
            var producto = _context.Products.Find(id);
            if (producto == null) return NotFound();

            return View(producto);
        }
    }
}
