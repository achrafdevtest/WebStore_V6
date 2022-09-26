using WebStore.Core.Models;

namespace WebStore.Core.Interface;
public interface ICustomerRepository
{
    Task<Customer> Get(int id);
    Task<IReadOnlyList<Customer>> GetAll();
    Task<bool> Exist(int id);
}

