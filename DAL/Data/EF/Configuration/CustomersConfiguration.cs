using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebStore.Core.Models;
using WebStore.DAL.Data.EF.Dao;

namespace WebStore.DAL.Data.EF.Configuration;
public class CustomersConfiguration : IEntityTypeConfiguration<CustomersDao>
{
    public void Configure(EntityTypeBuilder<CustomersDao> builder)
    {
        builder.ToTable("CUSTOMERS");
        builder.Property(s => s.Matricule)
               .IsRequired(true);
        builder.HasData
        (
            new Customer
            {
                Id = 1,
                Matricule = "001",
                FirstName = "Achraf",
                LastName = "",
                EMAIL = "achraf@gmail.com",
                City = "TUNISIA",
                State = "",
                Phone = "",
                Street = "",
                ZipCode = "",
            }
        );
    }
}
