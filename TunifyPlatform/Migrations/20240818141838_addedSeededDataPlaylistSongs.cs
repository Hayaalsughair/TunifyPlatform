using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TunifyPlatform.Migrations
{
    /// <inheritdoc />
    public partial class addedSeededDataPlaylistSongs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "playlistSongs",
                columns: new[] { "Playlist_Id", "Song_Id" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 3 },
                    { 3, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "playlistSongs",
                keyColumns: new[] { "Playlist_Id", "Song_Id" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "playlistSongs",
                keyColumns: new[] { "Playlist_Id", "Song_Id" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "playlistSongs",
                keyColumns: new[] { "Playlist_Id", "Song_Id" },
                keyValues: new object[] { 3, 2 });
        }
    }
}
