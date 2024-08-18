using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TunifyPlatform.Migrations
{
    /// <inheritdoc />
    public partial class AddNavigationPropertiesPlaylistSongs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_playlistSongs_playlists_PlaylistsId",
                table: "playlistSongs");

            migrationBuilder.DropForeignKey(
                name: "FK_playlistSongs_songs_SongsId",
                table: "playlistSongs");

            migrationBuilder.AlterColumn<int>(
                name: "SongsId",
                table: "playlistSongs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PlaylistsId",
                table: "playlistSongs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_playlistSongs_playlists_PlaylistsId",
                table: "playlistSongs",
                column: "PlaylistsId",
                principalTable: "playlists",
                principalColumn: "PlaylistsId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_playlistSongs_songs_SongsId",
                table: "playlistSongs",
                column: "SongsId",
                principalTable: "songs",
                principalColumn: "SongsId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_playlistSongs_playlists_PlaylistsId",
                table: "playlistSongs");

            migrationBuilder.DropForeignKey(
                name: "FK_playlistSongs_songs_SongsId",
                table: "playlistSongs");

            migrationBuilder.AlterColumn<int>(
                name: "SongsId",
                table: "playlistSongs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PlaylistsId",
                table: "playlistSongs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_playlistSongs_playlists_PlaylistsId",
                table: "playlistSongs",
                column: "PlaylistsId",
                principalTable: "playlists",
                principalColumn: "PlaylistsId");

            migrationBuilder.AddForeignKey(
                name: "FK_playlistSongs_songs_SongsId",
                table: "playlistSongs",
                column: "SongsId",
                principalTable: "songs",
                principalColumn: "SongsId");
        }
    }
}
