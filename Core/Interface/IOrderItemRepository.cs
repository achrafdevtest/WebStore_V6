using WebStore.Core.Models;

namespace WebStore.Core.Interface;
public interface IOrderItemRepository
{
    Task CreateOrderItems(IList<NewOrderLine> newOrderLine , int orderNo);
}

