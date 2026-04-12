using Microsoft.AspNetCore.Mvc;
using CRUDProductos.Models;
using Newtonsoft.Json;
using AspNetCoreGeneratedDocument;

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

            List<Product> items;

            if (string.IsNullOrEmpty(cart))
            {
                items = new List<Product>();
            }
            else
            {
                items = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Product>>(cart);
            }

            items.Add(product);

            HttpContext.Session.SetString("Cart", Newtonsoft.Json.JsonConvert.SerializeObject(items));

            return Ok();
        }


        public IActionResult Delete(int id)
        {
            var cart = HttpContext.Session.GetString("Cart");

            if (cart != null)
            {
                var items = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Product>>(cart);

                var producto = items.FirstOrDefault(p => p.ProductId == id);

                if (producto != null)
                {
                    items.Remove(producto);
                }

                HttpContext.Session.SetString("Cart", Newtonsoft.Json.JsonConvert.SerializeObject(items));
            }

            return RedirectToAction("Index");
        }

        public IActionResult Checkout()
        {
            var cart = HttpContext.Session.GetString("Cart");

            if (string.IsNullOrEmpty(cart))
            {
                ViewBag.Mensaje = "⚠️ No hay productos en el carrito";
                return View();
            }

            return View();
        }

        [HttpPost]
        public IActionResult Checkout(string nombre, string telefono, string direccion, string metodo)
        {
            var username = HttpContext.Session.GetString("User");
            var user = _context.Users.FirstOrDefault(u => u.Username == username);

            var cart = HttpContext.Session.GetString("Cart");

            var items = string.IsNullOrEmpty(cart)
                ? new List<Product>()
                : Newtonsoft.Json.JsonConvert.DeserializeObject<List<Product>>(cart);

            var total = items.Sum(p => p.Price);

            Console.WriteLine("TOTAL CALCULADO: " + total);

            var order = new Order
            {
                UserId = user.UserId,
                Nombre = nombre,
                Telefono = telefono,
                Direccion = direccion,
                Total = total,
                Status = "Pendiente",
                CreatedAt = DateTime.Now
            };

            _context.Orders.Add(order);
            _context.SaveChanges();

            HttpContext.Session.Remove("Cart");

            ViewBag.Mensaje = "✅ Pedido realizado con éxito";

            return View();
        }
    }
  }
