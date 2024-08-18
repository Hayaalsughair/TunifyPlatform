using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TunifyPlatform.Migrations
{
    /// <inheritdoc />
    public partial class AddArtistsSeededData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "artists",
                columns: new[] { "ArtistsId", "Bio", "Name" },
                values: new object[,]
                {
                    { 101, "Lebanese singer", "Haifa Wehbe" },
                    { 102, "Lebanese singer", "Nancy Ajram" },
                    { 103, "Egyptian singer", "Tamer Hosny" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "artists",
                keyColumn: "ArtistsId",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "artists",
                keyColumn: "ArtistsId",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "artists",
                keyColumn: "ArtistsId",
                keyValue: 103);
        }
    }
}
