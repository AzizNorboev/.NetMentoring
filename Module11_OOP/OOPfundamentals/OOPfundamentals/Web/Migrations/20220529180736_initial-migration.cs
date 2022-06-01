using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatePublished = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfPages = table.Column<int>(type: "int", nullable: true),
                    Publisher = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalPublisher = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryOfLocalization = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Magazine_Publisher = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentAuthorsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Authors_Documents_DocumentAuthorsId",
                        column: x => x.DocumentAuthorsId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Documents",
                columns: new[] { "Id", "DatePublished", "Discriminator", "ISBN", "NumberOfPages", "Publisher", "Title" },
                values: new object[] { 1, new DateTime(2022, 5, 29, 23, 7, 36, 275, DateTimeKind.Local).AddTicks(6336), "Book", "12-34-56-78-90", 450, "Publisher", "Hitchhiker's guide to the galaxy" });

            migrationBuilder.InsertData(
                table: "Documents",
                columns: new[] { "Id", "DatePublished", "Discriminator", "Title" },
                values: new object[] { 5, new DateTime(2022, 5, 29, 23, 7, 36, 276, DateTimeKind.Local).AddTicks(4555), "Document", "Document Title" });

            migrationBuilder.InsertData(
                table: "Documents",
                columns: new[] { "Id", "CountryOfLocalization", "DatePublished", "Discriminator", "ISBN", "LocalPublisher", "NumberOfPages", "Publisher", "Title" },
                values: new object[] { 2, "Uzbekistan", new DateTime(2022, 5, 29, 23, 7, 36, 276, DateTimeKind.Local).AddTicks(4942), "LocalizedBook", "09-87-65-43-21", "localPublisher", 464, "Localize Publisher", "The silence of the Lambs" });

            migrationBuilder.InsertData(
                table: "Documents",
                columns: new[] { "Id", "DatePublished", "Discriminator", "Magazine_Publisher", "Title" },
                values: new object[] { 4, new DateTime(2022, 5, 29, 23, 7, 36, 276, DateTimeKind.Local).AddTicks(5775), "Magazine", "Mazagine Publisher", "Magazine Title" });

            migrationBuilder.InsertData(
                table: "Documents",
                columns: new[] { "Id", "DatePublished", "Discriminator", "ExpirationDate", "Title" },
                values: new object[] { 3, new DateTime(2022, 5, 29, 23, 7, 36, 276, DateTimeKind.Local).AddTicks(6354), "Patent", new DateTime(2025, 5, 29, 23, 7, 36, 276, DateTimeKind.Local).AddTicks(6358), "Patent" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "DocumentAuthorsId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Douglas Adams" },
                    { 2, 1, "Eoin Colfer" },
                    { 3, 1, "Thomas Tidholm" },
                    { 4, 2, "Douglas Adams" },
                    { 5, 3, "Author Patent" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Authors_DocumentAuthorsId",
                table: "Authors",
                column: "DocumentAuthorsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Documents");
        }
    }
}
