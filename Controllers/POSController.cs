using Microsoft.AspNetCore.Mvc;
using CRUDProductos.Models;
using System.Linq;

public class POSController : Controller
{
    private readonly SampleDbContext _context;

    public POSController(SampleDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Buscar(string term)
    {
        var productos = _context.Products
            .Where(p => p.Name.Contains(term))
            .ToList();

        return Json(productos);
    }
}
