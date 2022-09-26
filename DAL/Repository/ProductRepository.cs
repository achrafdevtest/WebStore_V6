using Microsoft.EntityFrameworkCore;
using WebStore.Core.Interface;
using WebStore.Core.Models;
using WebStore.DAL.Data.EF;

namespace WebStore.DAL.Repository;

public class ProductRepository : IProductRepository
{
    private readonly StoreContext _context;
    public ProductRepository(StoreContext context)
     => _context = context ?? throw new ArgumentNullException(nameof(context));

    public async Task<bool> Exist(int id)
      => await _context.Products.AnyAsync(x => x.Id == id);

    public async Task<Product> Get(int id)
    {
        var data = await _context.Products.SingleOrDefaultAsync(x => x.Id == id);
        return new Product
        {
            Id = id,
            BrandId = data.BrandId,
            CategoryId = data.CategoryId,
            Code = data.Code,
            Name = data.Name,
            Description = data.Description,
            IsActive = data.IsActive,
            ModelYears = data.ModelYears,
            PU = data.PU,
            Unite = data.Unite
        };
    }

    public async Task<IReadOnlyList<Product>> GetAll()
    {
        return await _context.Products.Select(x => new Product
        {
            Id = x.Id,
            BrandId = x.BrandId,
            CategoryId = x.CategoryId,
            Code = x.Code,
            Name = x.Name,
            Description = x.Description,
            IsActive = x.IsActive,
            ModelYears = x.ModelYears,
            PU = x.PU,
            Unite = x.Unite
        }).ToListAsync();
    }
}

