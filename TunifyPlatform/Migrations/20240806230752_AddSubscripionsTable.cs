using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TunifyPlatform.Migrations
{
    /// <inheritdoc />
    public partial class AddSubscripionsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "subscripions",
                columns: table => new
                {
                    SubscripionsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subscripions_Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subscripions", x => x.SubscripionsId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "subscripions");
        }
    }
}
