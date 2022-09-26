using Microsoft.EntityFrameworkCore;
using WebStore.Core.Interface;
using WebStore.Core.Models;
using WebStore.DAL.Data.EF;
using WebStore.DAL.Data.EF.Dao;


namespace WebStore.DAL.Repository;

public class BrandsRepository : IBrandsRepository
{
    private readonly StoreContext _context;
    public BrandsRepository(StoreContext context)
     => _context = context ?? throw new ArgumentNullException(nameof(context));

    public async Task<bool> Exist(string code) => await _context.Brands.AnyAsync(x => x.Code == code);
    public async Task<bool> Exist(int id) => await _context.Brands.AnyAsync(x => x.Id == id);
    public async Task Create(NewBrand newBrand)
    {
        var data = new BrandsDao
        {
            Code = newBrand.Code,
            Name = newBrand.Name ?? "",
            Description = newBrand.Description ?? "",
        };
        _context.Brands.Add(data);
        await _context.SaveChangesAsync();
    }
    public async Task Delete(int id)
    {
        var result = await _context.Brands.SingleOrDefaultAsync(b => b.Id == id);
        if (result != null)
            _context.Remove(result);
        await _context.SaveChangesAsync();
    }
    public async Task<Brands> GetByCode(string code)
    {
        var result = await _context.Brands.FindAsync(code);
        return new Brands
        {
            Id = result.Id,
            Code = result.Code,
            Description = result.Description,
            Name = result.Name
        };
    }
    public async Task Update(UpdateModelBase brand, string code)
    {
        var result = await _context.Brands.SingleOrDefaultAsync(x => x.Code == code);
        result.Name = brand.Name ?? "";
        result.Description = brand.Description ?? "";
        result.Code = code;
        await _context.SaveChangesAsync();
    }
    public async Task<IReadOnlyList<Brands>> GetAll()
    {
        return await _context.Brands.Select(x => new Brands
        {
            Id = x.Id,
            Code = x.Code,
            Name = x.Name,
            Description = x.Description,
        }).ToListAsync();
    }
    public async Task<Brands> GetById(int id)
    {
        var result = await _context.Brands.FindAsync(id);
        return new Brands
        {
            Id = result.Id,
            Code = result.Code,
            Description = result.Description,
            Name = result.Name
        };
    }

}
