using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TunifyPlatform.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationshipsToPlaylistSongs : Migration
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

            migrationBuilder.DropIndex(
                name: "IX_playlistSongs_PlaylistsId",
                table: "playlistSongs");

            migrationBuilder.DropIndex(
                name: "IX_playlistSongs_SongsId",
                table: "playlistSongs");

            migrationBuilder.DropColumn(
                name: "PlaylistsId",
                table: "playlistSongs");

            migrationBuilder.DropColumn(
                name: "SongsId",
                table: "playlistSongs");

            migrationBuilder.CreateIndex(
                name: "IX_playlistSongs_Song_Id",
                table: "playlistSongs",
                column: "Song_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_playlistSongs_playlists_Playlist_Id",
                table: "playlistSongs",
                column: "Playlist_Id",
                principalTable: "playlists",
                principalColumn: "PlaylistsId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_playlistSongs_songs_Song_Id",
                table: "playlistSongs",
                column: "Song_Id",
                principalTable: "songs",
                principalColumn: "SongsId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_playlistSongs_playlists_Playlist_Id",
                table: "playlistSongs");

            migrationBuilder.DropForeignKey(
                name: "FK_playlistSongs_songs_Song_Id",
                table: "playlistSongs");

            migrationBuilder.DropIndex(
                name: "IX_playlistSongs_Song_Id",
                table: "playlistSongs");

            migrationBuilder.AddColumn<int>(
                name: "PlaylistsId",
                table: "playlistSongs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SongsId",
                table: "playlistSongs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_playlistSongs_PlaylistsId",
                table: "playlistSongs",
                column: "PlaylistsId");

            migrationBuilder.CreateIndex(
                name: "IX_playlistSongs_SongsId",
                table: "playlistSongs",
                column: "SongsId");

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
    }
}
