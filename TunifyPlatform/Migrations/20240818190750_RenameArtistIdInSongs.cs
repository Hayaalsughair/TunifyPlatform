using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TunifyPlatform.Migrations
{
    /// <inheritdoc />
    public partial class RenameArtistIdInSongs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_songs_artists_ArtistsId",
                table: "songs");

            migrationBuilder.DropIndex(
                name: "IX_songs_ArtistsId",
                table: "songs");

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

            migrationBuilder.DropColumn(
                name: "ArtistsId",
                table: "songs");

            migrationBuilder.RenameColumn(
                name: "Artist_Id",
                table: "songs",
                newName: "ArtistId");

            migrationBuilder.InsertData(
                table: "artists",
                columns: new[] { "ArtistsId", "Bio", "Name" },
                values: new object[,]
                {
                    { 1, "Lebanese singer", "Haifa Wehbe" },
                    { 2, "Lebanese singer", "Nancy Ajram" },
                    { 3, "Egyptian singer", "Tamer Hosny" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_songs_ArtistId",
                table: "songs",
                column: "ArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_songs_artists_ArtistId",
                table: "songs",
                column: "ArtistId",
                principalTable: "artists",
                principalColumn: "ArtistsId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_songs_artists_ArtistId",
                table: "songs");

            migrationBuilder.DropIndex(
                name: "IX_songs_ArtistId",
                table: "songs");

            migrationBuilder.DeleteData(
                table: "artists",
                keyColumn: "ArtistsId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "artists",
                keyColumn: "ArtistsId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "artists",
                keyColumn: "ArtistsId",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "ArtistId",
                table: "songs",
                newName: "Artist_Id");

            migrationBuilder.AddColumn<int>(
                name: "ArtistsId",
                table: "songs",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "artists",
                columns: new[] { "ArtistsId", "Bio", "Name" },
                values: new object[,]
                {
                    { 101, "Lebanese singer", "Haifa Wehbe" },
                    { 102, "Lebanese singer", "Nancy Ajram" },
                    { 103, "Egyptian singer", "Tamer Hosny" }
                });

            migrationBuilder.UpdateData(
                table: "songs",
                keyColumn: "SongsId",
                keyValue: 1,
                column: "ArtistsId",
                value: null);

            migrationBuilder.UpdateData(
                table: "songs",
                keyColumn: "SongsId",
                keyValue: 2,
                column: "ArtistsId",
                value: null);

            migrationBuilder.UpdateData(
                table: "songs",
                keyColumn: "SongsId",
                keyValue: 3,
                column: "ArtistsId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_songs_ArtistsId",
                table: "songs",
                column: "ArtistsId");

            migrationBuilder.AddForeignKey(
                name: "FK_songs_artists_ArtistsId",
                table: "songs",
                column: "ArtistsId",
                principalTable: "artists",
                principalColumn: "ArtistsId");
        }
    }
}
