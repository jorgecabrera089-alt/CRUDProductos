using Microsoft.AspNetCore.Mvc;

namespace CRUDProductos.Models
{
    public class Discount 
    {
        public int DiscountId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal Percentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate{ get; set; }
        public bool IsActive { get; set; }

    }
}
