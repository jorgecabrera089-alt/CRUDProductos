using Microsoft.AspNetCore.Mvc;
using CRUDProductos.Models;
using System.Linq;

namespace CRUDProductos.Controllers
{
    public class ReportsController : Controller
    {
        private readonly SampleDbContext _context;

        public ReportsController(SampleDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var reports = _context.Reports
                .OrderByDescending(r => r.CreatedAt)
                .ToList();

            ViewBag.TotalVentas = _context.Orders
                .Where(o => o.Status == "Entregado")
                .Sum(o => o.Total);

            ViewBag.TotalPedidos = _context.Orders.Count();

            return View(reports);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
public IActionResult Create(string descripcion, decimal totalVentas)
{
    var report = new Report
    {
        Description = descripcion ?? "Sin descripcion",
        Total = totalVentas,
        CreatedAt = DateTime.Now
    };

    _context.Reports.Add(report);
    _context.SaveChanges();

    return RedirectToAction("Index"); // 🔥 ESTE ES EL CAMBIO
}
    }
}