using Microsoft.AspNetCore.Mvc;
using CRUDProductos.Models;
using Newtonsoft.Json;

namespace CRUDProductos.Controllers
{
    public class CartController : Controller
    {
        private readonly SampleDbContext _context;

        public CartController(SampleDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var cart = HttpContext.Session.GetString("Cart");

            var cartItems = cart == null
                ? new List<Product>()
                : JsonConvert.DeserializeObject<List<Product>>(cart);

            return View(cartItems);
        }

        public IActionResult Add(int id)
        {
            var product = _context.Products.Find(id);

            if (product == null) return NotFound();

            var cart = HttpContext.Session.GetString("Cart");

            List<Product> cartItems = cart == null
                ? new List<Product>()
                : JsonConvert.DeserializeObject<List<Product>>(cart);

            cartItems.Add(product);

            HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cartItems));

            return Ok(); 
        }

      
        public IActionResult Delete(int id)
        {
            var cart = HttpContext.Session.GetString("Cart");

            if (cart != null)
            {
                var cartItems = JsonConvert.DeserializeObject<List<Product>>(cart);

                var item = cartItems.FirstOrDefault(p => p.ProductId == id);

                if (item != null)
                {
                    cartItems.Remove(item);
                }

                HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cartItems));
            }

            return RedirectToAction("Index");
        }
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(string nombre, string metodo, string telefono)
        {
            // aquí luego puedes guardar pedido

            HttpContext.Session.Remove("Cart");

            ViewBag.Mensaje = "Pago realizado con éxito";

            return View();
        }
    }
}