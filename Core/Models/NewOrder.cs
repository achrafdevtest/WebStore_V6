using System.ComponentModel.DataAnnotations;

namespace WebStore.Core.Models;
public class NewOrder
{
    [Required]
    public int CustomerId { get; set; }
    [Required]
    public int StoreId { get; set; }
    [Required]
    public int StaffId { get; set; }
    public bool Status { get; set; }
    public DateTime Date { get; set; }
    public IList<NewOrderLine>? newOrderLines { get; set; } = new List<NewOrderLine>();
}

