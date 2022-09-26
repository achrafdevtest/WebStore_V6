using Microsoft.EntityFrameworkCore;
using WebStore.Core.Interface;
using WebStore.Core.Models;
using WebStore.DAL.Data.EF;
using WebStore.DAL.Data.EF.Dao;

namespace WebStore.DAL.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly StoreContext _context;

        public CategoryRepository(StoreContext context)
        => _context = context ?? throw new ArgumentNullException(nameof(context));

        public async Task<bool> Exist(string code) => await _context.Categories.AnyAsync(x => x.Code == code);
        public async Task<bool> Exist(int id) => await _context.Categories.AnyAsync(x => x.Id == id);
        public async Task Create(NewCategory newBrand)
        {
            try
            {
                var data = new CategoriesDao
                {
                    Code = newBrand.Code,
                    Name = newBrand.Name ?? "",
                    Description = newBrand.Description ?? "",
                };
                _context.Categories.Add(data);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task Delete(int id)
        {
            var result = await _context.Categories.SingleOrDefaultAsync(b => b.Id == id);
            if (result != null)
                _context.Remove(result);
            await _context.SaveChangesAsync();
        }  
        public async Task<IReadOnlyList<Category>> GetAll()
        {
            return await _context.Categories.Select(x => new Category
            {
                Id = x.Id,
                Code = x.Code,
                Name = x.Name,
                Description = x.Description,
            }).ToListAsync();
        }
        public async Task<Category> GetByCode(string code)
        {
            var result = await _context.Brands.FindAsync(code);
            return new Category
            {
                Id          = result.Id,
                Code        = code,
                Description = result.Description,
                Name        = result.Name
            };
        }
        public async Task<Category> GetById(int id)
        {
            var result = await _context.Categories.FindAsync(id);
            return new Category
            {
                Id          = id,
                Code        = result.Code,
                Description = result.Description,
                Name        = result.Name
            };
        }
        public async Task Update(UpdateModelBase brand, string code)
        {
            var result = await _context.Categories.SingleOrDefaultAsync(x => x.Code == code);
            result.Name = brand.Name ?? "";
            result.Description = brand.Description ?? "";
            result.Code = code;
            await _context.SaveChangesAsync();
        }
    }
}
