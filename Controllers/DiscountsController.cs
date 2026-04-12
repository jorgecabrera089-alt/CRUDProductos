using Microsoft.AspNetCore.Mvc;
using CRUDProductos.Models;
using System.Linq;

public class DiscountsController : Controller
{
    private readonly SampleDbContext _context;

    public DiscountsController(SampleDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Discounts.ToList());
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
