using Microsoft.EntityFrameworkCore;
using WebStore.DAL.Data.EF.Configuration;
using WebStore.DAL.Data.EF.Dao;

namespace WebStore.DAL.Data.EF;

public class StoreContext : DbContext
{
    public StoreContext(DbContextOptions<StoreContext> options) : base(options)
    {
    }
    public DbSet<CustomersDao> Customers => Set<CustomersDao>();
    public DbSet<StoresDao> Stores => Set<StoresDao>();
    public DbSet<ProductsDao> Products => Set<ProductsDao>();
    public DbSet<CategoriesDao> Categories => Set<CategoriesDao>();
    public DbSet<BrandsDao> Brands => Set<BrandsDao>();
    public DbSet<StaffsDao> Staffs => Set<StaffsDao>();
    public DbSet<StocksDao> Stocks => Set<StocksDao>();
    public DbSet<OrderDao> Orders => Set<OrderDao>();
    public DbSet<OrderItemsDao> OrderItems => Set<OrderItemsDao>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new ProductsConfiguration());
        modelBuilder.ApplyConfiguration(new BrandsConfiguration());
        modelBuilder.ApplyConfiguration(new StockConfiguration());
        modelBuilder.ApplyConfiguration(new StoreConfiguration());
        modelBuilder.ApplyConfiguration(new CategoriesConfiguration());
        modelBuilder.ApplyConfiguration(new CustomersConfiguration());
        modelBuilder.ApplyConfiguration(new StaffConfiguration());

    }
}
