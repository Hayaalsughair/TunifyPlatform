using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TunifyPlatform.Migrations
{
    /// <inheritdoc />
    public partial class AddIcollectionPlaylists : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlaylistsId",
                table: "playlistSongs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_playlistSongs_PlaylistsId",
                table: "playlistSongs",
                column: "PlaylistsId");

            migrationBuilder.AddForeignKey(
                name: "FK_playlistSongs_playlists_PlaylistsId",
                table: "playlistSongs",
                column: "PlaylistsId",
                principalTable: "playlists",
                principalColumn: "PlaylistsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_playlistSongs_playlists_PlaylistsId",
                table: "playlistSongs");

            migrationBuilder.DropIndex(
                name: "IX_playlistSongs_PlaylistsId",
                table: "playlistSongs");

            migrationBuilder.DropColumn(
                name: "PlaylistsId",
                table: "playlistSongs");
        }
    }
}
