using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TunifyPlatform.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "playlists",
                columns: new[] { "PlaylistsId", "Created_Date", "Playlists_Name", "User_Id" },
                values: new object[,]
                {
                    { 1, "2024", "Road Trip Classics", 1 },
                    { 2, "2022", "Study Focus", 2 },
                    { 3, "2021", "Party Hits", 4 }
                });

            migrationBuilder.InsertData(
                table: "songs",
                columns: new[] { "SongsId", "Album_Id", "Artist_Id", "Duration", "Genre", "Title" },
                values: new object[,]
                {
                    { 1, 1, 1, "3:53", "Pop", "Shape of You" },
                    { 2, 2, 2, "4:31", "Funk", "Uptown Funk" },
                    { 3, 4, 3, "2:02", "Children's Music", "Veggie Dance" }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "UserId", "Email", "Join_Date", "Subscription_ID", "UserName" },
                values: new object[,]
                {
                    { 1, "hayaalsughair@gmail.com", "3-8-2024", 1, "Haya" },
                    { 2, "yasmenahmad@gmail.com", "5-8-2024", 2, "Yasmen" },
                    { 3, "sara2001@gmail.com", "1-8-2024", 3, "Sara" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "playlists",
                keyColumn: "PlaylistsId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "playlists",
                keyColumn: "PlaylistsId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "playlists",
                keyColumn: "PlaylistsId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "songs",
                keyColumn: "SongsId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "songs",
                keyColumn: "SongsId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "songs",
                keyColumn: "SongsId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "UserId",
                keyValue: 3);
        }
    }
}
