using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebStore.Migrations
{
    public partial class InitDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BRANDS",
                columns: table => new
                {
                    B_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    B_Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    B_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    B_Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BRANDS", x => x.B_Id);
                });

            migrationBuilder.CreateTable(
                name: "CATEGORY",
                columns: table => new
                {
                    C_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    C_Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    C_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    C_Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORY", x => x.C_Id);
                });

            migrationBuilder.CreateTable(
                name: "CUSTOMERS",
                columns: table => new
                {
                    C_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    C_Matricule = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    C_FIRST_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    C_LAST_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    C_PHONE = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    C_EMAIL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    C_STREET = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    C_CITY = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    C_STATE = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    C_ZIP_CODE = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMERS", x => x.C_ID);
                });

            migrationBuilder.CreateTable(
                name: "ORDER_ITEMS",
                columns: table => new
                {
                    OI_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    O_Id = table.Column<int>(type: "int", nullable: false),
                    P_Id = table.Column<int>(type: "int", nullable: false),
                    OI_Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OI_PUHT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OI_PUNet = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OI_PUTTC = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OI_Taxe = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OI_Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDER_ITEMS", x => x.OI_Id);
                });

            migrationBuilder.CreateTable(
                name: "STAFF",
                columns: table => new
                {
                    S_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    STR_Id = table.Column<int>(type: "int", nullable: false),
                    S_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    S_Matricule = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    S_Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    S_Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    S_Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STAFF", x => x.S_Id);
                });

            migrationBuilder.CreateTable(
                name: "STORES",
                columns: table => new
                {
                    STR_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    STR_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    STR_Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    STR_Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    STR_Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    STR_City = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    STR_State = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    STR_Zip_Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STORES", x => x.STR_Id);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCTS",
                columns: table => new
                {
                    P_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    B_Brand_Id = table.Column<int>(type: "int", nullable: false),
                    C_Category_Id = table.Column<int>(type: "int", nullable: false),
                    P_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    P_Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    P_Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    P_Model_Years = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    P_PU = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    P_Unite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    P_Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCTS", x => x.P_Id);
                    table.ForeignKey(
                        name: "FK_PRODUCTS_BRANDS_B_Brand_Id",
                        column: x => x.B_Brand_Id,
                        principalTable: "BRANDS",
                        principalColumn: "B_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PRODUCTS_CATEGORY_C_Category_Id",
                        column: x => x.C_Category_Id,
                        principalTable: "CATEGORY",
                        principalColumn: "C_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ORDERS",
                columns: table => new
                {
                    O_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "22000001, 1"),
                    C_Id = table.Column<int>(type: "int", nullable: false),
                    STR_Id = table.Column<int>(type: "int", nullable: false),
                    S_Id = table.Column<int>(type: "int", nullable: false),
                    O_Status = table.Column<bool>(type: "bit", nullable: false),
                    O_Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDERS", x => x.O_Id);
                    table.ForeignKey(
                        name: "FK_ORDERS_CUSTOMERS_C_Id",
                        column: x => x.C_Id,
                        principalTable: "CUSTOMERS",
                        principalColumn: "C_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ORDERS_STAFF_S_Id",
                        column: x => x.S_Id,
                        principalTable: "STAFF",
                        principalColumn: "S_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ORDERS_STORES_STR_Id",
                        column: x => x.STR_Id,
                        principalTable: "STORES",
                        principalColumn: "STR_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "STOCK",
                columns: table => new
                {
                    STK_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    STR_Id = table.Column<int>(type: "int", nullable: false),
                    P_Id = table.Column<int>(type: "int", nullable: false),
                    STK_Quantity = table.Column<decimal>(type: "decimal(18,2)", maxLength: 50, nullable: false),
                    STK_Disponibility = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STOCK", x => x.STK_Id);
                    table.ForeignKey(
                        name: "FK_STOCK_PRODUCTS_P_Id",
                        column: x => x.P_Id,
                        principalTable: "PRODUCTS",
                        principalColumn: "P_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_STOCK_STORES_STR_Id",
                        column: x => x.STR_Id,
                        principalTable: "STORES",
                        principalColumn: "STR_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BRANDS",
                columns: new[] { "B_Id", "B_Code", "B_Description", "B_Name" },
                values: new object[,]
                {
                    { 1, "001", "", "DELL" },
                    { 2, "002", "", "LENOVO" }
                });

            migrationBuilder.InsertData(
                table: "CATEGORY",
                columns: new[] { "C_Id", "C_Code", "C_Description", "C_Name" },
                values: new object[,]
                {
                    { 1, "001", "", "Ordinateur" },
                    { 2, "002", "", "Smartphone" }
                });

            migrationBuilder.InsertData(
                table: "CUSTOMERS",
                columns: new[] { "C_ID", "C_CITY", "C_EMAIL", "C_FIRST_NAME", "C_LAST_NAME", "C_Matricule", "C_PHONE", "C_STATE", "C_STREET", "C_ZIP_CODE" },
                values: new object[] { 1, "TUNISIA", "achraf@gmail.com", "Achraf", "", "001", "", "", "", "" });

            migrationBuilder.InsertData(
                table: "STAFF",
                columns: new[] { "S_Id", "S_Email", "S_Active", "S_Matricule", "S_Name", "S_Phone", "STR_Id" },
                values: new object[,]
                {
                    { 1, "staf01@gmail.com", true, "001", "Staff01", "", 1 },
                    { 2, "staf02@gmail.com", true, "002", "Staff02", "", 1 }
                });

            migrationBuilder.InsertData(
                table: "STORES",
                columns: new[] { "STR_Id", "STR_City", "STR_Email", "STR_Phone", "STR_Name", "STR_State", "STR_Street", "STR_Zip_Code" },
                values: new object[] { 1, "TUNISIA", "societe@gmail.com", "", "Societe", "", "", "" });

            migrationBuilder.InsertData(
                table: "PRODUCTS",
                columns: new[] { "P_Id", "B_Brand_Id", "C_Category_Id", "P_Code", "P_Description", "P_Status", "P_Model_Years", "P_Name", "P_PU", "P_Unite" },
                values: new object[] { 1, 1, 1, "001", "Ecran 15.6\" Full HD LED - Processeur Intel Core i7-1165G7, up to 4.7 GHz, 12 Mo de mémoire cache - Mémoire 24 Go - Disque 1 To - Carte graphique NVIDIA GeForce MX350, 2 Go de mémoire dédiée - Lecteur de cartes - HDMI - RJ45 - Wifi - Bluetooth 5.0", true, 2022, "Pc Portable Dell Vostro 15 3510 / i7 11è Gén / 24 Go / MX350 2G", 2470m, "PIECE" });

            migrationBuilder.InsertData(
                table: "PRODUCTS",
                columns: new[] { "P_Id", "B_Brand_Id", "C_Category_Id", "P_Code", "P_Description", "P_Status", "P_Model_Years", "P_Name", "P_PU", "P_Unite" },
                values: new object[] { 2, 2, 1, "002", "Écran 15.6\" IPS Full HD 165 Hz - Processeur Intel Core i7-12650H, up to 4.7 Ghz, 24 Mo de cache - Mémoire 24 Go - Disque SSD 1 To - Carte graphique Nvidia RTX 3050 Ti, 4 Go de mémoire GDDR6 dédiée - Wifi 6 - Bluetooth 5.2 - 2x USB 3.2 - 1x USB 2.0 - HDMI 2.0 - RJ45  - Clavier Retroéclairé - Windows 11 Home 64 - Couleur Noir ", true, 2022, "PC Portable Lenovo IdeaPad Gaming 3 15IAH7 / i7-12650H / 24 Go / RTX 3050 Ti 4GB / Noir", 4280m, "PIECE" });

            migrationBuilder.InsertData(
                table: "STOCK",
                columns: new[] { "STK_Id", "STK_Disponibility", "P_Id", "STK_Quantity", "STR_Id" },
                values: new object[] { 1, true, 1, 23m, 1 });

            migrationBuilder.InsertData(
                table: "STOCK",
                columns: new[] { "STK_Id", "STK_Disponibility", "P_Id", "STK_Quantity", "STR_Id" },
                values: new object[] { 2, true, 2, 17m, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_BRANDS_B_Code",
                table: "BRANDS",
                column: "B_Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CATEGORY_C_Code",
                table: "CATEGORY",
                column: "C_Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMERS_C_Matricule",
                table: "CUSTOMERS",
                column: "C_Matricule",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ORDERS_C_Id",
                table: "ORDERS",
                column: "C_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERS_S_Id",
                table: "ORDERS",
                column: "S_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERS_STR_Id",
                table: "ORDERS",
                column: "STR_Id");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_B_Brand_Id",
                table: "PRODUCTS",
                column: "B_Brand_Id");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_C_Category_Id",
                table: "PRODUCTS",
                column: "C_Category_Id");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_P_Code",
                table: "PRODUCTS",
                column: "P_Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_STAFF_S_Matricule",
                table: "STAFF",
                column: "S_Matricule",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_STOCK_P_Id",
                table: "STOCK",
                column: "P_Id");

            migrationBuilder.CreateIndex(
                name: "IX_STOCK_STR_Id",
                table: "STOCK",
                column: "STR_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ORDER_ITEMS");

            migrationBuilder.DropTable(
                name: "ORDERS");

            migrationBuilder.DropTable(
                name: "STOCK");

            migrationBuilder.DropTable(
                name: "CUSTOMERS");

            migrationBuilder.DropTable(
                name: "STAFF");

            migrationBuilder.DropTable(
                name: "PRODUCTS");

            migrationBuilder.DropTable(
                name: "STORES");

            migrationBuilder.DropTable(
                name: "BRANDS");

            migrationBuilder.DropTable(
                name: "CATEGORY");
        }
    }
}
