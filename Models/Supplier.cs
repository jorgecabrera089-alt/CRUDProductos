using Microsoft.AspNetCore.Mvc;

namespace CRUDProductos.Models
{
    public class Supplier 
    {
     public int SupplierId { get; set; }
     public string Name { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();
    }
 }

