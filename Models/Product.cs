using System;
using System.Collections.Generic;
using CRUDProductos.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDProductos.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public int? CategoryId { get; set; }

    public string? Description { get; set; }
    public string? ImageUrl { get; set; }

    public int? SupplierId { get; set; }
    public Supplier? Supplier { get; set; }

    public virtual Category? Category { get; set; }
}
