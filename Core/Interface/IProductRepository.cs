using WebStore.Core.Models;

namespace WebStore.Core.Interface;
public interface IProductRepository
{
    Task<Product> Get(int id);
    Task<IReadOnlyList<Product>> GetAll();
    Task<bool> Exist(int id);
}

