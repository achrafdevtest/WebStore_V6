using Microsoft.EntityFrameworkCore;
using WebStore.Core.Interface;
using WebStore.Core.Models;
using WebStore.DAL.Data.EF;

namespace WebStore.DAL.Repository;
public class ShopRepository : IShopRepository
{
    private readonly StoreContext _context;
    public ShopRepository(StoreContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    public async Task<IReadOnlyList<ShopDto>> GetProducts()
    {
        return await _context.Products.Select(x => new ShopDto
        {
            Name = x.Name,
            description = x.Description,
            Discount = x.Discount,
            PictureUrl = x.Picture,
            Price = x.PU,
            ProductBrand = x.Brands.Name,
            ProductCategory = x.Categories.Name,

        }).ToListAsync();

    }
}
