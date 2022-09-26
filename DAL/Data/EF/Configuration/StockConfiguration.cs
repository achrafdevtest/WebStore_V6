using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebStore.Core.Models;
using WebStore.DAL.Data.EF.Dao;

namespace WebStore.DAL.Data.EF.Configuration;
public class StockConfiguration : IEntityTypeConfiguration<StocksDao>
{
    public void Configure(EntityTypeBuilder<StocksDao> builder)
    {
        builder.ToTable("STOCK");
        builder.HasData
        (
            new Stock
            {
                Id = 1,
                StoreId = 1,
                ProductId = 1,
                Quantity = 23,
                Disponibility = true
            },
             new Stock
             {
                 Id = 2,
                 StoreId = 1,
                 ProductId = 2,
                 Quantity = 17,
                 Disponibility = true
             }

        );
    }
}
