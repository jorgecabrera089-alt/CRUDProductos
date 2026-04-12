using Microsoft.AspNetCore.Mvc;

namespace CRUDProductos.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public string? Nombre { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public decimal? Total { get; set; }
        public string? Status { get; set; }

        public string? Productos { get; set; } 
        public DateTime CreatedAt { get; set; }
    }
}
