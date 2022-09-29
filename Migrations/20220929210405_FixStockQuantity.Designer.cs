﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebStore.DAL.Data.EF;

#nullable disable

namespace WebStore.Migrations
{
    [DbContext(typeof(StoreContext))]
    [Migration("20220929210405_FixStockQuantity")]
    partial class FixStockQuantity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebStore.DAL.Data.EF.Dao.BrandsDao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("B_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)")
                        .HasColumnName("B_Code");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("B_Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("B_Name");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("BRANDS", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "001",
                            Description = "",
                            Name = "DELL"
                        },
                        new
                        {
                            Id = 2,
                            Code = "002",
                            Description = "",
                            Name = "LENOVO"
                        });
                });

            modelBuilder.Entity("WebStore.DAL.Data.EF.Dao.CategoriesDao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("C_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)")
                        .HasColumnName("C_Code");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("C_Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("C_Name");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("CATEGORY", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "001",
                            Description = "",
                            Name = "Ordinateur"
                        },
                        new
                        {
                            Id = 2,
                            Code = "002",
                            Description = "",
                            Name = "Smartphone"
                        });
                });

            modelBuilder.Entity("WebStore.DAL.Data.EF.Dao.CustomersDao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("C_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("C_CITY");

                    b.Property<string>("EMAIL")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("C_EMAIL");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("C_FIRST_NAME");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("C_LAST_NAME");

                    b.Property<string>("Matricule")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)")
                        .HasColumnName("C_Matricule");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("C_PHONE");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("C_STATE");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("C_STREET");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("C_ZIP_CODE");

                    b.HasKey("Id");

                    b.HasIndex("Matricule")
                        .IsUnique();

                    b.ToTable("CUSTOMERS", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "TUNISIA",
                            EMAIL = "achraf@gmail.com",
                            FirstName = "Achraf",
                            LastName = "",
                            Matricule = "001",
                            Phone = "",
                            State = "",
                            Street = "",
                            ZipCode = ""
                        });
                });

            modelBuilder.Entity("WebStore.DAL.Data.EF.Dao.OrderDao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("O_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 22000001L, 1);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("C_Id");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("O_Date");

                    b.Property<int>("StaffId")
                        .HasColumnType("int")
                        .HasColumnName("S_Id");

                    b.Property<bool>("Status")
                        .HasColumnType("bit")
                        .HasColumnName("O_Status");

                    b.Property<int>("StoreId")
                        .HasColumnType("int")
                        .HasColumnName("STR_Id");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("StaffId");

                    b.HasIndex("StoreId");

                    b.ToTable("ORDERS", (string)null);
                });

            modelBuilder.Entity("WebStore.DAL.Data.EF.Dao.OrderItemsDao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("OI_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18,3)")
                        .HasColumnName("OI_Discount");

                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("O_Id");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("P_Id");

                    b.Property<decimal>("PuHT")
                        .HasColumnType("decimal(18,3)")
                        .HasColumnName("OI_PUHT");

                    b.Property<decimal>("PuNet")
                        .HasColumnType("decimal(18,3)")
                        .HasColumnName("OI_PUNet");

                    b.Property<decimal>("PuTTC")
                        .HasColumnType("decimal(18,3)")
                        .HasColumnName("OI_PUTTC");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(18,3)")
                        .HasColumnName("OI_Quantity");

                    b.Property<decimal>("Taxe")
                        .HasColumnType("decimal(18,3)")
                        .HasColumnName("OI_Taxe");

                    b.HasKey("Id");

                    b.ToTable("ORDER_ITEMS");
                });

            modelBuilder.Entity("WebStore.DAL.Data.EF.Dao.ProductsDao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("P_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BrandId")
                        .HasColumnType("int")
                        .HasColumnName("B_Brand_Id");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("C_Category_Id");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)")
                        .HasColumnName("P_Code");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("P_Description");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("P_Status");

                    b.Property<int>("ModelYears")
                        .HasMaxLength(4)
                        .HasColumnType("int")
                        .HasColumnName("P_Model_Years");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("P_Name");

                    b.Property<decimal>("PU")
                        .HasColumnType("decimal(18,3)")
                        .HasColumnName("P_PU");

                    b.Property<string>("Unite")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("P_Unite");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("PRODUCTS", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BrandId = 1,
                            CategoryId = 1,
                            Code = "001",
                            Description = "Ecran 15.6\" Full HD LED - Processeur Intel Core i7-1165G7, up to 4.7 GHz, 12 Mo de mémoire cache - Mémoire 24 Go - Disque 1 To - Carte graphique NVIDIA GeForce MX350, 2 Go de mémoire dédiée - Lecteur de cartes - HDMI - RJ45 - Wifi - Bluetooth 5.0",
                            IsActive = true,
                            ModelYears = 2022,
                            Name = "Pc Portable Dell Vostro 15 3510 / i7 11è Gén / 24 Go / MX350 2G",
                            PU = 2470m,
                            Unite = "PIECE"
                        },
                        new
                        {
                            Id = 2,
                            BrandId = 2,
                            CategoryId = 1,
                            Code = "002",
                            Description = "Écran 15.6\" IPS Full HD 165 Hz - Processeur Intel Core i7-12650H, up to 4.7 Ghz, 24 Mo de cache - Mémoire 24 Go - Disque SSD 1 To - Carte graphique Nvidia RTX 3050 Ti, 4 Go de mémoire GDDR6 dédiée - Wifi 6 - Bluetooth 5.2 - 2x USB 3.2 - 1x USB 2.0 - HDMI 2.0 - RJ45  - Clavier Retroéclairé - Windows 11 Home 64 - Couleur Noir ",
                            IsActive = true,
                            ModelYears = 2022,
                            Name = "PC Portable Lenovo IdeaPad Gaming 3 15IAH7 / i7-12650H / 24 Go / RTX 3050 Ti 4GB / Noir",
                            PU = 4280m,
                            Unite = "PIECE"
                        });
                });

            modelBuilder.Entity("WebStore.DAL.Data.EF.Dao.StaffsDao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("S_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("EMAIL")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("S_Email");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("S_Active");

                    b.Property<string>("Matricule")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)")
                        .HasColumnName("S_Matricule");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("S_Name");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("S_Phone");

                    b.Property<int>("StoreId")
                        .HasColumnType("int")
                        .HasColumnName("STR_Id");

                    b.HasKey("Id");

                    b.HasIndex("Matricule")
                        .IsUnique();

                    b.ToTable("STAFF", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EMAIL = "staf01@gmail.com",
                            IsActive = true,
                            Matricule = "001",
                            Name = "Staff01",
                            Phone = "",
                            StoreId = 1
                        },
                        new
                        {
                            Id = 2,
                            EMAIL = "staf02@gmail.com",
                            IsActive = true,
                            Matricule = "002",
                            Name = "Staff02",
                            Phone = "",
                            StoreId = 1
                        });
                });

            modelBuilder.Entity("WebStore.DAL.Data.EF.Dao.StocksDao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("STK_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Disponibility")
                        .HasColumnType("bit")
                        .HasColumnName("STK_Disponibility");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("P_Id");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(18,3)")
                        .HasColumnName("STK_Quantity");

                    b.Property<int>("StoreId")
                        .HasColumnType("int")
                        .HasColumnName("STR_Id");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("StoreId");

                    b.ToTable("STOCK", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Disponibility = true,
                            ProductId = 1,
                            Quantity = 23m,
                            StoreId = 1
                        },
                        new
                        {
                            Id = 2,
                            Disponibility = true,
                            ProductId = 2,
                            Quantity = 17m,
                            StoreId = 1
                        });
                });

            modelBuilder.Entity("WebStore.DAL.Data.EF.Dao.StoresDao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("STR_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("STR_City");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("STR_Email");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("STR_Phone");

                    b.Property<string>("Societe")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("STR_Name");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("STR_State");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("STR_Street");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("STR_Zip_Code");

                    b.HasKey("Id");

                    b.ToTable("STORES", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "TUNISIA",
                            Email = "societe@gmail.com",
                            Phone = "",
                            Societe = "Societe",
                            State = "",
                            Street = "",
                            ZipCode = ""
                        });
                });

            modelBuilder.Entity("WebStore.DAL.Data.EF.Dao.OrderDao", b =>
                {
                    b.HasOne("WebStore.DAL.Data.EF.Dao.CustomersDao", "Customers")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebStore.DAL.Data.EF.Dao.StaffsDao", "Staffs")
                        .WithMany()
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebStore.DAL.Data.EF.Dao.StoresDao", "Stores")
                        .WithMany()
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customers");

                    b.Navigation("Staffs");

                    b.Navigation("Stores");
                });

            modelBuilder.Entity("WebStore.DAL.Data.EF.Dao.ProductsDao", b =>
                {
                    b.HasOne("WebStore.DAL.Data.EF.Dao.BrandsDao", "Brands")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebStore.DAL.Data.EF.Dao.CategoriesDao", "Categories")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brands");

                    b.Navigation("Categories");
                });

            modelBuilder.Entity("WebStore.DAL.Data.EF.Dao.StocksDao", b =>
                {
                    b.HasOne("WebStore.DAL.Data.EF.Dao.ProductsDao", "Products")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebStore.DAL.Data.EF.Dao.StoresDao", "Stores")
                        .WithMany()
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Products");

                    b.Navigation("Stores");
                });
#pragma warning restore 612, 618
        }
    }
}
