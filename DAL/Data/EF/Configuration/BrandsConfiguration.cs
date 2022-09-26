using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebStore.Core.Models;
using WebStore.DAL.Data.EF.Dao;

namespace WebStore.DAL.Data.EF.Configuration;

public class BrandsConfiguration : IEntityTypeConfiguration<BrandsDao>
{
    public void Configure(EntityTypeBuilder<BrandsDao> builder)
    {
        builder.ToTable("BRANDS");
        builder.Property(s => s.Code)
               .IsRequired(true);
        builder.HasData
        (
            new Brands
            {
                Id = 1,
                Code = "001",
                Name = "DELL",
                Description = "",
            },
            new Brands
            {
                Id = 2,
                Code = "002",
                Name = "LENOVO",
                Description = "",
            }
        );
    }
}
