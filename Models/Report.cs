using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CRUDProductos.Models
{
    public class Report
    {
        public int ReportId { get; set; }

        public string? Description { get; set; }

        public decimal Total { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}

