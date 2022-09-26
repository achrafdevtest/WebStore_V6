using WebStore.Core.Models;

namespace WebStore.Core.Interface;
public interface ICategoryRepository
{
    Task<Category> GetById(int id);
    Task<Category> GetByCode(string code);
    Task<IReadOnlyList<Category>> GetAll();
    Task Create(NewCategory newBrand);
    Task Update(UpdateModelBase brand, string code);
    Task Delete(int id);
    Task<bool> Exist(string code);
    Task<bool> Exist(int id);
}

