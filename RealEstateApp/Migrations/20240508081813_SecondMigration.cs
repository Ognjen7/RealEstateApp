using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstateApp.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Nekretnine",
                columns: new[] { "Id", "AgencijskaOznaka", "AgentId", "Cena", "GodinaIzgradnje", "Kvadratura", "Mesto" },
                values: new object[,]
                {
                    { 5, "Nek05", 1, 70000.0, 1974, 50.0, "Novi Sad" },
                    { 6, "Nek06", 2, 150000.0, 2020, 60.0, "Beograd" },
                    { 7, "Nek07", 3, 45000.0, 1995, 55.0, "Subotica" },
                    { 8, "Nek08", 1, 170000.0, 2010, 70.0, "Beograd" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Nekretnine",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Nekretnine",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Nekretnine",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Nekretnine",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
