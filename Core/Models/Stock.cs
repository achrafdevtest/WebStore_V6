namespace WebStore.Core.Models;
public class Stock
{
    public int Id { get; set; }
    public int StoreId { get; set; }
    public int ProductId { get; set; }
    public decimal Quantity { get; set; }
    public bool Disponibility { get; set; }

}

