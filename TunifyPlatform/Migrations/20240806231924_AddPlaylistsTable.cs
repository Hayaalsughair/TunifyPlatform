using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TunifyPlatform.Migrations
{
    /// <inheritdoc />
    public partial class AddPlaylistsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "playlists",
                columns: table => new
                {
                    PlaylistsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    Playlists_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created_Date = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_playlists", x => x.PlaylistsId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "playlists");
        }
    }
}
