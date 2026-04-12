using Microsoft.AspNetCore.Mvc;

namespace CRUDProductos.Controllers
{
   
public class AdminController : Controller
{
    
    public IActionResult AdminPanel()
    {
        return View();
    }
}
}