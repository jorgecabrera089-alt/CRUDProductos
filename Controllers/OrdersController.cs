using Microsoft.AspNetCore.Mvc;
using CRUDProductos.Models;
using System.Linq;

namespace CRUDProductos.Controllers
{
    public class OrdersController : Controller
    {
        private readonly SampleDbContext _context;

        public OrdersController(SampleDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var orders = _context.Orders.ToList();
            return View(orders);
        }

        public IActionResult EnCamino(int id)
        {
            var order = _context.Orders.Find(id);
            if (order != null)
            {
                order.Status = "En camino";
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Entregado(int id)
        {
            var order = _context.Orders.Find(id);
            if (order != null)
            {
                order.Status = "Entregado";
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}