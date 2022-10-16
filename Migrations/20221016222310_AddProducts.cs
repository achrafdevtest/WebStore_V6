using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebStore.Migrations
{
    public partial class AddProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "P_Unite",
                table: "PRODUCTS",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "P_Name",
                table: "PRODUCTS",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "P_Description",
                table: "PRODUCTS",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<decimal>(
                name: "P_Discount",
                table: "PRODUCTS",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "P_PictureUrl",
                table: "PRODUCTS",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "PRODUCTS",
                keyColumn: "P_Id",
                keyValue: 1,
                column: "P_Discount",
                value: 10m);

            migrationBuilder.UpdateData(
                table: "PRODUCTS",
                keyColumn: "P_Id",
                keyValue: 2,
                column: "P_Discount",
                value: 10m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "P_Discount",
                table: "PRODUCTS");

            migrationBuilder.DropColumn(
                name: "P_PictureUrl",
                table: "PRODUCTS");

            migrationBuilder.AlterColumn<string>(
                name: "P_Unite",
                table: "PRODUCTS",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "P_Name",
                table: "PRODUCTS",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "P_Description",
                table: "PRODUCTS",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
