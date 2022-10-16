namespace WebStore.Core.Models;

public class ShopDto
{
    public string? Name { get; set; }

    public string? description { get; set; }

    public decimal Price { get; set; }

    public decimal Discount { get; set; }

    public string? PictureUrl { get; set; }

    public string? ProductCategory { get; set; }

    public string? ProductBrand { get; set; }
}
