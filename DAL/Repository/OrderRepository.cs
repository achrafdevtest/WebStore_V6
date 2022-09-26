using Microsoft.EntityFrameworkCore.Storage;
using WebStore.Core.Interface;
using WebStore.Core.Models;
using WebStore.DAL.Data.EF;
using WebStore.DAL.Data.EF.Dao;

namespace WebStore.DAL.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly StoreContext _context;
        public OrderRepository(StoreContext context)
            => _context = context ?? throw new ArgumentNullException(nameof(context));
        public async Task<int> Create(NewOrder order)
        {

            using (IDbContextTransaction tr = _context.Database.BeginTransaction())
            {
                try
                {
                    var data = new OrderDao
                    {
                        CustomerId = order.CustomerId,
                        StaffId = order.StaffId,
                        StoreId = order.StoreId,
                        Status = order.Status,
                        Date = DateTime.Now,
                    };
                    _context.Orders.Add(data);
                    await _context.SaveChangesAsync();

                    return data.Id;

                    tr.Commit();
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }

        }

        public Task<IReadOnlyList<Order>> Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
