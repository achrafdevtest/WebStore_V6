
using WebStore.Core.Models;

namespace WebStore.Core.Interface;
public interface IBrandsRepository
{
    Task<Brands> GetById(int id);
    Task<Brands> GetByCode(string code);
    Task<IReadOnlyList<Brands>> GetAll();
    Task Create(NewBrand newBrand);
    Task Update(UpdateModelBase brand, string code);
    Task Delete(int id);
    Task<bool> Exist(string code);
    Task<bool> Exist(int id);
}

