using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebStore.Core.Models;
using WebStore.DAL.Data.EF.Dao;

namespace WebStore.DAL.Data.EF.Configuration;

public class StoreConfiguration : IEntityTypeConfiguration<StoresDao>
{
    public void Configure(EntityTypeBuilder<StoresDao> builder)
    {
        builder.ToTable("STORES");
        builder.HasData
        (
            new Store
            {
                Id = 1,
                City = "TUNISIA",
                Email = "societe@gmail.com",
                Societe = "Societe",
                State = "",
                Phone = "",
                Street = "",
                ZipCode = "",
            }

        );
    }
}
