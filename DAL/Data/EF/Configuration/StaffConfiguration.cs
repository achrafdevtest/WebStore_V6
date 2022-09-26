using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebStore.Core.Models;
using WebStore.DAL.Data.EF.Dao;

namespace WebStore.DAL.Data.EF.Configuration;
public class StaffConfiguration : IEntityTypeConfiguration<StaffsDao>
{
    public void Configure(EntityTypeBuilder<StaffsDao> builder)
    {
        builder.ToTable("STAFF");
        builder.Property(s => s.Matricule)
               .IsRequired(true);
        builder.HasData
        (
            new Staff
            {
                Id = 1,
                StoreId = 1,
                Matricule = "001",
                Name = "Staff01",
                EMAIL = "staf01@gmail.com",
                IsActive = true,
                Phone = "",
            },
            new Staff
            {
                Id = 2,
                StoreId = 1,
                Matricule = "002",
                Name = "Staff02",
                EMAIL = "staf02@gmail.com",
                IsActive = true,
                Phone = "",
            }
        );
    }
}
