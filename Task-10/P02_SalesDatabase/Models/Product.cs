using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace P02_SalesDatabase.Models;

public class Product
{
    public int ProductId { get; set; }

    [MaxLength(50)]
    [Unicode(true)]
    public string Name { get; set; }

    public double Quantity { get; set; }

    public decimal Price { get; set; }

    [MaxLength(250)]
    [Unicode(true)]
    public string Description { get; set; } = "No description";

    public ICollection<Sale> Sales { get; set; } = new HashSet<Sale>();
}
