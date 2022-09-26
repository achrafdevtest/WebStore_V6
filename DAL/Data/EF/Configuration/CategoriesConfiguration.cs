using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebStore.Core.Models;
using WebStore.DAL.Data.EF.Dao;

namespace WebStore.DAL.Data.EF.Configuration;

public class CategoriesConfiguration : IEntityTypeConfiguration<CategoriesDao>
{
    public void Configure(EntityTypeBuilder<CategoriesDao> builder)
    {
        builder.ToTable("CATEGORY");
        builder.Property(s => s.Code)
               .IsRequired(true);
        builder.HasData
        (
            new Category
            {
                Id = 1,
                Code = "001",
                Name = "Ordinateur",
                Description = "",

            },
            new Category
            {
                Id = 2,
                Code = "002",
                Name = "Smartphone",
                Description = "",
            }
        );
    }
}
