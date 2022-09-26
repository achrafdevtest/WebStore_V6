using Microsoft.EntityFrameworkCore.Storage;
using WebStore.Core.Interface;
using WebStore.Core.Models;
using WebStore.DAL.Data.EF;
using WebStore.DAL.Data.EF.Dao;

namespace WebStore.DAL.Repository;

public class OrderItemRepository : IOrderItemRepository
{
    private readonly StoreContext _context;

    public OrderItemRepository(StoreContext context)
       => _context = context ?? throw new ArgumentNullException(nameof(context));

    public async Task CreateOrderItems(IList<NewOrderLine> newOrderLine , int orderNo)
    {
        using (IDbContextTransaction tr = _context.Database.BeginTransaction())
        {
            try
            {
                foreach (var item in newOrderLine)
                {
                    var data = new OrderItemsDao
                    {
                        OrderId   = orderNo,
                        ProductId = item.ProductId,
                        PuHT      = item.PuHT,
                        Quantity  = item.Quantity,
                        Discount  = item.Discount,
                    };
                    _context.OrderItems.Add(data);
                }
                await _context.SaveChangesAsync();
                tr.Commit();
            }
            catch
            {
                tr.Rollback();
                throw;
            }
        }

    }
}

