using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TunifyPlatform.Migrations
{
    /// <inheritdoc />
    public partial class AddPlaylistSongsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "playlistSongs",
                columns: table => new
                {
                    PlaylistSongsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Playlist_Id = table.Column<int>(type: "int", nullable: false),
                    Song_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_playlistSongs", x => x.PlaylistSongsId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "playlistSongs");
        }
    }
}
