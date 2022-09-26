using Microsoft.EntityFrameworkCore;
using WebStore.Core.Interface;
using WebStore.DAL.Data.EF;

namespace WebStore.DAL.Repository;
public class StoreRepository : IStoreRepository
{
    private readonly StoreContext _context;
    public StoreRepository(StoreContext context)
      => _context = context ?? throw new ArgumentNullException(nameof(context));    

        public async Task<bool> Exist(int id)
          => await _context.Stores.AnyAsync(x=>x.Id == id); 
}
