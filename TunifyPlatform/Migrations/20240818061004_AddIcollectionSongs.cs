using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TunifyPlatform.Migrations
{
    /// <inheritdoc />
    public partial class AddIcollectionSongs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SongsId",
                table: "playlistSongs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_playlistSongs_SongsId",
                table: "playlistSongs",
                column: "SongsId");

            migrationBuilder.AddForeignKey(
                name: "FK_playlistSongs_songs_SongsId",
                table: "playlistSongs",
                column: "SongsId",
                principalTable: "songs",
                principalColumn: "SongsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_playlistSongs_songs_SongsId",
                table: "playlistSongs");

            migrationBuilder.DropIndex(
                name: "IX_playlistSongs_SongsId",
                table: "playlistSongs");

            migrationBuilder.DropColumn(
                name: "SongsId",
                table: "playlistSongs");
        }
    }
}
