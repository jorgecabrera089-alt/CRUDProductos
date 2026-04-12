using Microsoft.AspNetCore.Mvc;
using CRUDProductos.Models;
using System.Linq;

public class SuppliersController : Controller
{
    private readonly SampleDbContext _context;

    public SuppliersController(SampleDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Suppliers.ToList());
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