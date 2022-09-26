namespace WebStore.Core.Models;
public class Product
{
    public int Id { get; set; }
    public int BrandId { get; set; }
    public int CategoryId { get; set; }
    public string? Code { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int ModelYears { get; set; }
    public decimal PU { get; set; }
    public string? Unite { get; set; }
    public bool IsActive { get; set; }

}

