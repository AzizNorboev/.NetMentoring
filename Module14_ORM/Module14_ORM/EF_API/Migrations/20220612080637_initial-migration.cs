using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_API.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Height = table.Column<double>(type: "float", nullable: false),
                    Width = table.Column<double>(type: "float", nullable: false),
                    Length = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Height", "Length", "Name", "Weight", "Width" },
                values: new object[] { 1, "desc1", 10.0, 10.0, "product1", 10.0, 10.0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Height", "Length", "Name", "Weight", "Width" },
                values: new object[] { 2, "desc2", 12.0, 12.0, "product2", 11.0, 11.0 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreatedDate", "ProductId", "Status", "UpdatedDate" },
                values: new object[] { 1, new DateTime(2022, 6, 12, 13, 6, 37, 112, DateTimeKind.Local).AddTicks(2412), 1, 1, new DateTime(2022, 6, 12, 13, 6, 37, 112, DateTimeKind.Local).AddTicks(2420) });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreatedDate", "ProductId", "Status", "UpdatedDate" },
                values: new object[] { 2, new DateTime(2022, 6, 12, 13, 6, 37, 112, DateTimeKind.Local).AddTicks(2430), 2, 3, new DateTime(2022, 6, 12, 13, 6, 37, 112, DateTimeKind.Local).AddTicks(2430) });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductId",
                table: "Orders",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
