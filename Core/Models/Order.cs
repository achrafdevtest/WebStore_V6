namespace WebStore.Core.Models;
public class Order
{
    public int Id { get; set; }
    public int Customer { get; set; }
    public int Store { get; set; }
    public int Staff { get; set; }
    public bool Status { get; set; }
    public DateTime Date { get; set; }
    public decimal TotatlHT { get; set; }
    public decimal TotatlTTC { get; set; }
}

