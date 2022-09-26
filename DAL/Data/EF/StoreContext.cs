using Microsoft.EntityFrameworkCore;
using WebStore.DAL.Data.EF.Configuration;
using WebStore.DAL.Data.EF.Dao;

namespace WebStore.DAL.Data.EF;

public class StoreContext : DbContext
{
    public StoreContext(DbContextOptions<StoreContext> options) : base(options)
    {
    }
    public DbSet<CustomersDao>? Customers { get; set; }
    public DbSet<StoresDao>? Stores { get; set; }
    public DbSet<ProductsDao>? Products { get; set; }
    public DbSet<CategoriesDao>? Categories { get; set; }
    public DbSet<BrandsDao>? Brands { get; set; }
    public DbSet<StaffsDao>? Staffs { get; set; }
    public DbSet<StocksDao>? Stocks { get; set; }
    public DbSet<OrderDao>? Orders { get; set; }
    public DbSet<OrderItemsDao>? OrderItems { get; set; }
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
