using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebStore.DAL.Data.EF.Dao;

namespace WebStore.DAL.Data.EF.Configuration;

public class OrderConfiguration : IEntityTypeConfiguration<OrderDao>
{
    public void Configure(EntityTypeBuilder<OrderDao> builder)
    {
        builder.ToTable("ORDERS");
        builder.Property(s => s.Id)
               .UseIdentityColumn(22000001, 1);

    }
}
