namespace WebStore.Core.Models;
public class OrderItems
{
    public int OrderId { get; set; }
    public string? Product { get; set; }
    public decimal Quantity { get; set; }
    public decimal PU { get; set; }
    public decimal Discount { get; set; }
    public decimal PUTTC { get; set; }

}

