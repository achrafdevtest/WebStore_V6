using WebStore.Core.Models;

namespace WebStore.Core.Interface;
public interface IOrderRepository
{
    Task<int> Create(NewOrder order);

    Task<IReadOnlyList<Order>> Get(int id);
}

