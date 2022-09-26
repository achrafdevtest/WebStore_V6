using System.ComponentModel.DataAnnotations;

namespace WebStore.Core.Models;
public class NewOrderLine
{
    [Required]
    public int ProductId { get; set; }

    [Required]
    public decimal Quantity { get; set; }

    [Required]
    public decimal PuHT { get; set; }
    public decimal Discount { get; set; }
}

