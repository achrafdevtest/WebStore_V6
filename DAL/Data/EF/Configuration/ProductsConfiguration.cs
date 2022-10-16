using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebStore.Core.Models;
using WebStore.DAL.Data.EF.Dao;

namespace WebStore.DAL.Data.EF.Configuration;
public class ProductsConfiguration : IEntityTypeConfiguration<ProductsDao>
{
    public void Configure(EntityTypeBuilder<ProductsDao> builder)
    {
        builder.ToTable("PRODUCTS");
        builder.Property(s => s.Code)
               .IsRequired(true);
        builder.HasData
        (
            new Product
            {
                Id = 1,
                BrandId = 1,
                CategoryId = 1,
                Code = "001",
                Name = "Pc Portable Dell Vostro 15 3510 / i7 11è Gén / 24 Go / MX350 2G",
                Description = "Ecran 15.6\" Full HD LED - Processeur Intel Core i7-1165G7, up to 4.7 GHz, 12 Mo de mémoire cache " +
                "- Mémoire 24 Go - Disque 1 To - Carte graphique NVIDIA GeForce MX350, 2 Go de mémoire dédiée " +
                "- Lecteur de cartes - HDMI - RJ45 - Wifi - Bluetooth 5.0",
                ModelYears = 2022,
                PU = 2470,
                Unite = "PIECE",
                IsActive = true,
                Discount= 10
                
            },
            new Product
            {
                Id = 2,
                BrandId = 2,
                CategoryId = 1,
                Code = "002",
                Name = "PC Portable Lenovo IdeaPad Gaming 3 15IAH7 / i7-12650H / 24 Go / RTX 3050 Ti 4GB / Noir",
                Description = "Écran 15.6\" IPS Full HD 165 Hz - Processeur Intel Core i7-12650H, up to 4.7 Ghz, 24 Mo de cache" +
                " - Mémoire 24 Go - Disque SSD 1 To - Carte graphique Nvidia RTX 3050 Ti, 4 Go de mémoire GDDR6 dédiée - Wifi 6 " +
                "- Bluetooth 5.2 - 2x USB 3.2 - 1x USB 2.0 - HDMI 2.0 - RJ45 " +
                " - Clavier Retroéclairé - Windows 11 Home 64 - Couleur Noir ",
                ModelYears = 2022,
                PU = 4280,
                Unite = "PIECE",
                IsActive = true,
                Discount = 10
            }
        );

    }

}

