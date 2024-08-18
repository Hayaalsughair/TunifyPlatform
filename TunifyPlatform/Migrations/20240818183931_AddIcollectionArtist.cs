using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TunifyPlatform.Migrations
{
    /// <inheritdoc />
    public partial class AddIcollectionArtist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArtistsId",
                table: "songs",
                type: "int",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_songs_artists_ArtistsId",
                table: "songs");

            migrationBuilder.DropIndex(
                name: "IX_songs_ArtistsId",
                table: "songs");

            migrationBuilder.DropColumn(
                name: "ArtistsId",
                table: "songs");
        }
    }
}
